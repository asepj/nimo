using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeoJsonPoint
{
    public class CrPipeResult
    {
        public string PipeName { get; set; }
        public string NodeName { get; set; }
        public float Pressure { get; set; }
        public float Flow { get; set; }
        //public float Roughness { get; set; }
        public float PressureActual { get; set; }
        public float FlowActual { get; set; }

        public CrPipeResult() 
        {
        }

        public override string ToString()
        {
            return PipeName;
        }
    }
}
