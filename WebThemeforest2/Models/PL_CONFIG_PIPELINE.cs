using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_PIPELINE
	{
		public virtual int? ID { get; set; }
		public virtual int? MATERIAL_ID { get; set; }
		public virtual string SCHEDULE { get; set; }
		public virtual string NPS { get; set; }
		public virtual double OUTSIDE_DIAMETER { get; set; }
		public virtual double WALL_THICKNESS { get; set; }
		public virtual double INSIDE_DIAMETER { get; set; }

		public PL_CONFIG_PIPELINE()
		{

		}
	}
}