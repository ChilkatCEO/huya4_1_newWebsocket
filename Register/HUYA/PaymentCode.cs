using System;

namespace HUYA
{
	// Token: 0x0200005C RID: 92
	public enum PaymentCode
	{
		// Token: 0x040003B0 RID: 944
		PaymentCode_OK = 1,
		// Token: 0x040003B1 RID: 945
		PaymentCode_ParamterError = -10,
		// Token: 0x040003B2 RID: 946
		PaymentCode_SignError = -11,
		// Token: 0x040003B3 RID: 947
		PaymentCode_OrderNotExist = -22,
		// Token: 0x040003B4 RID: 948
		PaymentCode_Unauthorized = -30,
		// Token: 0x040003B5 RID: 949
		PaymentCode_UserCancelPay = -31,
		// Token: 0x040003B6 RID: 950
		PaymentCode_NotEnoughMoney = -32,
		// Token: 0x040003B7 RID: 951
		PaymentCode_TimeOut = -34,
		// Token: 0x040003B8 RID: 952
		PaymentCode_RequestFrequently = -38,
		// Token: 0x040003B9 RID: 953
		PaymentCode_RiskControlException = -80,
		// Token: 0x040003BA RID: 954
		PaymentCode_UserFreeze = -82
	}
}
