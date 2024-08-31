using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E1 RID: 225
	public sealed class MGetLiveListReq : JceStruct
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00006C3D File Offset: 0x00004E3D
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00006C45 File Offset: 0x00004E45
		public UserId tId { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x00006C4E File Offset: 0x00004E4E
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x00006C56 File Offset: 0x00004E56
		public int iSectionId
		{
			get
			{
				return this._iSectionId;
			}
			set
			{
				this._iSectionId = value;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00006C5F File Offset: 0x00004E5F
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x00006C67 File Offset: 0x00004E67
		public int iTag
		{
			get
			{
				return this._iTag;
			}
			set
			{
				this._iTag = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00006C70 File Offset: 0x00004E70
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00006C78 File Offset: 0x00004E78
		public int iPage
		{
			get
			{
				return this._iPage;
			}
			set
			{
				this._iPage = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00006C81 File Offset: 0x00004E81
		// (set) Token: 0x060002AD RID: 685 RVA: 0x00006C89 File Offset: 0x00004E89
		public int iPageSize
		{
			get
			{
				return this._iPageSize;
			}
			set
			{
				this._iPageSize = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060002AE RID: 686 RVA: 0x00006C92 File Offset: 0x00004E92
		// (set) Token: 0x060002AF RID: 687 RVA: 0x00006C9A File Offset: 0x00004E9A
		public int iUseLocation
		{
			get
			{
				return this._iUseLocation;
			}
			set
			{
				this._iUseLocation = value;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00006CA3 File Offset: 0x00004EA3
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00006CAB File Offset: 0x00004EAB
		public double dLatitude
		{
			get
			{
				return this._dLatitude;
			}
			set
			{
				this._dLatitude = value;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00006CB4 File Offset: 0x00004EB4
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x00006CBC File Offset: 0x00004EBC
		public double dLongitude
		{
			get
			{
				return this._dLongitude;
			}
			set
			{
				this._dLongitude = value;
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00006CC8 File Offset: 0x00004EC8
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.tId, 0);
			_os.Write(this.iSectionId, 1);
			_os.Write(this.iTag, 2);
			_os.Write(this.iPage, 3);
			_os.Write(this.iPageSize, 4);
			_os.Write(this.iUseLocation, 6);
			_os.Write(this.dLatitude, 7);
			_os.Write(this.dLongitude, 8);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00006D40 File Offset: 0x00004F40
		public override void ReadFrom(JceInputStream _is)
		{
			this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
			this.iSectionId = _is.Read(this.iSectionId, 1, false);
			this.iTag = _is.Read(this.iTag, 2, false);
			this.iPage = _is.Read(this.iPage, 3, false);
			this.iPageSize = _is.Read(this.iPageSize, 4, false);
			this.iUseLocation = _is.Read(this.iUseLocation, 6, false);
			this.dLatitude = _is.Read(this.dLatitude, 7, false);
			this.dLongitude = _is.Read(this.dLongitude, 8, false);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00006DF4 File Offset: 0x00004FF4
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display<UserId>(this.tId, "tId");
			jceDisplayer.Display(this.iSectionId, "iSectionId");
			jceDisplayer.Display(this.iTag, "iTag");
			jceDisplayer.Display(this.iPage, "iPage");
			jceDisplayer.Display(this.iPageSize, "iPageSize");
			jceDisplayer.Display(this.iUseLocation, "iUseLocation");
			jceDisplayer.Display(this.dLatitude, "dLatitude");
			jceDisplayer.Display(this.dLongitude, "dLongitude");
		}

		// Token: 0x04000777 RID: 1911
		private int _iSectionId;

		// Token: 0x04000778 RID: 1912
		private int _iTag;

		// Token: 0x04000779 RID: 1913
		private int _iPage;

		// Token: 0x0400077A RID: 1914
		private int _iPageSize;

		// Token: 0x0400077B RID: 1915
		private int _iUseLocation;

		// Token: 0x0400077C RID: 1916
		private double _dLatitude;

		// Token: 0x0400077D RID: 1917
		private double _dLongitude;
	}
}
