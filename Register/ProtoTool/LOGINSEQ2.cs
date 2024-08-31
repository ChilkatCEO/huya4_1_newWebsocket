using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHuya.ProtoTool
{
    /// <summary>
    /// heartbeat
    /// </summary>
    class LOGINSEQ2 : ProtoBase
    {
        /*

         VPHeartBeat_Req_SEQ2/3
         send[46]:
         .#f菳:?彺赂?
         {46,0,0,0,35,102,0,0,200,0,66,0,0,0,58,14,169,0,0,0,0,0,17,143,180,4,0,0,0,0,tickcount,0,0,0,0,1,0,0,0,0,0,0,5}
         {46,0,0,0,35,102,0,0,200,0,66,0,0,0,{uid:4},0,0,0,0,mainid,0,0,0,0,{RND0,255-3},22,0,0,0,0,1,0,0,0,0,0,0,5}
      */

        private long Uid { get; set; }
        private long Mainid { get; set; }

        public LOGINSEQ2(long Uid, long Mainid)
        {
            this.Uid = Uid;
            this.Mainid = Mainid;
        }

        public override void marshall()
        {
            base.marshall();
            setUri(26147);
            pushShort(200);
            pushInt(66);
            pushInt(Uid);
           // pushInt(0);
            pushInt(Mainid);
            //pushInt(0);
            pushInt(Call.GetTickCount());
            pushInt(0);
            pushByte(1);
            pushInt(0);
            pushShort(0);
            pushByte(0);

        }

    }
}