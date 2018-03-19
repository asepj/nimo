using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;
using WebThemeforest2.Models.GeoJsonPoint;
namespace WebThemeforest2.Repositories
{
	public partial class PL_DEMAND_INFORepository
	{
		

		

		public List<FeatureProperties> GetDataDemand()
		{
			List<FeatureProperties> items = new List<FeatureProperties>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
                    //SqlCommand command = new SqlCommand("SELECT a.IDREFPELANGGAN, a.NAMA, b.MonthName, b.Year,SUM (a.TOTAL_FDVC) AS TOTAL_MONTHLY_FDVC,c.Latitude,c.Longitude,d.ID_UNIT_USAHA,d.AREA FROM [dbo].[PL_DEMAND_GASVOLUME_DAILY] a, [dbo].[PL_DIM_DATE] b, [dbo].[PL_DEMAND_INFO] c,[dbo].[PL_AREA_REGIONAL] d WHERE  a.DATE_ID = b.DATE_ID AND     a.IDREFPELANGGAN = c.[IDRefPelanggan] AND     c.AreaID = d.ID_UNIT_USAHA AND    b.[Year] = '2017' AND    b.MonthName = 'July' AND     c.AreaID = '011' GROUP BY a.IDREFPELANGGAN, a.NAMA,b.MonthName, b.[Year],c.Latitude, c.Longitude,d.ID_UNIT_USAHA,d.AREA ORDER BY b.[Year] ASC, a.IDREFPELANGGAN ASC", conn);
                    //SqlCommand command = new SqlCommand("SELECT a.IDREFPELANGGAN, a.NAMA, b.MonthName, b.Year,SUM (a.TOTAL_FDVC) AS TOTAL_MONTHLY_FDVC,c.Latitude,c.Longitude,d.ID_UNIT_USAHA,d.AREA FROM [dbo].[PL_DEMAND_GASVOLUME_DAILY] a, [dbo].[PL_DIM_DATE] b, [dbo].[PL_DEMAND_INFO] c,[dbo].[PL_AREA_REGIONAL] d WHERE  a.DATE_ID = b.DATE_ID AND     a.IDREFPELANGGAN = c.[IDRefPelanggan] AND     c.AreaID = d.ID_UNIT_USAHA  GROUP BY a.IDREFPELANGGAN, a.NAMA,b.MonthName, b.[Year],c.Latitude, c.Longitude,d.ID_UNIT_USAHA,d.AREA ORDER BY b.[Year] ASC, a.IDREFPELANGGAN ASC", conn);
                   // SqlCommand command = new SqlCommand("SELECT a.IDREFPELANGGAN, a.NAMA, b.MonthName,b.Year,SUM(a.TOTAL_FDVC) AS TOTAL_MONTHLY_FDVC, c.Latitude,c.Longitude,d.id ID_UNIT_USAHA,d.nama AREA FROM[dbo].[PL_DEMAND_GASVOLUME_DAILY] a,[dbo].[PL_DIM_DATE] b,[dbo].[vw_sipg_view_pelanggan3] c,[dbo].[vw_sipg_idx_areapelanggan] d WHERE  a.DATE_ID = b.DATE_ID AND   a.IDREFPELANGGAN = c.[IDREFPELANGGAN] AND    c.ID_UNIT_USAHA = d.ID GROUP BY a.IDREFPELANGGAN, a.NAMA, b.MonthName, b.[Year], c.Latitude, c.Longitude, d.ID, d.NAMA ORDER BY b.[Year] ASC, a.IDREFPELANGGAN ASC", conn);
                    
                    //SqlCommand command = new SqlCommand("SELECT a.IDREFPELANGGAN, a.NAMA, b.MonthName,b.Year, SUM (a.TOTAL_FDVC)/1000 AS TOTAL_MONTHLY_FDVC,  c.Latitude, c.Longitude, d.id ID_UNIT_USAHA, d.nama AREA FROM [dbo].[PL_DEMAND_GASVOLUME_DAILY] a,  [dbo].[PL_DIM_DATE] b, [dbo].[vw_sipg_view_pelanggan3] c, [dbo].[vw_sipg_idx_areapelanggan] d  WHERE  a.DATE_ID = b.DATE_ID AND    a.IDREFPELANGGAN = c.[IDREFPELANGGAN] AND    c.ID_UNIT_USAHA = d.ID GROUP BY a.IDREFPELANGGAN, a.NAMA, b.MonthName, b.[Year], c.Latitude, c.Longitude, d.ID, d.NAMA ORDER BY b.[Year] ASC, a.IDREFPELANGGAN ASC", conn);

                    SqlCommand command = new SqlCommand("SELECT a.IDREFPELANGGAN, a.NAMA, b.MonthName, b.Year, AVG (a.AVERAGE_FDVC)/1000 AS AVERAGE_MONTHLY_FDVC, c.Latitude, c.Longitude, d.id ID_UNIT_USAHA, d.nama AREA FROM [dbo].[PL_DEMAND_GASVOLUME_DAILY] a, [dbo].[PL_DIM_DATE] b, [dbo].[vw_sipg_view_pelanggan3] c,  [dbo].[vw_sipg_idx_areapelanggan] d WHERE  a.DATE_ID = b.DATE_ID AND    a.IDREFPELANGGAN = c.[IDREFPELANGGAN] AND    c.ID_UNIT_USAHA = d.ID GROUP BY a.IDREFPELANGGAN, a.NAMA, b.MonthName, b.[Year], c.Latitude, c.Longitude, d.ID, d.NAMA ORDER BY b.[Year] ASC, a.IDREFPELANGGAN ASC", conn);
                    
                    SqlDataReader reader = command.ExecuteReader();
					FeatureProperties item = new FeatureProperties();
					while(reader.Read())
					{
						item = new FeatureProperties();
						if (reader[0] != DBNull.Value) { item.IDRefPelanggan = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.Name = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.Date = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.Year = Convert.ToString(reader[3]); }
						if (reader[4] != DBNull.Value) { item.Flowrate = Convert.ToDouble(reader[4]); }
                        if (reader[6] != DBNull.Value) { item.Lng = Convert.ToDouble(reader[5]); }
                        if (reader[5] != DBNull.Value) { item.Lat = Convert.ToDouble(reader[6]); }						
                        if (reader[7] != DBNull.Value) { item.AreaID = Convert.ToString(reader[7]); }
                        if (reader[8] != DBNull.Value) { item.AreaName = Convert.ToString(reader[8]); }
                        items.Add(item);
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
			return items;
		}

		

	}
}