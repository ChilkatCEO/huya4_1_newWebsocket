using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000ED RID: 237
	public sealed class UserId : JceStruct
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x000092E7 File Offset: 0x000074E7
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x000092EF File Offset: 0x000074EF
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

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x000092F8 File Offset: 0x000074F8
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x00009300 File Offset: 0x00007500
		public string sGuid
		{
			get
			{
				return this._sGuid;
			}
			set
			{
				this._sGuid = value;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x00009309 File Offset: 0x00007509
		// (set) Token: 0x060003D5 RID: 981 RVA: 0x00009311 File Offset: 0x00007511
		public string sToken
		{
			get
			{
				return this._sToken;
			}
			set
			{
				this._sToken = value;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x0000931A File Offset: 0x0000751A
		// (set) Token: 0x060003D7 RID: 983 RVA: 0x00009322 File Offset: 0x00007522
		public string sHuYaUA
		{
			get
			{
				return this._sHuYaUA;
			}
			set
			{
				this._sHuYaUA = value;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x0000932B File Offset: 0x0000752B
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00009333 File Offset: 0x00007533
		public string sCookie
		{
			get
			{
				return this._sCookie;
			}
			set
			{
				this._sCookie = value;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060003DA RID: 986 RVA: 0x0000933C File Offset: 0x0000753C
		// (set) Token: 0x060003DB RID: 987 RVA: 0x00009344 File Offset: 0x00007544
		public int iTokenType
		{
			get
			{
				return this._iTokenType;
			}
			set
			{
				this._iTokenType = value;
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00009350 File Offset: 0x00007550
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lUid, 0);
			_os.Write(this.sGuid, 1, false);
			_os.Write(this.sToken, 2, false);
			_os.Write(this.sHuYaUA, 3, false);
			_os.Write(this.sCookie, 4, false);
			_os.Write(this.iTokenType, 5);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000093B0 File Offset: 0x000075B0
		public override void ReadFrom(JceInputStream _is)
		{
			this.lUid = _is.Read(this.lUid, 0, false);
			this.sGuid = _is.Read(this.sGuid, 1, false);
			this.sToken = _is.Read(this.sToken, 2, false);
			this.sHuYaUA = _is.Read(this.sHuYaUA, 3, false);
			this.sCookie = _is.Read(this.sCookie, 4, false);
			this.iTokenType = _is.Read(this.iTokenType, 5, false);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00009438 File Offset: 0x00007638
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lUid, "lUid");
			jceDisplayer.Display(this.sGuid, "sGuid");
			jceDisplayer.Display(this.sToken, "sToken");
			jceDisplayer.Display(this.sHuYaUA, "sHuYaUA");
			jceDisplayer.Display(this.sCookie, "sCookie");
			jceDisplayer.Display(this.iTokenType, "iTokenType");
		}

		// Token: 0x040007F4 RID: 2036
		private long _lUid;

		// Token: 0x040007F5 RID: 2037
		private string _sGuid = "";

		// Token: 0x040007F6 RID: 2038
		private string _sToken = "";

		// Token: 0x040007F7 RID: 2039
		private string _sHuYaUA = "";

		// Token: 0x040007F8 RID: 2040
		private string _sCookie = "";

		// Token: 0x040007F9 RID: 2041
		private int _iTokenType;
	}
}
