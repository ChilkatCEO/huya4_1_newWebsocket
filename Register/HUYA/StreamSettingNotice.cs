using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
	// Token: 0x020000E8 RID: 232
	public sealed class StreamSettingNotice : JceStruct
	{
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0000808C File Offset: 0x0000628C
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00008094 File Offset: 0x00006294
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

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000346 RID: 838 RVA: 0x0000809D File Offset: 0x0000629D
		// (set) Token: 0x06000347 RID: 839 RVA: 0x000080A5 File Offset: 0x000062A5
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

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000348 RID: 840 RVA: 0x000080AE File Offset: 0x000062AE
		// (set) Token: 0x06000349 RID: 841 RVA: 0x000080B6 File Offset: 0x000062B6
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

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600034A RID: 842 RVA: 0x000080BF File Offset: 0x000062BF
		// (set) Token: 0x0600034B RID: 843 RVA: 0x000080C7 File Offset: 0x000062C7
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

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600034C RID: 844 RVA: 0x000080D0 File Offset: 0x000062D0
		// (set) Token: 0x0600034D RID: 845 RVA: 0x000080D8 File Offset: 0x000062D8
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

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600034E RID: 846 RVA: 0x000080E1 File Offset: 0x000062E1
		// (set) Token: 0x0600034F RID: 847 RVA: 0x000080E9 File Offset: 0x000062E9
		public string sDisplayName
		{
			get
			{
				return this._sDisplayName;
			}
			set
			{
				this._sDisplayName = value;
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x000080F4 File Offset: 0x000062F4
		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.lPresenterUid, 0);
			_os.Write(this.iBitRate, 1);
			_os.Write(this.iResolution, 2);
			_os.Write(this.iFrameRate, 3);
			_os.Write(this.lLiveId, 4);
			_os.Write(this.sDisplayName, 5, false);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00008150 File Offset: 0x00006350
		public override void ReadFrom(JceInputStream _is)
		{
			this.lPresenterUid = _is.Read(this.lPresenterUid, 0, false);
			this.iBitRate = _is.Read(this.iBitRate, 1, false);
			this.iResolution = _is.Read(this.iResolution, 2, false);
			this.iFrameRate = _is.Read(this.iFrameRate, 3, false);
			this.lLiveId = _is.Read(this.lLiveId, 4, false);
			this.sDisplayName = _is.Read(this.sDisplayName, 5, false);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x000081D8 File Offset: 0x000063D8
		public override void Display(StringBuilder _os, int _level)
		{
			JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
			jceDisplayer.Display(this.lPresenterUid, "lPresenterUid");
			jceDisplayer.Display(this.iBitRate, "iBitRate");
			jceDisplayer.Display(this.iResolution, "iResolution");
			jceDisplayer.Display(this.iFrameRate, "iFrameRate");
			jceDisplayer.Display(this.lLiveId, "lLiveId");
			jceDisplayer.Display(this.sDisplayName, "sDisplayName");
		}

		// Token: 0x040007B8 RID: 1976
		private long _lPresenterUid;

		// Token: 0x040007B9 RID: 1977
		private int _iBitRate;

		// Token: 0x040007BA RID: 1978
		private int _iResolution;

		// Token: 0x040007BB RID: 1979
		private int _iFrameRate;

		// Token: 0x040007BC RID: 1980
		private long _lLiveId;

		// Token: 0x040007BD RID: 1981
		private string _sDisplayName = "";
	}
}
