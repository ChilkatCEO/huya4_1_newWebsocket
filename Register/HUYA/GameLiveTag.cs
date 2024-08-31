using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000021 RID: 33
	public sealed class GameLiveTag : JceStruct
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00005968 File Offset: 0x00003B68
		// (set) Token: 0x060001EA RID: 490 RVA: 0x00005970 File Offset: 0x00003B70
		public int iTagId
		{
			get
			{
				return this._iTagId;
			}
			set
			{
				this._iTagId = value;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00005979 File Offset: 0x00003B79
		// (set) Token: 0x060001EC RID: 492 RVA: 0x00005981 File Offset: 0x00003B81
		public string sTagName
		{
			get
			{
				return this._sTagName;
			}
			set
			{
				this._sTagName = value;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060001ED RID: 493 RVA: 0x0000598A File Offset: 0x00003B8A
		// (set) Token: 0x060001EE RID: 494 RVA: 0x00005992 File Offset: 0x00003B92
		public bool bIsShow
		{
			get
			{
				return this._bIsShow;
			}
			set
			{
				this._bIsShow = value;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000599B File Offset: 0x00003B9B
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x000059A3 File Offset: 0x00003BA3
		public int iBindingGameId
		{
			get
			{
				return this._iBindingGameId;
			}
			set
			{
				this._iBindingGameId = value;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x000059AC File Offset: 0x00003BAC
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x000059B4 File Offset: 0x00003BB4
		public int iShowType
		{
			get
			{
				return this._iShowType;
			}
			set
			{
				this._iShowType = value;
			}
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000059C0 File Offset: 0x00003BC0
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iTagId, 0);
			_os.Write(this.sTagName, 1, false);
			_os.Write(this.bIsShow, 2);
			_os.Write(this.iBindingGameId, 3);
			_os.Write(this.iShowType, 4);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00005A10 File Offset: 0x00003C10
		public override void ReadFrom(JceInputStream _is)
		{
			this.iTagId = _is.Read(this.iTagId, 0, false);
			this.sTagName = _is.Read(this.sTagName, 1, false);
			this.bIsShow = _is.Read(this.bIsShow, 2, false);
			this.iBindingGameId = _is.Read(this.iBindingGameId, 3, false);
			this.iShowType = _is.Read(this.iShowType, 4, false);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00005A84 File Offset: 0x00003C84
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iTagId, "iTagId");
			jceDisplayer.Display(this.sTagName, "sTagName");
			jceDisplayer.Display(this.bIsShow, "bIsShow");
			jceDisplayer.Display(this.iBindingGameId, "iBindingGameId");
			jceDisplayer.Display(this.iShowType, "iShowType");
		}

		// Token: 0x040000CE RID: 206
		private int _iTagId;

		// Token: 0x040000CF RID: 207
		private string _sTagName = "";

		// Token: 0x040000D0 RID: 208
		private bool _bIsShow = true;

		// Token: 0x040000D1 RID: 209
		private int _iBindingGameId;

		// Token: 0x040000D2 RID: 210
		private int _iShowType;
	}
}
