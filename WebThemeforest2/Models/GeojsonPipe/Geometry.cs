using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models.GeojsonPipe
{
    public class Geometry
    {
        public string type { get; set; }
        public List<List<double>> coordinates { get; set; }
    }
}