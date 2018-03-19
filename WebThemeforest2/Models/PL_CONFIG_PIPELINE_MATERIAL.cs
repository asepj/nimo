using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_PIPELINE_MATERIAL
	{
		public virtual int? MATERIAL_ID { get; set; }
		public virtual string MATERIAL_CODE { get; set; }
		public virtual string MATERIAL_NAME { get; set; }
		public virtual double? ROUGHNESS { get; set; }

		public PL_CONFIG_PIPELINE_MATERIAL()
		{

		}
	}
}