using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_OVERVIEW
	{
		public virtual int? ID { get; set; }
		public virtual double MIN { get; set; }
		public virtual double MAX { get; set; }
		public virtual string COLOUR { get; set; }
        public virtual string ID_UNIT_USAHA  { get; set; }
		public virtual string AREA_NAME { get; set; }
        public virtual string MAP_TYPE { get; set; }

		public PL_CONFIG_OVERVIEW()
		{

		}
	}
}