using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeoJsonPoint
{
    public class Crs
    {
        public string type { get; set; }
        public CrsProperties properties { get; set; }

        public Crs()
        {

        }
    }
}
