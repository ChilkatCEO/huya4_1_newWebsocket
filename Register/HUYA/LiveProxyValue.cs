using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
    // Token: 0x02000108 RID: 264
    public sealed class LiveProxyValue : JceStruct
    {
        // Token: 0x1700000F RID: 15
        // (get) Token: 0x0600002E RID: 46 RVA: 0x0000251B File Offset: 0x0000071B
        // (set) Token: 0x0600002F RID: 47 RVA: 0x00002523 File Offset: 0x00000723
        public int eProxyType { get; set; }

        // Token: 0x17000010 RID: 16
        // (get) Token: 0x06000030 RID: 48 RVA: 0x0000252C File Offset: 0x0000072C
        // (set) Token: 0x06000031 RID: 49 RVA: 0x00002534 File Offset: 0x00000734
        public List<string> sProxy { get; set; }

        // Token: 0x06000032 RID: 50 RVA: 0x0000253D File Offset: 0x0000073D
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.eProxyType, 0);
            _os.Write(this.sProxy, 1);
        }

        // Token: 0x06000033 RID: 51 RVA: 0x00002559 File Offset: 0x00000759
        public override void ReadFrom(JceInputStream _is)
        {
            this.eProxyType = _is.Read(this.eProxyType, 0, false);
            this.sProxy = (List<string>)_is.Read<List<string>>(this.sProxy, 1, false);
        }

        // Token: 0x06000034 RID: 52 RVA: 0x00002588 File Offset: 0x00000788
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display(this.eProxyType, "eProxyType");
            jceDisplayer.Display<string>(this.sProxy, "sProxy");
        }
    }
}
