extern alias huyaproto;
using System;
using System.Collections.Generic;
using System.Text;
using Wup.Jce;

namespace HUYA
{
    // Token: 0x02000112 RID: 274
    public sealed class WebSocketCommand : JceStruct
    {
        // Token: 0x17000045 RID: 69
        // (get) Token: 0x060000C2 RID: 194 RVA: 0x00003597 File Offset: 0x00001797
        // (set) Token: 0x060000C3 RID: 195 RVA: 0x0000359F File Offset: 0x0000179F
        public int iCmdType
        {
            get
            {
                return this._iCmdType;
            }
            set
            {
                this._iCmdType = value;
            }
        }

        // Token: 0x17000046 RID: 70
        // (get) Token: 0x060000C4 RID: 196 RVA: 0x000035A8 File Offset: 0x000017A8
        // (set) Token: 0x060000C5 RID: 197 RVA: 0x000035B0 File Offset: 0x000017B0
        public List<byte> vData { get; set; }

        // Token: 0x060000C6 RID: 198 RVA: 0x000035B9 File Offset: 0x000017B9
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.iCmdType, 0);
            _os.Write(this.vData, 1);
        }

        // Token: 0x060000C7 RID: 199 RVA: 0x000035D5 File Offset: 0x000017D5
        public override void ReadFrom(JceInputStream _is)
        {
            this.iCmdType = _is.Read(this.iCmdType, 0, false);
            this.vData = (List<byte>)_is.Read<List<byte>>(this.vData, 1, false);
        }

        // Token: 0x060000C8 RID: 200 RVA: 0x00003604 File Offset: 0x00001804
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display(this.iCmdType, "iCmdType");
            jceDisplayer.Display<byte>(this.vData, "vData");
        }

        // Token: 0x04000958 RID: 2392
        private int _iCmdType;
    }
}
