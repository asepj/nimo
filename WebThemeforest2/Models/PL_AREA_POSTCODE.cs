using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_AREA_POSTCODE
	{
		public virtual string KODE_POS { get; set; }
		public virtual string KELURAHAN { get; set; }
		public virtual string KECAMATAN { get; set; }
		public virtual string JENIS { get; set; }
		public virtual string KABUPATEN { get; set; }
		public virtual string PROPINSI { get; set; }
		public virtual string NAMA_AREA { get; set; }

		public PL_AREA_POSTCODE()
		{

		}
	}
}