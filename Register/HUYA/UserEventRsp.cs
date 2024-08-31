using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000EC RID: 236
	public sealed class UserEventRsp : JceStruct
	{
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0000919A File Offset: 0x0000739A
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x000091A2 File Offset: 0x000073A2
		public long lTid
		{
			get
			{
				return this._lTid;
			}
			set
			{
				this._lTid = value;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x000091AB File Offset: 0x000073AB
		// (set) Token: 0x060003C7 RID: 967 RVA: 0x000091B3 File Offset: 0x000073B3
		public long lSid
		{
			get
			{
				return this._lSid;
			}
			set
			{
				this._lSid = value;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x000091BC File Offset: 0x000073BC
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x000091C4 File Offset: 0x000073C4
		public int iUserHeartBeatInterval
		{
			get
			{
				return this._iUserHeartBeatInterval;
			}
			set
			{
				this._iUserHeartBeatInterval = value;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060003CA RID: 970 RVA: 0x000091CD File Offset: 0x000073CD
		// (set) Token: 0x060003CB RID: 971 RVA: 0x000091D5 File Offset: 0x000073D5
		public int iPresentHeartBeatInterval
		{
			get
			{
				return this._iPresentHeartBeatInterval;
			}
			set
			{
				this._iPresentHeartBeatInterval = value;
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000091DE File Offset: 0x000073DE
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lTid, 0);
			_os.Write(this.lSid, 1);
			_os.Write(this.iUserHeartBeatInterval, 2);
			_os.Write(this.iPresentHeartBeatInterval, 3);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00009214 File Offset: 0x00007414
		public override void ReadFrom(JceInputStream _is)
		{
			this.lTid = _is.Read(this.lTid, 0, false);
			this.lSid = _is.Read(this.lSid, 1, false);
			this.iUserHeartBeatInterval = _is.Read(this.iUserHeartBeatInterval, 2, false);
			this.iPresentHeartBeatInterval = _is.Read(this.iPresentHeartBeatInterval, 3, false);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00009274 File Offset: 0x00007474
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lTid, "lTid");
			jceDisplayer.Display(this.lSid, "lSid");
			jceDisplayer.Display(this.iUserHeartBeatInterval, "iUserHeartBeatInterval");
			jceDisplayer.Display(this.iPresentHeartBeatInterval, "iPresentHeartBeatInterval");
		}

		// Token: 0x040007F0 RID: 2032
		private long _lTid;

		// Token: 0x040007F1 RID: 2033
		private long _lSid;

		// Token: 0x040007F2 RID: 2034
		private int _iUserHeartBeatInterval = 60;

		// Token: 0x040007F3 RID: 2035
		private int _iPresentHeartBeatInterval = 60;
	}
}
