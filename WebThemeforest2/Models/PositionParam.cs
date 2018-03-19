using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models
{
    public class PositionParam
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public double distance { get; set; }
        public string name { get; set; }
        public double pressure { get; set; }

        public double pressureMin  { get; set; }

        public double flowrate { get; set; }
        public double pressureinput { get; set; }
        public double flowrateinput { get; set; }
        public int tav { get; set; }
        public double sourcepipediameter { get; set; }
        public double diameterestimate  { get; set; }
        public double cost  { get; set; }
        public double NominalPipeSize  { get; set; }
        public string category { get; set; }
        public string customer  { get; set; }
        public string object1 { get; set; }

        public double roughness { get; set; }

        public int idConstruction { get; set; }

        public string myUrl { get; set; }

        public string pressureRegime { get; set; }

        public string areaPipeline { get; set; }

        public string unit   { get; set; }


        public PositionParam()
        {

        }
    }
}