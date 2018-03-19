using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
    public partial class PL_CONFIG_DASHBOARD
    {
        public virtual int? ID { get; set; }
        public virtual string AREA { get; set; }
        public virtual string NAME { get; set; }
        public virtual int? CAPACITY_MAX { get; set; }

        public PL_CONFIG_DASHBOARD()
        {

        }
    }
}