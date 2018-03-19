using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_PRESSURE_REGIME
	{
		public virtual string REGIME_NAME { get; set; }
		public virtual double? MIN { get; set; }
		public virtual double? MAX { get; set; }

		public PL_CONFIG_PRESSURE_REGIME()
		{

		}
	}
}