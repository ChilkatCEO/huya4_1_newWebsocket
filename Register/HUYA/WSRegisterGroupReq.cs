using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;
namespace HUYA
{
    // Token: 0x0200011A RID: 282
    public sealed class WSRegisterGroupReq : JceStruct
    {
        // Token: 0x17000055 RID: 85
        // (get) Token: 0x06000102 RID: 258 RVA: 0x00003A8C File Offset: 0x00001C8C
        // (set) Token: 0x06000103 RID: 259 RVA: 0x00003A94 File Offset: 0x00001C94
        public List<string> vGroupId { get; set; }

        // Token: 0x17000056 RID: 86
        // (get) Token: 0x06000104 RID: 260 RVA: 0x00003A9D File Offset: 0x00001C9D
        // (set) Token: 0x06000105 RID: 261 RVA: 0x00003AA5 File Offset: 0x00001CA5
        public string sToken
        {
            get
            {
                return this._sToken;
            }
            set
            {
                this._sToken = value;
            }
        }

        // Token: 0x06000106 RID: 262 RVA: 0x00003AAE File Offset: 0x00001CAE
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.vGroupId, 0);
            _os.Write(this.sToken, 1, false);
        }

        // Token: 0x06000107 RID: 263 RVA: 0x00003ACB File Offset: 0x00001CCB
        public override void ReadFrom(JceInputStream _is)
        {
            this.vGroupId = (List<string>)_is.Read<List<string>>(this.vGroupId, 0, false);
            this.sToken = _is.Read(this.sToken, 1, false);
        }

        // Token: 0x06000108 RID: 264 RVA: 0x00003AFA File Offset: 0x00001CFA
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display<string>(this.vGroupId, "vGroupId");
            jceDisplayer.Display(this.sToken, "sToken");
        }

        // Token: 0x04000969 RID: 2409
        private string _sToken = "";
    }
}
