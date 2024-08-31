using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
    // Token: 0x02000105 RID: 261
    public sealed class LiveAppUAEx : JceStruct
    {
        // Token: 0x17000003 RID: 3
        // (get) Token: 0x0600000A RID: 10 RVA: 0x0000210C File Offset: 0x0000030C
        // (set) Token: 0x0600000B RID: 11 RVA: 0x00002114 File Offset: 0x00000314
        public string sIMEI
        {
            get
            {
                return this._sIMEI;
            }
            set
            {
                this._sIMEI = value;
            }
        }

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x0600000C RID: 12 RVA: 0x0000211D File Offset: 0x0000031D
        // (set) Token: 0x0600000D RID: 13 RVA: 0x00002125 File Offset: 0x00000325
        public string sAPN
        {
            get
            {
                return this._sAPN;
            }
            set
            {
                this._sAPN = value;
            }
        }

        // Token: 0x17000005 RID: 5
        // (get) Token: 0x0600000E RID: 14 RVA: 0x0000212E File Offset: 0x0000032E
        // (set) Token: 0x0600000F RID: 15 RVA: 0x00002136 File Offset: 0x00000336
        public string sNetType
        {
            get
            {
                return this._sNetType;
            }
            set
            {
                this._sNetType = value;
            }
        }

        // Token: 0x17000006 RID: 6
        // (get) Token: 0x06000010 RID: 16 RVA: 0x0000213F File Offset: 0x0000033F
        // (set) Token: 0x06000011 RID: 17 RVA: 0x00002147 File Offset: 0x00000347
        public string sDeviceId
        {
            get
            {
                return this._sDeviceId;
            }
            set
            {
                this._sDeviceId = value;
            }
        }

        // Token: 0x06000012 RID: 18 RVA: 0x00002150 File Offset: 0x00000350
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.sIMEI, 1, false);
            _os.Write(this.sAPN, 2, false);
            _os.Write(this.sNetType, 3, false);
            _os.Write(this.sDeviceId, 4, false);
        }

        // Token: 0x06000013 RID: 19 RVA: 0x0000218C File Offset: 0x0000038C
        public override void ReadFrom(JceInputStream _is)
        {
            this.sIMEI = _is.Read(this.sIMEI, 1, false);
            this.sAPN = _is.Read(this.sAPN, 2, false);
            this.sNetType = _is.Read(this.sNetType, 3, false);
            this.sDeviceId = _is.Read(this.sDeviceId, 4, false);
        }

        // Token: 0x06000014 RID: 20 RVA: 0x000021EC File Offset: 0x000003EC
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display(this.sIMEI, "sIMEI");
            jceDisplayer.Display(this.sAPN, "sAPN");
            jceDisplayer.Display(this.sNetType, "sNetType");
            jceDisplayer.Display(this.sDeviceId, "sDeviceId");
        }

        // Token: 0x04000916 RID: 2326
        private string _sIMEI = "";

        // Token: 0x04000917 RID: 2327
        private string _sAPN = "";

        // Token: 0x04000918 RID: 2328
        private string _sNetType = "";

        // Token: 0x04000919 RID: 2329
        private string _sDeviceId = "";
    }
}
