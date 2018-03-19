using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models
{
    public partial class NimoLogin
    {
        public virtual string dominName { get; set; }
        public virtual string adPath { get; set; }
        public virtual string userName { get; set; }
        public virtual string userPassword  { get; set; }
        public virtual string userRole { get; set; }

        public virtual string roleAdmin { get; set; }

        public virtual string roleUser   { get; set; }
        public virtual bool stat { get; set; }


        public NimoLogin()
		{

		}

    }
}