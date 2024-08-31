using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000DE RID: 222
	public sealed class LinkMicStatusChangeNotice : JceStruct
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000278 RID: 632 RVA: 0x00006731 File Offset: 0x00004931
		// (set) Token: 0x06000279 RID: 633 RVA: 0x00006739 File Offset: 0x00004939
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

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00006742 File Offset: 0x00004942
		// (set) Token: 0x0600027B RID: 635 RVA: 0x0000674A File Offset: 0x0000494A
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

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00006753 File Offset: 0x00004953
		// (set) Token: 0x0600027D RID: 637 RVA: 0x0000675B File Offset: 0x0000495B
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

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00006764 File Offset: 0x00004964
		// (set) Token: 0x0600027F RID: 639 RVA: 0x0000676C File Offset: 0x0000496C
		public List<LMPresenterInfo> vLMPresenterInfos { get; set; }

		// Token: 0x06000280 RID: 640 RVA: 0x00006775 File Offset: 0x00004975
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lLMSessionId, 0);
			_os.Write(this.iLinkMicStatus, 1);
			_os.Write(this.lOwnerUid, 2);
			_os.Write(this.vLMPresenterInfos, 3);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x000067AC File Offset: 0x000049AC
		public override void ReadFrom(JceInputStream _is)
		{
			this.lLMSessionId = _is.Read(this.lLMSessionId, 0, false);
			this.iLinkMicStatus = _is.Read(this.iLinkMicStatus, 1, false);
			this.lOwnerUid = _is.Read(this.lOwnerUid, 2, false);
			this.vLMPresenterInfos = (List<LMPresenterInfo>)_is.Read<List<LMPresenterInfo>>(this.vLMPresenterInfos, 3, false);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00006810 File Offset: 0x00004A10
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lLMSessionId, "lLMSessionId");
			jceDisplayer.Display(this.iLinkMicStatus, "iLinkMicStatus");
			jceDisplayer.Display(this.lOwnerUid, "lOwnerUid");
			jceDisplayer.Display<LMPresenterInfo>(this.vLMPresenterInfos, "vLMPresenterInfos");
		}

		// Token: 0x04000766 RID: 1894
		private long _lLMSessionId;

		// Token: 0x04000767 RID: 1895
		private int _iLinkMicStatus;

		// Token: 0x04000768 RID: 1896
		private long _lOwnerUid;
	}
}
