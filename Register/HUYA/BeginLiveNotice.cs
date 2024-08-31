using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200001A RID: 26
	public sealed class BeginLiveNotice : JceStruct
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00003A87 File Offset: 0x00001C87
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00003A8F File Offset: 0x00001C8F
		public long lPresenterUid
		{
			get
			{
				return this._lPresenterUid;
			}
			set
			{
				this._lPresenterUid = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00003A98 File Offset: 0x00001C98
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00003AA0 File Offset: 0x00001CA0
		public int iGameId
		{
			get
			{
				return this._iGameId;
			}
			set
			{
				this._iGameId = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00003AA9 File Offset: 0x00001CA9
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00003AB1 File Offset: 0x00001CB1
		public string sGameName
		{
			get
			{
				return this._sGameName;
			}
			set
			{
				this._sGameName = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00003ABA File Offset: 0x00001CBA
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00003AC2 File Offset: 0x00001CC2
		public int iRandomRange
		{
			get
			{
				return this._iRandomRange;
			}
			set
			{
				this._iRandomRange = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00003ACB File Offset: 0x00001CCB
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00003AD3 File Offset: 0x00001CD3
		public int iStreamType
		{
			get
			{
				return this._iStreamType;
			}
			set
			{
				this._iStreamType = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00003ADC File Offset: 0x00001CDC
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00003AE4 File Offset: 0x00001CE4
		public List<StreamInfo> vStreamInfo { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00003AED File Offset: 0x00001CED
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00003AF5 File Offset: 0x00001CF5
		public List<string> vCdnList { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00003AFE File Offset: 0x00001CFE
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00003B06 File Offset: 0x00001D06
		public long lLiveId
		{
			get
			{
				return this._lLiveId;
			}
			set
			{
				this._lLiveId = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00003B0F File Offset: 0x00001D0F
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00003B17 File Offset: 0x00001D17
		public int iPCDefaultBitRate
		{
			get
			{
				return this._iPCDefaultBitRate;
			}
			set
			{
				this._iPCDefaultBitRate = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00003B20 File Offset: 0x00001D20
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00003B28 File Offset: 0x00001D28
		public int iWebDefaultBitRate
		{
			get
			{
				return this._iWebDefaultBitRate;
			}
			set
			{
				this._iWebDefaultBitRate = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00003B31 File Offset: 0x00001D31
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00003B39 File Offset: 0x00001D39
		public int iMobileDefaultBitRate
		{
			get
			{
				return this._iMobileDefaultBitRate;
			}
			set
			{
				this._iMobileDefaultBitRate = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00003B42 File Offset: 0x00001D42
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00003B4A File Offset: 0x00001D4A
		public long lMultiStreamFlag
		{
			get
			{
				return this._lMultiStreamFlag;
			}
			set
			{
				this._lMultiStreamFlag = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00003B53 File Offset: 0x00001D53
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00003B5B File Offset: 0x00001D5B
		public string sNick
		{
			get
			{
				return this._sNick;
			}
			set
			{
				this._sNick = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00003B64 File Offset: 0x00001D64
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00003B6C File Offset: 0x00001D6C
		public long lYYId
		{
			get
			{
				return this._lYYId;
			}
			set
			{
				this._lYYId = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00003B75 File Offset: 0x00001D75
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00003B7D File Offset: 0x00001D7D
		public long lAttendeeCount
		{
			get
			{
				return this._lAttendeeCount;
			}
			set
			{
				this._lAttendeeCount = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00003B86 File Offset: 0x00001D86
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00003B8E File Offset: 0x00001D8E
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

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00003B97 File Offset: 0x00001D97
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00003B9F File Offset: 0x00001D9F
		public int iScreenType
		{
			get
			{
				return this._iScreenType;
			}
			set
			{
				this._iScreenType = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00003BA8 File Offset: 0x00001DA8
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00003BB0 File Offset: 0x00001DB0
		public List<MultiStreamInfo> vMultiStreamInfo { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00003BB9 File Offset: 0x00001DB9
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00003BC1 File Offset: 0x00001DC1
		public string sLiveDesc
		{
			get
			{
				return this._sLiveDesc;
			}
			set
			{
				this._sLiveDesc = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00003BCA File Offset: 0x00001DCA
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00003BD2 File Offset: 0x00001DD2
		public long lLiveCompatibleFlag
		{
			get
			{
				return this._lLiveCompatibleFlag;
			}
			set
			{
				this._lLiveCompatibleFlag = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00003BDB File Offset: 0x00001DDB
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00003BE3 File Offset: 0x00001DE3
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

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00003BEC File Offset: 0x00001DEC
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00003BF4 File Offset: 0x00001DF4
		public int iSourceType
		{
			get
			{
				return this._iSourceType;
			}
			set
			{
				this._iSourceType = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00003BFD File Offset: 0x00001DFD
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00003C05 File Offset: 0x00001E05
		public string sSubchannelName
		{
			get
			{
				return this._sSubchannelName;
			}
			set
			{
				this._sSubchannelName = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00003C0E File Offset: 0x00001E0E
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00003C16 File Offset: 0x00001E16
		public string sVideoCaptureUrl
		{
			get
			{
				return this._sVideoCaptureUrl;
			}
			set
			{
				this._sVideoCaptureUrl = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00003C1F File Offset: 0x00001E1F
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00003C27 File Offset: 0x00001E27
		public int iStartTime
		{
			get
			{
				return this._iStartTime;
			}
			set
			{
				this._iStartTime = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00003C30 File Offset: 0x00001E30
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00003C38 File Offset: 0x00001E38
		public long lChannelId
		{
			get
			{
				return this._lChannelId;
			}
			set
			{
				this._lChannelId = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00003C41 File Offset: 0x00001E41
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00003C49 File Offset: 0x00001E49
		public long lSubChannelId
		{
			get
			{
				return this._lSubChannelId;
			}
			set
			{
				this._lSubChannelId = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00003C52 File Offset: 0x00001E52
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00003C5A File Offset: 0x00001E5A
		public string sLocation
		{
			get
			{
				return this._sLocation;
			}
			set
			{
				this._sLocation = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00003C63 File Offset: 0x00001E63
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00003C6B File Offset: 0x00001E6B
		public int iCdnPolicyLevel
		{
			get
			{
				return this._iCdnPolicyLevel;
			}
			set
			{
				this._iCdnPolicyLevel = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00003C74 File Offset: 0x00001E74
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00003C7C File Offset: 0x00001E7C
		public int iGameType
		{
			get
			{
				return this._iGameType;
			}
			set
			{
				this._iGameType = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00003C85 File Offset: 0x00001E85
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00003C8D File Offset: 0x00001E8D
		public Dictionary<string, string> mMiscInfo { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00003C96 File Offset: 0x00001E96
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00003C9E File Offset: 0x00001E9E
		public int iShortChannel
		{
			get
			{
				return this._iShortChannel;
			}
			set
			{
				this._iShortChannel = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00003CA7 File Offset: 0x00001EA7
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00003CAF File Offset: 0x00001EAF
		public int iRoomId
		{
			get
			{
				return this._iRoomId;
			}
			set
			{
				this._iRoomId = value;
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00003CB8 File Offset: 0x00001EB8
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lPresenterUid, 0);
			_os.Write(this.iGameId, 1);
			_os.Write(this.sGameName, 2, false);
			_os.Write(this.iRandomRange, 3);
			_os.Write(this.iStreamType, 4);
			_os.Write(this.vStreamInfo, 5);
			_os.Write(this.vCdnList, 6);
			_os.Write(this.lLiveId, 7);
			_os.Write(this.iPCDefaultBitRate, 8);
			_os.Write(this.iWebDefaultBitRate, 9);
			_os.Write(this.iMobileDefaultBitRate, 10);
			_os.Write(this.lMultiStreamFlag, 11);
			_os.Write(this.sNick, 12, false);
			_os.Write(this.lYYId, 13);
			_os.Write(this.lAttendeeCount, 14);
			_os.Write(this.iCodecType, 15);
			_os.Write(this.iScreenType, 16);
			_os.Write(this.vMultiStreamInfo, 17);
			_os.Write(this.sLiveDesc, 18, false);
			_os.Write(this.lLiveCompatibleFlag, 19);
			_os.Write(this.sAvatarUrl, 20, false);
			_os.Write(this.iSourceType, 21);
			_os.Write(this.sSubchannelName, 22, false);
			_os.Write(this.sVideoCaptureUrl, 23, false);
			_os.Write(this.iStartTime, 24);
			_os.Write(this.lChannelId, 25);
			_os.Write(this.lSubChannelId, 26);
			_os.Write(this.sLocation, 27, false);
			_os.Write(this.iCdnPolicyLevel, 28);
			_os.Write(this.iGameType, 29);
			_os.Write(this.mMiscInfo, 30);
			_os.Write(this.iShortChannel, 31);
			_os.Write(this.iRoomId, 32);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00003E94 File Offset: 0x00002094
		public override void ReadFrom(JceInputStream _is)
		{
			this.lPresenterUid = _is.Read(this.lPresenterUid, 0, false);
			this.iGameId = _is.Read(this.iGameId, 1, false);
			this.sGameName = _is.Read(this.sGameName, 2, false);
			this.iRandomRange = _is.Read(this.iRandomRange, 3, false);
			this.iStreamType = _is.Read(this.iStreamType, 4, false);
			this.vStreamInfo = (List<StreamInfo>)_is.Read<List<StreamInfo>>(this.vStreamInfo, 5, false);
			this.vCdnList = (List<string>)_is.Read<List<string>>(this.vCdnList, 6, false);
			this.lLiveId = _is.Read(this.lLiveId, 7, false);
			this.iPCDefaultBitRate = _is.Read(this.iPCDefaultBitRate, 8, false);
			this.iWebDefaultBitRate = _is.Read(this.iWebDefaultBitRate, 9, false);
			this.iMobileDefaultBitRate = _is.Read(this.iMobileDefaultBitRate, 10, false);
			this.lMultiStreamFlag = _is.Read(this.lMultiStreamFlag, 11, false);
			this.sNick = _is.Read(this.sNick, 12, false);
			this.lYYId = _is.Read(this.lYYId, 13, false);
			this.lAttendeeCount = _is.Read(this.lAttendeeCount, 14, false);
			this.iCodecType = _is.Read(this.iCodecType, 15, false);
			this.iScreenType = _is.Read(this.iScreenType, 16, false);
			this.vMultiStreamInfo = (List<MultiStreamInfo>)_is.Read<List<MultiStreamInfo>>(this.vMultiStreamInfo, 17, false);
			this.sLiveDesc = _is.Read(this.sLiveDesc, 18, false);
			this.lLiveCompatibleFlag = _is.Read(this.lLiveCompatibleFlag, 19, false);
			this.sAvatarUrl = _is.Read(this.sAvatarUrl, 20, false);
			this.iSourceType = _is.Read(this.iSourceType, 21, false);
			this.sSubchannelName = _is.Read(this.sSubchannelName, 22, false);
			this.sVideoCaptureUrl = _is.Read(this.sVideoCaptureUrl, 23, false);
			this.iStartTime = _is.Read(this.iStartTime, 24, false);
			this.lChannelId = _is.Read(this.lChannelId, 25, false);
			this.lSubChannelId = _is.Read(this.lSubChannelId, 26, false);
			this.sLocation = _is.Read(this.sLocation, 27, false);
			this.iCdnPolicyLevel = _is.Read(this.iCdnPolicyLevel, 28, false);
			this.iGameType = _is.Read(this.iGameType, 29, false);
			this.mMiscInfo = (Dictionary<string, string>)_is.Read<Dictionary<string, string>>(this.mMiscInfo, 30, false);
			this.iShortChannel = _is.Read(this.iShortChannel, 31, false);
			this.iRoomId = _is.Read(this.iRoomId, 32, false);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00004164 File Offset: 0x00002364
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lPresenterUid, "lPresenterUid");
			jceDisplayer.Display(this.iGameId, "iGameId");
			jceDisplayer.Display(this.sGameName, "sGameName");
			jceDisplayer.Display(this.iRandomRange, "iRandomRange");
			jceDisplayer.Display(this.iStreamType, "iStreamType");
			jceDisplayer.Display<StreamInfo>(this.vStreamInfo, "vStreamInfo");
			jceDisplayer.Display<string>(this.vCdnList, "vCdnList");
			jceDisplayer.Display(this.lLiveId, "lLiveId");
			jceDisplayer.Display(this.iPCDefaultBitRate, "iPCDefaultBitRate");
			jceDisplayer.Display(this.iWebDefaultBitRate, "iWebDefaultBitRate");
			jceDisplayer.Display(this.iMobileDefaultBitRate, "iMobileDefaultBitRate");
			jceDisplayer.Display(this.lMultiStreamFlag, "lMultiStreamFlag");
			jceDisplayer.Display(this.sNick, "sNick");
			jceDisplayer.Display(this.lYYId, "lYYId");
			jceDisplayer.Display(this.lAttendeeCount, "lAttendeeCount");
			jceDisplayer.Display(this.iCodecType, "iCodecType");
			jceDisplayer.Display(this.iScreenType, "iScreenType");
			jceDisplayer.Display<MultiStreamInfo>(this.vMultiStreamInfo, "vMultiStreamInfo");
			jceDisplayer.Display(this.sLiveDesc, "sLiveDesc");
			jceDisplayer.Display(this.lLiveCompatibleFlag, "lLiveCompatibleFlag");
			jceDisplayer.Display(this.sAvatarUrl, "sAvatarUrl");
			jceDisplayer.Display(this.iSourceType, "iSourceType");
			jceDisplayer.Display(this.sSubchannelName, "sSubchannelName");
			jceDisplayer.Display(this.sVideoCaptureUrl, "sVideoCaptureUrl");
			jceDisplayer.Display(this.iStartTime, "iStartTime");
			jceDisplayer.Display(this.lChannelId, "lChannelId");
			jceDisplayer.Display(this.lSubChannelId, "lSubChannelId");
			jceDisplayer.Display(this.sLocation, "sLocation");
			jceDisplayer.Display(this.iCdnPolicyLevel, "iCdnPolicyLevel");
			jceDisplayer.Display(this.iGameType, "iGameType");
			jceDisplayer.Display<string, string>(this.mMiscInfo, "mMiscInfo");
			jceDisplayer.Display(this.iShortChannel, "iShortChannel");
			jceDisplayer.Display(this.iRoomId, "iRoomId");
		}

		// Token: 0x04000065 RID: 101
		private long _lPresenterUid;

		// Token: 0x04000066 RID: 102
		private int _iGameId;

		// Token: 0x04000067 RID: 103
		private string _sGameName = "";

		// Token: 0x04000068 RID: 104
		private int _iRandomRange;

		// Token: 0x04000069 RID: 105
		private int _iStreamType;

		// Token: 0x0400006C RID: 108
		private long _lLiveId;

		// Token: 0x0400006D RID: 109
		private int _iPCDefaultBitRate;

		// Token: 0x0400006E RID: 110
		private int _iWebDefaultBitRate;

		// Token: 0x0400006F RID: 111
		private int _iMobileDefaultBitRate;

		// Token: 0x04000070 RID: 112
		private long _lMultiStreamFlag;

		// Token: 0x04000071 RID: 113
		private string _sNick = "";

		// Token: 0x04000072 RID: 114
		private long _lYYId;

		// Token: 0x04000073 RID: 115
		private long _lAttendeeCount;

		// Token: 0x04000074 RID: 116
		private int _iCodecType;

		// Token: 0x04000075 RID: 117
		private int _iScreenType;

		// Token: 0x04000077 RID: 119
		private string _sLiveDesc = "";

		// Token: 0x04000078 RID: 120
		private long _lLiveCompatibleFlag;

		// Token: 0x04000079 RID: 121
		private string _sAvatarUrl = "";

		// Token: 0x0400007A RID: 122
		private int _iSourceType;

		// Token: 0x0400007B RID: 123
		private string _sSubchannelName = "";

		// Token: 0x0400007C RID: 124
		private string _sVideoCaptureUrl = "";

		// Token: 0x0400007D RID: 125
		private int _iStartTime;

		// Token: 0x0400007E RID: 126
		private long _lChannelId;

		// Token: 0x0400007F RID: 127
		private long _lSubChannelId;

		// Token: 0x04000080 RID: 128
		private string _sLocation = "";

		// Token: 0x04000081 RID: 129
		private int _iCdnPolicyLevel;

		// Token: 0x04000082 RID: 130
		private int _iGameType;

		// Token: 0x04000084 RID: 132
		private int _iShortChannel;

		// Token: 0x04000085 RID: 133
		private int _iRoomId;
	}
}
