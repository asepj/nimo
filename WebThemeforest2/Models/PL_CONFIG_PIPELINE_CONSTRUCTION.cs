using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_PIPELINE_CONSTRUCTION
	{
		public virtual int? ID_CONSTRUCTION { get; set; }
		public virtual string DESCRIPTION { get; set; }
        public virtual string CATEGORY  { get; set; }
        public virtual int STATUS { get; set; }

		public PL_CONFIG_PIPELINE_CONSTRUCTION()
		{

		}
	}
}