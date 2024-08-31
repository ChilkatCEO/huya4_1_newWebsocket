using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E3 RID: 227
	public sealed class MSubTagInfo : JceStruct
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x0000719B File Offset: 0x0000539B
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x000071A3 File Offset: 0x000053A3
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

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x000071AC File Offset: 0x000053AC
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x000071B4 File Offset: 0x000053B4
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

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x000071BD File Offset: 0x000053BD
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x000071C5 File Offset: 0x000053C5
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

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x000071CE File Offset: 0x000053CE
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x000071D6 File Offset: 0x000053D6
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

		// Token: 0x060002D8 RID: 728 RVA: 0x000071DF File Offset: 0x000053DF
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iId, 0);
			_os.Write(this.sName, 1, false);
			_os.Write(this.sColor, 2, false);
			_os.Write(this.iType, 3);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00007218 File Offset: 0x00005418
		public override void ReadFrom(JceInputStream _is)
		{
			this.iId = _is.Read(this.iId, 0, false);
			this.sName = _is.Read(this.sName, 1, false);
			this.sColor = _is.Read(this.sColor, 2, false);
			this.iType = _is.Read(this.iType, 3, false);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00007278 File Offset: 0x00005478
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iId, "iId");
			jceDisplayer.Display(this.sName, "sName");
			jceDisplayer.Display(this.sColor, "sColor");
			jceDisplayer.Display(this.iType, "iType");
		}

		// Token: 0x04000788 RID: 1928
		private int _iId;

		// Token: 0x04000789 RID: 1929
		private string _sName = "";

		// Token: 0x0400078A RID: 1930
		private string _sColor = "";

		// Token: 0x0400078B RID: 1931
		private int _iType;
	}
}
