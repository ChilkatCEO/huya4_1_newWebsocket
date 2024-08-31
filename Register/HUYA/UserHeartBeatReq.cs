using System;
using System.Text;
using Wup.Jce;

namespace HUYA
{
    // Token: 0x020000F5 RID: 245
    public sealed class UserHeartBeatReq : JceStruct
    {
        // Token: 0x17000030 RID: 48
        // (get) Token: 0x0600008C RID: 140 RVA: 0x00002F23 File Offset: 0x00001123
        // (set) Token: 0x0600008D RID: 141 RVA: 0x00002F2B File Offset: 0x0000112B
        public UserId tId { get; set; }

        // Token: 0x17000031 RID: 49
        // (get) Token: 0x0600008E RID: 142 RVA: 0x00002F34 File Offset: 0x00001134
        // (set) Token: 0x0600008F RID: 143 RVA: 0x00002F3C File Offset: 0x0000113C
        public long lTid
        {
            get
            {
                return this._lTid;
            }
            set
            {
                this._lTid = value;
            }
        }

        // Token: 0x17000032 RID: 50
        // (get) Token: 0x06000090 RID: 144 RVA: 0x00002F45 File Offset: 0x00001145
        // (set) Token: 0x06000091 RID: 145 RVA: 0x00002F4D File Offset: 0x0000114D
        public long lSid
        {
            get
            {
                return this._lSid;
            }
            set
            {
                this._lSid = value;
            }
        }

        // Token: 0x17000033 RID: 51
        // (get) Token: 0x06000092 RID: 146 RVA: 0x00002F56 File Offset: 0x00001156
        // (set) Token: 0x06000093 RID: 147 RVA: 0x00002F5E File Offset: 0x0000115E
        public long lShortTid
        {
            get
            {
                return this._lShortTid;
            }
            set
            {
                this._lShortTid = value;
            }
        }

        // Token: 0x17000034 RID: 52
        // (get) Token: 0x06000094 RID: 148 RVA: 0x00002F67 File Offset: 0x00001167
        // (set) Token: 0x06000095 RID: 149 RVA: 0x00002F6F File Offset: 0x0000116F
        public long lPid
        {
            get
            {
                return this._lPid;
            }
            set
            {
                this._lPid = value;
            }
        }

        // Token: 0x17000035 RID: 53
        // (get) Token: 0x06000096 RID: 150 RVA: 0x00002F78 File Offset: 0x00001178
        // (set) Token: 0x06000097 RID: 151 RVA: 0x00002F80 File Offset: 0x00001180
        public bool bWatchVideo
        {
            get
            {
                return this._bWatchVideo;
            }
            set
            {
                this._bWatchVideo = value;
            }
        }

        // Token: 0x17000036 RID: 54
        // (get) Token: 0x06000098 RID: 152 RVA: 0x00002F89 File Offset: 0x00001189
        // (set) Token: 0x06000099 RID: 153 RVA: 0x00002F91 File Offset: 0x00001191
        public int eLineType
        {
            get
            {
                return this._eLineType;
            }
            set
            {
                this._eLineType = value;
            }
        }

        // Token: 0x17000037 RID: 55
        // (get) Token: 0x0600009A RID: 154 RVA: 0x00002F9A File Offset: 0x0000119A
        // (set) Token: 0x0600009B RID: 155 RVA: 0x00002FA2 File Offset: 0x000011A2
        public int iFps
        {
            get
            {
                return this._iFps;
            }
            set
            {
                this._iFps = value;
            }
        }

        // Token: 0x17000038 RID: 56
        // (get) Token: 0x0600009C RID: 156 RVA: 0x00002FAB File Offset: 0x000011AB
        // (set) Token: 0x0600009D RID: 157 RVA: 0x00002FB3 File Offset: 0x000011B3
        public int iAttendee
        {
            get
            {
                return this._iAttendee;
            }
            set
            {
                this._iAttendee = value;
            }
        }

        // Token: 0x17000039 RID: 57
        // (get) Token: 0x0600009E RID: 158 RVA: 0x00002FBC File Offset: 0x000011BC
        // (set) Token: 0x0600009F RID: 159 RVA: 0x00002FC4 File Offset: 0x000011C4
        public int iBandwidth
        {
            get
            {
                return this._iBandwidth;
            }
            set
            {
                this._iBandwidth = value;
            }
        }

