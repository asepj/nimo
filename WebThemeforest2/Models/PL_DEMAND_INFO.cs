using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_DEMAND_INFO
	{
		public virtual string IDRefPelanggan { get; set; }
		public virtual string AreaID { get; set; }
		public virtual string Name { get; set; }
		public virtual double? Latitude { get; set; }
		public virtual double? Longitude { get; set; }
		public virtual double? Altitude { get; set; }
		public virtual string Geometry { get; set; }

		public PL_DEMAND_INFO()
		{

		}
	}
}