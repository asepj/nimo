using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeoJsonPoint
{
    public class RootObject
    {
        public string type { get; set; }
        //public string name { get; set; }
        public Crs crs { get; set; }
        public List<Feature> features { get; set; }

       

        public RootObject()
        {

        }

        public void Populate(List<FeatureProperties> listfeatures)
        {
            this.type = "FeatureCollection";
            Crs crs = new Crs { type = "name" };
            CrsProperties crsProperties = new CrsProperties { name = "urn:ogc:def:crs:OGC:1.3:CRS84" };
            crs.properties = crsProperties;
            List<Feature> listFeature = new List<Feature>();

            this.crs = crs;

            foreach (FeatureProperties n in listfeatures)
            {
               
                Feature feature = new Feature { type = "Feature" };

                FeatureProperties featureProperties = new FeatureProperties { IDRefPelanggan = n.IDRefPelanggan, FacilityType = "Point", AreaID = n.AreaID, AreaName = n.AreaName, Name = n.Name , Year = n.Year, Date = n.Date +"-"+ n.Year, Flowrate = n.Flowrate, Lat = n.Lat, Lng = n.Lng};
                feature.properties = featureProperties;

                double[] _cordinate  = { n.Lng, n.Lat };

                Geometry geometry = new Geometry { type = "Point", coordinates = _cordinate  };
                feature.geometry = geometry;

                listFeature.Add(feature);
                

            }
            this.features = listFeature;
        }
    }
}
