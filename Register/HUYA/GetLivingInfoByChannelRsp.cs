using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200002A RID: 42
	public sealed class GetLivingInfoByChannelRsp : JceStruct
	{
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000636C File Offset: 0x0000456C
		// (set) Token: 0x0600024C RID: 588 RVA: 0x00006374 File Offset: 0x00004574
		public List<GameLiveInfo> vGameLiveInfo { get; set; }

		// Token: 0x0600024D RID: 589 RVA: 0x0000637D File Offset: 0x0000457D
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.vGameLiveInfo, 0);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000638C File Offset: 0x0000458C
		public override void ReadFrom(JceInputStream _is)
		{
			this.vGameLiveInfo = (List<GameLiveInfo>)_is.Read<List<GameLiveInfo>>(this.vGameLiveInfo, 0, false);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000063A7 File Offset: 0x000045A7
		public override void Display(StringBuilder _os, int _level)
		{
			new JceDisplayer(_os, _level).Display<GameLiveInfo>(this.vGameLiveInfo, "vGameLiveInfo");
		}
	}
}
