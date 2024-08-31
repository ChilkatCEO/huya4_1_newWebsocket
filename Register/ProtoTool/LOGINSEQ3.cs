using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHuya.ProtoTool
{
    /// <summary>
    /// heartbeat
    /// </summary>
    class LOGINSEQ3 : ProtoBase
    {
        /*

         VPHeartBeat_Req_SEQ2/3
         send[86]:
         V#热:?78941969-2699318348-11593484026152747008-958609000-10057-A-0-1?
{86,0,0,0,35,200,0,0,200,0,58,14,169,0,0,0,0,0,62,0,55,56,57,52,49,57,54,57,45,50,54,57,57,51,49,56,51,52,56,45,49,49,53,57,51,52,56,52,48,50,54,49,53,50,55,52,55,48,48,56,45,57,53,56,54,48,57,48,48,48,45,49,48,48,53,55,45,65,45,48,45,49,164,1,0,0}
      */
        private string StreamName { get; set; }
        private long Uid { get; set; }

        public LOGINSEQ3(long Uid, string StreamName )
        {
            this.Uid = Uid;
            this.StreamName = StreamName;
        }

        public override void marshall()
        {
            base.marshall();
            setUri(51235);
            pushShort(200);
            pushInt(Uid);
            //pushInt(0);
            pushBytes(Encoding.ASCII.GetBytes(StreamName));
            Random rnd = new Random();
            pushByte(3);
            pushByte(2);
            pushShort(0);

        }

    }
}