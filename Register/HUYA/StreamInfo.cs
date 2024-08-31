using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E7 RID: 231
	public sealed class StreamInfo : JceStruct
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000310 RID: 784 RVA: 0x0000793D File Offset: 0x00005B3D
		// (set) Token: 0x06000311 RID: 785 RVA: 0x00007945 File Offset: 0x00005B45
		public string sCdnType
		{
			get
			{
				return this._sCdnType;
			}
			set
			{
				this._sCdnType = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000312 RID: 786 RVA: 0x0000794E File Offset: 0x00005B4E
		// (set) Token: 0x06000313 RID: 787 RVA: 0x00007956 File Offset: 0x00005B56
		public int iIsMaster
		{
			get
			{
				return this._iIsMaster;
			}
			set
			{
				this._iIsMaster = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0000795F File Offset: 0x00005B5F
		// (set) Token: 0x06000315 RID: 789 RVA: 0x00007967 File Offset: 0x00005B67
		public long lChannelId
		{
			get
			{
				return this._lChannelId;
			}
			set
			{
				this._lChannelId = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00007970 File Offset: 0x00005B70
		// (set) Token: 0x06000317 RID: 791 RVA: 0x00007978 File Offset: 0x00005B78
		public long lSubChannelId
		{
			get
			{
				return this._lSubChannelId;
			}
			set
			{
				this._lSubChannelId = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000318 RID: 792 RVA: 0x00007981 File Offset: 0x00005B81
		// (set) Token: 0x06000319 RID: 793 RVA: 0x00007989 File Offset: 0x00005B89
		public long lPresenterUid
		{
			get
			{
				return this._lPresenterUid;
			}
			set
			{
				this._lPresenterUid = value;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00007992 File Offset: 0x00005B92
		// (set) Token: 0x0600031B RID: 795 RVA: 0x0000799A File Offset: 0x00005B9A
		public string sStreamName
		{
			get
			{
				return this._sStreamName;
			}
			set
			{
				this._sStreamName = value;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600031C RID: 796 RVA: 0x000079A3 File Offset: 0x00005BA3
		// (set) Token: 0x0600031D RID: 797 RVA: 0x000079AB File Offset: 0x00005BAB
		public string sFlvUrl
		{
			get
			{
				return this._sFlvUrl;
			}
			set
			{
				this._sFlvUrl = value;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600031E RID: 798 RVA: 0x000079B4 File Offset: 0x00005BB4
		// (set) Token: 0x0600031F RID: 799 RVA: 0x000079BC File Offset: 0x00005BBC
		public string sFlvUrlSuffix
		{
			get
			{
				return this._sFlvUrlSuffix;
			}
			set
			{
				this._sFlvUrlSuffix = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000320 RID: 800 RVA: 0x000079C5 File Offset: 0x00005BC5
		// (set) Token: 0x06000321 RID: 801 RVA: 0x000079CD File Offset: 0x00005BCD
		public string sFlvAntiCode
		{
			get
			{
				return this._sFlvAntiCode;
			}
			set
			{
				this._sFlvAntiCode = value;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000322 RID: 802 RVA: 0x000079D6 File Offset: 0x00005BD6
		// (set) Token: 0x06000323 RID: 803 RVA: 0x000079DE File Offset: 0x00005BDE
		public string sHlsUrl
		{
			get
			{
				return this._sHlsUrl;
			}
			set
			{
				this._sHlsUrl = value;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000324 RID: 804 RVA: 0x000079E7 File Offset: 0x00005BE7
		// (set) Token: 0x06000325 RID: 805 RVA: 0x000079EF File Offset: 0x00005BEF
		public string sHlsUrlSuffix
		{
			get
			{
				return this._sHlsUrlSuffix;
			}
			set
			{
				this._sHlsUrlSuffix = value;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000326 RID: 806 RVA: 0x000079F8 File Offset: 0x00005BF8
		// (set) Token: 0x06000327 RID: 807 RVA: 0x00007A00 File Offset: 0x00005C00
		public string sHlsAntiCode
		{
			get
			{
				return this._sHlsAntiCode;
			}
			set
			{
				this._sHlsAntiCode = value;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000328 RID: 808 RVA: 0x00007A09 File Offset: 0x00005C09
		// (set) Token: 0x06000329 RID: 809 RVA: 0x00007A11 File Offset: 0x00005C11
		public int iLineIndex
		{
			get
			{
				return this._iLineIndex;
			}
			set
			{
				this._iLineIndex = value;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00007A1A File Offset: 0x00005C1A
		// (set) Token: 0x0600032B RID: 811 RVA: 0x00007A22 File Offset: 0x00005C22
		public int iIsMultiStream
		{
			get
			{
				return this._iIsMultiStream;
			}
			set
			{
				this._iIsMultiStream = value;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00007A2B File Offset: 0x00005C2B
		// (set) Token: 0x0600032D RID: 813 RVA: 0x00007A33 File Offset: 0x00005C33
		public int iPCPriorityRate
		{
			get
			{
				return this._iPCPriorityRate;
			}
			set
			{
				this._iPCPriorityRate = value;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600032E RID: 814 RVA: 0x00007A3C File Offset: 0x00005C3C
		// (set) Token: 0x0600032F RID: 815 RVA: 0x00007A44 File Offset: 0x00005C44
		public int iWebPriorityRate
		{
			get
			{
				return this._iWebPriorityRate;
			}
			set
			{
				this._iWebPriorityRate = value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000330 RID: 816 RVA: 0x00007A4D File Offset: 0x00005C4D
		// (set) Token: 0x06000331 RID: 817 RVA: 0x00007A55 File Offset: 0x00005C55
		public int iMobilePriorityRate
		{
			get
			{
				return this._iMobilePriorityRate;
			}
			set
			{
				this._iMobilePriorityRate = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00007A5E File Offset: 0x00005C5E
		// (set) Token: 0x06000333 RID: 819 RVA: 0x00007A66 File Offset: 0x00005C66
		public List<string> vFlvIPList { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00007A6F File Offset: 0x00005C6F
		// (set) Token: 0x06000335 RID: 821 RVA: 0x00007A77 File Offset: 0x00005C77
		public int iIsP2PSupport
		{
			get
			{
				return this._iIsP2PSupport;
			}
			set
			{
				this._iIsP2PSupport = value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00007A80 File Offset: 0x00005C80
		// (set) Token: 0x06000337 RID: 823 RVA: 0x00007A88 File Offset: 0x00005C88
		public string sP2pUrl
		{
			get
			{
				return this._sP2pUrl;
			}
			set
			{
				this._sP2pUrl = value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000338 RID: 824 RVA: 0x00007A91 File Offset: 0x00005C91
		// (set) Token: 0x06000339 RID: 825 RVA: 0x00007A99 File Offset: 0x00005C99
		public string sP2pUrlSuffix
		{
			get
			{
				return this._sP2pUrlSuffix;
			}
			set
			{
				this._sP2pUrlSuffix = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600033A RID: 826 RVA: 0x00007AA2 File Offset: 0x00005CA2
		// (set) Token: 0x0600033B RID: 827 RVA: 0x00007AAA File Offset: 0x00005CAA
		public string sP2pAntiCode
		{
			get
			{
				return this._sP2pAntiCode;
			}
			set
			{
				this._sP2pAntiCode = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00007AB3 File Offset: 0x00005CB3
		// (set) Token: 0x0600033D RID: 829 RVA: 0x00007ABB File Offset: 0x00005CBB
		public long lFreeFlag
		{
			get
			{
				return this._lFreeFlag;
			}
			set
			{
				this._lFreeFlag = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00007AC4 File Offset: 0x00005CC4
		// (set) Token: 0x0600033F RID: 831 RVA: 0x00007ACC File Offset: 0x00005CCC
		public int iIsHEVCSupport
		{
			get
			{
				return this._iIsHEVCSupport;
			}
			set
			{
				this._iIsHEVCSupport = value;
			}
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00007AD8 File Offset: 0x00005CD8
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.sCdnType, 0, false);
			_os.Write(this.iIsMaster, 1);
			_os.Write(this.lChannelId, 2);
			_os.Write(this.lSubChannelId, 3);
			_os.Write(this.lPresenterUid, 4);
			_os.Write(this.sStreamName, 5, false);
			_os.Write(this.sFlvUrl, 6, false);
			_os.Write(this.sFlvUrlSuffix, 7, false);
			_os.Write(this.sFlvAntiCode, 8, false);
			_os.Write(this.sHlsUrl, 9, false);
			_os.Write(this.sHlsUrlSuffix, 10, false);
			_os.Write(this.sHlsAntiCode, 11, false);
			_os.Write(this.iLineIndex, 12);
			_os.Write(this.iIsMultiStream, 13);
			_os.Write(this.iPCPriorityRate, 14);
			_os.Write(this.iWebPriorityRate, 15);
			_os.Write(this.iMobilePriorityRate, 16);
			_os.Write(this.vFlvIPList, 17);
			_os.Write(this.iIsP2PSupport, 18);
			_os.Write(this.sP2pUrl, 19, false);
			_os.Write(this.sP2pUrlSuffix, 20, false);
			_os.Write(this.sP2pAntiCode, 21, false);
			_os.Write(this.lFreeFlag, 22);
			_os.Write(this.iIsHEVCSupport, 23);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00007C38 File Offset: 0x00005E38
		public override void ReadFrom(JceInputStream _is)
		{
			this.sCdnType = _is.Read(this.sCdnType, 0, false);
			this.iIsMaster = _is.Read(this.iIsMaster, 1, false);
			this.lChannelId = _is.Read(this.lChannelId, 2, false);
			this.lSubChannelId = _is.Read(this.lSubChannelId, 3, false);
			this.lPresenterUid = _is.Read(this.lPresenterUid, 4, false);
			this.sStreamName = _is.Read(this.sStreamName, 5, false);
			this.sFlvUrl = _is.Read(this.sFlvUrl, 6, false);
			this.sFlvUrlSuffix = _is.Read(this.sFlvUrlSuffix, 7, false);
			this.sFlvAntiCode = _is.Read(this.sFlvAntiCode, 8, false);
			this.sHlsUrl = _is.Read(this.sHlsUrl, 9, false);
			this.sHlsUrlSuffix = _is.Read(this.sHlsUrlSuffix, 10, false);
			this.sHlsAntiCode = _is.Read(this.sHlsAntiCode, 11, false);
			this.iLineIndex = _is.Read(this.iLineIndex, 12, false);
			this.iIsMultiStream = _is.Read(this.iIsMultiStream, 13, false);
			this.iPCPriorityRate = _is.Read(this.iPCPriorityRate, 14, false);
			this.iWebPriorityRate = _is.Read(this.iWebPriorityRate, 15, false);
			this.iMobilePriorityRate = _is.Read(this.iMobilePriorityRate, 16, false);
			this.vFlvIPList = (List<string>)_is.Read<List<string>>(this.vFlvIPList, 17, false);
			this.iIsP2PSupport = _is.Read(this.iIsP2PSupport, 18, false);
			this.sP2pUrl = _is.Read(this.sP2pUrl, 19, false);
			this.sP2pUrlSuffix = _is.Read(this.sP2pUrlSuffix, 20, false);
			this.sP2pAntiCode = _is.Read(this.sP2pAntiCode, 21, false);
			this.lFreeFlag = _is.Read(this.lFreeFlag, 22, false);
			this.iIsHEVCSupport = _is.Read(this.iIsHEVCSupport, 23, false);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00007E3C File Offset: 0x0000603C
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.sCdnType, "sCdnType");
			jceDisplayer.Display(this.iIsMaster, "iIsMaster");
			jceDisplayer.Display(this.lChannelId, "lChannelId");
			jceDisplayer.Display(this.lSubChannelId, "lSubChannelId");
			jceDisplayer.Display(this.lPresenterUid, "lPresenterUid");
			jceDisplayer.Display(this.sStreamName, "sStreamName");
			jceDisplayer.Display(this.sFlvUrl, "sFlvUrl");
			jceDisplayer.Display(this.sFlvUrlSuffix, "sFlvUrlSuffix");
			jceDisplayer.Display(this.sFlvAntiCode, "sFlvAntiCode");
			jceDisplayer.Display(this.sHlsUrl, "sHlsUrl");
			jceDisplayer.Display(this.sHlsUrlSuffix, "sHlsUrlSuffix");
			jceDisplayer.Display(this.sHlsAntiCode, "sHlsAntiCode");
			jceDisplayer.Display(this.iLineIndex, "iLineIndex");
			jceDisplayer.Display(this.iIsMultiStream, "iIsMultiStream");
			jceDisplayer.Display(this.iPCPriorityRate, "iPCPriorityRate");
			jceDisplayer.Display(this.iWebPriorityRate, "iWebPriorityRate");
			jceDisplayer.Display(this.iMobilePriorityRate, "iMobilePriorityRate");
			jceDisplayer.Display<string>(this.vFlvIPList, "vFlvIPList");
			jceDisplayer.Display(this.iIsP2PSupport, "iIsP2PSupport");
			jceDisplayer.Display(this.sP2pUrl, "sP2pUrl");
			jceDisplayer.Display(this.sP2pUrlSuffix, "sP2pUrlSuffix");
			jceDisplayer.Display(this.sP2pAntiCode, "sP2pAntiCode");
			jceDisplayer.Display(this.lFreeFlag, "lFreeFlag");
			jceDisplayer.Display(this.iIsHEVCSupport, "iIsHEVCSupport");
		}

		// Token: 0x040007A0 RID: 1952
		private string _sCdnType = "";

		// Token: 0x040007A1 RID: 1953
		private int _iIsMaster;

		// Token: 0x040007A2 RID: 1954
		private long _lChannelId;

		// Token: 0x040007A3 RID: 1955
		private long _lSubChannelId;

		// Token: 0x040007A4 RID: 1956
		private long _lPresenterUid;

		// Token: 0x040007A5 RID: 1957
		private string _sStreamName = "";

		// Token: 0x040007A6 RID: 1958
		private string _sFlvUrl = "";

		// Token: 0x040007A7 RID: 1959
		private string _sFlvUrlSuffix = "";

		// Token: 0x040007A8 RID: 1960
		private string _sFlvAntiCode = "";

		// Token: 0x040007A9 RID: 1961
		private string _sHlsUrl = "";

		// Token: 0x040007AA RID: 1962
		private string _sHlsUrlSuffix = "";

		// Token: 0x040007AB RID: 1963
		private string _sHlsAntiCode = "";

		// Token: 0x040007AC RID: 1964
		private int _iLineIndex;

		// Token: 0x040007AD RID: 1965
		private int _iIsMultiStream;

		// Token: 0x040007AE RID: 1966
		private int _iPCPriorityRate;

		// Token: 0x040007AF RID: 1967
		private int _iWebPriorityRate;

		// Token: 0x040007B0 RID: 1968
		private int _iMobilePriorityRate;

		// Token: 0x040007B2 RID: 1970
		private int _iIsP2PSupport;

		// Token: 0x040007B3 RID: 1971
		private string _sP2pUrl = "";

		// Token: 0x040007B4 RID: 1972
		private string _sP2pUrlSuffix = "";

		// Token: 0x040007B5 RID: 1973
		private string _sP2pAntiCode = "";

		// Token: 0x040007B6 RID: 1974
		private long _lFreeFlag;

		// Token: 0x040007B7 RID: 1975
		private int _iIsHEVCSupport;
	}
}
