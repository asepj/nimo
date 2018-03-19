using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models.RelyOn.Input
{
    public class Customer
    {
        public string name { get; set; }
        public string type { get; set; }
        public Location location { get; set; }
    }
}