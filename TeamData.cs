using System;
using System.Collections.Generic;
using System.Text;

namespace TeamTrack

{
    public enum TrackStatus
    {
        ACTIVE = 0,
        TRACKING = 1,
        DELAYED = 2,
        PLACES = 3
    };

    public struct Coords
    {
        public string MGRS;
        public double Latitude;
        public double Longitude;
        public int Altitude;
        public int Speed;
        public int Direction;
        public DateTime Time;
   }

    public class PlaceData
    {
        public string Name;
        public string Description;
        public Coords Coordinates;
    }

    public class TeamData
    {
        public string CID;
        public string Name;
        public string Description;
        public List<string> TeamMembers = new List<string>();
        public Coords Coordinates;
        public TrackStatus Status;
    }

    public class TeamConfig
    {
        public string SelectedComPort;
        public int PollingInterval;
    }
}
