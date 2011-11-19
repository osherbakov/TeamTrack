using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Istrib.Sound;
using Istrib.Sound.Formats;
using Istrib.Sound.Filters;

namespace Istrib.Sound.Filters
{
    public class CircStream : Stream, IDisposable
    {
        /// <summary>
        /// States for the VOX detection logic.
        /// </summary>
        public enum VOXStates
        {
            Idle,   // Looking for the volume above threshold
            Attack, // Waiting for the volume to become steady
            VOX_On, // Transient - VOX detected, go to Active
            Active, // Active mode
            Decay,  // No activity - waiting for the silence
            VOX_Off // Transient - Silence detected, go to Idle
        }

        /// <summary>
        /// Data passed when DataWritten event is fired
        /// </summary>
        public class DataReceivedEventArgs
                  : System.EventArgs
        {
            public byte[] buffer{get; private set;}
            public int index { get; private set; }
            public int count { get; private set; }

            internal DataReceivedEventArgs(byte[] buffer, int index, int count)
            {
                this.buffer = buffer;
                this.index = index;
                this.count = count;
            }
        }


        public VOXStates State { get; private set; }

        public int NAttack { get; set; }
        public int NDecay { get; set; }
        public int VolumeThreshold { get; set; }

        public int VolumeL { get; private set; }
        public int VolumeR { get; private set; }
        
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        private MemoryStream memStream = null;
        private byte[] ByteArray;
        private int WritePosition = 0;
        private int TotalSize = 0;
        private bool BufferFull = false;
        private int TimeoutCounter = 0;

        public override bool  CanTimeout { get { return false;}}
        public override bool  CanRead { get { return true;}}
        public override bool  CanWrite { get { return true;}}
        public override bool  CanSeek { get { return false;}}
        public override void  Close() { base.Close(); DestroyBuffer(); }
        protected override void  Dispose(bool disposing){	 base.Dispose(disposing);}
        public override void  Flush() { }
        public override long  Length 
        {
            get
            {
                int BytesAvailable = BufferFull ? TotalSize : WritePosition;
                return BytesAvailable;
            }
        }
        private void DestroyBuffer()
        {
            if (memStream != null)
            {
                Clear();
                memStream.SetLength(0);
                memStream.Close();
                memStream = null;
                ByteArray = null;
            }
        }

        public new void Dispose()
        {
            DestroyBuffer();
        }


        public void Clear()
        {
            WritePosition = 0;
            BufferFull = false;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int BytesAvailable = BufferFull ? TotalSize : WritePosition;
            count = Math.Min(BytesAvailable, count);

            if (BufferFull)
            {
                int size_read = Math.Min(count, TotalSize - WritePosition);
                memStream.Seek(WritePosition, SeekOrigin.Begin);
                memStream.Read(buffer, offset, size_read);
                if (size_read < count)
                {
                    offset += size_read;
                    size_read = count - size_read;
                    memStream.Seek(0, SeekOrigin.Begin);
                    memStream.Read(buffer, offset, size_read);
                }
            }
            else
            {
                memStream.Seek(0, SeekOrigin.Begin);
                memStream.Read(buffer, offset, count);
            }
            return count;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            int idx = offset;
            count = Math.Min(TotalSize, count);
            memStream.Seek(WritePosition, SeekOrigin.Begin);

            int NextPosition = WritePosition + count;
            if (NextPosition >= TotalSize)
            {
                NextPosition -= TotalSize;
                BufferFull = true;

                int size_write = Math.Min(count, TotalSize - WritePosition);

                memStream.Write(buffer, idx, size_write);
                idx += size_write;
                size_write = count - size_write;
                memStream.Seek(0, SeekOrigin.Begin);
                memStream.Write(buffer, idx, size_write);
            }
            else
            {
                memStream.Write(buffer, idx, count);
            }
            WritePosition = NextPosition;

            ProcessAudioData(buffer, offset, count);
        }
        
        private void ProcessAudioData(byte[] buffer, int offset, int count)
        {
            int idx = offset;
            double Sum = 0;

            int NumSamples = count / 2;

            for (int i = 0; i < NumSamples; i++)
            {
                int Sample = BitConverter.ToInt16(buffer, idx);
                Sum += Math.Abs(Sample);
                idx += 2;
            }
            
            Sum = Sum / NumSamples;

            VolumeL = (int)Math.Max(Sum, Sum * 0.9 + VolumeL * 0.1);
            VolumeR = (int)Math.Max(Sum, Sum * 0.9 + VolumeR * 0.1);

            switch (State)
            {
                case VOXStates.Idle:
                    if (VolumeL > VolumeThreshold)
                    {
                        State = VOXStates.Attack;
                        TimeoutCounter = NAttack;
                    }
                    break;

                case VOXStates.Attack:
                    if (VolumeL < VolumeThreshold)
                    {
                        State = VOXStates.Idle;
                    }
                    else if (--TimeoutCounter <= 0)
                    {
                        State = VOXStates.VOX_On;
                    }
                    break;

                case VOXStates.VOX_On:
                    State = VOXStates.Active;
                    break;

                case VOXStates.Active:
                    if (VolumeL < VolumeThreshold)
                    {
                        State = VOXStates.Decay;
                        TimeoutCounter = NDecay;
                    }
                    break;

                case VOXStates.Decay:
                    if (VolumeL > VolumeThreshold)
                    {
                        State = VOXStates.Active;

                    }else if (--TimeoutCounter <= 0)
                    {
                        State = VOXStates.VOX_Off;
                    }
                    break;

                case VOXStates.VOX_Off:
                    Clear();
                    State = VOXStates.Idle;
                    break;
            }
            if (DataReceived != null) DataReceived(this, new DataReceivedEventArgs(buffer, offset, count));
        }

