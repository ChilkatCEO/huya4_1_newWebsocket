using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace iHuya.ProtoTool
{
    class WSVerify
    {
        string sCookie = "";
        long lUid = 0;
        string sGuid = "";
        public int iValidate = 0;
        public WSVerify(string sCookie, long lUid,string sGuid)
        {
            this.sCookie = sCookie;
            this.sGuid = sGuid;
            this.lUid = lUid;
        }

        public byte[] marshall()
        {
            byte[] result = { };
  
       
            return result;
        }

        public void unmarshall(byte[] res)
        {
         
           

        }

    }
}
