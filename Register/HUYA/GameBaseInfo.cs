using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200001F RID: 31
	public sealed class GameBaseInfo : JceStruct
	{
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00004941 File Offset: 0x00002B41
		// (set) Token: 0x06000174 RID: 372 RVA: 0x00004949 File Offset: 0x00002B49
		public int iId
		{
			get
			{
				return this._iId;
			}
			set
			{
				this._iId = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00004952 File Offset: 0x00002B52
		// (set) Token: 0x06000176 RID: 374 RVA: 0x0000495A File Offset: 0x00002B5A
		public string sFullName
		{
			get
			{
				return this._sFullName;
			}
			set
			{
				this._sFullName = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000177 RID: 375 RVA: 0x00004963 File Offset: 0x00002B63
		// (set) Token: 0x06000178 RID: 376 RVA: 0x0000496B File Offset: 0x00002B6B
		public string sShortName
		{
			get
			{
				return this._sShortName;
			}
			set
			{
				this._sShortName = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00004974 File Offset: 0x00002B74
		// (set) Token: 0x0600017A RID: 378 RVA: 0x0000497C File Offset: 0x00002B7C
		public string sIcon
		{
			get
			{
				return this._sIcon;
			}
			set
			{
				this._sIcon = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00004985 File Offset: 0x00002B85
		// (set) Token: 0x0600017C RID: 380 RVA: 0x0000498D File Offset: 0x00002B8D
		public int iCategory
		{
			get
			{
				return this._iCategory;
			}
			set
			{
				this._iCategory = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00004996 File Offset: 0x00002B96
		// (set) Token: 0x0600017E RID: 382 RVA: 0x0000499E File Offset: 0x00002B9E
		public string sCategoryName
		{
			get
			{
				return this._sCategoryName;
			}
			set
			{
				this._sCategoryName = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600017F RID: 383 RVA: 0x000049A7 File Offset: 0x00002BA7
		// (set) Token: 0x06000180 RID: 384 RVA: 0x000049AF File Offset: 0x00002BAF
		public int iExeId
		{
			get
			{
				return this._iExeId;
			}
			set
			{
				this._iExeId = value;
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000049B8 File Offset: 0x00002BB8
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iId, 0);
			_os.Write(this.sFullName, 1, false);
			_os.Write(this.sShortName, 2, false);
			_os.Write(this.sIcon, 3, false);
			_os.Write(this.iCategory, 4);
			_os.Write(this.sCategoryName, 5, false);
			_os.Write(this.iExeId, 6);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00004A24 File Offset: 0x00002C24
		public override void ReadFrom(JceInputStream _is)
		{
			this.iId = _is.Read(this.iId, 0, false);
			this.sFullName = _is.Read(this.sFullName, 1, false);
			this.sShortName = _is.Read(this.sShortName, 2, false);
			this.sIcon = _is.Read(this.sIcon, 3, false);
			this.iCategory = _is.Read(this.iCategory, 4, false);
			this.sCategoryName = _is.Read(this.sCategoryName, 5, false);
			this.iExeId = _is.Read(this.iExeId, 6, false);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00004AC0 File Offset: 0x00002CC0
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iId, "iId");
			jceDisplayer.Display(this.sFullName, "sFullName");
			jceDisplayer.Display(this.sShortName, "sShortName");
			jceDisplayer.Display(this.sIcon, "sIcon");
			jceDisplayer.Display(this.iCategory, "iCategory");
			jceDisplayer.Display(this.sCategoryName, "sCategoryName");
			jceDisplayer.Display(this.iExeId, "iExeId");
		}

		// Token: 0x04000097 RID: 151
		private int _iId;

		// Token: 0x04000098 RID: 152
		private string _sFullName = "";

		// Token: 0x04000099 RID: 153
		private string _sShortName = "";

		// Token: 0x0400009A RID: 154
		private string _sIcon = "";

		// Token: 0x0400009B RID: 155
		private int _iCategory;

		// Token: 0x0400009C RID: 156
		private string _sCategoryName = "";

		// Token: 0x0400009D RID: 157
		private int _iExeId;
	}
}
