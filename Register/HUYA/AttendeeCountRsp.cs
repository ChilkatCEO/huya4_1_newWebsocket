using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
    // Token: 0x020000EC RID: 236
    public sealed class AttendeeCountRsp : JceStruct
    {
        // Token: 0x17000171 RID: 369
        // (get) Token: 0x060003C4 RID: 964 RVA: 0x0000919A File Offset: 0x0000739A
        // (set) Token: 0x060003C5 RID: 965 RVA: 0x000091A2 File Offset: 0x000073A2
        public long lAttendee
        {
            get
            {
                return this._lAttendee;
            }
            set
            {
                this._lAttendee = value;
            }
        }

 

        // Token: 0x060003CC RID: 972 RVA: 0x000091DE File Offset: 0x000073DE
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.lAttendee, 0);
  
        }

        // Token: 0x060003CD RID: 973 RVA: 0x00009214 File Offset: 0x00007414
        public override void ReadFrom(JceInputStream _is)
        {
            this.lAttendee = _is.Read(this.lAttendee, 0, false);
   
        }

        // Token: 0x060003CE RID: 974 RVA: 0x00009274 File Offset: 0x00007474
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display(this.lAttendee, "Attendee");

        }

        // Token: 0x040007F0 RID: 2032
        private long _lAttendee;


    }
}
