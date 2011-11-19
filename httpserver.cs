using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using TeamTrack.TeamTrackDataSetTableAdapters;

using System.Web;

namespace TeamTrack
{
    public enum SERVER_TYPE
    {
        TRACKING,
        HISTORY
    } ;

    public class Httpserver
    {
        #region Private fields
        private SERVER_TYPE _server_type = SERVER_TYPE.TRACKING;
        private DateTime _hist_time = DateTime.Now;
        private int _port_number = 9999;
        private bool _keepAppRunning = true;
        private HttpListener _listener = null;
        private Thread _listeningThread = null;
        private List<TeamData> _curr_data = new List<TeamData>();
        private StringBuilder _team_template_start = new StringBuilder();
        private StringBuilder _team_template_end = new StringBuilder();
        private HistoryTableAdapter _history_adapter = null;
        #endregion

        public void Start(SERVER_TYPE type, int port)
        {
            _team_template_start = new StringBuilder();
            _team_template_end = new StringBuilder();

            try
            {
                using (StreamReader sr = new StreamReader(@"Team.kml"))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Equals("<!-- INSERT_PLACEMARKS -->"))
                        {
                            break;
                        }
                        else
                        {
                            _team_template_start.Append(line);
                        }
                    }
                    while ((line = sr.ReadLine()) != null)
                    {
                        _team_template_end.Append(line);
                    }
                    sr.Close();
                }

