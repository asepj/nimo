using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models.RelyOn.Output
{
    public class Data
    {
        public string id { get; set; }
        public string type { get; set; }
        public Location location { get; set; }
        public Distance distance { get; set; }
        public Diameter diameter { get; set; }
        public Pressure pressure { get; set; }
        public List<Volume> volume { get; set; }
        public Cost cost { get; set; }
        public string route { get; set; }
    }
}