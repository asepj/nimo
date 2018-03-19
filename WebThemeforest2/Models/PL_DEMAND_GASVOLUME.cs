using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_DEMAND_GASVOLUME
	{
		public virtual int? DATE_ID { get; set; }
		public virtual DateTime FDATETIME { get; set; }
		public virtual string IDREFPELANGGAN { get; set; }
		public virtual string ID_UNIT_USAHA { get; set; }
		public virtual string NAMA { get; set; }
		public virtual double  TOTAL_FDVC { get; set; }

		public PL_DEMAND_GASVOLUME()
		{

		}
	}
}