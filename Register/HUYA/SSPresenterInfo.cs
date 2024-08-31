using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;
namespace HUYA
{
    class SSPresenterInfo : JceStruct
    {
        long lpId = 0;
        public override void ReadFrom(JceInputStream _is)
        {
            
            lpId = (long)_is.Read(this.lpId, 1, false);
            Console.WriteLine("..."+lpId);

        }

        public override void WriteTo(JceOutputStream _os)
        {
            throw new NotImplementedException();
        }
    }
}
