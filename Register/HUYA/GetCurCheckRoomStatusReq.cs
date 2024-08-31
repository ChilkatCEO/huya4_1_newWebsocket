using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000024 RID: 36
	public sealed class GetCurCheckRoomStatusReq : JceStruct
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00005F24 File Offset: 0x00004124
		// (set) Token: 0x06000218 RID: 536 RVA: 0x00005F2C File Offset: 0x0000412C
		public UserId tUserId { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00005F35 File Offset: 0x00004135
		// (set) Token: 0x0600021A RID: 538 RVA: 0x00005F3D File Offset: 0x0000413D
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

		// Token: 0x0600021B RID: 539 RVA: 0x00005F46 File Offset: 0x00004146
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tUserId, 0);
			_os.Write(this.lPid, 1);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00005F62 File Offset: 0x00004162
		public override void ReadFrom(JceInputStream _is)
		{
			this.tUserId = (UserId)_is.Read<UserId>(this.tUserId, 0, false);
			this.lPid = _is.Read(this.lPid, 1, false);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00005F91 File Offset: 0x00004191
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tUserId, "tUserId");
			jceDisplayer.Display(this.lPid, "lPid");
		}

		// Token: 0x040000E0 RID: 224
		private long _lPid;
	}
}
