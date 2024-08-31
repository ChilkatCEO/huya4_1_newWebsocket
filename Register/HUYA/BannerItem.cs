using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000019 RID: 25
	public sealed class BannerItem : JceStruct
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000037BE File Offset: 0x000019BE
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x000037C6 File Offset: 0x000019C6
		public string sExtval1
		{
			get
			{
				return this._sExtval1;
			}
			set
			{
				this._sExtval1 = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000037CF File Offset: 0x000019CF
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000037D7 File Offset: 0x000019D7
		public string sImage
		{
			get
			{
				return this._sImage;
			}
			set
			{
				this._sImage = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000EB RID: 235 RVA: 0x000037E0 File Offset: 0x000019E0
		// (set) Token: 0x060000EC RID: 236 RVA: 0x000037E8 File Offset: 0x000019E8
		public string sMarketing
		{
			get
			{
				return this._sMarketing;
			}
			set
			{
				this._sMarketing = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000ED RID: 237 RVA: 0x000037F1 File Offset: 0x000019F1
		// (set) Token: 0x060000EE RID: 238 RVA: 0x000037F9 File Offset: 0x000019F9
		public string sSubject
		{
			get
			{
				return this._sSubject;
			}
			set
			{
				this._sSubject = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00003802 File Offset: 0x00001A02
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x0000380A File Offset: 0x00001A0A
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

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00003813 File Offset: 0x00001A13
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x0000381B File Offset: 0x00001A1B
		public string sContent
		{
			get
			{
				return this._sContent;
			}
			set
			{
				this._sContent = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00003824 File Offset: 0x00001A24
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x0000382C File Offset: 0x00001A2C
		public string sSource
		{
			get
			{
				return this._sSource;
			}
			set
			{
				this._sSource = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00003835 File Offset: 0x00001A35
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x0000383D File Offset: 0x00001A3D
		public string sTraceId
		{
			get
			{
				return this._sTraceId;
			}
			set
			{
				this._sTraceId = value;
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00003848 File Offset: 0x00001A48
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.sExtval1, 0, false);
			_os.Write(this.sImage, 1, false);
			_os.Write(this.sMarketing, 2, false);
			_os.Write(this.sSubject, 3, false);
			_os.Write(this.sUrl, 4, false);
			_os.Write(this.sContent, 5, false);
			_os.Write(this.sSource, 6, false);
			_os.Write(this.sTraceId, 7, false);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000038C8 File Offset: 0x00001AC8
		public override void ReadFrom(JceInputStream _is)
		{
			this.sExtval1 = _is.Read(this.sExtval1, 0, false);
			this.sImage = _is.Read(this.sImage, 1, false);
			this.sMarketing = _is.Read(this.sMarketing, 2, false);
			this.sSubject = _is.Read(this.sSubject, 3, false);
			this.sUrl = _is.Read(this.sUrl, 4, false);
			this.sContent = _is.Read(this.sContent, 5, false);
			this.sSource = _is.Read(this.sSource, 6, false);
			this.sTraceId = _is.Read(this.sTraceId, 7, false);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00003978 File Offset: 0x00001B78
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.sExtval1, "sExtval1");
			jceDisplayer.Display(this.sImage, "sImage");
			jceDisplayer.Display(this.sMarketing, "sMarketing");
			jceDisplayer.Display(this.sSubject, "sSubject");
			jceDisplayer.Display(this.sUrl, "sUrl");
			jceDisplayer.Display(this.sContent, "sContent");
			jceDisplayer.Display(this.sSource, "sSource");
			jceDisplayer.Display(this.sTraceId, "sTraceId");
		}

		// Token: 0x0400005D RID: 93
		private string _sExtval1 = "";

		// Token: 0x0400005E RID: 94
		private string _sImage = "";

		// Token: 0x0400005F RID: 95
		private string _sMarketing = "";

		// Token: 0x04000060 RID: 96
		private string _sSubject = "";

		// Token: 0x04000061 RID: 97
		private string _sUrl = "";

		// Token: 0x04000062 RID: 98
		private string _sContent = "";

		// Token: 0x04000063 RID: 99
		private string _sSource = "";

		// Token: 0x04000064 RID: 100
		private string _sTraceId = "";
	}
}
