using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models.RelyOn.Input
{
    public class RootObject
    {
        public Customer customer { get; set; }
        public FlowRate flow_rate { get; set; }
        public Pressure pressure { get; set; }

        public Temperature temperature { get; set; }
    }
}