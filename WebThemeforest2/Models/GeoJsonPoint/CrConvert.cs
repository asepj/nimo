using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeoJsonPoint
{
    public class CrConvert
    {
        public static bool IsDemand(string str)
        {
            string strsub = str.Substring(0, 1);
            int num = 0;
            bool bl = Int32.TryParse(strsub, out num);
            return bl;
        }

        public static string GetDemandName(string str)
        {
            string retval = str;
            string strsub = str.Substring(0, 1);
            if (!strsub.Equals("0"))
            {
                retval = "0" + str;
            }
            return retval;
        }

        public static string GetAreaID(string str)
        {
            string retval = str;
            string strsub = str.Substring(0, 1);
            if (!strsub.Equals("0"))
            {
                retval = "0" + str;
            }
            retval = retval.Substring(0,3);
            return retval;
        }


    }
}
