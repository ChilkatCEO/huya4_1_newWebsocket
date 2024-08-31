 using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   
    namespace iHuya.ProtoTool
    {
        class WSRegisterGroup
        {
            private long lPid;
            public int iResCode = -3;

            public WSRegisterGroup(long lPid)
            {
                this.lPid = lPid;
            }

            public byte[] marshall()
            {
                byte[] result = { };
                //V8ScriptEngine v8 = Call.GetEngine();
                //IArrayBuffer i = (IArrayBuffer)(v8.Script.getRegisterGroup(lPid));
                //result = i.GetBytes();
                return result;
            }

            public void unmarshall(byte[] res)
            {
                //V8ScriptEngine v8 = Call.GetEngine();
                //var result = v8.Script.handleGroupRsp(res);
      

            }

        }
    }

