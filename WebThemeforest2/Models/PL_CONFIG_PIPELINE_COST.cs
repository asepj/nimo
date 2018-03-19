using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_PIPELINE_COST
	{
		public virtual int? ID { get; set; }
		public virtual int? ID_CLASSIFICATION { get; set; }
		public virtual int? PIPE_GRADE { get; set; }
		public virtual double NPS { get; set; }
		public virtual decimal? MATERIAL_COST_PERMETER { get; set; }
		public virtual decimal? BASE_MATERIAL_COST { get; set; }
		public virtual decimal? CONSTRUCTION_COST { get; set; }
		public virtual decimal? BASE_CONSTRUCTION_COST { get; set; }

		public PL_CONFIG_PIPELINE_COST()
		{

		}
	}
}