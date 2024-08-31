using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200001C RID: 28
	public sealed class CKRoomUserEnterReq : JceStruct
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00004481 File Offset: 0x00002681
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00004489 File Offset: 0x00002689
		public UserId tUserId { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00004492 File Offset: 0x00002692
		// (set) Token: 0x0600014A RID: 330 RVA: 0x0000449A File Offset: 0x0000269A
		public long lFromPid
		{
			get
			{
				return this._lFromPid;
			}
			set
			{
				this._lFromPid = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600014B RID: 331 RVA: 0x000044A3 File Offset: 0x000026A3
		// (set) Token: 0x0600014C RID: 332 RVA: 0x000044AB File Offset: 0x000026AB
		public long lToPid
		{
			get
			{
				return this._lToPid;
			}
			set
			{
				this._lToPid = value;
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000044B4 File Offset: 0x000026B4
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tUserId, 0);
			_os.Write(this.lFromPid, 1);
			_os.Write(this.lToPid, 2);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000044E0 File Offset: 0x000026E0
		public override void ReadFrom(JceInputStream _is)
		{
			this.tUserId = (UserId)_is.Read<UserId>(this.tUserId, 0, false);
			this.lFromPid = _is.Read(this.lFromPid, 1, false);
			this.lToPid = _is.Read(this.lToPid, 2, false);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000452E File Offset: 0x0000272E
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tUserId, "tUserId");
			jceDisplayer.Display(this.lFromPid, "lFromPid");
			jceDisplayer.Display(this.lToPid, "lToPid");
		}

		// Token: 0x04000088 RID: 136
		private long _lFromPid;

		// Token: 0x04000089 RID: 137
		private long _lToPid;
	}
}
