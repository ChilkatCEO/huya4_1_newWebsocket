using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E0 RID: 224
	public sealed class LMPresenterInfo : JceStruct
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000290 RID: 656 RVA: 0x000069CC File Offset: 0x00004BCC
		// (set) Token: 0x06000291 RID: 657 RVA: 0x000069D4 File Offset: 0x00004BD4
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

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000292 RID: 658 RVA: 0x000069DD File Offset: 0x00004BDD
		// (set) Token: 0x06000293 RID: 659 RVA: 0x000069E5 File Offset: 0x00004BE5
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

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000294 RID: 660 RVA: 0x000069EE File Offset: 0x00004BEE
		// (set) Token: 0x06000295 RID: 661 RVA: 0x000069F6 File Offset: 0x00004BF6
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

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000296 RID: 662 RVA: 0x000069FF File Offset: 0x00004BFF
		// (set) Token: 0x06000297 RID: 663 RVA: 0x00006A07 File Offset: 0x00004C07
		public string sNick
		{
			get
			{
				return this._sNick;
			}
			set
			{
				this._sNick = value;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00006A10 File Offset: 0x00004C10
		// (set) Token: 0x06000299 RID: 665 RVA: 0x00006A18 File Offset: 0x00004C18
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

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00006A21 File Offset: 0x00004C21
		// (set) Token: 0x0600029B RID: 667 RVA: 0x00006A29 File Offset: 0x00004C29
		public int iActivityCount
		{
			get
			{
				return this._iActivityCount;
			}
			set
			{
				this._iActivityCount = value;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00006A32 File Offset: 0x00004C32
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00006A3A File Offset: 0x00004C3A
		public int iLevel
		{
			get
			{
				return this._iLevel;
			}
			set
			{
				this._iLevel = value;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600029E RID: 670 RVA: 0x00006A43 File Offset: 0x00004C43
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00006A4B File Offset: 0x00004C4B
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

		// Token: 0x060002A0 RID: 672 RVA: 0x00006A54 File Offset: 0x00004C54
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lUid, 0);
			_os.Write(this.lChannelId, 1);
			_os.Write(this.lSubChannelId, 2);
			_os.Write(this.sNick, 3, false);
			_os.Write(this.sAvatarUrl, 4, false);
			_os.Write(this.iActivityCount, 5);
			_os.Write(this.iLevel, 6);
			_os.Write(this.lYYId, 7);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00006ACC File Offset: 0x00004CCC
		public override void ReadFrom(JceInputStream _is)
		{
			this.lUid = _is.Read(this.lUid, 0, false);
			this.lChannelId = _is.Read(this.lChannelId, 1, false);
			this.lSubChannelId = _is.Read(this.lSubChannelId, 2, false);
			this.sNick = _is.Read(this.sNick, 3, false);
			this.sAvatarUrl = _is.Read(this.sAvatarUrl, 4, false);
			this.iActivityCount = _is.Read(this.iActivityCount, 5, false);
			this.iLevel = _is.Read(this.iLevel, 6, false);
			this.lYYId = _is.Read(this.lYYId, 7, false);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00006B7C File Offset: 0x00004D7C
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lUid, "lUid");
			jceDisplayer.Display(this.lChannelId, "lChannelId");
			jceDisplayer.Display(this.lSubChannelId, "lSubChannelId");
			jceDisplayer.Display(this.sNick, "sNick");
			jceDisplayer.Display(this.sAvatarUrl, "sAvatarUrl");
			jceDisplayer.Display(this.iActivityCount, "iActivityCount");
			jceDisplayer.Display(this.iLevel, "iLevel");
			jceDisplayer.Display(this.lYYId, "lYYId");
		}

		// Token: 0x0400076E RID: 1902
		private long _lUid;

		// Token: 0x0400076F RID: 1903
		private long _lChannelId;

		// Token: 0x04000770 RID: 1904
		private long _lSubChannelId;

		// Token: 0x04000771 RID: 1905
		private string _sNick = "";

		// Token: 0x04000772 RID: 1906
		private string _sAvatarUrl = "";

		// Token: 0x04000773 RID: 1907
		private int _iActivityCount;

		// Token: 0x04000774 RID: 1908
		private int _iLevel;

		// Token: 0x04000775 RID: 1909
		private long _lYYId;
	}
}
