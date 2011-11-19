using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TeamTrack
{
    public partial class AddTeam : Form
    {
        private bool m_MGRS_started_input = false;
        
        private double Latitude, Longitude;
        
        public TeamData m_TeamData = new TeamData();

        public Dictionary<string, PlaceData> m_PlaceData = new Dictionary<string,PlaceData>();

        public AddTeam()
        {
            InitializeComponent();
        }

        private void MGRS_KeyDown(object sender, KeyEventArgs e)
        {
            m_MGRS_started_input = true;
            e.Handled = false;
        }

        private void MGRS_Validated(object sender, EventArgs e)
        {
            if (m_MGRS_started_input)
            {
                UpdateLatLon();
            }
        }

        private void UpdateLatLon()
        {
            if (!string.IsNullOrEmpty(MGRS.Text))
            {
                Coords cc = new Coords();
                cc.MGRS = MGRS.Text;
                cc = GPSTrack.MGRS_To_LatLon(cc);
                Latitude = cc.Latitude;
                Longitude = cc.Longitude;
                LatLon.Text = GPSTrack.FormatLatLon(Latitude, Longitude);
            }
        }

        private void MGRS_TextChanged(object sender, EventArgs e)
        {
            string mgrs;
            if(GPSTrack.IsValidMGRS(MGRS.Text, out mgrs))
            {
                MGRS.Text = mgrs;
                UpdateLatLon();
            }
        }

        private void MGRS_Validating(object sender, CancelEventArgs e)
        {
            string mgrs;
            if (!string.IsNullOrEmpty(MGRS.Text) && !GPSTrack.IsValidMGRS(MGRS.Text, out mgrs))
            {
                e.Cancel = true;
            }
        }

        private void LatLon_Validated(object sender, EventArgs e)
        {
            if ( m_MGRS_started_input == false )
            {
                UpdateMGRS();
            }
        }

        private void UpdateMGRS()
        {
            if (!string.IsNullOrEmpty(LatLon.Text))
            {
                Coords cc = new Coords();
                cc.Latitude = Latitude;
                cc.Longitude = Longitude;
                cc = GPSTrack.LatLon_To_MGRS(cc);
                MGRS.Text = cc.MGRS;
            }
        }

        private void LatLon_Validating(object sender, CancelEventArgs e)
        {
            double Lat, Lon;
            string latlon;
            if (string.IsNullOrEmpty(LatLon.Text))
            {
                return;
            }
            if (GPSTrack.IsValidLatLon(LatLon.Text, out Lat, out Lon, out latlon))
            {
                Latitude = Lat;
                Longitude = Lon;
                LatLon.Text = latlon;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void LatLon_KeyDown(object sender, KeyEventArgs e)
        {
            m_MGRS_started_input = false;
            e.Handled = false;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            m_TeamData.Coordinates.MGRS = MGRS.Text;
            m_TeamData.Coordinates.Latitude = Latitude;
            m_TeamData.Coordinates.Longitude = Longitude;
            m_TeamData.Coordinates.Speed = 0; int.TryParse(Speed_data.Text, out m_TeamData.Coordinates.Speed);
            m_TeamData.Coordinates.Direction = 0; int.TryParse(Dir_data.Text, out m_TeamData.Coordinates.Direction);
            m_TeamData.Description = TeamDesc.Text;
            m_TeamData.Name = TeamName.Text;
            m_TeamData.CID = CID.Text;
            m_TeamData.TeamMembers = new List<string>(TeamMembers.Lines);
        }

        private void AddTeam_Load(object sender, EventArgs e)
        {
            TeamName.Text = m_TeamData.Name;
            CID.Text = m_TeamData.CID;
            TeamDesc.Text = m_TeamData.Description;
            MGRS.Text = m_TeamData.Coordinates.MGRS;
            UpdateLatLon();
            Speed_data.Text = m_TeamData.Coordinates.Speed.ToString();
            Dir_data.Text = m_TeamData.Coordinates.Direction.ToString();
            TeamMembers.Lines = m_TeamData.TeamMembers.ToArray();
            Place.Items.Clear();
            foreach (string s in m_PlaceData.Keys)
            {
                Place.Items.Add(s);
            }
        }

        private void Place_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Place.Text))
            {
                MGRS.Text = m_PlaceData[Place.Text].Coordinates.MGRS;
            }
        }
    }
}
