using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;

namespace HUYA
{
    public sealed class ClickSearchUserReq : JceStruct
    {

        public UserId tId { get; set; }
        public long ltoUid { get; set; }
        public override void ReadFrom(JceInputStream _is)
        {
            this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
            this.ltoUid = _is.Read(this.ltoUid, 0, false);
        }

        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.tId, 0);
            _os.Write(this.ltoUid, 1);
        }


    }
}
