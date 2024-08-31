using System;

namespace HUYA
{
	// Token: 0x020000B0 RID: 176
	public enum EWebSocketPushMessageType
	{
		// Token: 0x040005EC RID: 1516
		EWSPushMsgTypeBcByTid = 1,
		// Token: 0x040005ED RID: 1517
		EWSPushMsgTypeBcByTidExUid,
		// Token: 0x040005EE RID: 1518
		EWSPushMsgTypeBcBySid,
		// Token: 0x040005EF RID: 1519
		EWSPushMsgTypeBcBySidExUid,
		// Token: 0x040005F0 RID: 1520
		EWSPushMsgTypeBcByGroup,
		// Token: 0x040005F1 RID: 1521
		EWSPushMsgTypeBcByTmpId,
		// Token: 0x040005F2 RID: 1522
		EWSPushMsgTypeUcByUid,
		// Token: 0x040005F3 RID: 1523
		EWSPushMsgTypeMcByUids,
		// Token: 0x040005F4 RID: 1524
		EWSPushMsgTypeUcBySession
	}
}
