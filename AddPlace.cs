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
    public partial class AddPlace : Form
    {
        private bool m_MGRS_started_input = false;
        
        private double Latitude, Longitude;
        
        public PlaceData m_PlaceData = new PlaceData();

        public AddPlace()
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
            if (GPSTrack.IsValidMGRS(MGRS.Text, out mgrs))
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
            m_PlaceData.Coordinates.MGRS = MGRS.Text;
            m_PlaceData.Coordinates.Latitude = Latitude;
            m_PlaceData.Coordinates.Longitude = Longitude;
            m_PlaceData.Coordinates.Speed = 0; int.TryParse(Speed_data.Text, out m_PlaceData.Coordinates.Speed);
            m_PlaceData.Coordinates.Direction = 0; int.TryParse(Dir_data.Text, out m_PlaceData.Coordinates.Direction);
            m_PlaceData.Description = PlaceDesc.Text;
            m_PlaceData.Name = PlaceName.Text;
        }

        private void AddPlace_Load(object sender, EventArgs e)
        {
            PlaceName.Text = m_PlaceData.Name;
            PlaceDesc.Text = m_PlaceData.Description;
            MGRS.Text = m_PlaceData.Coordinates.MGRS;
            UpdateLatLon(); 
            Speed_data.Text = m_PlaceData.Coordinates.Speed.ToString();
            Dir_data.Text = m_PlaceData.Coordinates.Direction.ToString();
        }
    }
}