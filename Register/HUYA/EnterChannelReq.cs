
using HUYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;
namespace HUYA
{
    public sealed class EnterChannelReq : JceStruct
    {


        // Token: 0x170000E4 RID: 228
        // (get) Token: 0x06000269 RID: 617 RVA: 0x0000663B File Offset: 0x0000483B
        // (set) Token: 0x0600026A RID: 618 RVA: 0x00006643 File Offset: 0x00004843
        public UserId tId { get; set; }

        // Token: 0x170000E5 RID: 229
        // (get) Token: 0x0600026B RID: 619 RVA: 0x0000664C File Offset: 0x0000484C
        // (set) Token: 0x0600026C RID: 620 RVA: 0x00006654 File Offset: 0x00004854


        public long lTid
        {
            get
            {
                return this._lTid;
            }
            set
            {
                this._lTid = value;
            }
        }
        public long lSid
        {
            get
            {
                return this._lSid;
            }
            set
            {
                this._lSid = value;
            }
        }
        // Token: 0x0600026D RID: 621 RVA: 0x0000665D File Offset: 0x0000485D
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.tId, 1);
            _os.Write(this.lTid,2);
            _os.Write(this.lSid, 3);
            _os.Write(this.iChannelType, 4);
        }

        // Token: 0x0600026E RID: 622 RVA: 0x00006679 File Offset: 0x00004879
        public override void ReadFrom(JceInputStream _is)
        {
            this.tId = (UserId)_is.Read<UserId>(this.tId, 1, false);
            this.lTid = _is.Read(this.lTid, 2, false);
            this.lSid = _is.Read(this.lSid, 3, false);
            this.iChannelType = _is.Read(this.iChannelType, 4, false);
        }

        // Token: 0x0600026F RID: 623 RVA: 0x000066A8 File Offset: 0x000048A8
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display<UserId>(this.tId, "tId");
            jceDisplayer.Display(this.lTid, "lTid");
            jceDisplayer.Display(this.lSid, "lSid");
            jceDisplayer.Display(this.iChannelType, "iChannelType");
        }

        // Token: 0x040000F7 RID: 247
        private long _lTid, _lSid;
        private int iChannelType = 0;


    }
}
