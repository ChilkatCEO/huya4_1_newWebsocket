using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000029 RID: 41
	public sealed class GetLivingInfoByChannelReq : JceStruct
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00006283 File Offset: 0x00004483
		// (set) Token: 0x06000242 RID: 578 RVA: 0x0000628B File Offset: 0x0000448B
		public UserId tId { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00006294 File Offset: 0x00004494
		// (set) Token: 0x06000244 RID: 580 RVA: 0x0000629C File Offset: 0x0000449C
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

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000245 RID: 581 RVA: 0x000062A5 File Offset: 0x000044A5
		// (set) Token: 0x06000246 RID: 582 RVA: 0x000062AD File Offset: 0x000044AD
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

		// Token: 0x06000247 RID: 583 RVA: 0x000062B6 File Offset: 0x000044B6
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tId, 0);
			_os.Write(this.lTopSid, 1);
			_os.Write(this.lSubSid, 2);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000062E0 File Offset: 0x000044E0
		public override void ReadFrom(JceInputStream _is)
		{
			this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
			this.lTopSid = _is.Read(this.lTopSid, 1, false);
			this.lSubSid = _is.Read(this.lSubSid, 2, false);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000632E File Offset: 0x0000452E
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tId, "tId");
			jceDisplayer.Display(this.lTopSid, "lTopSid");
			jceDisplayer.Display(this.lSubSid, "lSubSid");
		}

		// Token: 0x040000EB RID: 235
		private long _lTopSid;

		// Token: 0x040000EC RID: 236
		private long _lSubSid;
	}
}