        // Token: 0x1700003A RID: 58
        // (get) Token: 0x060000A0 RID: 160 RVA: 0x00002FCD File Offset: 0x000011CD
        // (set) Token: 0x060000A1 RID: 161 RVA: 0x00002FD5 File Offset: 0x000011D5
        public int iLastHeartElapseTime
        {
            get
            {
                return this._iLastHeartElapseTime;
            }
            set
            {
                this._iLastHeartElapseTime = value;
            }
        }

        // Token: 0x060000A2 RID: 162 RVA: 0x00002FE0 File Offset: 0x000011E0
        public override void WriteTo(JceOutputStream _os)
        {
            _os.Write(this.tId, 0);
            _os.Write(this.lTid, 1);
            _os.Write(this.lSid, 2);
            _os.Write(this.lShortTid, 3);
            _os.Write(this.lPid, 4);
            _os.Write(this.bWatchVideo, 5);
            _os.Write(this.eLineType, 6);
            _os.Write(this.iFps, 7);
            _os.Write(this.iAttendee, 8);
            _os.Write(this.iBandwidth, 9);
            _os.Write(this.iLastHeartElapseTime, 10);
        }

        // Token: 0x060000A3 RID: 163 RVA: 0x00003080 File Offset: 0x00001280
        public override void ReadFrom(JceInputStream _is)
        {
            this.tId = (UserId)_is.Read<UserId>(this.tId, 0, false);
            this.lTid = _is.Read(this.lTid, 1, false);
            this.lSid = _is.Read(this.lSid, 2, false);
            this.lShortTid = _is.Read(this.lShortTid, 3, false);
            this.lPid = _is.Read(this.lPid, 4, false);
            this.bWatchVideo = _is.Read(this.bWatchVideo, 5, false);
            this.eLineType = _is.Read(this.eLineType, 6, false);
            this.iFps = _is.Read(this.iFps, 7, false);
            this.iAttendee = _is.Read(this.iAttendee, 8, false);
            this.iBandwidth = _is.Read(this.iBandwidth, 9, false);
            this.iLastHeartElapseTime = _is.Read(this.iLastHeartElapseTime, 10, false);
        }

        // Token: 0x060000A4 RID: 164 RVA: 0x00003170 File Offset: 0x00001370
        public override void Display(StringBuilder _os, int _level)
        {
            JceDisplayer jceDisplayer = new JceDisplayer(_os, _level);
            jceDisplayer.Display<UserId>(this.tId, "tId");
            jceDisplayer.Display(this.lTid, "lTid");
            jceDisplayer.Display(this.lSid, "lSid");
            jceDisplayer.Display(this.lShortTid, "lShortTid");
            jceDisplayer.Display(this.lPid, "lPid");
            jceDisplayer.Display(this.bWatchVideo, "bWatchVideo");
            jceDisplayer.Display(this.eLineType, "eLineType");
            jceDisplayer.Display(this.iFps, "iFps");
            jceDisplayer.Display(this.iAttendee, "iAttendee");
            jceDisplayer.Display(this.iBandwidth, "iBandwidth");
            jceDisplayer.Display(this.iLastHeartElapseTime, "iLastHeartElapseTime");
        }

        // Token: 0x04000861 RID: 2145
        private long _lTid;

        // Token: 0x04000862 RID: 2146
        private long _lSid;

        // Token: 0x04000863 RID: 2147
        private long _lShortTid;

        // Token: 0x04000864 RID: 2148
        private long _lPid;

        // Token: 0x04000865 RID: 2149
        private bool _bWatchVideo;

        // Token: 0x04000866 RID: 2150
        private int _eLineType;

        // Token: 0x04000867 RID: 2151
        private int _iFps;

        // Token: 0x04000868 RID: 2152
        private int _iAttendee;

        // Token: 0x04000869 RID: 2153
        private int _iBandwidth;

        // Token: 0x0400086A RID: 2154
        private int _iLastHeartElapseTime;
    }
}
