using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_DEMAND_GASVOLUME_HOURLY_MONTHLY
	{
		public virtual string ID_UNIT_USAHA { get; set; }
		public virtual string IDREFPELANGGAN { get; set; }
		public virtual string NAMA { get; set; }
        public virtual int? daynumber { get; set; }
        public virtual string dayofWeekName { get; set; }
		public virtual int? FHOUR { get; set; }
		public virtual double TOTAL_FDVC { get; set; }
		public virtual double AVERAGE_FDVC { get; set; }
		public virtual double AVERAGE_FDVC_24 { get; set; }
        public virtual double kontrak_perjam { get; set; }
        public virtual double persen_utilisasi { get; set; }
        public virtual string start_date { get; set; }
        public virtual string end_date { get; set; }


		public PL_DEMAND_GASVOLUME_HOURLY_MONTHLY()
		{

		}
	}
}