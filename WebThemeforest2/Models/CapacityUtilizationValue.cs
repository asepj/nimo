using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models
{
    public class CapacityUtilizationValue
    {
        public List<CapacityUtilizationCount> Items { get; set; }

        public double AverageTotalFlow { get; set; }
        public double TotalFlow { get; set; }
        public double TotalFlowAllArea { get; set; }
        public double TotalFlowSBU { get; set; }

        public double CountDays { get; set; }

        public double MaxTotalFlow { get; set; }

        public CapacityUtilizationValue()
        {
        }
    }
}