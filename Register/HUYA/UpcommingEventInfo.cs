using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E9 RID: 233
	public sealed class UpcommingEventInfo : JceStruct
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000354 RID: 852 RVA: 0x0000826A File Offset: 0x0000646A
		// (set) Token: 0x06000355 RID: 853 RVA: 0x00008272 File Offset: 0x00006472
		public int iEventID
		{
			get
			{
				return this._iEventID;
			}
			set
			{
				this._iEventID = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000356 RID: 854 RVA: 0x0000827B File Offset: 0x0000647B
		// (set) Token: 0x06000357 RID: 855 RVA: 0x00008283 File Offset: 0x00006483
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

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000358 RID: 856 RVA: 0x0000828C File Offset: 0x0000648C
		// (set) Token: 0x06000359 RID: 857 RVA: 0x00008294 File Offset: 0x00006494
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

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0000829D File Offset: 0x0000649D
		// (set) Token: 0x0600035B RID: 859 RVA: 0x000082A5 File Offset: 0x000064A5
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

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600035C RID: 860 RVA: 0x000082AE File Offset: 0x000064AE
		// (set) Token: 0x0600035D RID: 861 RVA: 0x000082B6 File Offset: 0x000064B6
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

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600035E RID: 862 RVA: 0x000082BF File Offset: 0x000064BF
		// (set) Token: 0x0600035F RID: 863 RVA: 0x000082C7 File Offset: 0x000064C7
		public string sClickUrl
		{
			get
			{
				return this._sClickUrl;
			}
			set
			{
				this._sClickUrl = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000360 RID: 864 RVA: 0x000082D0 File Offset: 0x000064D0
		// (set) Token: 0x06000361 RID: 865 RVA: 0x000082D8 File Offset: 0x000064D8
		public int iLiveState
		{
			get
			{
				return this._iLiveState;
			}
			set
			{
				this._iLiveState = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000362 RID: 866 RVA: 0x000082E1 File Offset: 0x000064E1
		// (set) Token: 0x06000363 RID: 867 RVA: 0x000082E9 File Offset: 0x000064E9
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

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000364 RID: 868 RVA: 0x000082F2 File Offset: 0x000064F2
		// (set) Token: 0x06000365 RID: 869 RVA: 0x000082FA File Offset: 0x000064FA
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

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000366 RID: 870 RVA: 0x00008303 File Offset: 0x00006503
		// (set) Token: 0x06000367 RID: 871 RVA: 0x0000830B File Offset: 0x0000650B
		public bool bSubscribe
		{
			get
			{
				return this._bSubscribe;
			}
			set
			{
				this._bSubscribe = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000368 RID: 872 RVA: 0x00008314 File Offset: 0x00006514
		// (set) Token: 0x06000369 RID: 873 RVA: 0x0000831C File Offset: 0x0000651C
		public int iUpTime
		{
			get
			{
				return this._iUpTime;
			}
			set
			{
				this._iUpTime = value;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00008325 File Offset: 0x00006525
		// (set) Token: 0x0600036B RID: 875 RVA: 0x0000832D File Offset: 0x0000652D
		public int iDownTime
		{
			get
			{
				return this._iDownTime;
			}
			set
			{
				this._iDownTime = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00008336 File Offset: 0x00006536
		// (set) Token: 0x0600036D RID: 877 RVA: 0x0000833E File Offset: 0x0000653E
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

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00008347 File Offset: 0x00006547
		// (set) Token: 0x0600036F RID: 879 RVA: 0x0000834F File Offset: 0x0000654F
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

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00008358 File Offset: 0x00006558
		// (set) Token: 0x06000371 RID: 881 RVA: 0x00008360 File Offset: 0x00006560
		public string sShareUrl
		{
			get
			{
				return this._sShareUrl;
			}
			set
			{
				this._sShareUrl = value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000372 RID: 882 RVA: 0x00008369 File Offset: 0x00006569
		// (set) Token: 0x06000373 RID: 883 RVA: 0x00008371 File Offset: 0x00006571
		public string sShareImage
		{
			get
			{
				return this._sShareImage;
			}
			set
			{
				this._sShareImage = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000374 RID: 884 RVA: 0x0000837A File Offset: 0x0000657A
		// (set) Token: 0x06000375 RID: 885 RVA: 0x00008382 File Offset: 0x00006582
		public string sNickName
		{
			get
			{
				return this._sNickName;
			}
			set
			{
				this._sNickName = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000376 RID: 886 RVA: 0x0000838B File Offset: 0x0000658B
		// (set) Token: 0x06000377 RID: 887 RVA: 0x00008393 File Offset: 0x00006593
		public string sAvatarUrl
		{
			get
			{
				return this._sAvatarUrl;
			}
			set
			{
				this._sAvatarUrl = value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0000839C File Offset: 0x0000659C
		// (set) Token: 0x06000379 RID: 889 RVA: 0x000083A4 File Offset: 0x000065A4
		public string sLiveDesc
		{
			get
			{
				return this._sLiveDesc;
			}
			set
			{
				this._sLiveDesc = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600037A RID: 890 RVA: 0x000083AD File Offset: 0x000065AD
		// (set) Token: 0x0600037B RID: 891 RVA: 0x000083B5 File Offset: 0x000065B5
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

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600037C RID: 892 RVA: 0x000083BE File Offset: 0x000065BE
		// (set) Token: 0x0600037D RID: 893 RVA: 0x000083C6 File Offset: 0x000065C6
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

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600037E RID: 894 RVA: 0x000083CF File Offset: 0x000065CF
		// (set) Token: 0x0600037F RID: 895 RVA: 0x000083D7 File Offset: 0x000065D7
		public string sActiveStatus
		{
			get
			{
				return this._sActiveStatus;
			}
			set
			{
				this._sActiveStatus = value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000380 RID: 896 RVA: 0x000083E0 File Offset: 0x000065E0
		// (set) Token: 0x06000381 RID: 897 RVA: 0x000083E8 File Offset: 0x000065E8
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

		// Token: 0x06000382 RID: 898 RVA: 0x000083F4 File Offset: 0x000065F4
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iEventID, 0);
			_os.Write(this.iSubCnt, 1);
			_os.Write(this.sTitle, 2, false);
			_os.Write(this.sDigest, 3, false);
			_os.Write(this.sPicUrl, 4, false);
			_os.Write(this.sClickUrl, 5, false);
			_os.Write(this.iLiveState, 6);
			_os.Write(this.lTid, 7);
			_os.Write(this.lSubid, 8);
			_os.Write(this.bSubscribe, 9);
			_os.Write(this.iUpTime, 10);
			_os.Write(this.iDownTime, 11);
			_os.Write(this.lPUid, 12);
			_os.Write(this.iSourceType, 13);
			_os.Write(this.sShareUrl, 14, false);
			_os.Write(this.sShareImage, 15, false);
			_os.Write(this.sNickName, 16, false);
			_os.Write(this.sAvatarUrl, 17, false);
			_os.Write(this.sLiveDesc, 18, false);
			_os.Write(this.sGameName, 19, false);
			_os.Write(this.iGameID, 20);
			_os.Write(this.sActiveStatus, 21, false);
			_os.Write(this.iScreenType, 22);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00008548 File Offset: 0x00006748
		public override void ReadFrom(JceInputStream _is)
		{
			this.iEventID = _is.Read(this.iEventID, 0, false);
			this.iSubCnt = _is.Read(this.iSubCnt, 1, false);
			this.sTitle = _is.Read(this.sTitle, 2, false);
			this.sDigest = _is.Read(this.sDigest, 3, false);
			this.sPicUrl = _is.Read(this.sPicUrl, 4, false);
			this.sClickUrl = _is.Read(this.sClickUrl, 5, false);
			this.iLiveState = _is.Read(this.iLiveState, 6, false);
			this.lTid = _is.Read(this.lTid, 7, false);
			this.lSubid = _is.Read(this.lSubid, 8, false);
			this.bSubscribe = _is.Read(this.bSubscribe, 9, false);
			this.iUpTime = _is.Read(this.iUpTime, 10, false);
			this.iDownTime = _is.Read(this.iDownTime, 11, false);
			this.lPUid = _is.Read(this.lPUid, 12, false);
			this.iSourceType = _is.Read(this.iSourceType, 13, false);
			this.sShareUrl = _is.Read(this.sShareUrl, 14, false);
			this.sShareImage = _is.Read(this.sShareImage, 15, false);
			this.sNickName = _is.Read(this.sNickName, 16, false);
			this.sAvatarUrl = _is.Read(this.sAvatarUrl, 17, false);
			this.sLiveDesc = _is.Read(this.sLiveDesc, 18, false);
			this.sGameName = _is.Read(this.sGameName, 19, false);
			this.iGameID = _is.Read(this.iGameID, 20, false);
			this.sActiveStatus = _is.Read(this.sActiveStatus, 21, false);
			this.iScreenType = _is.Read(this.iScreenType, 22, false);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00008730 File Offset: 0x00006930
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iEventID, "iEventID");
			jceDisplayer.Display(this.iSubCnt, "iSubCnt");
			jceDisplayer.Display(this.sTitle, "sTitle");
			jceDisplayer.Display(this.sDigest, "sDigest");
			jceDisplayer.Display(this.sPicUrl, "sPicUrl");
			jceDisplayer.Display(this.sClickUrl, "sClickUrl");
			jceDisplayer.Display(this.iLiveState, "iLiveState");
			jceDisplayer.Display(this.lTid, "lTid");
			jceDisplayer.Display(this.lSubid, "lSubid");
			jceDisplayer.Display(this.bSubscribe, "bSubscribe");
			jceDisplayer.Display(this.iUpTime, "iUpTime");
			jceDisplayer.Display(this.iDownTime, "iDownTime");
			jceDisplayer.Display(this.lPUid, "lPUid");
			jceDisplayer.Display(this.iSourceType, "iSourceType");
			jceDisplayer.Display(this.sShareUrl, "sShareUrl");
			jceDisplayer.Display(this.sShareImage, "sShareImage");
			jceDisplayer.Display(this.sNickName, "sNickName");
			jceDisplayer.Display(this.sAvatarUrl, "sAvatarUrl");
			jceDisplayer.Display(this.sLiveDesc, "sLiveDesc");
			jceDisplayer.Display(this.sGameName, "sGameName");
			jceDisplayer.Display(this.iGameID, "iGameID");
			jceDisplayer.Display(this.sActiveStatus, "sActiveStatus");
			jceDisplayer.Display(this.iScreenType, "iScreenType");
		}

		// Token: 0x040007BE RID: 1982
		private int _iEventID;

		// Token: 0x040007BF RID: 1983
		private long _iSubCnt;

		// Token: 0x040007C0 RID: 1984
		private string _sTitle = "";

		// Token: 0x040007C1 RID: 1985
		private string _sDigest = "";

		// Token: 0x040007C2 RID: 1986
		private string _sPicUrl = "";

		// Token: 0x040007C3 RID: 1987
		private string _sClickUrl = "";

		// Token: 0x040007C4 RID: 1988
		private int _iLiveState;

		// Token: 0x040007C5 RID: 1989
		private long _lTid;

		// Token: 0x040007C6 RID: 1990
		private long _lSubid;

		// Token: 0x040007C7 RID: 1991
		private bool _bSubscribe;

		// Token: 0x040007C8 RID: 1992
		private int _iUpTime;

		// Token: 0x040007C9 RID: 1993
		private int _iDownTime;

		// Token: 0x040007CA RID: 1994
		private long _lPUid;

		// Token: 0x040007CB RID: 1995
		private int _iSourceType;

		// Token: 0x040007CC RID: 1996
		private string _sShareUrl = "";

		// Token: 0x040007CD RID: 1997
		private string _sShareImage = "";

		// Token: 0x040007CE RID: 1998
		private string _sNickName = "";

		// Token: 0x040007CF RID: 1999
		private string _sAvatarUrl = "";

		// Token: 0x040007D0 RID: 2000
		private string _sLiveDesc = "";

		// Token: 0x040007D1 RID: 2001
		private string _sGameName = "";

		// Token: 0x040007D2 RID: 2002
		private int _iGameID;

		// Token: 0x040007D3 RID: 2003
		private string _sActiveStatus = "";

		// Token: 0x040007D4 RID: 2004
		private int _iScreenType;
	}
}
