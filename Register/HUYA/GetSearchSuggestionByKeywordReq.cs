using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;

namespace HUYA
{
    public sealed class GetSearchSuggestionByKeywordReq : JceStruct
    {

        public UserId tId { get; set; }
        public string sKeyWord { get; set; }
        public override void ReadFrom(JceInputStream _is)
        {

        }

        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.tId, 0);
            _os.Write(this.sKeyWord, 1);
        }


    }
}
