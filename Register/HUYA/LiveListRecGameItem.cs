using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000DF RID: 223
	public sealed class LiveListRecGameItem : JceStruct
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0000686B File Offset: 0x00004A6B
		// (set) Token: 0x06000285 RID: 645 RVA: 0x00006873 File Offset: 0x00004A73
		public int iGameId
		{
			get
			{
				return this._iGameId;
			}
			set
			{
				this._iGameId = value;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000286 RID: 646 RVA: 0x0000687C File Offset: 0x00004A7C
		// (set) Token: 0x06000287 RID: 647 RVA: 0x00006884 File Offset: 0x00004A84
		public string sAction
		{
			get
			{
				return this._sAction;
			}
			set
			{
				this._sAction = value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000288 RID: 648 RVA: 0x0000688D File Offset: 0x00004A8D
		// (set) Token: 0x06000289 RID: 649 RVA: 0x00006895 File Offset: 0x00004A95
		public string sImageUrl
		{
			get
			{
				return this._sImageUrl;
			}
			set
			{
				this._sImageUrl = value;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600028A RID: 650 RVA: 0x0000689E File Offset: 0x00004A9E
		// (set) Token: 0x0600028B RID: 651 RVA: 0x000068A6 File Offset: 0x00004AA6
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

		// Token: 0x0600028C RID: 652 RVA: 0x000068AF File Offset: 0x00004AAF
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iGameId, 0);
			_os.Write(this.sAction, 1, false);
			_os.Write(this.sImageUrl, 2, false);
			_os.Write(this.sGameName, 3, false);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x000068E8 File Offset: 0x00004AE8
		public override void ReadFrom(JceInputStream _is)
		{
			this.iGameId = _is.Read(this.iGameId, 0, false);
			this.sAction = _is.Read(this.sAction, 1, false);
			this.sImageUrl = _is.Read(this.sImageUrl, 2, false);
			this.sGameName = _is.Read(this.sGameName, 3, false);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00006948 File Offset: 0x00004B48
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iGameId, "iGameId");
			jceDisplayer.Display(this.sAction, "sAction");
			jceDisplayer.Display(this.sImageUrl, "sImageUrl");
			jceDisplayer.Display(this.sGameName, "sGameName");
		}

		// Token: 0x0400076A RID: 1898
		private int _iGameId;

		// Token: 0x0400076B RID: 1899
		private string _sAction = "";

		// Token: 0x0400076C RID: 1900
		private string _sImageUrl = "";

		// Token: 0x0400076D RID: 1901
		private string _sGameName = "";
	}
}
