using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class VIEW_PELANGGAN3Repository
	{
		private string connString;
		public string Message { get; set; }

		public VIEW_PELANGGAN3Repository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(VIEW_PELANGGAN3 view_pelanggan3)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO VIEW_PELANGGAN3 ([IDREFPELANGGAN], [ACC_ID], [ID_UNIT_USAHA], [NOREF], [NAMA], [ALAMAT], [JENIS_CUSTOMER], [JENIS_TARIF], [CONTACT_PERSON], [NO_TELP], [STATUS], [NO_KONTRAK], [TGL_BERLAKU], [TGL_BERAKHIR], [JENIS_KONTRAK], [MIN_KONTRAK], [MAX_KONTRAK], [HARIAN_MIN_KONTRAK], [BULANAN_MIN_KONTRAK], [HARIAN_MAX_KONTRAK], [BULANAN_MAX_KONTRAK], [TEKANAN], [SEKTOR], [SEKTOR_INDUSTRI], [TGL_BERLANGGANAN], [TGL_BERHENTI_BERLANGGANAN], [JNS_KALORI], [JML_HARI_KERJA_MINGGU], [JML_JAM_KERJA_HARI], [KODE_HARGA], [LONGITUDE], [LATITUDE], [SIPGAS_LAST_FEED], [SERIAL_NUM], [ASSET_NUM], [INSTALL_DATE], [MERK], [ATTRIBUTE_TIPE], [GSIZE]) VALUES(@IDREFPELANGGAN, @ACC_ID, @ID_UNIT_USAHA, @NOREF, @NAMA, @ALAMAT, @JENIS_CUSTOMER, @JENIS_TARIF, @CONTACT_PERSON, @NO_TELP, @STATUS, @NO_KONTRAK, @TGL_BERLAKU, @TGL_BERAKHIR, @JENIS_KONTRAK, @MIN_KONTRAK, @MAX_KONTRAK, @HARIAN_MIN_KONTRAK, @BULANAN_MIN_KONTRAK, @HARIAN_MAX_KONTRAK, @BULANAN_MAX_KONTRAK, @TEKANAN, @SEKTOR, @SEKTOR_INDUSTRI, @TGL_BERLANGGANAN, @TGL_BERHENTI_BERLANGGANAN, @JNS_KALORI, @JML_HARI_KERJA_MINGGU, @JML_JAM_KERJA_HARI, @KODE_HARGA, @LONGITUDE, @LATITUDE, @SIPGAS_LAST_FEED, @SERIAL_NUM, @ASSET_NUM, @INSTALL_DATE, @MERK, @ATTRIBUTE_TIPE, @GSIZE)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (view_pelanggan3.IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", view_pelanggan3.IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
					if (view_pelanggan3.ACC_ID != null) { command.Parameters.AddWithValue("@ACC_ID", view_pelanggan3.ACC_ID); } else { command.Parameters.AddWithValue("@ACC_ID", DBNull.Value); } 
					if (view_pelanggan3.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", view_pelanggan3.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
					if (view_pelanggan3.NOREF != null) { command.Parameters.AddWithValue("@NOREF", view_pelanggan3.NOREF); } else { command.Parameters.AddWithValue("@NOREF", DBNull.Value); } 
					if (view_pelanggan3.NAMA != null) { command.Parameters.AddWithValue("@NAMA", view_pelanggan3.NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
					if (view_pelanggan3.ALAMAT != null) { command.Parameters.AddWithValue("@ALAMAT", view_pelanggan3.ALAMAT); } else { command.Parameters.AddWithValue("@ALAMAT", DBNull.Value); } 
					if (view_pelanggan3.JENIS_CUSTOMER != null) { command.Parameters.AddWithValue("@JENIS_CUSTOMER", view_pelanggan3.JENIS_CUSTOMER); } else { command.Parameters.AddWithValue("@JENIS_CUSTOMER", DBNull.Value); } 
					if (view_pelanggan3.JENIS_TARIF != null) { command.Parameters.AddWithValue("@JENIS_TARIF", view_pelanggan3.JENIS_TARIF); } else { command.Parameters.AddWithValue("@JENIS_TARIF", DBNull.Value); } 
					if (view_pelanggan3.CONTACT_PERSON != null) { command.Parameters.AddWithValue("@CONTACT_PERSON", view_pelanggan3.CONTACT_PERSON); } else { command.Parameters.AddWithValue("@CONTACT_PERSON", DBNull.Value); } 
					if (view_pelanggan3.NO_TELP != null) { command.Parameters.AddWithValue("@NO_TELP", view_pelanggan3.NO_TELP); } else { command.Parameters.AddWithValue("@NO_TELP", DBNull.Value); } 
					if (view_pelanggan3.STATUS != null) { command.Parameters.AddWithValue("@STATUS", view_pelanggan3.STATUS); } else { command.Parameters.AddWithValue("@STATUS", DBNull.Value); } 
					if (view_pelanggan3.NO_KONTRAK != null) { command.Parameters.AddWithValue("@NO_KONTRAK", view_pelanggan3.NO_KONTRAK); } else { command.Parameters.AddWithValue("@NO_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.TGL_BERLAKU != null) { command.Parameters.AddWithValue("@TGL_BERLAKU", view_pelanggan3.TGL_BERLAKU); } else { command.Parameters.AddWithValue("@TGL_BERLAKU", DBNull.Value); } 
					if (view_pelanggan3.TGL_BERAKHIR != null) { command.Parameters.AddWithValue("@TGL_BERAKHIR", view_pelanggan3.TGL_BERAKHIR); } else { command.Parameters.AddWithValue("@TGL_BERAKHIR", DBNull.Value); } 
					if (view_pelanggan3.JENIS_KONTRAK != null) { command.Parameters.AddWithValue("@JENIS_KONTRAK", view_pelanggan3.JENIS_KONTRAK); } else { command.Parameters.AddWithValue("@JENIS_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.MIN_KONTRAK != null) { command.Parameters.AddWithValue("@MIN_KONTRAK", view_pelanggan3.MIN_KONTRAK); } else { command.Parameters.AddWithValue("@MIN_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.MAX_KONTRAK != null) { command.Parameters.AddWithValue("@MAX_KONTRAK", view_pelanggan3.MAX_KONTRAK); } else { command.Parameters.AddWithValue("@MAX_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.HARIAN_MIN_KONTRAK != null) { command.Parameters.AddWithValue("@HARIAN_MIN_KONTRAK", view_pelanggan3.HARIAN_MIN_KONTRAK); } else { command.Parameters.AddWithValue("@HARIAN_MIN_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.BULANAN_MIN_KONTRAK != null) { command.Parameters.AddWithValue("@BULANAN_MIN_KONTRAK", view_pelanggan3.BULANAN_MIN_KONTRAK); } else { command.Parameters.AddWithValue("@BULANAN_MIN_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.HARIAN_MAX_KONTRAK != null) { command.Parameters.AddWithValue("@HARIAN_MAX_KONTRAK", view_pelanggan3.HARIAN_MAX_KONTRAK); } else { command.Parameters.AddWithValue("@HARIAN_MAX_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.BULANAN_MAX_KONTRAK != null) { command.Parameters.AddWithValue("@BULANAN_MAX_KONTRAK", view_pelanggan3.BULANAN_MAX_KONTRAK); } else { command.Parameters.AddWithValue("@BULANAN_MAX_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.TEKANAN != null) { command.Parameters.AddWithValue("@TEKANAN", view_pelanggan3.TEKANAN); } else { command.Parameters.AddWithValue("@TEKANAN", DBNull.Value); } 
					if (view_pelanggan3.SEKTOR != null) { command.Parameters.AddWithValue("@SEKTOR", view_pelanggan3.SEKTOR); } else { command.Parameters.AddWithValue("@SEKTOR", DBNull.Value); } 
					if (view_pelanggan3.SEKTOR_INDUSTRI != null) { command.Parameters.AddWithValue("@SEKTOR_INDUSTRI", view_pelanggan3.SEKTOR_INDUSTRI); } else { command.Parameters.AddWithValue("@SEKTOR_INDUSTRI", DBNull.Value); } 
					if (view_pelanggan3.TGL_BERLANGGANAN != null) { command.Parameters.AddWithValue("@TGL_BERLANGGANAN", view_pelanggan3.TGL_BERLANGGANAN); } else { command.Parameters.AddWithValue("@TGL_BERLANGGANAN", DBNull.Value); } 
					if (view_pelanggan3.TGL_BERHENTI_BERLANGGANAN != null) { command.Parameters.AddWithValue("@TGL_BERHENTI_BERLANGGANAN", view_pelanggan3.TGL_BERHENTI_BERLANGGANAN); } else { command.Parameters.AddWithValue("@TGL_BERHENTI_BERLANGGANAN", DBNull.Value); } 
					if (view_pelanggan3.JNS_KALORI != null) { command.Parameters.AddWithValue("@JNS_KALORI", view_pelanggan3.JNS_KALORI); } else { command.Parameters.AddWithValue("@JNS_KALORI", DBNull.Value); } 
					if (view_pelanggan3.JML_HARI_KERJA_MINGGU != null) { command.Parameters.AddWithValue("@JML_HARI_KERJA_MINGGU", view_pelanggan3.JML_HARI_KERJA_MINGGU); } else { command.Parameters.AddWithValue("@JML_HARI_KERJA_MINGGU", DBNull.Value); } 
					if (view_pelanggan3.JML_JAM_KERJA_HARI != null) { command.Parameters.AddWithValue("@JML_JAM_KERJA_HARI", view_pelanggan3.JML_JAM_KERJA_HARI); } else { command.Parameters.AddWithValue("@JML_JAM_KERJA_HARI", DBNull.Value); } 
					if (view_pelanggan3.KODE_HARGA != null) { command.Parameters.AddWithValue("@KODE_HARGA", view_pelanggan3.KODE_HARGA); } else { command.Parameters.AddWithValue("@KODE_HARGA", DBNull.Value); } 
					if (view_pelanggan3.LONGITUDE != null) { command.Parameters.AddWithValue("@LONGITUDE", view_pelanggan3.LONGITUDE); } else { command.Parameters.AddWithValue("@LONGITUDE", DBNull.Value); } 
					if (view_pelanggan3.LATITUDE != null) { command.Parameters.AddWithValue("@LATITUDE", view_pelanggan3.LATITUDE); } else { command.Parameters.AddWithValue("@LATITUDE", DBNull.Value); } 
					if (view_pelanggan3.SIPGAS_LAST_FEED != null) { command.Parameters.AddWithValue("@SIPGAS_LAST_FEED", view_pelanggan3.SIPGAS_LAST_FEED); } else { command.Parameters.AddWithValue("@SIPGAS_LAST_FEED", DBNull.Value); } 
					if (view_pelanggan3.SERIAL_NUM != null) { command.Parameters.AddWithValue("@SERIAL_NUM", view_pelanggan3.SERIAL_NUM); } else { command.Parameters.AddWithValue("@SERIAL_NUM", DBNull.Value); } 
					if (view_pelanggan3.ASSET_NUM != null) { command.Parameters.AddWithValue("@ASSET_NUM", view_pelanggan3.ASSET_NUM); } else { command.Parameters.AddWithValue("@ASSET_NUM", DBNull.Value); } 
					if (view_pelanggan3.INSTALL_DATE != null) { command.Parameters.AddWithValue("@INSTALL_DATE", view_pelanggan3.INSTALL_DATE); } else { command.Parameters.AddWithValue("@INSTALL_DATE", DBNull.Value); } 
					if (view_pelanggan3.MERK != null) { command.Parameters.AddWithValue("@MERK", view_pelanggan3.MERK); } else { command.Parameters.AddWithValue("@MERK", DBNull.Value); } 
					if (view_pelanggan3.ATTRIBUTE_TIPE != null) { command.Parameters.AddWithValue("@ATTRIBUTE_TIPE", view_pelanggan3.ATTRIBUTE_TIPE); } else { command.Parameters.AddWithValue("@ATTRIBUTE_TIPE", DBNull.Value); } 
					if (view_pelanggan3.GSIZE != null) { command.Parameters.AddWithValue("@GSIZE", view_pelanggan3.GSIZE); } else { command.Parameters.AddWithValue("@GSIZE", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<VIEW_PELANGGAN3> view_pelanggan3)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(VIEW_PELANGGAN3 item in view_pelanggan3)
					{
						SqlCommand command = new SqlCommand("INSERT INTO VIEW_PELANGGAN3 ([IDREFPELANGGAN], [ACC_ID], [ID_UNIT_USAHA], [NOREF], [NAMA], [ALAMAT], [JENIS_CUSTOMER], [JENIS_TARIF], [CONTACT_PERSON], [NO_TELP], [STATUS], [NO_KONTRAK], [TGL_BERLAKU], [TGL_BERAKHIR], [JENIS_KONTRAK], [MIN_KONTRAK], [MAX_KONTRAK], [HARIAN_MIN_KONTRAK], [BULANAN_MIN_KONTRAK], [HARIAN_MAX_KONTRAK], [BULANAN_MAX_KONTRAK], [TEKANAN], [SEKTOR], [SEKTOR_INDUSTRI], [TGL_BERLANGGANAN], [TGL_BERHENTI_BERLANGGANAN], [JNS_KALORI], [JML_HARI_KERJA_MINGGU], [JML_JAM_KERJA_HARI], [KODE_HARGA], [LONGITUDE], [LATITUDE], [SIPGAS_LAST_FEED], [SERIAL_NUM], [ASSET_NUM], [INSTALL_DATE], [MERK], [ATTRIBUTE_TIPE], [GSIZE]) VALUES(@IDREFPELANGGAN, @ACC_ID, @ID_UNIT_USAHA, @NOREF, @NAMA, @ALAMAT, @JENIS_CUSTOMER, @JENIS_TARIF, @CONTACT_PERSON, @NO_TELP, @STATUS, @NO_KONTRAK, @TGL_BERLAKU, @TGL_BERAKHIR, @JENIS_KONTRAK, @MIN_KONTRAK, @MAX_KONTRAK, @HARIAN_MIN_KONTRAK, @BULANAN_MIN_KONTRAK, @HARIAN_MAX_KONTRAK, @BULANAN_MAX_KONTRAK, @TEKANAN, @SEKTOR, @SEKTOR_INDUSTRI, @TGL_BERLANGGANAN, @TGL_BERHENTI_BERLANGGANAN, @JNS_KALORI, @JML_HARI_KERJA_MINGGU, @JML_JAM_KERJA_HARI, @KODE_HARGA, @LONGITUDE, @LATITUDE, @SIPGAS_LAST_FEED, @SERIAL_NUM, @ASSET_NUM, @INSTALL_DATE, @MERK, @ATTRIBUTE_TIPE, @GSIZE)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (view_pelanggan3[pos].IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", view_pelanggan3[pos].IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
						if (view_pelanggan3[pos].ACC_ID != null) { command.Parameters.AddWithValue("@ACC_ID", view_pelanggan3[pos].ACC_ID); } else { command.Parameters.AddWithValue("@ACC_ID", DBNull.Value); } 
						if (view_pelanggan3[pos].ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", view_pelanggan3[pos].ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
						if (view_pelanggan3[pos].NOREF != null) { command.Parameters.AddWithValue("@NOREF", view_pelanggan3[pos].NOREF); } else { command.Parameters.AddWithValue("@NOREF", DBNull.Value); } 
						if (view_pelanggan3[pos].NAMA != null) { command.Parameters.AddWithValue("@NAMA", view_pelanggan3[pos].NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
						if (view_pelanggan3[pos].ALAMAT != null) { command.Parameters.AddWithValue("@ALAMAT", view_pelanggan3[pos].ALAMAT); } else { command.Parameters.AddWithValue("@ALAMAT", DBNull.Value); } 
						if (view_pelanggan3[pos].JENIS_CUSTOMER != null) { command.Parameters.AddWithValue("@JENIS_CUSTOMER", view_pelanggan3[pos].JENIS_CUSTOMER); } else { command.Parameters.AddWithValue("@JENIS_CUSTOMER", DBNull.Value); } 
						if (view_pelanggan3[pos].JENIS_TARIF != null) { command.Parameters.AddWithValue("@JENIS_TARIF", view_pelanggan3[pos].JENIS_TARIF); } else { command.Parameters.AddWithValue("@JENIS_TARIF", DBNull.Value); } 
						if (view_pelanggan3[pos].CONTACT_PERSON != null) { command.Parameters.AddWithValue("@CONTACT_PERSON", view_pelanggan3[pos].CONTACT_PERSON); } else { command.Parameters.AddWithValue("@CONTACT_PERSON", DBNull.Value); } 
						if (view_pelanggan3[pos].NO_TELP != null) { command.Parameters.AddWithValue("@NO_TELP", view_pelanggan3[pos].NO_TELP); } else { command.Parameters.AddWithValue("@NO_TELP", DBNull.Value); } 
						if (view_pelanggan3[pos].STATUS != null) { command.Parameters.AddWithValue("@STATUS", view_pelanggan3[pos].STATUS); } else { command.Parameters.AddWithValue("@STATUS", DBNull.Value); } 
						if (view_pelanggan3[pos].NO_KONTRAK != null) { command.Parameters.AddWithValue("@NO_KONTRAK", view_pelanggan3[pos].NO_KONTRAK); } else { command.Parameters.AddWithValue("@NO_KONTRAK", DBNull.Value); } 
						if (view_pelanggan3[pos].TGL_BERLAKU != null) { command.Parameters.AddWithValue("@TGL_BERLAKU", view_pelanggan3[pos].TGL_BERLAKU); } else { command.Parameters.AddWithValue("@TGL_BERLAKU", DBNull.Value); } 
						if (view_pelanggan3[pos].TGL_BERAKHIR != null) { command.Parameters.AddWithValue("@TGL_BERAKHIR", view_pelanggan3[pos].TGL_BERAKHIR); } else { command.Parameters.AddWithValue("@TGL_BERAKHIR", DBNull.Value); } 
						if (view_pelanggan3[pos].JENIS_KONTRAK != null) { command.Parameters.AddWithValue("@JENIS_KONTRAK", view_pelanggan3[pos].JENIS_KONTRAK); } else { command.Parameters.AddWithValue("@JENIS_KONTRAK", DBNull.Value); } 
						if (view_pelanggan3[pos].MIN_KONTRAK != null) { command.Parameters.AddWithValue("@MIN_KONTRAK", view_pelanggan3[pos].MIN_KONTRAK); } else { command.Parameters.AddWithValue("@MIN_KONTRAK", DBNull.Value); } 
						if (view_pelanggan3[pos].MAX_KONTRAK != null) { command.Parameters.AddWithValue("@MAX_KONTRAK", view_pelanggan3[pos].MAX_KONTRAK); } else { command.Parameters.AddWithValue("@MAX_KONTRAK", DBNull.Value); } 
						if (view_pelanggan3[pos].HARIAN_MIN_KONTRAK != null) { command.Parameters.AddWithValue("@HARIAN_MIN_KONTRAK", view_pelanggan3[pos].HARIAN_MIN_KONTRAK); } else { command.Parameters.AddWithValue("@HARIAN_MIN_KONTRAK", DBNull.Value); } 
						if (view_pelanggan3[pos].BULANAN_MIN_KONTRAK != null) { command.Parameters.AddWithValue("@BULANAN_MIN_KONTRAK", view_pelanggan3[pos].BULANAN_MIN_KONTRAK); } else { command.Parameters.AddWithValue("@BULANAN_MIN_KONTRAK", DBNull.Value); } 
						if (view_pelanggan3[pos].HARIAN_MAX_KONTRAK != null) { command.Parameters.AddWithValue("@HARIAN_MAX_KONTRAK", view_pelanggan3[pos].HARIAN_MAX_KONTRAK); } else { command.Parameters.AddWithValue("@HARIAN_MAX_KONTRAK", DBNull.Value); } 
						if (view_pelanggan3[pos].BULANAN_MAX_KONTRAK != null) { command.Parameters.AddWithValue("@BULANAN_MAX_KONTRAK", view_pelanggan3[pos].BULANAN_MAX_KONTRAK); } else { command.Parameters.AddWithValue("@BULANAN_MAX_KONTRAK", DBNull.Value); } 
						if (view_pelanggan3[pos].TEKANAN != null) { command.Parameters.AddWithValue("@TEKANAN", view_pelanggan3[pos].TEKANAN); } else { command.Parameters.AddWithValue("@TEKANAN", DBNull.Value); } 
						if (view_pelanggan3[pos].SEKTOR != null) { command.Parameters.AddWithValue("@SEKTOR", view_pelanggan3[pos].SEKTOR); } else { command.Parameters.AddWithValue("@SEKTOR", DBNull.Value); } 
						if (view_pelanggan3[pos].SEKTOR_INDUSTRI != null) { command.Parameters.AddWithValue("@SEKTOR_INDUSTRI", view_pelanggan3[pos].SEKTOR_INDUSTRI); } else { command.Parameters.AddWithValue("@SEKTOR_INDUSTRI", DBNull.Value); } 
						if (view_pelanggan3[pos].TGL_BERLANGGANAN != null) { command.Parameters.AddWithValue("@TGL_BERLANGGANAN", view_pelanggan3[pos].TGL_BERLANGGANAN); } else { command.Parameters.AddWithValue("@TGL_BERLANGGANAN", DBNull.Value); } 
						if (view_pelanggan3[pos].TGL_BERHENTI_BERLANGGANAN != null) { command.Parameters.AddWithValue("@TGL_BERHENTI_BERLANGGANAN", view_pelanggan3[pos].TGL_BERHENTI_BERLANGGANAN); } else { command.Parameters.AddWithValue("@TGL_BERHENTI_BERLANGGANAN", DBNull.Value); } 
						if (view_pelanggan3[pos].JNS_KALORI != null) { command.Parameters.AddWithValue("@JNS_KALORI", view_pelanggan3[pos].JNS_KALORI); } else { command.Parameters.AddWithValue("@JNS_KALORI", DBNull.Value); } 
						if (view_pelanggan3[pos].JML_HARI_KERJA_MINGGU != null) { command.Parameters.AddWithValue("@JML_HARI_KERJA_MINGGU", view_pelanggan3[pos].JML_HARI_KERJA_MINGGU); } else { command.Parameters.AddWithValue("@JML_HARI_KERJA_MINGGU", DBNull.Value); } 
						if (view_pelanggan3[pos].JML_JAM_KERJA_HARI != null) { command.Parameters.AddWithValue("@JML_JAM_KERJA_HARI", view_pelanggan3[pos].JML_JAM_KERJA_HARI); } else { command.Parameters.AddWithValue("@JML_JAM_KERJA_HARI", DBNull.Value); } 
						if (view_pelanggan3[pos].KODE_HARGA != null) { command.Parameters.AddWithValue("@KODE_HARGA", view_pelanggan3[pos].KODE_HARGA); } else { command.Parameters.AddWithValue("@KODE_HARGA", DBNull.Value); } 
						if (view_pelanggan3[pos].LONGITUDE != null) { command.Parameters.AddWithValue("@LONGITUDE", view_pelanggan3[pos].LONGITUDE); } else { command.Parameters.AddWithValue("@LONGITUDE", DBNull.Value); } 
						if (view_pelanggan3[pos].LATITUDE != null) { command.Parameters.AddWithValue("@LATITUDE", view_pelanggan3[pos].LATITUDE); } else { command.Parameters.AddWithValue("@LATITUDE", DBNull.Value); } 
						if (view_pelanggan3[pos].SIPGAS_LAST_FEED != null) { command.Parameters.AddWithValue("@SIPGAS_LAST_FEED", view_pelanggan3[pos].SIPGAS_LAST_FEED); } else { command.Parameters.AddWithValue("@SIPGAS_LAST_FEED", DBNull.Value); } 
						if (view_pelanggan3[pos].SERIAL_NUM != null) { command.Parameters.AddWithValue("@SERIAL_NUM", view_pelanggan3[pos].SERIAL_NUM); } else { command.Parameters.AddWithValue("@SERIAL_NUM", DBNull.Value); } 
						if (view_pelanggan3[pos].ASSET_NUM != null) { command.Parameters.AddWithValue("@ASSET_NUM", view_pelanggan3[pos].ASSET_NUM); } else { command.Parameters.AddWithValue("@ASSET_NUM", DBNull.Value); } 
						if (view_pelanggan3[pos].INSTALL_DATE != null) { command.Parameters.AddWithValue("@INSTALL_DATE", view_pelanggan3[pos].INSTALL_DATE); } else { command.Parameters.AddWithValue("@INSTALL_DATE", DBNull.Value); } 
						if (view_pelanggan3[pos].MERK != null) { command.Parameters.AddWithValue("@MERK", view_pelanggan3[pos].MERK); } else { command.Parameters.AddWithValue("@MERK", DBNull.Value); } 
						if (view_pelanggan3[pos].ATTRIBUTE_TIPE != null) { command.Parameters.AddWithValue("@ATTRIBUTE_TIPE", view_pelanggan3[pos].ATTRIBUTE_TIPE); } else { command.Parameters.AddWithValue("@ATTRIBUTE_TIPE", DBNull.Value); } 
						if (view_pelanggan3[pos].GSIZE != null) { command.Parameters.AddWithValue("@GSIZE", view_pelanggan3[pos].GSIZE); } else { command.Parameters.AddWithValue("@GSIZE", DBNull.Value); } 
						command.ExecuteNonQuery();
						pos = pos + 1;
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Update(VIEW_PELANGGAN3 view_pelanggan3)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE VIEW_PELANGGAN3 SET ACC_ID = @ACC_ID, ID_UNIT_USAHA = @ID_UNIT_USAHA, NOREF = @NOREF, NAMA = @NAMA, ALAMAT = @ALAMAT, JENIS_CUSTOMER = @JENIS_CUSTOMER, JENIS_TARIF = @JENIS_TARIF, CONTACT_PERSON = @CONTACT_PERSON, NO_TELP = @NO_TELP, STATUS = @STATUS, NO_KONTRAK = @NO_KONTRAK, TGL_BERLAKU = @TGL_BERLAKU, TGL_BERAKHIR = @TGL_BERAKHIR, JENIS_KONTRAK = @JENIS_KONTRAK, MIN_KONTRAK = @MIN_KONTRAK, MAX_KONTRAK = @MAX_KONTRAK, HARIAN_MIN_KONTRAK = @HARIAN_MIN_KONTRAK, BULANAN_MIN_KONTRAK = @BULANAN_MIN_KONTRAK, HARIAN_MAX_KONTRAK = @HARIAN_MAX_KONTRAK, BULANAN_MAX_KONTRAK = @BULANAN_MAX_KONTRAK, TEKANAN = @TEKANAN, SEKTOR = @SEKTOR, SEKTOR_INDUSTRI = @SEKTOR_INDUSTRI, TGL_BERLANGGANAN = @TGL_BERLANGGANAN, TGL_BERHENTI_BERLANGGANAN = @TGL_BERHENTI_BERLANGGANAN, JNS_KALORI = @JNS_KALORI, JML_HARI_KERJA_MINGGU = @JML_HARI_KERJA_MINGGU, JML_JAM_KERJA_HARI = @JML_JAM_KERJA_HARI, KODE_HARGA = @KODE_HARGA, LONGITUDE = @LONGITUDE, LATITUDE = @LATITUDE, SIPGAS_LAST_FEED = @SIPGAS_LAST_FEED, SERIAL_NUM = @SERIAL_NUM, ASSET_NUM = @ASSET_NUM, INSTALL_DATE = @INSTALL_DATE, MERK = @MERK, ATTRIBUTE_TIPE = @ATTRIBUTE_TIPE, GSIZE = @GSIZE WHERE IDREFPELANGGAN = @IDREFPELANGGAN", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (view_pelanggan3.IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", view_pelanggan3.IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
					if (view_pelanggan3.ACC_ID != null) { command.Parameters.AddWithValue("@ACC_ID", view_pelanggan3.ACC_ID); } else { command.Parameters.AddWithValue("@ACC_ID", DBNull.Value); } 
					if (view_pelanggan3.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", view_pelanggan3.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
					if (view_pelanggan3.NOREF != null) { command.Parameters.AddWithValue("@NOREF", view_pelanggan3.NOREF); } else { command.Parameters.AddWithValue("@NOREF", DBNull.Value); } 
					if (view_pelanggan3.NAMA != null) { command.Parameters.AddWithValue("@NAMA", view_pelanggan3.NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
					if (view_pelanggan3.ALAMAT != null) { command.Parameters.AddWithValue("@ALAMAT", view_pelanggan3.ALAMAT); } else { command.Parameters.AddWithValue("@ALAMAT", DBNull.Value); } 
					if (view_pelanggan3.JENIS_CUSTOMER != null) { command.Parameters.AddWithValue("@JENIS_CUSTOMER", view_pelanggan3.JENIS_CUSTOMER); } else { command.Parameters.AddWithValue("@JENIS_CUSTOMER", DBNull.Value); } 
					if (view_pelanggan3.JENIS_TARIF != null) { command.Parameters.AddWithValue("@JENIS_TARIF", view_pelanggan3.JENIS_TARIF); } else { command.Parameters.AddWithValue("@JENIS_TARIF", DBNull.Value); } 
					if (view_pelanggan3.CONTACT_PERSON != null) { command.Parameters.AddWithValue("@CONTACT_PERSON", view_pelanggan3.CONTACT_PERSON); } else { command.Parameters.AddWithValue("@CONTACT_PERSON", DBNull.Value); } 
					if (view_pelanggan3.NO_TELP != null) { command.Parameters.AddWithValue("@NO_TELP", view_pelanggan3.NO_TELP); } else { command.Parameters.AddWithValue("@NO_TELP", DBNull.Value); } 
					if (view_pelanggan3.STATUS != null) { command.Parameters.AddWithValue("@STATUS", view_pelanggan3.STATUS); } else { command.Parameters.AddWithValue("@STATUS", DBNull.Value); } 
					if (view_pelanggan3.NO_KONTRAK != null) { command.Parameters.AddWithValue("@NO_KONTRAK", view_pelanggan3.NO_KONTRAK); } else { command.Parameters.AddWithValue("@NO_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.TGL_BERLAKU != null) { command.Parameters.AddWithValue("@TGL_BERLAKU", view_pelanggan3.TGL_BERLAKU); } else { command.Parameters.AddWithValue("@TGL_BERLAKU", DBNull.Value); } 
					if (view_pelanggan3.TGL_BERAKHIR != null) { command.Parameters.AddWithValue("@TGL_BERAKHIR", view_pelanggan3.TGL_BERAKHIR); } else { command.Parameters.AddWithValue("@TGL_BERAKHIR", DBNull.Value); } 
					if (view_pelanggan3.JENIS_KONTRAK != null) { command.Parameters.AddWithValue("@JENIS_KONTRAK", view_pelanggan3.JENIS_KONTRAK); } else { command.Parameters.AddWithValue("@JENIS_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.MIN_KONTRAK != null) { command.Parameters.AddWithValue("@MIN_KONTRAK", view_pelanggan3.MIN_KONTRAK); } else { command.Parameters.AddWithValue("@MIN_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.MAX_KONTRAK != null) { command.Parameters.AddWithValue("@MAX_KONTRAK", view_pelanggan3.MAX_KONTRAK); } else { command.Parameters.AddWithValue("@MAX_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.HARIAN_MIN_KONTRAK != null) { command.Parameters.AddWithValue("@HARIAN_MIN_KONTRAK", view_pelanggan3.HARIAN_MIN_KONTRAK); } else { command.Parameters.AddWithValue("@HARIAN_MIN_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.BULANAN_MIN_KONTRAK != null) { command.Parameters.AddWithValue("@BULANAN_MIN_KONTRAK", view_pelanggan3.BULANAN_MIN_KONTRAK); } else { command.Parameters.AddWithValue("@BULANAN_MIN_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.HARIAN_MAX_KONTRAK != null) { command.Parameters.AddWithValue("@HARIAN_MAX_KONTRAK", view_pelanggan3.HARIAN_MAX_KONTRAK); } else { command.Parameters.AddWithValue("@HARIAN_MAX_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.BULANAN_MAX_KONTRAK != null) { command.Parameters.AddWithValue("@BULANAN_MAX_KONTRAK", view_pelanggan3.BULANAN_MAX_KONTRAK); } else { command.Parameters.AddWithValue("@BULANAN_MAX_KONTRAK", DBNull.Value); } 
					if (view_pelanggan3.TEKANAN != null) { command.Parameters.AddWithValue("@TEKANAN", view_pelanggan3.TEKANAN); } else { command.Parameters.AddWithValue("@TEKANAN", DBNull.Value); } 
					if (view_pelanggan3.SEKTOR != null) { command.Parameters.AddWithValue("@SEKTOR", view_pelanggan3.SEKTOR); } else { command.Parameters.AddWithValue("@SEKTOR", DBNull.Value); } 
					if (view_pelanggan3.SEKTOR_INDUSTRI != null) { command.Parameters.AddWithValue("@SEKTOR_INDUSTRI", view_pelanggan3.SEKTOR_INDUSTRI); } else { command.Parameters.AddWithValue("@SEKTOR_INDUSTRI", DBNull.Value); } 
					if (view_pelanggan3.TGL_BERLANGGANAN != null) { command.Parameters.AddWithValue("@TGL_BERLANGGANAN", view_pelanggan3.TGL_BERLANGGANAN); } else { command.Parameters.AddWithValue("@TGL_BERLANGGANAN", DBNull.Value); } 
					if (view_pelanggan3.TGL_BERHENTI_BERLANGGANAN != null) { command.Parameters.AddWithValue("@TGL_BERHENTI_BERLANGGANAN", view_pelanggan3.TGL_BERHENTI_BERLANGGANAN); } else { command.Parameters.AddWithValue("@TGL_BERHENTI_BERLANGGANAN", DBNull.Value); } 
					if (view_pelanggan3.JNS_KALORI != null) { command.Parameters.AddWithValue("@JNS_KALORI", view_pelanggan3.JNS_KALORI); } else { command.Parameters.AddWithValue("@JNS_KALORI", DBNull.Value); } 
					if (view_pelanggan3.JML_HARI_KERJA_MINGGU != null) { command.Parameters.AddWithValue("@JML_HARI_KERJA_MINGGU", view_pelanggan3.JML_HARI_KERJA_MINGGU); } else { command.Parameters.AddWithValue("@JML_HARI_KERJA_MINGGU", DBNull.Value); } 
					if (view_pelanggan3.JML_JAM_KERJA_HARI != null) { command.Parameters.AddWithValue("@JML_JAM_KERJA_HARI", view_pelanggan3.JML_JAM_KERJA_HARI); } else { command.Parameters.AddWithValue("@JML_JAM_KERJA_HARI", DBNull.Value); } 
					if (view_pelanggan3.KODE_HARGA != null) { command.Parameters.AddWithValue("@KODE_HARGA", view_pelanggan3.KODE_HARGA); } else { command.Parameters.AddWithValue("@KODE_HARGA", DBNull.Value); } 
					if (view_pelanggan3.LONGITUDE != null) { command.Parameters.AddWithValue("@LONGITUDE", view_pelanggan3.LONGITUDE); } else { command.Parameters.AddWithValue("@LONGITUDE", DBNull.Value); } 
					if (view_pelanggan3.LATITUDE != null) { command.Parameters.AddWithValue("@LATITUDE", view_pelanggan3.LATITUDE); } else { command.Parameters.AddWithValue("@LATITUDE", DBNull.Value); } 
					if (view_pelanggan3.SIPGAS_LAST_FEED != null) { command.Parameters.AddWithValue("@SIPGAS_LAST_FEED", view_pelanggan3.SIPGAS_LAST_FEED); } else { command.Parameters.AddWithValue("@SIPGAS_LAST_FEED", DBNull.Value); } 
					if (view_pelanggan3.SERIAL_NUM != null) { command.Parameters.AddWithValue("@SERIAL_NUM", view_pelanggan3.SERIAL_NUM); } else { command.Parameters.AddWithValue("@SERIAL_NUM", DBNull.Value); } 
					if (view_pelanggan3.ASSET_NUM != null) { command.Parameters.AddWithValue("@ASSET_NUM", view_pelanggan3.ASSET_NUM); } else { command.Parameters.AddWithValue("@ASSET_NUM", DBNull.Value); } 
					if (view_pelanggan3.INSTALL_DATE != null) { command.Parameters.AddWithValue("@INSTALL_DATE", view_pelanggan3.INSTALL_DATE); } else { command.Parameters.AddWithValue("@INSTALL_DATE", DBNull.Value); } 
					if (view_pelanggan3.MERK != null) { command.Parameters.AddWithValue("@MERK", view_pelanggan3.MERK); } else { command.Parameters.AddWithValue("@MERK", DBNull.Value); } 
					if (view_pelanggan3.ATTRIBUTE_TIPE != null) { command.Parameters.AddWithValue("@ATTRIBUTE_TIPE", view_pelanggan3.ATTRIBUTE_TIPE); } else { command.Parameters.AddWithValue("@ATTRIBUTE_TIPE", DBNull.Value); } 
					if (view_pelanggan3.GSIZE != null) { command.Parameters.AddWithValue("@GSIZE", view_pelanggan3.GSIZE); } else { command.Parameters.AddWithValue("@GSIZE", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<VIEW_PELANGGAN3> view_pelanggan3s)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(VIEW_PELANGGAN3 item in view_pelanggan3s)
					{
						SqlCommand command = new SqlCommand("UPDATE VIEW_PELANGGAN3 SET ACC_ID = @ACC_ID, ID_UNIT_USAHA = @ID_UNIT_USAHA, NOREF = @NOREF, NAMA = @NAMA, ALAMAT = @ALAMAT, JENIS_CUSTOMER = @JENIS_CUSTOMER, JENIS_TARIF = @JENIS_TARIF, CONTACT_PERSON = @CONTACT_PERSON, NO_TELP = @NO_TELP, STATUS = @STATUS, NO_KONTRAK = @NO_KONTRAK, TGL_BERLAKU = @TGL_BERLAKU, TGL_BERAKHIR = @TGL_BERAKHIR, JENIS_KONTRAK = @JENIS_KONTRAK, MIN_KONTRAK = @MIN_KONTRAK, MAX_KONTRAK = @MAX_KONTRAK, HARIAN_MIN_KONTRAK = @HARIAN_MIN_KONTRAK, BULANAN_MIN_KONTRAK = @BULANAN_MIN_KONTRAK, HARIAN_MAX_KONTRAK = @HARIAN_MAX_KONTRAK, BULANAN_MAX_KONTRAK = @BULANAN_MAX_KONTRAK, TEKANAN = @TEKANAN, SEKTOR = @SEKTOR, SEKTOR_INDUSTRI = @SEKTOR_INDUSTRI, TGL_BERLANGGANAN = @TGL_BERLANGGANAN, TGL_BERHENTI_BERLANGGANAN = @TGL_BERHENTI_BERLANGGANAN, JNS_KALORI = @JNS_KALORI, JML_HARI_KERJA_MINGGU = @JML_HARI_KERJA_MINGGU, JML_JAM_KERJA_HARI = @JML_JAM_KERJA_HARI, KODE_HARGA = @KODE_HARGA, LONGITUDE = @LONGITUDE, LATITUDE = @LATITUDE, SIPGAS_LAST_FEED = @SIPGAS_LAST_FEED, SERIAL_NUM = @SERIAL_NUM, ASSET_NUM = @ASSET_NUM, INSTALL_DATE = @INSTALL_DATE, MERK = @MERK, ATTRIBUTE_TIPE = @ATTRIBUTE_TIPE, GSIZE = @GSIZE WHERE IDREFPELANGGAN = @IDREFPELANGGAN", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", item.IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
						if (item.ACC_ID != null) { command.Parameters.AddWithValue("@ACC_ID", item.ACC_ID); } else { command.Parameters.AddWithValue("@ACC_ID", DBNull.Value); } 
						if (item.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", item.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
						if (item.NOREF != null) { command.Parameters.AddWithValue("@NOREF", item.NOREF); } else { command.Parameters.AddWithValue("@NOREF", DBNull.Value); } 
						if (item.NAMA != null) { command.Parameters.AddWithValue("@NAMA", item.NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
						if (item.ALAMAT != null) { command.Parameters.AddWithValue("@ALAMAT", item.ALAMAT); } else { command.Parameters.AddWithValue("@ALAMAT", DBNull.Value); } 
						if (item.JENIS_CUSTOMER != null) { command.Parameters.AddWithValue("@JENIS_CUSTOMER", item.JENIS_CUSTOMER); } else { command.Parameters.AddWithValue("@JENIS_CUSTOMER", DBNull.Value); } 
						if (item.JENIS_TARIF != null) { command.Parameters.AddWithValue("@JENIS_TARIF", item.JENIS_TARIF); } else { command.Parameters.AddWithValue("@JENIS_TARIF", DBNull.Value); } 
						if (item.CONTACT_PERSON != null) { command.Parameters.AddWithValue("@CONTACT_PERSON", item.CONTACT_PERSON); } else { command.Parameters.AddWithValue("@CONTACT_PERSON", DBNull.Value); } 
						if (item.NO_TELP != null) { command.Parameters.AddWithValue("@NO_TELP", item.NO_TELP); } else { command.Parameters.AddWithValue("@NO_TELP", DBNull.Value); } 
						if (item.STATUS != null) { command.Parameters.AddWithValue("@STATUS", item.STATUS); } else { command.Parameters.AddWithValue("@STATUS", DBNull.Value); } 
						if (item.NO_KONTRAK != null) { command.Parameters.AddWithValue("@NO_KONTRAK", item.NO_KONTRAK); } else { command.Parameters.AddWithValue("@NO_KONTRAK", DBNull.Value); } 
						if (item.TGL_BERLAKU != null) { command.Parameters.AddWithValue("@TGL_BERLAKU", item.TGL_BERLAKU); } else { command.Parameters.AddWithValue("@TGL_BERLAKU", DBNull.Value); } 
						if (item.TGL_BERAKHIR != null) { command.Parameters.AddWithValue("@TGL_BERAKHIR", item.TGL_BERAKHIR); } else { command.Parameters.AddWithValue("@TGL_BERAKHIR", DBNull.Value); } 
						if (item.JENIS_KONTRAK != null) { command.Parameters.AddWithValue("@JENIS_KONTRAK", item.JENIS_KONTRAK); } else { command.Parameters.AddWithValue("@JENIS_KONTRAK", DBNull.Value); } 
						if (item.MIN_KONTRAK != null) { command.Parameters.AddWithValue("@MIN_KONTRAK", item.MIN_KONTRAK); } else { command.Parameters.AddWithValue("@MIN_KONTRAK", DBNull.Value); } 
						if (item.MAX_KONTRAK != null) { command.Parameters.AddWithValue("@MAX_KONTRAK", item.MAX_KONTRAK); } else { command.Parameters.AddWithValue("@MAX_KONTRAK", DBNull.Value); } 
						if (item.HARIAN_MIN_KONTRAK != null) { command.Parameters.AddWithValue("@HARIAN_MIN_KONTRAK", item.HARIAN_MIN_KONTRAK); } else { command.Parameters.AddWithValue("@HARIAN_MIN_KONTRAK", DBNull.Value); } 
						if (item.BULANAN_MIN_KONTRAK != null) { command.Parameters.AddWithValue("@BULANAN_MIN_KONTRAK", item.BULANAN_MIN_KONTRAK); } else { command.Parameters.AddWithValue("@BULANAN_MIN_KONTRAK", DBNull.Value); } 
						if (item.HARIAN_MAX_KONTRAK != null) { command.Parameters.AddWithValue("@HARIAN_MAX_KONTRAK", item.HARIAN_MAX_KONTRAK); } else { command.Parameters.AddWithValue("@HARIAN_MAX_KONTRAK", DBNull.Value); } 
						if (item.BULANAN_MAX_KONTRAK != null) { command.Parameters.AddWithValue("@BULANAN_MAX_KONTRAK", item.BULANAN_MAX_KONTRAK); } else { command.Parameters.AddWithValue("@BULANAN_MAX_KONTRAK", DBNull.Value); } 
						if (item.TEKANAN != null) { command.Parameters.AddWithValue("@TEKANAN", item.TEKANAN); } else { command.Parameters.AddWithValue("@TEKANAN", DBNull.Value); } 
						if (item.SEKTOR != null) { command.Parameters.AddWithValue("@SEKTOR", item.SEKTOR); } else { command.Parameters.AddWithValue("@SEKTOR", DBNull.Value); } 
						if (item.SEKTOR_INDUSTRI != null) { command.Parameters.AddWithValue("@SEKTOR_INDUSTRI", item.SEKTOR_INDUSTRI); } else { command.Parameters.AddWithValue("@SEKTOR_INDUSTRI", DBNull.Value); } 
						if (item.TGL_BERLANGGANAN != null) { command.Parameters.AddWithValue("@TGL_BERLANGGANAN", item.TGL_BERLANGGANAN); } else { command.Parameters.AddWithValue("@TGL_BERLANGGANAN", DBNull.Value); } 
						if (item.TGL_BERHENTI_BERLANGGANAN != null) { command.Parameters.AddWithValue("@TGL_BERHENTI_BERLANGGANAN", item.TGL_BERHENTI_BERLANGGANAN); } else { command.Parameters.AddWithValue("@TGL_BERHENTI_BERLANGGANAN", DBNull.Value); } 
						if (item.JNS_KALORI != null) { command.Parameters.AddWithValue("@JNS_KALORI", item.JNS_KALORI); } else { command.Parameters.AddWithValue("@JNS_KALORI", DBNull.Value); } 
						if (item.JML_HARI_KERJA_MINGGU != null) { command.Parameters.AddWithValue("@JML_HARI_KERJA_MINGGU", item.JML_HARI_KERJA_MINGGU); } else { command.Parameters.AddWithValue("@JML_HARI_KERJA_MINGGU", DBNull.Value); } 
						if (item.JML_JAM_KERJA_HARI != null) { command.Parameters.AddWithValue("@JML_JAM_KERJA_HARI", item.JML_JAM_KERJA_HARI); } else { command.Parameters.AddWithValue("@JML_JAM_KERJA_HARI", DBNull.Value); } 
						if (item.KODE_HARGA != null) { command.Parameters.AddWithValue("@KODE_HARGA", item.KODE_HARGA); } else { command.Parameters.AddWithValue("@KODE_HARGA", DBNull.Value); } 
						if (item.LONGITUDE != null) { command.Parameters.AddWithValue("@LONGITUDE", item.LONGITUDE); } else { command.Parameters.AddWithValue("@LONGITUDE", DBNull.Value); } 
						if (item.LATITUDE != null) { command.Parameters.AddWithValue("@LATITUDE", item.LATITUDE); } else { command.Parameters.AddWithValue("@LATITUDE", DBNull.Value); } 
						if (item.SIPGAS_LAST_FEED != null) { command.Parameters.AddWithValue("@SIPGAS_LAST_FEED", item.SIPGAS_LAST_FEED); } else { command.Parameters.AddWithValue("@SIPGAS_LAST_FEED", DBNull.Value); } 
						if (item.SERIAL_NUM != null) { command.Parameters.AddWithValue("@SERIAL_NUM", item.SERIAL_NUM); } else { command.Parameters.AddWithValue("@SERIAL_NUM", DBNull.Value); } 
						if (item.ASSET_NUM != null) { command.Parameters.AddWithValue("@ASSET_NUM", item.ASSET_NUM); } else { command.Parameters.AddWithValue("@ASSET_NUM", DBNull.Value); } 
						if (item.INSTALL_DATE != null) { command.Parameters.AddWithValue("@INSTALL_DATE", item.INSTALL_DATE); } else { command.Parameters.AddWithValue("@INSTALL_DATE", DBNull.Value); } 
						if (item.MERK != null) { command.Parameters.AddWithValue("@MERK", item.MERK); } else { command.Parameters.AddWithValue("@MERK", DBNull.Value); } 
						if (item.ATTRIBUTE_TIPE != null) { command.Parameters.AddWithValue("@ATTRIBUTE_TIPE", item.ATTRIBUTE_TIPE); } else { command.Parameters.AddWithValue("@ATTRIBUTE_TIPE", DBNull.Value); } 
						if (item.GSIZE != null) { command.Parameters.AddWithValue("@GSIZE", item.GSIZE); } else { command.Parameters.AddWithValue("@GSIZE", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(VIEW_PELANGGAN3 id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE VIEW_PELANGGAN3 WHERE IDREFPELANGGAN = @IDREFPELANGGAN", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id.IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", id.IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<VIEW_PELANGGAN3> GetData()
		{
			List<VIEW_PELANGGAN3> items = new List<VIEW_PELANGGAN3>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [IDREFPELANGGAN], [ACC_ID], [ID_UNIT_USAHA], [NOREF], [NAMA], [ALAMAT], [JENIS_CUSTOMER], [JENIS_TARIF], [CONTACT_PERSON], [NO_TELP], [STATUS], [NO_KONTRAK], [TGL_BERLAKU], [TGL_BERAKHIR], [JENIS_KONTRAK], [MIN_KONTRAK], [MAX_KONTRAK], [HARIAN_MIN_KONTRAK], [BULANAN_MIN_KONTRAK], [HARIAN_MAX_KONTRAK], [BULANAN_MAX_KONTRAK], [TEKANAN], [SEKTOR], [SEKTOR_INDUSTRI], [TGL_BERLANGGANAN], [TGL_BERHENTI_BERLANGGANAN], [JNS_KALORI], [JML_HARI_KERJA_MINGGU], [JML_JAM_KERJA_HARI], [KODE_HARGA], [LONGITUDE], [LATITUDE], [SIPGAS_LAST_FEED], [SERIAL_NUM], [ASSET_NUM], [INSTALL_DATE], [MERK], [ATTRIBUTE_TIPE], [GSIZE] FROM VIEW_PELANGGAN3", conn);
					SqlDataReader reader = command.ExecuteReader();
					VIEW_PELANGGAN3 item = new VIEW_PELANGGAN3();
					while(reader.Read())
					{
						item = new VIEW_PELANGGAN3();
						if (reader[0] != DBNull.Value) { item.IDREFPELANGGAN = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.ACC_ID = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.ID_UNIT_USAHA = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.NOREF = Convert.ToString(reader[3]); }
						if (reader[4] != DBNull.Value) { item.NAMA = Convert.ToString(reader[4]); }
						if (reader[5] != DBNull.Value) { item.ALAMAT = Convert.ToString(reader[5]); }
						if (reader[6] != DBNull.Value) { item.JENIS_CUSTOMER = Convert.ToString(reader[6]); }
						if (reader[7] != DBNull.Value) { item.JENIS_TARIF = Convert.ToString(reader[7]); }
						if (reader[8] != DBNull.Value) { item.CONTACT_PERSON = Convert.ToString(reader[8]); }
						if (reader[9] != DBNull.Value) { item.NO_TELP = Convert.ToString(reader[9]); }
						if (reader[10] != DBNull.Value) { item.STATUS = Convert.ToString(reader[10]); }
						if (reader[11] != DBNull.Value) { item.NO_KONTRAK = Convert.ToString(reader[11]); }
						if (reader[12] != DBNull.Value) { item.TGL_BERLAKU = Convert.ToDateTime(reader[12]); }
						if (reader[13] != DBNull.Value) { item.TGL_BERAKHIR = Convert.ToDateTime(reader[13]); }
						if (reader[14] != DBNull.Value) { item.JENIS_KONTRAK = Convert.ToString(reader[14]); }
						if (reader[15] != DBNull.Value) { item.MIN_KONTRAK = Convert.ToDouble(reader[15]); }
						if (reader[16] != DBNull.Value) { item.MAX_KONTRAK = Convert.ToDouble(reader[16]); }
						if (reader[17] != DBNull.Value) { item.HARIAN_MIN_KONTRAK = Convert.ToDouble(reader[17]); }
						if (reader[18] != DBNull.Value) { item.BULANAN_MIN_KONTRAK = Convert.ToDouble(reader[18]); }
						if (reader[19] != DBNull.Value) { item.HARIAN_MAX_KONTRAK = Convert.ToDouble(reader[19]); }
						if (reader[20] != DBNull.Value) { item.BULANAN_MAX_KONTRAK = Convert.ToDouble(reader[20]); }
						if (reader[21] != DBNull.Value) { item.TEKANAN = Convert.ToString(reader[21]); }
						if (reader[22] != DBNull.Value) { item.SEKTOR = Convert.ToString(reader[22]); }
						if (reader[23] != DBNull.Value) { item.SEKTOR_INDUSTRI = Convert.ToString(reader[23]); }
						if (reader[24] != DBNull.Value) { item.TGL_BERLANGGANAN = Convert.ToDateTime(reader[24]); }
						if (reader[25] != DBNull.Value) { item.TGL_BERHENTI_BERLANGGANAN = Convert.ToDateTime(reader[25]); }
						if (reader[26] != DBNull.Value) { item.JNS_KALORI = Convert.ToString(reader[26]); }
						if (reader[27] != DBNull.Value) { item.JML_HARI_KERJA_MINGGU = Convert.ToInt32(reader[27]); }
						if (reader[28] != DBNull.Value) { item.JML_JAM_KERJA_HARI = Convert.ToInt32(reader[28]); }
						if (reader[29] != DBNull.Value) { item.KODE_HARGA = Convert.ToString(reader[29]); }
						if (reader[30] != DBNull.Value) { item.LONGITUDE = Convert.ToDouble(reader[30]); }
						if (reader[31] != DBNull.Value) { item.LATITUDE = Convert.ToDouble(reader[31]); }
						if (reader[32] != DBNull.Value) { item.SIPGAS_LAST_FEED = Convert.ToDateTime(reader[32]); }
						if (reader[33] != DBNull.Value) { item.SERIAL_NUM = Convert.ToString(reader[33]); }
						if (reader[34] != DBNull.Value) { item.ASSET_NUM = Convert.ToString(reader[34]); }
						if (reader[35] != DBNull.Value) { item.INSTALL_DATE = Convert.ToDateTime(reader[35]); }
						if (reader[36] != DBNull.Value) { item.MERK = Convert.ToString(reader[36]); }
						if (reader[37] != DBNull.Value) { item.ATTRIBUTE_TIPE = Convert.ToString(reader[37]); }
						if (reader[38] != DBNull.Value) { item.GSIZE = Convert.ToString(reader[38]); }
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

		public List<VIEW_PELANGGAN3> GetDataByIDREFPELANGGAN(string IDREFPELANGGAN)
		{
			List<VIEW_PELANGGAN3> items = new List<VIEW_PELANGGAN3>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [IDREFPELANGGAN], [ACC_ID], [ID_UNIT_USAHA], [NOREF], [NAMA], [ALAMAT], [JENIS_CUSTOMER], [JENIS_TARIF], [CONTACT_PERSON], [NO_TELP], [STATUS], [NO_KONTRAK], [TGL_BERLAKU], [TGL_BERAKHIR], [JENIS_KONTRAK], [MIN_KONTRAK], [MAX_KONTRAK], [HARIAN_MIN_KONTRAK], [BULANAN_MIN_KONTRAK], [HARIAN_MAX_KONTRAK], [BULANAN_MAX_KONTRAK], [TEKANAN], [SEKTOR], [SEKTOR_INDUSTRI], [TGL_BERLANGGANAN], [TGL_BERHENTI_BERLANGGANAN], [JNS_KALORI], [JML_HARI_KERJA_MINGGU], [JML_JAM_KERJA_HARI], [KODE_HARGA], [LONGITUDE], [LATITUDE], [SIPGAS_LAST_FEED], [SERIAL_NUM], [ASSET_NUM], [INSTALL_DATE], [MERK], [ATTRIBUTE_TIPE], [GSIZE] FROM [192.168.104.37].[sipg].[dbo].VIEW_PELANGGAN3 WHERE IDREFPELANGGAN = @IDREFPELANGGAN", conn);
					command.Parameters.AddWithValue("@IDREFPELANGGAN", IDREFPELANGGAN);
					SqlDataReader reader = command.ExecuteReader();
					VIEW_PELANGGAN3 item = new VIEW_PELANGGAN3();
					while(reader.Read())
					{
						item = new VIEW_PELANGGAN3();
						if (reader[0] != DBNull.Value) { item.IDREFPELANGGAN = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.ACC_ID = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.ID_UNIT_USAHA = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.NOREF = Convert.ToString(reader[3]); }
						if (reader[4] != DBNull.Value) { item.NAMA = Convert.ToString(reader[4]); }
						if (reader[5] != DBNull.Value) { item.ALAMAT = Convert.ToString(reader[5]); }
						if (reader[6] != DBNull.Value) { item.JENIS_CUSTOMER = Convert.ToString(reader[6]); }
						if (reader[7] != DBNull.Value) { item.JENIS_TARIF = Convert.ToString(reader[7]); }
						if (reader[8] != DBNull.Value) { item.CONTACT_PERSON = Convert.ToString(reader[8]); }
						if (reader[9] != DBNull.Value) { item.NO_TELP = Convert.ToString(reader[9]); }
						if (reader[10] != DBNull.Value) { item.STATUS = Convert.ToString(reader[10]); }
						if (reader[11] != DBNull.Value) { item.NO_KONTRAK = Convert.ToString(reader[11]); }
						if (reader[12] != DBNull.Value) { item.TGL_BERLAKU = Convert.ToDateTime(reader[12]); }
						if (reader[13] != DBNull.Value) { item.TGL_BERAKHIR = Convert.ToDateTime(reader[13]); }
						if (reader[14] != DBNull.Value) { item.JENIS_KONTRAK = Convert.ToString(reader[14]); }
						if (reader[15] != DBNull.Value) { item.MIN_KONTRAK = Convert.ToDouble(reader[15]); }
						if (reader[16] != DBNull.Value) { item.MAX_KONTRAK = Convert.ToDouble(reader[16]); }
						if (reader[17] != DBNull.Value) { item.HARIAN_MIN_KONTRAK = Convert.ToDouble(reader[17]); }
						if (reader[18] != DBNull.Value) { item.BULANAN_MIN_KONTRAK = Convert.ToDouble(reader[18]); }
						if (reader[19] != DBNull.Value) { item.HARIAN_MAX_KONTRAK = Convert.ToDouble(reader[19]); }
						if (reader[20] != DBNull.Value) { item.BULANAN_MAX_KONTRAK = Convert.ToDouble(reader[20]); }
						if (reader[21] != DBNull.Value) { item.TEKANAN = Convert.ToString(reader[21]); }
						if (reader[22] != DBNull.Value) { item.SEKTOR = Convert.ToString(reader[22]); }
						if (reader[23] != DBNull.Value) { item.SEKTOR_INDUSTRI = Convert.ToString(reader[23]); }
						if (reader[24] != DBNull.Value) { item.TGL_BERLANGGANAN = Convert.ToDateTime(reader[24]); }
						if (reader[25] != DBNull.Value) { item.TGL_BERHENTI_BERLANGGANAN = Convert.ToDateTime(reader[25]); }
						if (reader[26] != DBNull.Value) { item.JNS_KALORI = Convert.ToString(reader[26]); }
						if (reader[27] != DBNull.Value) { item.JML_HARI_KERJA_MINGGU = Convert.ToInt32(reader[27]); }
						if (reader[28] != DBNull.Value) { item.JML_JAM_KERJA_HARI = Convert.ToInt32(reader[28]); }
						if (reader[29] != DBNull.Value) { item.KODE_HARGA = Convert.ToString(reader[29]); }
						if (reader[30] != DBNull.Value) { item.LONGITUDE = Convert.ToDouble(reader[30]); }
						if (reader[31] != DBNull.Value) { item.LATITUDE = Convert.ToDouble(reader[31]); }
						if (reader[32] != DBNull.Value) { item.SIPGAS_LAST_FEED = Convert.ToDateTime(reader[32]); }
						if (reader[33] != DBNull.Value) { item.SERIAL_NUM = Convert.ToString(reader[33]); }
						if (reader[34] != DBNull.Value) { item.ASSET_NUM = Convert.ToString(reader[34]); }
						if (reader[35] != DBNull.Value) { item.INSTALL_DATE = Convert.ToDateTime(reader[35]); }
						if (reader[36] != DBNull.Value) { item.MERK = Convert.ToString(reader[36]); }
						if (reader[37] != DBNull.Value) { item.ATTRIBUTE_TIPE = Convert.ToString(reader[37]); }
						if (reader[38] != DBNull.Value) { item.GSIZE = Convert.ToString(reader[38]); }
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

		public void RemoveByIDREFPELANGGAN(string id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE VIEW_PELANGGAN3 WHERE IDREFPELANGGAN = @IDREFPELANGGAN", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", id); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public DataTable GetDataTable(List<VIEW_PELANGGAN3> view_pelanggan3)
		{
			DataTable dt = new DataTable("VIEW_PELANGGAN3");

			DataColumn c1 = new DataColumn("IDREFPELANGGAN", typeof(string)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("ACC_ID", typeof(string)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("ID_UNIT_USAHA", typeof(string)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("NOREF", typeof(string)); c4.AllowDBNull = true;
			dt.Columns.Add(c4);
			DataColumn c5 = new DataColumn("NAMA", typeof(string)); c5.AllowDBNull = true;
			dt.Columns.Add(c5);
			DataColumn c6 = new DataColumn("ALAMAT", typeof(string)); c6.AllowDBNull = true;
			dt.Columns.Add(c6);
			DataColumn c7 = new DataColumn("JENIS_CUSTOMER", typeof(string)); c7.AllowDBNull = true;
			dt.Columns.Add(c7);
			DataColumn c8 = new DataColumn("JENIS_TARIF", typeof(string)); c8.AllowDBNull = true;
			dt.Columns.Add(c8);
			DataColumn c9 = new DataColumn("CONTACT_PERSON", typeof(string)); c9.AllowDBNull = true;
			dt.Columns.Add(c9);
			DataColumn c10 = new DataColumn("NO_TELP", typeof(string)); c10.AllowDBNull = true;
			dt.Columns.Add(c10);
			DataColumn c11 = new DataColumn("STATUS", typeof(string)); c11.AllowDBNull = true;
			dt.Columns.Add(c11);
			DataColumn c12 = new DataColumn("NO_KONTRAK", typeof(string)); c12.AllowDBNull = true;
			dt.Columns.Add(c12);
			DataColumn c13 = new DataColumn("TGL_BERLAKU", typeof(DateTime)); c13.AllowDBNull = true;
			dt.Columns.Add(c13);
			DataColumn c14 = new DataColumn("TGL_BERAKHIR", typeof(DateTime)); c14.AllowDBNull = true;
			dt.Columns.Add(c14);
			DataColumn c15 = new DataColumn("JENIS_KONTRAK", typeof(string)); c15.AllowDBNull = true;
			dt.Columns.Add(c15);
			DataColumn c16 = new DataColumn("MIN_KONTRAK", typeof(double)); c16.AllowDBNull = true;
			dt.Columns.Add(c16);
			DataColumn c17 = new DataColumn("MAX_KONTRAK", typeof(double)); c17.AllowDBNull = true;
			dt.Columns.Add(c17);
			DataColumn c18 = new DataColumn("HARIAN_MIN_KONTRAK", typeof(double)); c18.AllowDBNull = true;
			dt.Columns.Add(c18);
			DataColumn c19 = new DataColumn("BULANAN_MIN_KONTRAK", typeof(double)); c19.AllowDBNull = true;
			dt.Columns.Add(c19);
			DataColumn c20 = new DataColumn("HARIAN_MAX_KONTRAK", typeof(double)); c20.AllowDBNull = true;
			dt.Columns.Add(c20);
			DataColumn c21 = new DataColumn("BULANAN_MAX_KONTRAK", typeof(double)); c21.AllowDBNull = true;
			dt.Columns.Add(c21);
			DataColumn c22 = new DataColumn("TEKANAN", typeof(string)); c22.AllowDBNull = true;
			dt.Columns.Add(c22);
			DataColumn c23 = new DataColumn("SEKTOR", typeof(string)); c23.AllowDBNull = true;
			dt.Columns.Add(c23);
			DataColumn c24 = new DataColumn("SEKTOR_INDUSTRI", typeof(string)); c24.AllowDBNull = true;
			dt.Columns.Add(c24);
			DataColumn c25 = new DataColumn("TGL_BERLANGGANAN", typeof(DateTime)); c25.AllowDBNull = true;
			dt.Columns.Add(c25);
			DataColumn c26 = new DataColumn("TGL_BERHENTI_BERLANGGANAN", typeof(DateTime)); c26.AllowDBNull = true;
			dt.Columns.Add(c26);
			DataColumn c27 = new DataColumn("JNS_KALORI", typeof(string)); c27.AllowDBNull = true;
			dt.Columns.Add(c27);
			DataColumn c28 = new DataColumn("JML_HARI_KERJA_MINGGU", typeof(int)); c28.AllowDBNull = true;
			dt.Columns.Add(c28);
			DataColumn c29 = new DataColumn("JML_JAM_KERJA_HARI", typeof(int)); c29.AllowDBNull = true;
			dt.Columns.Add(c29);
			DataColumn c30 = new DataColumn("KODE_HARGA", typeof(string)); c30.AllowDBNull = true;
			dt.Columns.Add(c30);
			DataColumn c31 = new DataColumn("LONGITUDE", typeof(double)); c31.AllowDBNull = true;
			dt.Columns.Add(c31);
			DataColumn c32 = new DataColumn("LATITUDE", typeof(double)); c32.AllowDBNull = true;
			dt.Columns.Add(c32);
			DataColumn c33 = new DataColumn("SIPGAS_LAST_FEED", typeof(DateTime)); c33.AllowDBNull = true;
			dt.Columns.Add(c33);
			DataColumn c34 = new DataColumn("SERIAL_NUM", typeof(string)); c34.AllowDBNull = true;
			dt.Columns.Add(c34);
			DataColumn c35 = new DataColumn("ASSET_NUM", typeof(string)); c35.AllowDBNull = true;
			dt.Columns.Add(c35);
			DataColumn c36 = new DataColumn("INSTALL_DATE", typeof(DateTime)); c36.AllowDBNull = true;
			dt.Columns.Add(c36);
			DataColumn c37 = new DataColumn("MERK", typeof(string)); c37.AllowDBNull = true;
			dt.Columns.Add(c37);
			DataColumn c38 = new DataColumn("ATTRIBUTE_TIPE", typeof(string)); c38.AllowDBNull = true;
			dt.Columns.Add(c38);
			DataColumn c39 = new DataColumn("GSIZE", typeof(string)); c39.AllowDBNull = true;
			dt.Columns.Add(c39);

			foreach (VIEW_PELANGGAN3 v in view_pelanggan3)
			{
				DataRow dr = dt.NewRow();
				if (v.IDREFPELANGGAN != null) { dr[0] = v.IDREFPELANGGAN; } else { dr[0] = DBNull.Value; }
				if (v.ACC_ID != null) { dr[1] = v.ACC_ID; } else { dr[1] = DBNull.Value; }
				if (v.ID_UNIT_USAHA != null) { dr[2] = v.ID_UNIT_USAHA; } else { dr[2] = DBNull.Value; }
				if (v.NOREF != null) { dr[3] = v.NOREF; } else { dr[3] = DBNull.Value; }
				if (v.NAMA != null) { dr[4] = v.NAMA; } else { dr[4] = DBNull.Value; }
				if (v.ALAMAT != null) { dr[5] = v.ALAMAT; } else { dr[5] = DBNull.Value; }
				if (v.JENIS_CUSTOMER != null) { dr[6] = v.JENIS_CUSTOMER; } else { dr[6] = DBNull.Value; }
				if (v.JENIS_TARIF != null) { dr[7] = v.JENIS_TARIF; } else { dr[7] = DBNull.Value; }
				if (v.CONTACT_PERSON != null) { dr[8] = v.CONTACT_PERSON; } else { dr[8] = DBNull.Value; }
				if (v.NO_TELP != null) { dr[9] = v.NO_TELP; } else { dr[9] = DBNull.Value; }
				if (v.STATUS != null) { dr[10] = v.STATUS; } else { dr[10] = DBNull.Value; }
				if (v.NO_KONTRAK != null) { dr[11] = v.NO_KONTRAK; } else { dr[11] = DBNull.Value; }
				if (v.TGL_BERLAKU != null) { dr[12] = v.TGL_BERLAKU; } else { dr[12] = DBNull.Value; }
				if (v.TGL_BERAKHIR != null) { dr[13] = v.TGL_BERAKHIR; } else { dr[13] = DBNull.Value; }
				if (v.JENIS_KONTRAK != null) { dr[14] = v.JENIS_KONTRAK; } else { dr[14] = DBNull.Value; }
				if (v.MIN_KONTRAK != null) { dr[15] = v.MIN_KONTRAK; } else { dr[15] = DBNull.Value; }
				if (v.MAX_KONTRAK != null) { dr[16] = v.MAX_KONTRAK; } else { dr[16] = DBNull.Value; }
				if (v.HARIAN_MIN_KONTRAK != null) { dr[17] = v.HARIAN_MIN_KONTRAK; } else { dr[17] = DBNull.Value; }
				if (v.BULANAN_MIN_KONTRAK != null) { dr[18] = v.BULANAN_MIN_KONTRAK; } else { dr[18] = DBNull.Value; }
				if (v.HARIAN_MAX_KONTRAK != null) { dr[19] = v.HARIAN_MAX_KONTRAK; } else { dr[19] = DBNull.Value; }
				if (v.BULANAN_MAX_KONTRAK != null) { dr[20] = v.BULANAN_MAX_KONTRAK; } else { dr[20] = DBNull.Value; }
				if (v.TEKANAN != null) { dr[21] = v.TEKANAN; } else { dr[21] = DBNull.Value; }
				if (v.SEKTOR != null) { dr[22] = v.SEKTOR; } else { dr[22] = DBNull.Value; }
				if (v.SEKTOR_INDUSTRI != null) { dr[23] = v.SEKTOR_INDUSTRI; } else { dr[23] = DBNull.Value; }
				if (v.TGL_BERLANGGANAN != null) { dr[24] = v.TGL_BERLANGGANAN; } else { dr[24] = DBNull.Value; }
				if (v.TGL_BERHENTI_BERLANGGANAN != null) { dr[25] = v.TGL_BERHENTI_BERLANGGANAN; } else { dr[25] = DBNull.Value; }
				if (v.JNS_KALORI != null) { dr[26] = v.JNS_KALORI; } else { dr[26] = DBNull.Value; }
				if (v.JML_HARI_KERJA_MINGGU != null) { dr[27] = v.JML_HARI_KERJA_MINGGU; } else { dr[27] = DBNull.Value; }
				if (v.JML_JAM_KERJA_HARI != null) { dr[28] = v.JML_JAM_KERJA_HARI; } else { dr[28] = DBNull.Value; }
				if (v.KODE_HARGA != null) { dr[29] = v.KODE_HARGA; } else { dr[29] = DBNull.Value; }
				if (v.LONGITUDE != null) { dr[30] = v.LONGITUDE; } else { dr[30] = DBNull.Value; }
				if (v.LATITUDE != null) { dr[31] = v.LATITUDE; } else { dr[31] = DBNull.Value; }
				if (v.SIPGAS_LAST_FEED != null) { dr[32] = v.SIPGAS_LAST_FEED; } else { dr[32] = DBNull.Value; }
				if (v.SERIAL_NUM != null) { dr[33] = v.SERIAL_NUM; } else { dr[33] = DBNull.Value; }
				if (v.ASSET_NUM != null) { dr[34] = v.ASSET_NUM; } else { dr[34] = DBNull.Value; }
				if (v.INSTALL_DATE != null) { dr[35] = v.INSTALL_DATE; } else { dr[35] = DBNull.Value; }
				if (v.MERK != null) { dr[36] = v.MERK; } else { dr[36] = DBNull.Value; }
				if (v.ATTRIBUTE_TIPE != null) { dr[37] = v.ATTRIBUTE_TIPE; } else { dr[37] = DBNull.Value; }
				if (v.GSIZE != null) { dr[38] = v.GSIZE; } else { dr[38] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<VIEW_PELANGGAN3> view_pelanggan3)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(view_pelanggan3);
					using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connString))
					{
						bulkCopy.DestinationTableName = dt.TableName;
						bulkCopy.WriteToServer(dt);
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

        //public List<VIEW_PELANGGAN3> GetDataFromFile()
        //{
        //    string path = Directory.GetCurrentDirectory();
        //    string fileName = path + "\\FileData\\" + "VIEW_PELANGGAN3.txt";
        //    List<VIEW_PELANGGAN3> items = new List<VIEW_PELANGGAN3>();
        //    using (var reader = new StreamReader(fileName))
        //    {
        //        Message = "";
        //        try
        //        {
        //            int pos = 0;
        //            while(!reader.EndOfStream)
        //            {
        //                VIEW_PELANGGAN3 item = new VIEW_PELANGGAN3();
        //                var line = reader.ReadLine();
        //                var values = line.Split('\t');
        //                if (pos == 0)
        //                {
        //                    pos = pos + 1;
        //                    continue;
        //                }
        //                if (values[0] != "") { item.IDREFPELANGGAN = Convert.ToString(values[0]); }
        //                if (values[1] != "") { item.ACC_ID = Convert.ToString(values[1]); }
        //                if (values[2] != "") { item.ID_UNIT_USAHA = Convert.ToString(values[2]); }
        //                if (values[3] != "") { item.NOREF = Convert.ToString(values[3]); }
        //                if (values[4] != "") { item.NAMA = Convert.ToString(values[4]); }
        //                if (values[5] != "") { item.ALAMAT = Convert.ToString(values[5]); }
        //                if (values[6] != "") { item.JENIS_CUSTOMER = Convert.ToString(values[6]); }
        //                if (values[7] != "") { item.JENIS_TARIF = Convert.ToString(values[7]); }
        //                if (values[8] != "") { item.CONTACT_PERSON = Convert.ToString(values[8]); }
        //                if (values[9] != "") { item.NO_TELP = Convert.ToString(values[9]); }
        //                if (values[10] != "") { item.STATUS = Convert.ToString(values[10]); }
        //                if (values[11] != "") { item.NO_KONTRAK = Convert.ToString(values[11]); }
        //                if (values[12] != "") { item.TGL_BERLAKU = Convert.ToDateTime(values[12]); }
        //                if (values[13] != "") { item.TGL_BERAKHIR = Convert.ToDateTime(values[13]); }
        //                if (values[14] != "") { item.JENIS_KONTRAK = Convert.ToString(values[14]); }
        //                if (values[15] != "") { item.MIN_KONTRAK = Convert.ToDouble(values[15]); }
        //                if (values[16] != "") { item.MAX_KONTRAK = Convert.ToDouble(values[16]); }
        //                if (values[17] != "") { item.HARIAN_MIN_KONTRAK = Convert.ToDouble(values[17]); }
        //                if (values[18] != "") { item.BULANAN_MIN_KONTRAK = Convert.ToDouble(values[18]); }
        //                if (values[19] != "") { item.HARIAN_MAX_KONTRAK = Convert.ToDouble(values[19]); }
        //                if (values[20] != "") { item.BULANAN_MAX_KONTRAK = Convert.ToDouble(values[20]); }
        //                if (values[21] != "") { item.TEKANAN = Convert.ToString(values[21]); }
        //                if (values[22] != "") { item.SEKTOR = Convert.ToString(values[22]); }
        //                if (values[23] != "") { item.SEKTOR_INDUSTRI = Convert.ToString(values[23]); }
        //                if (values[24] != "") { item.TGL_BERLANGGANAN = Convert.ToDateTime(values[24]); }
        //                if (values[25] != "") { item.TGL_BERHENTI_BERLANGGANAN = Convert.ToDateTime(values[25]); }
        //                if (values[26] != "") { item.JNS_KALORI = Convert.ToString(values[26]); }
        //                if (values[27] != "") { item.JML_HARI_KERJA_MINGGU = Convert.ToInt32(values[27]); }
        //                if (values[28] != "") { item.JML_JAM_KERJA_HARI = Convert.ToInt32(values[28]); }
        //                if (values[29] != "") { item.KODE_HARGA = Convert.ToString(values[29]); }
        //                if (values[30] != "") { item.LONGITUDE = Convert.ToDouble(values[30]); }
        //                if (values[31] != "") { item.LATITUDE = Convert.ToDouble(values[31]); }
        //                if (values[32] != "") { item.SIPGAS_LAST_FEED = Convert.ToDateTime(values[32]); }
        //                if (values[33] != "") { item.SERIAL_NUM = Convert.ToString(values[33]); }
        //                if (values[34] != "") { item.ASSET_NUM = Convert.ToString(values[34]); }
        //                if (values[35] != "") { item.INSTALL_DATE = Convert.ToDateTime(values[35]); }
        //                if (values[36] != "") { item.MERK = Convert.ToString(values[36]); }
        //                if (values[37] != "") { item.ATTRIBUTE_TIPE = Convert.ToString(values[37]); }
        //                if (values[38] != "") { item.GSIZE = Convert.ToString(values[38]); }
        //                items.Add(item);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Message = ex.Message;
        //        }
        //    }
        //    return items;
        //}

	}
}