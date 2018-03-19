using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class PL_CONFIG_USER_ROLE
	{
		public virtual int? ID { get; set; }
		public virtual string USER_NAME { get; set; }
		public virtual string USER_ROLE { get; set; }

		public PL_CONFIG_USER_ROLE()
		{

		}
	}
}