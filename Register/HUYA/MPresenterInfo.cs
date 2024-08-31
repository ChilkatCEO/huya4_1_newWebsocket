using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;
namespace HUYA
{
    class MPresenterInfo : JceStruct
    {
        public SSPresenterInfo sSPresenterInfo;
        public override void ReadFrom(JceInputStream _is)
        {
            sSPresenterInfo = new SSPresenterInfo();
            _is.Read(sSPresenterInfo, 0, false);

        }

        public override void WriteTo(JceOutputStream _os)
        {
            throw new NotImplementedException();
        }
    }
}
