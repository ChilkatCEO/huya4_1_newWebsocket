using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000023 RID: 35
	public sealed class GetCdnTokenRsp : JceStruct
	{
		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00005C6C File Offset: 0x00003E6C
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00005C74 File Offset: 0x00003E74
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

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00005C7D File Offset: 0x00003E7D
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00005C85 File Offset: 0x00003E85
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

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00005C8E File Offset: 0x00003E8E
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00005C96 File Offset: 0x00003E96
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

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00005C9F File Offset: 0x00003E9F
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00005CA7 File Offset: 0x00003EA7
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

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600020B RID: 523 RVA: 0x00005CB0 File Offset: 0x00003EB0
		// (set) Token: 0x0600020C RID: 524 RVA: 0x00005CB8 File Offset: 0x00003EB8
		public string anti_code
		{
			get
			{
				return this._anti_code;
			}
			set
			{
				this._anti_code = value;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00005CC1 File Offset: 0x00003EC1
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00005CC9 File Offset: 0x00003EC9
		public string sTime
		{
			get
			{
				return this._sTime;
			}
			set
			{
				this._sTime = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00005CD2 File Offset: 0x00003ED2
		// (set) Token: 0x06000210 RID: 528 RVA: 0x00005CDA File Offset: 0x00003EDA
		public string flv_anti_code
		{
			get
			{
				return this._flv_anti_code;
			}
			set
			{
				this._flv_anti_code = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00005CE3 File Offset: 0x00003EE3
		// (set) Token: 0x06000212 RID: 530 RVA: 0x00005CEB File Offset: 0x00003EEB
		public string hls_anti_code
		{
			get
			{
				return this._hls_anti_code;
			}
			set
			{
				this._hls_anti_code = value;
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00005CF4 File Offset: 0x00003EF4
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.url, 0, false);
			_os.Write(this.cdn_type, 1, false);
			_os.Write(this.stream_name, 2, false);
			_os.Write(this.presenter_uid, 3);
			_os.Write(this.anti_code, 4, false);
			_os.Write(this.sTime, 5, false);
			_os.Write(this.flv_anti_code, 6, false);
			_os.Write(this.hls_anti_code, 7, false);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00005D70 File Offset: 0x00003F70
		public override void ReadFrom(JceInputStream _is)
		{
			this.url = _is.Read(this.url, 0, false);
			this.cdn_type = _is.Read(this.cdn_type, 1, false);
			this.stream_name = _is.Read(this.stream_name, 2, false);
			this.presenter_uid = _is.Read(this.presenter_uid, 3, false);
			this.anti_code = _is.Read(this.anti_code, 4, false);
			this.sTime = _is.Read(this.sTime, 5, false);
			this.flv_anti_code = _is.Read(this.flv_anti_code, 6, false);
			this.hls_anti_code = _is.Read(this.hls_anti_code, 7, false);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00005E20 File Offset: 0x00004020
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.url, "url");
			jceDisplayer.Display(this.cdn_type, "cdn_type");
			jceDisplayer.Display(this.stream_name, "stream_name");
			jceDisplayer.Display(this.presenter_uid, "presenter_uid");
			jceDisplayer.Display(this.anti_code, "anti_code");
			jceDisplayer.Display(this.sTime, "sTime");
			jceDisplayer.Display(this.flv_anti_code, "flv_anti_code");
			jceDisplayer.Display(this.hls_anti_code, "hls_anti_code");
		}

		// Token: 0x040000D7 RID: 215
		private string _url = "";

		// Token: 0x040000D8 RID: 216
		private string _cdn_type = "";

		// Token: 0x040000D9 RID: 217
		private string _stream_name = "";

		// Token: 0x040000DA RID: 218
		private long _presenter_uid;

		// Token: 0x040000DB RID: 219
		private string _anti_code = "";

		// Token: 0x040000DC RID: 220
		private string _sTime = "";

		// Token: 0x040000DD RID: 221
		private string _flv_anti_code = "";

		// Token: 0x040000DE RID: 222
		private string _hls_anti_code = "";
	}
}
