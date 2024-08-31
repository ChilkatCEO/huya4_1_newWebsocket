using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000EB RID: 235
	public sealed class UserEventReq : JceStruct
	{
		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00008E49 File Offset: 0x00007049
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00008E51 File Offset: 0x00007051
		public UserId tId { get; set; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00008E5A File Offset: 0x0000705A
		// (set) Token: 0x060003AD RID: 941 RVA: 0x00008E62 File Offset: 0x00007062
		public long lTid
		{
			get
			{
				return this._lTid;
			}
			set
			{
				this._lTid = value;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00008E6B File Offset: 0x0000706B
		// (set) Token: 0x060003AF RID: 943 RVA: 0x00008E73 File Offset: 0x00007073
		public long lSid
		{
			get
			{
				return this._lSid;
			}
			set
			{
				this._lSid = value;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x00008E7C File Offset: 0x0000707C
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x00008E84 File Offset: 0x00007084
		public int eOp { get; set; }

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x00008E8D File Offset: 0x0000708D
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x00008E95 File Offset: 0x00007095
		public string sChan
		{
			get
			{
				return this._sChan;
			}
			set
			{
				this._sChan = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00008E9E File Offset: 0x0000709E
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x00008EA6 File Offset: 0x000070A6
		public int eSource { get; set; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00008EAF File Offset: 0x000070AF
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x00008EB7 File Offset: 0x000070B7
		public long lPid
		{
			get
			{
				return this._lPid;
			}
			set
			{
				this._lPid = value;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x00008EC0 File Offset: 0x000070C0
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x00008EC8 File Offset: 0x000070C8
		public bool bWatchVideo
		{
			get
			{
				return this._bWatchVideo;
			}
			set
			{
				this._bWatchVideo = value;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00008ED1 File Offset: 0x000070D1
		// (set) Token: 0x060003BB RID: 955 RVA: 0x00008ED9 File Offset: 0x000070D9
		public bool bAnonymous
		{
			get
			{
				return this._bAnonymous;
			}
			set
			{
				this._bAnonymous = value;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00008EE2 File Offset: 0x000070E2
		// (set) Token: 0x060003BD RID: 957 RVA: 0x00008EEA File Offset: 0x000070EA
		public int eTemplateType
		{
			get
			{
				return this._eTemplateType;
			}
			set
			{
				this._eTemplateType = value;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060003BE RID: 958 RVA: 0x00008EF3 File Offset: 0x000070F3
		// (set) Token: 0x060003BF RID: 959 RVA: 0x00008EFB File Offset: 0x000070FB
		public string sTraceSource
		{
			get
			{
				return this._sTraceSource;
			}
			set
			{
				this._sTraceSource = value;
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00008F04 File Offset: 0x00007104
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tId, 0);
			_os.Write(this.lTid, 1);
			_os.Write(this.lSid, 2);
			_os.Write(this.eOp, 4);
			_os.Write(this.sChan, 5, false);
			_os.Write(this.eSource, 6);
			_os.Write(this.lPid, 7);
			_os.Write(this.bWatchVideo, 8);
			_os.Write(this.bAnonymous, 9);
			_os.Write(this.eTemplateType, 10);
			_os.Write(this.sTraceSource, 11, false);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00008FA8 File Offset: 0x000071A8
		public override void ReadFrom(JceInputStream _is)
		{
			this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
			this.lTid = _is.Read(this.lTid, 1, false);
			this.lSid = _is.Read(this.lSid, 2, false);
			this.eOp = _is.Read(this.eOp, 4, false);
			this.sChan = _is.Read(this.sChan, 5, false);
			this.eSource = _is.Read(this.eSource, 6, false);
			this.lPid = _is.Read(this.lPid, 7, false);
			this.bWatchVideo = _is.Read(this.bWatchVideo, 8, false);
			this.bAnonymous = _is.Read(this.bAnonymous, 9, false);
			this.eTemplateType = _is.Read(this.eTemplateType, 10, false);
			this.sTraceSource = _is.Read(this.sTraceSource, 11, false);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000909C File Offset: 0x0000729C
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tId, "tId");
			jceDisplayer.Display(this.lTid, "lTid");
			jceDisplayer.Display(this.lSid, "lSid");
			jceDisplayer.Display(this.eOp, "eOp");
			jceDisplayer.Display(this.sChan, "sChan");
			jceDisplayer.Display(this.eSource, "eSource");
			jceDisplayer.Display(this.lPid, "lPid");
			jceDisplayer.Display(this.bWatchVideo, "bWatchVideo");
			jceDisplayer.Display(this.bAnonymous, "bAnonymous");
			jceDisplayer.Display(this.eTemplateType, "eTemplateType");
			jceDisplayer.Display(this.sTraceSource, "sTraceSource");
		}

		// Token: 0x040007E6 RID: 2022
		private long _lTid;

		// Token: 0x040007E7 RID: 2023
		private long _lSid;

		// Token: 0x040007E9 RID: 2025
		private string _sChan = "";

		// Token: 0x040007EB RID: 2027
		private long _lPid;

		// Token: 0x040007EC RID: 2028
		private bool _bWatchVideo;

		// Token: 0x040007ED RID: 2029
		private bool _bAnonymous;

		// Token: 0x040007EE RID: 2030
		private int _eTemplateType = 1;

		// Token: 0x040007EF RID: 2031
		private string _sTraceSource = "";
	}
}
