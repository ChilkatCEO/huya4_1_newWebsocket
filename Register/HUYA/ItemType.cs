using System;

namespace HUYA
{
	// Token: 0x0200005D RID: 93
	public enum ItemType
	{
		// Token: 0x040003BC RID: 956
		ItemType_Main_Begin,
		// Token: 0x040003BD RID: 957
		ItemType_Speaker,
		// Token: 0x040003BE RID: 958
		ItemType_BaQi,
		// Token: 0x040003BF RID: 959
		ItemType_Kengdie,
		// Token: 0x040003C0 RID: 960
		ItemType_Meng,
		// Token: 0x040003C1 RID: 961
		ItemType_FreeBaQi,
		// Token: 0x040003C2 RID: 962
		ItemType_FreeKengdie,
		// Token: 0x040003C3 RID: 963
		ItemType_FreeMeng,
		// Token: 0x040003C4 RID: 964
		ItemType_WhiteBean,
		// Token: 0x040003C5 RID: 965
		ItemType_GreenBean,
		// Token: 0x040003C6 RID: 966
		ItemType_BloodBottle,
		// Token: 0x040003C7 RID: 967
		ItemType_DiaoBao,
		// Token: 0x040003C8 RID: 968
		ItemType_Treasure,
		// Token: 0x040003C9 RID: 969
		ItemType_BlueHeart,
		// Token: 0x040003CA RID: 970
		ItemType_V12Speaker,
		// Token: 0x040003CB RID: 971
		ItemType_V520Speaker,
		// Token: 0x040003CC RID: 972
		ItemType_BannedSpeaker,
		// Token: 0x040003CD RID: 973
		ItemType_BindingGreenBean,
		// Token: 0x040003CE RID: 974
		ItemType_MoBai,
		// Token: 0x040003CF RID: 975
		ItemType_FreeMoBai,
		// Token: 0x040003D0 RID: 976
		ItemType_BlueBottle,
		// Token: 0x040003D1 RID: 977
		ItemType_TeaEgg,
		// Token: 0x040003D2 RID: 978
		ItemType_FunnyBean,
		// Token: 0x040003D3 RID: 979
		ItemType_GiftGoldenBean,
		// Token: 0x040003D4 RID: 980
		ItemType_GoldTicket = 32,
		// Token: 0x040003D5 RID: 981
		ItemType_Main_End = 45,
		// Token: 0x040003D6 RID: 982
		ItemType_JieDai_Begin = 48,
		// Token: 0x040003D7 RID: 983
		ItemType_RedHeart,
		// Token: 0x040003D8 RID: 984
		ItemType_Lollipop,
		// Token: 0x040003D9 RID: 985
		ItemType_Clap,
		// Token: 0x040003DA RID: 986
		ItemType_Balloon,
		// Token: 0x040003DB RID: 987
		ItemType_LoveLetter,
		// Token: 0x040003DC RID: 988
		ItemType_MemeDa,
		// Token: 0x040003DD RID: 989
		ItemType_BearHug,
		// Token: 0x040003DE RID: 990
		ItemType_Date,
		// Token: 0x040003DF RID: 991
		ItemType_Banana,
		// Token: 0x040003E0 RID: 992
		ItemType_Rose,
		// Token: 0x040003E1 RID: 993
		ItemType_Chocolate,
		// Token: 0x040003E2 RID: 994
		ItemType_Perfume,
		// Token: 0x040003E3 RID: 995
		ItemType_Lipstick,
		// Token: 0x040003E4 RID: 996
		ItemType_DiamondRing,
		// Token: 0x040003E5 RID: 997
		ItemType_OceanHeart,
		// Token: 0x040003E6 RID: 998
		ItemType_GameMoney = 68,
		// Token: 0x040003E7 RID: 999
		ItemType_JieDai_End = 200,
		// Token: 0x040003E8 RID: 1000
		ItemType_GaiZhang_Begin,
		// Token: 0x040003E9 RID: 1001
		ItemType_Luoli,
		// Token: 0x040003EA RID: 1002
		ItemType_RuanMei,
		// Token: 0x040003EB RID: 1003
		ItemType_BaoBei,
		// Token: 0x040003EC RID: 1004
		ItemType_Beauty,
		// Token: 0x040003ED RID: 1005
		ItemType_DiaoShi,
		// Token: 0x040003EE RID: 1006
		ItemType_LaoWang,
		// Token: 0x040003EF RID: 1007
		ItemType_Marriage,
		// Token: 0x040003F0 RID: 1008
		ItemType_DouBi,
		// Token: 0x040003F1 RID: 1009
		ItemType_XiaoQingXin,
		// Token: 0x040003F2 RID: 1010
		ItemType_Flavors,
		// Token: 0x040003F3 RID: 1011
		ItemType_SmallMeat,
		// Token: 0x040003F4 RID: 1012
		ItemType_GuaiShuLi,
		// Token: 0x040003F5 RID: 1013
		ItemType_TuHao,
		// Token: 0x040003F6 RID: 1014
		ItemType_Boss,
		// Token: 0x040003F7 RID: 1015
		ItemType_ZhuanShiNan,
		// Token: 0x040003F8 RID: 1016
		ItemType_BaiDaoZhongChai,
		// Token: 0x040003F9 RID: 1017
		ItemType_NanShen,
		// Token: 0x040003FA RID: 1018
		ItemType_NvShen,
		// Token: 0x040003FB RID: 1019
		ItemType_GaoFuShuai,
		// Token: 0x040003FC RID: 1020
		ItemType_BaiFuMei,
		// Token: 0x040003FD RID: 1021
		ItemType_Husband,
		// Token: 0x040003FE RID: 1022
		ItemType_Wife,
		// Token: 0x040003FF RID: 1023
		ItemType_GaiZhang_End = 300,
		// Token: 0x04000400 RID: 1024
		ItemType_Main_GaiZhang_Begin,
		// Token: 0x04000401 RID: 1025
		ItemType_Main_GaiZhang_End = 400,
		// Token: 0x04000402 RID: 1026
		ItemType_ActivePropLang = 20035,
		// Token: 0x04000403 RID: 1027
		ItemType_HuYaTexasPoker_Song = 2001,
		// Token: 0x04000404 RID: 1028
		ItemType_HuYaTexasPoker_Hao,
		// Token: 0x04000405 RID: 1029
		ItemType_HuYaTexasPoker_ThanksBoss,
		// Token: 0x04000406 RID: 1030
		ItemType_HuYaTexasPoker_Bankroll = 2006,
		// Token: 0x04000407 RID: 1031
		ItemType_HuYaTexasPoker_Love = 20041,
		// Token: 0x04000408 RID: 1032
		ItemType_HuYaTexasPoker_GodHand,
		// Token: 0x04000409 RID: 1033
		ItemType_ActivePropsIDBounds = 20000
	}
}
