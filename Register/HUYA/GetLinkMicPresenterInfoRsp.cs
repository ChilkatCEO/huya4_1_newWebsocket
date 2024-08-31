using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000028 RID: 40
	public sealed class GetLinkMicPresenterInfoRsp : JceStruct
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00006149 File Offset: 0x00004349
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00006151 File Offset: 0x00004351
		public long lLMSessionId
		{
			get
			{
				return this._lLMSessionId;
			}
			set
			{
				this._lLMSessionId = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000237 RID: 567 RVA: 0x0000615A File Offset: 0x0000435A
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00006162 File Offset: 0x00004362
		public int iLinkMicStatus
		{
			get
			{
				return this._iLinkMicStatus;
			}
			set
			{
				this._iLinkMicStatus = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000239 RID: 569 RVA: 0x0000616B File Offset: 0x0000436B
		// (set) Token: 0x0600023A RID: 570 RVA: 0x00006173 File Offset: 0x00004373
		public long lOwnerUid
		{
			get
			{
				return this._lOwnerUid;
			}
			set
			{
				this._lOwnerUid = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000617C File Offset: 0x0000437C
		// (set) Token: 0x0600023C RID: 572 RVA: 0x00006184 File Offset: 0x00004384
		public List<LMPresenterInfo> vLMPresenterInfos { get; set; }

		// Token: 0x0600023D RID: 573 RVA: 0x0000618D File Offset: 0x0000438D
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lLMSessionId, 0);
			_os.Write(this.iLinkMicStatus, 1);
			_os.Write(this.lOwnerUid, 2);
			_os.Write(this.vLMPresenterInfos, 3);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x000061C4 File Offset: 0x000043C4
		public override void ReadFrom(JceInputStream _is)
		{
			this.lLMSessionId = _is.Read(this.lLMSessionId, 0, false);
			this.iLinkMicStatus = _is.Read(this.iLinkMicStatus, 1, false);
			this.lOwnerUid = _is.Read(this.lOwnerUid, 2, false);
			this.vLMPresenterInfos = (List<LMPresenterInfo>)_is.Read<List<LMPresenterInfo>>(this.vLMPresenterInfos, 3, false);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00006228 File Offset: 0x00004428
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lLMSessionId, "lLMSessionId");
			jceDisplayer.Display(this.iLinkMicStatus, "iLinkMicStatus");
			jceDisplayer.Display(this.lOwnerUid, "lOwnerUid");
			jceDisplayer.Display<LMPresenterInfo>(this.vLMPresenterInfos, "vLMPresenterInfos");
		}

		// Token: 0x040000E6 RID: 230
		private long _lLMSessionId;

		// Token: 0x040000E7 RID: 231
		private int _iLinkMicStatus;

		// Token: 0x040000E8 RID: 232
		private long _lOwnerUid;
	}
}
