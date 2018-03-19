using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThemeforest2.Models.GeojsonPipe
{
    public class PointDistance
    {
        public double Distance { get; set; }
        public List<double> Point { get; set; }
        public int Pos { get; set; }
        public PointDistance()
        {

        }
    }
}
