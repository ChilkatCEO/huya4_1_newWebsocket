using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;
namespace HUYA
{
    class MobileSearchByKeywordRsp : JceStruct
    {

        public string sTraceId { get; set; }
        public int iJumpTab { get; set; }
        public int bIsMomentTopic { get; set; }
        public List<MobileSearchModule> c { get; set; }

        public override void ReadFrom(JceInputStream _is)
        {
            sTraceId = "";
            iJumpTab = 0;
            bIsMomentTopic = 0;
            this.sTraceId = _is.Read(this.sTraceId, 0, false);
            this.iJumpTab = _is.Read(this.iJumpTab, 1, false);
            this.bIsMomentTopic = _is.Read(this.bIsMomentTopic, 2, false);
            if (c == null)
            {
                c = new List<MobileSearchModule>();
                c.Add(new MobileSearchModule());

            }
            c = (List<MobileSearchModule>)_is.Read<List<MobileSearchModule>>(this.c, 3, false);
        }

        public override void WriteTo(JceOutputStream _os)
        {

        }

    }
}
