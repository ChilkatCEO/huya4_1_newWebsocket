using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E5 RID: 229
	public sealed class MultiStreamInfo : JceStruct
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060002EA RID: 746 RVA: 0x0000749B File Offset: 0x0000569B
		// (set) Token: 0x060002EB RID: 747 RVA: 0x000074A3 File Offset: 0x000056A3
		public string sDisplayName
		{
			get
			{
				return this._sDisplayName;
			}
			set
			{
				this._sDisplayName = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060002EC RID: 748 RVA: 0x000074AC File Offset: 0x000056AC
		// (set) Token: 0x060002ED RID: 749 RVA: 0x000074B4 File Offset: 0x000056B4
		public int iBitRate
		{
			get
			{
				return this._iBitRate;
			}
			set
			{
				this._iBitRate = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060002EE RID: 750 RVA: 0x000074BD File Offset: 0x000056BD
		// (set) Token: 0x060002EF RID: 751 RVA: 0x000074C5 File Offset: 0x000056C5
		public int iCodecType
		{
			get
			{
				return this._iCodecType;
			}
			set
			{
				this._iCodecType = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x000074CE File Offset: 0x000056CE
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x000074D6 File Offset: 0x000056D6
		public int iCompatibleFlag
		{
			get
			{
				return this._iCompatibleFlag;
			}
			set
			{
				this._iCompatibleFlag = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x000074DF File Offset: 0x000056DF
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x000074E7 File Offset: 0x000056E7
		public int iHEVCBitRate
		{
			get
			{
				return this._iHEVCBitRate;
			}
			set
			{
				this._iHEVCBitRate = value;
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000074F0 File Offset: 0x000056F0
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.sDisplayName, 0, false);
			_os.Write(this.iBitRate, 1);
			_os.Write(this.iCodecType, 2);
			_os.Write(this.iCompatibleFlag, 3);
			_os.Write(this.iHEVCBitRate, 4);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00007540 File Offset: 0x00005740
		public override void ReadFrom(JceInputStream _is)
		{
			this.sDisplayName = _is.Read(this.sDisplayName, 0, false);
			this.iBitRate = _is.Read(this.iBitRate, 1, false);
			this.iCodecType = _is.Read(this.iCodecType, 2, false);
			this.iCompatibleFlag = _is.Read(this.iCompatibleFlag, 3, false);
			this.iHEVCBitRate = _is.Read(this.iHEVCBitRate, 4, false);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x000075B4 File Offset: 0x000057B4
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.sDisplayName, "sDisplayName");
			jceDisplayer.Display(this.iBitRate, "iBitRate");
			jceDisplayer.Display(this.iCodecType, "iCodecType");
			jceDisplayer.Display(this.iCompatibleFlag, "iCompatibleFlag");
			jceDisplayer.Display(this.iHEVCBitRate, "iHEVCBitRate");
		}

		// Token: 0x04000791 RID: 1937
		private string _sDisplayName = "";

		// Token: 0x04000792 RID: 1938
		private int _iBitRate;

		// Token: 0x04000793 RID: 1939
		private int _iCodecType;

		// Token: 0x04000794 RID: 1940
		private int _iCompatibleFlag;

		// Token: 0x04000795 RID: 1941
		private int _iHEVCBitRate = -1;
	}
}
