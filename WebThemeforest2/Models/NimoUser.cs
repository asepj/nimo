using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models
{
    public partial class NimoUser
    {
        public virtual string USER_ID { get; set; }
        public virtual string USER_NAME { get; set; }
        public virtual string USER_PASSWORD { get; set; }
        public virtual string USER_ROLE { get; set; }

        public NimoUser()
		{

		}

    }
}