        public override void SetLength(long value)
        {
            
            TotalSize = (int) value;
            ByteArray = new byte[value];
            memStream = new MemoryStream(ByteArray, true);
            BufferFull = false;
            WritePosition = 0;
            State = VOXStates.Idle;
        }

        public override long Position
        {
            get
            {
                return WritePosition;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }
    }

    public class VOXFilter
        : SoundFilter, IDisposable
    {
        private CircStream _stream = null;
        private int _NAttack;
        private int _NDecay;
        private int _VolumeThreshold;

        public event EventHandler VOXStarting;
        public event EventHandler VOXStopping;

        public int NAttack { get { return _NAttack; } set { _NAttack = value; if (_stream != null) _stream.NAttack = value; } }
        public int NDecay { get { return _NDecay; } set { _NDecay = value; if(_stream != null) _stream.NDecay = value; } }
        public int VolumeThreshold { get { return _VolumeThreshold; } set { _VolumeThreshold = value; if (_stream != null) _stream.VolumeThreshold = value; } }

        public int VolumeL { get { return _stream != null ? _stream.VolumeL : 0; } }
        public int VolumeR { get { return _stream != null ? _stream.VolumeR : 0; } }
        public bool VOXActive
        {
            get
            {
                CircStream.VOXStates curr_state = _stream != null ? _stream.State : CircStream.VOXStates.Idle;

                return !((curr_state == CircStream.VOXStates.Idle) ||
                    (curr_state == CircStream.VOXStates.Attack)); 
            }
        }

        /// <summary>
        /// The stream that received input for the filter
        /// </summary>
        public override System.IO.Stream Input
        {
            get
            {
                return _stream;
            }
        }

        /// <summary>
        /// Raw PCM
        /// </summary>
        public override Type RequiredInputFormatType
        {
            get { return typeof(PcmSoundFormat); }
        }

        /// <summary>
        /// The same as actual input format.
        /// </summary>
        public override Istrib.Sound.Formats.ISoundFormat OutputFormat
        {
            get { return InputFormat; }
        }

        public VOXFilter(int SizeInBytes)
        {
            _stream = new CircStream();
            _stream.SetLength(SizeInBytes);
            _stream.DataReceived += new EventHandler<CircStream.DataReceivedEventArgs>(OnDataReceived);
        }

        void OnDataReceived(object sender, CircStream.DataReceivedEventArgs e)
        {
            CircStream cs = (CircStream) sender;
            if ( (cs.State == CircStream.VOXStates.Active) ||
                 (cs.State == CircStream.VOXStates.Decay) )
            {
                Output.Write(e.buffer, e.index, e.count);
            }
            else if (cs.State == CircStream.VOXStates.VOX_On)
            {
                BinaryWriter output = new BinaryWriter(Output);
                BinaryReader input = new BinaryReader(_stream);
                output.Write(input.ReadBytes((int)input.BaseStream.Length));
                if (VOXStarting != null) VOXStarting.BeginInvoke(this, EventArgs.Empty, new AsyncCallback(EndCallback), VOXStarting);
            }
            else if (cs.State == CircStream.VOXStates.VOX_Off)
            {
                Output.Flush();
                if (VOXStopping != null) VOXStopping.BeginInvoke(this, EventArgs.Empty, new AsyncCallback(EndCallback), VOXStopping);
            }
        }

        private void EndCallback(IAsyncResult ar)
        {
            ((EventHandler)(ar.AsyncState)).EndInvoke(ar);
        }

        protected internal override void OnStreamingStoppedSuspended(SoundStreamingStatus streamingStatus)
        {
            try
            {
                base.OnStreamingStoppedSuspended(streamingStatus);
            }
            finally
            {
                DestroyBuffer();
            }
        }

        private void DestroyBuffer()
        {
            if (_stream != null)
            {
                _stream.Close();
                _stream = null;
            }
        }

        public void Dispose()
        {
            DestroyBuffer();
        }
    }
}
