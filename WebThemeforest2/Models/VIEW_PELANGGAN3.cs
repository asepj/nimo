using System;
using System.Collections.Generic;

namespace WebThemeforest2.Models
{
	public partial class VIEW_PELANGGAN3
	{
		public virtual string IDREFPELANGGAN { get; set; }
		public virtual string ACC_ID { get; set; }
		public virtual string ID_UNIT_USAHA { get; set; }
		public virtual string NOREF { get; set; }
		public virtual string NAMA { get; set; }
		public virtual string ALAMAT { get; set; }
		public virtual string JENIS_CUSTOMER { get; set; }
		public virtual string JENIS_TARIF { get; set; }
		public virtual string CONTACT_PERSON { get; set; }
		public virtual string NO_TELP { get; set; }
		public virtual string STATUS { get; set; }
		public virtual string NO_KONTRAK { get; set; }
		public virtual DateTime? TGL_BERLAKU { get; set; }
		public virtual DateTime? TGL_BERAKHIR { get; set; }
		public virtual string JENIS_KONTRAK { get; set; }
		public virtual double? MIN_KONTRAK { get; set; }
		public virtual double? MAX_KONTRAK { get; set; }
		public virtual double? HARIAN_MIN_KONTRAK { get; set; }
		public virtual double? BULANAN_MIN_KONTRAK { get; set; }
		public virtual double? HARIAN_MAX_KONTRAK { get; set; }
		public virtual double? BULANAN_MAX_KONTRAK { get; set; }
		public virtual string TEKANAN { get; set; }
		public virtual string SEKTOR { get; set; }
		public virtual string SEKTOR_INDUSTRI { get; set; }
		public virtual DateTime? TGL_BERLANGGANAN { get; set; }
		public virtual DateTime? TGL_BERHENTI_BERLANGGANAN { get; set; }
		public virtual string JNS_KALORI { get; set; }
		public virtual int? JML_HARI_KERJA_MINGGU { get; set; }
		public virtual int? JML_JAM_KERJA_HARI { get; set; }
		public virtual string KODE_HARGA { get; set; }
		public virtual double? LONGITUDE { get; set; }
		public virtual double? LATITUDE { get; set; }
		public virtual DateTime? SIPGAS_LAST_FEED { get; set; }
		public virtual string SERIAL_NUM { get; set; }
		public virtual string ASSET_NUM { get; set; }
		public virtual DateTime? INSTALL_DATE { get; set; }
		public virtual string MERK { get; set; }
		public virtual string ATTRIBUTE_TIPE { get; set; }
		public virtual string GSIZE { get; set; }

		public VIEW_PELANGGAN3()
		{

		}
	}
}