using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000026 RID: 38
	public sealed class GetDynamicConfigRsp : JceStruct
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000227 RID: 551 RVA: 0x0000605B File Offset: 0x0000425B
		// (set) Token: 0x06000228 RID: 552 RVA: 0x00006063 File Offset: 0x00004263
		public Dictionary<string, string> mpConfig { get; set; }

		// Token: 0x06000229 RID: 553 RVA: 0x0000606C File Offset: 0x0000426C
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.mpConfig, 0);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000607B File Offset: 0x0000427B
		public override void ReadFrom(JceInputStream _is)
		{
			this.mpConfig = (Dictionary<string, string>)_is.Read<Dictionary<string, string>>(this.mpConfig, 0, false);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00006096 File Offset: 0x00004296
		public override void Display(StringBuilder _os, int _level)
		{
			new JceDisplayer(_os, _level).Display<string, string>(this.mpConfig, "mpConfig");
		}
	}
}
