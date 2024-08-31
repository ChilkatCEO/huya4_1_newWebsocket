using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x0200002C RID: 44
	public sealed class GetLivingInfoRsp : JceStruct
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600025D RID: 605 RVA: 0x000064FB File Offset: 0x000046FB
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00006503 File Offset: 0x00004703
		public int bIsLiving
		{
			get
			{
				return this._bIsLiving;
			}
			set
			{
				this._bIsLiving = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0000650C File Offset: 0x0000470C
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00006514 File Offset: 0x00004714
		public BeginLiveNotice tNotice { get; set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000651D File Offset: 0x0000471D
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00006525 File Offset: 0x00004725
		public StreamSettingNotice tStreamSettingNotice { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000652E File Offset: 0x0000472E
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00006536 File Offset: 0x00004736
		public int bIsSelfLiving
		{
			get
			{
				return this._bIsSelfLiving;
			}
			set
			{
				this._bIsSelfLiving = value;
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000653F File Offset: 0x0000473F
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.bIsLiving, 0);
			_os.Write(this.tNotice, 1);
			_os.Write(this.tStreamSettingNotice, 2);
			_os.Write(this.bIsSelfLiving, 3);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00006578 File Offset: 0x00004778
		public override void ReadFrom(JceInputStream _is)
		{
			this.bIsLiving = _is.Read(this.bIsLiving, 0, false);
			this.tNotice = (BeginLiveNotice)_is.Read<BeginLiveNotice>(this.tNotice, 1, false);
			this.tStreamSettingNotice = (StreamSettingNotice)_is.Read<StreamSettingNotice>(this.tStreamSettingNotice, 2, false);
			this.bIsSelfLiving = _is.Read(this.bIsSelfLiving, 3, false);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000065E0 File Offset: 0x000047E0
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.bIsLiving, "bIsLiving");
			jceDisplayer.Display<BeginLiveNotice>(this.tNotice, "tNotice");
			jceDisplayer.Display<StreamSettingNotice>(this.tStreamSettingNotice, "tStreamSettingNotice");
			jceDisplayer.Display(this.bIsSelfLiving, "bIsSelfLiving");
		}

		// Token: 0x040000F2 RID: 242
		private int _bIsLiving;

		// Token: 0x040000F5 RID: 245
		private int _bIsSelfLiving;
	}
}