                _server_type = type;
                _port_number = port;
                _hist_time = DateTime.Now;
                _keepAppRunning = true;
                InitialiseListener();
                if (_server_type == SERVER_TYPE.HISTORY)
                {
                    _history_adapter = new HistoryTableAdapter();
                    _history_adapter.Connection.Open();
                }
                _listeningThread = new Thread(ListeningThread);
                _listeningThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
            }
        }

        public void Stop()
        {
            // Close down our thread and listener if required.
            _keepAppRunning = false;
            if (_listeningThread != null && _listeningThread.ThreadState == ThreadState.Running)
            {
                _listeningThread.Abort();
                _listeningThread = null;
            }
            if (_listener != null && _listener.IsListening)
            {
                _listener.Stop();
                _listener.Close();
                _listener = null;
            }
            _curr_data.Clear();

            if(_history_adapter != null && _history_adapter.Connection.State != ConnectionState.Closed)
            {
                _history_adapter.Connection.Close();
                _history_adapter = null;
            }
        }

        public void Update(List<TeamData> Data)
        {
            lock (_curr_data)
            {
                _curr_data = Data;
            }
        }

        public void Update(DateTime HistData)
        {
            _hist_time = HistData;
        }


        #region InitialiseListener
        /// <summary>
        /// Initialise our http listener 
        /// </summary>
        private void InitialiseListener()
        {
            _listener = new HttpListener();
            _listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            string prefix = string.Format("http://+:{0}/", _port_number);
            _listener.Prefixes.Add(prefix);
            _listener.Start();
        }
        #endregion

        #region Main ListeningThread method
        private void ListeningThread()
        {
            while (_keepAppRunning)
            {
                HttpListenerContext context = _listener.GetContext();
                try
                {
                    CreateResponseDocument(context);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
                }
            }
        }
        #endregion

        #region Create a simple response document to send to the browser

        private void CreateTrackingDocument(StringBuilder htmlOutput)
        {
            lock (_curr_data)
            {
                foreach (TeamData td in _curr_data)
                {
                    htmlOutput.Append("<Placemark>");
                    htmlOutput.Append("<name>" + td.Name + "</name>");
                    switch (td.Status)
                    {
                        case TrackStatus.PLACES:
                            htmlOutput.Append("<styleUrl>#place-status-template</styleUrl>");
                            break;

                        case TrackStatus.DELAYED:
                            htmlOutput.Append("<styleUrl>#team-delayed-template</styleUrl>");
                            break;

                        default:
                            htmlOutput.Append("<styleUrl>#team-tracking-template</styleUrl>");
                            break;
                    }
                    htmlOutput.Append("<ExtendedData>  <SchemaData schemaUrl=\"#TeamStatusId\">");
                    htmlOutput.Append("<SimpleData name=\"TeamName\">" + td.Name + "</SimpleData>");
                    htmlOutput.Append("<SimpleData name=\"Description\">" + td.Description + "</SimpleData>");
                    htmlOutput.Append("<SimpleData name=\"Members\">");
                    foreach (string memb in td.TeamMembers)
                    {
                        htmlOutput.Append(memb + "&lt;br/&gt;");
                    }
                    htmlOutput.Append("</SimpleData>");
                    htmlOutput.Append("<SimpleData name=\"MGRS\">" + td.Coordinates.MGRS + "</SimpleData>");
                    htmlOutput.Append("<SimpleData name=\"LatLon\">" + GPSTrack.FormatLatLon(td.Coordinates.Latitude, td.Coordinates.Longitude) + "</SimpleData>");
                    htmlOutput.Append("<SimpleData name=\"Speed\">" + td.Coordinates.Speed + "</SimpleData>");
                    htmlOutput.Append("<SimpleData name=\"Dir\">" + td.Coordinates.Direction + "</SimpleData>");
                    htmlOutput.Append("<SimpleData name=\"Time\">" + td.Coordinates.Time.ToShortTimeString() +
                        td.Coordinates.Time.ToUniversalTime().ToString(" (HH:mm:ssZ)") + "</SimpleData>");
                    htmlOutput.Append("</SchemaData> </ExtendedData> ");
                    htmlOutput.Append("<Point>  <coordinates> ");
                    htmlOutput.Append(td.Coordinates.Longitude.ToString("N10") + "," + td.Coordinates.Latitude.ToString("N10"));
                    htmlOutput.Append("," + td.Coordinates.Altitude.ToString());
                    htmlOutput.Append("</coordinates>    </Point> ");
                    htmlOutput.Append("</Placemark>");

                    // Add projected team path
                    if (td.Coordinates.Speed > 2)
                    {
                        htmlOutput.Append("<Placemark>");
                        htmlOutput.Append("<name>" + td.Name + "</name>");
                        htmlOutput.Append("<styleUrl>#projected-line</styleUrl>");
                        htmlOutput.Append("<LineString> ");
                        htmlOutput.Append("<extrude>1</extrude> <tessellate>1</tessellate> <altitudeMode>relativeToGround </altitudeMode> ");
                        htmlOutput.Append("<coordinates> ");
                        htmlOutput.Append(td.Coordinates.Longitude.ToString("N10") + "," + td.Coordinates.Latitude.ToString("N10") + ",2 ");
                        Coords projected = GPSTrack.NewPosition(td.Coordinates);
                        htmlOutput.Append(projected.Longitude.ToString("N10") + "," + projected.Latitude.ToString("N10") + ",2");
                        htmlOutput.Append("</coordinates>    </LineString> ");
                        htmlOutput.Append("</Placemark>");
                    }
                }
            }
        }

        private void CreateHistoryDocument(StringBuilder htmlOutput)
        {
            // Get the Names of all Objects that we were tracking
            try
            {
                TeamTrackDataSet.HistoryDataTable hdt = _history_adapter.GetNamesByHistTime(_hist_time);
                foreach (TeamTrackDataSet.HistoryRow name_data_row in hdt.Rows)
                {
                    string team_name = name_data_row.Name;
                    htmlOutput.Append("<Folder> ");
                    htmlOutput.Append(" <styleUrl>#check-hide-children</styleUrl> ");
                    htmlOutput.Append(" <name>" + team_name + "</name> ");


                    // Get all qualifying events/tracks for each name
                    TeamTrackDataSet.HistoryDataTable team_events;
                    team_events = _history_adapter.GetDataByNameTime(_hist_time, team_name );
                    foreach (TeamTrackDataSet.HistoryRow team_ev in team_events.Rows)
                    {
                        string team_timestamp = team_ev.Time.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                        htmlOutput.Append(" <Placemark> ");
                        htmlOutput.Append(" <TimeStamp> ");
                        htmlOutput.Append("  <when>" + team_timestamp + "</when> ");
                        htmlOutput.Append(" </TimeStamp> ");
                        htmlOutput.Append(" <styleUrl>#team-icon</styleUrl> ");
                        htmlOutput.Append(" <Point>");
                        htmlOutput.Append(" <coordinates>" + team_ev.Geo + "," + team_ev.Alt + "</coordinates> ");
                        htmlOutput.Append(" </Point> ");
                        htmlOutput.Append(" </Placemark> ");
                    }
                    htmlOutput.Append(" </Folder> ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.ToString());
            }
        }

        private void CreateResponseDocument(HttpListenerContext ctxt)
        {
            StringBuilder htmlOutput = new StringBuilder(_team_template_start.ToString());
            if (_server_type == SERVER_TYPE.TRACKING)
            {
                CreateTrackingDocument(htmlOutput);
            }
            else
            {
                CreateHistoryDocument(htmlOutput);
            }
            htmlOutput.Append(_team_template_end.ToString());
            // Send the output, if any, to the response context for the listener
            if (htmlOutput.Length != 0 && ctxt.Response.OutputStream.CanWrite)
            {
                byte[] htmlData = System.Text.UTF8Encoding.UTF8.GetBytes(htmlOutput.ToString());
                ctxt.Response.OutputStream.Write(htmlData, 0, htmlData.Length);
            }
            ctxt.Response.Close();
        }
        #endregion
    }
}
