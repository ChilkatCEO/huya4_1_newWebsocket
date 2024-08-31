
extern alias huyaproto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huyaproto::Wup.Jce;

namespace iHuya.ProtoTool
{
    public sealed class WSVerifyCookieReq :JceStruct
    {
        public long uid;
        public string sUA,sCookie,sGuid;

        public int bAutoRegisterUid
        {
            get
            {
                return this._bAutoRegisterUid;
            }
            set
            {
                this._bAutoRegisterUid = value;
            }
        }

        private int _bAutoRegisterUid;
        public override void ReadFrom(JceInputStream _is)
        {
            throw new NotImplementedException();
        }

        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(uid, 0);
            _os.Write(sUA, 1);
            _os.Write(sCookie, 2);
            _os.Write(sGuid, 3);
            _os.Write(this.bAutoRegisterUid, 4);
        }
    }

}
