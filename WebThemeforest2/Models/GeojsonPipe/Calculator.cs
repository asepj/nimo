using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeojsonPipe
{
    public class Calculator
    {
        private static double GetRad(double x)
        {
            return x * Math.PI / 180;
        }

        public static double GetDistance(List<double> p1, List<double> p2)
        {
            double lat1 = p1[1];
            double lng1 = p1[0];
            double lat2 = p2[1];
            double lng2 = p2[0];

            var R = 6378137; // Earth’s mean radius in meter
            var dLat = GetRad(lat2 - lat1);
            var dLong = GetRad(lng2 - lng1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(GetRad(lat1)) * Math.Cos(GetRad(lat2)) *
              Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return d; // returns the distance in meter
        }

        public static DataTable GetCoordinatesDataset(List<List<double>> list)
        {
            DataTable dt = new DataTable("Coordinates");
            DataColumn c1 = new DataColumn("lat", typeof(Double));
            dt.Columns.Add(c1);
            DataColumn c2 = new DataColumn("lng", typeof(Double));
            dt.Columns.Add(c2);

            foreach (List<double> c in list)
            {
                if (c.Count == 2)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = c[1];
                    dr[1] = c[0];
                    dt.Rows.Add(dr);
                }
            }
            dt.AcceptChanges();

            return dt;
        }

        public static DataTable GetDistancesDataset(List<PointDistance> list)
        {
            DataTable dt = new DataTable("Distances");
            DataColumn c1 = new DataColumn("pos", typeof(Int32));
            dt.Columns.Add(c1);
            DataColumn c2 = new DataColumn("distance", typeof(Double));
            dt.Columns.Add(c2);
            DataColumn c3 = new DataColumn("lat", typeof(Double));
            dt.Columns.Add(c3);
            DataColumn c4 = new DataColumn("lng", typeof(Double));
            dt.Columns.Add(c4);

            foreach (PointDistance d in list)
            {
                DataRow dr = dt.NewRow();
                dr[0] = d.Pos;
                dr[1] = d.Distance;
                dr[2] = d.Point[1];
                dr[3] = d.Point[0];
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }

        public static List<PointDistance> GetDistances(List<List<double>> coordinates, List<double> origin)
        {
            List<PointDistance> list = new List<PointDistance>();
            int pos = 0;
            foreach (List<double> p in coordinates)
            {
                double distance = GetDistance(origin, p);
                PointDistance d = new PointDistance { Distance = distance, Point = p, Pos = pos };
                list.Add(d);
                pos = pos + 1;
            }
            return list;
        }

        public static List<List<double>> DecodePolylinePoints(string encodedPoints)
        {
            if (encodedPoints == null || encodedPoints == "") return null;
            List<List<double>> poly = new List<List<double>>();
            char[] polylinechars = encodedPoints.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            try
            {
                while (index < polylinechars.Length)
                {
                    // calculate next latitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length)
                        break;

                    currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                    //calculate next longitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length && next5bits >= 32)
                        break;

                    currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                    List<double> p = new List<double>();
                    double lat = Convert.ToDouble(currentLat) / 100000.0;
                    double lng = Convert.ToDouble(currentLng) / 100000.0;
                    p.Add(lng);
                    p.Add(lat);
                    poly.Add(p);
                }
            }
            catch (Exception ex)
            {
                // logo it
            }
            return poly;
        }

        private static double GetR(List<double> source, List<double> destination)
        {
            double lat1 = source[1];
            double lng1 = source[0];
            double lat2 = destination[1];
            double lng2 = destination[0];

            double horizontalDistance = (lng2 - lng1);
            double verticalDistance = (lat2 - lat1);
            double distance = System.Math.Sqrt((horizontalDistance * horizontalDistance) + (verticalDistance * verticalDistance));
            return distance;
        }
        private static double GetD(List<double> a, List<double> b, List<double> c)
        {
            double distance = 0.0;
            double x1 = a[1];
            double y1 = a[0];
            double x2 = b[1];
            double y2 = b[0];
            double x0 = c[1];
            double y0 = c[0];

            distance = Math.Abs((x2 - x1) * (y1 - y0) - (x1 - x0) * (y2 - y1)) / Math.Sqrt(Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));

            return distance;
        }

        public static List<double> GetDistancePointSegment(List<double> a, List<double> b, List<double> c, out double d)
        {
            //StartLocation retval = new StartLocation {  lng = projection.X, lat=projection.Y};
            double x1 = a[1];
            double y1 = a[0];
            double x2 = b[1];
            double y2 = b[0];

            double r = GetR(a, c);
            d = GetD(a, b, c);
            double s = Math.Sqrt(r * r - d * d);
            double distance = GetR(a, b);
            double redX = x1 + ((x2 - x1) / distance * s);
            double redY = y1 + ((y2 - y1) / distance * s);
            List<double> retval = new List<double> { redY, redX };

            //double t1 = (retval[1] - x1) / (x2 - x1);
            //double t2 = (retval[0] - y1) / (y2 - y1);
            //double tt = Math.Abs(t1 - t2);
            if (((redY > y1 && redY < y2) || (redY > y2 && redY < y1)) && ((redX > x1 && redX < x2) || (redX > x2 && redX < x1)))
            {
                string stop = "here";
            }
            else
            {
                string stop = "here";
            }

            return retval;
        }

        public static List<double> GetDistancePointSegment2(List<double> a, List<double> b, List<double> c, out double d)
        {
            //StartLocation retval = new StartLocation {  lng = projection.X, lat=projection.Y};
            double ax = a[0];
            double ay = a[1];
            double bx = b[0];
            double by = b[1];
            double cx = c[0];
            double cy = c[1];

            List<double> retval = new List<double>();
            d = 0.0;

            //double L = Math.Sqrt(Math.Pow(bx-ax,2.0) + Math.Pow(by-ay,2.0));
            //double r = ((cx-ax) * (bx-ax) + (cy-ay)*(by-ay)) / Math.Pow(L,2.0);
            //double s = ((ay-cy)*(bx-ax) - (ax-cx)*(by-ay))/Math.Pow(L,2.0);

            double r_numerator = (cx - ax) * (bx - ax) + (cy - ay) * (by - ay);
            double r_denomenator = (bx - ax) * (bx - ax) + (by - ay) * (by - ay);
            double r = r_numerator / r_denomenator;

            double px = ax + r * (bx - ax);
            double py = ay + r * (by - ay);

            double s = ((ay - cy) * (bx - ax) - (ax - cx) * (by - ay)) / r_denomenator;
            double distanceLine = Math.Abs(s) * Math.Sqrt(r_denomenator);

            //
            // (xx,yy) is the point on the lineSegment closest to (cx,cy)
            //
            double xx = px;
            double yy = py;

            double distanceSegment = 0.0;
            if ((r >= 0) && (r <= 1))
            {
                distanceSegment = distanceLine;
            }
            else
            {
                double dist1 = (cx - ax) * (cx - ax) + (cy - ay) * (cy - ay);
                double dist2 = (cx - bx) * (cx - bx) + (cy - by) * (cy - by);
                if (dist1 < dist2)
                {
                    xx = ax;
                    yy = ay;
                    distanceSegment = Math.Sqrt(dist1);
                }
                else
                {
                    xx = bx;
                    yy = by;
                    distanceSegment = Math.Sqrt(dist2);
                }
            }

            d = distanceSegment;
            retval = new List<double> { xx, yy };

            return retval;
        }

        public static DataTable GetDoubleDataset(List<double> list)
        {
            DataTable dt = new DataTable("Distances");
            DataColumn c1 = new DataColumn("val", typeof(double));
            dt.Columns.Add(c1);

            foreach (double d in list)
            {
                DataRow dr = dt.NewRow();
                dr[0] = d;
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }



    }
}
