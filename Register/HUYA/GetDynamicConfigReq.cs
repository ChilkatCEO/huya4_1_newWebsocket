using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA.Huya
{
	// Token: 0x02000025 RID: 37
	public sealed class GetDynamicConfigReq : JceStruct
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00005FBD File Offset: 0x000041BD
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00005FC5 File Offset: 0x000041C5
		public UserId tId { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00005FCE File Offset: 0x000041CE
		// (set) Token: 0x06000222 RID: 546 RVA: 0x00005FD6 File Offset: 0x000041D6
		public Dictionary<string, string> mpParams { get; set; }

		// Token: 0x06000223 RID: 547 RVA: 0x00005FDF File Offset: 0x000041DF
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tId, 0);
			_os.Write(this.mpParams, 1);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00005FFB File Offset: 0x000041FB
		public override void ReadFrom(JceInputStream _is)
		{
			this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
			this.mpParams = (Dictionary<string, string>)_is.Read<Dictionary<string, string>>(this.mpParams, 1, false);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000602F File Offset: 0x0000422F
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tId, "tId");
			jceDisplayer.Display<string, string>(this.mpParams, "mpParams");
		}
	}
}
