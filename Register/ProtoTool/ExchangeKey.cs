using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHuya.ProtoTool
{
    class ExchangeKey : ProtoBase
    {

        private byte[] byte_0;

        private byte[] byte_1;

        public ExchangeKey(byte[] _arg1, byte[] _arg2)
        {
            byte_0 = _arg1;
            byte_1 = _arg2;
        }

        public override void marshall()
        {
            base.marshall();
            setUri(4356u);
            pushBytes(byte_0);
            pushBytes(byte_1);
        }
    }
}
