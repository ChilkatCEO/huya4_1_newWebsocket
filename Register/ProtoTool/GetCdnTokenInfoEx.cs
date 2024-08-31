
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHuya.ProtoTool
{
    class GetCdnTokenInfoEx
    {
        public string sToken = "";
        public int iExpireTime = 0;
        string sFlvUrl, sStreamName;

        public GetCdnTokenInfoEx(string sFlvUrl, string sStreamName)
        {
            this.sFlvUrl = sFlvUrl;
            this.sStreamName = sStreamName ;
        }

        public byte[] marshall()
        {
            byte[] result = { };
            //V8ScriptEngine v8 = Call.GetEngine();
            //IArrayBuffer i = (IArrayBuffer)(v8.Script.getTokenInfoExReq(sFlvUrl,sStreamName));
            //result = i.GetBytes();
            return result;
        }

        public void unmarshall(byte[] res)
        {
            string aa = Encoding.UTF8.GetString(res);
            //V8ScriptEngine v8 = Call.GetEngine();
            //var result = v8.Script.handlegetCdnTokenInfoExRsp(res);
    
        }
    }
}
