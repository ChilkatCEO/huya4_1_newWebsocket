using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;
namespace HUYA
{
    class SSNormalUserInfo : JceStruct
    {
        public int iLevel2 = 0;
        public int iLevel = 0;
        public int iSubscribedCount = 0;
        public long lUid = 0;
        public long lYYId = 0;
        public string sAvatarUrl = "";
        public string sNick = "";

        public override void ReadFrom(JceInputStream _is)
        {
            this.lUid = (long)_is.Read(this.lUid, 0, false);
            this.lYYId = (long)_is.Read(lYYId, 1, false);
            this.sNick = (string)_is.Read(this.sNick, 2, false);
            this.sAvatarUrl = (string)_is.Read(this.sAvatarUrl, 3, false);
            this.iSubscribedCount = (int)_is.Read(this.iSubscribedCount, 4, false);
            this.iLevel = (int)_is.Read(this.iLevel, 5, false);
            this.iLevel2 = (int)_is.Read(this.iLevel2, 6, false);
        }

        public override void WriteTo(JceOutputStream _os)
        {
            throw new NotImplementedException();
        }
    }
}
