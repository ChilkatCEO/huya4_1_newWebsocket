using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x02000020 RID: 32
	public sealed class GameLiveInfo : JceStruct
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00004B85 File Offset: 0x00002D85
		// (set) Token: 0x06000186 RID: 390 RVA: 0x00004B8D File Offset: 0x00002D8D
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

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00004B96 File Offset: 0x00002D96
		// (set) Token: 0x06000188 RID: 392 RVA: 0x00004B9E File Offset: 0x00002D9E
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

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00004BA7 File Offset: 0x00002DA7
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00004BAF File Offset: 0x00002DAF
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

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00004BB8 File Offset: 0x00002DB8
		// (set) Token: 0x0600018C RID: 396 RVA: 0x00004BC0 File Offset: 0x00002DC0
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

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00004BC9 File Offset: 0x00002DC9
		// (set) Token: 0x0600018E RID: 398 RVA: 0x00004BD1 File Offset: 0x00002DD1
		public long lSubchannel
		{
			get
			{
				return this._lSubchannel;
			}
			set
			{
				this._lSubchannel = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00004BDA File Offset: 0x00002DDA
		// (set) Token: 0x06000190 RID: 400 RVA: 0x00004BE2 File Offset: 0x00002DE2
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

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00004BEB File Offset: 0x00002DEB
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00004BF3 File Offset: 0x00002DF3
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

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00004BFC File Offset: 0x00002DFC
		// (set) Token: 0x06000194 RID: 404 RVA: 0x00004C04 File Offset: 0x00002E04
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

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00004C0D File Offset: 0x00002E0D
		// (set) Token: 0x06000196 RID: 406 RVA: 0x00004C15 File Offset: 0x00002E15
		public int iAttendeeCount
		{
			get
			{
				return this._iAttendeeCount;
			}
			set
			{
				this._iAttendeeCount = value;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00004C1E File Offset: 0x00002E1E
		// (set) Token: 0x06000198 RID: 408 RVA: 0x00004C26 File Offset: 0x00002E26
		public int eGender
		{
			get
			{
				return this._eGender;
			}
			set
			{
				this._eGender = value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00004C2F File Offset: 0x00002E2F
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00004C37 File Offset: 0x00002E37
		public int iAid
		{
			get
			{
				return this._iAid;
			}
			set
			{
				this._iAid = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00004C40 File Offset: 0x00002E40
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00004C48 File Offset: 0x00002E48
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

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00004C51 File Offset: 0x00002E51
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00004C59 File Offset: 0x00002E59
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

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00004C62 File Offset: 0x00002E62
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00004C6A File Offset: 0x00002E6A
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

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00004C73 File Offset: 0x00002E73
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00004C7B File Offset: 0x00002E7B
		public int iEndTime
		{
			get
			{
				return this._iEndTime;
			}
			set
			{
				this._iEndTime = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00004C84 File Offset: 0x00002E84
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00004C8C File Offset: 0x00002E8C
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

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00004C95 File Offset: 0x00002E95
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00004C9D File Offset: 0x00002E9D
		public bool bIsCameraOpen
		{
			get
			{
				return this._bIsCameraOpen;
			}
			set
			{
				this._bIsCameraOpen = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00004CA6 File Offset: 0x00002EA6
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x00004CAE File Offset: 0x00002EAE
		public bool bIsRoomSecret
		{
			get
			{
				return this._bIsRoomSecret;
			}
			set
			{
				this._bIsRoomSecret = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00004CB7 File Offset: 0x00002EB7
		// (set) Token: 0x060001AA RID: 426 RVA: 0x00004CBF File Offset: 0x00002EBF
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

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00004CC8 File Offset: 0x00002EC8
		// (set) Token: 0x060001AC RID: 428 RVA: 0x00004CD0 File Offset: 0x00002ED0
		public int iCdnAttendee
		{
			get
			{
				return this._iCdnAttendee;
			}
			set
			{
				this._iCdnAttendee = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00004CD9 File Offset: 0x00002ED9
		// (set) Token: 0x060001AE RID: 430 RVA: 0x00004CE1 File Offset: 0x00002EE1
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

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00004CEA File Offset: 0x00002EEA
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00004CF2 File Offset: 0x00002EF2
		public bool bCertified
		{
			get
			{
				return this._bCertified;
			}
			set
			{
				this._bCertified = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00004CFB File Offset: 0x00002EFB
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00004D03 File Offset: 0x00002F03
		public int iRecType
		{
			get
			{
				return this._iRecType;
			}
			set
			{
				this._iRecType = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00004D0C File Offset: 0x00002F0C
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x00004D14 File Offset: 0x00002F14
		public long lSignChannel
		{
			get
			{
				return this._lSignChannel;
			}
			set
			{
				this._lSignChannel = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00004D1D File Offset: 0x00002F1D
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x00004D25 File Offset: 0x00002F25
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

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00004D2E File Offset: 0x00002F2E
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00004D36 File Offset: 0x00002F36
		public int iLevel
		{
			get
			{
				return this._iLevel;
			}
			set
			{
				this._iLevel = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00004D3F File Offset: 0x00002F3F
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00004D47 File Offset: 0x00002F47
		public string sGameShortName
		{
			get
			{
				return this._sGameShortName;
			}
			set
			{
				this._sGameShortName = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00004D50 File Offset: 0x00002F50
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00004D58 File Offset: 0x00002F58
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

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00004D61 File Offset: 0x00002F61
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00004D69 File Offset: 0x00002F69
		public string sPrivateHost
		{
			get
			{
				return this._sPrivateHost;
			}
			set
			{
				this._sPrivateHost = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00004D72 File Offset: 0x00002F72
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00004D7A File Offset: 0x00002F7A
		public int iActivityCount
		{
			get
			{
				return this._iActivityCount;
			}
			set
			{
				this._iActivityCount = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00004D83 File Offset: 0x00002F83
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00004D8B File Offset: 0x00002F8B
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

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00004D94 File Offset: 0x00002F94
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00004D9C File Offset: 0x00002F9C
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

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00004DA5 File Offset: 0x00002FA5
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00004DAD File Offset: 0x00002FAD
		public int iResolution
		{
			get
			{
				return this._iResolution;
			}
			set
			{
				this._iResolution = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00004DB6 File Offset: 0x00002FB6
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00004DBE File Offset: 0x00002FBE
		public int iFrameRate
		{
			get
			{
				return this._iFrameRate;
			}
			set
			{
				this._iFrameRate = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00004DC7 File Offset: 0x00002FC7
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00004DCF File Offset: 0x00002FCF
		public int iIsMultiStream
		{
			get
			{
				return this._iIsMultiStream;
			}
			set
			{
				this._iIsMultiStream = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00004DD8 File Offset: 0x00002FD8
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00004DE0 File Offset: 0x00002FE0
		public int iExeGameId
		{
			get
			{
				return this._iExeGameId;
			}
			set
			{
				this._iExeGameId = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00004DE9 File Offset: 0x00002FE9
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00004DF1 File Offset: 0x00002FF1
		public long lExp
		{
			get
			{
				return this._lExp;
			}
			set
			{
				this._lExp = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00004DFA File Offset: 0x00002FFA
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00004E02 File Offset: 0x00003002
		public string sReplayHls
		{
			get
			{
				return this._sReplayHls;
			}
			set
			{
				this._sReplayHls = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00004E0B File Offset: 0x0000300B
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00004E13 File Offset: 0x00003013
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

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00004E1C File Offset: 0x0000301C
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00004E24 File Offset: 0x00003024
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

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00004E2D File Offset: 0x0000302D
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00004E35 File Offset: 0x00003035
		public int iChannelType
		{
			get
			{
				return this._iChannelType;
			}
			set
			{
				this._iChannelType = value;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00004E3E File Offset: 0x0000303E
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00004E46 File Offset: 0x00003046
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

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00004E4F File Offset: 0x0000304F
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00004E57 File Offset: 0x00003057
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

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00004E60 File Offset: 0x00003060
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00004E68 File Offset: 0x00003068
		public List<GameLiveTag> vPresenterTags { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00004E71 File Offset: 0x00003071
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00004E79 File Offset: 0x00003079
		public List<GameLiveTag> vGameTags { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00004E82 File Offset: 0x00003082
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00004E8A File Offset: 0x0000308A
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

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00004E93 File Offset: 0x00003093
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00004E9B File Offset: 0x0000309B
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

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00004EA4 File Offset: 0x000030A4
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00004EAC File Offset: 0x000030AC
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

		// Token: 0x060001E5 RID: 485 RVA: 0x00004EB8 File Offset: 0x000030B8
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lLiveId, 0);
			_os.Write(this.lUid, 1);
			_os.Write(this.lChannelId, 2);
			_os.Write(this.iShortChannel, 3);
			_os.Write(this.lSubchannel, 4);
			_os.Write(this.sSubchannelName, 5, false);
			_os.Write(this.iGameId, 6);
			_os.Write(this.sGameName, 7, false);
			_os.Write(this.iAttendeeCount, 8);
			_os.Write(this.eGender, 9);
			_os.Write(this.iAid, 10);
			_os.Write(this.sNick, 11, false);
			_os.Write(this.sAvatarUrl, 12, false);
			_os.Write(this.iStartTime, 13);
			_os.Write(this.iEndTime, 14);
			_os.Write(this.iSourceType, 15);
			_os.Write(this.bIsCameraOpen, 16);
			_os.Write(this.bIsRoomSecret, 17);
			_os.Write(this.sVideoCaptureUrl, 18, false);
			_os.Write(this.iCdnAttendee, 19);
			_os.Write(this.lYYId, 20);
			_os.Write(this.bCertified, 21);
			_os.Write(this.iRecType, 22);
			_os.Write(this.lSignChannel, 23);
			_os.Write(this.sLiveDesc, 24, false);
			_os.Write(this.iLevel, 25);
			_os.Write(this.sGameShortName, 26, false);
			_os.Write(this.iGameType, 27);
			_os.Write(this.sPrivateHost, 28, false);
			_os.Write(this.iActivityCount, 29);
			_os.Write(this.iStreamType, 30);
			_os.Write(this.iBitRate, 31);
			_os.Write(this.iResolution, 32);
			_os.Write(this.iFrameRate, 33);
			_os.Write(this.iIsMultiStream, 34);
			_os.Write(this.iExeGameId, 35);
			_os.Write(this.lExp, 36);
			_os.Write(this.sReplayHls, 37, false);
			_os.Write(this.lMultiStreamFlag, 38);
			_os.Write(this.iScreenType, 39);
			_os.Write(this.iChannelType, 40);
			_os.Write(this.sLocation, 41, false);
			_os.Write(this.iCodecType, 42);
			_os.Write(this.vPresenterTags, 43);
			_os.Write(this.vGameTags, 44);
			_os.Write(this.lLiveCompatibleFlag, 45);
			_os.Write(this.sTraceId, 46, false);
			_os.Write(this.iRoomId, 47);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00005168 File Offset: 0x00003368
		public override void ReadFrom(JceInputStream _is)
		{
			this.lLiveId = _is.Read(this.lLiveId, 0, false);
			this.lUid = _is.Read(this.lUid, 1, false);
			this.lChannelId = _is.Read(this.lChannelId, 2, false);
			this.iShortChannel = _is.Read(this.iShortChannel, 3, false);
			this.lSubchannel = _is.Read(this.lSubchannel, 4, false);
			this.sSubchannelName = _is.Read(this.sSubchannelName, 5, false);
			this.iGameId = _is.Read(this.iGameId, 6, false);
			this.sGameName = _is.Read(this.sGameName, 7, false);
			this.iAttendeeCount = _is.Read(this.iAttendeeCount, 8, false);
			this.eGender = _is.Read(this.eGender, 9, false);
			this.iAid = _is.Read(this.iAid, 10, false);
			this.sNick = _is.Read(this.sNick, 11, false);
			this.sAvatarUrl = _is.Read(this.sAvatarUrl, 12, false);
			this.iStartTime = _is.Read(this.iStartTime, 13, false);
			this.iEndTime = _is.Read(this.iEndTime, 14, false);
			this.iSourceType = _is.Read(this.iSourceType, 15, false);
			this.bIsCameraOpen = _is.Read(this.bIsCameraOpen, 16, false);
			this.bIsRoomSecret = _is.Read(this.bIsRoomSecret, 17, false);
			this.sVideoCaptureUrl = _is.Read(this.sVideoCaptureUrl, 18, false);
			this.iCdnAttendee = _is.Read(this.iCdnAttendee, 19, false);
			this.lYYId = _is.Read(this.lYYId, 20, false);
			this.bCertified = _is.Read(this.bCertified, 21, false);
			this.iRecType = _is.Read(this.iRecType, 22, false);
			this.lSignChannel = _is.Read(this.lSignChannel, 23, false);
			this.sLiveDesc = _is.Read(this.sLiveDesc, 24, false);
			this.iLevel = _is.Read(this.iLevel, 25, false);
			this.sGameShortName = _is.Read(this.sGameShortName, 26, false);
			this.iGameType = _is.Read(this.iGameType, 27, false);
			this.sPrivateHost = _is.Read(this.sPrivateHost, 28, false);
			this.iActivityCount = _is.Read(this.iActivityCount, 29, false);
			this.iStreamType = _is.Read(this.iStreamType, 30, false);
			this.iBitRate = _is.Read(this.iBitRate, 31, false);
			this.iResolution = _is.Read(this.iResolution, 32, false);
			this.iFrameRate = _is.Read(this.iFrameRate, 33, false);
			this.iIsMultiStream = _is.Read(this.iIsMultiStream, 34, false);
			this.iExeGameId = _is.Read(this.iExeGameId, 35, false);
			this.lExp = _is.Read(this.lExp, 36, false);
			this.sReplayHls = _is.Read(this.sReplayHls, 37, false);
			this.lMultiStreamFlag = _is.Read(this.lMultiStreamFlag, 38, false);
			this.iScreenType = _is.Read(this.iScreenType, 39, false);
			this.iChannelType = _is.Read(this.iChannelType, 40, false);
			this.sLocation = _is.Read(this.sLocation, 41, false);
			this.iCodecType = _is.Read(this.iCodecType, 42, false);
			this.vPresenterTags = (List<GameLiveTag>)_is.Read<List<GameLiveTag>>(this.vPresenterTags, 43, false);
			this.vGameTags = (List<GameLiveTag>)_is.Read<List<GameLiveTag>>(this.vGameTags, 44, false);
			this.lLiveCompatibleFlag = _is.Read(this.lLiveCompatibleFlag, 45, false);
			this.sTraceId = _is.Read(this.sTraceId, 46, false);
			this.iRoomId = _is.Read(this.iRoomId, 47, false);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00005568 File Offset: 0x00003768
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lLiveId, "lLiveId");
			jceDisplayer.Display(this.lUid, "lUid");
			jceDisplayer.Display(this.lChannelId, "lChannelId");
			jceDisplayer.Display(this.iShortChannel, "iShortChannel");
			jceDisplayer.Display(this.lSubchannel, "lSubchannel");
			jceDisplayer.Display(this.sSubchannelName, "sSubchannelName");
			jceDisplayer.Display(this.iGameId, "iGameId");
			jceDisplayer.Display(this.sGameName, "sGameName");
			jceDisplayer.Display(this.iAttendeeCount, "iAttendeeCount");
			jceDisplayer.Display(this.eGender, "eGender");
			jceDisplayer.Display(this.iAid, "iAid");
			jceDisplayer.Display(this.sNick, "sNick");
			jceDisplayer.Display(this.sAvatarUrl, "sAvatarUrl");
			jceDisplayer.Display(this.iStartTime, "iStartTime");
			jceDisplayer.Display(this.iEndTime, "iEndTime");
			jceDisplayer.Display(this.iSourceType, "iSourceType");
			jceDisplayer.Display(this.bIsCameraOpen, "bIsCameraOpen");
			jceDisplayer.Display(this.bIsRoomSecret, "bIsRoomSecret");
			jceDisplayer.Display(this.sVideoCaptureUrl, "sVideoCaptureUrl");
			jceDisplayer.Display(this.iCdnAttendee, "iCdnAttendee");
			jceDisplayer.Display(this.lYYId, "lYYId");
			jceDisplayer.Display(this.bCertified, "bCertified");
			jceDisplayer.Display(this.iRecType, "iRecType");
			jceDisplayer.Display(this.lSignChannel, "lSignChannel");
			jceDisplayer.Display(this.sLiveDesc, "sLiveDesc");
			jceDisplayer.Display(this.iLevel, "iLevel");
			jceDisplayer.Display(this.sGameShortName, "sGameShortName");
			jceDisplayer.Display(this.iGameType, "iGameType");
			jceDisplayer.Display(this.sPrivateHost, "sPrivateHost");
			jceDisplayer.Display(this.iActivityCount, "iActivityCount");
			jceDisplayer.Display(this.iStreamType, "iStreamType");
			jceDisplayer.Display(this.iBitRate, "iBitRate");
			jceDisplayer.Display(this.iResolution, "iResolution");
			jceDisplayer.Display(this.iFrameRate, "iFrameRate");
			jceDisplayer.Display(this.iIsMultiStream, "iIsMultiStream");
			jceDisplayer.Display(this.iExeGameId, "iExeGameId");
			jceDisplayer.Display(this.lExp, "lExp");
			jceDisplayer.Display(this.sReplayHls, "sReplayHls");
			jceDisplayer.Display(this.lMultiStreamFlag, "lMultiStreamFlag");
			jceDisplayer.Display(this.iScreenType, "iScreenType");
			jceDisplayer.Display(this.iChannelType, "iChannelType");
			jceDisplayer.Display(this.sLocation, "sLocation");
			jceDisplayer.Display(this.iCodecType, "iCodecType");
			jceDisplayer.Display<GameLiveTag>(this.vPresenterTags, "vPresenterTags");
			jceDisplayer.Display<GameLiveTag>(this.vGameTags, "vGameTags");
			jceDisplayer.Display(this.lLiveCompatibleFlag, "lLiveCompatibleFlag");
			jceDisplayer.Display(this.sTraceId, "sTraceId");
			jceDisplayer.Display(this.iRoomId, "iRoomId");
		}

		// Token: 0x0400009E RID: 158
		private long _lLiveId;

		// Token: 0x0400009F RID: 159
		private long _lUid;

		// Token: 0x040000A0 RID: 160
		private long _lChannelId;

		// Token: 0x040000A1 RID: 161
		private int _iShortChannel;

		// Token: 0x040000A2 RID: 162
		private long _lSubchannel;

		// Token: 0x040000A3 RID: 163
		private string _sSubchannelName = "";

		// Token: 0x040000A4 RID: 164
		private int _iGameId;

		// Token: 0x040000A5 RID: 165
		private string _sGameName = "";

		// Token: 0x040000A6 RID: 166
		private int _iAttendeeCount;

		// Token: 0x040000A7 RID: 167
		private int _eGender;

		// Token: 0x040000A8 RID: 168
		private int _iAid;

		// Token: 0x040000A9 RID: 169
		private string _sNick = "";

		// Token: 0x040000AA RID: 170
		private string _sAvatarUrl = "";

		// Token: 0x040000AB RID: 171
		private int _iStartTime;

		// Token: 0x040000AC RID: 172
		private int _iEndTime;

		// Token: 0x040000AD RID: 173
		private int _iSourceType;

		// Token: 0x040000AE RID: 174
		private bool _bIsCameraOpen;

		// Token: 0x040000AF RID: 175
		private bool _bIsRoomSecret;

		// Token: 0x040000B0 RID: 176
		private string _sVideoCaptureUrl = "";

		// Token: 0x040000B1 RID: 177
		private int _iCdnAttendee;

		// Token: 0x040000B2 RID: 178
		private long _lYYId;

		// Token: 0x040000B3 RID: 179
		private bool _bCertified;

		// Token: 0x040000B4 RID: 180
		private int _iRecType;

		// Token: 0x040000B5 RID: 181
		private long _lSignChannel;

		// Token: 0x040000B6 RID: 182
		private string _sLiveDesc = "";

		// Token: 0x040000B7 RID: 183
		private int _iLevel;

		// Token: 0x040000B8 RID: 184
		private string _sGameShortName = "";

		// Token: 0x040000B9 RID: 185
		private int _iGameType;

		// Token: 0x040000BA RID: 186
		private string _sPrivateHost = "";

		// Token: 0x040000BB RID: 187
		private int _iActivityCount;

		// Token: 0x040000BC RID: 188
		private int _iStreamType;

		// Token: 0x040000BD RID: 189
		private int _iBitRate;

		// Token: 0x040000BE RID: 190
		private int _iResolution;

		// Token: 0x040000BF RID: 191
		private int _iFrameRate;

		// Token: 0x040000C0 RID: 192
		private int _iIsMultiStream;

		// Token: 0x040000C1 RID: 193
		private int _iExeGameId;

		// Token: 0x040000C2 RID: 194
		private long _lExp;

		// Token: 0x040000C3 RID: 195
		private string _sReplayHls = "";

		// Token: 0x040000C4 RID: 196
		private long _lMultiStreamFlag;

		// Token: 0x040000C5 RID: 197
		private int _iScreenType;

		// Token: 0x040000C6 RID: 198
		private int _iChannelType;

		// Token: 0x040000C7 RID: 199
		private string _sLocation = "";

		// Token: 0x040000C8 RID: 200
		private int _iCodecType;

		// Token: 0x040000CB RID: 203
		private long _lLiveCompatibleFlag;

		// Token: 0x040000CC RID: 204
		private string _sTraceId = "";

		// Token: 0x040000CD RID: 205
		private int _iRoomId;
	}
}
