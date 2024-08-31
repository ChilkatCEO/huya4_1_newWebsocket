using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200001B RID: 27
	public sealed class CheckRoomStatus : JceStruct
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000141 RID: 321 RVA: 0x0000442C File Offset: 0x0000262C
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00004434 File Offset: 0x00002634
		public List<CRPresenterInfo> vPidList { get; set; }

		// Token: 0x06000143 RID: 323 RVA: 0x0000443D File Offset: 0x0000263D
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.vPidList, 0);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000444C File Offset: 0x0000264C
		public override void ReadFrom(JceInputStream _is)
		{
			this.vPidList = (List<CRPresenterInfo>)_is.Read<List<CRPresenterInfo>>(this.vPidList, 0, false);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004467 File Offset: 0x00002667
		public override void Display(StringBuilder _os, int _level)
		{
			new JceDisplayer(_os, _level).Display<CRPresenterInfo>(this.vPidList, "vPidList");
		}
	}
}
