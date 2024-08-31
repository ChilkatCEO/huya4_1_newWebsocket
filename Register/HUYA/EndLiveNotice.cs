using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200001E RID: 30
	public sealed class EndLiveNotice : JceStruct
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00004869 File Offset: 0x00002A69
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00004871 File Offset: 0x00002A71
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

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600016B RID: 363 RVA: 0x0000487A File Offset: 0x00002A7A
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00004882 File Offset: 0x00002A82
		public int iReason
		{
			get
			{
				return this._iReason;
			}
			set
			{
				this._iReason = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600016D RID: 365 RVA: 0x0000488B File Offset: 0x00002A8B
		// (set) Token: 0x0600016E RID: 366 RVA: 0x00004893 File Offset: 0x00002A93
		public long lLiveId
		{
			get
			{
				return this._lLiveId;
			}
			set
			{
				this._lLiveId = value;
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000489C File Offset: 0x00002A9C
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lPresenterUid, 0);
			_os.Write(this.iReason, 1);
			_os.Write(this.lLiveId, 2);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000048C5 File Offset: 0x00002AC5
		public override void ReadFrom(JceInputStream _is)
		{
			this.lPresenterUid = _is.Read(this.lPresenterUid, 0, false);
			this.iReason = _is.Read(this.iReason, 1, false);
			this.lLiveId = _is.Read(this.lLiveId, 2, false);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00004903 File Offset: 0x00002B03
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lPresenterUid, "lPresenterUid");
			jceDisplayer.Display(this.iReason, "iReason");
			jceDisplayer.Display(this.lLiveId, "lLiveId");
		}

		// Token: 0x04000094 RID: 148
		private long _lPresenterUid;

		// Token: 0x04000095 RID: 149
		private int _iReason;

		// Token: 0x04000096 RID: 150
		private long _lLiveId;
	}
}
