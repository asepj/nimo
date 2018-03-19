using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeoJsonPoint
{
    public class Feature
    {
        public string type { get; set; }
        public FeatureProperties properties { get; set; }
        public Geometry geometry { get; set; }
    
        public Feature()
        {

        }
    }
}
