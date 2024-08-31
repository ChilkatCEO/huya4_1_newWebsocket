using System;

namespace HUYA
{
	// Token: 0x020000AF RID: 175
	public enum EWebSocketCommandType
	{
        // Token: 0x04000632 RID: 1586
        EWSCmd_NULL,
        // Token: 0x04000633 RID: 1587
        EWSCmd_RegisterReq,
        // Token: 0x04000634 RID: 1588
        EWSCmd_RegisterRsp,
        // Token: 0x04000635 RID: 1589
        EWSCmd_WupReq,
        // Token: 0x04000636 RID: 1590
        EWSCmd_WupRsp,
        // Token: 0x04000637 RID: 1591
        EWSCmdC2S_HeartBeat,
        // Token: 0x04000638 RID: 1592
        EWSCmdS2C_HeartBeatAck,
        // Token: 0x04000639 RID: 1593
        EWSCmdS2C_MsgPushReq,
        // Token: 0x0400063A RID: 1594
        EWSCmdC2S_DeregisterReq,
        // Token: 0x0400063B RID: 1595
        EWSCmdS2C_DeRegisterRsp,
        // Token: 0x0400063C RID: 1596
        EWSCmdC2S_VerifyCookieReq,
        // Token: 0x0400063D RID: 1597
        EWSCmdS2C_VerifyCookieRsp,
        // Token: 0x0400063E RID: 1598
        EWSCmdC2S_VerifyHuyaTokenReq,
        // Token: 0x0400063F RID: 1599
        EWSCmdS2C_VerifyHuyaTokenRsp,
        // Token: 0x04000640 RID: 1600
        EWSCmdC2S_UNVerifyReq,
        // Token: 0x04000641 RID: 1601
        EWSCmdS2C_UNVerifyRsp,
        // Token: 0x04000642 RID: 1602
        EWSCmdC2S_RegisterGroupReq,
        // Token: 0x04000643 RID: 1603
        EWSCmdS2C_RegisterGroupRsp,
        // Token: 0x04000644 RID: 1604
        EWSCmdC2S_UnRegisterGroupReq,
        // Token: 0x04000645 RID: 1605
        EWSCmdS2C_UnRegisterGroupRsp,
        // Token: 0x04000646 RID: 1606
        EWSCmdC2S_HeartBeatReq,
        // Token: 0x04000647 RID: 1607
        EWSCmdS2C_HeartBeatRsp,
        // Token: 0x04000648 RID: 1608
        EWSCmdS2C_MsgPushReq_V2,
        // Token: 0x04000649 RID: 1609
        EWSCmdC2S_UpdateUserExpsReq,
        // Token: 0x0400064A RID: 1610
        EWSCmdS2C_UpdateUserExpsRsp
    }
}
