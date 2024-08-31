using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
    // Token: 0x02000109 RID: 265
    public sealed class LiveUserbase : JceStruct
    {
        // Token: 0x17000011 RID: 17
        // (get) Token: 0x06000036 RID: 54 RVA: 0x000025B4 File Offset: 0x000007B4
        // (set) Token: 0x06000037 RID: 55 RVA: 0x000025BC File Offset: 0x000007BC
        public int eSource { get; set; }

        // Token: 0x17000012 RID: 18
        // (get) Token: 0x06000038 RID: 56 RVA: 0x000025C5 File Offset: 0x000007C5
        // (set) Token: 0x06000039 RID: 57 RVA: 0x000025CD File Offset: 0x000007CD
        public int eType { get; set; }

        // Token: 0x17000013 RID: 19
        // (get) Token: 0x0600003A RID: 58 RVA: 0x000025D6 File Offset: 0x000007D6
        // (set) Token: 0x0600003B RID: 59 RVA: 0x000025DE File Offset: 0x000007DE
        public LiveAppUAEx tUAEx { get; set; }

        // Token: 0x0600003C RID: 60 RVA: 0x000025E7 File Offset: 0x000007E7
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.eSource, 0);
            _os.Write(this.eType, 1);
            _os.Write(this.tUAEx, 2);
        }

        // Token: 0x0600003D RID: 61 RVA: 0x00002610 File Offset: 0x00000810
        public override void ReadFrom(JceInputStream _is)
        {
            this.eSource = _is.Read(this.eSource, 0, false);
            this.eType = _is.Read(this.eType, 1, false);
            this.tUAEx = (LiveAppUAEx)_is.Read<LiveAppUAEx>(this.tUAEx, 2, false);
        }

        // Token: 0x0600003E RID: 62 RVA: 0x0000265E File Offset: 0x0000085E
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display(this.eSource, "eSource");
            jceDisplayer.Display(this.eType, "eType");
            jceDisplayer.Display<LiveAppUAEx>(this.tUAEx, "tUAEx");
        }
    }
}
