using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E4 RID: 228
	public sealed class MTagInfo : JceStruct
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060002DC RID: 732 RVA: 0x000072F1 File Offset: 0x000054F1
		// (set) Token: 0x060002DD RID: 733 RVA: 0x000072F9 File Offset: 0x000054F9
		public int iId
		{
			get
			{
				return this._iId;
			}
			set
			{
				this._iId = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00007302 File Offset: 0x00005502
		// (set) Token: 0x060002DF RID: 735 RVA: 0x0000730A File Offset: 0x0000550A
		public string sName
		{
			get
			{
				return this._sName;
			}
			set
			{
				this._sName = value;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00007313 File Offset: 0x00005513
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x0000731B File Offset: 0x0000551B
		public string sColor
		{
			get
			{
				return this._sColor;
			}
			set
			{
				this._sColor = value;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00007324 File Offset: 0x00005524
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x0000732C File Offset: 0x0000552C
		public int iType
		{
			get
			{
				return this._iType;
			}
			set
			{
				this._iType = value;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00007335 File Offset: 0x00005535
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x0000733D File Offset: 0x0000553D
		public List<MSubTagInfo> vMSubTagInfos { get; set; }

		// Token: 0x060002E6 RID: 742 RVA: 0x00007348 File Offset: 0x00005548
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iId, 0);
			_os.Write(this.sName, 1, false);
			_os.Write(this.sColor, 2, false);
			_os.Write(this.iType, 3);
			_os.Write(this.vMSubTagInfos, 4);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00007398 File Offset: 0x00005598
		public override void ReadFrom(JceInputStream _is)
		{
			this.iId = _is.Read(this.iId, 0, false);
			this.sName = _is.Read(this.sName, 1, false);
			this.sColor = _is.Read(this.sColor, 2, false);
			this.iType = _is.Read(this.iType, 3, false);
			this.vMSubTagInfos = (List<MSubTagInfo>)_is.Read<List<MSubTagInfo>>(this.vMSubTagInfos, 4, false);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00007410 File Offset: 0x00005610
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iId, "iId");
			jceDisplayer.Display(this.sName, "sName");
			jceDisplayer.Display(this.sColor, "sColor");
			jceDisplayer.Display(this.iType, "iType");
			jceDisplayer.Display<MSubTagInfo>(this.vMSubTagInfos, "vMSubTagInfos");
		}

		// Token: 0x0400078C RID: 1932
		private int _iId;

		// Token: 0x0400078D RID: 1933
		private string _sName = "";

		// Token: 0x0400078E RID: 1934
		private string _sColor = "";

		// Token: 0x0400078F RID: 1935
		private int _iType;
	}
}
