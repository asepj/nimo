using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_AREA_GASVOLUME
	{
		public virtual int? DATETIME_ID { get; set; }
		public virtual DateTime? FDATETIME { get; set; }
		public virtual string AREA_ID { get; set; }
		public virtual double TOTAL_FDVC { get; set; }

		public PL_AREA_GASVOLUME()
		{

		}
	}
}