
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHuya.ProtoTool
{
    class VideoGateWayPing
    {

        public VideoGateWayPing()
        {
   
        }


        public byte[] marshall()
        {
            byte[] result = { };
            //V8ScriptEngine v8 = Call.GetEngine();
            //IArrayBuffer i = (IArrayBuffer)(v8.Script.getVideoPingReq());
         
            return result;
        }

        public void unmarshall(byte[] res)
        {
            //V8ScriptEngine v8 = Call.GetEngine();
            //var result = v8.Script.handlegetUserTaskInfoRsp(res);
            // int re = result.Length;
            Console.WriteLine("VideoGateWayPong");

        }
    }
}
