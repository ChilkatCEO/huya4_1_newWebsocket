using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000EE RID: 238
	public sealed class UserProfile : JceStruct
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x000094EB File Offset: 0x000076EB
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x000094F3 File Offset: 0x000076F3
		public UserBase tUserBase { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x000094FC File Offset: 0x000076FC
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x00009504 File Offset: 0x00007704
		public PresenterBase tPresenterBase { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0000950D File Offset: 0x0000770D
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x00009515 File Offset: 0x00007715
		public GameLiveInfo tRecentLive { get; set; }

		// Token: 0x060003E6 RID: 998 RVA: 0x0000951E File Offset: 0x0000771E
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tUserBase, 0);
			_os.Write(this.tPresenterBase, 1);
			_os.Write(this.tRecentLive, 2);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00009548 File Offset: 0x00007748
		public override void ReadFrom(JceInputStream _is)
		{
			this.tUserBase = (UserBase)_is.Read<UserBase>(this.tUserBase, 0, false);
			this.tPresenterBase = (PresenterBase)_is.Read<PresenterBase>(this.tPresenterBase, 1, false);
			this.tRecentLive = (GameLiveInfo)_is.Read<GameLiveInfo>(this.tRecentLive, 2, false);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x000095A0 File Offset: 0x000077A0
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserBase>(this.tUserBase, "tUserBase");
			jceDisplayer.Display<PresenterBase>(this.tPresenterBase, "tPresenterBase");
			jceDisplayer.Display<GameLiveInfo>(this.tRecentLive, "tRecentLive");
		}
	}
}
