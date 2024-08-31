using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHuya.ProtoTool
{
    /// <summary>
    /// login
    /// </summary>
    class LOGINSEQ1 : ProtoBase
    {
        /*
         * struct:
        send[len(114)]:
        r#稳966-2656835610-11411022055798210560-3707647550-10057-A-0-1?醬y;括蜛.12920000306
        {len,0,0,0,35,206,0,0,200,0,VsnLen,0,VstreamName,164,1,0,0,{uid:4},0,0,0,0,0,0,0,0,0,1,0,0,0,192,168,{rnd0,255-2},{rnd1024-65535},0,0,46,49,50,57,8,0,50,48,48,48,48,51,48,54,5,8}
         */
        private string StreamName { get; set; }
        private uint Uid { get; set; }
        public LOGINSEQ1(string StreamName, long Uid)
        {
            this.StreamName = StreamName;
            this.Uid = Convert.ToUInt32(Uid);
        }

        public override void marshall()
        {
            base.marshall();
            setUri(52771);
            pushShort(200);
            pushBytes(Encoding.ASCII.GetBytes(StreamName));//78941969-2559461593-10992803837303062528-2693342886-10057-A-0-1
            pushByte(3);
            pushByte(2);
            pushShort(0);
            pushInt(Uid);
            //pushInt(0);
            pushInt(0);
            pushByte(0);
            pushInt(1);
            pushByte(192);
            pushByte(168);
            Random rand = new Random();
            pushByte(2);// pushByte((byte)rand.Next(1, 255));
            pushByte(229);//pushByte((byte)rand.Next(2, 255));
            pushByte(179);// pushByte((byte)rand.Next(2, 255));
            pushByte(123);//pushByte((byte)rand.Next(1, 255));
  
            pushByte(0);
            pushByte(0);
            pushByte(0);
            pushByte(0);
            pushByte(0);
            pushByte(0);
            //pushByte((byte)('0'+(rand).Next(0, 9)));
            //pushByte((byte)('0' + (rand).Next(0, 9)));
            //pushByte((byte)('0' + (rand).Next(0, 9)));
            //pushByte((byte)('0' + (rand).Next(0, 9)));
            pushBytes(new byte[] { 50, 48, 48, 48, 48, 51, 48, 54 });
            pushByte(0);
            pushByte(8);
        }
        
    }
}
