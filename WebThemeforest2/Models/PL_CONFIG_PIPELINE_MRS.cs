using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
    public partial class PL_CONFIG_PIPELINE_MRS
    {
        public virtual int? ID_MRS { get; set; }
        public virtual string MRS_TYPE { get; set; }
        public virtual double MATERIAL_COST { get; set; }
        public virtual double CONSTRUCTION_COST { get; set; }
        public virtual double MAX_FLOW { get; set; }

        public PL_CONFIG_PIPELINE_MRS()
        {

        }
    }
}