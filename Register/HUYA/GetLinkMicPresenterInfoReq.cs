using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000027 RID: 39
	public sealed class GetLinkMicPresenterInfoReq : JceStruct
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600022D RID: 557 RVA: 0x000060B0 File Offset: 0x000042B0
		// (set) Token: 0x0600022E RID: 558 RVA: 0x000060B8 File Offset: 0x000042B8
		public UserId tId { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600022F RID: 559 RVA: 0x000060C1 File Offset: 0x000042C1
		// (set) Token: 0x06000230 RID: 560 RVA: 0x000060C9 File Offset: 0x000042C9
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

		// Token: 0x06000231 RID: 561 RVA: 0x000060D2 File Offset: 0x000042D2
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tId, 0);
			_os.Write(this.lUid, 1);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000060EE File Offset: 0x000042EE
		public override void ReadFrom(JceInputStream _is)
		{
			this.tId = (HUYA.UserId)_is.Read<HUYA.UserId>(this.tId, 0, false);
			this.lUid = _is.Read(this.lUid, 1, false);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000611D File Offset: 0x0000431D
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tId, "tId");
			jceDisplayer.Display(this.lUid, "lUid");
		}

		// Token: 0x040000E5 RID: 229
		private long _lUid;
	}
}
