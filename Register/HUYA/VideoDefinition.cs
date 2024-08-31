using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000EF RID: 239
	public sealed class VideoDefinition : JceStruct
	{
		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x000095DE File Offset: 0x000077DE
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x000095E6 File Offset: 0x000077E6
		public string sSize
		{
			get
			{
				return this._sSize;
			}
			set
			{
				this._sSize = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x000095EF File Offset: 0x000077EF
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x000095F7 File Offset: 0x000077F7
		public string sWidth
		{
			get
			{
				return this._sWidth;
			}
			set
			{
				this._sWidth = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x00009600 File Offset: 0x00007800
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x00009608 File Offset: 0x00007808
		public string sHeight
		{
			get
			{
				return this._sHeight;
			}
			set
			{
				this._sHeight = value;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x00009611 File Offset: 0x00007811
		// (set) Token: 0x060003F1 RID: 1009 RVA: 0x00009619 File Offset: 0x00007819
		public string sDefinition
		{
			get
			{
				return this._sDefinition;
			}
			set
			{
				this._sDefinition = value;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00009622 File Offset: 0x00007822
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x0000962A File Offset: 0x0000782A
		public string sUrl
		{
			get
			{
				return this._sUrl;
			}
			set
			{
				this._sUrl = value;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x00009633 File Offset: 0x00007833
		// (set) Token: 0x060003F5 RID: 1013 RVA: 0x0000963B File Offset: 0x0000783B
		public string sM3u8
		{
			get
			{
				return this._sM3u8;
			}
			set
			{
				this._sM3u8 = value;
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00009644 File Offset: 0x00007844
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.sSize, 0, false);
			_os.Write(this.sWidth, 1, false);
			_os.Write(this.sHeight, 2, false);
			_os.Write(this.sDefinition, 3, false);
			_os.Write(this.sUrl, 4, false);
			_os.Write(this.sM3u8, 5, false);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x000096A8 File Offset: 0x000078A8
		public override void ReadFrom(JceInputStream _is)
		{
			this.sSize = _is.Read(this.sSize, 0, false);
			this.sWidth = _is.Read(this.sWidth, 1, false);
			this.sHeight = _is.Read(this.sHeight, 2, false);
			this.sDefinition = _is.Read(this.sDefinition, 3, false);
			this.sUrl = _is.Read(this.sUrl, 4, false);
			this.sM3u8 = _is.Read(this.sM3u8, 5, false);
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00009730 File Offset: 0x00007930
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.sSize, "sSize");
			jceDisplayer.Display(this.sWidth, "sWidth");
			jceDisplayer.Display(this.sHeight, "sHeight");
			jceDisplayer.Display(this.sDefinition, "sDefinition");
			jceDisplayer.Display(this.sUrl, "sUrl");
			jceDisplayer.Display(this.sM3u8, "sM3u8");
		}

		// Token: 0x040007FD RID: 2045
		private string _sSize = "";

		// Token: 0x040007FE RID: 2046
		private string _sWidth = "";

		// Token: 0x040007FF RID: 2047
		private string _sHeight = "";

		// Token: 0x04000800 RID: 2048
		private string _sDefinition = "";

		// Token: 0x04000801 RID: 2049
		private string _sUrl = "";

		// Token: 0x04000802 RID: 2050
		private string _sM3u8 = "";
	}
}
