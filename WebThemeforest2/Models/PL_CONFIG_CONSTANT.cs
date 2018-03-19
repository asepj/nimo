using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_CONSTANT
	{
		public virtual int? ID { get; set; }
		public virtual string CONSTANT_NAME { get; set; }
		public virtual double  VALUE { get; set; }

		public PL_CONFIG_CONSTANT()
		{

		}
	}
}