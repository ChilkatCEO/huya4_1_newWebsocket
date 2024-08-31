using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200001D RID: 29
	public sealed class CRPresenterInfo : JceStruct
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000456C File Offset: 0x0000276C
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00004574 File Offset: 0x00002774
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

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000153 RID: 339 RVA: 0x0000457D File Offset: 0x0000277D
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00004585 File Offset: 0x00002785
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

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000155 RID: 341 RVA: 0x0000458E File Offset: 0x0000278E
		// (set) Token: 0x06000156 RID: 342 RVA: 0x00004596 File Offset: 0x00002796
		public string sIconUrl
		{
			get
			{
				return this._sIconUrl;
			}
			set
			{
				this._sIconUrl = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000157 RID: 343 RVA: 0x0000459F File Offset: 0x0000279F
		// (set) Token: 0x06000158 RID: 344 RVA: 0x000045A7 File Offset: 0x000027A7
		public long lTopCid
		{
			get
			{
				return this._lTopCid;
			}
			set
			{
				this._lTopCid = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000159 RID: 345 RVA: 0x000045B0 File Offset: 0x000027B0
		// (set) Token: 0x0600015A RID: 346 RVA: 0x000045B8 File Offset: 0x000027B8
		public long lSubCid
		{
			get
			{
				return this._lSubCid;
			}
			set
			{
				this._lSubCid = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600015B RID: 347 RVA: 0x000045C1 File Offset: 0x000027C1
		// (set) Token: 0x0600015C RID: 348 RVA: 0x000045C9 File Offset: 0x000027C9
		public int iType
		{
			get
			{
				return this._iType;
			}
			set
			{
				this._iType = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600015D RID: 349 RVA: 0x000045D2 File Offset: 0x000027D2
		// (set) Token: 0x0600015E RID: 350 RVA: 0x000045DA File Offset: 0x000027DA
		public long lRoomId
		{
			get
			{
				return this._lRoomId;
			}
			set
			{
				this._lRoomId = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600015F RID: 351 RVA: 0x000045E3 File Offset: 0x000027E3
		// (set) Token: 0x06000160 RID: 352 RVA: 0x000045EB File Offset: 0x000027EB
		public long lYYID
		{
			get
			{
				return this._lYYID;
			}
			set
			{
				this._lYYID = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000161 RID: 353 RVA: 0x000045F4 File Offset: 0x000027F4
		// (set) Token: 0x06000162 RID: 354 RVA: 0x000045FC File Offset: 0x000027FC
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

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00004605 File Offset: 0x00002805
		// (set) Token: 0x06000164 RID: 356 RVA: 0x0000460D File Offset: 0x0000280D
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

		// Token: 0x06000165 RID: 357 RVA: 0x00004618 File Offset: 0x00002818
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lPid, 0);
			_os.Write(this.sNickName, 1, false);
			_os.Write(this.sIconUrl, 2, false);
			_os.Write(this.lTopCid, 3);
			_os.Write(this.lSubCid, 4);
			_os.Write(this.iType, 5);
			_os.Write(this.lRoomId, 6);
			_os.Write(this.lYYID, 7);
			_os.Write(this.iSourceType, 8);
			_os.Write(this.iScreenType, 9);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000046AC File Offset: 0x000028AC
		public override void ReadFrom(JceInputStream _is)
		{
			this.lPid = _is.Read(this.lPid, 0, false);
			this.sNickName = _is.Read(this.sNickName, 1, false);
			this.sIconUrl = _is.Read(this.sIconUrl, 2, false);
			this.lTopCid = _is.Read(this.lTopCid, 3, false);
			this.lSubCid = _is.Read(this.lSubCid, 4, false);
			this.iType = _is.Read(this.iType, 5, false);
			this.lRoomId = _is.Read(this.lRoomId, 6, false);
			this.lYYID = _is.Read(this.lYYID, 7, false);
			this.iSourceType = _is.Read(this.iSourceType, 8, false);
			this.iScreenType = _is.Read(this.iScreenType, 9, false);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00004784 File Offset: 0x00002984
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lPid, "lPid");
			jceDisplayer.Display(this.sNickName, "sNickName");
			jceDisplayer.Display(this.sIconUrl, "sIconUrl");
			jceDisplayer.Display(this.lTopCid, "lTopCid");
			jceDisplayer.Display(this.lSubCid, "lSubCid");
			jceDisplayer.Display(this.iType, "iType");
			jceDisplayer.Display(this.lRoomId, "lRoomId");
			jceDisplayer.Display(this.lYYID, "lYYID");
			jceDisplayer.Display(this.iSourceType, "iSourceType");
			jceDisplayer.Display(this.iScreenType, "iScreenType");
		}

		// Token: 0x0400008A RID: 138
		private long _lPid;

		// Token: 0x0400008B RID: 139
		private string _sNickName = "";

		// Token: 0x0400008C RID: 140
		private string _sIconUrl = "";

		// Token: 0x0400008D RID: 141
		private long _lTopCid;

		// Token: 0x0400008E RID: 142
		private long _lSubCid;

		// Token: 0x0400008F RID: 143
		private int _iType;

		// Token: 0x04000090 RID: 144
		private long _lRoomId;

		// Token: 0x04000091 RID: 145
		private long _lYYID;

		// Token: 0x04000092 RID: 146
		private int _iSourceType;

		// Token: 0x04000093 RID: 147
		private int _iScreenType;
	}
}
