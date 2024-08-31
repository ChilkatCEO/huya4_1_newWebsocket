using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200002D RID: 45
	public sealed class GetUserProfileReq : JceStruct
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000663B File Offset: 0x0000483B
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00006643 File Offset: 0x00004843
		public UserId tId { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600026B RID: 619 RVA: 0x0000664C File Offset: 0x0000484C
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00006654 File Offset: 0x00004854
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

		// Token: 0x0600026D RID: 621 RVA: 0x0000665D File Offset: 0x0000485D
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tId, 0);
			_os.Write(this.lUid, 1);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00006679 File Offset: 0x00004879
		public override void ReadFrom(JceInputStream _is)
		{
			this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
			this.lUid = _is.Read(this.lUid, 1, false);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x000066A8 File Offset: 0x000048A8
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tId, "tId");
			jceDisplayer.Display(this.lUid, "lUid");
		}

		// Token: 0x040000F7 RID: 247
		private long _lUid;
	}
}
