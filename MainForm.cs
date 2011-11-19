using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.DirectX.DirectSound;
using Istrib.Sound;

namespace TeamTrack
{

    public partial class MainForm : Form
    {
        // Assembly of all visible and trackable objects - teams and Places
        Dictionary<string, PlaceData> m_Places = new Dictionary<string, PlaceData>();
        Dictionary<string, TeamData> m_Teams = new Dictionary<string, TeamData>();
        
        // List of current Ports
        List<string> m_CommPortNames = new List<string>();

        //List of current Capture Devices
        List<string> m_CaptureNames = new List<string>();
        
        // GPS Tracking object - receives the Serial data and fires events
        GPSTrack m_TrackData = new GPSTrack();

        // The HTTP servers that handle Google Earth requests
        Httpserver m_TrackingServer = new Httpserver();
        Httpserver m_HistoryServer = new Httpserver();

        // Number of records added to the database
        int m_RecordsAdded = 0;

        // The Manual Log entry window 
        LogEntry m_LogEntry = new LogEntry();

        // The events that is fired when new tracking data, or any status change in general, is available
        private delegate void UpdateTrackingStatus(TrackingData Data);
        private delegate void UpdateAudioStatus(List<string> CaptureDevices);
        private delegate void UpdateStatus();
        private delegate void StartCapture(string DeviceName, string FileDirectory, int BuffSize, int MinSignal, int Threshold);
        private delegate void StopCapture();


        public MainForm()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// Called when context (Right mouse click) menu is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusContextMenu_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip cm = (ContextMenuStrip)sender;
            if (StatusView.SelectedItems.Count == 0)
            {
                cm.Items["StartTracking"].Enabled = false;
                cm.Items["StopTracking"].Enabled = false;
                cm.Items["Remove"].Enabled = false;
                cm.Items["AddTeam"].Enabled = true;
                cm.Items["AddPlace"].Enabled = true;
            }
            else
            {
                String lvigs = StatusView.SelectedItems[0].Group.Name;
                if (lvigs.Equals("Tracking"))
                {
                    cm.Items["StartTracking"].Enabled = false;
                    cm.Items["StopTracking"].Enabled = true;
                    cm.Items["Remove"].Enabled = false;
                    cm.Items["AddTeam"].Enabled = true;
                    cm.Items["AddPlace"].Enabled = false;
                }
                else if (lvigs.Equals("Active"))
                {
                    cm.Items["StartTracking"].Enabled = true;
                    cm.Items["StopTracking"].Enabled = false;
                    cm.Items["Remove"].Enabled = true;
                    cm.Items["AddTeam"].Enabled = true;
                    cm.Items["AddPlace"].Enabled = false;
                }
                else if (lvigs.Equals("Places"))
                {
                    cm.Items["StartTracking"].Enabled = false;
                    cm.Items["StopTracking"].Enabled = false;
                    cm.Items["Remove"].Enabled = true;
                    cm.Items["AddTeam"].Enabled = false;
                    cm.Items["AddPlace"].Enabled = true;
                }
                else if (lvigs.Equals("Delayed"))
                {
                    cm.Items["StartTracking"].Enabled = false;
                    cm.Items["StopTracking"].Enabled = true;
                    cm.Items["Remove"].Enabled = false;
                    cm.Items["AddTeam"].Enabled = true;
                    cm.Items["AddPlace"].Enabled = false;
                }
                else
                {
                    cm.Items["StartTracking"].Enabled = false;
                    cm.Items["StopTracking"].Enabled = false;
                    cm.Items["Remove"].Enabled = false;
                    cm.Items["AddTeam"].Enabled = true;
                    cm.Items["AddPlace"].Enabled = true;
                }
            }
        }

