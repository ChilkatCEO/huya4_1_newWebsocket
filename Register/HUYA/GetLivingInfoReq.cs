using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200002B RID: 43
	public sealed class GetLivingInfoReq : JceStruct
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000251 RID: 593 RVA: 0x000063C1 File Offset: 0x000045C1
		// (set) Token: 0x06000252 RID: 594 RVA: 0x000063C9 File Offset: 0x000045C9
		public UserId tId { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000253 RID: 595 RVA: 0x000063D2 File Offset: 0x000045D2
		// (set) Token: 0x06000254 RID: 596 RVA: 0x000063DA File Offset: 0x000045DA
		public long lTopSid
		{
			get
			{
				return this._lTopSid;
			}
			set
			{
				this._lTopSid = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000255 RID: 597 RVA: 0x000063E3 File Offset: 0x000045E3
		// (set) Token: 0x06000256 RID: 598 RVA: 0x000063EB File Offset: 0x000045EB
		public long lSubSid
		{
			get
			{
				return this._lSubSid;
			}
			set
			{
				this._lSubSid = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000257 RID: 599 RVA: 0x000063F4 File Offset: 0x000045F4
		// (set) Token: 0x06000258 RID: 600 RVA: 0x000063FC File Offset: 0x000045FC
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

		// Token: 0x06000259 RID: 601 RVA: 0x00006405 File Offset: 0x00004605
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tId, 0);
			_os.Write(this.lTopSid, 1);
			_os.Write(this.lSubSid, 2);
			_os.Write(this.lPresenterUid, 3);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000643C File Offset: 0x0000463C
		public override void ReadFrom(JceInputStream _is)
		{
			this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
			this.lTopSid = _is.Read(this.lTopSid, 1, false);
			this.lSubSid = _is.Read(this.lSubSid, 2, false);
			this.lPresenterUid = _is.Read(this.lPresenterUid, 3, false);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000064A0 File Offset: 0x000046A0
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tId, "tId");
			jceDisplayer.Display(this.lTopSid, "lTopSid");
			jceDisplayer.Display(this.lSubSid, "lSubSid");
			jceDisplayer.Display(this.lPresenterUid, "lPresenterUid");
		}

		// Token: 0x040000EF RID: 239
		private long _lTopSid;

		// Token: 0x040000F0 RID: 240
		private long _lSubSid;

		// Token: 0x040000F1 RID: 241
		private long _lPresenterUid;
	}
}
