using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using WebThemeforest2.Models;

namespace WebThemeforest2
{
    public class TestController : ApiController
    {
        public string Post(NimoParam param)
        {
            string val = "";
            string myParameter = Newtonsoft.Json.JsonConvert.SerializeObject(param);

            DateTime start = new DateTime();
            DateTime end = new DateTime();
            val =      ParseDateStamp(param, param.PARAM_ID, out start, out end);

            //test
            //start = start.AddMonths(-2);
            //end = end.AddMonths(-2);

           

            return val;
        }


        private string ParseDateStamp(NimoParam param, int paramid,  out DateTime start, out DateTime end)
        {
            end = DateTime.Now;
            end = new DateTime(end.Year, end.Month, end.Day);
            start = end.AddDays(-6);

            string str = param.DATE_STAMP_STRING;
            string[] dates = str.Split('-');
            string val = "";
            
            

            if (paramid == 1)
            {
                val = dates[0];

            }
            
            else if (paramid == 2){

                val = dates[1];
            }
            else if (paramid == 3)
            {

                val = DateTime.Parse(dates[0]).ToString();
            }

            else if (paramid == 4)
            {
                val = DateTime.Parse(dates[1]).ToString();
               
            }

            else if (paramid == 5)
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                val = cultureInfo.Name;

            }

            //if (dates.Length == 2)
            //{
            //    string strStart = dates[0];
              //start = DateTime.Parse(val);
            //    string strEnd = dates[1];
            //    end = DateTime.Parse(strEnd);
            //}
            return val;
        }
    }
}
