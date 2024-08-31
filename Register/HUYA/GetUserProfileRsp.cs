using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200002E RID: 46
	public sealed class GetUserProfileRsp : JceStruct
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000271 RID: 625 RVA: 0x000066D4 File Offset: 0x000048D4
		// (set) Token: 0x06000272 RID: 626 RVA: 0x000066DC File Offset: 0x000048DC
		public UserProfile tUserProfile { get; set; }

		// Token: 0x06000273 RID: 627 RVA: 0x000066E5 File Offset: 0x000048E5
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tUserProfile, 0);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000066F4 File Offset: 0x000048F4
		public override void ReadFrom(JceInputStream _is)
		{
			this.tUserProfile = (UserProfile)_is.Read<UserProfile>(this.tUserProfile, 0, false);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000670F File Offset: 0x0000490F
		public override void Display(StringBuilder _os, int _level)
		{
			new JceDisplayer(_os, _level).Display<UserProfile>(this.tUserProfile, "tUserProfile");
		}
	}
}
