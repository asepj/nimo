using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeoJsonPoint
{
    public class Geometry
    {
        public string type { get; set; }
        //public List<double[]> coordinates { get; set; }
        public double[] coordinates { get; set; }
        public Geometry()
        {

        }

    }
}
