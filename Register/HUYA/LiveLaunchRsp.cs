using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
    // Token: 0x02000107 RID: 263
    public sealed class LiveLaunchRsp : JceStruct
    {
        // Token: 0x1700000A RID: 10
        // (get) Token: 0x06000020 RID: 32 RVA: 0x00002371 File Offset: 0x00000571
        // (set) Token: 0x06000021 RID: 33 RVA: 0x00002379 File Offset: 0x00000579
        public string sGuid
        {
            get
            {
                return this._sGuid;
            }
            set
            {
                this._sGuid = value;
            }
        }

        // Token: 0x1700000B RID: 11
        // (get) Token: 0x06000022 RID: 34 RVA: 0x00002382 File Offset: 0x00000582
        // (set) Token: 0x06000023 RID: 35 RVA: 0x0000238A File Offset: 0x0000058A
        public int iTime
        {
            get
            {
                return this._iTime;
            }
            set
            {
                this._iTime = value;
            }
        }

        // Token: 0x1700000C RID: 12
        // (get) Token: 0x06000024 RID: 36 RVA: 0x00002393 File Offset: 0x00000593
        // (set) Token: 0x06000025 RID: 37 RVA: 0x0000239B File Offset: 0x0000059B
        public List<LiveProxyValue> vProxyList { get; set; }

        // Token: 0x1700000D RID: 13
        // (get) Token: 0x06000026 RID: 38 RVA: 0x000023A4 File Offset: 0x000005A4
        // (set) Token: 0x06000027 RID: 39 RVA: 0x000023AC File Offset: 0x000005AC
        public int eAccess { get; set; }

        // Token: 0x1700000E RID: 14
        // (get) Token: 0x06000028 RID: 40 RVA: 0x000023B5 File Offset: 0x000005B5
        // (set) Token: 0x06000029 RID: 41 RVA: 0x000023BD File Offset: 0x000005BD
        public string sClientIp
        {
            get
            {
                return this._sClientIp;
            }
            set
            {
                this._sClientIp = value;
            }
        }

        // Token: 0x0600002A RID: 42 RVA: 0x000023C8 File Offset: 0x000005C8
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.sGuid, 0, false);
            _os.Write(this.iTime, 1);
            _os.Write(this.vProxyList, 2);
            _os.Write(this.eAccess, 3);
            _os.Write(this.sClientIp, 4, false);
        }

        // Token: 0x0600002B RID: 43 RVA: 0x00002418 File Offset: 0x00000618
        public override void ReadFrom(JceInputStream _is)
        {
            this.sGuid = _is.Read(this.sGuid, 0, false);
            this.iTime = _is.Read(this.iTime, 1, false);
            this.vProxyList = (List<LiveProxyValue>)_is.Read<List<LiveProxyValue>>(this.vProxyList, 2, false);
            this.eAccess = _is.Read(this.eAccess, 3, false);
            this.sClientIp = _is.Read(this.sClientIp, 4, false);
        }

        // Token: 0x0600002C RID: 44 RVA: 0x00002490 File Offset: 0x00000690
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display(this.sGuid, "sGuid");
            jceDisplayer.Display(this.iTime, "iTime");
            jceDisplayer.Display<LiveProxyValue>(this.vProxyList, "vProxyList");
            jceDisplayer.Display(this.eAccess, "eAccess");
            jceDisplayer.Display(this.sClientIp, "sClientIp");
        }

        // Token: 0x0400091D RID: 2333
        private string _sGuid = "";

        // Token: 0x0400091E RID: 2334
        private int _iTime;

        // Token: 0x04000921 RID: 2337
        private string _sClientIp = "";
    }
}
