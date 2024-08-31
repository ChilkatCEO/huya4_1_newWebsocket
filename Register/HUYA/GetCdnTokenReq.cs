using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000022 RID: 34
	public sealed class GetCdnTokenReq : JceStruct
	{
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00005B0B File Offset: 0x00003D0B
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00005B13 File Offset: 0x00003D13
		public string url
		{
			get
			{
				return this._url;
			}
			set
			{
				this._url = value;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00005B1C File Offset: 0x00003D1C
		// (set) Token: 0x060001FA RID: 506 RVA: 0x00005B24 File Offset: 0x00003D24
		public string cdn_type
		{
			get
			{
				return this._cdn_type;
			}
			set
			{
				this._cdn_type = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00005B2D File Offset: 0x00003D2D
		// (set) Token: 0x060001FC RID: 508 RVA: 0x00005B35 File Offset: 0x00003D35
		public string stream_name
		{
			get
			{
				return this._stream_name;
			}
			set
			{
				this._stream_name = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00005B3E File Offset: 0x00003D3E
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00005B46 File Offset: 0x00003D46
		public long presenter_uid
		{
			get
			{
				return this._presenter_uid;
			}
			set
			{
				this._presenter_uid = value;
			}
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00005B4F File Offset: 0x00003D4F
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.url, 0, false);
			_os.Write(this.cdn_type, 1, false);
			_os.Write(this.stream_name, 2, false);
			_os.Write(this.presenter_uid, 3);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00005B88 File Offset: 0x00003D88
		public override void ReadFrom(JceInputStream _is)
		{
			this.url = _is.Read(this.url, 0, false);
			this.cdn_type = _is.Read(this.cdn_type, 1, false);
			this.stream_name = _is.Read(this.stream_name, 2, false);
			this.presenter_uid = _is.Read(this.presenter_uid, 3, false);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00005BE8 File Offset: 0x00003DE8
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.url, "url");
			jceDisplayer.Display(this.cdn_type, "cdn_type");
			jceDisplayer.Display(this.stream_name, "stream_name");
			jceDisplayer.Display(this.presenter_uid, "presenter_uid");
		}

		// Token: 0x040000D3 RID: 211
		private string _url = "";

		// Token: 0x040000D4 RID: 212
		private string _cdn_type = "";

		// Token: 0x040000D5 RID: 213
		private string _stream_name = "";

		// Token: 0x040000D6 RID: 214
		private long _presenter_uid;
	}
}
