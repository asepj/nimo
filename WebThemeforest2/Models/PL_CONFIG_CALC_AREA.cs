using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_CALC_AREA
	{
		public virtual int? ID { get; set; }
		public virtual string AREA { get; set; }
		public virtual string REGIME { get; set; }
		public virtual string FILE_NAME { get; set; }

        public virtual double LAT { get; set; }
        public virtual double LNG { get; set; }

        public virtual int ID_CONSTRUCTION { get; set; }
        public virtual string CATEGORY { get; set; }

		public virtual int? ENABLED { get; set; }

		public PL_CONFIG_CALC_AREA()
		{

		}
	}
}