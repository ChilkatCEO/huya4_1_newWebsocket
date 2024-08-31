
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHuya.ProtoTool
{
    class OnReady
    {
        string sCookie = "";
        long lUid = 0;
        long topsid; long subsid;
        public int iValidate = 0;
        public OnReady(string sCookie, long lUid, long topsid, long subsid)
        {
            this.sCookie = sCookie;
            this.lUid = lUid;
            this.topsid = topsid;
            this.subsid = subsid;
        }


        public byte[] marshall()
        {
            byte[] result = { };
            //V8ScriptEngine v8 = Call.GetEngine();
            //IArrayBuffer i = (IArrayBuffer)(v8.Script.getUserActivity(sCookie, lUid, topsid, subsid));
            //result = i.GetBytes();
            return result;
        }

        public void unmarshall(byte[] res)
        {
            //V8ScriptEngine v8 = Call.GetEngine();
            //var result = v8.Script.handlegetUserTaskInfoRsp(res);
            // int re = result.Length;
            Console.WriteLine("getUserActivityOK");

        }
    }
}