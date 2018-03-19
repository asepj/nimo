using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class HistoryCalculator
	{
		public virtual int? ID { get; set; }
		public virtual double SOURCE_DIAMETER { get; set; }
		public virtual double SOURCE_PRESSURE { get; set; }
		public virtual double PRESSURE_INPUT { get; set; }
		public virtual double FLOWRATE_INPUT { get; set; }
		public virtual double ESTIMATED_DIAMETER { get; set; }
		public virtual double ESTIMATED_LENGTH { get; set; }
		public virtual double ESTIMATED_COST { get; set; }
		public virtual double ESTIMATED_FLOWRATE { get; set; }
		public virtual double REMAINING_CAPACITY { get; set; }
		public virtual string CATEGORY { get; set; }
		public virtual string CUSTOMER { get; set; }
		public virtual double LAT { get; set; }
		public virtual double LNG { get; set; }
		public virtual DateTime CREATED_DATE { get; set; }
		public virtual string CREATED_BY { get; set; }

        public HistoryCalculator()
		{

		}
	}
}