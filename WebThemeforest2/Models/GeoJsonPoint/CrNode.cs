using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace WebThemeforest2.Models.GeoJsonPoint
{
    public class CrNode
    {
        public int NodeId { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }

        public double VolumeContract { get; set; }

        //public double Length { get; set; }

        public double Pressure { get; set; }

        public bool IsCustomNode { get; set; }

        protected string prefixRS = "RS";
        protected string prefixNo = "No";

        public string Description { get; set; }

        public string Status { get; set; }

        public double[] Coordinate { get; set; }
        public bool IsDemand 
        { 
            get
            {
                bool bl = false;
                string s = Name.Substring(0, 1);
                int val = 0;
                bl = Int32.TryParse(s, out val);
                return bl;
            }
        }

        public bool IsRS
        {
            get
            {
                bool bl = false;
                string s = Name.Substring(0, 2);
                bl = s.Equals(prefixRS) ? true : false;
                return bl;
            }
        }

        public bool IsSupply
        {
            get
            {
                bool bl1 = false;
                bool bl2 = false;
                bool bl3 = false;
                bool bl = false;
                string s1 = Name.Substring(0, 2);
                bl1 = s1.Equals(prefixRS) ? true : false;
                bl2 = s1.Equals(prefixNo) ? true : false;
                string s3 = Name.Substring(0, 1);
                int v3 = 0;
                bl3 = Int32.TryParse(s3, out v3);
                if (!bl1 && !bl2 && !bl3)
                {
                    bl = true;
                }

                return bl;
            }
        }

        public string GetDemandName()
        {
            string str = this.Name;
            if (this.IsDemand)
            {
                string str2 = str.Substring(0, 1);
                if (!str2.Equals("0"))
                {
                    str = "0" + str;
                }
            }
            return str;
        }
        public CrNode()
        {

        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            bool bl = false;

            if (obj==null || GetType() != obj.GetType())
            {
                bl = false;
            }
            else
            {
                CrNode myNode = (CrNode)obj;
                if (this.Name.Equals(myNode.Name))
                {
                    bl = true;
                }
            }

            return bl;
        }
    }
}