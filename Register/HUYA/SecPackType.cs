using System;

namespace HUYA
{
	// Token: 0x02000030 RID: 48
	public enum SecPackType
	{
		// Token: 0x040000FE RID: 254
		kSecPackTypeNobleTips = 1000,
		// Token: 0x040000FF RID: 255
		kSecPackTypeNewNobleNotice,
		// Token: 0x04000100 RID: 256
		kSecPackTypeNobleEnterNotice,
		// Token: 0x04000101 RID: 257
		kSecPackTypeNobleSpeak,
		// Token: 0x04000102 RID: 258
		kSecPackTypeNobleSpeakNew,
		// Token: 0x04000103 RID: 259
		kecPackTypeNobleEnterSingle,
		// Token: 0x04000104 RID: 260
		kSecPackTypeNobleEnd = 1203,
		// Token: 0x04000105 RID: 261
		kSecPackTypeMessageNotice = 1400,
		// Token: 0x04000106 RID: 262
		kSecPackTypeAdsBegin = 1500,
		// Token: 0x04000107 RID: 263
		kSecPackTypeAdsPush,
		// Token: 0x04000108 RID: 264
		KSecPackTypeAdsChannelPush,
		// Token: 0x04000109 RID: 265
		kSecPackTypeAdsEnd = 2000,
		// Token: 0x0400010A RID: 266
		KSecPackTypeSubscribeBegin = 3100,
		// Token: 0x0400010B RID: 267
		kSecPackTypeSubscribePresenterNotice,
		// Token: 0x0400010C RID: 268
		kSecPackTypeSubscribeInfoNotice,
		// Token: 0x0400010D RID: 269
		kSecPackTypeSubscribePresenterNoticeTaf,
		// Token: 0x0400010E RID: 270
		kSecPackTypeSubscribeInfoNoticeTaf,
		// Token: 0x0400010F RID: 271
		kSecPackTypeSubscribeEnd = 3199,
		// Token: 0x04000110 RID: 272
		kSecPackTypeSubscribeInform = 3140,
		// Token: 0x04000111 RID: 273
		kSecPackTypeBlackWordBc = 10000,
		// Token: 0x04000112 RID: 274
		kSecPackTypeBlackWordBcNew,
		// Token: 0x04000113 RID: 275
		kSecPackTourFieldAudienceNotice = 5151,
		// Token: 0x04000114 RID: 276
		kPSecPackTourFieldPresenterNotice,
		// Token: 0x04000115 RID: 277
		kPSecPackStampUserListNotice = 5160,
		// Token: 0x04000116 RID: 278
		kPSecPackPrincessUpgradeNotice,
		// Token: 0x04000117 RID: 279
		kPSecPackTop10PrincessGlamourListNotice,
		// Token: 0x04000118 RID: 280
		kPSecPackTop10RicherListNotice,
		// Token: 0x04000119 RID: 281
		kPSecPackRicherWeekRank10ChangeNotice,
		// Token: 0x0400011A RID: 282
		kPSecPackGlamourWeekRank10ChangeNotice,
		// Token: 0x0400011B RID: 283
		kPSecPackTop10RicherEnterNotice,
		// Token: 0x0400011C RID: 284
		kSecPackTypeRecptionRankListNotice = 5170,
		// Token: 0x0400011D RID: 285
		kSecPackTypeRecptionRankEnterNotice,
		// Token: 0x0400011E RID: 286
		kSecPackTypeUserCardNotice = 6001,
		// Token: 0x0400011F RID: 287
		kSecPackTypeUserInfoChange,
		// Token: 0x04000120 RID: 288
		kSecPackUserBarNotice = 6051,
		// Token: 0x04000121 RID: 289
		kSecPackTypeWeekStarPropsWeekChanged = 6100,
		// Token: 0x04000122 RID: 290
		kSecPackTypeFaceWeekStarWeekChanged,
		// Token: 0x04000123 RID: 291
		kSecPackVipEnterBanner = 6110,
		// Token: 0x04000124 RID: 292
		kSecPackEnterPushInfoNotice = 6200,
		// Token: 0x04000125 RID: 293
		kSecPackGameAdvertisementNotice,
		// Token: 0x04000126 RID: 294
		kSecPackAdvanceUserEnterNotice,
		// Token: 0x04000127 RID: 295
		kSecPackViewerListNotice,
		// Token: 0x04000128 RID: 296
		kSecPackVipBarListNotice = 6210,
		// Token: 0x04000129 RID: 297
		kSecPackWeekRankListNotice = 6220,
		// Token: 0x0400012A RID: 298
		kSecPackWeekRankEnterBanner,
		// Token: 0x0400012B RID: 299
		kSecPackWeekRankChangeBanner,
		// Token: 0x0400012C RID: 300
		kSecPackFansSupportListNotice,
		// Token: 0x0400012D RID: 301
		kSecPackFansRankListNotice = 6230,
		// Token: 0x0400012E RID: 302
		kSecPackFansUsingBadgeInfoNotice,
		// Token: 0x0400012F RID: 303
		kSecPackFansBadgeScoreChangedNotice,
		// Token: 0x04000130 RID: 304
		kSecPackFansInfoNotice,
		// Token: 0x04000131 RID: 305
		kSecPackUserGetGiftNotice,
		// Token: 0x04000132 RID: 306
		kSecPackGiftBarNotice = 6250,
		// Token: 0x04000133 RID: 307
		kSecPackChampionPresenterEnterChannel = 6260,
		// Token: 0x04000134 RID: 308
		kSecPackActivityStatusNotice = 6270,
		// Token: 0x04000135 RID: 309
		kSecPackH5ActivityHorizontalInfoChanged,
		// Token: 0x04000136 RID: 310
		kSecPackLuckyCatPannel = 6280,
		// Token: 0x04000137 RID: 311
		kSecPackLuckyCatAwardNotice,
		// Token: 0x04000138 RID: 312
		kSecPackLuckyCatStateChanged,
		// Token: 0x04000139 RID: 313
		kSecPackNewsTickerNotice = 6290,
		// Token: 0x0400013A RID: 314
		kSecPackPKStartNotice = 6302,
		// Token: 0x0400013B RID: 315
		kSecPackPKEndNotice,
		// Token: 0x0400013C RID: 316
		kSecPackPKRoundStartNotice,
		// Token: 0x0400013D RID: 317
		kSecPackPKRoundEndNotice,
		// Token: 0x0400013E RID: 318
		kSecPackPKInviteeNotice,
		// Token: 0x0400013F RID: 319
		kSecPackPKInviterRsp,
		// Token: 0x04000140 RID: 320
		kSecPackPKOpponentMsg,
		// Token: 0x04000141 RID: 321
		kSecPackPKInfoNotice = 6320,
		// Token: 0x04000142 RID: 322
		kSecPackPKLotteryNotice,
		// Token: 0x04000143 RID: 323
		kSecPackPKSpeakNotice,
		// Token: 0x04000144 RID: 324
		kSecPackCheckRoomStatusNotice = 6340,
		// Token: 0x04000145 RID: 325
		kSecPackTypeItemConsumBegin = 6500,
		// Token: 0x04000146 RID: 326
		kSecPackTypeItemConsumSubNotify,
		// Token: 0x04000147 RID: 327
		kSecPackTypeItemConsumTopNotify,
		// Token: 0x04000148 RID: 328
		kSecPackTypeItemUpdateNotify,
		// Token: 0x04000149 RID: 329
		kSecPackTypeItemPresenterNotify,
		// Token: 0x0400014A RID: 330
		kSecPackTypeItemReloadNotify,
		// Token: 0x0400014B RID: 331
		kSecPackTypeTreasureLotteryResultNotice = 6600,
		// Token: 0x0400014C RID: 332
		kSecPackTypeTreasureNotice,
		// Token: 0x0400014D RID: 333
		kSecPackTypeTreasureResultBroadcast,
		// Token: 0x0400014E RID: 334
		kSecPackTypeTreasureStatNotice,
		// Token: 0x0400014F RID: 335
		kSecPackTypeTreasureSendNotice,
		// Token: 0x04000150 RID: 336
		kSecPackTypeTreasureLotteryResultBroadCast,
		// Token: 0x04000151 RID: 337
		KSecPackTypeHongBaoInfoNotify = 6610,
		// Token: 0x04000152 RID: 338
		KSecPackTypeHongBaoSubChannelNotify,
		// Token: 0x04000153 RID: 339
		KSecPackTypeHongBaoAllChannelNotify,
		// Token: 0x04000154 RID: 340
		KSecPackTypeHongBaoFecthSubChannelNotify,
		// Token: 0x04000155 RID: 341
		KSecPackTypeHongBaoFetchFinishNotify,
		// Token: 0x04000156 RID: 342
		KSecPackTypeHongBaoTimeCountdownNotify,
		// Token: 0x04000157 RID: 343
		kSecPackTypeContributionPresenterNotify = 6630,
		// Token: 0x04000158 RID: 344
		kSecPackTypeContributionRankNotify,
		// Token: 0x04000159 RID: 345
		kSecPackTypeContributionRankChangeBanner,
		// Token: 0x0400015A RID: 346
		kSecPackTypeShowScreenSkinNotify = 6640,
		// Token: 0x0400015B RID: 347
		kSecPackTypeHideScreenSkinNotify,
		// Token: 0x0400015C RID: 348
		kSecPackTypeShowPrePictureNotify,
		// Token: 0x0400015D RID: 349
		kSecPackTypeHidePrePictureNotify,
		// Token: 0x0400015E RID: 350
		kSecPackTypeItemConsumEnd = 7000,
		// Token: 0x0400015F RID: 351
		kSecPackTypeClickPraiseNotice = 7010,
		// Token: 0x04000160 RID: 352
		kSecPackTypeUserStampNotice,
		// Token: 0x04000161 RID: 353
		kSecPackTypeGambleResultNoticePacket,
		// Token: 0x04000162 RID: 354
		kSecPackTypeUserStampListNoticePacket,
		// Token: 0x04000163 RID: 355
		kSecPackTypeVideoModeNoticePacket,
		// Token: 0x04000164 RID: 356
		kSecPackTypeGrantLuckBagNotice,
		// Token: 0x04000165 RID: 357
		kSecPackTypeGrantBigLuckBagNotice,
		// Token: 0x04000166 RID: 358
		kSecPackTypePetardPanelInfoNotice,
		// Token: 0x04000167 RID: 359
		kSecPackTypePetardRankInfoNotice,
		// Token: 0x04000168 RID: 360
		kSecPackTypeRankChangeNotice,
		// Token: 0x04000169 RID: 361
		kSecPackTypeClickLuckBagNotice,
		// Token: 0x0400016A RID: 362
		kSecPackTypeMonsterEntryNotice,
		// Token: 0x0400016B RID: 363
		kSecPackTypeAwardNotice,
		// Token: 0x0400016C RID: 364
		kSecPackTypeBeatMonstorResultNotice,
		// Token: 0x0400016D RID: 365
		kSecPackTypeCountDownNotice,
		// Token: 0x0400016E RID: 366
		kSecPackTypeStandingsTopThreeNotice,
		// Token: 0x0400016F RID: 367
		kSecPackTypeEndMonstorNotice,
		// Token: 0x04000170 RID: 368
		kSecPackTypeGetFreePropNotice,
		// Token: 0x04000171 RID: 369
		kSecPackTypeIntegralTopThreeNotice = 7030,
		// Token: 0x04000172 RID: 370
		kSecPackTypeTopicListNotice = 7050,
		// Token: 0x04000173 RID: 371
		kSecPacketRaffleWinnerNotice = 7054,
		// Token: 0x04000174 RID: 372
		kSecPacketRaffleResultNotice,
		// Token: 0x04000175 RID: 373
		kSecPackTypeBatchGameInfoNotice = 7500,
		// Token: 0x04000176 RID: 374
		kSecPackTypeGameInfoChangeNotice,
		// Token: 0x04000177 RID: 375
		kSecPackTypeEndHistoryGameNotice,
		// Token: 0x04000178 RID: 376
		kSecPackTypeGameSettlementNotice,
		// Token: 0x04000179 RID: 377
		kSecPackTypePresenterEndGameNotice,
		// Token: 0x0400017A RID: 378
		kSecPackTypeBuyBetNotice,
		// Token: 0x0400017B RID: 379
		kSecPackTypePresenterEndBreakGameNotice,
		// Token: 0x0400017C RID: 380
		kSecPackTypeActiveGameRspNotice,
		// Token: 0x0400017D RID: 381
		kSecPackTypeSuspendGameRspNotice,
		// Token: 0x0400017E RID: 382
		kSecPackTypeResumeGameRspNotice,
		// Token: 0x0400017F RID: 383
		kSecPackTypePresenterEndGameRspNotice,
		// Token: 0x04000180 RID: 384
		kSecPackTypePanelInfoNotice = 7600,
		// Token: 0x04000181 RID: 385
		kSecPackTypeRankInfoNotice,
		// Token: 0x04000182 RID: 386
		kSecPackTypePresenterPopupNotice,
		// Token: 0x04000183 RID: 387
		kSecPackTypeDownPlaneNotice,
		// Token: 0x04000184 RID: 388
		kSecPackTypePlanePopupNotice,
		// Token: 0x04000185 RID: 389
		kSecPackTypePlayPlaneRankChangeNotice,
		// Token: 0x04000186 RID: 390
		kSecPackTypePresenterUpgradeNotice = 7700,
		// Token: 0x04000187 RID: 391
		kSecPackTypeWelfareTaskNotice,
		// Token: 0x04000188 RID: 392
		kSecPackTypeWelfareTaskResultNotice,
		// Token: 0x04000189 RID: 393
		kSecPackTypeWelfarePackageStartNotice,
		// Token: 0x0400018A RID: 394
		kSecPackTypeWelfarePackageNotice,
		// Token: 0x0400018B RID: 395
		kSecPackTypeWelfareWinnersNotice,
		// Token: 0x0400018C RID: 396
		kSecPackTypeWelfarePackageEndNotice,
		// Token: 0x0400018D RID: 397
		kSecPackTypePresenterLevelInfoNotice,
		// Token: 0x0400018E RID: 398
		kSecPackTypeBeginLiveNotice = 8000,
		// Token: 0x0400018F RID: 399
		kSecPackTypeEndLiveNotice,
		// Token: 0x04000190 RID: 400
		kSecPackTypeStreamSetting,
		// Token: 0x04000191 RID: 401
		kSecPackTypeStreamEndNotice,
		// Token: 0x04000192 RID: 402
		kSecPackTypeLiveInfoChangedNotice,
		// Token: 0x04000193 RID: 403
		kSecPackTypeForceChangeStreamSettingNotice,
		// Token: 0x04000194 RID: 404
		kSecPackTypeAttendeeCountNotice,
		// Token: 0x04000195 RID: 405
		kSecPackTypePresenterListChangeNotice,
		// Token: 0x04000196 RID: 406
		kSecPackTypeRePushCdnNotice = 8900,
		// Token: 0x04000197 RID: 407
		kSecPackTypeAddCdnLineNotice,
		// Token: 0x04000198 RID: 408
		kSecPackTypeChangePushStreamNotice,
		// Token: 0x04000199 RID: 409
		kSecPackTypeLinkMicPresenterMessage = 9000,
		// Token: 0x0400019A RID: 410
		kSecPackTypeReplayPresenterInLive = 9010,
		// Token: 0x0400019B RID: 411
		kSecPackTypeReplayMessage,
		// Token: 0x0400019C RID: 412
		KSecPackTypeTelecomSpeedup,
		// Token: 0x0400019D RID: 413
		kSecPackTypeBlackWordsNotice = 10010,
		// Token: 0x0400019E RID: 414
		kSecPackTypeTransmitMsg = 10020,
		// Token: 0x0400019F RID: 415
		kSecPackTypeWelcomeTextNotice = 10030,
		// Token: 0x040001A0 RID: 416
		kSecPackTypeEnterLivePushConfig,
		// Token: 0x040001A1 RID: 417
		kSecPackTypeCoverHostPushConfig,
		// Token: 0x040001A2 RID: 418
		kSecPackTypeAuditorEnterLiveNotice = 10040,
		// Token: 0x040001A3 RID: 419
		kSecPackTypeAuditorRoleChangeNotice,
		// Token: 0x040001A4 RID: 420
		kSecPackTypeRoomAuditConfNotice,
		// Token: 0x040001A5 RID: 421
		kSecPackTypeCharadesRankNotice = 10050,
		// Token: 0x040001A6 RID: 422
		kSecPackTypeLMInviteReq = 42005,
		// Token: 0x040001A7 RID: 423
		kSecPackTypeLMInviteResp,
		// Token: 0x040001A8 RID: 424
		kSecPackTypeLMStatusChangeNotice = 42008,
		// Token: 0x040001A9 RID: 425
		kSecPackTypeLMRemovePresenterReq,
		// Token: 0x040001AA RID: 426
		kConfigurableChatNotice = 43000,
		// Token: 0x040001AB RID: 427
		kSecPackTypeInterveneCountRsp = 44000,
		// Token: 0x040001AC RID: 428
		kSecPackTypeUploadLog = 100100,
		// Token: 0x040001AD RID: 429
		KSecPackTypeMLiveComment = 1000001,
		// Token: 0x040001AE RID: 430
		KSecPackTypeMLiveFavor,
		// Token: 0x040001AF RID: 431
		KSecPackTypeMLiveLiveInfo,
		// Token: 0x040001B0 RID: 432
		KSecPackTypeMLiveEnterLive,
		// Token: 0x040001B1 RID: 433
		KSecPackTypeMLiveLeaveLive,
		// Token: 0x040001B2 RID: 434
		KSecPackTypeMLivePresentGift,
		// Token: 0x040001B3 RID: 435
		KSecPackTypeMLiveUserInteraction,
		// Token: 0x040001B4 RID: 436
		KSecPackTypeMLiveEndLive,
		// Token: 0x040001B5 RID: 437
		kSecPackTypeMLinkMicSwitchNotify,
		// Token: 0x040001B6 RID: 438
		kSecPackTypeMLinkMicSeatStatNotify,
		// Token: 0x040001B7 RID: 439
		kSecPackTypeMLinkMicStatNotifyOld,
		// Token: 0x040001B8 RID: 440
		kSecPackTypeMLinkMicStatNotify,
		// Token: 0x040001B9 RID: 441
		kSecPackTypeMVideoLinkMicStatNotify = 1000031,
		// Token: 0x040001BA RID: 442
		kSecPackTypeMVideoLinkMicActionNotify,
		// Token: 0x040001BB RID: 443
		kSecPackTypeMVideoLinkMicStatNotify2,
		// Token: 0x040001BC RID: 444
		kSecPackTypeLiveFavorNotify = 1000101,
		// Token: 0x040001BD RID: 445
		kSecPackTypeUserEnter,
		// Token: 0x040001BE RID: 446
		kSecPackTypeUserLeave,
		// Token: 0x040001BF RID: 447
		kSecPackTypeLiveSharedNotify,
		// Token: 0x040001C0 RID: 448
		kSecPackTypeUDBSafeNotify,
		// Token: 0x040001C1 RID: 449
		KSecPackTypeUserLevelUpgradeNotice,
		// Token: 0x040001C2 RID: 450
		KSecPackTypeUserNovieTaskComplete,
		// Token: 0x040001C3 RID: 451
		kSecPackTypeFansVideoSharedNotify,
		// Token: 0x040001C4 RID: 452
		kSecPackTypeCorpsMsg = 1010001,
		// Token: 0x040001C5 RID: 453
		kSecPackTypeActivityCommon,
		// Token: 0x040001C6 RID: 454
		kSecPackTypeActivityMsgNotice,
		// Token: 0x040001C7 RID: 455
		kSecPackTypeActivityUserInfo,
		// Token: 0x040001C8 RID: 456
		kSecPackTypeGuardianNoticeInfoList = 1020000,
		// Token: 0x040001C9 RID: 457
		kSecPackTypeGuardianPresenterInfoNotice,
		// Token: 0x040001CA RID: 458
		kSecPackTypeDailyPresentNotice,
		// Token: 0x040001CB RID: 459
		kSecPackTypeUserTeaseRecordsBroadcast = 1020100,
		// Token: 0x040001CC RID: 460
		kSecPackTypeGameInfoNotice,
		// Token: 0x040001CD RID: 461
		kSecPackTypeEndGameNotice,
		// Token: 0x040001CE RID: 462
		kSecPackTypeLuckyUserNotice,
		// Token: 0x040001CF RID: 463
		kSecPackTypeGameStartNotice,
		// Token: 0x040001D0 RID: 464
		kSecPackTypeBoxTaskCleanBroadcast = 1020200,
		// Token: 0x040001D1 RID: 465
		kSecPackTypeTexasActionResp = 1021003,
		// Token: 0x040001D2 RID: 466
		kSecPackTypeTexasCardInfoNotice,
		// Token: 0x040001D3 RID: 467
		kSecPackTypeTexasActionNotice,
		// Token: 0x040001D4 RID: 468
		kSecPackTypeTexasGameResultNotify,
		// Token: 0x040001D5 RID: 469
		kSecPackTypeTexasRoundOverNotice,
		// Token: 0x040001D6 RID: 470
		kSecPackTypeTexasDealCardsNotice,
		// Token: 0x040001D7 RID: 471
		kSecPackTypeTexasGameOverNotify,
		// Token: 0x040001D8 RID: 472
		kSecPackTyperShowCardActionNotify,
		// Token: 0x040001D9 RID: 473
		kSecPackTypeTexasDelPlayerBroadcast,
		// Token: 0x040001DA RID: 474
		kSecPackTypeTexasNewGameBroadcast,
		// Token: 0x040001DB RID: 475
		kSecPackTypeTexasLiveInfoBroadcast,
		// Token: 0x040001DC RID: 476
		kSecPackTypeTexasPlayerLeaveBroadcast,
		// Token: 0x040001DD RID: 477
		kSecPackTypeTexasJoinGameBroadcast,
		// Token: 0x040001DE RID: 478
		kSecPackTypeTexasPlayerStatusBroadcast,
		// Token: 0x040001DF RID: 479
		kSecPackTypeTexasSpeakerBanBroadcast,
		// Token: 0x040001E0 RID: 480
		kSecPackTypeTexasCountdownBroadcast,
		// Token: 0x040001E1 RID: 481
		kSecPackTypeTexasRechargeBankrollBroadcast,
		// Token: 0x040001E2 RID: 482
		kSecPackTypeMsgPullNotify = 1022000
	}
}
