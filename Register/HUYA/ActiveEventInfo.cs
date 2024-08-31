using System;
using System.Text;
using Wup.Jce;

namespace iHUYA
{
	// Token: 0x02000018 RID: 24
	public sealed class ActiveEventInfo : JceStruct
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00003166 File Offset: 0x00001366
		// (set) Token: 0x060000BA RID: 186 RVA: 0x0000316E File Offset: 0x0000136E
		public int iID
		{
			get
			{
				return this._iID;
			}
			set
			{
				this._iID = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00003177 File Offset: 0x00001377
		// (set) Token: 0x060000BC RID: 188 RVA: 0x0000317F File Offset: 0x0000137F
		public string sTitle
		{
			get
			{
				return this._sTitle;
			}
			set
			{
				this._sTitle = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00003188 File Offset: 0x00001388
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00003190 File Offset: 0x00001390
		public int iActBeginTime
		{
			get
			{
				return this._iActBeginTime;
			}
			set
			{
				this._iActBeginTime = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00003199 File Offset: 0x00001399
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x000031A1 File Offset: 0x000013A1
		public string sPicUrl
		{
			get
			{
				return this._sPicUrl;
			}
			set
			{
				this._sPicUrl = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x000031AA File Offset: 0x000013AA
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x000031B2 File Offset: 0x000013B2
		public string sGameName
		{
			get
			{
				return this._sGameName;
			}
			set
			{
				this._sGameName = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x000031BB File Offset: 0x000013BB
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x000031C3 File Offset: 0x000013C3
		public int iGameID
		{
			get
			{
				return this._iGameID;
			}
			set
			{
				this._iGameID = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x000031CC File Offset: 0x000013CC
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x000031D4 File Offset: 0x000013D4
		public string sDigest
		{
			get
			{
				return this._sDigest;
			}
			set
			{
				this._sDigest = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x000031DD File Offset: 0x000013DD
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x000031E5 File Offset: 0x000013E5
		public int iActButtionState
		{
			get
			{
				return this._iActButtionState;
			}
			set
			{
				this._iActButtionState = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000031EE File Offset: 0x000013EE
		// (set) Token: 0x060000CA RID: 202 RVA: 0x000031F6 File Offset: 0x000013F6
		public int iActiveState
		{
			get
			{
				return this._iActiveState;
			}
			set
			{
				this._iActiveState = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000CB RID: 203 RVA: 0x000031FF File Offset: 0x000013FF
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00003207 File Offset: 0x00001407
		public string sActiveState
		{
			get
			{
				return this._sActiveState;
			}
			set
			{
				this._sActiveState = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00003210 File Offset: 0x00001410
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00003218 File Offset: 0x00001418
		public string sLinkUrl
		{
			get
			{
				return this._sLinkUrl;
			}
			set
			{
				this._sLinkUrl = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00003221 File Offset: 0x00001421
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00003229 File Offset: 0x00001429
		public string sDetailUrl
		{
			get
			{
				return this._sDetailUrl;
			}
			set
			{
				this._sDetailUrl = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00003232 File Offset: 0x00001432
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x0000323A File Offset: 0x0000143A
		public int iActEndTime
		{
			get
			{
				return this._iActEndTime;
			}
			set
			{
				this._iActEndTime = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00003243 File Offset: 0x00001443
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x0000324B File Offset: 0x0000144B
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

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00003254 File Offset: 0x00001454
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000325C File Offset: 0x0000145C
		public long lSubid
		{
			get
			{
				return this._lSubid;
			}
			set
			{
				this._lSubid = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00003265 File Offset: 0x00001465
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000326D File Offset: 0x0000146D
		public long lPUid
		{
			get
			{
				return this._lPUid;
			}
			set
			{
				this._lPUid = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00003276 File Offset: 0x00001476
		// (set) Token: 0x060000DA RID: 218 RVA: 0x0000327E File Offset: 0x0000147E
		public int iSourceType
		{
			get
			{
				return this._iSourceType;
			}
			set
			{
				this._iSourceType = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00003287 File Offset: 0x00001487
		// (set) Token: 0x060000DC RID: 220 RVA: 0x0000328F File Offset: 0x0000148F
		public long iSubCnt
		{
			get
			{
				return this._iSubCnt;
			}
			set
			{
				this._iSubCnt = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00003298 File Offset: 0x00001498
		// (set) Token: 0x060000DE RID: 222 RVA: 0x000032A0 File Offset: 0x000014A0
		public int iScreenType
		{
			get
			{
				return this._iScreenType;
			}
			set
			{
				this._iScreenType = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000DF RID: 223 RVA: 0x000032A9 File Offset: 0x000014A9
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x000032B1 File Offset: 0x000014B1
		public bool bDetailUrlNeedLogin
		{
			get
			{
				return this._bDetailUrlNeedLogin;
			}
			set
			{
				this._bDetailUrlNeedLogin = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x000032BA File Offset: 0x000014BA
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x000032C2 File Offset: 0x000014C2
		public bool bLinkUrlNeedLogin
		{
			get
			{
				return this._bLinkUrlNeedLogin;
			}
			set
			{
				this._bLinkUrlNeedLogin = value;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000032CC File Offset: 0x000014CC
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iID, 0);
			_os.Write(this.sTitle, 1, false);
			_os.Write(this.iActBeginTime, 2);
			_os.Write(this.sPicUrl, 4, false);
			_os.Write(this.sGameName, 5, false);
			_os.Write(this.iGameID, 6);
			_os.Write(this.sDigest, 7, false);
			_os.Write(this.iActButtionState, 8);
			_os.Write(this.iActiveState, 9);
			_os.Write(this.sActiveState, 10, false);
			_os.Write(this.sLinkUrl, 11, false);
			_os.Write(this.sDetailUrl, 12, false);
			_os.Write(this.iActEndTime, 13);
			_os.Write(this.lTid, 14);
			_os.Write(this.lSubid, 15);
			_os.Write(this.lPUid, 16);
			_os.Write(this.iSourceType, 17);
			_os.Write(this.iSubCnt, 18);
			_os.Write(this.iScreenType, 19);
			_os.Write(this.bDetailUrlNeedLogin, 20);
			_os.Write(this.bLinkUrlNeedLogin, 21);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003400 File Offset: 0x00001600
		public override void ReadFrom(JceInputStream _is)
		{
			this.iID = _is.Read(this.iID, 0, false);
			this.sTitle = _is.Read(this.sTitle, 1, false);
			this.iActBeginTime = _is.Read(this.iActBeginTime, 2, false);
			this.sPicUrl = _is.Read(this.sPicUrl, 4, false);
			this.sGameName = _is.Read(this.sGameName, 5, false);
			this.iGameID = _is.Read(this.iGameID, 6, false);
			this.sDigest = _is.Read(this.sDigest, 7, false);
			this.iActButtionState = _is.Read(this.iActButtionState, 8, false);
			this.iActiveState = _is.Read(this.iActiveState, 9, false);
			this.sActiveState = _is.Read(this.sActiveState, 10, false);
			this.sLinkUrl = _is.Read(this.sLinkUrl, 11, false);
			this.sDetailUrl = _is.Read(this.sDetailUrl, 12, false);
			this.iActEndTime = _is.Read(this.iActEndTime, 13, false);
			this.lTid = _is.Read(this.lTid, 14, false);
			this.lSubid = _is.Read(this.lSubid, 15, false);
			this.lPUid = _is.Read(this.lPUid, 16, false);
			this.iSourceType = _is.Read(this.iSourceType, 17, false);
			this.iSubCnt = _is.Read(this.iSubCnt, 18, false);
			this.iScreenType = _is.Read(this.iScreenType, 19, false);
			this.bDetailUrlNeedLogin = _is.Read(this.bDetailUrlNeedLogin, 20, false);
			this.bLinkUrlNeedLogin = _is.Read(this.bLinkUrlNeedLogin, 21, false);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000035C0 File Offset: 0x000017C0
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iID, "iID");
			jceDisplayer.Display(this.sTitle, "sTitle");
			jceDisplayer.Display(this.iActBeginTime, "iActBeginTime");
			jceDisplayer.Display(this.sPicUrl, "sPicUrl");
			jceDisplayer.Display(this.sGameName, "sGameName");
			jceDisplayer.Display(this.iGameID, "iGameID");
			jceDisplayer.Display(this.sDigest, "sDigest");
			jceDisplayer.Display(this.iActButtionState, "iActButtionState");
			jceDisplayer.Display(this.iActiveState, "iActiveState");
			jceDisplayer.Display(this.sActiveState, "sActiveState");
			jceDisplayer.Display(this.sLinkUrl, "sLinkUrl");
			jceDisplayer.Display(this.sDetailUrl, "sDetailUrl");
			jceDisplayer.Display(this.iActEndTime, "iActEndTime");
			jceDisplayer.Display(this.lTid, "lTid");
			jceDisplayer.Display(this.lSubid, "lSubid");
			jceDisplayer.Display(this.lPUid, "lPUid");
			jceDisplayer.Display(this.iSourceType, "iSourceType");
			jceDisplayer.Display(this.iSubCnt, "iSubCnt");
			jceDisplayer.Display(this.iScreenType, "iScreenType");
			jceDisplayer.Display(this.bDetailUrlNeedLogin, "bDetailUrlNeedLogin");
			jceDisplayer.Display(this.bLinkUrlNeedLogin, "bLinkUrlNeedLogin");
		}

		// Token: 0x04000048 RID: 72
		private int _iID;

		// Token: 0x04000049 RID: 73
		private string _sTitle = "";

		// Token: 0x0400004A RID: 74
		private int _iActBeginTime;

		// Token: 0x0400004B RID: 75
		private string _sPicUrl = "";

		// Token: 0x0400004C RID: 76
		private string _sGameName = "";

		// Token: 0x0400004D RID: 77
		private int _iGameID;

		// Token: 0x0400004E RID: 78
		private string _sDigest = "";

		// Token: 0x0400004F RID: 79
		private int _iActButtionState;

		// Token: 0x04000050 RID: 80
		private int _iActiveState;

		// Token: 0x04000051 RID: 81
		private string _sActiveState = "";

		// Token: 0x04000052 RID: 82
		private string _sLinkUrl = "";

		// Token: 0x04000053 RID: 83
		private string _sDetailUrl = "";

		// Token: 0x04000054 RID: 84
		private int _iActEndTime;

		// Token: 0x04000055 RID: 85
		private long _lTid;

		// Token: 0x04000056 RID: 86
		private long _lSubid;

		// Token: 0x04000057 RID: 87
		private long _lPUid;

		// Token: 0x04000058 RID: 88
		private int _iSourceType;

		// Token: 0x04000059 RID: 89
		private long _iSubCnt;

		// Token: 0x0400005A RID: 90
		private int _iScreenType;

		// Token: 0x0400005B RID: 91
		private bool _bDetailUrlNeedLogin = true;

		// Token: 0x0400005C RID: 92
		private bool _bLinkUrlNeedLogin = true;
	}
}
