using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models
{
    public class CapacityUtilizationCount
    {
        public DateTime datetime { get; set; }
        public int day { get; set; }
        public string DayName { get; set; }
        public int hour { get; set; }
        public double value { get; set; }
        public string AreaName { get; set; }
        public string AreaCode { get; set; }

        public double MaxTotalFlow { get; set; }

        public double AverageTotalFlow { get; set; }
        public CapacityUtilizationCount()
        {

        }
    }
}