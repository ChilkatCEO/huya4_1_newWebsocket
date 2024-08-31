using System;

namespace HUYA
{
	// Token: 0x020000C1 RID: 193
	public enum TexasResponseType
	{
		// Token: 0x04000671 RID: 1649
		kRespOK,
		// Token: 0x04000672 RID: 1650
		kPackage_CPEC_MYCLIENT = 2,
		// Token: 0x04000673 RID: 1651
		kPackage_CPEC_NOMEMORY = 4,
		// Token: 0x04000674 RID: 1652
		kPackage_CPEC_PERMISSIONDENIED,
		// Token: 0x04000675 RID: 1653
		kPackage_CPEC_NOCLIENTID,
		// Token: 0x04000676 RID: 1654
		kPackage_CPEC_NOSHARD,
		// Token: 0x04000677 RID: 1655
		kPackage_CPEC_NOENOUGH,
		// Token: 0x04000678 RID: 1656
		kPackage_CPEC_INVALID,
		// Token: 0x04000679 RID: 1657
		kPackage_CPEC_FAILED,
		// Token: 0x0400067A RID: 1658
		kPackage_CPEC_NOTFOUND,
		// Token: 0x0400067B RID: 1659
		kPackage_CPEC_PARAMERROR = 100,
		// Token: 0x0400067C RID: 1660
		kPackage_CPEC_ITEM_EXPIRED,
		// Token: 0x0400067D RID: 1661
		kPackage_CPEC_NOT_ENOUGH,
		// Token: 0x0400067E RID: 1662
		kPackage_CPEC_USEITEM_ERR,
		// Token: 0x0400067F RID: 1663
		kPackage_CPEC_GET_ITEM_ERR,
		// Token: 0x04000680 RID: 1664
		kPackage_CPEC_ITEM_OVERFLOW,
		// Token: 0x04000681 RID: 1665
		kPackage_CPEC_NOTALLSUCC,
		// Token: 0x04000682 RID: 1666
		kPackage_CPEC_REORDER,
		// Token: 0x04000683 RID: 1667
		kPackage_CPEC_ORDERINVALID,
		// Token: 0x04000684 RID: 1668
		kPackage_CPEC_DELITEM_ERR,
		// Token: 0x04000685 RID: 1669
		kPackage_CPEC_TRAN_TIMEOUT,
		// Token: 0x04000686 RID: 1670
		kPackage_CPEC_RECHARDFAILED = 20001,
		// Token: 0x04000687 RID: 1671
		kPackage_CPEC_RECHARGEAGAIN = 30001,
		// Token: 0x04000688 RID: 1672
		kPackage_CPEC_USEAGAIN,
		// Token: 0x04000689 RID: 1673
		kPackage_CPEC_USERINBLACKLIST,
		// Token: 0x0400068A RID: 1674
		kDroppedGame = 20002,
		// Token: 0x0400068B RID: 1675
		kNotEnoughBean,
		// Token: 0x0400068C RID: 1676
		kGameNotFinish,
		// Token: 0x0400068D RID: 1677
		kGameSettleError = 20006,
		// Token: 0x0400068E RID: 1678
		kSeatedBySomeone,
		// Token: 0x0400068F RID: 1679
		kErrorOperation,
		// Token: 0x04000690 RID: 1680
		kNoGameLiveFound,
		// Token: 0x04000691 RID: 1681
		kGameIsPlaying,
		// Token: 0x04000692 RID: 1682
		kBankrollNotCorrect = 20012,
		// Token: 0x04000693 RID: 1683
		kUserIsSeated,
		// Token: 0x04000694 RID: 1684
		kAllSeatsTaken,
		// Token: 0x04000695 RID: 1685
		kInvalidAccount,
		// Token: 0x04000696 RID: 1686
		kExceedMaxDemoModePlayTimes,
		// Token: 0x04000697 RID: 1687
		kCardInfoErr,
		// Token: 0x04000698 RID: 1688
		kDealCardIsForbidden,
		// Token: 0x04000699 RID: 1689
		kGameLevelError,
		// Token: 0x0400069A RID: 1690
		kNoAuthority,
		// Token: 0x0400069B RID: 1691
		kDeskModelError,
		// Token: 0x0400069C RID: 1692
		kNoGuessAuthority,
		// Token: 0x0400069D RID: 1693
		kDeskNotExistError,
		// Token: 0x0400069E RID: 1694
		kNotEnoughPeople,
		// Token: 0x0400069F RID: 1695
		kOutOfLimit,
		// Token: 0x040006A0 RID: 1696
		kDBError,
		// Token: 0x040006A1 RID: 1697
		kJoinGamePositionError,
		// Token: 0x040006A2 RID: 1698
		kFreeTicketNotMatch,
		// Token: 0x040006A3 RID: 1699
		kCardInfoError,
		// Token: 0x040006A4 RID: 1700
		kProhibitDealCard,
		// Token: 0x040006A5 RID: 1701
		kTransItemTypeErr,
		// Token: 0x040006A6 RID: 1702
		kParameterErr,
		// Token: 0x040006A7 RID: 1703
		kLivieIsNotFinish,
		// Token: 0x040006A8 RID: 1704
		kNotFoundPlayerInDesk,
		// Token: 0x040006A9 RID: 1705
		kOpPackageDBError,
		// Token: 0x040006AA RID: 1706
		kUnknowErr,
		// Token: 0x040006AB RID: 1707
		kTexasLogicRunErr,
		// Token: 0x040006AC RID: 1708
		kCDKeyErr,
		// Token: 0x040006AD RID: 1709
		kCDKeyInvalid,
		// Token: 0x040006AE RID: 1710
		kSecondTimeInSameBatch,
		// Token: 0x040006AF RID: 1711
		kIsNotNewPlayer,
		// Token: 0x040006B0 RID: 1712
		kTicketIsExpired
	}
}
