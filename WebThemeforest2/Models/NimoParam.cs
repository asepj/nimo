using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models
{
    public class NimoParam
    {
        public DateTime DATE_STAMP { get; set; }
        public string DATE_STAMP_STRING { get; set; }
        public string AREA { get; set; }
        public int PARAM_ID { get; set; }

        public DateTime Start { get; set; }

        public DateTime End  { get; set; }


        public NimoParam()
        {

        }
    }
}