        /// <summary>
        /// Called to stop Team tracking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopTracking_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = StatusView.SelectedItems[0];
            lvi.Group = StatusView.Groups["Active"];
            if (m_Teams.ContainsKey(lvi.Text))
            {
                m_Teams[lvi.Text].Status = TrackStatus.ACTIVE;
            }
        }
        /// <summary>
        /// Called to start Team tracking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartTracking_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = StatusView.SelectedItems[0];
            lvi.Group = StatusView.Groups["Tracking"];
            if (m_Teams.ContainsKey(lvi.Text))
            {
                m_Teams[lvi.Text].Status = TrackStatus.TRACKING;
            }
        }

        /// <summary>
        /// called to remove Team/Object from the status window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, EventArgs e)
        {
            if (StatusView.SelectedItems.Count != 0)
            {
                ListViewItem lvi = StatusView.SelectedItems[0];
                String lvigs = lvi.Group.Name;
                if (lvigs.Equals("Places"))
                {
                    m_Places.Remove(lvi.Name);
                }
                else
                {
                    m_Teams.Remove(lvi.Text);
                }
                lvi.Remove();
            }
        }

        /// <summary>
        /// Called to add Team/Object to the tracking window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTeam_Click(object sender, EventArgs e)
        {
            AddTeam at_dlg = new AddTeam();
            at_dlg.m_PlaceData = m_Places;

            while(at_dlg.ShowDialog() == DialogResult.OK)
            {
                if (m_Teams.ContainsKey(at_dlg.m_TeamData.CID))
                {
                    MessageBox.Show("The Combat ID entered is already in the list.\nPlease re-enter", "Incorrect CID");
                    continue;
                }
                else
                {
                    ListViewItem lvi = new ListViewItem();
                    TeamData td = at_dlg.m_TeamData;
                    td.Status = TrackStatus.TRACKING;

                    lvi.Group = StatusView.Groups["Tracking"];
                    lvi.Name = td.CID;
                    lvi.Text = td.CID;
                    lvi.SubItems.Add(td.Name);
                    lvi.SubItems.Add(td.Coordinates.MGRS + " / " + td.Coordinates.Latitude.ToString("N6") + ", " + td.Coordinates.Longitude.ToString("N6"));

                    DateTime add_time = DateTime.Now;
                    td.Coordinates.Time = add_time;
                    lvi.SubItems.Add(add_time.ToShortTimeString() + add_time.ToUniversalTime().ToString(" (HH:mm:ssZ)"));
                    m_Teams.Add(td.CID, td); UpdateTrackingHistory(td);
                    StatusView.Items.Add(lvi);
                    break;
                }
            }
        }

        /// <summary>
        /// Called to add Place to the tracking window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPlace_Click(object sender, EventArgs e)
        {
            AddPlace ap_dlg = new AddPlace();
            while (ap_dlg.ShowDialog() == DialogResult.OK)
            {
                if (m_Places.ContainsKey(ap_dlg.m_PlaceData.Name))
                {
                    MessageBox.Show("The Place name entered is already in the list.\nPlease re-enter", "Incorrect data");
                    continue;
                }
                else
                {
                    PlaceData pd = ap_dlg.m_PlaceData;

                    ListViewItem lvi = new ListViewItem();
                    lvi.Group = StatusView.Groups["Places"];
                    lvi.Name = pd.Name;
                    lvi.Text = "*****";
                    lvi.SubItems.Add(pd.Name);
                    lvi.SubItems.Add(pd.Coordinates.MGRS + " / " + pd.Coordinates.Latitude.ToString("N6") + ", " + pd.Coordinates.Longitude.ToString("N6"));
                    DateTime add_time = DateTime.Now;
                    pd.Coordinates.Time = add_time;
                    lvi.SubItems.Add(add_time.ToShortTimeString() + add_time.ToUniversalTime().ToString(" (HH:mm:ssZ)"));
                    m_Places.Add(pd.Name, pd); UpdateTrackingHistory(pd);
                    StatusView.Items.Add(lvi);
                    break;
                }
            }
        }

        /// <summary>
        /// Called when user double-clicks on the Team/Place - bring appropriate dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusView_DoubleClick(object sender, EventArgs e)
        {
            if (StatusView.SelectedItems.Count != 0)
            {
                ListViewItem lvi = StatusView.SelectedItems[0];
                String lvigs = lvi.Group.Name;
                if (lvigs.Equals("Places"))
                {
                    AddPlace ap_dlg = new AddPlace();
                    if(m_Places.ContainsKey(lvi.Name))
                    {
                        ap_dlg.m_PlaceData = m_Places[lvi.Name];
                    }else
                    {
                        PlaceData pd = new PlaceData();
                        pd.Name = lvi.SubItems[1].Text; 
                        pd.Coordinates.MGRS = lvi.SubItems[2].Text;
                        ap_dlg.m_PlaceData = pd;
                    }
                    ap_dlg.Text = "Change/View Place";
                    if (ap_dlg.ShowDialog() == DialogResult.OK)
                    {
                        PlaceData pd = ap_dlg.m_PlaceData;
                        m_Places[pd.Name] = pd; UpdateTrackingHistory(pd);

                        lvi.SubItems.Clear();
                        lvi.Name = pd.Name;
                        lvi.Text = "*****";
                        lvi.SubItems.Add(pd.Name);
                        lvi.SubItems.Add(pd.Coordinates.MGRS + " / " + pd.Coordinates.Latitude.ToString("N6") + ", " + pd.Coordinates.Longitude.ToString("N6"));
                        DateTime add_time = DateTime.Now;
                        lvi.SubItems.Add(add_time.ToShortTimeString() + add_time.ToUniversalTime().ToString(" (HH:mm:ssZ)"));
                    }
                }
                else
                {
                    AddTeam at_dlg = new AddTeam();
                    at_dlg.m_PlaceData = m_Places;

                    if (m_Teams.ContainsKey(lvi.Text))
                    {
                        at_dlg.m_TeamData = m_Teams[lvi.Text];
                    }
                    else
                    {
                        TeamData td = new TeamData();
                        td.CID = lvi.Text;
                        td.Name = lvi.SubItems[1].Text; 
                        td.Coordinates.MGRS = lvi.SubItems[2].Text;
                        at_dlg.m_TeamData = td;
                    }
                    at_dlg.Text = "Change/View Team";
                    if (at_dlg.ShowDialog() == DialogResult.OK)
                    {
                        TeamData td = at_dlg.m_TeamData;
                        td.Coordinates.Time = DateTime.Now;
                        m_Teams[td.CID] = td;  UpdateTrackingHistory(td);
                        lvi.SubItems.Clear();
                        lvi.Name = td.CID;
                        lvi.Text = td.CID;
                        lvi.SubItems.Add(td.Name);
                        lvi.SubItems.Add(td.Coordinates.MGRS + " / " + td.Coordinates.Latitude.ToString("N6") + ", " + td.Coordinates.Longitude.ToString("N6"));
                        DateTime add_time = td.Coordinates.Time;
                        lvi.SubItems.Add(add_time.ToShortTimeString() + add_time.ToUniversalTime().ToString(" (HH:mm:ssZ)"));
                    }
                }
           }
        }

        private void UpdateComPortsListBox()
        {
            bool needs_refresh = false;
            string []new_ports = SerialPort.GetPortNames();
            if (new_ports.Length == m_CommPortNames.Count)
            {
                for(int i = 0; i < new_ports.Length; i++)
                {
                    if (!m_CommPortNames[i].Equals(new_ports[i]))
                    {
                        needs_refresh = true;
                        break;
                    }
                }
            }
            else
            {
                needs_refresh = true;
            }
            if (needs_refresh)
            {
                string _selected = ConfigComPorts.Text;
                m_CommPortNames.Clear();
                m_CommPortNames.AddRange(new_ports);

                ConfigComPorts.SuspendLayout();
                ConfigComPorts.Items.Clear();
                ConfigComPorts.Items.AddRange(new_ports);
                ConfigComPorts.Text = _selected;
                ConfigComPorts.SelectedItem = _selected;
                ConfigComPorts.SelectedValue = _selected;
                ConfigComPorts.ResumeLayout();
            }
        }

        private void UpdateCaptureDevicesListBox(List<string> CaptureDevices)
        {
            bool needs_refresh = false;
            
            int Count = CaptureDevices.Count;
            if (Count == m_CaptureNames.Count)
            {
                int i = 0;
                foreach (string scd in CaptureDevices)
                {
                    // Change detected - set needs_refresh flag and break
                    if (!scd.Equals(m_CaptureNames[i]))
                    {
                        needs_refresh = true;
                        break;
                    }
                    i++;
                }
            }
            else
            {
                needs_refresh = true;
            }

            // Changes in the list detected
            if (needs_refresh)
            {
                // Save previously selected
                string _selected = m_AudioCapDevices.Text;
                m_CaptureNames.Clear();

                m_AudioCapDevices.SuspendLayout();
                m_AudioCapDevices.Items.Clear();

               // Populate the dropdown listbox
                m_AudioCapDevices.Items.AddRange(CaptureDevices.ToArray());
                m_CaptureNames.AddRange(CaptureDevices);
                m_AudioCapDevices.Text = _selected;
                m_AudioCapDevices.SelectedItem = _selected;
                m_AudioCapDevices.SelectedValue = _selected;
                m_AudioCapDevices.ResumeLayout();
            }
        }

        private void UpdateTeamStatus()
        {
            // Go thru the list of all teams and find out those who failed to report
            int last_check = 5;
            int.TryParse(Delayed_time.Text, out last_check);
            DateTime check_due_time = DateTime.Now.AddMinutes(-last_check);
            foreach (TeamData td in m_Teams.Values)
            {
                if (td.Status == TrackStatus.TRACKING && td.Coordinates.Time < check_due_time)
                {
                    td.Status = TrackStatus.DELAYED;
                    UpdateTeamDisplay(td);
                }
            }
        }

        private void UpdateAudioDevices()
        {
            UpdateStatus us = new UpdateStatus(DoCaptureEnumeration);
            us.BeginInvoke(new AsyncCallback(EndCaptureEnumeration), us); 
        }

        private void EndCaptureEnumeration(IAsyncResult ar)
        {
            ((UpdateStatus)ar.AsyncState).EndInvoke(ar);
        }

        private void DoCaptureEnumeration()
        {
            List<string> allCaptureDevices = new List<string>();
            foreach (SoundCaptureDevice scd in SoundCaptureDevice.AllAvailable)
            {
                allCaptureDevices.Add(scd.Description);
            }

            if (m_AudioCapDevices.InvokeRequired)
            {
                m_AudioCapDevices.Invoke(new UpdateAudioStatus(UpdateCaptureDevicesListBox), allCaptureDevices);
            }
            else
            {
                UpdateCaptureDevicesListBox(allCaptureDevices);
            }
        }


        private void PeriodicTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Calculate and start the next update period
                int next_tick = 5;
                int.TryParse(PollInterval.Text, out next_tick);
                next_tick = Math.Max(next_tick, 5); // Default is 5 seconds

                // Restart Timer
                PeriodicTimer.Stop();
                PeriodicTimer.Interval = next_tick * 1000;
                PeriodicTimer.Start();

                // Send the request to the MBITR
                if (m_SerialCommPort.IsOpen)
                {
                    m_SerialCommPort.WriteLine("/77");
                }

                UpdateTeamStatus();
                UpdateComPortsListBox();
                UpdateHttpStatus();
                UpdateAudioDevices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                m_statusStrip.Items[0].Text = ex.ToString();
            }
        }

        private void ConfigComPorts_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_SerialCommPort.IsOpen)
                {
                    m_SerialCommPort.DiscardInBuffer();
                    m_SerialCommPort.DiscardOutBuffer();
                    m_SerialCommPort.Close();
                }
                    
                if (!string.IsNullOrEmpty(ConfigComPorts.Text))
                {
                    m_SerialCommPort.PortName = ConfigComPorts.Text;
                    m_SerialCommPort.BaudRate = 9600;
                    m_SerialCommPort.DataBits = 8;
                    m_SerialCommPort.Parity = System.IO.Ports.Parity.None;
                    m_SerialCommPort.StopBits = System.IO.Ports.StopBits.One;
                    m_SerialCommPort.Handshake = System.IO.Ports.Handshake.None;
                    m_SerialCommPort.ReadTimeout = 2000;
                    m_SerialCommPort.WriteTimeout = SerialPort.InfiniteTimeout;
                    m_SerialCommPort.DiscardNull = true;
                    m_SerialCommPort.ReadBufferSize = 1024;
                    m_SerialCommPort.WriteBufferSize = 1024;
                    m_SerialCommPort.Open();
                    m_statusStrip.Items[0].Text = String.Format("{0} is open successfully.", m_SerialCommPort.PortName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                m_statusStrip.Items[0].Text = String.Format("Error opening {0}.", m_SerialCommPort.PortName);
            }
        }


        private void UpdateCommStatusLine()
        {
            m_statusStrip.Items[0].Text = String.Format("{0} is receiving Data", m_SerialCommPort.PortName);
        }


        /// <summary>
        /// Event handler for the data received from the serial port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialCommlPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (m_statusStrip.InvokeRequired)
            {
                m_statusStrip.Invoke(new UpdateStatus(UpdateCommStatusLine));
            }
            else
            {
                UpdateCommStatusLine();
            }
            m_TrackData.ProcessTrackingData(m_SerialCommPort.ReadExisting());
        }


        private void UpdateTeamDisplay(TeamData td)
        {
            StatusView.BeginUpdate();
            StatusView.Items.RemoveByKey(td.CID);

            ListViewItem lvi = new ListViewItem();
            lvi.Text = td.CID;
            lvi.Name = td.CID;
            lvi.SubItems.Add(td.Name);
            lvi.SubItems.Add(td.Coordinates.MGRS + " / " + td.Coordinates.Latitude.ToString("N6") + ", " + td.Coordinates.Longitude.ToString("N6"));
            DateTime add_time = td.Coordinates.Time;
            lvi.SubItems.Add(add_time.ToShortTimeString() + add_time.ToUniversalTime().ToString(" (HH:mm:ssZ)"));
            if (td.Status == TrackStatus.TRACKING)
            {
                lvi.Group = StatusView.Groups["Tracking"];
            }
            else if (td.Status == TrackStatus.DELAYED)
            {
                lvi.Group = StatusView.Groups["Delayed"];
            }
            else
            {
                lvi.Group = StatusView.Groups["Active"];
            }
            StatusView.Items.Add(lvi);
            StatusView.EndUpdate();
        }

        private void UpdateTeamStatus(TrackingData Data)
        {
            TeamData td;
            ListViewItem lvi = new ListViewItem();
            try
            {
                int _prev_speed = 0;
                int _prev_direction = 0;

                if (m_Teams.ContainsKey(Data.CID))
                {
                    td = m_Teams[Data.CID];
                    // The GPS update came - change the status from Delayed to Tracking
                    if (td.Status == TrackStatus.DELAYED)
                    {
                        td.Status = TrackStatus.TRACKING;
                    }
                    _prev_speed = td.Coordinates.Speed;
                    _prev_direction = td.Coordinates.Direction;
                    if (_prev_direction > 180) _prev_direction -= 180;
                }
                else
                {
                    td = new TeamData();
                    td.CID = Data.CID;
                    td.Status = TrackStatus.TRACKING;
                    td.Name = Data.CID;
                }
                td.Coordinates = Data.Coordinates;
                td.Coordinates.MGRS = GPSTrack.FormatMGRS(td.Coordinates.MGRS);
                td.Coordinates = GPSTrack.MGRS_To_LatLon(td.Coordinates);
                td.Coordinates.Time = DateTime.Now;
                td.Coordinates.Speed = (td.Coordinates.Speed + _prev_speed) / 2;
                if (td.Coordinates.Direction > 180) td.Coordinates.Direction -= 180;
                td.Coordinates.Direction = (td.Coordinates.Direction + _prev_direction) / 2;
                if (td.Coordinates.Direction < 0) td.Coordinates.Direction += 180;

                m_Teams[td.CID] = td; 
                UpdateTrackingHistory(td);
                UpdateTeamDisplay(td);
                m_statusStrip.Items[0].Text = String.Format("{0} is receiving SA updates", m_SerialCommPort.PortName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
            }
        }

        // Update positions of all Teams who are Tracked or Delayed
        // Update the positions of all Places/
        // This function sends the list of teams to the HTTP server
        /// <summary>
        /// Sends the list of tracked items to http server.
        /// </summary>
        private void UpdateHttpStatus()
        {
            List<TeamData> ltd = new List<TeamData>();
            foreach (TeamData tdi in m_Teams.Values)
            {
                if ((tdi.Status == TrackStatus.TRACKING) ||
                    (tdi.Status == TrackStatus.DELAYED) )
                {
                    ltd.Add(tdi);
                }
            }
            foreach (PlaceData pdi in m_Places.Values)
            {
                TeamData tdi = new TeamData();
                tdi.Description = pdi.Description;
                tdi.Name = pdi.Name;
                tdi.Coordinates = pdi.Coordinates;
                tdi.Status = TrackStatus.PLACES;
                ltd.Add(tdi);
            }
            m_TrackingServer.Update(ltd);
        }

        private void NewTrackingInfoReceived(object sender, EventArgs e)
        {
            TrackingData td = ((GPSTrack) sender).NewData;
            if (StatusView.InvokeRequired)
            {
                StatusView.Invoke(new UpdateTrackingStatus(this.UpdateTeamStatus), td);
            }
            else
            {
                UpdateTeamStatus(td);
            }
        }

        private void UpdateTrackingHistory(TeamData td)
        {
            try
            {
                string Geo = td.Coordinates.Longitude.ToString("N6") + "," + td.Coordinates.Latitude.ToString("N6");
                m_historyTableAdapter.Insert(td.CID, td.Name, td.Coordinates.MGRS, Geo,
                    td.Coordinates.Altitude.ToString(), td.Coordinates.Direction.ToString(), td.Coordinates.Speed.ToString(), 
                        td.Coordinates.Time, td.Description, null, null);
                m_statusStrip.Items[2].Text = String.Format("History writing :{0}({1}).", m_historyTableAdapter.Connection.DataSource, ++m_RecordsAdded);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                m_statusStrip.Items[2].Text = String.Format("History writing error: {0}.", ex.Message);
            }
        }

        private void UpdateTrackingHistory(PlaceData pd)
        {
            try
            {
                string Geo = pd.Coordinates.Longitude.ToString("N6") + "," + pd.Coordinates.Latitude.ToString("N6");
                m_historyTableAdapter.Insert(pd.Name, pd.Name, pd.Coordinates.MGRS, Geo,
                    pd.Coordinates.Altitude.ToString(), pd.Coordinates.Direction.ToString(), pd.Coordinates.Speed.ToString(), 
                        pd.Coordinates.Time, pd.Description, null, null);
                m_statusStrip.Items[2].Text = String.Format("History writing :{0}({1}).", m_historyTableAdapter.Connection.DataSource, ++m_RecordsAdded);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                m_statusStrip.Items[2].Text = String.Format("History writing error: {0}.", ex.Message);
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            int new_track_port = 0;

            m_statusStrip.Items[0].Text = String.Format("No ComPort is open.");
            
            UpdateComPortsListBox();
            ConfigComPorts_SelectedValueChanged(this, EventArgs.Empty);

            UpdateAudioDevices();
            m_AudioCapDevices_SelectedValueChanged(this, EventArgs.Empty);

            try
            {
                m_historyTableAdapter.Connection.Open();
                m_statusStrip.Items[2].Text = String.Format("History writing :{0}.", m_historyTableAdapter.Connection.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                m_statusStrip.Items[2].Text = String.Format("History writing error : {0}.", ex.Message);
            }

            this.DesktopLocation = new Point(0, 0);

            // Start Log Entry Window
            m_LogEntry.Show(this);
            m_LogEntry.DesktopLocation = new Point(Location.X + Width, Location.Y + Height / 2);

            try
            {
                m_TrackData.TrackReceived += NewTrackingInfoReceived;
                int.TryParse(Track_Port.Text, out new_track_port);
                if (new_track_port >= 80)
                {
                    m_TrackingServer.Start(SERVER_TYPE.TRACKING, new_track_port);
                }
                History_Port_Time_Validated(this, EventArgs.Empty);
                m_statusStrip.Items[1].Text = String.Format("Http Server on Ports {0}.", new_track_port);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                m_statusStrip.Items[1].Text = String.Format("Error starting http Server on Ports {0}.", new_track_port);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing &&  
                    MessageBox.Show("Are you sure you want \n to close the application?", "Application Closing", 
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }else
            {
                e.Cancel = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (m_SerialCommPort.IsOpen)
                {
                    m_SerialCommPort.DiscardOutBuffer();
                    m_SerialCommPort.DiscardInBuffer();
                    m_SerialCommPort.Close();
                }
                if (m_historyTableAdapter.Connection.State == ConnectionState.Open)
                {
                    m_historyTableAdapter.Connection.Close();
                }

                m_TrackingServer.Stop();
                m_HistoryServer.Stop();
                m_UVMetersTimer.Enabled = false;
                m_UVMetersTimer.Stop();

                StopCapture sc = new StopCapture(DoAsyncStopCapture);
                sc.EndInvoke(sc.BeginInvoke(null, null));

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
            }
        }


        private void Track_Port_Validated(object sender, EventArgs e)
        {
            int new_track_port = 0;
            try
            {
                int.TryParse(Track_Port.Text, out new_track_port);
                if (new_track_port >= 80)
                {
                    m_TrackingServer.Stop();
                    m_TrackingServer.Start(SERVER_TYPE.TRACKING, new_track_port);
                }
                m_statusStrip.Items[1].Text = String.Format("Http Server on Port {0}.", new_track_port);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                m_statusStrip.Items[1].Text = String.Format("Error opening http Server on Port {0}.", new_track_port);
            }
        }

        /// <summary>
        /// Called when both History and Delay are validated.
        /// Re-initializes the Port and statrs sending new history data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void History_Port_Time_Validated(object sender, EventArgs e)
        {
            int new_history_port = 0;
            int new_history_time = 5;
            try
            {
                int.TryParse(History_Port.Text, out new_history_port);
                int.TryParse(History_Time.Text, out new_history_time);
                if (new_history_port >= 80)
                {
                    m_HistoryServer.Stop();
                    m_HistoryServer.Start(SERVER_TYPE.HISTORY, new_history_port);
                }
                m_HistoryServer.Update(DateTime.Now.AddHours(-new_history_time));
                m_statusStrip.Items[1].Text = String.Format("Http history Server on Port {0}.", new_history_port);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                m_statusStrip.Items[1].Text = String.Format("Error opening http history Server on Port {0}", new_history_port);
            }
        }

        /// <summary>
        /// Processes the button and brings the Directory Select dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_AudioFolderClick(object sender, EventArgs e)
        {
            if (m_AudioFolderBrowserDlg.ShowDialog() == DialogResult.OK)
            {
                m_AudioDir.Text = m_AudioFolderBrowserDlg.SelectedPath;
            }
        }

        private void DoAsyncStartCapture(string CaptureDeviceName, string FileDirectory, int BuffSize, int MinSize, int Threshold)
        {
            DoAsyncStopCapture();
            foreach (SoundCaptureDevice scd in SoundCaptureDevice.AllAvailable)
            {
                if (scd.Description.ToUpper().Contains(CaptureDeviceName.ToUpper()))
                {
                    if (!String.IsNullOrEmpty(FileDirectory))
                    {
                        m_mp3SoundCapture.CaptureDevice = new SoundCaptureDevice(scd.Description, scd.DriverGuid, scd.ModuleName);
                        m_mp3SoundCapture.BufferSeconds = BuffSize;
                        m_mp3SoundCapture.MinSoundSeconds = MinSize;
                        m_mp3SoundCapture.VOXThreshold = (int)Threshold;
                        m_mp3SoundCapture.IsDirectory = true;
                        m_mp3SoundCapture.Start(FileDirectory);
                    }
                    break;
                }
            }
        }

        private void DoAsyncStopCapture()
        {
            if (m_mp3SoundCapture.Capturing)
            {
                m_mp3SoundCapture.WaitOnStop = true;
                m_mp3SoundCapture.Stop();
                m_mp3SoundCapture.Dispose();
            }
        }

        private void m_AudioCapDevices_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(m_AudioDir.Text) && !String.IsNullOrEmpty(m_AudioCapDevices.Text))
            {
                double ThreshVal = ((double)m_ThreshAdj.Value) / (m_ThreshAdj.Maximum - m_ThreshAdj.Minimum);
                ThreshVal = Math.Pow(Int16.MaxValue, ThreshVal);

                StartCapture sc = new StartCapture(DoAsyncStartCapture);
                sc.EndInvoke(sc.BeginInvoke(m_AudioCapDevices.Text, m_AudioDir.Text, 
                                (int)m_BuffTime.Value, (int) m_SkipTime.Value, (int) ThreshVal, 
                                    null, null));
  
                m_UVMetersTimer.Enabled = true;
                m_UVMetersTimer.Start();
            }
        }

        private void m_UVMeters_Tick(object sender, EventArgs e)
        {
            double OneBit = Math.Log(Int16.MaxValue);
            double LVal = m_mp3SoundCapture.VolumeL;
            double RVal = m_mp3SoundCapture.VolumeR;


            LVal = (LVal == 0) ? 0.0 : (Math.Log(LVal) / OneBit);
            RVal = (RVal == 0) ? 0.0 : (Math.Log(RVal) / OneBit); 

            m_LeftChan.Value = (int)(m_LeftChan.Minimum +  LVal * (m_LeftChan.Maximum - m_LeftChan.Minimum));
            m_RightChan.Value = (int)(m_RightChan.Minimum +  RVal * (m_RightChan.Maximum - m_RightChan.Minimum));
            m_ThreshAdj.BackColor = m_mp3SoundCapture.VOXActive ? Color.Red : SystemColors.Control;
            m_statusStrip.Items[3].BackColor = m_mp3SoundCapture.VOXActive ? Color.Red : SystemColors.Control;
        }

        private void VOXParams_ValueChanged(object sender, EventArgs e)
        {
            m_mp3SoundCapture.BufferSeconds = (int)m_BuffTime.Value;
            m_mp3SoundCapture.MinSoundSeconds = (int)m_SkipTime.Value;
            double ThreshVal = ((double) m_ThreshAdj.Value) / (m_ThreshAdj.Maximum - m_ThreshAdj.Minimum);
            ThreshVal = Math.Pow(Int16.MaxValue,ThreshVal);
            m_mp3SoundCapture.VOXThreshold = (int) ThreshVal;
        }
    }
}