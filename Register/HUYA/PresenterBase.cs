using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E6 RID: 230
	public sealed class PresenterBase : JceStruct
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0000763B File Offset: 0x0000583B
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x00007643 File Offset: 0x00005843
		public int iIsPresenter
		{
			get
			{
				return this._iIsPresenter;
			}
			set
			{
				this._iIsPresenter = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060002FA RID: 762 RVA: 0x0000764C File Offset: 0x0000584C
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00007654 File Offset: 0x00005854
		public string sPresenterName
		{
			get
			{
				return this._sPresenterName;
			}
			set
			{
				this._sPresenterName = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060002FC RID: 764 RVA: 0x0000765D File Offset: 0x0000585D
		// (set) Token: 0x060002FD RID: 765 RVA: 0x00007665 File Offset: 0x00005865
		public long lSignedChannel
		{
			get
			{
				return this._lSignedChannel;
			}
			set
			{
				this._lSignedChannel = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0000766E File Offset: 0x0000586E
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00007676 File Offset: 0x00005876
		public string sPrivateHost
		{
			get
			{
				return this._sPrivateHost;
			}
			set
			{
				this._sPrivateHost = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000767F File Offset: 0x0000587F
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00007687 File Offset: 0x00005887
		public int iRecType
		{
			get
			{
				return this._iRecType;
			}
			set
			{
				this._iRecType = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00007690 File Offset: 0x00005890
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00007698 File Offset: 0x00005898
		public int iFreeze
		{
			get
			{
				return this._iFreeze;
			}
			set
			{
				this._iFreeze = value;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000304 RID: 772 RVA: 0x000076A1 File Offset: 0x000058A1
		// (set) Token: 0x06000305 RID: 773 RVA: 0x000076A9 File Offset: 0x000058A9
		public int iPresenterLevel
		{
			get
			{
				return this._iPresenterLevel;
			}
			set
			{
				this._iPresenterLevel = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000306 RID: 774 RVA: 0x000076B2 File Offset: 0x000058B2
		// (set) Token: 0x06000307 RID: 775 RVA: 0x000076BA File Offset: 0x000058BA
		public long lPresenterExp
		{
			get
			{
				return this._lPresenterExp;
			}
			set
			{
				this._lPresenterExp = value;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000308 RID: 776 RVA: 0x000076C3 File Offset: 0x000058C3
		// (set) Token: 0x06000309 RID: 777 RVA: 0x000076CB File Offset: 0x000058CB
		public List<GameBaseInfo> vPresentedGames { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600030A RID: 778 RVA: 0x000076D4 File Offset: 0x000058D4
		// (set) Token: 0x0600030B RID: 779 RVA: 0x000076DC File Offset: 0x000058DC
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

		// Token: 0x0600030C RID: 780 RVA: 0x000076E8 File Offset: 0x000058E8
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iIsPresenter, 0);
			_os.Write(this.sPresenterName, 1, false);
			_os.Write(this.lSignedChannel, 2);
			_os.Write(this.sPrivateHost, 3, false);
			_os.Write(this.iRecType, 4);
			_os.Write(this.iFreeze, 5);
			_os.Write(this.iPresenterLevel, 6);
			_os.Write(this.lPresenterExp, 7);
			_os.Write(this.vPresentedGames, 8);
			_os.Write(this.iCertified, 9);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000777C File Offset: 0x0000597C
		public override void ReadFrom(JceInputStream _is)
		{
			this.iIsPresenter = _is.Read(this.iIsPresenter, 0, false);
			this.sPresenterName = _is.Read(this.sPresenterName, 1, false);
			this.lSignedChannel = _is.Read(this.lSignedChannel, 2, false);
			this.sPrivateHost = _is.Read(this.sPrivateHost, 3, false);
			this.iRecType = _is.Read(this.iRecType, 4, false);
			this.iFreeze = _is.Read(this.iFreeze, 5, false);
			this.iPresenterLevel = _is.Read(this.iPresenterLevel, 6, false);
			this.lPresenterExp = _is.Read(this.lPresenterExp, 7, false);
			this.vPresentedGames = (List<GameBaseInfo>)_is.Read<List<GameBaseInfo>>(this.vPresentedGames, 8, false);
			this.iCertified = _is.Read(this.iCertified, 9, false);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00007858 File Offset: 0x00005A58
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iIsPresenter, "iIsPresenter");
			jceDisplayer.Display(this.sPresenterName, "sPresenterName");
			jceDisplayer.Display(this.lSignedChannel, "lSignedChannel");
			jceDisplayer.Display(this.sPrivateHost, "sPrivateHost");
			jceDisplayer.Display(this.iRecType, "iRecType");
			jceDisplayer.Display(this.iFreeze, "iFreeze");
			jceDisplayer.Display(this.iPresenterLevel, "iPresenterLevel");
			jceDisplayer.Display(this.lPresenterExp, "lPresenterExp");
			jceDisplayer.Display<GameBaseInfo>(this.vPresentedGames, "vPresentedGames");
			jceDisplayer.Display(this.iCertified, "iCertified");
		}

		// Token: 0x04000796 RID: 1942
		private int _iIsPresenter;

		// Token: 0x04000797 RID: 1943
		private string _sPresenterName = "";

		// Token: 0x04000798 RID: 1944
		private long _lSignedChannel;

		// Token: 0x04000799 RID: 1945
		private string _sPrivateHost = "";

		// Token: 0x0400079A RID: 1946
		private int _iRecType;

		// Token: 0x0400079B RID: 1947
		private int _iFreeze;

		// Token: 0x0400079C RID: 1948
		private int _iPresenterLevel;

		// Token: 0x0400079D RID: 1949
		private long _lPresenterExp;

		// Token: 0x0400079F RID: 1951
		private int _iCertified;
	}
}
