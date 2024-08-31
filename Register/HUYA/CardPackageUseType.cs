using System;

namespace HUYA
{
	// Token: 0x02000031 RID: 49
	public enum CardPackageUseType
	{
		// Token: 0x040001E4 RID: 484
		kCardPackageUseTypeGambling = 30,
		// Token: 0x040001E5 RID: 485
		kCardPackageUseTypeGBTransferWB,
		// Token: 0x040001E6 RID: 486
		kCardPackageUseTypeUseItem,
		// Token: 0x040001E7 RID: 487
		kCardPackageUseTypeCard,
		// Token: 0x040001E8 RID: 488
		kCardPackageUseTypeTreasure,
		// Token: 0x040001E9 RID: 489
		kCardPackageUseTypeGoldBTransferGB,
		// Token: 0x040001EA RID: 490
		kCardPackageUseTypeGetGBAfterSettle,
		// Token: 0x040001EB RID: 491
		kCardPackageUseTypeYBTransferGB,
		// Token: 0x040001EC RID: 492
		kCardPackageUseTypeGambleCommission,
		// Token: 0x040001ED RID: 493
		kCardPackageUseTypePresentation,
		// Token: 0x040001EE RID: 494
		kCardPackageUseTypeManual,
		// Token: 0x040001EF RID: 495
		kCardPackageUseTypeGoldBAutoTransferGB,
		// Token: 0x040001F0 RID: 496
		kCardPackageUseTypeBackFromDeposit,
		// Token: 0x040001F1 RID: 497
		kCardPackageUseTypeGuardianPresentaton,
		// Token: 0x040001F2 RID: 498
		kCardPackageUseTypeWebSpecialTopic,
		// Token: 0x040001F3 RID: 499
		kCardPackageUseTypeBindingGBTransferGB,
		// Token: 0x040001F4 RID: 500
		kCardPackageUseTypeGBTransferBindingGB,
		// Token: 0x040001F5 RID: 501
		kCardPackageUseTypeNewTask,
		// Token: 0x040001F6 RID: 502
		kCardPackageUseTypeJackpotBuy,
		// Token: 0x040001F7 RID: 503
		kCardPackageUseTypeJackpotCharge,
		// Token: 0x040001F8 RID: 504
		kCardPackageUseTypeDealPrsente,
		// Token: 0x040001F9 RID: 505
		kCardPackageUseTypeGoddessVote,
		// Token: 0x040001FA RID: 506
		kCardPackageUseTypeBuyCreditByGB,
		// Token: 0x040001FB RID: 507
		kCardPackageUseTypeFansProps,
		// Token: 0x040001FC RID: 508
		kCardPackageUseTypeGoldTicket,
		// Token: 0x040001FD RID: 509
		kCardPackageUseTypeYSL,
		// Token: 0x040001FE RID: 510
		kCardPackageUseTypeYSLGambling,
		// Token: 0x040001FF RID: 511
		kCardPackageUseTypeGamblingBet,
		// Token: 0x04000200 RID: 512
		kCardPackageUseTypeGamblingBuyBet,
		// Token: 0x04000201 RID: 513
		kCardPackageUseTypeGamblingBetBack,
		// Token: 0x04000202 RID: 514
		kCardPackageUseTypeGamblingBuyBetBack,
		// Token: 0x04000203 RID: 515
		kCardPackageUseTypeMatchGamblePay,
		// Token: 0x04000204 RID: 516
		kCardPackageUseTypeMatchGambleRecharge,
		// Token: 0x04000205 RID: 517
		kCardPackageUseTypeHuYaPlayPlane,
		// Token: 0x04000206 RID: 518
		kCardPackageUseTypeHuYaClickPraise,
		// Token: 0x04000207 RID: 519
		kCardPackageUseTypeHongBaoBet,
		// Token: 0x04000208 RID: 520
		kCardPackageUseTypeHongBaoRechnage,
		// Token: 0x04000209 RID: 521
		kCardPackageUseTypeHongBaoBetBack,
		// Token: 0x0400020A RID: 522
		kCardPackageUseTypeJieDaiRuning = 69,
		// Token: 0x0400020B RID: 523
		kCardPackageUseTypeOldDriverActivityWhiteBean,
		// Token: 0x0400020C RID: 524
		kCardPackageUseTypeHandDeductionGoldTicket,
		// Token: 0x0400020D RID: 525
		kCardPackageUsergeErrorFix,
		// Token: 0x0400020E RID: 526
		kCardPackageUseairForBug,
		// Token: 0x0400020F RID: 527
		kCardPackageUseTypePKGift,
		// Token: 0x04000210 RID: 528
		kCardPackageUseTypeGamblePayDeposit = 81,
		// Token: 0x04000211 RID: 529
		kCardPackageUseTypeGambleBackDeposit,
		// Token: 0x04000212 RID: 530
		kCardPackageUseTypeAnnualLottery = 6000,
		// Token: 0x04000213 RID: 531
		kCardPackageUseTypeTreasureMap,
		// Token: 0x04000214 RID: 532
		kCardPackageUseTypeHideBullet,
		// Token: 0x04000215 RID: 533
		kCardPackageUseTypeDreamTicketPresentation,
		// Token: 0x04000216 RID: 534
		kCardPackageUseTypeWangYiGameWithGB,
		// Token: 0x04000217 RID: 535
		kCardPackageUseTypeWangYiGameWithWB,
		// Token: 0x04000218 RID: 536
		kCardPackageUseTypeRewardGB,
		// Token: 0x04000219 RID: 537
		kCardPackageUseTypePunishGB,
		// Token: 0x0400021A RID: 538
		kCardPackageUseTypeTieBaWB,
		// Token: 0x0400021B RID: 539
		kCardPackageUseTypeFreezGBForCredit,
		// Token: 0x0400021C RID: 540
		kCardPackageUseTypeThawGbForCredit,
		// Token: 0x0400021D RID: 541
		kCardPackageUseTypeBlackGoldGB,
		// Token: 0x0400021E RID: 542
		kCardPackageUseTypeBlackGoldWB,
		// Token: 0x0400021F RID: 543
		kCardPackageUseTypeWangYi2GB,
		// Token: 0x04000220 RID: 544
		kCardPackageUseTypeWangYi2WB,
		// Token: 0x04000221 RID: 545
		kCardPackageUseTypeWuHunGB,
		// Token: 0x04000222 RID: 546
		kCardPackageUseTypeWuHunWB,
		// Token: 0x04000223 RID: 547
		kCardPackageUseTypeQianNvWB,
		// Token: 0x04000224 RID: 548
		kCardPackageUseTypeQianNvGB,
		// Token: 0x04000225 RID: 549
		kCardPackageUseTypeJiangHuGB,
		// Token: 0x04000226 RID: 550
		kCardPackageUseTypeZiZuan,
		// Token: 0x04000227 RID: 551
		kCardPackageUseTypeWarWorld,
		// Token: 0x04000228 RID: 552
		kCardPackageUseTypeCsOnline,
		// Token: 0x04000229 RID: 553
		kCardPackageUseTypeRepaireFailedRecharge,
		// Token: 0x0400022A RID: 554
		kCardPackageUseTypeJiuYin,
		// Token: 0x0400022B RID: 555
		kCardPackageUseTypeZuiLiu,
		// Token: 0x0400022C RID: 556
		kCardPackageUseTypeSheDiao,
		// Token: 0x0400022D RID: 557
		kCardPackageUseTypeJianNvYouHui,
		// Token: 0x0400022E RID: 558
		kCardPackageUseTypeWeiTeQuan,
		// Token: 0x0400022F RID: 559
		kCardPackageUseTypeJinGDong,
		// Token: 0x04000230 RID: 560
		kCardPackageUseTypeFBToGB,
		// Token: 0x04000231 RID: 561
		kCardPackageUseTypeGBToFB,
		// Token: 0x04000232 RID: 562
		kCardPackageUseTypeTexasPoker,
		// Token: 0x04000233 RID: 563
		kCardPackageUseTypeLingYu1,
		// Token: 0x04000234 RID: 564
		kCardPackageUseTypeLingYu2,
		// Token: 0x04000235 RID: 565
		kCardPackageUseTypeLingYu3,
		// Token: 0x04000236 RID: 566
		kCardPackageUseTypeLingYu4,
		// Token: 0x04000237 RID: 567
		kCardPackageUseTypeLingYu5,
		// Token: 0x04000238 RID: 568
		kCardPackageUseTypeLingYu6,
		// Token: 0x04000239 RID: 569
		kCardPackageUseTypeLingYu7 = 6040,
		// Token: 0x0400023A RID: 570
		kCardPackageUseTypeRechargeFunnybean,
		// Token: 0x0400023B RID: 571
		kCardPackageUseTypeYearCeremony,
		// Token: 0x0400023C RID: 572
		kCardPackageUseTypePhoneCardBaKengMeng,
		// Token: 0x0400023D RID: 573
		kCardPackageUseTypeTexasPokerInOfficial,
		// Token: 0x0400023E RID: 574
		kCardPackageUseTypeTexasPokerOutOfficial,
		// Token: 0x0400023F RID: 575
		kCardPackageUseTypeLinYuPacket1,
		// Token: 0x04000240 RID: 576
		kCardPackageUseTypeLinYuPacket2,
		// Token: 0x04000241 RID: 577
		kCardPackageUseTypeLinYuPacket3,
		// Token: 0x04000242 RID: 578
		kCardPackageUseTypeLinYuPacket5,
		// Token: 0x04000243 RID: 579
		kCardPackageUseTypePhoneSpread,
		// Token: 0x04000244 RID: 580
		kCardPackageUseTypeYule,
		// Token: 0x04000245 RID: 581
		kCardPackageUseTypeLiYuZhuboPK,
		// Token: 0x04000246 RID: 582
		kCardPackageUseType1206ReRecharge,
		// Token: 0x04000247 RID: 583
		kCardPackageUseType1206ReActConsume,
		// Token: 0x04000248 RID: 584
		kCardPackageUseTypeHuyaApp,
		// Token: 0x04000249 RID: 585
		kCardPackageUseType5153Ba,
		// Token: 0x0400024A RID: 586
		kCardPackageUseType5153Meng,
		// Token: 0x0400024B RID: 587
		kCardPackageUseType5153Whitebean,
		// Token: 0x0400024C RID: 588
		kCardPackageUseTypeChaojiZiZuanYueFei,
		// Token: 0x0400024D RID: 589
		kCardPackageUseTypeChaojiZiZuanJiFei,
		// Token: 0x0400024E RID: 590
		kCardPackageUseTypeChaojiZiZuanNianFei,
		// Token: 0x0400024F RID: 591
		kCardPackageUseTypeJingCaiFix,
		// Token: 0x04000250 RID: 592
		kCardPackageUseTypeLingYuApple,
		// Token: 0x04000251 RID: 593
		kCardPackageUseTypeJiHuoMaDuiHuan,
		// Token: 0x04000252 RID: 594
		kCardPackageUseTypeHuYaTexasPoker,
		// Token: 0x04000253 RID: 595
		kCardPackageUseTypeHero,
		// Token: 0x04000254 RID: 596
		kCardPackageUseTypeMinDaiTianXia3888,
		// Token: 0x04000255 RID: 597
		kCardPackageUseTypeMinDaiTianXia2000,
		// Token: 0x04000256 RID: 598
		kCardPackageUseTypeJiaJingWen,
		// Token: 0x04000257 RID: 599
		kCardPackageUseTypeAvengers,
		// Token: 0x04000258 RID: 600
		kCardPackageUseTypeDailyRegister,
		// Token: 0x04000259 RID: 601
		kCardPackageUseTypeAppXiaoMi,
		// Token: 0x0400025A RID: 602
		kCardPackageUseTypeGoldBeanMarketing,
		// Token: 0x0400025B RID: 603
		kCardPackageUseTypeFirstRechargeCard,
		// Token: 0x0400025C RID: 604
		kCardPackageUseTypeNobleWar,
		// Token: 0x0400025D RID: 605
		kCardPackageUseTypepresenterecology,
		// Token: 0x0400025E RID: 606
		kCardPackageUseTypeSpecialGoldBean = 6099,
		// Token: 0x0400025F RID: 607
		kCardPackageUseTypeActivityRecharge = 6111,
		// Token: 0x04000260 RID: 608
		kCardPackageUseTypeAwardHeart,
		// Token: 0x04000261 RID: 609
		kCardPackageUseTypeMoveStore,
		// Token: 0x04000262 RID: 610
		kCardPackageUseTypeOnlineWatchAwardBean1Pc = 7001,
		// Token: 0x04000263 RID: 611
		kCardPackageUseTypeOnlineWatchAwardBean2Pc,
		// Token: 0x04000264 RID: 612
		kCardPackageUseTypeOnlineWatchAwardBean3Pc,
		// Token: 0x04000265 RID: 613
		kCardPackageUseTypeOnlineWatchAwardBean4Pc,
		// Token: 0x04000266 RID: 614
		kCardPackageUseTypeOnlineWatchAwardProp3Pc = 7013,
		// Token: 0x04000267 RID: 615
		kCardPackageUseTypeOnlineWatchAwardProp4Pc,
		// Token: 0x04000268 RID: 616
		kCardPackageUseTypeHuYaTexasPokerTransGameMoney = 7070,
		// Token: 0x04000269 RID: 617
		kCardPackageUseTypeHuYaTexasPokerServiceFee = 7076,
		// Token: 0x0400026A RID: 618
		kCardPackageUseTypeHuYaTexasPokerReward,
		// Token: 0x0400026B RID: 619
		kCardPackageUseTypeHuYaTexasPokerOfficalServiceFee,
		// Token: 0x0400026C RID: 620
		kCardPackageUseTypeHuYaTexasPokerFreeBankroll,
		// Token: 0x0400026D RID: 621
		kCardPackageUseTypeHuYaPcActivity,
		// Token: 0x0400026E RID: 622
		kCardPackageUseTypeHuYaTexasPokerFinishTutorialReward,
		// Token: 0x0400026F RID: 623
		kCardPackageUseTypeHuYaTexasPokerPlayerRankReward,
		// Token: 0x04000270 RID: 624
		kCardPackageUseTypeTeaseMonkeyJackPot,
		// Token: 0x04000271 RID: 625
		kCardPackageUseTypeTeaseMonkeyByProps,
		// Token: 0x04000272 RID: 626
		kCardPackageUseTypeTeaseMonkeyUserBonus,
		// Token: 0x04000273 RID: 627
		kCardPackageUseTypeTeaseMonkeyProfit,
		// Token: 0x04000274 RID: 628
		kCardPackageUseTypeTeaseMonkeyOwProfit,
		// Token: 0x04000275 RID: 629
		kCardPackageUseTypeOnlineWatchAwardBean1Mobile = 8001,
		// Token: 0x04000276 RID: 630
		kCardPackageUseTypeOnlineWatchAwardBean2Mobile,
		// Token: 0x04000277 RID: 631
		kCardPackageUseTypeOnlineWatchAwardBean3Mobile,
		// Token: 0x04000278 RID: 632
		kCardPackageUseTypeOnlineWatchAwardBean4Mobile,
		// Token: 0x04000279 RID: 633
		kCardPackageUseTypeOnlineWatchAwardProp3Mobile = 8013,
		// Token: 0x0400027A RID: 634
		kCardPackageUseTypeOnlineWatchAwardProp4Mobile,
		// Token: 0x0400027B RID: 635
		kCardPackageUseTypeOnlineWatchAwardBean1Web = 9001,
		// Token: 0x0400027C RID: 636
		kCardPackageUseTypeOnlineWatchAwardBean2Web,
		// Token: 0x0400027D RID: 637
		kCardPackageUseTypeOnlineWatchAwardBean3Web,
		// Token: 0x0400027E RID: 638
		kCardPackageUseTypeOnlineWatchAwardBean4Web,
		// Token: 0x0400027F RID: 639
		kCardPackageUseTypeOnlineWatchAwardProp3Web = 9013,
		// Token: 0x04000280 RID: 640
		kCardPackageUseTypeOnlineWatchAwardProp4Web,
		// Token: 0x04000281 RID: 641
		kCardPackageUseTypeBBXPC,
		// Token: 0x04000282 RID: 642
		kCardPackageUseTypeBBXWEB,
		// Token: 0x04000283 RID: 643
		kCardPackageUseTypeBBXAPP
	}
}
