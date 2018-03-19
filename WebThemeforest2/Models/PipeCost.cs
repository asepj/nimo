using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models
{
    public class PipeCost
    {


        public double roughness { get; set; }
        public int idConstruction { get; set; }
        public double length  { get; set; }
        public double pipePressure  { get; set; }
        public double diameter  { get; set; }
        public double cost  { get; set; }

        public double pipePressureInput { get; set; }

        public double pipeFlowrateInput  { get; set; }

        public double NPS { get; set; }

        public string unit   { get; set; }

        public PipeCost()
        {

        }

    }
}