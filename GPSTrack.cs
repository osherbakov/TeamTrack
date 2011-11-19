using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TeamTrack
{
    public struct TrackingData
    {
        public string CID;
        public Coords Coordinates;
        public int TFOM;
        public int PFOM;
    }

    class GPSTrack
    {
        public EventHandler TrackReceived;

        public TrackingData NewData;
        private Dictionary<string, TrackingData> StoredData = new Dictionary<string, TrackingData>();

        private static Regex latlon_rx =
            new Regex(@"\s*((?<N>.*?)(?<LAT>[0-9.]{3,})|(?<LAT>[0-9.]{3,})(?<N>.*?))[\s,]+((?<E>.*?)(?<LON>[0-9.]{4,})|(?<LON>[0-9.]{4,})(?<E>.*?))\s*",
                RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
        private static Regex mgrs_rx =
            new Regex(@"\s*(?<ZD>\d{1,2})\s*(?<ZL>\p{L})\s*(?<GG>\p{L}{2})\s*(?<GRID>(\d{8}\b|\d{10}\b|\d{4}\s+\d{4}\b|\d{5}\s+\d{5}\b))\s*",
                RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
        private static Regex SA_rx = 
            new Regex(@"\s*?(?<CID>\d{1,5})
                    \s*?(?<ZD>\d{1,2})
                    \s*?(?<ZL>[A-Z])
                    \s*?(?<GG>[A-Z]{2})
                    \s*?(?<X>\d{5})
                    \s*?(?<Y>\d{5})
                    \s*?(?<ALT>\d+)
                    \s+?(?<TFOM>\d+)
                    \s+?(?<PFOM>\d+)
                    \s+?(?<DIR>\d+) 
                    \s+?(?<SPEED>\d+)
                    \s*?", 
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        StringBuilder ReceivedSerialData = new StringBuilder();
        
        static Geotran.Convert gc = new Geotran.Convert();
        
        const double RADS_TO_DEG = 360.0 / (2.0 * Math.PI);
        const double MGRS_a = 6378137.0;    /* Semi-major axis of ellipsoid in meters */
        const double MGRS_b = 6356752.3142; /* Semi-minor axis of ellipsoid           */

        const double MGRS_R = (MGRS_a + MGRS_b) / 2;

        static public Coords NewPosition(Coords OldPosition, double dX, double dY)
        {
            Coords result;
            double dLat;
            double dLon;

            result = OldPosition;
            
            dLat = dY / MGRS_R;
            dLon = (dX / MGRS_R) / Math.Cos(OldPosition.Latitude / RADS_TO_DEG);

            result.Latitude += dLat * RADS_TO_DEG;
            result.Longitude += dLon * RADS_TO_DEG;
            return result;
        }

        static public Coords NewPosition(Coords OldPosition)
        {
            double dT = 1000.0 * (DateTime.Now - OldPosition.Time).TotalSeconds/(60.0 * 60.0);
            double brng = OldPosition.Direction / RADS_TO_DEG;
            double dX = OldPosition.Speed * Math.Sin(brng) * dT;
            double dY = OldPosition.Speed * Math.Cos(brng) * dT;
            return NewPosition(OldPosition, dX, dY);
        }

        static public Coords MGRS_To_LatLon(Coords coordinates)
        {
            if (!string.IsNullOrEmpty(coordinates.MGRS))
            {
                double Lat, Lon;
                unsafe
                {
                    fixed (byte* p_str = Encoding.ASCII.GetBytes(coordinates.MGRS.ToUpper().Replace(" ", "")))
                    {
                        gc.Convert_MGRS_To_Geodetic((sbyte*)p_str, &Lat, &Lon);
                    }
                }
                coordinates.Latitude = Lat * RADS_TO_DEG;
                coordinates.Longitude = Lon * RADS_TO_DEG;
            }
            return coordinates;
        }

        static public Coords LatLon_To_MGRS(Coords coordinates)
        {
            double Lat, Lon;
            string mgrs;
            byte[] buffer = new byte[100];
            Lat = coordinates.Latitude / RADS_TO_DEG;
            Lon = coordinates.Longitude / RADS_TO_DEG;
            unsafe
            {
                fixed (byte* p_str = buffer)
                {
                    gc.Convert_Geodetic_To_MGRS(Lat, Lon, 5, (sbyte*)p_str);
                    mgrs = Encoding.ASCII.GetString(buffer);
                }
            }
            coordinates.MGRS = FormatMGRS(mgrs);
            return coordinates;
        }

        static public bool IsValidMGRS(string in_mgrs, out string out_mgrs)
        {
            bool result = false;
            out_mgrs = string.Empty;
            if (!string.IsNullOrEmpty(in_mgrs))
            {
                Match mm = mgrs_rx.Match(in_mgrs);
                if (mm.Success)
                {
                    string mgrs = mm.Groups["ZD"].Value + mm.Groups["ZL"].Value + mm.Groups["GG"].Value + mm.Groups["GRID"].Value;
                    out_mgrs = FormatMGRS(mgrs);
                    result = true;
                }
            }
            return result;
        }

        static public bool IsValidLatLon(string in_latlon, out double Lat, out double Lon, out string out_latlon)
        {
            bool result = false;
            out_latlon = string.Empty;
            Lat = 0;
            Lon = 0;

            if (!string.IsNullOrEmpty(in_latlon))
            {
                Match mm = latlon_rx.Match(in_latlon);
                if (mm.Success)
                {
                    string N = mm.Groups["N"].Value;
                    string E = mm.Groups["E"].Value;

                    double.TryParse(mm.Groups["LAT"].Value, out Lat);
                    double.TryParse(mm.Groups["LON"].Value, out Lon);

                    if (!(string.IsNullOrEmpty(N) || N.Equals("+") || N.ToUpper().Equals("N")))
                    {
                        Lat = -Lat;
                    }

                    if (!(string.IsNullOrEmpty(E) || E.Equals("+") || E.ToUpper().Equals("E")))
                    {
                        Lon = -Lon;
                    }

                    out_latlon = FormatLatLon(Lat, Lon);
                    result = true;
                }
            }
            return result;
        }

        static public string FormatLatLon(double Latitude, double Longitude)
        {
            return Latitude.ToString("N10") + ", " + Longitude.ToString("N10");
        }

        static public string FormatMGRS(string in_mgrs)
        {
            string out_mgrs = string.Empty;
            if (!string.IsNullOrEmpty(in_mgrs))
            {
                if (in_mgrs.IndexOf("\0") != -1)
                {
                    in_mgrs = in_mgrs.Substring(0, in_mgrs.IndexOf("\0"));
                }
                in_mgrs = in_mgrs.ToUpper().Replace(" ", "");
                int len = in_mgrs.Length;

                if (len == 12)
                {
                    out_mgrs = in_mgrs.Substring(0, 1) + " ";
                    out_mgrs += in_mgrs.Substring(1, 1) + " ";
                    out_mgrs += in_mgrs.Substring(2, 2) + " ";
                    out_mgrs += in_mgrs.Substring(4, 4) + " ";
                    out_mgrs += in_mgrs.Substring(8);
                }
                else if (len == 13)
                {
                    out_mgrs = in_mgrs.Substring(0, 2) + " ";
                    out_mgrs += in_mgrs.Substring(2, 1) + " ";
                    out_mgrs += in_mgrs.Substring(3, 2) + " ";
                    out_mgrs += in_mgrs.Substring(5, 4) + " ";
                    out_mgrs += in_mgrs.Substring(9);
                }
                else if (len == 14)
                {
                    out_mgrs = in_mgrs.Substring(0, 1) + " ";
                    out_mgrs += in_mgrs.Substring(1, 1) + " ";
                    out_mgrs += in_mgrs.Substring(2, 2) + " ";
                    out_mgrs += in_mgrs.Substring(4, 5) + " ";
                    out_mgrs += in_mgrs.Substring(9);
                }
                else if (len == 15)
                {
                    out_mgrs = in_mgrs.Substring(0, 2) + " ";
                    out_mgrs += in_mgrs.Substring(2, 1) + " ";
                    out_mgrs += in_mgrs.Substring(3, 2) + " ";
                    out_mgrs += in_mgrs.Substring(5, 5) + " ";
                    out_mgrs += in_mgrs.Substring(10);
                }
            }
            return out_mgrs;
        }

        public void ProcessTrackingData(string IncomingData)
        {
            bool needs_update = false;
            lock (ReceivedSerialData)
            {
                IncomingData = IncomingData.Replace("\r", "");
                IncomingData = IncomingData.Replace("OK", "");
                int new_length = ReceivedSerialData.Length + IncomingData.Length;
                if (new_length > 4096)
                {
                    // Too many unrecognized symbols accumulated - 
                    //   switch into the scrolling mode
                    ReceivedSerialData.Remove(0, IncomingData.Length);
                }
                ReceivedSerialData.Append(IncomingData);

                bool match_found = false;
                do
                {
                    Match rm = SA_rx.Match(ReceivedSerialData.ToString());
                    match_found = rm.Success;
                    if (match_found)
                    {
                        TrackingData ct = new TrackingData();
                        ct.CID = rm.Groups["CID"].Value;
                        ct.PFOM = 0;  int.TryParse(rm.Groups["PFOM"].Value, out ct.PFOM);
                        ct.TFOM = 0; int.TryParse(rm.Groups["TFOM"].Value, out ct.TFOM);
                        ct.Coordinates.Altitude = 0; int.TryParse(rm.Groups["ALT"].Value, out ct.Coordinates.Altitude);
                        ct.Coordinates.Speed = 0; int.TryParse(rm.Groups["SPEED"].Value, out ct.Coordinates.Speed);
                        ct.Coordinates.Direction = 0; int.TryParse(rm.Groups["DIR"].Value, out ct.Coordinates.Direction);
                        ct.Coordinates.MGRS = rm.Groups["ZD"].Value + rm.Groups["ZL"].Value + rm.Groups["GG"].Value +
                            rm.Groups["X"].Value + rm.Groups["Y"].Value;
                        ct.Coordinates.Time = DateTime.Now;
                        ReceivedSerialData.Remove(rm.Index, rm.Length);
                        // Check if the same information is already in the system
                        if(StoredData.ContainsKey(ct.CID))
                        {
                            // Any changes???
                            TrackingData old_ct = StoredData[ct.CID];
                            if ((old_ct.PFOM != ct.PFOM) || (old_ct.TFOM != ct.TFOM) ||
                                !old_ct.Coordinates.MGRS.Equals(ct.Coordinates.MGRS) ||
                                (old_ct.Coordinates.Direction != ct.Coordinates.Direction) ||
                                (old_ct.Coordinates.Altitude != ct.Coordinates.Altitude) ||
                                (old_ct.Coordinates.Speed != ct.Coordinates.Speed))
                            {
                                needs_update = true;
                            }
                        }else
                        {
                            // New CID detected
                            needs_update = true;
                        }
                        // Save received data indexed by the CID
                        StoredData[ct.CID] = ct;
                        if (needs_update && (TrackReceived != null))
                        {
                            NewData = ct;
                            TrackReceived(this, EventArgs.Empty);
                        }
                    }
                } while (match_found);
            }
        }
    }
}
