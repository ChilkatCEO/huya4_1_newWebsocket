using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000EA RID: 234
	public sealed class UserBase : JceStruct
	{
		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00008970 File Offset: 0x00006B70
		// (set) Token: 0x06000387 RID: 903 RVA: 0x00008978 File Offset: 0x00006B78
		public long lUid
		{
			get
			{
				return this._lUid;
			}
			set
			{
				this._lUid = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00008981 File Offset: 0x00006B81
		// (set) Token: 0x06000389 RID: 905 RVA: 0x00008989 File Offset: 0x00006B89
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

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00008992 File Offset: 0x00006B92
		// (set) Token: 0x0600038B RID: 907 RVA: 0x0000899A File Offset: 0x00006B9A
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

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600038C RID: 908 RVA: 0x000089A3 File Offset: 0x00006BA3
		// (set) Token: 0x0600038D RID: 909 RVA: 0x000089AB File Offset: 0x00006BAB
		public int iGender
		{
			get
			{
				return this._iGender;
			}
			set
			{
				this._iGender = value;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600038E RID: 910 RVA: 0x000089B4 File Offset: 0x00006BB4
		// (set) Token: 0x0600038F RID: 911 RVA: 0x000089BC File Offset: 0x00006BBC
		public long lYYId
		{
			get
			{
				return this._lYYId;
			}
			set
			{
				this._lYYId = value;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000390 RID: 912 RVA: 0x000089C5 File Offset: 0x00006BC5
		// (set) Token: 0x06000391 RID: 913 RVA: 0x000089CD File Offset: 0x00006BCD
		public int iCertified
		{
			get
			{
				return this._iCertified;
			}
			set
			{
				this._iCertified = value;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000392 RID: 914 RVA: 0x000089D6 File Offset: 0x00006BD6
		// (set) Token: 0x06000393 RID: 915 RVA: 0x000089DE File Offset: 0x00006BDE
		public int iSubscribedCount
		{
			get
			{
				return this._iSubscribedCount;
			}
			set
			{
				this._iSubscribedCount = value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000394 RID: 916 RVA: 0x000089E7 File Offset: 0x00006BE7
		// (set) Token: 0x06000395 RID: 917 RVA: 0x000089EF File Offset: 0x00006BEF
		public int iSubscribeToCount
		{
			get
			{
				return this._iSubscribeToCount;
			}
			set
			{
				this._iSubscribeToCount = value;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000396 RID: 918 RVA: 0x000089F8 File Offset: 0x00006BF8
		// (set) Token: 0x06000397 RID: 919 RVA: 0x00008A00 File Offset: 0x00006C00
		public int iUserLevel
		{
			get
			{
				return this._iUserLevel;
			}
			set
			{
				this._iUserLevel = value;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00008A09 File Offset: 0x00006C09
		// (set) Token: 0x06000399 RID: 921 RVA: 0x00008A11 File Offset: 0x00006C11
		public long lUserExp
		{
			get
			{
				return this._lUserExp;
			}
			set
			{
				this._lUserExp = value;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00008A1A File Offset: 0x00006C1A
		// (set) Token: 0x0600039B RID: 923 RVA: 0x00008A22 File Offset: 0x00006C22
		public int iBirthday
		{
			get
			{
				return this._iBirthday;
			}
			set
			{
				this._iBirthday = value;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00008A2B File Offset: 0x00006C2B
		// (set) Token: 0x0600039D RID: 925 RVA: 0x00008A33 File Offset: 0x00006C33
		public string sSign
		{
			get
			{
				return this._sSign;
			}
			set
			{
				this._sSign = value;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00008A3C File Offset: 0x00006C3C
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00008A44 File Offset: 0x00006C44
		public string sArea
		{
			get
			{
				return this._sArea;
			}
			set
			{
				this._sArea = value;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00008A4D File Offset: 0x00006C4D
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x00008A55 File Offset: 0x00006C55
		public string sLocation
		{
			get
			{
				return this._sLocation;
			}
			set
			{
				this._sLocation = value;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00008A5E File Offset: 0x00006C5E
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x00008A66 File Offset: 0x00006C66
		public string sRegisterTime
		{
			get
			{
				return this._sRegisterTime;
			}
			set
			{
				this._sRegisterTime = value;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00008A6F File Offset: 0x00006C6F
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00008A77 File Offset: 0x00006C77
		public int iFreezeTime
		{
			get
			{
				return this._iFreezeTime;
			}
			set
			{
				this._iFreezeTime = value;
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00008A80 File Offset: 0x00006C80
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lUid, 0);
			_os.Write(this.sNickName, 1, false);
			_os.Write(this.sAvatarUrl, 2, false);
			_os.Write(this.iGender, 3);
			_os.Write(this.lYYId, 4);
			_os.Write(this.iCertified, 5);
			_os.Write(this.iSubscribedCount, 6);
			_os.Write(this.iSubscribeToCount, 7);
			_os.Write(this.iUserLevel, 8);
			_os.Write(this.lUserExp, 9);
			_os.Write(this.iBirthday, 10);
			_os.Write(this.sSign, 11, false);
			_os.Write(this.sArea, 12, false);
			_os.Write(this.sLocation, 13, false);
			_os.Write(this.sRegisterTime, 14, false);
			_os.Write(this.iFreezeTime, 15);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00008B6C File Offset: 0x00006D6C
		public override void ReadFrom(JceInputStream _is)
		{
			this.lUid = _is.Read(this.lUid, 0, false);
			this.sNickName = _is.Read(this.sNickName, 1, false);
			this.sAvatarUrl = _is.Read(this.sAvatarUrl, 2, false);
			this.iGender = _is.Read(this.iGender, 3, false);
			this.lYYId = _is.Read(this.lYYId, 4, false);
			this.iCertified = _is.Read(this.iCertified, 5, false);
			this.iSubscribedCount = _is.Read(this.iSubscribedCount, 6, false);
			this.iSubscribeToCount = _is.Read(this.iSubscribeToCount, 7, false);
			this.iUserLevel = _is.Read(this.iUserLevel, 8, false);
			this.lUserExp = _is.Read(this.lUserExp, 9, false);
			this.iBirthday = _is.Read(this.iBirthday, 10, false);
			this.sSign = _is.Read(this.sSign, 11, false);
			this.sArea = _is.Read(this.sArea, 12, false);
			this.sLocation = _is.Read(this.sLocation, 13, false);
			this.sRegisterTime = _is.Read(this.sRegisterTime, 14, false);
			this.iFreezeTime = _is.Read(this.iFreezeTime, 15, false);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00008CC0 File Offset: 0x00006EC0
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lUid, "lUid");
			jceDisplayer.Display(this.sNickName, "sNickName");
			jceDisplayer.Display(this.sAvatarUrl, "sAvatarUrl");
			jceDisplayer.Display(this.iGender, "iGender");
			jceDisplayer.Display(this.lYYId, "lYYId");
			jceDisplayer.Display(this.iCertified, "iCertified");
			jceDisplayer.Display(this.iSubscribedCount, "iSubscribedCount");
			jceDisplayer.Display(this.iSubscribeToCount, "iSubscribeToCount");
			jceDisplayer.Display(this.iUserLevel, "iUserLevel");
			jceDisplayer.Display(this.lUserExp, "lUserExp");
			jceDisplayer.Display(this.iBirthday, "iBirthday");
			jceDisplayer.Display(this.sSign, "sSign");
			jceDisplayer.Display(this.sArea, "sArea");
			jceDisplayer.Display(this.sLocation, "sLocation");
			jceDisplayer.Display(this.sRegisterTime, "sRegisterTime");
			jceDisplayer.Display(this.iFreezeTime, "iFreezeTime");
		}

		// Token: 0x040007D5 RID: 2005
		private long _lUid;

		// Token: 0x040007D6 RID: 2006
		private string _sNickName = "";

		// Token: 0x040007D7 RID: 2007
		private string _sAvatarUrl = "";

		// Token: 0x040007D8 RID: 2008
		private int _iGender;

		// Token: 0x040007D9 RID: 2009
		private long _lYYId;

		// Token: 0x040007DA RID: 2010
		private int _iCertified;

		// Token: 0x040007DB RID: 2011
		private int _iSubscribedCount;

		// Token: 0x040007DC RID: 2012
		private int _iSubscribeToCount;

		// Token: 0x040007DD RID: 2013
		private int _iUserLevel;

		// Token: 0x040007DE RID: 2014
		private long _lUserExp;

		// Token: 0x040007DF RID: 2015
		private int _iBirthday;

		// Token: 0x040007E0 RID: 2016
		private string _sSign = "";

		// Token: 0x040007E1 RID: 2017
		private string _sArea = "";

		// Token: 0x040007E2 RID: 2018
		private string _sLocation = "";

		// Token: 0x040007E3 RID: 2019
		private string _sRegisterTime = "";

		// Token: 0x040007E4 RID: 2020
		private int _iFreezeTime;
	}
}
