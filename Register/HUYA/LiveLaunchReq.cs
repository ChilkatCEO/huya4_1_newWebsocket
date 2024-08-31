using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
    // Token: 0x02000106 RID: 262
    public sealed class LiveLaunchReq : JceStruct
    {
        // Token: 0x17000007 RID: 7
        // (get) Token: 0x06000016 RID: 22 RVA: 0x0000227B File Offset: 0x0000047B
        // (set) Token: 0x06000017 RID: 23 RVA: 0x00002283 File Offset: 0x00000483
        public UserId tId { get; set; }

        // Token: 0x17000008 RID: 8
        // (get) Token: 0x06000018 RID: 24 RVA: 0x0000228C File Offset: 0x0000048C
        // (set) Token: 0x06000019 RID: 25 RVA: 0x00002294 File Offset: 0x00000494
        public LiveUserbase tLiveUB { get; set; }

        // Token: 0x17000009 RID: 9
        // (get) Token: 0x0600001A RID: 26 RVA: 0x0000229D File Offset: 0x0000049D
        // (set) Token: 0x0600001B RID: 27 RVA: 0x000022A5 File Offset: 0x000004A5
        public int bSupportDomain
        {
            get
            {
                return this._bSupportDomain;
            }
            set
            {
                this._bSupportDomain = value;
            }
        }

        // Token: 0x0600001C RID: 28 RVA: 0x000022AE File Offset: 0x000004AE
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.tId, 0);
            _os.Write(this.tLiveUB, 1);
            _os.Write(this.bSupportDomain, 2);
        }

        // Token: 0x0600001D RID: 29 RVA: 0x000022D8 File Offset: 0x000004D8
        public override void ReadFrom(JceInputStream _is)
        {
            this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
            this.tLiveUB = (LiveUserbase)_is.Read<LiveUserbase>(this.tLiveUB, 1, false);
            this.bSupportDomain = _is.Read(this.bSupportDomain, 2, false);
        }

        // Token: 0x0600001E RID: 30 RVA: 0x0000232B File Offset: 0x0000052B
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display<UserId>(this.tId, "tId");
            jceDisplayer.Display<LiveUserbase>(this.tLiveUB, "tLiveUB");
            jceDisplayer.Display(this.bSupportDomain, "bSupportDomain");
        }

        // Token: 0x0400091C RID: 2332
        private int _bSupportDomain;
    }
}
