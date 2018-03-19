using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeoJsonPoint
{
    public class FeatureProperties
    {


        public string IDRefPelanggan { get; set; }
        public string FacilityType { get; set; }
        public string AreaID { get; set; }
        public string AreaName { get; set; }
        public string Name { get; set; }

        public string  Year { get; set; }
        public double Flowrate { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

       
        public string Date { get; set; }

        public FeatureProperties()
        {

        }
    }
}
