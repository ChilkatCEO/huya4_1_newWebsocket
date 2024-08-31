using iHUYA;
using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E2 RID: 226
	public sealed class MGetLiveListRsp : JceStruct
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00006E97 File Offset: 0x00005097
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00006E9F File Offset: 0x0000509F
		public int iTotalCount
		{
			get
			{
				return this._iTotalCount;
			}
			set
			{
				this._iTotalCount = value;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00006EA8 File Offset: 0x000050A8
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00006EB0 File Offset: 0x000050B0
		public List<GameLiveInfo> vLives { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00006EB9 File Offset: 0x000050B9
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00006EC1 File Offset: 0x000050C1
		public List<MTagInfo> vTags { get; set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00006ECA File Offset: 0x000050CA
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00006ED2 File Offset: 0x000050D2
		public List<BannerItem> vBanners { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00006EDB File Offset: 0x000050DB
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00006EE3 File Offset: 0x000050E3
		public int iViewType
		{
			get
			{
				return this._iViewType;
			}
			set
			{
				this._iViewType = value;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00006EEC File Offset: 0x000050EC
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00006EF4 File Offset: 0x000050F4
		public int iHasMore
		{
			get
			{
				return this._iHasMore;
			}
			set
			{
				this._iHasMore = value;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00006EFD File Offset: 0x000050FD
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00006F05 File Offset: 0x00005105
		public List<UpcommingEventInfo> vUpcommingEvent { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00006F0E File Offset: 0x0000510E
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00006F16 File Offset: 0x00005116
		public List<LiveListRecGameItem> vLiveListRecGameItem { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00006F1F File Offset: 0x0000511F
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00006F27 File Offset: 0x00005127
		public List<VideoInfo> vRecVideoInfo { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00006F30 File Offset: 0x00005130
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00006F38 File Offset: 0x00005138
		public List<ActiveEventInfo> vActiveEventInfo { get; set; }

		// Token: 0x060002CC RID: 716 RVA: 0x00006F44 File Offset: 0x00005144
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iTotalCount, 1);
			_os.Write(this.vLives, 2);
			_os.Write(this.vTags, 3);
			_os.Write(this.vBanners, 4);
			_os.Write(this.iViewType, 5);
			_os.Write(this.iHasMore, 6);
			_os.Write(this.vUpcommingEvent, 7);
			_os.Write(this.vLiveListRecGameItem, 8);
			_os.Write(this.vRecVideoInfo, 9);
			_os.Write(this.vActiveEventInfo, 10);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00006FD8 File Offset: 0x000051D8
		public override void ReadFrom(JceInputStream _is)
		{
			this.iTotalCount = _is.Read(this.iTotalCount, 1, false);
			this.vLives = (List<GameLiveInfo>)_is.Read<List<GameLiveInfo>>(this.vLives, 2, false);
			this.vTags = (List<MTagInfo>)_is.Read<List<MTagInfo>>(this.vTags, 3, false);
			this.vBanners = (List<BannerItem>)_is.Read<List<BannerItem>>(this.vBanners, 4, false);
			this.iViewType = _is.Read(this.iViewType, 5, false);
			this.iHasMore = _is.Read(this.iHasMore, 6, false);
			this.vUpcommingEvent = (List<UpcommingEventInfo>)_is.Read<List<UpcommingEventInfo>>(this.vUpcommingEvent, 7, false);
			this.vLiveListRecGameItem = (List<LiveListRecGameItem>)_is.Read<List<LiveListRecGameItem>>(this.vLiveListRecGameItem, 8, false);
			this.vRecVideoInfo = (List<VideoInfo>)_is.Read<List<VideoInfo>>(this.vRecVideoInfo, 9, false);
			this.vActiveEventInfo = (List<ActiveEventInfo>)_is.Read<List<ActiveEventInfo>>(this.vActiveEventInfo, 10, false);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x000070D4 File Offset: 0x000052D4
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.iTotalCount, "iTotalCount");
			jceDisplayer.Display<GameLiveInfo>(this.vLives, "vLives");
			jceDisplayer.Display<MTagInfo>(this.vTags, "vTags");
			jceDisplayer.Display<BannerItem>(this.vBanners, "vBanners");
			jceDisplayer.Display(this.iViewType, "iViewType");
			jceDisplayer.Display(this.iHasMore, "iHasMore");
			jceDisplayer.Display<UpcommingEventInfo>(this.vUpcommingEvent, "vUpcommingEvent");
			jceDisplayer.Display<LiveListRecGameItem>(this.vLiveListRecGameItem, "vLiveListRecGameItem");
			jceDisplayer.Display<VideoInfo>(this.vRecVideoInfo, "vRecVideoInfo");
			jceDisplayer.Display<ActiveEventInfo>(this.vActiveEventInfo, "vActiveEventInfo");
		}

		// Token: 0x0400077E RID: 1918
		private int _iTotalCount;

		// Token: 0x04000782 RID: 1922
		private int _iViewType;

		// Token: 0x04000783 RID: 1923
		private int _iHasMore;
	}
}
