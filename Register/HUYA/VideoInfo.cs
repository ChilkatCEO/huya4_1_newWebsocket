using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000F0 RID: 240
	public sealed class VideoInfo : JceStruct
	{
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x00009805 File Offset: 0x00007A05
		// (set) Token: 0x060003FB RID: 1019 RVA: 0x0000980D File Offset: 0x00007A0D
		public long lUid
		{
			get
			{
				return this._lUid;
			}
			set
			{
				this._lUid = value;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x00009816 File Offset: 0x00007A16
		// (set) Token: 0x060003FD RID: 1021 RVA: 0x0000981E File Offset: 0x00007A1E
		public string sAvatarUrl
		{
			get
			{
				return this._sAvatarUrl;
			}
			set
			{
				this._sAvatarUrl = value;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x00009827 File Offset: 0x00007A27
		// (set) Token: 0x060003FF RID: 1023 RVA: 0x0000982F File Offset: 0x00007A2F
		public string sNickName
		{
			get
			{
				return this._sNickName;
			}
			set
			{
				this._sNickName = value;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x00009838 File Offset: 0x00007A38
		// (set) Token: 0x06000401 RID: 1025 RVA: 0x00009840 File Offset: 0x00007A40
		public long lVid
		{
			get
			{
				return this._lVid;
			}
			set
			{
				this._lVid = value;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00009849 File Offset: 0x00007A49
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x00009851 File Offset: 0x00007A51
		public string sVideoTitle
		{
			get
			{
				return this._sVideoTitle;
			}
			set
			{
				this._sVideoTitle = value;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x0000985A File Offset: 0x00007A5A
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x00009862 File Offset: 0x00007A62
		public string sVideoCover
		{
			get
			{
				return this._sVideoCover;
			}
			set
			{
				this._sVideoCover = value;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x0000986B File Offset: 0x00007A6B
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x00009873 File Offset: 0x00007A73
		public long lVideoPlayNum
		{
			get
			{
				return this._lVideoPlayNum;
			}
			set
			{
				this._lVideoPlayNum = value;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x0000987C File Offset: 0x00007A7C
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x00009884 File Offset: 0x00007A84
		public long lVideoCommentNum
		{
			get
			{
				return this._lVideoCommentNum;
			}
			set
			{
				this._lVideoCommentNum = value;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x0000988D File Offset: 0x00007A8D
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x00009895 File Offset: 0x00007A95
		public string sVideoDuration
		{
			get
			{
				return this._sVideoDuration;
			}
			set
			{
				this._sVideoDuration = value;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x0000989E File Offset: 0x00007A9E
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x000098A6 File Offset: 0x00007AA6
		public string sVideoUrl
		{
			get
			{
				return this._sVideoUrl;
			}
			set
			{
				this._sVideoUrl = value;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x000098AF File Offset: 0x00007AAF
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x000098B7 File Offset: 0x00007AB7
		public string sVideoUploadTime
		{
			get
			{
				return this._sVideoUploadTime;
			}
			set
			{
				this._sVideoUploadTime = value;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x000098C0 File Offset: 0x00007AC0
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x000098C8 File Offset: 0x00007AC8
		public string sVideoChannel
		{
			get
			{
				return this._sVideoChannel;
			}
			set
			{
				this._sVideoChannel = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x000098D1 File Offset: 0x00007AD1
		// (set) Token: 0x06000413 RID: 1043 RVA: 0x000098D9 File Offset: 0x00007AD9
		public string sCategory
		{
			get
			{
				return this._sCategory;
			}
			set
			{
				this._sCategory = value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x000098E2 File Offset: 0x00007AE2
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x000098EA File Offset: 0x00007AEA
		public List<VideoDefinition> vDefinitions { get; set; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x000098F3 File Offset: 0x00007AF3
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x000098FB File Offset: 0x00007AFB
		public int iVideoRecommend
		{
			get
			{
				return this._iVideoRecommend;
			}
			set
			{
				this._iVideoRecommend = value;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x00009904 File Offset: 0x00007B04
		// (set) Token: 0x06000419 RID: 1049 RVA: 0x0000990C File Offset: 0x00007B0C
		public bool bVideoDot
		{
			get
			{
				return this._bVideoDot;
			}
			set
			{
				this._bVideoDot = value;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x00009915 File Offset: 0x00007B15
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x0000991D File Offset: 0x00007B1D
		public long lVideoRank
		{
			get
			{
				return this._lVideoRank;
			}
			set
			{
				this._lVideoRank = value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00009926 File Offset: 0x00007B26
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x0000992E File Offset: 0x00007B2E
		public bool bVideoHasRanked
		{
			get
			{
				return this._bVideoHasRanked;
			}
			set
			{
				this._bVideoHasRanked = value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00009937 File Offset: 0x00007B37
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x0000993F File Offset: 0x00007B3F
		public string sTraceId
		{
			get
			{
				return this._sTraceId;
			}
			set
			{
				this._sTraceId = value;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00009948 File Offset: 0x00007B48
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x00009950 File Offset: 0x00007B50
		public long lActorUid
		{
			get
			{
				return this._lActorUid;
			}
			set
			{
				this._lActorUid = value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x00009959 File Offset: 0x00007B59
		// (set) Token: 0x06000423 RID: 1059 RVA: 0x00009961 File Offset: 0x00007B61
		public string sActorNick
		{
			get
			{
				return this._sActorNick;
			}
			set
			{
				this._sActorNick = value;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x0000996A File Offset: 0x00007B6A
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x00009972 File Offset: 0x00007B72
		public string sActorAvatarUrl
		{
			get
			{
				return this._sActorAvatarUrl;
			}
			set
			{
				this._sActorAvatarUrl = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000997B File Offset: 0x00007B7B
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00009983 File Offset: 0x00007B83
		public int iExtPlayTimes
		{
			get
			{
				return this._iExtPlayTimes;
			}
			set
			{
				this._iExtPlayTimes = value;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x0000998C File Offset: 0x00007B8C
		// (set) Token: 0x06000429 RID: 1065 RVA: 0x00009994 File Offset: 0x00007B94
		public string sVideoBigCover
		{
			get
			{
				return this._sVideoBigCover;
			}
			set
			{
				this._sVideoBigCover = value;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000999D File Offset: 0x00007B9D
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x000099A5 File Offset: 0x00007BA5
		public int iCommentCount
		{
			get
			{
				return this._iCommentCount;
			}
			set
			{
				this._iCommentCount = value;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x000099AE File Offset: 0x00007BAE
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x000099B6 File Offset: 0x00007BB6
		public List<string> vTags { get; set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x000099BF File Offset: 0x00007BBF
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x000099C7 File Offset: 0x00007BC7
		public int iVideoDirection
		{
			get
			{
				return this._iVideoDirection;
			}
			set
			{
				this._iVideoDirection = value;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x000099D0 File Offset: 0x00007BD0
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x000099D8 File Offset: 0x00007BD8
		public string sBriefIntroduction
		{
			get
			{
				return this._sBriefIntroduction;
			}
			set
			{
				this._sBriefIntroduction = value;
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000099E4 File Offset: 0x00007BE4
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lUid, 0);
			_os.Write(this.sAvatarUrl, 1, false);
			_os.Write(this.sNickName, 2, false);
			_os.Write(this.lVid, 3);
			_os.Write(this.sVideoTitle, 4, false);
			_os.Write(this.sVideoCover, 5, false);
			_os.Write(this.lVideoPlayNum, 6);
			_os.Write(this.lVideoCommentNum, 7);
			_os.Write(this.sVideoDuration, 8, false);
			_os.Write(this.sVideoUrl, 9, false);
			_os.Write(this.sVideoUploadTime, 10, false);
			_os.Write(this.sVideoChannel, 11, false);
			_os.Write(this.sCategory, 12, false);
			_os.Write(this.vDefinitions, 13);
			_os.Write(this.iVideoRecommend, 14);
			_os.Write(this.bVideoDot, 15);
			_os.Write(this.lVideoRank, 16);
			_os.Write(this.bVideoHasRanked, 17);
			_os.Write(this.sTraceId, 18, false);
			_os.Write(this.lActorUid, 19);
			_os.Write(this.sActorNick, 20, false);
			_os.Write(this.sActorAvatarUrl, 21, false);
			_os.Write(this.iExtPlayTimes, 22);
			_os.Write(this.sVideoBigCover, 23, false);
			_os.Write(this.iCommentCount, 24);
			_os.Write(this.vTags, 25);
			_os.Write(this.iVideoDirection, 26);
			_os.Write(this.sBriefIntroduction, 27, false);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00009B80 File Offset: 0x00007D80
		public override void ReadFrom(JceInputStream _is)
		{
			this.lUid = _is.Read(this.lUid, 0, false);
			this.sAvatarUrl = _is.Read(this.sAvatarUrl, 1, false);
			this.sNickName = _is.Read(this.sNickName, 2, false);
			this.lVid = _is.Read(this.lVid, 3, false);
			this.sVideoTitle = _is.Read(this.sVideoTitle, 4, false);
			this.sVideoCover = _is.Read(this.sVideoCover, 5, false);
			this.lVideoPlayNum = _is.Read(this.lVideoPlayNum, 6, false);
			this.lVideoCommentNum = _is.Read(this.lVideoCommentNum, 7, false);
			this.sVideoDuration = _is.Read(this.sVideoDuration, 8, false);
			this.sVideoUrl = _is.Read(this.sVideoUrl, 9, false);
			this.sVideoUploadTime = _is.Read(this.sVideoUploadTime, 10, false);
			this.sVideoChannel = _is.Read(this.sVideoChannel, 11, false);
			this.sCategory = _is.Read(this.sCategory, 12, false);
			this.vDefinitions = (List<VideoDefinition>)_is.Read<List<VideoDefinition>>(this.vDefinitions, 13, false);
			this.iVideoRecommend = _is.Read(this.iVideoRecommend, 14, false);
			this.bVideoDot = _is.Read(this.bVideoDot, 15, false);
			this.lVideoRank = _is.Read(this.lVideoRank, 16, false);
			this.bVideoHasRanked = _is.Read(this.bVideoHasRanked, 17, false);
			this.sTraceId = _is.Read(this.sTraceId, 18, false);
			this.lActorUid = _is.Read(this.lActorUid, 19, false);
			this.sActorNick = _is.Read(this.sActorNick, 20, false);
			this.sActorAvatarUrl = _is.Read(this.sActorAvatarUrl, 21, false);
			this.iExtPlayTimes = _is.Read(this.iExtPlayTimes, 22, false);
			this.sVideoBigCover = _is.Read(this.sVideoBigCover, 23, false);
			this.iCommentCount = _is.Read(this.iCommentCount, 24, false);
			this.vTags = (List<string>)_is.Read<List<string>>(this.vTags, 25, false);
			this.iVideoDirection = _is.Read(this.iVideoDirection, 26, false);
			this.sBriefIntroduction = _is.Read(this.sBriefIntroduction, 27, false);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00009DDC File Offset: 0x00007FDC
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lUid, "lUid");
			jceDisplayer.Display(this.sAvatarUrl, "sAvatarUrl");
			jceDisplayer.Display(this.sNickName, "sNickName");
			jceDisplayer.Display(this.lVid, "lVid");
			jceDisplayer.Display(this.sVideoTitle, "sVideoTitle");
			jceDisplayer.Display(this.sVideoCover, "sVideoCover");
			jceDisplayer.Display(this.lVideoPlayNum, "lVideoPlayNum");
			jceDisplayer.Display(this.lVideoCommentNum, "lVideoCommentNum");
			jceDisplayer.Display(this.sVideoDuration, "sVideoDuration");
			jceDisplayer.Display(this.sVideoUrl, "sVideoUrl");
			jceDisplayer.Display(this.sVideoUploadTime, "sVideoUploadTime");
			jceDisplayer.Display(this.sVideoChannel, "sVideoChannel");
			jceDisplayer.Display(this.sCategory, "sCategory");
			jceDisplayer.Display<VideoDefinition>(this.vDefinitions, "vDefinitions");
			jceDisplayer.Display(this.iVideoRecommend, "iVideoRecommend");
			jceDisplayer.Display(this.bVideoDot, "bVideoDot");
			jceDisplayer.Display(this.lVideoRank, "lVideoRank");
			jceDisplayer.Display(this.bVideoHasRanked, "bVideoHasRanked");
			jceDisplayer.Display(this.sTraceId, "sTraceId");
			jceDisplayer.Display(this.lActorUid, "lActorUid");
			jceDisplayer.Display(this.sActorNick, "sActorNick");
			jceDisplayer.Display(this.sActorAvatarUrl, "sActorAvatarUrl");
			jceDisplayer.Display(this.iExtPlayTimes, "iExtPlayTimes");
			jceDisplayer.Display(this.sVideoBigCover, "sVideoBigCover");
			jceDisplayer.Display(this.iCommentCount, "iCommentCount");
			jceDisplayer.Display<string>(this.vTags, "vTags");
			jceDisplayer.Display(this.iVideoDirection, "iVideoDirection");
			jceDisplayer.Display(this.sBriefIntroduction, "sBriefIntroduction");
		}

		// Token: 0x04000803 RID: 2051
		private long _lUid;

		// Token: 0x04000804 RID: 2052
		private string _sAvatarUrl = "";

		// Token: 0x04000805 RID: 2053
		private string _sNickName = "";

		// Token: 0x04000806 RID: 2054
		private long _lVid;

		// Token: 0x04000807 RID: 2055
		private string _sVideoTitle = "";

		// Token: 0x04000808 RID: 2056
		private string _sVideoCover = "";

		// Token: 0x04000809 RID: 2057
		private long _lVideoPlayNum;

		// Token: 0x0400080A RID: 2058
		private long _lVideoCommentNum;

		// Token: 0x0400080B RID: 2059
		private string _sVideoDuration = "";

		// Token: 0x0400080C RID: 2060
		private string _sVideoUrl = "";

		// Token: 0x0400080D RID: 2061
		private string _sVideoUploadTime = "";

		// Token: 0x0400080E RID: 2062
		private string _sVideoChannel = "";

		// Token: 0x0400080F RID: 2063
		private string _sCategory = "";

		// Token: 0x04000811 RID: 2065
		private int _iVideoRecommend;

		// Token: 0x04000812 RID: 2066
		private bool _bVideoDot = true;

		// Token: 0x04000813 RID: 2067
		private long _lVideoRank;

		// Token: 0x04000814 RID: 2068
		private bool _bVideoHasRanked = true;

		// Token: 0x04000815 RID: 2069
		private string _sTraceId = "";

		// Token: 0x04000816 RID: 2070
		private long _lActorUid;

		// Token: 0x04000817 RID: 2071
		private string _sActorNick = "";

		// Token: 0x04000818 RID: 2072
		private string _sActorAvatarUrl = "";

		// Token: 0x04000819 RID: 2073
		private int _iExtPlayTimes;

		// Token: 0x0400081A RID: 2074
		private string _sVideoBigCover = "";

		// Token: 0x0400081B RID: 2075
		private int _iCommentCount;

		// Token: 0x0400081D RID: 2077
		private int _iVideoDirection;

		// Token: 0x0400081E RID: 2078
		private string _sBriefIntroduction = "";
	}
}
