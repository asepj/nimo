using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class VIEW_PELANGGAN3
	{
        private double DEFAULT_MONTHLY_WORK_DAYS = 6.0;
        private double DEFAULT_VOLUME = 0.000001;
        private double CONVERSION_M3D_MMSCFD = 0.000815249;
        public double GetMaxContractDaily()
        {
            double retval = DEFAULT_VOLUME;
            if (this.HARIAN_MAX_KONTRAK != null)
            {
                retval = this.HARIAN_MAX_KONTRAK.Value;
            }
            else if (this.BULANAN_MAX_KONTRAK != null)
            {
                double dayWeek = DEFAULT_MONTHLY_WORK_DAYS;
                if (this.JML_HARI_KERJA_MINGGU != null)
                {
                    dayWeek = this.JML_HARI_KERJA_MINGGU.Value;
                }
                if (dayWeek == 0)
                {
                    dayWeek = DEFAULT_MONTHLY_WORK_DAYS;
                }
                retval = this.BULANAN_MAX_KONTRAK.Value / (dayWeek * 4.0);
            }

            retval = retval * CONVERSION_M3D_MMSCFD;
            retval = retval / 24.0; //hourly to daily
            retval = -retval;

            return retval;
        }

        public override string ToString()
        {
            return this.IDREFPELANGGAN;
        }

	}
}