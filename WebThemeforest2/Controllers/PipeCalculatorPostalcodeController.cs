using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebThemeforest2.Models;
using WebThemeforest2.Models.GoogleGeocode;

using WebThemeforest2.Repositories;
using System.Configuration;
using System.Threading;
using System.Globalization;

using GoogleReverseGeocode = WebThemeforest2.Models.GoogleReverseGeocode;

namespace WebThemeforest2.Controllers
{
    public class PipeCalculatorPostalcodeController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        private string ToAbsoluteUrl(string relativeUrl)
        {
            if (string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;

            if (HttpContext.Current == null)
                return relativeUrl;

            if (relativeUrl.StartsWith("/"))
                relativeUrl = relativeUrl.Insert(0, "~");
            if (!relativeUrl.StartsWith("~/"))
                relativeUrl = relativeUrl.Insert(0, "~/");

            var url = HttpContext.Current.Request.Url;
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

            return String.Format("{0}://{1}{2}{3}",
                url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        }


        private double GetRad(double x)
        {
            return x * Math.PI / 180;
        }

        private double GetDistance(StartLocation p1, StartLocation p2)
        {
            var R = 6378137; // Earth’s mean radius in meter
            var dLat = GetRad(p2.lat - p1.lat);
            var dLong = GetRad(p2.lng - p1.lng);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(GetRad(p1.lat)) * Math.Cos(GetRad(p2.lat)) *
              Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return d; // returns the distance in meter
        }

        private StartLocation GetPerp(StartLocation a, StartLocation b, StartLocation c)
        {
            double x1 = a.lng;
            double y1 = a.lat;
            double x2 = b.lng;
            double y2 = b.lat;
            double x3 = c.lng;
            double y3 = c.lat;
            double x4 = 0;
            double y4 = 0;
            StartLocation loc = new StartLocation();

            double xx = x2 - x1;
            double yy = y2 - y1;

            double shortestLength = ((xx * (x3 - x1)) + (yy * (y3 - y1))) / ((xx * xx) + (yy * yy));
            x4 = x1 + xx * shortestLength;
            y4 = y1 + yy * shortestLength;
            loc = new StartLocation { lng = x4, lat = y4 };

            return loc;
        }
        private double GetClosestPoint(List<double> A, List<double> B, List<double> P)
        {
            var A1 = new GeoCoordinate(A[1], A[0]);
            var B1 = new GeoCoordinate(B[1], B[0]);
            StartLocation s1 = new StartLocation { lat = A1.Latitude, lng = A1.Longitude };
            StartLocation s2 = new StartLocation { lat = B1.Latitude, lng = B1.Longitude };
            double ds = A1.GetDistanceTo(B1);
            double ds2 = GetDistance(s1, s2);
            //double R = 6371.0;
            //double x0 = P[0];
            //double y0 = P[1];
            //double x1 = A[0];
            //double y1 = A[1];
            //double x2 = B[0];
            //double y2 = B[1];
            //double retval = Math.Abs((y2-y1)*x0 - (x2-x1)*y0 + x2*y1 - y2*x1) / Math.Sqrt(Math.Pow(y2-y1, 2) + Math.Pow(x2-x1, 2));

            return ds;
        }

        private List<StartLocation> GetRoute(Models.GoogleGeocode.Route route)
        {
            List<StartLocation> list = new List<StartLocation>();
            Leg leg = route.legs[0];
            StartLocation start = leg.start_location;
            list.Add(start);
            foreach (Step step in leg.steps)
            {
                EndLocation2 end2 = step.end_location;
                StartLocation end = new StartLocation { lat = end2.lat, lng = end2.lng };
                list.Add(end);
            }
            return list;
        }

        private bool CheckSegmentOrder(List<List<double>> coordinates)
        {
            bool bl = false;
            int count = coordinates.Count;
            for (int i = 0; i < count - 1; i++)
            {
                List<double> point1 = coordinates[i];
                List<double> nextPoint = new List<double>();
                List<double> nextPointPredict = coordinates[i + 1];
                double minimumDistance = 1e10;
                for (int j = i + 1; j < count; j++)
                {
                    if (j == i) continue;
                    List<double> point2 = coordinates[j];
                    double x1 = point1[1];
                    double y1 = point1[0];
                    double x2 = point2[1];
                    double y2 = point2[0];
                    double distance = Math.Sqrt(Math.Pow(x1 - x2, 2.0) + Math.Pow(y1 - y2, 2.0));
                    if (minimumDistance > distance)
                    {
                        minimumDistance = distance;
                        nextPoint = point2;
                    }
                }

                if (nextPoint[0] == nextPointPredict[0] && nextPoint[1] == nextPointPredict[1])
                {
                    bl = true;
                }
            }

            return bl;
        }

        private string API_KEY = "AIzaSyAG1GiD6Z-cxmU7ymECJ1hn1cHfBRuY2XY"; //scadaprimacipta
        private string TRAVEL_MODE = "walking"; //driving, walking, bicycling, transit
        //private double MINIMUM_INSIDE_DIAMETER = 4.03;
        private double MINIMUM_INSIDE_DIAMETER = 2.03;
        private int TOP_POSITION = 15;
        private const double MINIMUM_DISTANCE = 30.0;
        private const double MINIMUM_DISTANCE2 = 10.0;
        //private double MINIMUM_NEIGHBOUR_DISTANCE = 40.0;
        private double MINIMUM_NEIGHBOUR_DISTANCE = MINIMUM_DISTANCE;
        private double MINIMUM_NEIGHBOUR_DISTANCE2 = MINIMUM_DISTANCE2;

        public const double PIPE_MATERIAL_COST_PERTON = 8040000;
        public const double PIPE_LABOR_COST_PERMETER = 880000;
        private string area;
        //calculate otomatis

        private GoogleReverseGeocode.RootObject GetReverseGeocode(PositionParam origin)
        {
            GoogleReverseGeocode.RootObject obj = null;
            try
            {
                double lat = origin.lat;
                double lng = origin.lng;
                string url = @"https://maps.googleapis.com/maps/api/geocode/json?latlng=" + Convert.ToString(lat) + "," + Convert.ToString(lng) + "&key=" + API_KEY;

                //myRowNumber = 3;
                WebRequest request = WebRequest.Create(url);
                //myRowNumber = 4;
                WebResponse response = request.GetResponse();
                //myRowNumber = 5;
                Stream data = response.GetResponseStream();
                //myRowNumber = 6;
                StreamReader reader = new StreamReader(data);
                //myRowNumber = 7;
                // json-formatted string from maps api
                string responseFromServer = reader.ReadToEnd();
                //myRowNumber = 8;
                obj = JsonConvert.DeserializeObject<GoogleReverseGeocode.RootObject>(responseFromServer);

                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //myMessage = "kena1";
                //myRowNumber = 130;
            }
            return obj;
        }

        private string GetPostcode(GoogleReverseGeocode.RootObject reverseGeocode)
        {
            string str = "";
            if (reverseGeocode != null)
            {
                if (reverseGeocode.status.Equals("OK"))
                {
                    GoogleReverseGeocode.Result result = reverseGeocode.results[0];
                    foreach (GoogleReverseGeocode.AddressComponent addressComponent in result.address_components)
                    {
                        string type = addressComponent.types[0];
                        if (type.Equals("postal_code"))
                        {
                            str = addressComponent.short_name;
                        }
                    }

                }
            }

            return str;
        }

        public PositionParam Post(PositionParam origin)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            PositionParam origin_rev = origin;

            GoogleReverseGeocode.RootObject reverseGeocode = GetReverseGeocode(origin);
            if (reverseGeocode != null)
            {
                string postcode = GetPostcode(reverseGeocode);
                string areaPostcode = "";

                PL_AREA_POSTCODERepository repPostcode = new PL_AREA_POSTCODERepository(connectionString);
                List<PL_AREA_POSTCODE> listPostcode = repPostcode.GetDataByKODE_POS(postcode);
                if (listPostcode.Count > 0)
                {
                    areaPostcode = listPostcode[0].NAMA_AREA + "-" + origin.category;
                    origin_rev.areaPipeline = areaPostcode;
                }

            }

            PositionParam retval = Run_Post_Postalcode(origin_rev);
            return retval;
        }
        private PositionParam Run_Post_Postalcode(PositionParam origin)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            int myRowNumber = 0;
            string myMessage = "";
            PositionParam val = new PositionParam();
            try
            {

                string myParameter = Newtonsoft.Json.JsonConvert.SerializeObject(origin);

                if (origin.category == "Industri")
                {
                    PL_CONFIG_CALC_AREARepository repCal = new PL_CONFIG_CALC_AREARepository(connectionString);

                List<PL_CONFIG_CALC_AREA> listCal = repCal.GetDataByAREA(origin.areaPipeline);

                    area = listCal[0].FILE_NAME;
                }
                else if (origin.category == "Rumah Tangga")
                {
                    PL_CONFIG_CALC_AREARepository repCal = new PL_CONFIG_CALC_AREARepository(connectionString);
                    List<PL_CONFIG_CALC_AREA> listCal = repCal.GetDataByCATEGORY(origin.category);
                    area = listCal[0].FILE_NAME;

                    
                }

                string urlarea = "~/Scripts/" + area;

                
                string myUrl = ToAbsoluteUrl(urlarea);
                //string myUrl = ToAbsoluteUrl("~/Scripts/PipesRD1.js");
                var json = new WebClient().DownloadString(myUrl);
                Models.GeojsonPipe.RootObject myRootObject = JsonConvert.DeserializeObject<Models.GeojsonPipe.RootObject>(json);
                double orilat = origin.lat;
                double orilng = origin.lng;
                List<double> pointOrigin = new List<double> { orilng, orilat };
                List<PositionParam> listPosition = new List<PositionParam>();
                List<PositionParam> listPositionAlt = new List<PositionParam>();

                foreach (Models.GeojsonPipe.Feature f in myRootObject.features)
                {
                    Models.GeojsonPipe.Properties2 p = f.properties;
                    double innerDiameter = p.PipeDi2003;
                    if (innerDiameter > MINIMUM_INSIDE_DIAMETER)
                    {
                        Models.GeojsonPipe.Geometry g = f.geometry;
                        int pos = 0;
                        PositionParam myPosition = new PositionParam();
                        double minimumDistance = -1.0;
                        double myDistance = 0.0;

                        foreach (List<double> xy in g.coordinates)
                        {
                            //myDistance = Math.Sqrt(Math.Pow(xy[1] - orilat, 2.0) + Math.Pow(xy[0] - orilng, 2.0));
                            myDistance = Models.GeojsonPipe.Calculator.GetDistance(xy, pointOrigin);
                            if (minimumDistance == -1)
                            {
                                minimumDistance = myDistance;
                                myPosition = new PositionParam { name = p.FacNam1005, lat = xy[1], lng = xy[0], sourcepipediameter = Math.Round(p.PipeDi2003, 4), flowrate = Math.Round(p.PipeC20721, 4), pressure = p.Pmax, pressureMin = p.Pmin, distance = minimumDistance, roughness = Math.Round (p.roughness, 5) };
                            }
                            if (minimumDistance > myDistance)
                            {
                                minimumDistance = myDistance;
                                myPosition = new PositionParam { name = p.FacNam1005, lat = xy[1], lng = xy[0], sourcepipediameter = Math.Round(p.PipeDi2003, 4), flowrate = Math.Round(p.PipeC20721, 4), pressure = p.Pmax, pressureMin = p.Pmin, distance = minimumDistance, roughness = Math.Round ( p.roughness, 5) };
                            }
                            pos = pos + 1;
                        }
                        listPosition.Add(myPosition);
                    }
                }
                //sort
                listPosition = listPosition.OrderBy(o => o.distance).ToList().Take(TOP_POSITION).ToList();

                List<StartLocation> listRoute = new List<StartLocation>();
                //List<StartLocation> listPolyline = new List<StartLocation>();
                List<List<double>> listPolyline = new List<List<double>>();
                List<double> listDistance = new List<double>();
                //List<string> listJson = new List<string>();
                List<RootObject> listObject = new List<RootObject>();
                double minimunDistance = -1.0;

                try
                {
                    foreach (PositionParam p in listPosition)
                    {
                        //myRowNumber = 1;
                        List<double> pointPipe = (new double[] { p.lng, p.lat }).ToList();
                        //string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=75+9th+Ave+New+York,+NY&destination=MetLife+Stadium+1+MetLife+Stadium+Dr+East+Rutherford,+NJ+07073&key=" + API_KEY;
                        //string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + Convert.ToString(parameters.origin.lat) + "," + Convert.ToString(parameters.origin.lng) + "&destination=" + Convert.ToString(p.lat) + "," + Convert.ToString(p.lng) + "&key=" + API_KEY;
                        //myRowNumber = 2;
                        string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + Convert.ToString(origin.lat) + "," + Convert.ToString(origin.lng) + "&destination=" + Convert.ToString(p.lat) + "," + Convert.ToString(p.lng) + "&mode=" + TRAVEL_MODE + "&key=" + API_KEY;

                        //myRowNumber = 3;
                        WebRequest request = WebRequest.Create(url);
                        //myRowNumber = 4;
                        WebResponse response = request.GetResponse();
                        //myRowNumber = 5;
                        Stream data = response.GetResponseStream();
                        //myRowNumber = 6;
                        StreamReader reader = new StreamReader(data);
                        //myRowNumber = 7;
                        // json-formatted string from maps api
                        string responseFromServer = reader.ReadToEnd();
                        //myRowNumber = 8;
                        RootObject obj = JsonConvert.DeserializeObject<RootObject>(responseFromServer);
                        //myRowNumber = 9;
                        //myMessage = responseFromServer;
                        myMessage = url;
                        //errornya disini

                        double myDistance = obj.routes[0].legs[0].distance.value;

                        //myRowNumber = 10;
                        listDistance.Add(myDistance);
                        //myRowNumber = 11;
                        List<List<double>> listPolyline2 = Models.GeojsonPipe.Calculator.DecodePolylinePoints(obj.routes[0].overview_polyline.points);
                        //myRowNumber = 12;
                        int countPolyline2 = listPolyline2.Count;
                        //myRowNumber = 13;
                        double distanceOffroad = Models.GeojsonPipe.Calculator.GetDistance(listPolyline2[countPolyline2 - 1], pointPipe); //if no road
                        //myRowNumber = 14;


                        if (distanceOffroad < MINIMUM_DISTANCE)
                        {
                            //myRowNumber = 15;
                            if (minimunDistance == -1)
                            {
                                minimunDistance = myDistance;
                                val.distance = minimunDistance;
                                val.lat = p.lat;
                                val.lng = p.lng;
                                val.name = p.name;
                                val.pressure = p.pressure;
                                val.pressureMin = p.pressureMin;
                                val.flowrate = p.flowrate;
                                val.sourcepipediameter = p.sourcepipediameter;
                                val.roughness = p.roughness;

                                //myRowNumber = 16;
                                //break;
                                listRoute = GetRoute(obj.routes[0]);
                                //myRowNumber = 17;
                                listPolyline = Models.GeojsonPipe.Calculator.DecodePolylinePoints(obj.routes[0].overview_polyline.points);
                                //myRowNumber = 18;
                            }
                            if (myDistance < minimunDistance)
                            {
                                //myRowNumber = 19;
                                minimunDistance = myDistance;
                                val.distance = minimunDistance;
                                val.lat = p.lat;
                                val.lng = p.lng;
                                val.name = p.name;
                                val.pressure = p.pressure;
                                val.pressureMin = p.pressureMin;
                                val.flowrate = p.flowrate;
                                val.sourcepipediameter = p.sourcepipediameter;
                                val.roughness = p.roughness;

                                //myRowNumber = 20;
                                listRoute = GetRoute(obj.routes[0]);
                                //myRowNumber = 21;
                                listPolyline = Models.GeojsonPipe.Calculator.DecodePolylinePoints(obj.routes[0].overview_polyline.points);
                                //myRowNumber = 22;
                            }
                            //listJson.Add(responseFromServer);
                            listObject.Add(obj);
                            //myRowNumber = 23;
                        }

                        response.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //myMessage = "kena1";
                    //myRowNumber = 130;
                }


                Models.GeojsonPipe.Feature selectedFeature = myRootObject.features.Find(delegate(Models.GeojsonPipe.Feature f) { return f.properties.FacNam1005.Equals(val.name); });

                List<List<double>> coordinates = selectedFeature.geometry.coordinates;

                int countPipe = selectedFeature.geometry.coordinates.Count;

                int count = listPolyline.Count;

                string jsonPolyLine = JsonConvert.SerializeObject(listPolyline);

                List<Models.GeojsonPipe.PointDistance> listDistance2 = new List<Models.GeojsonPipe.PointDistance>();

                int mypos = 0;



                if (count > 2)
                {
                    foreach (List<double> p in listPolyline)
                    {
                        List<Models.GeojsonPipe.PointDistance> listDistanceSegment = new List<Models.GeojsonPipe.PointDistance>();
                        for (int i = 0; i < countPipe - 1; i++)
                        {
                            double d = 0.0;
                            List<double> p1 = coordinates[i];
                            List<double> p2 = coordinates[i + 1];
                            List<double> s = Models.GeojsonPipe.Calculator.GetDistancePointSegment2(p1, p2, p, out d);
                            double meter = Models.GeojsonPipe.Calculator.GetDistance(p, s);
                            //Models.GeojsonPipe.PointDistance point = new Models.GeojsonPipe.PointDistance { Distance = meter, Pos = mypos, Point = s };
                            Models.GeojsonPipe.PointDistance point = new Models.GeojsonPipe.PointDistance { Distance = meter, Pos = mypos, Point = p };
                            listDistanceSegment.Add(point);

                        }
                        mypos = mypos + 1;
                        listDistanceSegment = listDistanceSegment.OrderBy(o => o.Distance).ToList();
                        listDistance2.Add(listDistanceSegment[0]);
                    }
                    List<List<double>> listPath = new List<List<double>>();
                    foreach (Models.GeojsonPipe.PointDistance p in listDistance2)
                    {
                        listPath.Add(p.Point);
                    }
                    string jsonPath = JsonConvert.SerializeObject(listPath);
                    int pathNum = 0;
                    foreach (Models.GeojsonPipe.PointDistance p in listDistance2)
                    {
                        if (p.Distance < MINIMUM_DISTANCE)
                        {
                            val.lat = p.Point[1];
                            val.lng = p.Point[0];
                            if (p.Distance < MINIMUM_DISTANCE2)
                            {
                                pathNum = pathNum + 1;
                                break;
                            }
                            else
                            {
                                //check next path
                                if (pathNum + 1 < count)
                                {
                                    Models.GeojsonPipe.PointDistance pointTrial = listDistance2[pathNum + 1];
                                    if (pointTrial.Distance < MINIMUM_DISTANCE2)
                                    {
                                        val.lat = p.Point[1];
                                        val.lng = p.Point[0];
                                        pathNum = pathNum + 1;
                                    }
                                }
                                pathNum = pathNum + 1;
                                break;
                            }
                        }
                        pathNum = pathNum + 1;
                    }
                    //check if not the right path
                    PositionParam paramOrigin = listPosition.Find(delegate(PositionParam f) { return f.name.Equals(val.name); });
                    double distanceOriginal = paramOrigin.distance;
                    double distanceCalculated = val.distance;
                    bool iscontinue = true;
                    if (iscontinue) //(distanceOriginal * 1.9 <= distanceCalculated)
                    {
                        List<PositionParam> listNeighbour = new List<PositionParam>();
                        for (int i = 0; i <= pathNum; i++)
                        {
                            //if (i != 8) continue;
                            List<double> p1 = listPolyline[i];
                            List<PositionParam> list1 = new List<PositionParam>();
                            foreach (PositionParam f1 in listPosition)
                            {
                                PositionParam posParam = new PositionParam();
                                string pipeName = f1.name;
                                //if (!pipeName.Equals("Pi350606")) continue;
                                Models.GeojsonPipe.Feature selectedPipe = myRootObject.features.Find(delegate(Models.GeojsonPipe.Feature f) { return f.properties.FacNam1005.Equals(pipeName); });
                                List<List<double>> myCoordinates = selectedPipe.geometry.coordinates;
                                double minDistance = 1e10;
                                int countCoordinateSegment = myCoordinates.Count;
                                for (int j = 0; j < countCoordinateSegment - 1; j++)
                                {
                                    List<double> p2a = myCoordinates[j];
                                    List<double> p2b = myCoordinates[j + 1];
                                    //double distance = Models.GeojsonPipe.Calculator.GetDistance(p1, p2);
                                    double distance2 = 0.0;
                                    List<double> p1c = Models.GeojsonPipe.Calculator.GetDistancePointSegment2(p2a, p2b, p1, out distance2);
                                    distance2 = Models.GeojsonPipe.Calculator.GetDistance(p1, p1c);
                                    if (minDistance > distance2)
                                    {
                                        minDistance = distance2;
                                        posParam = new PositionParam { name = pipeName, distance = minDistance, lat = p1[1], lng = p1[0] };
                                    }
                                }
                                list1.Add(posParam);
                            }
                            list1 = list1.OrderBy(o => o.distance).ToList();
                            listNeighbour.Add(list1[0]);
                            if (i < pathNum)
                            {
                                if (list1[0].distance < MINIMUM_NEIGHBOUR_DISTANCE)
                                {
                                    val.lng = list1[0].lng;
                                    val.lat = list1[0].lat;
                                    if (i + 1 < pathNum)
                                    {
                                        List<double> pointTrial = listPolyline[i + 1];
                                        double distanceTrial = Models.GeojsonPipe.Calculator.GetDistance(p1, pointTrial);
                                        if (distanceTrial < MINIMUM_NEIGHBOUR_DISTANCE2)
                                        {
                                            val.lng = pointTrial[0];
                                            val.lat = pointTrial[1];
                                        }
                                    }
                                    //check next path
                                    break;
                                }
                            }
                        }
                    }
                }

                //PL_CONFIG_PRESSURE_REGIMERepository rep0 = new PL_CONFIG_PRESSURE_REGIMERepository(connectionString);

                //List<PL_CONFIG_PRESSURE_REGIME> list2 = rep0.GetDataByREGIME_NAME(origin.pressureRegime);
                //double pressure = list2[0].MAX.Value;

                double pressure = val.pressure;

                double pressureInput = toPSIG(origin.pressureinput);
                pressure = toPSIG(pressure);
                double flowrateinput = origin.flowrateinput * 1000000;
                double length = toMiles(val.distance / 1000);
                double diameter = getDiameterPanhandleA(pressure, pressureInput, origin.tav, flowrateinput, length);

                PL_CONFIG_PIPELINE pl = new PL_CONFIG_PIPELINE();
                PL_CONFIG_PIPELINE pp = new PL_CONFIG_PIPELINE();
                pl.INSIDE_DIAMETER = diameter;
                PL_CONFIG_PIPELINERepository rep = new PL_CONFIG_PIPELINERepository(connectionString);
                List<PL_CONFIG_PIPELINE> List = rep.GetDataNPS(pl);
               



                val.flowrateinput = origin.flowrateinput;
                val.pressureinput = origin.pressureinput;
                val.tav = origin.tav;
                val.diameterestimate = diameter;
                val.customer = origin.customer;
                val.category = origin.category;
                val.idConstruction = origin.idConstruction;
                val.object1 = jsonPolyLine;
                val.myUrl = origin.myUrl;
                val.pressureRegime = origin.pressureRegime;
                val.areaPipeline = origin.areaPipeline;
                


                PipeCost pc = new PipeCost();
                pc.roughness = val.roughness;
                pc.idConstruction = val.idConstruction;
                pc.length = val.distance;
                pc.pipePressure = val.pressure;
                pc.diameter = val.diameterestimate;
                pc.pipePressureInput = val.pressureinput;
                pc.pipeFlowrateInput = val.flowrateinput;


                if (val.diameterestimate != 0 && val.diameterestimate != null)
                {

                    double cost = rep.GetCost(pc);
                    val.cost = Math.Ceiling(cost);
                    val.NominalPipeSize = pc.NPS;
                    val.unit = pc.unit;
                    

                }


            }
            catch (Exception exc)
            {
                //val.object1 = exc.ToString();
                val.object1 = "Error baris ke = " + Convert.ToString(myRowNumber) + " " + myMessage;
            }

            return val;
        }

        //calcultate manual
        [Route("api/PipeCalculatorPostalcode/CalculateRoute")]
        [HttpPost]


        public PositionParam CalculateRoute(PositionParam origin)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            PositionParam origin_rev = origin;

            GoogleReverseGeocode.RootObject reverseGeocode = GetReverseGeocode(origin);
            if (reverseGeocode != null)
            {
                string postcode = GetPostcode(reverseGeocode);
                string areaPostcode = "";

                PL_AREA_POSTCODERepository repPostcode = new PL_AREA_POSTCODERepository(connectionString);
                List<PL_AREA_POSTCODE> listPostcode = repPostcode.GetDataByKODE_POS(postcode);
                if (listPostcode.Count > 0)
                {
                    areaPostcode = listPostcode[0].NAMA_AREA + "-" + origin.category;
                    origin_rev.areaPipeline = areaPostcode;
                }

            }

            PositionParam retval = Run_Post_Postalcode_Manual(origin_rev);
            return retval;
        }




        private PositionParam Run_Post_Postalcode_Manual(PositionParam origin)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            int myRowNumber = 0;
            string myMessage = "";
            PositionParam val = new PositionParam();
            try
            {

                string myParameter = Newtonsoft.Json.JsonConvert.SerializeObject(origin);

                if (origin.category == "Industri")
                {
                    PL_CONFIG_CALC_AREARepository repCal = new PL_CONFIG_CALC_AREARepository(connectionString);

                    List<PL_CONFIG_CALC_AREA> listCal = repCal.GetDataByAREA(origin.areaPipeline);

                    area = listCal[0].FILE_NAME;
                }
                else if (origin.category == "Rumah Tangga")
                {
                    PL_CONFIG_CALC_AREARepository repCal = new PL_CONFIG_CALC_AREARepository(connectionString);
                    List<PL_CONFIG_CALC_AREA> listCal = repCal.GetDataByCATEGORY(origin.category);
                    area = listCal[0].FILE_NAME;


                }

                string urlarea = "~/Scripts/" + area;
                //}

                string myUrl = ToAbsoluteUrl(urlarea);
                //string myUrl = ToAbsoluteUrl("~/Scripts/PipesRD1.js");
                var json = new WebClient().DownloadString(myUrl);
                Models.GeojsonPipe.RootObject myRootObject = JsonConvert.DeserializeObject<Models.GeojsonPipe.RootObject>(json);
                double orilat = origin.lat;
                double orilng = origin.lng;
                List<double> pointOrigin = new List<double> { orilng, orilat };
                List<PositionParam> listPosition = new List<PositionParam>();
                List<PositionParam> listPositionAlt = new List<PositionParam>();

                foreach (Models.GeojsonPipe.Feature f in myRootObject.features)
                {
                    Models.GeojsonPipe.Properties2 p = f.properties;
                    double innerDiameter = p.PipeDi2003;
                    if (innerDiameter > MINIMUM_INSIDE_DIAMETER)
                    {
                        Models.GeojsonPipe.Geometry g = f.geometry;
                        int pos = 0;
                        PositionParam myPosition = new PositionParam();
                        double minimumDistance = -1.0;
                        double myDistance = 0.0;

                        foreach (List<double> xy in g.coordinates)
                        {
                            //myDistance = Math.Sqrt(Math.Pow(xy[1] - orilat, 2.0) + Math.Pow(xy[0] - orilng, 2.0));
                            myDistance = Models.GeojsonPipe.Calculator.GetDistance(xy, pointOrigin);
                            if (minimumDistance == -1)
                            {
                                minimumDistance = myDistance;
                                myPosition = new PositionParam { name = p.FacNam1005, lat = xy[1], lng = xy[0], sourcepipediameter = Math.Round(p.PipeDi2003, 4), flowrate = Math.Round(p.Flow, 4), pressure = p.Pmax, pressureMin = p.Pmin, distance = minimumDistance, roughness = Math.Round(p.roughness, 5) };
                            }
                            if (minimumDistance > myDistance)
                            {
                                minimumDistance = myDistance;
                                myPosition = new PositionParam { name = p.FacNam1005, lat = xy[1], lng = xy[0], sourcepipediameter = Math.Round(p.PipeDi2003, 4), flowrate = Math.Round(p.Flow, 4), pressure = p.Pmax, pressureMin = p.Pmin, distance = minimumDistance, roughness = Math.Round(p.roughness, 5) };
                            }
                            pos = pos + 1;
                        }
                        listPosition.Add(myPosition);
                    }
                }
                //sort
                listPosition = listPosition.OrderBy(o => o.distance).ToList().Take(TOP_POSITION).ToList();

                List<StartLocation> listRoute = new List<StartLocation>();
                //List<StartLocation> listPolyline = new List<StartLocation>();
                List<List<double>> listPolyline = new List<List<double>>();
                List<double> listDistance = new List<double>();
                //List<string> listJson = new List<string>();
                List<RootObject> listObject = new List<RootObject>();
                double minimunDistance = -1.0;

                try
                {
                    foreach (PositionParam p in listPosition)
                    {
                        //myRowNumber = 1;
                        List<double> pointPipe = (new double[] { p.lng, p.lat }).ToList();
                        //string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=75+9th+Ave+New+York,+NY&destination=MetLife+Stadium+1+MetLife+Stadium+Dr+East+Rutherford,+NJ+07073&key=" + API_KEY;
                        //string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + Convert.ToString(parameters.origin.lat) + "," + Convert.ToString(parameters.origin.lng) + "&destination=" + Convert.ToString(p.lat) + "," + Convert.ToString(p.lng) + "&key=" + API_KEY;
                        //myRowNumber = 2;
                        string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + Convert.ToString(origin.lat) + "," + Convert.ToString(origin.lng) + "&destination=" + Convert.ToString(p.lat) + "," + Convert.ToString(p.lng) + "&mode=" + TRAVEL_MODE + "&key=" + API_KEY;

                        //myRowNumber = 3;
                        WebRequest request = WebRequest.Create(url);
                        //myRowNumber = 4;
                        WebResponse response = request.GetResponse();
                        //myRowNumber = 5;
                        Stream data = response.GetResponseStream();
                        //myRowNumber = 6;
                        StreamReader reader = new StreamReader(data);
                        //myRowNumber = 7;
                        // json-formatted string from maps api
                        string responseFromServer = reader.ReadToEnd();
                        //myRowNumber = 8;
                        RootObject obj = JsonConvert.DeserializeObject<RootObject>(responseFromServer);
                        //myRowNumber = 9;
                        //myMessage = responseFromServer;
                        myMessage = url;
                        //errornya disini

                        double myDistance = obj.routes[0].legs[0].distance.value;

                        //myRowNumber = 10;
                        listDistance.Add(myDistance);
                        //myRowNumber = 11;
                        List<List<double>> listPolyline2 = Models.GeojsonPipe.Calculator.DecodePolylinePoints(obj.routes[0].overview_polyline.points);
                        //myRowNumber = 12;
                        int countPolyline2 = listPolyline2.Count;
                        //myRowNumber = 13;
                        double distanceOffroad = Models.GeojsonPipe.Calculator.GetDistance(listPolyline2[countPolyline2 - 1], pointPipe); //if no road
                        //myRowNumber = 14;


                        if (distanceOffroad < MINIMUM_DISTANCE)
                        {
                            //myRowNumber = 15;
                            if (minimunDistance == -1)
                            {
                                minimunDistance = myDistance;
                                val.distance = minimunDistance;
                                val.lat = p.lat;
                                val.lng = p.lng;
                                val.name = p.name;
                                val.pressure = p.pressure;
                                val.pressureMin = p.pressureMin;
                                val.flowrate = p.flowrate;
                                val.sourcepipediameter = p.sourcepipediameter;
                                val.roughness = p.roughness;

                                //myRowNumber = 16;
                                //break;
                                listRoute = GetRoute(obj.routes[0]);
                                //myRowNumber = 17;
                                listPolyline = Models.GeojsonPipe.Calculator.DecodePolylinePoints(obj.routes[0].overview_polyline.points);
                                //myRowNumber = 18;
                            }
                            if (myDistance < minimunDistance)
                            {
                                //myRowNumber = 19;
                                minimunDistance = myDistance;
                                val.distance = minimunDistance;
                                val.lat = p.lat;
                                val.lng = p.lng;
                                val.name = p.name;
                                val.pressure = p.pressure;
                                val.pressureMin = p.pressureMin;
                                val.flowrate = p.flowrate;
                                val.sourcepipediameter = p.sourcepipediameter;
                                val.roughness = p.roughness;

                                //myRowNumber = 20;
                                listRoute = GetRoute(obj.routes[0]);
                                //myRowNumber = 21;
                                listPolyline = Models.GeojsonPipe.Calculator.DecodePolylinePoints(obj.routes[0].overview_polyline.points);
                                //myRowNumber = 22;
                            }
                            //listJson.Add(responseFromServer);
                            listObject.Add(obj);
                            //myRowNumber = 23;
                        }

                        response.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //myMessage = "kena1";
                    //myRowNumber = 130;
                }


                Models.GeojsonPipe.Feature selectedFeature = myRootObject.features.Find(delegate (Models.GeojsonPipe.Feature f) { return f.properties.FacNam1005.Equals(val.name); });

                List<List<double>> coordinates = selectedFeature.geometry.coordinates;

                int countPipe = selectedFeature.geometry.coordinates.Count;

                int count = listPolyline.Count;

                string jsonPolyLine = JsonConvert.SerializeObject(listPolyline);

                List<Models.GeojsonPipe.PointDistance> listDistance2 = new List<Models.GeojsonPipe.PointDistance>();

                int mypos = 0;



                if (count > 2)
                {
                    foreach (List<double> p in listPolyline)
                    {
                        List<Models.GeojsonPipe.PointDistance> listDistanceSegment = new List<Models.GeojsonPipe.PointDistance>();
                        for (int i = 0; i < countPipe - 1; i++)
                        {
                            double d = 0.0;
                            List<double> p1 = coordinates[i];
                            List<double> p2 = coordinates[i + 1];
                            List<double> s = Models.GeojsonPipe.Calculator.GetDistancePointSegment2(p1, p2, p, out d);
                            double meter = Models.GeojsonPipe.Calculator.GetDistance(p, s);
                            //Models.GeojsonPipe.PointDistance point = new Models.GeojsonPipe.PointDistance { Distance = meter, Pos = mypos, Point = s };
                            Models.GeojsonPipe.PointDistance point = new Models.GeojsonPipe.PointDistance { Distance = meter, Pos = mypos, Point = p };
                            listDistanceSegment.Add(point);

                        }
                        mypos = mypos + 1;
                        listDistanceSegment = listDistanceSegment.OrderBy(o => o.Distance).ToList();
                        listDistance2.Add(listDistanceSegment[0]);
                    }
                    List<List<double>> listPath = new List<List<double>>();
                    foreach (Models.GeojsonPipe.PointDistance p in listDistance2)
                    {
                        listPath.Add(p.Point);
                    }
                    string jsonPath = JsonConvert.SerializeObject(listPath);
                    int pathNum = 0;
                    foreach (Models.GeojsonPipe.PointDistance p in listDistance2)
                    {
                        if (p.Distance < MINIMUM_DISTANCE)
                        {
                            val.lat = p.Point[1];
                            val.lng = p.Point[0];
                            if (p.Distance < MINIMUM_DISTANCE2)
                            {
                                pathNum = pathNum + 1;
                                break;
                            }
                            else
                            {
                                //check next path
                                if (pathNum + 1 < count)
                                {
                                    Models.GeojsonPipe.PointDistance pointTrial = listDistance2[pathNum + 1];
                                    if (pointTrial.Distance < MINIMUM_DISTANCE2)
                                    {
                                        val.lat = p.Point[1];
                                        val.lng = p.Point[0];
                                        pathNum = pathNum + 1;
                                    }
                                }
                                pathNum = pathNum + 1;
                                break;
                            }
                        }
                        pathNum = pathNum + 1;
                    }
                    //check if not the right path
                    PositionParam paramOrigin = listPosition.Find(delegate (PositionParam f) { return f.name.Equals(val.name); });
                    double distanceOriginal = paramOrigin.distance;
                    double distanceCalculated = val.distance;
                    bool iscontinue = true;
                    if (iscontinue) //(distanceOriginal * 1.9 <= distanceCalculated)
                    {
                        List<PositionParam> listNeighbour = new List<PositionParam>();
                        for (int i = 0; i <= pathNum; i++)
                        {
                            //if (i != 8) continue;
                            List<double> p1 = listPolyline[i];
                            List<PositionParam> list1 = new List<PositionParam>();
                            foreach (PositionParam f1 in listPosition)
                            {
                                PositionParam posParam = new PositionParam();
                                string pipeName = f1.name;
                                //if (!pipeName.Equals("Pi350606")) continue;
                                Models.GeojsonPipe.Feature selectedPipe = myRootObject.features.Find(delegate (Models.GeojsonPipe.Feature f) { return f.properties.FacNam1005.Equals(pipeName); });
                                List<List<double>> myCoordinates = selectedPipe.geometry.coordinates;
                                double minDistance = 1e10;
                                int countCoordinateSegment = myCoordinates.Count;
                                for (int j = 0; j < countCoordinateSegment - 1; j++)
                                {
                                    List<double> p2a = myCoordinates[j];
                                    List<double> p2b = myCoordinates[j + 1];
                                    //double distance = Models.GeojsonPipe.Calculator.GetDistance(p1, p2);
                                    double distance2 = 0.0;
                                    List<double> p1c = Models.GeojsonPipe.Calculator.GetDistancePointSegment2(p2a, p2b, p1, out distance2);
                                    distance2 = Models.GeojsonPipe.Calculator.GetDistance(p1, p1c);
                                    if (minDistance > distance2)
                                    {
                                        minDistance = distance2;
                                        posParam = new PositionParam { name = pipeName, distance = minDistance, lat = p1[1], lng = p1[0] };
                                    }
                                }
                                list1.Add(posParam);
                            }
                            list1 = list1.OrderBy(o => o.distance).ToList();
                            listNeighbour.Add(list1[0]);
                            if (i < pathNum)
                            {
                                if (list1[0].distance < MINIMUM_NEIGHBOUR_DISTANCE)
                                {
                                    val.lng = list1[0].lng;
                                    val.lat = list1[0].lat;
                                    if (i + 1 < pathNum)
                                    {
                                        List<double> pointTrial = listPolyline[i + 1];
                                        double distanceTrial = Models.GeojsonPipe.Calculator.GetDistance(p1, pointTrial);
                                        if (distanceTrial < MINIMUM_NEIGHBOUR_DISTANCE2)
                                        {
                                            val.lng = pointTrial[0];
                                            val.lat = pointTrial[1];
                                        }
                                    }
                                    //check next path
                                    break;
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception exc)
            {
                //val.object1 = exc.ToString();
                val.object1 = "Error baris ke = " + Convert.ToString(myRowNumber) + " " + myMessage;
            }

            return val;
        }


        //calcultate manual
        [Route("api/PipeCalculatorPostalcode/CalculateManual")]
        [HttpPost]

        public PositionParam CalculateManual(PositionParam origin)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            int myRowNumber = 0;
            string myMessage = "";
            PositionParam val = new PositionParam();
            try
            {
                

                double pressure = origin.pressure;

                double pressureInput = toPSIG(origin.pressureinput);
                pressure = toPSIG(pressure);
                double flowrateinput = origin.flowrateinput * 1000000;
                double length = toMiles(origin.distance / 1000);
                double diameter = getDiameterPanhandleA(pressure, pressureInput, origin.tav, flowrateinput, length);
                val.roughness = origin.roughness;
                val.idConstruction = origin.idConstruction;
                PL_CONFIG_PIPELINE pl = new PL_CONFIG_PIPELINE();
                PL_CONFIG_PIPELINE pp = new PL_CONFIG_PIPELINE();
                pl.INSIDE_DIAMETER = diameter;
                PL_CONFIG_PIPELINERepository rep = new PL_CONFIG_PIPELINERepository(connectionString);
                List<PL_CONFIG_PIPELINE> List = rep.GetDataNPS(pl);

                val.pressure = origin.pressure;
                val.pressureMin = origin.pressureMin;
                val.flowrate = origin.flowrate;
                val.distance = origin.distance;
                val.name = origin.name;
                val.sourcepipediameter = origin.sourcepipediameter;
                val.flowrateinput = origin.flowrateinput;
                val.pressureinput = origin.pressureinput;
                val.tav = origin.tav;
                val.diameterestimate = diameter;
                val.customer = origin.customer;
                val.category = origin.category;
                val.roughness = origin.roughness;


                PipeCost pc = new PipeCost();
                pc.roughness = val.roughness;
                pc.idConstruction = val.idConstruction;
                pc.length = val.distance;
                pc.pipePressure = val.pressure;
                pc.diameter = val.diameterestimate;
                pc.pipePressureInput = val.pressureinput;
                pc.pipeFlowrateInput = val.flowrateinput;

                if (val.diameterestimate != 0 && val.diameterestimate != null)
                {

                    double cost = rep.GetCost(pc);
                    val.cost = Math.Ceiling(cost);
                    val.NominalPipeSize = pc.NPS;
                    val.unit = pc.unit;


                }

            }
            catch (Exception exc)
            {
                //val.object1 = exc.ToString();
                val.object1 = "Error baris ke = " + Convert.ToString(myRowNumber) + " " + myMessage;
            }

            return val;
        }

        // Function to calculate pipe sizing diameter (inch) using PanhandleA
        // Q = volume flow rate, standard ft3/day (SCFD)
        // E = pipeline efficiency, a decimal value less than 1.0
        // Pb = base pressure, psia
        // Tb = base temperature, °R (460 + °F)
        // P1 = upstream pressure, psia
        // P2 = downstream pressure, psia
        // G =  gas gravity (air = 1.00)
        // Tf = average gas flow temperature, °R (460 + °F)
        // d = inside pipe diameter
        // L = Pipe length (KM)

        // Panhandle-A equation, assume elevation is 0
        // Q = 435.87*E*X*Y*D (unit, SCFD)
        // X = (Tb/Pb)^1.0788
        // Y = ((P1^2-P2^2)/((G^0.8539)*Tf*L*Z))^0.5394
        // D = d^2.6182
        private double getDiameterPanhandleB(double p1, double p2, int Tav, double Q, double L)
        {
            // Assume E = 0.92
            double E = 0.92;
            // assume specific gravity
            double g = 0.65;
            // assume base pressure
            double pb = 14.73; // psia
            // assume base temperature
            double tb = 520; // Reamur (460 + 60F)

            // Convert km to miles
            L = toMiles(L);

            // get compressibility factor
            double Z = getCompressiblityFactoryCNGA(p1, p2, Tav);

            double X = 737 * E * Math.Pow(tb / pb, 1.02);
            double Y = Math.Pow(p1 + pb, 2) - Math.Pow(p2 + pb, 2);
            double W = Math.Pow(g, 0.961) * toReamur(Tav) * L * Z;
            double u = Math.Pow(Y / W, 0.51);
            double D = Q / (X * u);

            // compute inside diameter
            double d = Math.Pow(D, 1 / 2.53);
            return d;


        }

        // Panhandle-B equation, assume elevation is 0
        // Q = 737*E*X*Y*D (unit, SCFD)
        // X = (Tb/Pb)^1.02
        // Y = ((P1^2-P2^2)/((G^0.961)*Tf*L*Z))^0.51
        // D = d^2.53
        private double getDiameterPanhandleA(double p1, double p2, int Tav, double Q, double L)
        {
            

            // Assume E = 0.92
            double E = 0.90;
            // assume specific gravity
            double g = 0.65;
            // assume base pressure
            double pb = 14.73; // psia
            // assume base temperature
            double tb = 520; // Reamur (460 + 60F)

            // Convert km to miles
            //L = toMiles(L);

            // get compressibility factor
            double Z = getCompressiblityFactoryCNGA(p1, p2, Tav);

            double X = 435.87 * E * Math.Pow(tb / pb, 1.0788);
            double Y = Math.Pow(p1 + pb, 2) - Math.Pow(p2 + pb, 2);
            double W = Math.Pow(g, 0.8539) * toReamur(Tav) * L * Z;
            double u = Math.Pow(Y / W, 0.5394);
            double D = Q / (X * u);

            // compute inside diameter
            double d = Math.Pow(D, 1 / 2.6182);
            return d;
        }

        private double getCompressiblityFactoryCNGA(double p1, double p2, int Tav)
        {
            // assume specific gravity
            double g = 0.65;
            // assume base pressure
            //var pb = 14.73; // psia
            // get temperature in Reamur
            double r = toReamur(Tav);
            // pressure in psig
            double Pavg = ((p1 + p2) - ((p1 * p2) / (p1 + p2))) * 2 / 3;
            // calculate compressibility factor
            // double z = 1 / (1 + (((Pavg - BASE_PRESSURE) * 344400 * Math.Pow(10, 1.785 * SPECIFIC_GRAVITY)) / Math.Pow(Tav, 3.825)));
            double z1 = Pavg * 344400 * Math.Pow(10, 1.785 * g);
            double z2 = Math.Pow(r, 3.825);
            double z3 = z1 / z2;
            double z = 1 / (1 + z3);

            return z;
        }

        private int toFahrenheit(int celcius)
        {

            var f = (celcius * 9 / 5) + 32;
            return f;
        }

        private double toMiles(double km)
        {
            return km / 1.6;
        }

        private double toPSIG(double bar)
        {

            double psig = 14.5038 * bar;
            return psig;
        }

        private int toReamur(int celcius)
        {

            var f = toFahrenheit(celcius) + 460;
            return f;
        }

        private double getCost(double length)
        {
            return length * 1000000;
        }






        public static double GetPipelineConstructionCost(double lengthpipe, double pipeoutsitediameter, double pipewallthickness, double pipelineCostPerTon, double laborCostPerMeter)
        {

            double d = 0;
            double laborcost = 0;

            double po = InchToMilimeter(pipeoutsitediameter);
            double pw = InchToMilimeter(pipewallthickness);

            d = 0.0246 * (po - pw) * pw * lengthpipe * pipelineCostPerTon;
            laborcost = lengthpipe * laborCostPerMeter * 1000;

            return d + laborcost;
        }
        public static double InchToMilimeter(double inch)
        {
            return inch * 25.4;
        }

       



    }
}
