extern alias huyawatchframe;
extern alias huyaproto;
extern alias huyanetsvc;
extern alias huyawatchframeinformationview;
extern alias huyawatchframetreasurebox;
extern alias huyawatchfamemsgv;
extern alias HuyawatchFramepropertyView;
extern alias huyalogin;
using System;
//using Noesis.Javascript;
using System.IO;
using System.Text;
using System.Threading;

using System.Collections.Generic;
using huyaproto::Wup;
using System.Net.Sockets;
using System.Net;
using System.Reflection;

using huyawatchframe::Huya.WatchFrame.VideoStream;
using System.Collections.ObjectModel;
using Wup.Jce;
using HUYA;
using UserId = HUYA.UserId;
using UserChannelReq = HUYA.UserChannelReq;
using iHuya.ProtoTool;
using System.Threading.Tasks;
using WebSocketSharp;

namespace iHuya
{

    class User3 : Object
    {
        #region

        string sHuYaUA = Call.webUA;//"pc_exe&3.0.0.0&official";
        bool isMark = false;
        private bool isBizToken = false;
        string strInfor = "", oldCookie = "";
        int tokenRet = 0;
        int iFps = 40;
        string checkName = "";
        private bool isCheck = false;
        public int VideoTimerInterval = 10000;
        bool connected = false;
        //PCLogin pclogin = null;
        string UserName { get; set; }
        //channel channelsvc = null;
        //public delegate void callbackres(string a);
        public bool isShutdown = false;
        //public callbackres cbres = null;
        public int shortID { get; private set; }

        public int limitre { get; private set; }
        public byte[] WSRegisterGroupData { get; private set; }
        public byte[] UserChannelReqData { get; private set; }
        public byte[] OnReadyData { get; private set; }
        public bool isFirstLogin { get; private set; }

        int time = 60;
        Timer HBevent, SocketTimer, LastingHeartTimer, AwardTimer, ReLoginTimer;

        bool lgnOK = false;

        bool reLogin = false;

        int pindex, hbcounter = 2;
        long uid = 0;

        string pctoken = "";
        int tokentype = 0;

        public long realuid { get; private set; }
        public bool isLived { get; private set; }

        public S5Struct pubs5x = new S5Struct();
        public string state = "";





        Chilkat.Http http = null, httpex = null;

        string UserAgent = "";
        StreamItem playingOut = null;
        long pid = 0, id = 0, sid = 0;
        uint Counts = 0;
        string guid = "";
        int eop = 1;
        int allCount = 0;
        string roomid = "";
        huyawatchframe::HUYA.StreamInfo streamsinfo;
        byte[] version = Encoding.UTF8.GetBytes(Call.versions);
        private string flvuri = "";//FLV

        //private string vipp2p = "";//P2P服务器地址
        //private string vipflv = "";//FLV服务器地址

        Guest guest = null;
        private string p2puri = "", PassWord = "";//P2P
        WebSocket ws = null;

        #endregion


        private Task onmess(MessageEventArgs eo)
        {


            if (eo.Opcode == Opcode.Binary)
            {
                //lock (oo2)
                //{

                try
                {
                    byte[] recv = new byte[20480];
                    int len = eo.Data.Read(recv, 0, recv.Length);
                    byte[] arr = new byte[len];
                    Array.Copy(recv, 0, arr, 0, len);

                    dealData(arr);

                }
                catch
                {

                }


                //}
                //long len = e
                //byte[] sob = null;
                //sob = new byte[len];
                //eo.Data.Read(sob, 0, sob.Length);
                //Console.WriteLine();
            }
            else if (eo.Opcode == Opcode.Text)
            {
                Console.WriteLine(eo.Text.ReadToEnd());
            }
            return Task.FromResult(0);

        }

        /// <summary>
        /// 用户实体类初始化
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="index"></param>
        /// <param name="infor"></param>
        /// <param name="uid"></param>
        /// 
        public User3(string user, string pwd, int index, string infor, long uid, int tokenRet)
        {

            this.HBevent = new Timer(new TimerCallback(this.HB));
            ReLoginTimer = new Timer(new TimerCallback(this.ReLgn));

            SocketTimer = new Timer(new TimerCallback(this.RecvEvent));
            LastingHeartTimer = new Timer(new TimerCallback(this.LastingHearting));
            AwardTimer = new Timer(new TimerCallback(this.AwardAutoTimer));

            //infor = "";
            if (tokenRet == 126)
            {
                this.pctoken = infor;

            }

            else if (infor != "")
                this.strInfor = infor;

            UserName = user;
            PassWord = pwd;
            this.tokenRet = tokenRet;
            pindex = index;
            this.oldCookie = strInfor;

            //2256903326
            Random n = new Random();
            //1739459805
            //n.Next(1039459805, 1739459805);
            this.uid = uid;
        }
        public void GetPropsList()
        {
            HuyawatchFramepropertyView::HUYA.GetPropsListReq getPropsListReq = new HuyawatchFramepropertyView::HUYA.GetPropsListReq();
            getPropsListReq.tUserId = new HuyawatchFramepropertyView::HUYA.UserId();

            getPropsListReq.tUserId.lUid = uid;
            getPropsListReq.tUserId.sGuid = guid;
            getPropsListReq.tUserId.sHuYaUA = sHuYaUA;
            getPropsListReq.tUserId.iTokenType = tokentype;
            getPropsListReq.tUserId.sToken = pctoken;
            getPropsListReq.lSid = id;
            getPropsListReq.lSubSid = sid;
            getPropsListReq.lPresenterUid = pid;
            getPropsListReq.sMd5 = "";
            getPropsListReq.iTemplateType = 1;
            UniPacket pack = WupHelper.MakeupPacket<HuyawatchFramepropertyView::HUYA.GetPropsListReq>(getPropsListReq, "PropsUIServer", "getPropsList");

            Send(GetWebPacket(pack.Encode()));
        }
        private void AwardAutoTimer(object state)
        {
            try
            {
                AwardTimer.Change(-1, -1);
                ReqFinishOKAY(currWaitid);

            }
            catch { }
        }

        int con = 0;
        void LastingHearting(object obj)
        {
            try
            {
                if (sguid != "")
                {
                    SendWSHeart(true, true);


                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// metric
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 


        string postmetricc(string ts, string data)
        {
            //http.SetRequestHeader("Origin", "https://www.huya.com");
            string rest = "";
            try
            {
                rest = http.PostJson2("https://metric.huya.com/?ts=" + ts, "text/plain;charset=UTF-8", data).BodyStr;
            }
            catch
            {

            }
            return rest;
        }
        string sguid = "";
        string realip = "", localtion = "";
        string sdid = "";
        string nextkey = "";
        void FingerPrintCheck()
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();

            // Set the encryption algorithm = "arc4"	
            crypt.CryptAlgorithm = "arc4";

            // KeyLength may range from 1 byte to 256 bytes.
            // (i.e. 8 bits to 2048 bits)
            // ARC4 key sizes are typically in the range of 
            // 40 to 128 bits.
            // The KeyLength property is specified in bits:
            crypt.KeyLength = 128;

            // Note: The PaddingScheme and CipherMode properties
            // do not apply w/ ARC4.  ARC4 does not encrypt in blocks --
            // it is a streaming encryption algorithm. The number of output bytes
            // is exactly equal to the number of input bytes.

            // EncodingMode specifies the encoding of the output for
            // encryption, and the input for decryption.
            // It may be "hex", "url", "base64", or "quoted-printable".
            crypt.EncodingMode = "base64";

            // Note: ARC4 does not utilize initialization vectors.  IV's only
            // apply to block encryption algorithms.  

            // The secret key must equal the size of the key.
            // For 128-bit encryption, the binary secret key is 16 bytes.
            string keyHex = "";
            if (!isFirstLogin)
            {
                keyHex = "3836356134393234613430383937616331666366653662346332636262303435";

            }
            else keyHex = nextkey;//"3836356134393234613430383937616331666366653662346332636262303435";
            crypt.SetEncodedKey(keyHex, "hex");

            // Encrypt a string...
            // The output length is exactly equal to the input.  In this
            // example, the input string is 44 chars (ANSI bytes) so the
            // output is 44 bytes -- and when hex encoded results in an
            // 88-char string (2 chars per byte for the hex encoding).
            Random RND = new Random();
            string addText = Properties.Resources.printText;
            addText = addText.Replace("{NONE1}", RND.Next(1, 9).ToString());
            addText = addText.Replace("{NONE2}", RND.Next(100, 158).ToString());
            addText = addText.Replace("{NONE3}", RND.Next(8700, 9700).ToString());
            byte[] name = new byte[RND.Next(2, 7)];
            for (int i = 0; i < name.Length; i++)
                name[i] = (byte)RND.Next('a', 'z');
            string nname = Encoding.UTF8.GetString(name);
            addText = addText.Replace("{NONE4}", nname);
            addText = addText.Replace("{NONE5}", RND.Next(10, 54).ToString());
            addText = addText.Replace("{NONE6}", small);
            addText = addText.Replace("{sdid}", sdid);
            string encStr = crypt.EncryptStringENC(addText);

            byte[] arr0 = bytetool.String2Bytes(encStr);

            byte[] arrs = bytetool.strToToHexByte("0000000B");
            if (!isFirstLogin)
            {
                arrs = bytetool.strToToHexByte("0000000A");
            }
            MemoryStream ms = new MemoryStream();

            ms.Write(arrs, 0, arrs.Length);
            ms.Write(arr0, 0, arr0.Length);
            Chilkat.HttpResponse rsp = http.PBinary("POST", "https://udbdf.huya.com/device/fingerprint/check", ms.ToArray(), "application/octet-stream", false, false);
            Chilkat.JsonObject jr = new Chilkat.JsonObject
                ();
            /*if (rsp == null || rsp.BodyStr == null || rsp.BodyStr == string.Empty)
            {
                isFirstLogin = true;
                return;
                //throw new Exception("fingerprint content is empty,relogin...");
            }*/
            if (jr.Load(rsp.BodyStr))
            {
                if (!isFirstLogin)
                {
                    sdid = jr.StringOf("safedeviceid");
                    nextkey = jr.StringOf("channelKey");
                    nextkey = Call.bytesToHexString(Encoding.UTF8.GetBytes(nextkey));
                }
            }
            else
            {

                throw new Exception("loginerr");
            }

        }
        void GetRealIPInfo()
        {

            string rets = http.QuickGetStr("http://ip.360.cn/IPShare/info");

            Chilkat.JsonObject jsonA = new Chilkat.JsonObject();
            bool success = jsonA.Load(rets);
            realip = jsonA.StringOf("ip");
            localtion = jsonA.StringOf("location");
            if (localtion != null && localtion.Length > 0)
                Call.manage.Msg(4, pindex, realip);
        }
        void metrichy()
        {


            try
            {
                string key = Call.GetTimeStamp(DateTime.Now);
                if (sguid == "")
                {
                    sguid = Call.GetMD5String(uid.ToString());
                }
                Random rnd = new Random();
                string content = Properties.Resources.metricHuya001.Replace("{UID}", this.uid.ToString()).Replace("{USERMD5}", sguid).Replace("{TIMERPICK}", key)
                .Replace("{VIDEOLOADTIMING}", rnd.Next(680, 2300).ToString());
                //postmetricc(key, Call.GetEngine().Script.xEncode(content, key));

            }
            catch (Exception ex)
            {
                //Console.WriteLine("at huya_metric\n" + ex.ToString());
            }






        }
        public string Send_CheckLoginReq()
        {
            http.SetRequestHeader("Cookie", strInfor);
            http.Referer = "https://www.huya.com/" + Call.ChList[0];
            http.SetRequestHeader("Referer", http.Referer);
            while (true)
            {
                string ret2 = "";
                try
                {
                    ret2 = http.QuickGetStr("https://l.web.huya.com/index.php?m=HuyaWeb&do=check&callback=data");

                }
                catch
                {

                }
                if (ret2 == "")
                {
                    Thread.Sleep(3000);
                }
                break;
            }

            ////Console.WriteLine(ret2);
            //metrichy();
            return "okay";

        }
        /// <summary>
        /// 重新登录
        /// </summary>
        /// <param name="state"></param>
        /// 
        void CheckUserName()
        {
            string ss = "";
            try
            {
                try
                {
                    http.RemoveRequestHeader("Cookie");
                }
                catch
                {

                }
                http.SetRequestHeader("Cookie", strInfor);
                ss = http.QuickGetStr("http://www.huya.com/udb_web/udbport2.php?m=HuyaHome&do=checkUserNick");

            }
            catch
            {

            }
            //Call.log.Debug("checkusn:" + ss);
            checkName = Call.Native2Ascii(Call.StrcenterOf(ss, Properties.Resources.weblogincheckpre, Properties.Resources.webloginchecksuff));


        }
        private void ReLgn(object state)
        {

            try
            {
                isFirstLogin = false;
                ReLoginTimer.Change(-1, -1);
                try
                {
                    if (HBevent != null)
                        HBevent.Change(-1, -1);
                    if (LastingHeartTimer != null)
                        LastingHeartTimer.Change(-1, -1);
                    if (SocketTimer != null)
                        SocketTimer.Change(-1, -1);
                    if (AwardTimer != null)
                        AwardTimer.Change(-1, -1);

                }
                catch
                {

                }
                Call.AddLoginTaskT(pindex);

            }
            catch (Exception ex)
            {
                Call.manage.Msg(3, pindex, "[ERR IN RELOGON]");
                Call.manage.Msg(4, pindex, ex.StackTrace);

                //ReLoginTimer.Change(100000, 100000);
            }
        }
        object lk = new object();
        bool msgReady = false;
        huyawatchframe::HUYA.StreamInfo streamInfoOfP2p = null, streamInfoOfFlv = null;
        private string GetNameOfAward(int type)
        {
            switch (type)
            {
                case 8:
                    return "SliverBean";
                case 9:
                    return "GoldBean";
                case -1:
                    return "BadLuck";
            }
            return "Unknown" + type;
        }

        public void setSocketTimer()
        {
            SocketTimer.Change(1, 1);
        }
        void dealData(byte[] arr)
        {
            huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
            webSocketCommand.ReadFrom(new huyaproto::Wup.Jce.JceInputStream(arr));
            lastheartTime = DateTime.Now;
            if (webSocketCommand.iCmdType == 4)
            {

                UniPacket uniPacket2 = new UniPacket();
                uniPacket2.Decode(webSocketCommand.vData.ToArray(), 0);
                Wup.UniPacket oldUniPacket = new Wup.UniPacket();
                oldUniPacket.Decode(webSocketCommand.vData.ToArray(), 0);
                if (uniPacket2.Get<int>("", -1) >= 0)
                {

                    string uname = uniPacket2.FuncName;
                    Console.WriteLine("RecvFrom :" + uname + " , uid:" + uid);
                    if (uname == "doLaunch")
                    {
                        huyanetsvc::HUYA.LiveLaunchRsp liveLaunchRsp = uniPacket2.Get<huyanetsvc::HUYA.LiveLaunchRsp>("tRsp");

                        if (isAdding == false)
                        {
                            guid = sguid = liveLaunchRsp.sGuid;
                            int q = strInfor.LastIndexOf("guid");
                            if (q != -1)
                            {

                                guid = strInfor.Substring(q + 5, 32);
                            }
                            strInfor = strInfor.Replace("guid=" + guid, "guid=" + sguid);
                            guid = sguid;
                            string deviceId = mid;// guid;
                            isAdding = true;// 
                            lastheartTime = DateTime.Now;
                            Console.WriteLine("myguid:" + guid);
                            verifyHuyaToken();
                        }
                        //SendUe();
                        //}
                    }
                    else if (uname == "OnUserHeartBeat")
                    {
                        huyanetsvc::HUYA.UserHeartBeatRsp rsp = uniPacket2.Get<huyanetsvc::HUYA.UserHeartBeatRsp>("tRsp");
                        if (rsp != null)
                        {
                            lastheartTime = DateTime.Now;
                            //Console.WriteLine("hb:" + rsp.iRet);
                            //state = "已回应 " + Counts;
                        }
                    }
                    else if (uname == "getCdnTokenInfo")
                    {

                        huyawatchframe::HUYA.GetCdnTokenRsp rsp = uniPacket2.Get<huyawatchframe::HUYA.GetCdnTokenRsp>("tRsp");

                        if (rsp != null)
                        {
                            flvuri = OnCdnTokenAction(rsp, playingOut);
                            //vipflv = vipp2p;
                            if (string.IsNullOrEmpty(flvuri))
                            {
                                GetLivingInfo();
                            }
                            else
                            {


                                msgReady = true;
                                //Call.manage.Msg(5, pindex, DateTime.Now.ToString());
                                p2puri = flvuri;

                                isConnected = ConnectvideoStream();

                            }
                        }

                    }
                    else if (uname == "getLivingInfo")
                    {
                        huyawatchframe::HUYA.GetLivingInfoRsp getLivingInfoRsp = null;
                        getLivingInfoRsp = uniPacket2.Get<huyawatchframe::HUYA.GetLivingInfoRsp>("tRsp");
                        int isLiving = getLivingInfoRsp.bIsLiving;
                        this.liveId = getLivingInfoRsp.tNotice.lLiveId.ToString();
                        this.gameid = getLivingInfoRsp.tNotice.iGameId;

                        //this.pid = getLivingInfoRsp.tNotice.lPresenterUid;
                        //this.id = getLivingInfoRsp.tNotice.lChannelId;
                        //this.sid = getLivingInfoRsp.tNotice.lSubChannelId;

                        this.shortID = getLivingInfoRsp.tNotice.iShortChannel;//0

                        iFps = getLivingInfoRsp.tStreamSettingNotice.iFrameRate;

                        playingOut = new StreamItem();
                        if (isLiving != 0 && getLivingInfoRsp.tNotice.vStreamInfo.Count > 0)
                        {
                            int _iDefaultBitRateFromServer = getLivingInfoRsp.tNotice.iPCDefaultBitRate;//码率


                            ObservableCollection<LineItem> vlines = new ObservableCollection<LineItem>();
                            bool isHevc = false;

                            StreamLineHandle(getLivingInfoRsp.tNotice, ref playingOut, ref vlines, getLivingInfoRsp.tStreamSettingNotice.iBitRate, isHevc);

                            isLived = true;
                            //getLivingInfoRsp.tNotice.vStreamInfo.Count - 1
                            streamInfoOfFlv = playingOut.StreamInfo;// getLivingInfoRsp.tNotice.vStreamInfo[0];// r.Next(0, getLivingInfoRsp.tNotice.vStreamInfo.Count - 1)];
                            streamInfoOfP2p = playingOut.StreamInfo; //getLivingInfoRsp.tNotice.vStreamInfo[getLivingInfoRsp.tNotice.vStreamInfo.Count - 1];// getLivingInfoRsp.tNotice.vStreamInfo.Count - 1];
                        }
                        else
                        {
                            isLived = false;
                        }

                        if (isLived)
                        {

                            if (pindex <= 3)
                            {
                                Call.sDesc = getLivingInfoRsp.tNotice.sLiveDesc + " - " + getLivingInfoRsp.tNotice.sSubchannelName;
                                Call.gType = getLivingInfoRsp.tNotice.sGameName;
                            }


                            streamsinfo = playingOut.StreamInfo;
                            pid = streamsinfo.lPresenterUid;
                            flvuri = string.Format("{0}/{1}.flv?{2}", streamsinfo.sFlvUrl, streamsinfo.sStreamName, streamsinfo.sFlvAntiCode);
                            realUrl = string.Format("{0}.flv?{1}", streamsinfo.sStreamName, streamsinfo.sFlvAntiCode);
                            GetCdnMsg(playingOut.StreamInfo);
                        }


                    }
                    else if (uname == "getUserBoxInfo")
                    {
                        if (Call.isAwardBox)
                        {
                            lock (cc)
                            {
                                huyawatchframetreasurebox::HUYA.GetUserBoxInfoRsp getUserBoxInfoRsp = uniPacket2.Get<huyawatchframetreasurebox::HUYA.GetUserBoxInfoRsp>("tRsp");
                                if (getUserBoxInfoRsp == null)
                                {
                                    Console.WriteLine("初始化UserBoxInfo失败");
                                }
                                else
                                {
                                    vTemp = new ObservableCollection<huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo>();
                                    vTemp.Add(this.CreateTreasureBoxItemInfo(1u, getUserBoxInfoRsp.tTask1, getUserBoxInfoRsp.tTask2.iStat));
                                    vTemp.Add(this.CreateTreasureBoxItemInfo(2u, getUserBoxInfoRsp.tTask2, getUserBoxInfoRsp.tTask3.iStat));
                                    vTemp.Add(this.CreateTreasureBoxItemInfo(3u, getUserBoxInfoRsp.tTask3, getUserBoxInfoRsp.tTask4.iStat));
                                    vTemp.Add(this.CreateTreasureBoxItemInfo(4u, getUserBoxInfoRsp.tTask4, getUserBoxInfoRsp.tTask5.iStat));
                                    vTemp.Add(this.CreateTreasureBoxItemInfo(5u, getUserBoxInfoRsp.tTask5, getUserBoxInfoRsp.tTask6.iStat));
                                    vTemp.Add(this.CreateTreasureBoxItemInfo(6u, getUserBoxInfoRsp.tTask6, -1));


                                    this.ItemsInfo = vTemp;
                                    uint a = this.GetTreasureBoxCanAwardCount(getUserBoxInfoRsp);
                                    if (awardOK)
                                    {
                                        Call.manage.Msg(5, pindex, "All-OK");
                                    }
                                    else
                                    {
                                        Call.manage.Msg(5, pindex, a.ToString() + "|" + currTaskid.ToString() + "|" + currWaitid
                                            .ToString());
                                        Console.WriteLine(a.ToString() + "|" + currTaskid.ToString() + "|" + currWaitid
                                            .ToString());
                                        if (a == 6 && currTaskid == 1 && currWaitid == 999)
                                        {

                                            intervalOfAward = 60000;

                                            currWaitid = 1;
                                            Call.manage.Msg(5, pindex, "ing...1");
                                            AwardTimer.Change(intervalOfAward, intervalOfAward);
                                        }
                                        if (currTaskid != 999 && currWaitid != 999)
                                        {
                                            if (currWaitid == 1)
                                            {
                                                intervalOfAward = 60000;
                                            }

                                            AwardTimer.Change(intervalOfAward, intervalOfAward);
                                            Call.manage.Msg(5, pindex, "ing..." + currWaitid);
                                            if (a == 1 && currTaskid == 1 && currWaitid == 2)
                                            {
                                                intervalOfAward = 60000;
                                                currWaitid = 1;
                                                AwardTimer.Change(intervalOfAward, intervalOfAward);

                                            }


                                        }
                                        if (currTaskid == 6 && currWaitid == 999)
                                        {
                                            this.GetTreasureBoxCanAwardCount(getUserBoxInfoRsp, true);
                                        }


                                    }

                                }
                            }
                        }
                    }
                    else if (uname == "awardBoxPrize")
                    {
                        huyawatchframetreasurebox::HUYA.AwardBoxPrizeRsp awardBoxPrizeRsp = uniPacket2.Get<huyawatchframetreasurebox::HUYA.AwardBoxPrizeRsp>("tRsp");
                        string res = awardBoxPrizeRsp.iTaskId + "|" + awardBoxPrizeRsp.iRspCode + "," + awardBoxPrizeRsp.iCount + GetNameOfAward(awardBoxPrizeRsp.iItemType);
                        Console.WriteLine(currTaskid.ToString() + "|" + currWaitid
                                        .ToString() + "[" + res + "]");
                    }
                    else if (uname == "finishTaskNotice")
                    {
                        huyawatchframetreasurebox::HUYA.FinishTaskNoticeRsp finishTaskNoticeRsp = uniPacket2.Get<huyawatchframetreasurebox::HUYA.FinishTaskNoticeRsp>("tRsp");
                        Console.WriteLine(uid + "|完成结果:" + finishTaskNoticeRsp.iRspCode + " , ID " + finishTaskNoticeRsp.iTaskId);
                        if (finishTaskNoticeRsp.iRspCode == 0)
                        {
                            GetUserBoxbean();
                            //ReqFinishOKAY(1);
                        }

                    }
                    else if (uname == "mobileSearchByKeyword")
                    {
                        MobileSearchByKeywordRsp mobileSearchByKeywordRsp = oldUniPacket.Get<MobileSearchByKeywordRsp>("tRsp");

                    }
                    else if (uname == "getUserProfile")
                    {
                        GetUserProfileRsp getUserProfileRsp = oldUniPacket.Get<GetUserProfileRsp>("tRsp");
                        Call.manage.Msg(5, pindex, "等级:" + getUserProfileRsp.tUserProfile.tUserBase.iUserLevel);



                    }
                    else if (uname == "getNobleInfo")
                    {
                        huyalogin::HUYA.NobleBase nobleBase = uniPacket2.Get<huyalogin::HUYA.NobleBase>("tRsp");

                        if (nobleBase.iLevel > 0)
                        {
                            Call.manage.Msg(5, pindex, "爵位:" + nobleBase.sName);
                        }
                    }
                }
            }
            else if (webSocketCommand.iCmdType == 7)
            {
                WSPushMessage pushMessage = new WSPushMessage();
                pushMessage.ReadFrom(new JceInputStream(webSocketCommand.vData.ToArray()));
                if (pushMessage.iUri == 8006)
                {
                    AttendeeCountRsp attendeeCountRsp = new AttendeeCountRsp();
                    attendeeCountRsp.ReadFrom(new JceInputStream(pushMessage.vData.ToArray()));

                    //Call.AddPeople(attendeeCountRsp.lAttendee);
                }
            }
        }
        private void RecvEvent(object state)
        {

            try
            {
                //SocketTimer.Change(-1, -1);

            }
            catch
            {

            }

        }
        ObservableCollection<huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo> vTemp = null;
        private uint currTaskid = 999;
        private uint currWaitid = 999;
        bool awardOK = true;
        private ObservableCollection<huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo> ItemsInfo = null;
        private bool IsAllTaskAwarded()
        {
            try
            {
                using (IEnumerator<huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo> enumerator = this.ItemsInfo.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.TaskState != huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo.TreasureTaskState.TASK_STATE_COMPLETE_AWARDED)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        int intervalOfAward = 0;
        object cc = new object();
        private uint GetTreasureBoxCanAwardCount(huyawatchframetreasurebox::HUYA.GetUserBoxInfoRsp rsp, bool isReq = false)
        {
            uint num = 0u;
            try
            {

                awardOK = true;
                currWaitid = 999;
                currTaskid = 999;


                for (int i = 6; i > 0; i--)
                {
                    huyawatchframetreasurebox::HUYA.BoxTaskInfo bi = null;
                    switch (i)
                    {
                        case 1:
                            bi = rsp.tTask1;
                            break;
                        case 2:
                            bi = rsp.tTask2;
                            break;
                        case 3:
                            bi = rsp.tTask3;
                            break;
                        case 4:
                            bi = rsp.tTask4;
                            break;
                        case 5:
                            bi = rsp.tTask5;
                            break;
                        case 6:
                            bi = rsp.tTask6;
                            break;
                    }
                    if (bi.iStat == 1)
                    {
                        awardOK = false;
                        if (currTaskid > i)
                        {
                            currTaskid = (uint)i;
                        }
                        if (isReq)
                            ReqAwardBox((uint)i);
                        num += 1u;
                    }
                    else if (bi.iStat == 0)
                    {
                        if (i == 1)
                        {
                            ReqFinishOKAY(1);
                            return 0;
                        }
                        awardOK = false;
                        if (currWaitid > i)
                        {
                            currWaitid = (uint)i;
                        }
                        intervalOfAward = (int)vTemp[i - 1].AwardTime;
                    }
                }


                return num;
            }
            catch (Exception)
            {
            }
            return 0u;
        }

        private void ReqFinishOKAY(uint taskId)
        {
            huyawatchframetreasurebox::HUYA.FinishTaskNoticeReq finishTaskNoticeReq = new huyawatchframetreasurebox::HUYA.FinishTaskNoticeReq();
            finishTaskNoticeReq.tId = new huyawatchframetreasurebox::HUYA.UserId();
            if (pctoken != "")
            {
                finishTaskNoticeReq.tId.iTokenType = 2;
                finishTaskNoticeReq.tId.sToken = pctoken;
            }
            else
            {
                finishTaskNoticeReq.tId.sCookie = strInfor;
            }

            finishTaskNoticeReq.tId.lUid = realuid;
            finishTaskNoticeReq.tId.sGuid = guid;
            finishTaskNoticeReq.tId.sHuYaUA = Call.wxappUA;// sHuYaUA;
            finishTaskNoticeReq.lSid = id;
            finishTaskNoticeReq.lSubSid = sid;
            finishTaskNoticeReq.iTaskId = Convert.ToInt32(taskId);
            finishTaskNoticeReq.iFromType = 3;
            finishTaskNoticeReq.fVersion = 4;

            finishTaskNoticeReq.sTime = DateTime.Now.ToString();
            string text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", new object[]
            {
                finishTaskNoticeReq.tId.lUid,
                finishTaskNoticeReq.lSid,
                finishTaskNoticeReq.lSubSid,
                finishTaskNoticeReq.iTaskId,
                finishTaskNoticeReq.sPassport,
                finishTaskNoticeReq.iFromType,
                finishTaskNoticeReq.fVersion,
                finishTaskNoticeReq.sTime
            });
            finishTaskNoticeReq.sMd5 = Call.GetMD5String(text);
            UniPacket uniP = WupHelper.MakeupPacket<huyawatchframetreasurebox::HUYA.FinishTaskNoticeReq>(finishTaskNoticeReq, "huyauserui", "finishTaskNotice");
            Send(GetWebPacket(uniP.Encode()));
        }

        private huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo CreateTreasureBoxItemInfo(uint taskId, huyawatchframetreasurebox::HUYA.BoxTaskInfo taskInfo, int iNextStat = -1)
        {
            huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo treasureBoxItemInfo = new huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo();
            try
            {
                if (taskId == 1u)
                {

                    treasureBoxItemInfo.AwardTime = 180000u;

                }
                else
                {
                    treasureBoxItemInfo.AwardTime = 600000u;
                }
                if (taskInfo == null)
                {
                    return treasureBoxItemInfo;
                }
                if (taskInfo.iStat == 1)
                {
                    treasureBoxItemInfo.TaskId = taskId;
                    if (taskId == 1u && treasureBoxItemInfo.AwardTime > 0u && iNextStat == 0)
                    {
                        treasureBoxItemInfo.TaskState = huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo.TreasureTaskState.TASK_STATE_UNCOMPLETE_WAIT;
                    }
                    else
                    {
                        treasureBoxItemInfo.TaskState = huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo.TreasureTaskState.TASK_STATE_COMPLETE_UNAWARD;
                    }
                    treasureBoxItemInfo.AwardType = 0;
                    treasureBoxItemInfo.AwardCount = 0;
                    treasureBoxItemInfo.CountTime = 0u;
                    treasureBoxItemInfo.AnimPath = "";
                }
                else if (taskInfo.iStat == 2)
                {
                    treasureBoxItemInfo.TaskId = taskId;
                    treasureBoxItemInfo.TaskState = huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo.TreasureTaskState.TASK_STATE_COMPLETE_AWARDED;
                    treasureBoxItemInfo.AwardType = taskInfo.iItemType;
                    treasureBoxItemInfo.AwardCount = taskInfo.iItemCount;
                    treasureBoxItemInfo.CountTime = 0u;
                    treasureBoxItemInfo.AnimPath = "";
                }
                else
                {
                    treasureBoxItemInfo.TaskId = taskId;
                    treasureBoxItemInfo.TaskState = huyawatchframetreasurebox::Huya.WatchFrame.TreasureBox.ViewModel.TreasureBoxItemInfo.TreasureTaskState.TASK_STATE_UNCOMPLETE_WAIT;
                    treasureBoxItemInfo.AwardType = 0;
                    treasureBoxItemInfo.AwardCount = 0;
                    treasureBoxItemInfo.CountTime = 0u;
                    treasureBoxItemInfo.AnimPath = "";
                }
            }
            catch (Exception ex)
            {
            }
            return treasureBoxItemInfo;
        }
        public object LoginHuya(object o)
        {
            return LoginHy();
        }
        private void ToEndVideo()
        {

            Call.http.QuickGetStr("http://" + "localhost" + ":" + Call.usePort + "/?CloseVideo|" + pindex);// This

        }
        private void ReqAwardBox(uint taskId)
        {
            huyawatchframetreasurebox::HUYA.AwardBoxPrizeReq awardBoxPrizeReq = new huyawatchframetreasurebox::HUYA.AwardBoxPrizeReq();

            awardBoxPrizeReq.tId = new huyawatchframetreasurebox::HUYA.UserId();
            if (pctoken != "")
            {
                awardBoxPrizeReq.tId.iTokenType = 2;
                awardBoxPrizeReq.tId.sToken = pctoken;
            }
            else
            {
                awardBoxPrizeReq.tId.sCookie = strInfor;
            }
            awardBoxPrizeReq.tId.lUid = realuid;
            awardBoxPrizeReq.tId.sGuid = guid;
            awardBoxPrizeReq.tId.sHuYaUA = Call.wxappUA;

            awardBoxPrizeReq.lSid = this.id;
            awardBoxPrizeReq.lSubSid = this.sid;
            awardBoxPrizeReq.iTaskId = Convert.ToInt32(taskId);
            awardBoxPrizeReq.iFromType = 3;
            awardBoxPrizeReq.fVersion = 4;

            awardBoxPrizeReq.sTime = DateTime.Now.ToString();
            string text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", new object[]
            {
                    awardBoxPrizeReq.tId.lUid,
                    awardBoxPrizeReq.lSid,
                    awardBoxPrizeReq.lSubSid,
                    awardBoxPrizeReq.iTaskId,
                    awardBoxPrizeReq.sPassport,
                    awardBoxPrizeReq.iFromType,
                    awardBoxPrizeReq.fVersion,
                    awardBoxPrizeReq.sTime
            });
            awardBoxPrizeReq.sMd5 = Call.GetMD5String(text);
            UniPacket uniP = WupHelper.MakeupPacket<huyawatchframetreasurebox::HUYA.AwardBoxPrizeReq>(awardBoxPrizeReq, "huyauserui", "awardBoxPrize");
            Send(GetWebPacket(uniP.Encode()));
        }
        private void GetUserBoxbean()
        {
            huyawatchframetreasurebox::HUYA.GetUserBoxInfoReq getUserBoxInfoReq = new huyawatchframetreasurebox::HUYA.GetUserBoxInfoReq();
            getUserBoxInfoReq.tId = new huyawatchframetreasurebox::HUYA.UserId();
            if (pctoken != "")
            {
                getUserBoxInfoReq.tId.iTokenType = 2;
                getUserBoxInfoReq.tId.sToken = pctoken;
            }
            else
            {
                getUserBoxInfoReq.tId.sCookie = strInfor;
            }
            getUserBoxInfoReq.tId.lUid = realuid;
            getUserBoxInfoReq.tId.sGuid = guid;
            getUserBoxInfoReq.tId.sHuYaUA = sHuYaUA;
            UniPacket uniP = WupHelper.MakeupPacket<huyawatchframetreasurebox::HUYA.GetUserBoxInfoReq>(getUserBoxInfoReq, "huyauserui", "getUserBoxInfo");
            Send(GetWebPacket(uniP.Encode()));

        }
        private string GetVideoStatus()
        {
            try
            {
                string ret = httpex.QuickGetStr("http://" + "localhost" + ":" + Call.usePort + "/?GetStatus|" + pindex);
                return ret;
            }
            catch
            {
                return "false";
            }

        }


        int Time = new Random().Next(20, 50);
        public void reConnectVideo()
        {
            try
            {
                if (ws != null && Counts > 1)
                {
                    if (connectTime.AddSeconds(Time) <= DateTime.Now)
                    {
                        connectTime = DateTime.Now;
                        Call.manage.Msg(4, pindex, "VOL.." + Counts);
                        GetLivingInfo();
                        //

                        Time = new Random().Next(80, 260);
                    }
                }
            }
            catch
            {

            }
        }
        DateTime connectTime = DateTime.Now;
        /// <summary>
        /// 连接视频流服务
        /// </summary>
        /// <returns></returns>
        /// 
        bool isConnected = true;
        bool connectVErr = false;
        int jiciConn = 0;
        string connectdes = "";
        bool ConnectvideoStream()
        {

            try
            {
                connectdes = "connecting...";
                if (!Call.isOpenVideo)
                    return true;
                Call.manage.Msg(4, pindex, "开始连接视频 " + DateTime.Now);


                connectTime = DateTime.Now;
                connected = true;
                isConnected = true;
                string limitBandwidth = "1";//4096

                //"&u=" + Call.convertUid(this.uid, this.pid) + "&t=100&sv=1905221002&myIp=" + realip//&uid=" + uid;
                //string uri = flvuri + "&codec=264&baseIndex=0&quickTime=5000&ex1=0&time=57929316&u=" + Call.convertUid(this.uid, this.pid) + "&t=100&sv=1905221002";//" ;
                //"http://" + vipflv + 

                string uri = flvuri + "&codec=264&baseIndex=0&quickTime=5000&ex1=0&time=57929316&uid=" + uid; //&u=" + Call.convertUid(this.uid, this.pid) + "&t=100&sv=1905221002";//" ;

                httpex.ReadTimeout = 15;
                connectdes = "sending...";
                string res = "";
                if (Call.isOpenVideo)
                {
                    if (Call.isUsingSocks5WithVideo)
                    {
                        S5Struct s5v = Call.S5ARRAY[pindex];
                        s5v = pubs5x;
                        res = httpex.QuickGetStr("http://" + Call.imHost + ":" + Call.usePort + "/?OpenVideo|" + uri + "|" + s5v.Socks5HostName + "|" + s5v.Socks5Port + "|" + s5v.Socks5Usn + "|" + s5v.Socks5Pwd + "|" + pindex + (limitBandwidth != "" ? "|" + limitBandwidth : ""));

                    }
                    else
                    {
                        res = httpex.QuickGetStr("http://" + Call.imHost + ":" + Call.usePort + "/?OpenVideo|" + uri + "|" + "" + "|" + "" + "|" + "" + "|" + "" + "|" + pindex + (limitBandwidth != "" ? "|" + limitBandwidth : ""));

                    }
                }



                if (res == "okay")
                {
                    connectdes = "result:okay...";
                    jiciConn = 0;
                    isConnected = true;
                    connected = true;
                    connectVErr = false;
                    Call.manage.Msg(4, pindex, "视频服务返回:" + res);
                    return true;
                }
                if (res == "403Error")
                {
                    connectdes = "result:403...";
                    Call.manage.Msg(4, pindex, "403..");
                    isConnected = false;
                    connected = false;
                    GetLivingInfo();


                }
                connectdes = "result:cerr...";
                Call.manage.Msg(4, pindex, "ConnVErr " + DateTime.Now);

                jiciConn++;
                isConnected = false;
                connectVErr = true;
                connected = false;
                return false;


            }
            catch (Exception ex)
            {
                Call.manage.Msg(4, pindex, "CVERR.." + ex.Message);
                //Console.WriteLine(ex.ToString());
                //conn err
                return true;
            }

        }

        /// <summary>
        /// 连接登录服务
        /// </summary>
        /// <param name="s5x">S5代理</param>
        /// <param name="ip">远程服务IP</param>
        /// <param name="port">远程服务端口</param>
        /// <param name="useS5">是否使用S5代理，默认本机登录</param>
        /// <param name="useCook">附加Cookie连接WS</param>
        /// <returns></returns>
        /// 
        bool ConnectTo(S5Struct s5x, string ip, int port = 80, bool useS5 = true, bool useCook = false, bool tls = false)
        {

            string vip = "wss://" + ip;
            if (ws != null)
            {
                try
                {
                    ws.Close();
                    ws = null;
                }
                catch
                {

                }

            }

            ws = new WebSocket(vip, onMessage: onmess);
            bool success = DoConnect(useS5).Wait(8000);


            return success;

        }
        bool wsIsConnect = false;

        async Task DoConnect(bool uses5)
        {



            try
            {

                if (uses5)
                    ws.SetProxy("http://" + pubs5x
                        .Socks5HostName + ":" + pubs5x.Socks5Port, pubs5x.Socks5Usn, pubs5x.Socks5Pwd);
                else
                {
                    //ws.SetProxy("http://localhost:1080", "a", "a");
                }
                ws.Origin = "https://www.huya.com/";
                wsIsConnect = await ws.Connect().ConfigureAwait(false);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        object oo1 = new object();
        async void Send(byte[] buff)
        {
            var await_ = await this.ws.Send
                (buff).ConfigureAwait(false);
            if (await_)
                wsIsConnect = true;
            else wsIsConnect = false;

        }
        object oo2 = new object();


        /// <summary>
        /// POST 请求 wup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] PostData(byte[] data, int i = 0)
        {
            if (http != null)
            {
                try
                {
                    Chilkat.HttpResponse hrsp = http.PBinary("POST", "https://" + (i == 0 ? "wup" : "online") + ".huya.com/", data, string.Empty, false, false);
                    byte[] str = hrsp.Body;

                    if (http.LastMethodSuccess != true)
                        throw new Exception(http.LastErrorText);
                    return str;
                }
                catch
                {

                }
            }
            return null;

        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        void LiveLaunchReq(bool isWS = false)
        {
            LiveLaunchReq req = new LiveLaunchReq();
            req.tId = new UserId();
            req.tId.lUid = uid;
            if (pctoken != "")
            {
                req.tId.sToken = pctoken;
                req.tId.iTokenType = tokentype;
            }
            else req.tId.sCookie = strInfor;

            if (isWS)
                req.tId.sGuid = guid;
            else req.tId.sGuid = "";
            req.tId.sHuYaUA = sHuYaUA;
            req.tLiveUB = new LiveUserbase();
            req.tLiveUB.eSource = 1;
            req.tLiveUB.tUAEx = new LiveAppUAEx();
            req.tLiveUB.tUAEx.sDeviceId = "";// mid;// "bd7c05d0-9816-4f6d-a8e8-f3c911e2ccc5";
            Wup.UniPacket pack = Wup.WupHelper.MakeupPacket<LiveLaunchReq>(req, "launch", "doLaunch");
            if (isWS)
            {
                Send(GetWebPacket(pack.Encode()));
                return;
            }
            byte[] res = PostData(pack.Encode());
            UniPacket uniPacket2 = new UniPacket();
            uniPacket2.Decode(res);
            huyanetsvc::HUYA.LiveLaunchRsp liveLaunchRsp = uniPacket2.Get<huyanetsvc::HUYA.LiveLaunchRsp>("tRsp");

            if (isAdding == false)
            {
                guid = sguid = liveLaunchRsp.sGuid;
                int q = strInfor.LastIndexOf("guid");
                if (q != -1)
                {

                    guid = strInfor.Substring(q + 5, 32);
                }
                strInfor = strInfor.Replace("guid=" + guid, "guid=" + sguid);
                guid = sguid;
                string deviceId = mid;// guid;
                isAdding = true;// 
            }




        }
        void verifyHuyaToken()
        {
            huyaproto::Wup.Jce.JceStruct os = null;
            huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
            if (pctoken == "")
            {
                WSVerifyCookieReq verifyCookieReq = new WSVerifyCookieReq();
                verifyCookieReq.bAutoRegisterUid = 1;
                verifyCookieReq.sGuid = guid;
                verifyCookieReq.sCookie = strInfor;
                verifyCookieReq.sUA = sHuYaUA;
                verifyCookieReq.uid = uid;
                webSocketCommand.iCmdType = (int)EWebSocketCommandType.EWSCmdC2S_VerifyCookieReq;
                os = verifyCookieReq;
            }
            else
            {
                huyanetsvc::HUYA.WSVerifyHuyaTokenReq wsverifyHuyaTokenReq = new huyanetsvc::HUYA.WSVerifyHuyaTokenReq();
                wsverifyHuyaTokenReq.tId = new huyanetsvc::HUYA.UserId();
                wsverifyHuyaTokenReq.tId.lUid = uid;

                wsverifyHuyaTokenReq.tId.iTokenType = tokentype;
                wsverifyHuyaTokenReq.tId.sToken = pctoken;
                webSocketCommand.iCmdType = 12;
                wsverifyHuyaTokenReq.tId.sHuYaUA = sHuYaUA;
                wsverifyHuyaTokenReq.bAutoRegisterUid = 1;
                os = wsverifyHuyaTokenReq;

            }


            huyaproto::Wup.Jce.JceOutputStream jceOutputStream = new huyaproto::Wup.Jce.JceOutputStream();
            os.WriteTo(jceOutputStream);
            webSocketCommand.vData = new List<byte>(jceOutputStream.toByteArray());
            huyaproto::Wup.Jce.JceOutputStream jceOutputStream2 = new huyaproto::Wup.Jce.JceOutputStream();
            webSocketCommand.WriteTo(jceOutputStream2);
            byte[] sendData = jceOutputStream2.toByteArray();


            Send(sendData);



        }
        byte[] DecodeWebPack(byte[] pack)
        {
            //pack = new byte[] { 0, 1, 29, 0, 0, 23, 12, 16, 1, 38, 0, 54, 0, 66, 2, 236, 222, 203, 83, 0, 0, 0, 0, 152, 220, 226, 59, 108, 124 };

            if (pack == null || pack.Length <= 0)
                throw new Exception("接收错误.");
            huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
            try
            {


                webSocketCommand.ReadFrom(new huyaproto::Wup.Jce.JceInputStream(pack));
                int type = webSocketCommand.iCmdType;
                //Console.WriteLine("cmdType:" + type);
                return webSocketCommand.vData.ToArray();
            }
            catch
            {

            }
            //Console.WriteLine("收到消息类型：" + webSocketCommand.iCmdType);
            return new byte[] { };
        }
        byte[] GetWebPacket(byte[] pack)
        {
            // return Call.getProtoBuff(pack);
            huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
            webSocketCommand.iCmdType = 3;
            webSocketCommand.vData = new List<byte>(pack);


            huyaproto::Wup.Jce.JceOutputStream jceOutputStream = new huyaproto::Wup.Jce.JceOutputStream();
            //jceOutputStream.setServerEncoding("Unicode");
            webSocketCommand.WriteTo(jceOutputStream);

            byte[] array = jceOutputStream.toByteArray();
            return array;
        }
        void GetCdnMsg(huyawatchframe::HUYA.StreamInfo streamInfo)
        {
            huyawatchframe::HUYA.GetCdnTokenReq getCdnTokenReq = new huyawatchframe::HUYA.GetCdnTokenReq();

            getCdnTokenReq.stream_name = streamInfo.sStreamName;
            getCdnTokenReq.cdn_type = streamInfo.sCdnType;


            //Call.manage.Msg(3, pindex, "获取节点NORMAL");
            UniPacket packue = WupHelper.MakeupPacket<huyawatchframe::HUYA.GetCdnTokenReq>(getCdnTokenReq, "liveui", "getCdnTokenInfo");


            //Send(GetWebPacket(packue.Encode()));

            Send(GetWebPacket(packue.Encode()));


        }
        string realUrl = "";
        private string OnCdnTokenAction(huyawatchframe::HUYA.GetCdnTokenRsp pack, object obj)
        {
            try
            {

                StreamItem streamItem = obj as StreamItem;
                string text = "";
                if (pack != null)
                {
                    huyawatchframe::HUYA.GetCdnTokenRsp getCdnTokenRsp = pack;
                    int rate = 2000;
                    bool flag = false;
                    bool flag2 = false;

                    //int i = pindex % 3;
                    //if(i==0)
                    text = string.Format("{0}/{1}." + streamItem.StreamInfo.sFlvUrlSuffix + "?{2}", streamItem.StreamInfo.sFlvUrl, streamItem.StreamInfo.sStreamName, getCdnTokenRsp.flv_anti_code);


                    realUrl = text;
                    flvuri = p2puri = realUrl;
                    // string t2= string.Format("{0}/{1}." + streamItem.StreamInfo.sHlsUrlSuffix + "?{2}", streamItem.StreamInfo.sHlsUrl, streamItem.StreamInfo.sStreamName, getCdnTokenRsp.hls_anti_code);//
                    //string t3 = string.Format("{0}/{1}." + streamItem.StreamInfo.sP2pUrlSuffix + "?{2}", streamItem.StreamInfo.sP2pUrl, streamItem.StreamInfo.sStreamName, getCdnTokenRsp.anti_code);//*/
                    return realUrl;
                    if (flag2)
                    {
                        if (streamItem.MultiStreamInfo.iCodecType != 0)
                        {
                            flag = true;
                            text = string.Format("{0}/{1}.flv?{2}&codec=265", streamItem.StreamInfo.sFlvUrl, streamItem.StreamInfo.sStreamName, getCdnTokenRsp.flv_anti_code);
                        }
                        else if (streamItem.StreamInfo.iIsHEVCSupport == 1 && streamItem.MultiStreamInfo.iHEVCBitRate > 0)
                        {
                            flag = true;
                            rate = 2000;
                            text = string.Format("{0}/{1}.flv?{2}&ratio={3}&codec=265", new object[]
                            {
                         streamItem.StreamInfo.sFlvUrl,
                         streamItem.StreamInfo.sStreamName,
                         getCdnTokenRsp.flv_anti_code,
                         rate
                            });
                        }
                        else if (streamItem.MultiStreamInfo.iBitRate == 0)
                        {
                            text = string.Format("{0}/{1}.flv?{2}", streamItem.StreamInfo.sFlvUrl, streamItem.StreamInfo.sStreamName, getCdnTokenRsp.flv_anti_code);//&codec=264
                        }
                        else
                        {
                            rate = 2000;// streamItem.MultiStreamInfo.iBitRate;
                            text = string.Format("{0}/{1}.flv?{2}&ratio={3}", new object[]//&codec=264
                            {
                         streamItem.StreamInfo.sFlvUrl,
                         streamItem.StreamInfo.sStreamName,
                         getCdnTokenRsp.flv_anti_code,
                         rate
                            });
                        }
                    }
                    else if (streamItem.MultiStreamInfo.iBitRate == 0)
                    {
                        text = string.Format("{0}/{1}.flv?{2}", streamItem.StreamInfo.sFlvUrl, streamItem.StreamInfo.sStreamName, getCdnTokenRsp.flv_anti_code);//&codec=264
                    }
                    else
                    {
                        rate = 2000;// streamItem.MultiStreamInfo.iBitRate;
                        text = string.Format("{0}/{1}.flv?{2}&ratio={3}", new object[]//&codec=264
                        {
                     streamItem.StreamInfo.sFlvUrl,
                     streamItem.StreamInfo.sStreamName,
                     getCdnTokenRsp.flv_anti_code,
                     rate
                        });
                    }


                    string obj2 = string.Format("flv={0},  IsHEVCSupport={1}, HEVCBitRate={2}, IsHevc={3}, LineIndex={4}, IsH265={5}", new object[]
                    {
                 text,
                 streamItem.StreamInfo.iIsHEVCSupport,
                 streamItem.MultiStreamInfo.iHEVCBitRate,
                 flag2,
                 streamItem.LineIndex,
                 flag
                    });

                    //Console.WriteLine(obj2);
                }


                return text;
            }
            catch (Exception ex)
            {

            }
            return "";
        }
        void StreamLineHandle(huyawatchframe::HUYA.BeginLiveNotice tNotice, ref StreamItem playingStreamOut, ref ObservableCollection<LineItem> vLines, int LiveBitRate, bool IsHevc)
        {
            string text = "";
            try
            {
                LineItem lineItem = new LineItem();
                if (tNotice != null && tNotice.vMultiStreamInfo != null && tNotice.vStreamInfo != null && tNotice.vCdnList != null && tNotice.vMultiStreamInfo != null)
                {
                    bool flag = false;
                    Random rnd = new Random();
                    double num = (double)(rnd.Next() % 100 + 1);
                    foreach (huyawatchframe::HUYA.StreamInfo streamInfo in tNotice.vStreamInfo)
                    {
                        string log = (string.Format("HUYA.BeginLiveNotice VideoStream.StreamItem sCdnType={0},iPCPriorityRate={1}", streamInfo.sCdnType, streamInfo.iPCPriorityRate));
                        //Console.WriteLine(log);

                        if (!(streamInfo.sCdnType == "OLD_YY"))
                        {
                            int iLineIndex = streamInfo.iLineIndex;

                            lineItem.sCdnType = streamInfo.sCdnType;
                            lineItem.LineIndex = streamInfo.iLineIndex;
                            lineItem.LineName = string.Format("线路{0}：", streamInfo.iLineIndex);
                            lineItem.vStreamItems = new ObservableCollection<StreamItem>();
                            vLines.Add(lineItem);
                            if (streamInfo.iPCPriorityRate >= 0)
                            {
                                if ((double)streamInfo.iPCPriorityRate >= num)
                                {
                                    text = streamInfo.sCdnType;
                                }
                                else
                                {
                                    num -= (double)streamInfo.iPCPriorityRate;
                                }
                            }
                            bool flag2 = tNotice.iCodecType == 4 || tNotice.iCodecType == 1 || tNotice.iCodecType == 6;
                            foreach (huyawatchframe::HUYA.MultiStreamInfo multiStreamInfo in tNotice.vMultiStreamInfo)
                            {
                                string log2 = (string.Format("iCodecType={0},sCdnType={1},iBitRate={2},sDisplayName={3},LiveBiteRate={4}, IsHevc={5}, IsH265={6}", new object[]
                                {
                                    multiStreamInfo.iCodecType,
                                    streamInfo.sCdnType,
                                    multiStreamInfo.iBitRate,
                                    multiStreamInfo.sDisplayName,
                                    LiveBitRate,
                                    IsHevc,
                                    flag2
                                }));
                                //Console.WriteLine(log2);
                                if (IsHevc)
                                {
                                    if (multiStreamInfo.iBitRate >= LiveBitRate)
                                    {
                                        continue;
                                    }
                                }
                                else if (flag2 && multiStreamInfo.iBitRate == 0)
                                {
                                    continue;
                                }
                                StreamItem streamItem = new StreamItem();
                                streamItem.sCheckTag = streamInfo.sCdnType + "_" + multiStreamInfo.iBitRate.ToString();
                                streamItem.sDisplayName = multiStreamInfo.sDisplayName;
                                streamItem.LineIndex = iLineIndex;
                                streamItem.LiveRate = LiveBitRate;
                                streamItem.MultiStreamInfo = multiStreamInfo;
                                streamItem.StreamInfo = streamInfo;
                                lineItem.vStreamItems.Add(streamItem);
                                if (text == streamInfo.sCdnType && tNotice.iPCDefaultBitRate == multiStreamInfo.iBitRate)
                                {
                                    playingStreamOut = streamItem;
                                    flag = true;
                                }
                            }
                        }
                    }
                    if (!flag || (playingStreamOut != null && playingStreamOut.LineIndex == 3))
                    {
                        try
                        {
                            if (vLines != null && vLines.Count != 0)
                            {
                                int num2 = rnd.Next(0, vLines.Count);
                                if (num2 < 0 || num2 >= vLines.Count || vLines[num2].LineIndex == 3)
                                {
                                    num2 = (num2 + 1) % vLines.Count;
                                }
                                int recommendRateIndex = GetRecommendRateIndex(vLines[num2].vStreamItems, tNotice.iPCDefaultBitRate);
                                if (recommendRateIndex >= 0)
                                {
                                    playingStreamOut = vLines[num2].vStreamItems[recommendRateIndex];
                                    flag = true;
                                }
                                string log3 = (string.Format("randLineIndex={0}, rateIndex={1}, vLineCout={2}", num2, recommendRateIndex, vLines.Count));
                                //Console.WriteLine(log3);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    if (!flag && vLines.Count > 0)
                    {
                        if (text == "")
                        {
                            text = vLines[0].sCdnType;
                        }

                        foreach (LineItem lineItem2 in vLines)
                        {
                            if (lineItem2.sCdnType == text && lineItem2.vStreamItems.Count > 0)
                            {
                                playingStreamOut = lineItem2.vStreamItems[0];
                                break;
                            }
                        }
                    }
                    StreamItem sitem = new StreamItem();

                    if (isConnectErr)
                    {
                        int ii = pindex % tNotice.vStreamInfo.Count;

                    rernd:

                        int iii = rnd.Next(0, tNotice.vStreamInfo.Count - 1);

                        if (iii == ii) goto rernd;

                        sitem.StreamInfo = tNotice.vStreamInfo[iii];


                    }
                    else sitem.StreamInfo = tNotice.vStreamInfo[pindex % tNotice.vStreamInfo.Count];


                    //Random rrnd = new Random();//rrnd.Next(0, lineItem.vStreamItems.Count-1)]
                    playingStreamOut = sitem;//lineItem.vStreamItems[lineItem.vStreamItems.Count-1];
                    videoLine = 1;// sitem.LineIndex;
                }
            }
            catch (Exception ex2)
            {

            }
        }

        bool isConnectErr = false;
        private int GetRecommendRateIndex(ObservableCollection<StreamItem> items, int defaultRate)
        {
            try
            {
                if (items == null || items.Count == 0)
                {
                    return -1;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].MultiStreamInfo.iBitRate == defaultRate)
                    {
                        return i;
                    }
                }
                return 0;
            }
            catch (Exception)
            {
            }
            return -1;
        }
        void wsuserinfo()
        {

            huyanetsvc::HUYA.WSUserInfo wsuserInfo = new huyanetsvc::HUYA.WSUserInfo();
            wsuserInfo.bAnonymous = false;
            wsuserInfo.lTid = id;
            wsuserInfo.lSid = sid;
            wsuserInfo.lUid = uid;
            wsuserInfo.lGroupId = uid;
            wsuserInfo.lGroupType = 0L;
            wsuserInfo.bAnonymous = false;



            MethodInfo method = typeof(huyanetsvc::HUYA.WSUserInfo).GetMethod("WriteTo");
            huyaproto::Wup.Jce.JceOutputStream jceOutputStream = new huyaproto::Wup.Jce.JceOutputStream();
            if (method != null)
            {
                method.Invoke(wsuserInfo, new object[]
                {
                        jceOutputStream
                });
            }
            huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
            webSocketCommand.iCmdType = (int)huyanetsvc::HUYA.EWebSocketCommandType.EWSCmd_RegisterReq;
            webSocketCommand.vData = new List<byte>(jceOutputStream.toByteArray());
            huyaproto::Wup.Jce.JceOutputStream jceOutputStream2 = new huyaproto::Wup.Jce.JceOutputStream();
            webSocketCommand.WriteTo(jceOutputStream2);
            byte[] data = jceOutputStream2.toByteArray();
            Send(data);

            // Call.manage.Msg(3, pindex, wrr.sMessage);

            return;


        }


        void new__guest()
        {
            Chilkat.HttpResponse resp = http.QuickGetObj("http://www.huya.com/udb_web/checkLogin.php");
            if (resp != null && resp.NumCookies > 0)
            {
                string strp = "";
                for (int i = 0; i < resp.NumCookies; i++)
                {
                    strp += resp.GetCookieName(i) + "=" + resp.GetCookieValue(i) + "; ";
                }
                string phpsess = Call.StrcenterOf(strInfor, "PHPSESSID=", ";");
                if (phpsess != "")
                {
                    strInfor = strInfor.Replace("PHPSESSID=" + phpsess + ";", "");
                }
                guid = Call.GetMD5String(uid.ToString());
                string guestcookie = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + "0e74abbcc485d05b6e9f99099a09405a" + "; SoundValue=0.07; ";
                if (guest == null)
                {
                    if (pindex % 2 == 0)
                        guest = new Guest(new S5Struct(), guestcookie, id, sid, pid);
                    else guest = new Guest(pubs5x, guestcookie, id, sid, pid);
                    guest.ReLoginTimer.Change(8000, 8000);
                }
                if (strInfor.IndexOf("videoBitRate") != -1)
                {
                    strInfor = strInfor.Replace("videoBitRate=0;", "videoBitRate=2000;");
                    strInfor = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + guid + "; SoundValue=0.07; " + strInfor;
                }
                else
                {
                    strInfor = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + guid + "; SoundValue=0.07; videoBitRate=2000; " + strInfor;
                }
                isCheck = true;
            }
        }

        void SendStatwupLog()
        {
        reTry:
            byte[] arrs = bytetool.strToToHexByte("0000021610022C3C4C56066D657472696366067265706F72747D000101F3080001060474526571180001060E485559412E4D65747269635365741D000101D20A0A023B7975E11620306134343164363433353530656135623532393966353863663638633731616127000001047751432F4141454441414141345856354F774141414141414141414141414141414151414E5441774E6851414E7A42684E444134596A677A4F445A6B4E6A45334E7A4D344D325945414455774D446143414149596A367262794459484B6A436D57393437364F45702F5964306F6E51683133556168737A64617A2F4E746C6C32436F6B366E4E48452F6234474962616D736D424C614D5875385257776F5151787750446654366D426852773463444D76455030347731485231704B364171392F74674648396C4E746C6C535134664B516A38356F7641642B2B47706D45626673426A67573947315650415863754C463239346E3674322B4679672B715077514141414141361770635F65786526332E322E302E30266F6666696369616C460050020B1900010A0612706C617965722E7032702E64657461696C731900040A0609616E63686F72756964160A313339343537353533340B0A0608636F6465726174651601300B0A06046C696E651601330B0A060A706C6179657274797065160A64787661706C617965720B2308D67F9CC7A36AE83C4C550000000000000000600F86000B0B8C980CA80C");
            if (http.PBinary("POST", "http://statwup.huya.com", arrs, "application/x-wup", false, false) == null)
            {
                Thread.Sleep(3000);
                goto reTry;
            }
        }
        void SendUdbHeartLog()
        {

            byte[] arrs = bytetool.strToToHexByte("000005B010032C3C4200AD4EA8560C68757961756462776562756966067265706F72747D0001058308000206095F7775705F646174611D000105550A0A0C1603312E3026647B226173736F63696174696F6E4964223A383234312C2266756E634E616D65223A227265706F7274222C2267726F7570223A31312C226964223A343134352C2273657373696F6E223A31313335373836342C2273746570223A312C2274797065223A337D360435303036400356423130396338353136333662623161303662396562333634366137663963623436636134393662616537336332386139663962663331396162363838373231303131640B160768757961756462270000048B5B7B226170705F766572223A22332E322E302E30222C226170706964223A2235303036222C22627970617373223A332C22636172726965725F74797065223A322C226368616E6E656C223A2233222C2264657461696C223A226E61746976652073646B20696E6974222C226465766963655F6964223A223730613430386238333836643631373733383366222C226465766963655F6E616D65223A224C53444E2D32303138313033315748222C226C6576656C223A312C226C6F63616C5F74696D65223A313534383034343230313030302C226E65745F74797065223A322C2273646B5F766572223A22222C227365727665725F686F7374223A22222C2273797374656D5F696E666F223A2277696E646F7773222C2273797374656D5F766572223A224D6963726F736F66742057696E646F777320372020556C74696D6174652045646974696F6E2053657276696365205061636B20312C2036342D626974222C227465726D5F74797065223A332C22757269223A22696E6974227D2C7B226170705F766572223A22332E322E302E30222C226170706964223A2235303036222C22627970617373223A332C22636172726965725F74797065223A322C226368616E6E656C223A2233222C2264657461696C223A226C6F616462696E643A73697A653A34222C226465766963655F6964223A223730613430386238333836643631373733383366222C226465766963655F6E616D65223A224C53444E2D32303138313033315748222C226C6576656C223A312C226C6F63616C5F74696D65223A313534383034343230313030302C226E65745F74797065223A322C2273646B5F766572223A22222C227365727665725F686F7374223A22222C2273797374656D5F696E666F223A2277696E646F7773222C2273797374656D5F766572223A224D6963726F736F66742057696E646F777320372020556C74696D6174652045646974696F6E2053657276696365205061636B20312C2036342D626974222C227465726D5F74797065223A332C22757269223A226C6F616462696E64227D2C7B226170705F766572223A22332E322E302E30222C226170706964223A2235303036222C22627970617373223A332C22636172726965725F74797065223A322C226368616E6E656C223A2233222C2264657461696C223A2273617665706174683A73697A653A333B7569643A393937383135373737222C226465766963655F6964223A223730613430386238333836643631373733383366222C226465766963655F6E616D65223A224C53444E2D32303138313033315748222C226C6576656C223A312C226C6F63616C5F74696D65223A313534383034343230313030302C226E65745F74797065223A322C2273646B5F766572223A22222C227365727665725F686F7374223A22222C2273797374656D5F696E666F223A2277696E646F7773222C2273797374656D5F766572223A224D6963726F736F66742057696E646F777320372020556C74696D6174652045646974696F6E2053657276696365205061636B20312C2036342D626974222C227465726D5F74797065223A332C22757269223A226C6F616463726564227D5D0B0610777570756462726571756573745F76301D0000050200AD4EA88C980CA80C");
            http.PBinary("POST", "https://udbdf.huya.com/device/fingerprint/check", arrs, "application/x-wup", false, false);

        }
        public void loginres()
        {
            /*if (pclogin.ticketget)
            {
                if (pclogin.token != "")
                {

                    Call.manage.Msg(3, pindex, "已分配 " + pclogin.tokenType);
                    pctoken = pclogin.token;
                    tokentype = pclogin.tokenType;
                    this.uid = Convert.ToInt64(pclogin.uid);
                    ReLoginTimer.Change(2000, 2000);
                    if (cbres != null)
                        cbres(pctoken);
                }
                else
                {

                    Call.manage.Msg(3, pindex, "登录失败 = >" + pclogin.errmsg);
                    if (cbres != null)
                        cbres(pclogin.errmsg);

                }

            }
            else if (pclogin.token == "")
            {

                Call.manage.Msg(3, pindex, "登录失败 = >" + pclogin.errmsg);
                if (cbres != null)
                    cbres(pclogin.errmsg);

            }
            else
            {
                pclogin.ticketlogin(ulong.Parse(pclogin.uid), pclogin.token);
            }
            */

        }

        bool isChangeID = false;
        public bool LoginHy()
        {
            try
            {
                SocketTimer.Change(-1, -1);
                ReLoginTimer.Change(-1, -1);
                HBevent.Change(-1, -1);

                Call.manage.Msg(3, pindex, "LGN-1");
                msgReady = false;
                connectVErr = false;
                isConnected = false;
                connected = false;
                jiciConn = 0;
                isShutdown = false;
                if (httpex != null && isChangeID)
                {
                    string ff = Call.outAUser();

                    string[] ss = ff.Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
                    if (ss.Length <= 0)
                    {
                        Call.manage.Msg(4, pindex, "USERGETTERERR");
                        throw new Exception("获取账号异常");
                    }
                    UserName = ss[0];
                    PassWord = ss[1];
                    Call.manage.Msg(1, pindex, UserName);
                    Call.manage.Msg(4, pindex, "CUser");
                }


                Call.manage.Msg(4, pindex, "");
                Call.manage.Msg(3, pindex, "LGN-2");
                connected = false;
                is403 = false;
                if (roomid == "")
                {
                    try
                    {
                        roomid = Call.ChList[0];
                        Call.getChannelArgs(roomid, ref pid, ref id, ref sid);
                    }
                    catch (Exception err)
                    {
                        Call.manage.Msg(3, pindex, "STREAMERR");
                        Thread.Sleep(1000);
                        throw new Exception("STREAMERR");
                    }
                }
                reLogin = true;
                connected = false;
                time = 60;
                S5Struct s5x = new S5Struct();
                if (Call.isUsingSocks5 || Call.isUsingSocks5WithSvc || Call.isUsingSocks5WithVideo)
                {
                    try
                    {
                        s5x = Call.readAS5(pindex);
                        pubs5x = s5x;
                    }
                    catch
                    {
                        Call.manage.Msg(3, pindex, "[NO PROXY]");
                        return false;
                    }
                }

                if (http == null)
                    http = new Chilkat.Http();
                Random rnd = new Random();
                UserAgent = Call.useragent[rnd.Next(0, Call.useragent.Length - 1)];
                http.UserAgent = UserAgent;
                if (httpex == null)
                    httpex = new Chilkat.Http();
                http.Connection = "keep-alive";
                httpex.Connection = "keep-alive";
                httpex.ReadTimeout = 10;
                httpex.ConnectTimeout = 20;

                if (tokenRet == 0)
                {
                    Call.manage.Msg(3, pindex, "LGN-GETUID");
                    if (!LoginHuya(UserName, PassWord))
                    {
                        if (isChangeID)
                        {
                            throw new Exception("登录重新获取账号");
                        }
                        reLogin = false;
                        Call.manage.Msg(3, pindex, "LGNERR");
                        lgnOK = true;
                        return true;


                    }
                    Call.manage.Msg(3, pindex, "LGN-RETUID " + uid);
                    //strInfor = "";
                    //pctoken = "";
                    //tokentype = 2;
                }
                if (Call.isUsingSocks5)
                {
                    http.SocksVersion = 5;
                    http.SocksHostname = s5x.Socks5HostName;
                    http.SocksPort = s5x.Socks5Port;
                    http.SocksUsername = s5x.Socks5Usn;
                    http.SocksPassword = s5x.Socks5Pwd;

                    Call.manage.Msg(2, pindex, "Socks5");
                }
                else Call.manage.Msg(2, pindex, "Local");

                try
                {


                    //LiveLaunchReq();
                    Call.manage.Msg(3, pindex, "LGN[1359]");

                    string[] users;
                    //if (Call.accountsrc != null && Call.accountsrc.Length > 0 && !isBizToken)
                    //{

                    //   users = Call.accountsrc[pindex].Split(',');
                    //   UserName = users[0];
                    //   PassWord = users[1];
                    //   Call.manage.Msg(3, pindex, "读取");
                    //}
                    //else
                    //{
                    //#if DEBUG
                    //goto tryautologin;
                    //#endif
                    users = new string[] { UserName, PassWord };
                    //}
                    /*reLogin = false;
                    lgnOK = true;
                    new__guest();
                    return true;*/

                    //ua设置

                    if (pindex % 5 == 0)
                        sHuYaUA = Call.webUA;
                    else
                    {
                        if (pindex % 2 == 0)
                            sHuYaUA = Call.pcUA;//PCUA
                        else
                        {
                            if (pindex % 7 == 0)
                            {
                                sHuYaUA = Call.iphoneUA;
                            }
                            else sHuYaUA = Call.wxappUA;
                        }

                    }
                    Call.manage.Msg(4, pindex, "[" + sHuYaUA + "]");
                }
                catch (Exception ex)
                {
                    throw new Exception("登录:" + ex.Message);

                }
                Call.manage.Msg(3, pindex, "LGN-3");


                Chilkat.HttpResponse resp = null;

                strInfor = oldCookie;

                http.RemoveRequestHeader("Cookie");


                resp = http.QuickGetObj("http://www.huya.com/udb_web/checkLogin.php");


                if (resp == null)
                {
                    //reLogin = true;

                    http.RemoveRequestHeader("Cookie");
                    strInfor = oldCookie;
                    http.SetRequestHeader("Cookie", strInfor);
                    isCheck = false;
                    //throw new Exception("校验登录失败");
                }
                else
                {
                    if (isCheck && resp.NumCookies > 0)
                    {
                        isCheck = false;
                        strInfor = oldCookie;

                    }
                }





                if (resp != null && resp.NumCookies > 0)
                {

                    string strp = getSTRP(true);
                    for (int i = 0; i < resp.NumCookies; i++)
                    {
                        strp += resp.GetCookieName(i) + "=" + resp.GetCookieValue(i) + "; ";
                    }
                    string phpsess = Call.StrcenterOf(strInfor, "PHPSESSID=", ";");
                    if (phpsess != "")
                    {
                        strInfor = strInfor.Replace("PHPSESSID=" + phpsess + ";", "");
                    }
                    guid = Call.GetMD5String(uid.ToString());
                    string guestcookie = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + "0e74abbcc485d05b6e9f99099a09405a" + "; SoundValue=0.50; ";
                    if (guest == null)
                    {
                        //if (pindex % 2 == 0)
                        //    guest = new Guest(new S5Struct(), guestcookie, id, sid, pid);
                        //else guest = new Guest(pubs5x, guestcookie, id, sid, pid);
                        //guest = new Guest(s5x, guestcookie, id, sid, pid);
                        //guest.ReLoginTimer.Change(8000, 8000);

                        if (strInfor.IndexOf("videoBitRate") != -1)
                        {
                            strInfor = strInfor.Replace("videoBitRate=0;", "videoBitRate=2000;");
                            strInfor = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + guid + "; SoundValue=0.50; " + strInfor;
                        }
                        else
                        {
                            strInfor = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + guid + "; SoundValue=0.50; videoBitRate=2000; " + strInfor;
                        }


                    }
                    else
                    {
                        if (isCheck == false)
                        {

                            strp = getSTRP(true);
                            for (int i = 0; i < resp.NumCookies; i++)
                            {
                                strp += resp.GetCookieName(i) + "=" + resp.GetCookieValue(i) + "; ";
                            }

                            guid = Call.GetMD5String(uid.ToString());
                            guestcookie = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + "0e74abbcc485d05b6e9f99099a09405a" + "; SoundValue=0.50; ";
                            if (guest == null)
                            {
                                //if (pindex % 2 == 0)
                                //    guest = new Guest(new S5Struct(), guestcookie, id, sid, pid);
                                //else guest = new Guest(pubs5x, guestcookie, id, sid, pid);
                                //guest = new Guest(s5x, guestcookie, id, sid, pid);
                                //guest.ReLoginTimer.Change(8000, 8000);

                                if (strInfor.IndexOf("videoBitRate") != -1)
                                {
                                    strInfor = strInfor.Replace("videoBitRate=0;", "videoBitRate=2000;");
                                    strInfor = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + guid + "; SoundValue=0.50; " + strInfor;
                                }
                                else
                                {
                                    strInfor = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + guid + "; SoundValue=0.50; videoBitRate=2000; " + strInfor;
                                }


                            }
                        }
                    }
                }
                else
                {


                    if (isCheck == false)
                    {

                        string strp = getSTRP(true);


                        guid = Call.GetMD5String(uid.ToString());
                        string guestcookie = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + "0e74abbcc485d05b6e9f99099a09405a" + "; SoundValue=0.50; ";
                        if (guest == null)
                        {
                            //if (pindex % 2 == 0)
                            //    guest = new Guest(new S5Struct(), guestcookie, id, sid, pid);
                            //else guest = new Guest(pubs5x, guestcookie, id, sid, pid);
                            //guest = new Guest(s5x, guestcookie, id, sid, pid);
                            //guest.ReLoginTimer.Change(8000, 8000);

                            if (strInfor.IndexOf("videoBitRate") != -1)
                            {
                                strInfor = strInfor.Replace("videoBitRate=0;", "videoBitRate=2000;");
                                strInfor = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + guid + "; SoundValue=0.50; " + strInfor;
                            }
                            else
                            {
                                strInfor = strp + "isInLiveRoom=true; udb_passdata=3; guid=" + guid + "; SoundValue=0.50; videoBitRate=2000; " + strInfor;
                            }


                        }
                    }


                }

                http.SetRequestHeader("Cookie", strInfor);


                Call.manage.Msg(3, pindex, "LGN-5");
                if (!isCheck)
                {
                    isCheck = true;
                    //CheckUserName();
                    //Send_CheckLoginReq();

                }

                FingerPrintCheck();

                Call.manage.Msg(3, pindex, "LGN-6[CONNECT]");

                //Call.manage.Msg(4, pindex, guid);
                eop = 1;//upd 12/2

                //GetRealIPInfo();
                int ReConn = 0;
                //FingerPrintCheck();
                //while (true)
                //{


                bool isOK = false;
                try
                {
                    Call.manage.Msg(3, pindex, "LGN-6[CONNECT]ing");
                    isOK = this.ConnectTo(s5x, Call.apiHuya, 443, true, pctoken == "", true);
                    //isOK = this.ConnectTo(s5x, "cdnws.api.huya.com", 443, true, pctoken == "", true);
                }
                catch (Exception ex)
                {

                    Call.manage.Msg(4, pindex, ex.Message);
                }
                Call.manage.Msg(3, pindex, "LGN-6[CONNECT]ret");
                if (!isOK)
                {

                    ReConn++;

                    reLogin = true;
                    Call.manage.Msg(3, pindex, "LGN-6[CONNECT]ret CONNERR");
                    throw new Exception("CONN ERR.");

                }


                //Thread.Sleep(5000);

                //}

                //if (isRegister == false)
                //{

                /**/
                //Send(Wup.HexUtil.hexStr2Bytes("00031D000101D2000001D210032C3C4007560C68757961756462776562756966106879616E6F6E796D6F75734C6F67696E7D0001019E08000206095F7775705F646174611D000101700A0A0C1603312E30266D7B226173736F63696174696F6E4964223A383230332C2266756E634E616D65223A226879616E6F6E796D6F75734C6F67696E222C2267726F7570223A31362C226964223A343130372C2273657373696F6E223A323236383736332C2273746570223A312C2274797065223A337D360435303036400356423130396333343932666262633737626535306235333666366137666163393136396134313637666437643937643163636338666431616138336138353238303431390B1A062065643834356136653336343830383635663435333639653633346539633638351607332E352E342E30260036013046093132372E302E302E315601330B2A0003160F4C53444E2D3230313831303331574826143432316438343136666365373832346531313662360777696E646F7773461D4D6963726F736F66742057696E646F7773203130202C2036342D6269746604313932307604313038300B3C49000106043530303650010B0610777570756462726571756573745F76301D0000050200229E5B8C980CA80C"));
                //Recv();

                Call.manage.Msg(3, pindex, "LGN-7[CONNECTED]");


                // }
                //if (pctoken != "")
                Call.manage.Msg(3, pindex, "LGN-8");
                verifyHuyaToken();

                Random RND = new Random();


                Send(bytetool.strToToHexByte("00171D00000D08000106047465737416026132"));
                Send(bytetool.strToToHexByte("00171D000023080002060E6B6169626F5F7979656E7472793116046465663306047465737416026132"));

                //else RegisterChan(guid);
                //wsuserinfo();

                //eop = 1;
                //Send(this.genRegisterPk());
                //Recv();
                //
                LiveLaunchReq(true);

                // livingInfoReq


                if (!GetLivingInfo())
                {
                    throw new Exception("err");
                }
                Call.manage.Msg(3, pindex, "LGN-9");
                Console.WriteLine(strInfor + "\r\n------------------------------------------------");
                /*if (pindex % 8 == 0 && pindex>2)
                {
                    if (getLivingInfoRsp.tNotice.iMobileDefaultBitRate != 0)
                        flvuri = string.Format("{0}/{1}.flv?{2}&ratio={3}", streamsinfo.sFlvUrl, streamsinfo.sStreamName, streamsinfo.sFlvAntiCode, getLivingInfoRsp.tNotice.iMobileDefaultBitRate == 0 ? getLivingInfoRsp.tNotice.iWebDefaultBitRate : getLivingInfoRsp.tNotice.iMobileDefaultBitRate);
                    else
                        flvuri = string.Format("{0}/{1}.flv?{2}", streamsinfo.sFlvUrl, streamsinfo.sStreamName, streamsinfo.sFlvAntiCode);
                }
                else
                {
                    int i = pindex % 2;//0 1
                    if(i==0)
                    {
                        flvuri = string.Format("{0}/{1}.{2}?{3}", streamsinfo.sHlsUrl, streamsinfo.sStreamName, streamsinfo.sHlsUrlSuffix,streamsinfo.sHlsAntiCode);
                    }
                    else
                    {
                        flvuri = string.Format("{0}/{1}.{2}?{3}", streamsinfo.sP2pUrl, streamsinfo.sStreamName, streamsinfo.sP2pUrlSuffix, streamsinfo.sP2pAntiCode);
                    }



                }*/

                //goto loginf;


                //Send(livingPacket);


                Counts = 0;



                GetPropsList(); Call.manage.Msg(3, pindex, "LGN-9");
                if (Call.isRegisterBarrage)
                {
                    Call.manage.Msg(3, pindex, "ROOMSVC..");
                    UserId userId = new UserId();

                    userId.lUid = uid;
                    if (pctoken != "")
                    {
                        userId.sToken = pctoken;
                        userId.iTokenType = 2;
                    }
                    else userId.sCookie = strInfor;

                    userId.sGuid = guid;
                    userId.sHuYaUA = sHuYaUA;
                    Wup.UniPacket pack3 = Wup.WupHelper.MakeupPacket<UserId>(userId, "NoblePrivServer", "getNobleInfo");

                    Send(GetWebPacket(pack3.Encode())); Call.manage.Msg(3, pindex, "LGN-10");
                    /*
                          ClickSearchUserReq clickSearchUserReq = new ClickSearchUserReq();
                          clickSearchUserReq.tId = new UserId();


                          clickSearchUserReq.tId.lUid = uid;
                          if (pctoken != "")
                          {
                              clickSearchUserReq.tId.sToken = pctoken;
                              clickSearchUserReq.tId.iTokenType = 2;
                          }
                          else clickSearchUserReq.tId.sCookie = strInfor;

                          clickSearchUserReq.tId.sGuid = guid;
                          clickSearchUserReq.tId.sHuYaUA = sHuYaUA;

                          clickSearchUserReq.ltoUid = 2206327063;//1035629757 ;
                          Wup.UniPacket pack2 = Wup.WupHelper.MakeupPacket<ClickSearchUserReq>(clickSearchUserReq, "huyauserui", "clickSearchUser");

                          Send(GetWebPacket(pack2.Encode()));
                          */


                    GetUserProfileReq getUserProfileByYYReq = new GetUserProfileReq();

                    getUserProfileByYYReq.tId = new UserId();

                    getUserProfileByYYReq.tId.lUid = uid;
                    if (pctoken != "")
                    {
                        getUserProfileByYYReq.tId.sToken = pctoken;
                        getUserProfileByYYReq.tId.iTokenType = 2;
                    }
                    else getUserProfileByYYReq.tId.sCookie = strInfor;

                    getUserProfileByYYReq.tId.sGuid = guid;
                    getUserProfileByYYReq.tId.sHuYaUA = sHuYaUA;

                    if (PassWord == "x")
                        getUserProfileByYYReq.lUid = uid;// 2214812936;// 8502388;// 400945;//;8502388;
                    else getUserProfileByYYReq.lUid = uid;
                    Wup.UniPacket pack2 = Wup.WupHelper.MakeupPacket<GetUserProfileReq>(getUserProfileByYYReq, "huyauserui", "getUserProfile");

                    Send(GetWebPacket(pack2.Encode())); Call.manage.Msg(3, pindex, "LGN-11");
                    //獲取搜索意見
                    /*GetSearchSuggestionByKeywordReq clickSearchUserReq = new GetSearchSuggestionByKeywordReq();
                    clickSearchUserReq.tId = new UserId();


                    clickSearchUserReq.tId.lUid = uid;
                    if (pctoken != "")
                    {
                        clickSearchUserReq.tId.sToken = pctoken;
                        clickSearchUserReq.tId.iTokenType = 2;
                    }
                    else clickSearchUserReq.tId.sCookie = strInfor;

                    clickSearchUserReq.tId.sGuid = guid;
                    clickSearchUserReq.tId.sHuYaUA = sHuYaUA;

                    clickSearchUserReq.sKeyWord = "4AM";//1035629757 ;
                    Wup.UniPacket pack2 = Wup.WupHelper.MakeupPacket<GetSearchSuggestionByKeywordReq>(clickSearchUserReq, "wupui", "getSearchSuggestionByKeyword");

                    Send(GetWebPacket(pack2.Encode()));*/
                    /*MobileSearchByKeywordReq clickSearchUserReq2 = new MobileSearchByKeywordReq();
                    clickSearchUserReq2.tId = new UserId();


                    clickSearchUserReq2.tId.lUid = uid;
                    if (pctoken != "")
                    {
                        clickSearchUserReq2.tId.sToken = pctoken;
                        clickSearchUserReq2.tId.iTokenType = 2;
                    }
                    else clickSearchUserReq2.tId.sCookie = strInfor;

                    clickSearchUserReq2.tId.sGuid = guid;
                    clickSearchUserReq2.tId.sHuYaUA = sHuYaUA;

                    clickSearchUserReq2.sKeyWord = "2206640006";//2206640006// "2214812936";//1035629757 ;
                    pack2 = Wup.WupHelper.MakeupPacket<MobileSearchByKeywordReq>(clickSearchUserReq2, "mobileui", "mobileSearchByKeyword");

                    Send(GetWebPacket(pack2.Encode()));*/
                    //-------------------------------------------
                    wsuserinfo();//注册
                    Call.manage.Msg(3, pindex, "LGN-12");

                    huyanetsvc::HUYA.WSRegisterGroupReq registerGroup = new huyanetsvc::HUYA.WSRegisterGroupReq();
                    registerGroup.vGroupId = new List<string>();
                    registerGroup.vGroupId.Add("live:" + pid);
                    registerGroup.vGroupId.Add("chat:" + pid);

                    byte[] array = null;
                    this.WSPacketEncode<huyanetsvc::HUYA.WSRegisterGroupReq>(registerGroup, EWebSocketCommandType.EWSCmdC2S_RegisterGroupReq, out array);

                    Send(array);
                    Call.manage.Msg(3, pindex, "LGN-13");

                    UserChannelReq userChannelReq = new UserChannelReq();
                    userChannelReq.tId = new UserId();



                    userChannelReq.tId.lUid = uid;
                    if (pctoken != "")
                    {
                        userChannelReq.tId.sToken = pctoken;
                        userChannelReq.tId.iTokenType = 2;
                    }
                    else userChannelReq.tId.sCookie = strInfor;

                    userChannelReq.tId.sGuid = guid;
                    userChannelReq.tId.sHuYaUA = sHuYaUA;

                    userChannelReq.lTid = id;
                    userChannelReq.lSid = sid;

                    Wup.UniPacket pack = Wup.WupHelper.MakeupPacket<UserChannelReq>(userChannelReq, "liveui", "userIn");
                    Send(GetWebPacket(pack.Encode()));

                    Call.manage.Msg(3, pindex, "LGN-14");
                    EnterChannelReq enterChannelReq = new EnterChannelReq();
                    enterChannelReq.tId = new UserId();



                    enterChannelReq.tId.lUid = uid;
                    if (pctoken != "")
                    {
                        enterChannelReq.tId.sToken = pctoken;
                        enterChannelReq.tId.iTokenType = 2;
                    }
                    else enterChannelReq.tId.sCookie = strInfor;

                    enterChannelReq.tId.sGuid = guid;
                    enterChannelReq.tId.sHuYaUA = sHuYaUA;

                    enterChannelReq.lTid = id;
                    enterChannelReq.lSid = sid;

                    pack = Wup.WupHelper.MakeupPacket<EnterChannelReq>(enterChannelReq, "ActivityUIServer", "OnClientReady");
                    Send(GetWebPacket(pack.Encode()));
                    Call.manage.Msg(3, pindex, "LGN-15");
                }


                GetUserBoxbean();

                limitre = 99999;// RND.Next(4800, 7200);
                Counts = 0;

                hbcounter = 0;
                reLogin = false;
                lgnOK = true;


                //SendEnterChannel(true);


                //SendRoomEnterLog();
                Call.manage.Msg(3, pindex, "LGN-OKAY");
                //isShutdown = true;



                SendUe();
                SendWSHeart();
                this.HBevent.Change(8000, 10000);


                LastingHeartTimer.Change(15000, 15000);
                if (!isFirstLogin)
                {
                    //ReqSubscribe();

                    isFirstLogin = true;
                    //Call.AddDaochu(strInfor);
                }

                //ReqSubscribe();
                this.http.RemoveRequestHeader("Cookie");



                return true;


            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.StackTrace);
                ////Console.WriteLine(ex.ToString());
                Call.manage.Msg(3, pindex, "ReLogon...");
                Call.manage.Msg(4, pindex, ex.ToString());
                isShutdown = false;
                reLogin = true;
            }
            finally
            {


                if (!isShutdown)
                {
                    if (reLogin)
                    {


                        Random r = new Random();
                        int newr = r.Next(5000, 10000);
                        Call.manage.Msg(3, pindex, "[重新登录2 ," + newr.ToString() + "ms]");
                        //Call.AddLoginTaskT(pindex);
                        ReLoginTimer.Change(newr, newr);

                    }
                    else
                    {
                        if (!lgnOK)
                        {
                            Random r = new Random();
                            int newr = r.Next(10000, 15000);
                            ReLoginTimer.Change(newr, newr);
                        }


                    }
                }
            }
            return false;
        }
        private void SendEnterChannel(bool closeAllConn = false)
        {
            if (closeAllConn)
            {
                try
                {
                    //http.CloseAllConnections();
                }
                catch
                {

                }
            }
            SendAllInitLog();
        }

        void getCdnInfo()
        {
            huyawatchframe::HUYA.GetCdnTokenReq getCdnTokenReq = new huyawatchframe::HUYA.GetCdnTokenReq();

            getCdnTokenReq.stream_name = playingOut.StreamInfo.sStreamName;
            getCdnTokenReq.cdn_type = playingOut.StreamInfo.sCdnType;




            Call.manage.Msg(3, pindex, "TOKEN..");
            //Call.manage.Msg(3, pindex, "获取CDN.");
            UniPacket packue = WupHelper.MakeupPacket<huyawatchframe::HUYA.GetCdnTokenReq>(getCdnTokenReq, "liveui", "getCdnTokenInfo");
            livingPacket = GetWebPacket(packue.Encode());

        }
        public bool GetLivingInfo()
        {
            msgReady = false;
            huyawatchframe::HUYA.GetLivingInfoReq getLivingInfoReq = new huyawatchframe::HUYA.GetLivingInfoReq();


            getLivingInfoReq.tId = new huyawatchframe::HUYA.UserId();
            getLivingInfoReq.tId.lUid = this.uid;

            if (pctoken != "")
            {
                getLivingInfoReq.tId.sToken = this.pctoken;
                getLivingInfoReq.tId.iTokenType = this.tokentype;
            }
            else getLivingInfoReq.tId.sCookie = this.strInfor;
            getLivingInfoReq.tId.sHuYaUA = sHuYaUA;
            getLivingInfoReq.tId.sGuid = guid;
            getLivingInfoReq.lTopSid = id;
            getLivingInfoReq.lSubSid = sid;
            getLivingInfoReq.lPresenterUid = pid;

            getLivingInfoReq.tId.iTokenType = tokentype;


            UniPacket packue = WupHelper.MakeupPacket<huyawatchframe::HUYA.GetLivingInfoReq>(getLivingInfoReq, "liveui", "getLivingInfo");
            //packue.setVersion(3);

            byte[] pk_ = packue.Encode();

            livingPacket = GetWebPacket(pk_);
            Send(livingPacket);

            return true;
        }

        void SendUe(bool post = false)
        {
            huyawatchframe::HUYA.UserEventReq userEventReq = new huyawatchframe::HUYA.UserEventReq();

            userEventReq.tId = new huyawatchframe::HUYA.UserId();
            userEventReq.tId.lUid = this.uid;
            if (pctoken != "")
            {
                userEventReq.tId.sToken = pctoken;
                userEventReq.tId.iTokenType = tokentype;
            }
            else userEventReq.tId.sCookie = this.strInfor;
            userEventReq.tId.sHuYaUA = sHuYaUA;
            userEventReq.tId.sGuid = guid;

            // userEventReq.eSource = 3;
            //userEventReq.eTemplateType = 1;
            //userEventReq.sChan = "";
            //userEventReq.sTraceSource = "";
            //this.loginProxy.FillUserId(userEventReq.tId);
            userEventReq.lTid = id;
            userEventReq.lSid = sid;
            userEventReq.lPid = pid;//presenter
            userEventReq.eOp = eop;// (tafRegister.bRegister ? 1 : 2);
            huyaproto::Wup.UniPacket packue = WupHelper.MakeupPacket<huyawatchframe::HUYA.UserEventReq>(userEventReq, "onlineui", "OnUserEvent");
            if (post)
            {
                PostData(packue.Encode());
            }
            else
            {
                byte[] sss = GetWebPacket(packue.Encode());
                Send(sss);
            }
            if (sessionid == "")
                sessionid = Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
            http.QuickGetStr("http://ylog.huya.com/d.gif?act=/event&pro=huya_pc&dty=live&rid=ods_action_log&mid=" + small + "&iver=3.5.4.0&uver=3.5.4.0&yyuid=" + uid + "&cha=yy&rso=huyatemplate_new&rid=ods_action_log&eid=startup&session_id=" + sessionid + "&ati=" + DateTime.Now.ToString("yyyyMMddHHmmss"));

            return;
        }
        string sessionid = "";
        public void ReqSubscribe()
        {


            huyawatchframeinformationview::HUYA.ModRelationReq modRelationReq = new huyawatchframeinformationview::HUYA.ModRelationReq();
            modRelationReq.tId = new huyawatchframeinformationview::HUYA.UserId();
            modRelationReq.tId.lUid = this.uid;
            if (pctoken != "")
            {
                modRelationReq.tId.sToken = pctoken;
                modRelationReq.tId.iTokenType = tokentype;
            }
            else modRelationReq.tId.sCookie = this.strInfor;
            modRelationReq.tId.sHuYaUA = sHuYaUA;
            modRelationReq.tId.sGuid = guid;

            modRelationReq.lUid = this.pid;
            modRelationReq.iOp = 1;
            UniPacket pack = WupHelper.MakeupPacket<huyawatchframeinformationview::HUYA.ModRelationReq>(modRelationReq, "huyauserui", "addSubscribe");
            Send(GetWebPacket(pack.Encode()));
            //PostData(pack.Encode(), 1);

        }
        void SendWSHeart(bool bWatchVideo = true, bool post = false)
        {
            huyanetsvc::HUYA.UserHeartBeatReq userHeartBeatReq = new huyanetsvc::HUYA.UserHeartBeatReq();
            userHeartBeatReq.tId = new huyanetsvc::HUYA.UserId();
            userHeartBeatReq.tId.lUid = this.uid;
            if (pctoken != "")
            {
                userHeartBeatReq.tId.sToken = pctoken;
                userHeartBeatReq.tId.iTokenType = tokentype;
            }
            else userHeartBeatReq.tId.sCookie = this.strInfor;
            userHeartBeatReq.tId.sHuYaUA = sHuYaUA;
            userHeartBeatReq.tId.sGuid = guid;
            // userHeartBeatReq.bWatchVideo = Call.isWatch;

            userHeartBeatReq.lTid = id;
            userHeartBeatReq.lSid = sid;
            userHeartBeatReq.lShortTid = shortID;
            userHeartBeatReq.lPid = pid;
            //time += 10;
            /*if (time >= 999999999)
            {
                time = 10;
            }*/
            UniPacket pack = WupHelper.MakeupPacket<huyanetsvc::HUYA.UserHeartBeatReq>(userHeartBeatReq, "onlineui", "OnUserHeartBeat");
            if (post)
            {
                PostData(pack.Encode(), 1);
                if (sessionid == "")
                    sessionid = Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
                if (Call.isOpenLog)
                {
                    http.QuickGetStr("http://ylog.huya.com/d.gif?act=/event&pro=huya_pc&dty=live&rid=ods_action_log&mid=" + small + "&iver=3.5.4.0&uver=3.5.4.0&yyuid=" + uid + "&cha=yy&rso=huyatemplate_new&rid=ods_action_log&eid=heartbeat&cid=" + id + "/" + sid + "&ayyuid=" + pid + "&game_id=" + gameid + "&video_line=AL&video_definition=%E6%B5%81%E7%95%85&video_encode=H264&session_id=" + sessionid + "&ati=" + DateTime.Now.ToString("yyyyMMddHHmmss") + "&oexp=kaibo_yyentry1.def3,test.a2&sguid=" + guid);
                    http.QuickGetStr("http://ylog.hiido.com/c.gif?act=/event&pro=huya_pcexe&dty=live&mid=" + small + "&iver=3.5.4.0&uver=3.5.4.0&yyuid=" + uid + "&cha=huya&rso=desktop&eid=heartbeat&game_id=" + gameid + "&ayyuid=" + pid + "&cid=" + id + " / " + sid + "&session_id=" + sessionid + "&ati=" + DateTime.Now.ToString("yyyyMMddHHmmss") + "&oexp=test.a2,test2.a1&sguid=" + guid);
                }
                return;


            }
            else
            {
                Send(GetWebPacket(pack.Encode()));
                //http.QuickGetStr("http://ylog.huya.com/d.gif?act=/event&pro=huya_pc&dty=live&rid=ods_action_log&mid=" + small + "&iver=3.5.5.2&uver=3.5.5.2&yyuid=" + pid + "&cha=yy&rso=huyatemplate_new&rid=ods_action_log&eid=hearbeat&duration=959991&sguid=" + guid + "&is_huya_template=1&product=huya_pcanchor&mid=" + small + "&oexp=test.a2,test2.a1&sguid=" + guid);
                //Call.log.Debug("UserHeartBeatRsp(" + uhbr.iRet + "):" + Encoding.UTF8.GetString(rets) + "\n");
            }


            return;

            //return 0;

        }
        string small = Guid.NewGuid().ToString().Replace("-", "").ToLower();
        string big = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        string mid = Guid.NewGuid().ToString();
        string getSTRP(bool isWithUid)
        {
            string rid = new Random().Next(10000000, 81533097) + "49786815";
            long ts = Call.GetTimeStampTen();
            string strp = "Hm_lvt_51700b6c722f5bb4cf39906a596ea41f=" + ts + "; Hm_lpvt_51700b6c722f5bb4cf39906a596ea41f=" + ts + new Random().Next(10, 13) + "; __yasmid=0." + rid + "; __yamid_tt1=0." + rid + "; __yamid_new=" + big + "; _yasids=__rootsid%3D" + big + "; " +
                "udb_passdata=3; udb_guiddata=" + small + "; ";
            if (isWithUid)
                strp += "__yaoldyyuid=" + this.uid + "; ";
            strp += "UM_distinctid=" + mid + "; ";//需要动态化的参数？？
            return strp;
        }
        void RegisterChan(string guid)
        {



        }
        Chilkat.Task VTask = null;
        public void Shutdown()
        {
            Call.manage.Msg(3, pindex, "账号下线");
            isShutdown = true;
            try
            {
                HBevent.Change(-1, -1);

                ReLoginTimer.Change(-1, -1);
                ShutdownConnection();

            }
            catch { }
        }

        public void CloseVideo()
        {

            try
            {

            }
            catch
            {

            }
            connected = false;

        }
        bool is403 = false;
        private void VideoEvent(object o)
        {
            VideoPing();
        }
        int JCS = 0;
        void VideoPing()
        {

        }
        byte[] vgp = { };
        void SendVGWP()
        {


            //Call.log.Debug("VideoGateWayPong:" + Encoding.UTF8.GetString(recv) + "\n");
        }
        int Num = 0;
        int passworderrnum = 0;
        public bool LoginHuya(string user, string password)
        {

            int retry = 0;
            bool err = true;


            //PassWord = "x";
            //small = Guid.NewGuid().ToString().Replace("-", "").ToLower();

            if (PassWord != "22")
            {
                try
                {

                    //err = true;
                    //realuid = uid =  long.Parse(UserName);

                    if (realuid != 0)
                        return true;
                    http.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_2 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/7.0.4(0x17000428) NetType/WIFI Language/zh_HK";
                reGet:
                    GetUserProfileByYYReq getUserProfileByYYReq = new GetUserProfileByYYReq();

                    getUserProfileByYYReq.tId = new UserId();

                    getUserProfileByYYReq.tId.lUid = uid;
                    if (pctoken != "")
                    {
                        getUserProfileByYYReq.tId.sToken = pctoken;
                        getUserProfileByYYReq.tId.iTokenType = 2;
                    }
                    else getUserProfileByYYReq.tId.sCookie = strInfor;

                    getUserProfileByYYReq.tId.sGuid = guid;
                    getUserProfileByYYReq.tId.sHuYaUA = sHuYaUA;

                    getUserProfileByYYReq.lUid = long.Parse(user);// 2214812936;// 8502388;// 400945;//;8502388;

                    Wup.UniPacket pack2 = Wup.WupHelper.MakeupPacket<GetUserProfileByYYReq>(getUserProfileByYYReq, "huyauserui", "getUserProfileByYY");


                    byte[] res = PostData(pack2.Encode());
                    if (res == null || res.Length <= 0)
                    {

                        uid = 0;
                        //string lgnText = http.QuickGetStr("https://find.yy.com/friend/name/0/0?callback=nickCallback&name=" + user + "&_=1559887131532");
                        //realuid = uid = long.Parse(Call.StrcenterOf(lgnText, "uid\":", ","));
                    }
                    else
                    {
                        Wup.UniPacket uniPacket2 = new Wup.UniPacket();
                        uniPacket2.Decode(res);
                        GetUserProfileRsp getUserProfileRsp = uniPacket2.Get<GetUserProfileRsp>("tRsp");

                        realuid = uid = getUserProfileRsp.tUserProfile.tUserBase.lUid;
                    }
                    if (uid == 0)
                    {
                        Thread.Sleep(100);
                        retry++;
                        if (retry < 5)
                            goto reGet;
   
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }


            }





            Num++;
            return true;
        }
        private void WSPacketEncode<T>(T packet, EWebSocketCommandType type, out byte[] data)
        {
            try
            {
                MethodInfo method = typeof(T).GetMethod("WriteTo");
                huyaproto::Wup.Jce.JceOutputStream jceOutputStream = new huyaproto::Wup.Jce.JceOutputStream();
                if (method != null)
                {
                    method.Invoke(packet, new object[]
                    {
                        jceOutputStream
                    });
                }

                huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
                webSocketCommand.iCmdType = (int)type;
                webSocketCommand.vData = new List<byte>(jceOutputStream.toByteArray());
                huyaproto::Wup.Jce.JceOutputStream jceOutputStream2 = new huyaproto::Wup.Jce.JceOutputStream();
                webSocketCommand.WriteTo(jceOutputStream2);
                data = jceOutputStream2.toByteArray();
            }
            catch
            {
                data = null;
            }
        }
        private void HB(object o)
        {
            HBevent.Change(-1, -1);
            bool reLogin = false;
            try
            {

                Counts++;
                allCount++;
                try
                {
                    if (wsIsConnect == false || lastheartTime.AddMinutes(1) < DateTime.Now)
                        throw new Exception("掉线");

                    DateTime begin = DateTime.Now;

                    if (Counts % 10 == 0)
                    {
                        SendUe();

                    }
                    else
                    {


                        //SendUe(true);
                        SendWSHeart(true, false);
                        huyawatchfamemsgv.HUYA.SendMessageReq messageReq = new huyawatchfamemsgv.HUYA.SendMessageReq();
                        messageReq.tUserId = new huyawatchfamemsgv.HUYA.UserId();
                        if (pctoken != "")
                        {
                            messageReq.tUserId.iTokenType = 2;
                            messageReq.tUserId.sToken = pctoken;
                        }
                        else
                        {
                            messageReq.tUserId.sCookie = strInfor;
                        }
                        messageReq.tUserId.lUid = realuid;
                        messageReq.tUserId.sGuid = guid;
                        messageReq.tUserId.sHuYaUA = sHuYaUA;
                        messageReq.lTid = this.id;
                        messageReq.lSid = this.sid;
                        messageReq.lPid = this.pid;
                        Random rnd = new Random();
                        int p = rnd.Next(1, 7);
                        messageReq.sContent = Call.GenerateChineseWords(p);


                        huyaproto::Wup.UniPacket pack = huyaproto::Wup.WupHelper.MakeupPacket<huyawatchfamemsgv.HUYA.SendMessageReq>(messageReq, "liveui", "sendMessage");
                        if (Call.isTrySpoken)
                            Send(GetWebPacket(pack.Encode()));
                        //Send(getsmspk());
                        //SendRoomEnterLog();
                        //vsdkViewer20Sec();

                    }


                    begin = DateTime.Now;


                    //}
                    if (Counts > 3 && Call.isOpenVideo)
                    {
                        SendVideoHeart();
                    }

                    //if (isConnectErr)
                    //{

                    if ((isConnected == false || connectVErr == true) && msgReady)
                    {
                        Call.manage.Msg(4, pindex, "重新获取视频信息 " + jiciConn + "次");
                        isConnected = true;
                        GetLivingInfo();
                    }



                    //}
                }
                catch (Exception ex)
                {
                    Call.manage.Msg(3, pindex, "账号掉线 " + DateTime.Now.ToString());

                    throw new Exception("ERR");
                }

                if (jiciConn > 6)
                {


                    throw new Exception("err");
                }
                if (Counts == limitre)
                {
                    throw new Exception("needRe.");
                }
                Call.manage.Msg(3, pindex, "已心跳 " + Counts);
                reLogin = false;


            }
            catch (Exception ex)
            {

                /*isAdding = false;
                strInfor = oldCookie;
                guid = sguid = "";
                isCheck = false;*/
                isShutdown = false;
                reLogin = true;

            }//WS PK REMINDER
            finally
            {

                if (reLogin && !isShutdown)
                {

                    isAdding = false;
                    strInfor = oldCookie;

                    //if (isNeedLiveLaunchj)
                    guid = sguid = "";
                    isCheck = false;
                    if (Call.twiceLoginAccount.Count > 0)
                    {
                        try
                        {
                            string[] arrs = Call.twiceLoginAccount[pindex].Split(new string[] { "----" }, StringSplitOptions.None);
                            UserName = arrs[0];
                            PassWord = arrs[1];
                            Call.manage.Msg(1, pindex, UserName);
                        }
                        catch
                        {

                        }
                    }
                    //reLogin = true;
                    //isCheck = false;
                    //strInfor = oldCookie;
                    //isRegister = false;
                    allCount = 0;
                    Counts = 0;

                    //Call.manage.Msg(3, This, "[" + DateTime.Now.ToString() + "," + "re x" + Counts.ToString() + "]");

                    try
                    {
                        HBevent.Change(-1, -1);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SocketTimer.Change(-1, -1);
                    }
                    catch
                    {

                    }
                    try
                    {
                        LastingHeartTimer.Change(-1, -1);
                        //http.CloseAllConnections();
                    }
                    catch
                    {

                    }
                    /*try
                    {
                        ws.Dispose();
                    }
                    catch
                    {

                    }
                    try
                    {
                        socket.Dispose();
                    }
                    catch
                    {

                    }
                    try
                    {
                        rest.Dispose();
                    }
                    catch
                    {

                    }*/
                    Random random = new Random();
                    time = random.Next(5000, 15000);
                    ReLoginTimer.Change(time, time);

                    //ReLgn(null);

                    Call.manage.Msg(3, pindex, "(HB)准备重新登录 " + time);
                }
                else
                {
                    HBevent.Change(hbinterval, hbinterval);
                    lastheartTime = DateTime.Now;
                }
            }


        }

        private void SendVideoHeart()
        {
            try
            {
                string res = httpex.QuickGetStr("http://" + Call.imHost + ":" + Call.usePort + "/?GetStatus|" + pindex);
                if (res == "true")
                {
                    Call.manage.Msg(4, pindex, "视频心跳:正常 " + DateTime.Now.ToString());
                }
                else
                {
                    Call.manage.Msg(4, pindex, "视频心跳:异常 " + DateTime.Now.ToString());
                    isConnected = false;
                    connectVErr = true;

                }
            }
            catch
            {

            }

        }

        int hbinterval = 10000;
        int hbinterval2 = 30000;
        string liveId = "";
        int gameid = 1;//2793 绝地求生 1 星秀
        int videoLine = 1;
        private bool isAdding;

        void SendWXHeart()
        {
            Send(new byte[] { 0, 8, 29, 0, 0, 2, 0, 2 });
            Send(new byte[] { 0, 20, 29, 0, 12 });
        }
        void PingServer()
        {


        }
        void ShutdownConnection()
        {
            if (ws != null)
            {
                try
                {
                    ws.Close();
                }
                catch
                {

                }
            }
            if (http != null)
            {
                try
                {
                    //http.CloseAllConnections();
                }
                catch
                {

                }
            }
            if (httpex != null)
            {
                try
                {
                    //httpex.CloseAllConnections();
                }
                catch
                {

                }
            }

            reLogin = true;
            isCheck = false;
            strInfor = oldCookie;

            Counts = 0;
        }
        public void tryAntiCdn()
        {
            GetCdnMsg(playingOut.StreamInfo);
        }
        private void GetCdnMsgEx(huyawatchframe::HUYA.StreamInfo streamsinfo)
        {



        }

        public void SendAllInitLog()
        {
            try
            {
                SendHuyaInit();
                SendLoginStatusLog();
                SendHomePathLog();



                //SendUe();//进入房间



                SendRoomEnterLog();
                SendRoomInitUI();
                metrichy();

            }
            catch
            {

            }
        }
        void SendHuyaInit()//1=
        {

            string vid = sguid.ToUpper();
            string log = "http://ylog.huya.com/d.gif?mid=" + vid + "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&eid=startup&atime=" + DateTime.Now.ToString();
            Chilkat.HttpResponse resp = http.QuickGetObj(log);


            log = "http://ylog.huya.com/d.gif?mid=" + vid + "&session_id =" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&eid=pageview%2Fhome&atime=" + DateTime.Now.ToString();
            resp = http.QuickGetObj(log);



        }
        void SendLoginStatusLog()
        {

            string vid = sguid.ToUpper();
            string log = "http://ylog.huya.com/d.gif?mid=" + vid + "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid=" + uid + "&eid=status%2FcredLogin&label=%E5%BE%AE%E4%BF%A1&prop=%7B%22result%22%3A%22%E6%88%90%E5%8A%9F%22%7D&eid_desc=%E7%BB%AD%E7%99%BB%E5%BD%95&atime=" + DateTime.Now.ToString();
            Chilkat.HttpResponse resp = http.QuickGetObj(log);

            log = "http://ylog.huya.com/d.gif?mid=" + vid + "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid=" + uid + "&eid=status%2Flogged&eid_desc=%E7%8A%B6%E6%80%81%2F%E5%B7%B2%E7%99%BB%E5%BD%95&label=%E5%BE%AE%E4%BF%A1%E5%8F%B7&atime=" + DateTime.Now.ToString();
            resp = http.QuickGetObj(log);

        }
        void SendHomePathLog()
        {

            string vid = sguid.ToUpper();
            string log = "http://ylog.huya.com/d.gif?mid=" + vid + "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid=" + uid + "&eid=pageview%2Fapp&eid_desc=%E5%BA%94%E7%94%A8%E5%90%AF%E5%8A%A8&rso_desc=%E5%BA%94%E7%94%A8%E5%90%AF%E5%8A%A8%E6%9D%A5%E6%BA%90%E5%9C%BA%E6%99%AF%E5%80%BC&prop=%7B%22path%22%3A%22pages%2Fmain%2Flive%2Findex%22%2C%22query%22%3A%7B%7D%2C%22rso%22%3A1089%7D&atime=" + DateTime.Now.ToString();
            Chilkat.HttpResponse resp = http.QuickGetObj(log);

        }

        Chilkat.Task tasker;
        private byte[] livingPacket;
        private DateTime lastheartTime;

        void vsdkViewer20Sec()
        {
            string vid = sguid.ToUpper();
            string log = "http://dlog.hiido.com/c.gif?act=vsdkviewer20sec";
            tasker = http.QuickGetAsync(log);
            tasker.Run();
        }
        void SendRoomEnterLog()
        {

            string vid = sguid.ToUpper();
            string log = "http://ylog.huya.com/d.gif?mid=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid=" + uid + "&session_id=" + vid + "&eid=startup&ayyuid=" + pid + "&game_id=" + gameid + "&liveId=" + liveId + "&cid=" + id + "&sid=" + sid + "&video_line=" + videoLine + "&atime=" + DateTime.Now.ToString();
            http.QuickGetObj(log);

            log = "http://dlog.hiido.com/c.gif?act=vsdkviewer20sec";
            http.QuickGetObj(log);

        }

        void SendRoomInitUI()
        {
            string vid = sguid.ToUpper();
            string[] urls = {
                "http://ylog.huya.com/d.gif?mid=" + vid+ "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid="+uid+"&eid=pageview%2Flive&label=index&prop=%7B%22anchorUid%22%3A%22"+pid+"%22%2C%22is_live%22%3A1%2C%22screenDirection%22%3A%22%E7%AB%96%E5%B1%8F%22%7D&ayyuid="+pid+"&game_id="+gameid+"&liveId="+liveId+"&cid="+id+"&sid="+sid+"&video_line="+videoLine+"&atime="+DateTime.Now.ToString(),

                "http://ylog.huya.com/d.gif?mid=" + vid+ "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid="+uid+"&eid=pageview%2Flive%2Fnot_broadcast&label=%E5%85%B3%E9%97%AD&eid_desc=%E5%B1%95%E7%A4%BA%2F%E7%9B%B4%E6%92%AD%E9%97%B4%2F%E6%9C%AA%E5%BC%80%E6%92%AD%2F%E5%BC%80%E6%92%AD%E6%8F%90%E9%86%92%E7%8A%B6%E6%80%81&prop=%7B%22screenDirection%22%3A%22%E7%AB%96%E5%B1%8F%22%7D&ayyuid="+pid+"&game_id="+gameid+"&liveId="+liveId+"&cid="+id+"&sid="+sid+"&video_line="+videoLine+"&atime="+DateTime.Now.ToString(),

                   "http://ylog.huya.com/d.gif?mid=" + vid+ "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid="+uid+"&eid=status%2Flive%2Fremind&label=%E5%85%B3%E9%97%AD&eid_desc=%E7%8A%B6%E6%80%81%2F%E7%9B%B4%E6%92%AD%E9%97%B4%2F%E5%BC%80%E6%92%AD%E6%8F%90%E9%86%92&prop=%7B%22screenDirection%22%3A%22%E7%AB%96%E5%B1%8F%22%7D&ayyuid="+pid+"&game_id="+gameid+"&liveId="+liveId+"&cid="+id+"&sid="+sid+"&video_line="+videoLine+"&atime="+DateTime.Now.ToString(),


                           "http://ylog.huya.com/d.gif?mid=" + vid+ "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid="+uid+"&eid=pageview%2Fscreenstatus&prop=%7B%22screenDirection%22%3A%22%E7%AB%96%E5%B1%8F%22%2C%22is_live%22%3A1%7D&ayyuid="+pid+"&game_id="+gameid+"&liveId="+liveId+"&cid="+id+"&sid="+sid+"&video_line="+videoLine+"&atime="+DateTime.Now.ToString(),//hb

                            "http://ylog.huya.com/d.gif?mid=" + vid+ "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid="+uid+"&eid=status%2Flive%2Fcurrent_definition&label=%E8%B6%85%E6%B8%85&eid_desc=%E7%8A%B6%E6%80%81%2F%E7%9B%B4%E6%92%AD%E9%97%B4%2F%E5%BD%93%E5%89%8D%E6%92%AD%E6%94%BE%E6%B8%85%E6%99%B0%E5%BA%A6&prop=%7B%22screenDirection%22%3A%22%E7%AB%96%E5%B1%8F%22%7D&ayyuid="+pid+"&game_id="+gameid+"&liveId="+liveId+"&cid="+id+"&sid="+sid+"&video_line="+videoLine+"&atime="+DateTime.Now.ToString(),

                                     "http://ylog.huya.com/d.gif?mid=" + vid+ "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid="+uid+"&eid=status%2Flive%2Fcurrent_line&label=%E7%BA%BF%E8%B7%AF"+videoLine+"&eid_desc=%E7%8A%B6%E6%80%81%2F%E7%9B%B4%E6%92%AD%E9%97%B4%2F%E5%BD%93%E5%89%8D%E6%92%AD%E6%94%BE%E7%BA%BF%E8%B7%AF&prop=%7B%22screenDirection%22%3A%22%E7%AB%96%E5%B1%8F%22%7D&ayyuid="+pid+"&game_id="+gameid+"&liveId="+liveId+"&cid="+id+"&sid="+sid+"&video_line="+videoLine+"&atime="+DateTime.Now.ToString(),

                                                        "http://ylog.huya.com/d.gif?mid=" + vid+ "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid="+uid+"&eid=click%2Fhome%2Frecommend%2Fgame&label=0-0&eid_desc=%E7%82%B9%E5%87%BB%2F%E9%A6%96%E9%A1%B5%2F%E6%8E%A8%E8%8D%90%2F%E5%93%81%E7%B1%BB&atime="+DateTime.Now.ToString()
        };




            string log = "";

            for (int i = 0; i < urls.Length; i++)
            {

                log = urls[i];
                Chilkat.HttpResponse resp = http.QuickGetObj(log);

            }

        }

        void SendHeartLog()
        {
            try
            {


                string vid = sguid.ToUpper();
                string log = "http://ylog.huya.com/d.gif?mid=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid=" + uid + "&session_id=" + vid + "&eid=heartbeat&ayyuid=" + pid + "&game_id=" + gameid + "&liveId=" + liveId + "&cid=" + id + "&sid=" + sid + "&video_line=" + videoLine + "&atime=" + DateTime.Now.ToString();
                http.QuickGetObj(log);


                log = "http://ylog.huya.com/d.gif?mid=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid=" + uid + "&session_id=" + vid + "&eid=heartbeat&dur=" + 60000 * Counts + "&atime=" + DateTime.Now.ToString();
                http.QuickGetObj(log);
                vsdkViewer20Sec();


            }
            catch
            {

            }
        }
        void SendHeartLogHalfTime()
        {
            try
            {


                string vid = sguid.ToUpper();
                string log = "http://ylog.huya.com/d.gif?mid=" + vid + "&session_id=" + vid + "&sdk_ver=xcx_0.0.1&rid=ods_action_log&act=hyevent&platform=xcx&dty=live&lla=zh_CN&os=iOS%2012.1&sre=2436.1125&machine=iPhone%20X%20(GSM%2BCDMA)%3CiPhone10%2C3%3E&pro=huya_applet&rso=1089&yyuid=" + uid + "&eid=pageview%2Fscreenstatus&prop=%7B%22screenDirection%22%3A%22%E7%AB%96%E5%B1%8F%22%2C%22is_live%22%3A1%7D&ayyuid=" + pid + "&game_id=" + gameid + "&liveId=" + liveId + "&cid=" + id + "&sid=" + sid + "&video_line=" + videoLine + "&atime=" + DateTime.Now.ToString();
                http.QuickGetObj(log);

            }
            catch
            {

            }

        }

        byte[] gendoLauncht()
        {
            int alllen = 151 + strInfor.Length;
            byte[] myID = Call.getRES(uid);
            byte[] myChid = Call.getRES(id);
            byte[] myChsid = Call.getRES(sid);

            byte[] lenOf1 = Call.getRES((short)(alllen));
            byte[] lenOf2 = Call.getRES((short)(alllen - 37));
            byte[] lenOf3 = Call.getRES((short)(alllen - 51));
            byte[] lenOfcookies = Call.getRES((short)(strInfor.Length));

            byte[] normalPacket = { 0, 0, lenOf1[0], lenOf1[1], 16, 3, 44, 60, 76, 86, 6, 108, 105, 118, 101, 117, 105, 102, 8, 100, 111, 76, 97, 117, 110, 99, 104, 125, 0, 1, lenOf2[0], lenOf2[1], 8, 0, 1, 6, 4, 116, 82, 101, 113, 29, 0, 1, lenOf3[0], lenOf3[1], 10, 10, 3, 0, 0, 0, 0, myID[0], myID[1], myID[2], myID[3], 22, 32, 48, 101, 55, 52, 97, 98, 98, 57, 97, 50, 100, 100, 56, 55, 53, 97, 49, 52, 54, 99, 55, 54, 102, 57, 55, 55, 102, 57, 52, 49, 98, 53, 38, 0, 54, 26, 119, 101, 98, 104, 53, 38, 49, 56, 48, 51, 50, 54, 49, 54, 48, 54, 38, 119, 101, 98, 115, 111, 99, 107, 101, 116, 71, 0, 0 };
            byte[] normal2 = lenOfcookies;
            byte[] normal3 = Encoding.UTF8.GetBytes(strInfor);
            byte[] normalEnding = { 92, 11, 26, 0, 3, 28, 42, 22, 0, 38, 0, 54, 0, 70, 0, 11, 11, 32, 1, 11, 140, 152, 12, 168, 12 };

            MemoryStream ms = new MemoryStream();
            ms.Write(normalPacket, 0, normalPacket.Length);
            ms.Write(normal2, 0, normal2.Length);
            ms.Write(normal3, 0, normal3.Length);
            ms.Write(normalEnding, 0, normalEnding.Length);
            byte[] demo = ms.ToArray();
            string v = Convert.ToBase64String(demo);
            return demo;
        }

        byte[] genLivingInfot()
        {
            int alllen = 168 + strInfor.Length;
            byte[] myID = Call.getRES(uid);
            byte[] myChid = Call.getRES(id);
            byte[] myChsid = Call.getRES(sid);

            byte[] lenOf1 = Call.getRES((short)(alllen - 8));
            byte[] lenOf2 = Call.getRES((short)(alllen - 50));
            byte[] lenOf3 = Call.getRES((short)(alllen - 64));
            byte[] lenOfcookies = Call.getRES((short)(strInfor.Length));

            byte[] normalPacket = { 0, 3, 29, 0, 1, lenOf1[0], lenOf1[1], 0, 0, lenOf1[0], lenOf1[1], 16, 3, 44, 60, 76, 86, 6, 108, 105, 118, 101, 117, 105, 102, 13, 103, 101, 116, 76, 105, 118, 105, 110, 103, 73, 110, 102, 111, 125, 0, 1, lenOf2[0], lenOf2[1], 8, 0, 1, 6, 4, 116, 82, 101, 113, 29, 0, 1, lenOf3[0], lenOf3[1], 10, 10, 3, 0, 0, 0, 0, myID[0], myID[1], myID[2], myID[3], 22, 32, 48, 101, 55, 52, 97, 98, 98, 57, 97, 50, 100, 100, 56, 55, 53, 97, 49, 52, 54, 99, 55, 54, 102, 57, 55, 55, 102, 57, 52, 49, 98, 53, 38, 0, 54, 26, 119, 101, 98, 104, 53, 38, version[0], version[1], version[2], version[3], version[4], version[5], version[6], version[7], version[8], version[9], 38, 119, 101, 98, 115, 111, 99, 107, 101, 116, 71, 0, 0 };
            byte[] normal2 = lenOfcookies;
            byte[] normal3 = Encoding.UTF8.GetBytes(strInfor);
            byte[] pid = Call.getRES(this.pid);

            byte[] normalEnding = { 92, 11, 18, myChid[0], myChid[1], myChid[2], myChid[3], 35, 0, 0, 0, 0, myChsid[0], myChsid[1], myChsid[2], myChsid[3], 50, pid[0], pid[1], pid[2], pid[3], 70, 0, 11, 140, 152, 12, 168, 12, 44 };

            MemoryStream ms = new MemoryStream();
            ms.Write(normalPacket, 0, normalPacket.Length);
            ms.Write(normal2, 0, normal2.Length);
            ms.Write(normal3, 0, normal3.Length);
            ms.Write(normalEnding, 0, normalEnding.Length);
            byte[] demo = ms.ToArray();
            string v = Convert.ToBase64String(demo);
            return demo;
        }

        byte[] genLgnpk()
        {
            int num = 179 + this.strInfor.Length;
            byte[] res = Call.getRES(this.uid);
            byte[] res2 = Call.getRES(this.id);
            byte[] res3 = Call.getRES(this.sid);
            byte[] res4 = Call.getRES((short)(num - 8));
            byte[] res5 = Call.getRES((short)(num - 50));
            byte[] res6 = Call.getRES((short)(num - 64));
            byte[] res7 = Call.getRES((short)this.strInfor.Length);
            byte[] array = new byte[]
            {
        0,
        3,
        29,
        0,
        1,
        0,
        0,
        0,
        0,
        0,
        0,
        16,
        3,
        44,
        60,
        76,
        86,
        8,
        111,
        110,
        108,
        105,
        110,
        101,
        117,
        105,
        102,
        11,
        79,
        110,
        85,
        115,
        101,
        114,
        69,
        118,
        101,
        110,
        116,
        125,
        0,
        1,
        0,
        0,
        8,
        0,
        1,
        6,
        4,
        116,
        82,
        101,
        113,
        29,
        0,
        1,
        0,
        0,
        10,
        10,
        3,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        22,
        32,
        48,
        101,
        55,
        52,
        97,
        98,
        98,
        57,
        97,
        50,
        100,
        100,
        56,
        55,
        53,
        97,
        49,
        52,
        54,
        99,
        55,
        54,
        102,
        57,
        55,
        55,
        102,
        57,
        52,
        49,
        98,
        53,
        38,
        0,
        54,
        26,
        119,
        101,
        98,
        104,
        53,
        38,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        38,
        119,
        101,
        98,
        115,
        111,
        99,
        107,
        101,
        116,
        71,
        0,
        0
            };
            array[5] = res4[0];
            array[6] = res4[1];
            array[9] = res4[0];
            array[10] = res4[1];
            array[42] = res5[0];
            array[43] = res5[1];
            array[56] = res6[0];
            array[57] = res6[1];
            array[65] = res[0];
            array[66] = res[1];
            array[67] = res[2];
            array[68] = res[3];
            array[113] = this.version[0];
            array[114] = this.version[1];
            array[115] = this.version[2];
            array[116] = this.version[3];
            array[117] = this.version[4];
            array[118] = this.version[5];
            array[119] = this.version[6];
            array[120] = this.version[7];
            array[121] = this.version[8];
            array[122] = this.version[9];
            byte[] array2 = array;
            byte[] array3 = res7;
            byte[] bytes = Encoding.UTF8.GetBytes(this.strInfor);
            byte[] res8 = Call.getRES(this.pid);
            byte[] array4 = new byte[]
            {
        92,
        11,
        18,
        0,
        0,
        0,
        0,
        35,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        64,
        1,
        86,
        0,
        96,
        3,
        114,
        0,
        0,
        0,
        0,
        128,
        1,
        156,
        160,
        1,
        182,
        0,
        11,
        140,
        152,
        12,
        168,
        12,
        44
            };
            array4[3] = res2[0];
            array4[4] = res2[1];
            array4[5] = res2[2];
            array4[6] = res2[3];
            array4[12] = res3[0];
            array4[13] = res3[1];
            array4[14] = res3[2];
            array4[15] = res3[3];
            array4[23] = res8[0];
            array4[24] = res8[1];
            array4[25] = res8[2];
            array4[26] = res8[3];
            byte[] array5 = array4;
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(array2, 0, array2.Length);
            memoryStream.Write(array3, 0, array3.Length);
            memoryStream.Write(bytes, 0, bytes.Length);
            memoryStream.Write(array5, 0, array5.Length);
            byte[] array6 = memoryStream.ToArray();

            return array6;
        }


        byte[] genHBpk()
        {
            int alllen = 176 + 4 + strInfor.Length;
            byte[] myID = Call.getRES(uid);
            byte[] myChid = Call.getRES(id);
            byte[] myChsid = Call.getRES(sid);


            byte[] lenOf1 = Call.getRES((short)(alllen - 8));
            byte[] lenOf2 = Call.getRES((short)(alllen - 55));
            byte[] lenOf3 = Call.getRES((short)(alllen - 69));
            byte[] lenOfcookies = Call.getRES((short)(strInfor.Length));

            byte[] normalPacket = { 0, 3, 29, 0, 1, lenOf1[0], lenOf1[1], 0, 0, lenOf1[0], lenOf1[1], 16, 3, 44, 60, 64, (byte)hbcounter, 86, 8, 111, 110, 108, 105, 110, 101, 117, 105, 102, 15, 79, 110, 85, 115, 101, 114, 72, 101, 97, 114, 116, 66, 101, 97, 116, 125, 0, 1, lenOf2[0], lenOf2[1], 8, 0, 1, 6, 4, 116, 82, 101, 113, 29, 0, 1, lenOf3[0], lenOf3[1], 10, 10, 3, 0, 0, 0, 0, myID[0], myID[1], myID[2], myID[3], 22, 32, 48, 101, 55, 52, 97, 98, 98, 57, 97, 50, 100, 100, 56, 55, 53, 97, 49, 52, 54, 99, 55, 54, 102, 57, 55, 55, 102, 57, 52, 49, 98, 53, 38, 0, 54, 26, 119, 101, 98, 104, 53, 38, version[0], version[1], version[2], version[3], version[4], version[5], version[6], version[7], version[8], version[9], 38, 119, 101, 98, 115, 111, 99, 107, 101, 116, 71, 0, 0 };
            byte[] normal2 = lenOfcookies;
            byte[] normal3 = Encoding.UTF8.GetBytes(strInfor);
            byte[] pid = Call.getRES(this.pid);
            byte[] normalEnding = { 92, 11, 18, myChid[0], myChid[1], myChid[2], myChid[3], 35, 0, 0, 0, 0, myChsid[0], myChsid[1], myChsid[2], myChsid[3], 66, pid[0], pid[1], pid[2], pid[3], 80, 1, 96, 5, 112, 30, 140, 156, 172, 11, 140, 152, 12, 168, 12, 44 };
            hbcounter++;
            MemoryStream ms = new MemoryStream();
            ms.Write(normalPacket, 0, normalPacket.Length);
            ms.Write(normal2, 0, normal2.Length);
            ms.Write(normal3, 0, normal3.Length);
            ms.Write(normalEnding, 0, normalEnding.Length);
            byte[] demo = ms.ToArray();

            return demo;
        }

        byte[] genRegisterPk()
        {

            int alllen = 34 + strInfor.Length;//1=191 1700=192
            byte[] myID = Call.getRES(uid);
            byte[] lenOf1 = Call.getRES((short)(alllen - 8));
            byte[] lenOfcookies = Call.getRES((short)(strInfor.Length));
            byte[] rPk = { 0, 10, 29, 0, 1, lenOf1[0], lenOf1[1], 3, 0, 0, 0, 0, myID[0], myID[1], myID[2], myID[3], 22, 10, 49, 56, 48, 52, 49, 51, 49, 49, 52, 48, 39, 0, 0, lenOfcookies[0], lenOfcookies[1] };
            byte[] normalPk = Encoding.UTF8.GetBytes(strInfor);
            byte[] endingPk = { 44 };
            MemoryStream ms = new MemoryStream();
            ms.Write(rPk, 0, rPk.Length);
            ms.Write(normalPk, 0, normalPk.Length);
            ms.Write(endingPk, 0, endingPk.Length);

            return ms.ToArray();
        }
        byte[] getsmspk()
        {
            //Random r = new Random();

            string sendsms = Call.GenerateChineseWords(3);

            Random r = new Random();
            // byte[] sendMsm = Encoding.UTF8.GetBytes(sendsms);
            //  return new byte[] { 0, 3, 29, 0, 1, 9, 53, 0, 0, 9, 53, 16, 3, 44, 60, 64, 255, 86, 6, 108, 105, 118, 101, 117, 105, 102, 11, 115, 101, 110, 100, 77, 101, 115, 115, 97, 103, 101, 125, 0, 1, 9, 12, 8, 0, 1, 6, 4, 116, 82, 101, 113, 29, 0, 1, 8, 254, 10, 10, 2, 0, 169, 14, 58, 22, 32, 48, 101, 55, 52, 97, 98, 98, 99, 100, 55, 51, 51, 99, 54, 53, 97, 54, 52, 51, 101, 54, 57, 54, 54, 54, 97, 54, 54, 102, 57, 100, 99, 38, 0, 54, 26, 119, 101, 98, 104, 53, 38, 49, 56, 48, 52, 50, 49, 49, 56, 50, 50, 38, 119, 101, 98, 115, 111, 99, 107, 101, 116, 71, 0, 0, 8, 110, 95, 95, 121, 97, 109, 105, 100, 95, 116, 116, 49, 61, 48, 46, 56, 51, 52, 55, 52, 53, 53, 48, 56, 57, 56, 54, 50, 53, 51, 55, 59, 32, 95, 95, 121, 97, 109, 105, 100, 95, 110, 101, 119, 61, 67, 55, 69, 70, 69, 69, 56, 48, 48, 57, 67, 48, 48, 48, 48, 49, 65, 51, 67, 56, 57, 56, 67, 48, 49, 70, 65, 65, 49, 66, 51, 67, 59, 32, 85, 77, 95, 100, 105, 115, 116, 105, 110, 99, 116, 105, 100, 61, 49, 54, 50, 57, 54, 51, 97, 55, 57, 56, 53, 50, 51, 51, 45, 48, 101, 100, 54, 57, 49, 101, 98, 54, 57, 100, 97, 49, 100, 45, 51, 98, 54, 48, 52, 57, 48, 100, 45, 49, 56, 101, 52, 49, 52, 45, 49, 54, 50, 57, 54, 51, 97, 55, 57, 56, 54, 50, 49, 59, 32, 83, 111, 117, 110, 100, 86, 97, 108, 117, 101, 61, 48, 46, 53, 48, 59, 32, 103, 117, 105, 100, 61, 48, 101, 55, 52, 97, 98, 98, 99, 100, 55, 51, 51, 99, 54, 53, 97, 54, 52, 51, 101, 54, 57, 54, 54, 54, 97, 54, 54, 102, 57, 100, 99, 59, 32, 67, 78, 90, 90, 68, 65, 84, 65, 49, 50, 54, 54, 56, 52, 48, 56, 55, 49, 61, 51, 54, 55, 48, 50, 49, 50, 50, 50, 45, 49, 53, 50, 50, 57, 52, 50, 52, 53, 48, 45, 37, 55, 67, 49, 53, 50, 51, 48, 56, 56, 50, 53, 48, 59, 32, 117, 100, 98, 95, 103, 117, 105, 100, 100, 97, 116, 97, 61, 49, 54, 52, 97, 56, 51, 102, 52, 51, 48, 50, 97, 52, 53, 52, 57, 57, 49, 54, 99, 53, 50, 97, 50, 99, 101, 57, 54, 56, 49, 54, 100, 59, 32, 117, 100, 98, 95, 97, 99, 99, 100, 97, 116, 97, 61, 121, 121, 53, 55, 51, 117, 105, 104, 102, 114, 114, 59, 32, 67, 78, 90, 90, 68, 65, 84, 65, 49, 50, 53, 54, 55, 57, 51, 51, 49, 57, 61, 49, 51, 50, 55, 50, 54, 51, 56, 52, 55, 45, 49, 53, 50, 50, 57, 51, 53, 50, 53, 52, 45, 37, 55, 67, 49, 53, 50, 51, 55, 55, 50, 51, 50, 54, 59, 32, 80, 72, 80, 83, 69, 83, 83, 73, 68, 61, 54, 109, 101, 116, 100, 106, 104, 51, 116, 117, 113, 53, 97, 100, 114, 54, 106, 100, 99, 109, 103, 110, 103, 112, 56, 52, 59, 32, 105, 115, 73, 110, 76, 105, 118, 101, 82, 111, 111, 109, 61, 116, 114, 117, 101, 59, 32, 95, 95, 121, 97, 115, 109, 105, 100, 61, 48, 46, 56, 51, 52, 55, 52, 53, 53, 48, 56, 57, 56, 54, 50, 53, 51, 55, 59, 32, 72, 109, 95, 108, 118, 116, 95, 53, 49, 55, 48, 48, 98, 54, 99, 55, 50, 50, 102, 53, 98, 98, 52, 99, 102, 51, 57, 57, 48, 54, 97, 53, 57, 54, 101, 97, 52, 49, 102, 61, 49, 53, 50, 52, 51, 49, 57, 56, 56, 48, 44, 49, 53, 50, 52, 51, 50, 49, 48, 49, 53, 44, 49, 53, 50, 52, 51, 54, 57, 49, 53, 56, 44, 49, 53, 50, 52, 51, 57, 51, 50, 49, 52, 59, 32, 117, 100, 98, 95, 112, 97, 115, 115, 100, 97, 116, 97, 61, 49, 59, 32, 121, 97, 95, 101, 105, 100, 61, 110, 97, 118, 105, 47, 115, 105, 103, 110, 59, 32, 117, 100, 98, 111, 97, 117, 116, 104, 116, 109, 112, 116, 111, 107, 101, 110, 61, 102, 54, 100, 55, 57, 100, 99, 48, 51, 51, 49, 101, 54, 51, 98, 99, 54, 97, 102, 49, 99, 57, 100, 50, 101, 99, 55, 97, 48, 98, 51, 100, 54, 101, 53, 50, 48, 97, 49, 56, 98, 99, 49, 97, 98, 56, 102, 49, 49, 98, 51, 97, 51, 99, 98, 48, 102, 101, 101, 55, 52, 51, 97, 55, 97, 49, 102, 97, 49, 49, 97, 99, 50, 53, 52, 98, 102, 56, 56, 102, 99, 56, 52, 50, 50, 102, 98, 57, 48, 100, 57, 51, 55, 50, 97, 57, 59, 32, 117, 100, 98, 111, 97, 117, 116, 104, 116, 109, 112, 116, 111, 107, 101, 110, 115, 101, 99, 61, 59, 32, 104, 95, 112, 114, 61, 49, 59, 32, 121, 121, 117, 105, 100, 61, 49, 49, 48, 55, 57, 50, 50, 54, 59, 32, 117, 115, 101, 114, 110, 97, 109, 101, 61, 120, 105, 97, 110, 103, 53, 49, 49, 55, 59, 32, 112, 97, 115, 115, 119, 111, 114, 100, 61, 68, 68, 50, 69, 51, 68, 65, 48, 57, 52, 65, 66, 48, 52, 68, 65, 65, 56, 65, 50, 53, 67, 55, 56, 68, 69, 48, 68, 50, 56, 57, 49, 56, 50, 65, 56, 67, 48, 70, 68, 59, 32, 111, 115, 105, 110, 102, 111, 61, 69, 53, 70, 69, 68, 66, 67, 66, 50, 70, 52, 65, 66, 68, 52, 54, 70, 67, 50, 49, 51, 52, 49, 69, 52, 52, 68, 56, 56, 65, 55, 49, 55, 55, 50, 68, 55, 68, 65, 53, 59, 32, 117, 100, 98, 95, 108, 61, 67, 81, 66, 52, 97, 87, 70, 117, 90, 122, 85, 120, 77, 84, 99, 98, 90, 100, 120, 97, 67, 72, 69, 65, 122, 89, 68, 67, 107, 103, 107, 95, 51, 55, 97, 88, 109, 84, 76, 73, 54, 70, 78, 89, 82, 99, 84, 69, 114, 105, 106, 86, 103, 108, 54, 99, 104, 49, 77, 51, 50, 81, 74, 119, 54, 80, 72, 86, 117, 113, 101, 70, 87, 105, 65, 97, 57, 65, 76, 108, 117, 65, 120, 88, 121, 107, 83, 82, 78, 68, 99, 115, 56, 81, 102, 55, 66, 118, 119, 84, 101, 78, 82, 84, 83, 83, 73, 82, 83, 82, 98, 88, 114, 112, 115, 48, 98, 90, 57, 76, 69, 76, 67, 71, 116, 119, 49, 72, 114, 101, 53, 89, 52, 79, 75, 102, 69, 83, 83, 70, 86, 113, 68, 74, 82, 75, 108, 113, 80, 113, 97, 112, 79, 89, 113, 106, 48, 115, 78, 68, 57, 57, 68, 116, 90, 105, 54, 116, 118, 116, 116, 111, 65, 66, 77, 65, 65, 65, 65, 65, 65, 119, 65, 65, 65, 65, 65, 65, 65, 65, 65, 79, 65, 68, 69, 120, 77, 121, 52, 120, 77, 68, 81, 117, 77, 84, 107, 122, 76, 106, 85, 48, 66, 65, 65, 49, 77, 106, 69, 50, 59, 32, 117, 100, 98, 95, 110, 61, 51, 57, 57, 53, 52, 56, 53, 56, 98, 55, 52, 53, 48, 97, 53, 97, 101, 54, 101, 49, 98, 99, 52, 101, 98, 98, 53, 102, 53, 56, 57, 98, 57, 99, 99, 49, 53, 55, 48, 57, 51, 97, 101, 97, 98, 53, 49, 98, 56, 51, 50, 48, 53, 53, 57, 54, 99, 100, 102, 52, 100, 54, 55, 53, 99, 102, 52, 50, 98, 54, 53, 99, 53, 100, 97, 55, 50, 54, 53, 98, 56, 50, 52, 102, 100, 48, 52, 99, 48, 97, 50, 51, 49, 53, 56, 49, 59, 32, 117, 100, 98, 95, 99, 61, 65, 77, 67, 78, 74, 70, 66, 113, 65, 65, 74, 103, 65, 75, 97, 79, 107, 105, 100, 107, 55, 104, 74, 49, 98, 52, 108, 56, 95, 97, 80, 102, 65, 66, 88, 74, 77, 80, 103, 45, 77, 121, 103, 114, 74, 113, 69, 78, 49, 68, 112, 104, 51, 117, 86, 53, 102, 68, 71, 81, 101, 75, 122, 90, 75, 53, 72, 89, 57, 97, 51, 72, 104, 51, 97, 81, 50, 86, 95, 120, 103, 106, 55, 113, 57, 87, 49, 81, 50, 57, 83, 71, 70, 66, 110, 76, 118, 97, 120, 118, 121, 56, 71, 51, 114, 122, 69, 103, 109, 121, 75, 117, 89, 65, 119, 51, 88, 85, 101, 97, 103, 99, 67, 121, 52, 65, 117, 100, 107, 116, 121, 101, 116, 102, 115, 79, 56, 77, 54, 101, 45, 119, 61, 61, 59, 32, 117, 100, 98, 95, 111, 97, 114, 61, 49, 68, 65, 68, 50, 68, 54, 51, 50, 65, 56, 65, 55, 65, 54, 57, 56, 52, 50, 56, 70, 48, 67, 49, 52, 65, 56, 68, 52, 50, 55, 68, 56, 57, 56, 67, 68, 66, 55, 57, 67, 65, 56, 49, 52, 48, 69, 53, 66, 56, 55, 57, 48, 55, 56, 65, 66, 65, 50, 57, 48, 53, 54, 65, 66, 55, 48, 49, 69, 48, 65, 57, 70, 55, 54, 49, 50, 67, 50, 69, 48, 52, 66, 50, 67, 48, 69, 67, 65, 52, 68, 55, 54, 66, 48, 69, 70, 49, 50, 54, 49, 51, 66, 55, 68, 57, 49, 57, 68, 69, 49, 54, 65, 70, 68, 55, 57, 57, 65, 65, 48, 54, 70, 55, 68, 57, 68, 51, 48, 48, 69, 68, 67, 66, 56, 54, 68, 70, 66, 54, 65, 67, 52, 53, 51, 55, 56, 57, 54, 67, 70, 66, 70, 66, 50, 51, 65, 56, 55, 69, 52, 56, 55, 51, 54, 56, 53, 51, 48, 69, 66, 51, 57, 56, 70, 55, 48, 53, 48, 50, 56, 56, 56, 68, 51, 69, 69, 70, 50, 52, 49, 54, 54, 51, 49, 56, 56, 56, 68, 51, 50, 52, 49, 67, 66, 55, 67, 55, 49, 52, 69, 50, 56, 55, 65, 57, 56, 54, 67, 69, 55, 70, 48, 49, 66, 66, 56, 48, 55, 70, 56, 51, 53, 57, 70, 70, 52, 70, 57, 67, 69, 51, 53, 50, 65, 65, 68, 70, 53, 65, 68, 70, 57, 70, 53, 54, 53, 65, 57, 52, 67, 53, 49, 51, 54, 49, 68, 56, 52, 56, 67, 54, 50, 51, 70, 53, 57, 65, 53, 52, 49, 52, 66, 65, 49, 52, 56, 56, 51, 54, 52, 48, 49, 54, 48, 53, 53, 50, 67, 65, 70, 53, 51, 67, 53, 51, 52, 50, 49, 48, 69, 70, 70, 48, 51, 70, 69, 55, 51, 49, 69, 54, 55, 70, 56, 54, 69, 52, 49, 69, 53, 57, 67, 66, 55, 52, 52, 55, 66, 57, 55, 53, 68, 65, 49, 70, 54, 56, 54, 51, 53, 68, 66, 53, 65, 66, 54, 55, 67, 49, 56, 68, 51, 54, 54, 68, 50, 57, 51, 49, 54, 48, 65, 68, 50, 65, 53, 55, 52, 68, 51, 57, 68, 57, 52, 67, 65, 69, 67, 65, 65, 53, 56, 66, 49, 66, 54, 48, 57, 55, 56, 67, 50, 57, 67, 66, 66, 54, 66, 50, 56, 56, 54, 67, 52, 67, 56, 69, 51, 49, 50, 67, 54, 56, 54, 54, 48, 65, 56, 68, 55, 68, 48, 55, 49, 70, 54, 54, 65, 52, 57, 48, 69, 67, 69, 66, 49, 68, 48, 67, 68, 65, 53, 54, 52, 49, 53, 48, 65, 68, 51, 65, 51, 52, 68, 49, 55, 67, 67, 65, 69, 50, 54, 51, 70, 68, 66, 67, 54, 68, 50, 67, 69, 54, 51, 69, 54, 56, 70, 52, 66, 49, 53, 54, 50, 68, 50, 70, 49, 65, 55, 67, 65, 57, 49, 66, 55, 56, 49, 68, 55, 50, 48, 48, 54, 68, 49, 52, 65, 68, 50, 66, 67, 70, 50, 70, 68, 55, 48, 50, 49, 67, 55, 70, 65, 69, 48, 55, 66, 66, 48, 54, 49, 53, 53, 70, 69, 51, 69, 67, 70, 69, 51, 56, 55, 67, 49, 48, 51, 53, 50, 55, 52, 56, 50, 65, 54, 67, 53, 55, 51, 53, 65, 67, 66, 66, 66, 50, 48, 66, 52, 49, 56, 68, 55, 50, 67, 70, 70, 67, 70, 69, 49, 54, 65, 66, 56, 67, 66, 67, 53, 53, 69, 70, 69, 55, 53, 70, 54, 52, 70, 51, 51, 56, 54, 70, 70, 51, 51, 53, 51, 69, 51, 50, 69, 70, 52, 70, 50, 66, 56, 66, 57, 70, 56, 50, 55, 53, 70, 52, 59, 32, 95, 95, 121, 97, 111, 108, 100, 121, 121, 117, 105, 100, 61, 49, 49, 48, 55, 57, 50, 50, 54, 59, 32, 95, 121, 97, 115, 105, 100, 115, 61, 95, 95, 114, 111, 111, 116, 115, 105, 100, 37, 51, 68, 67, 55, 70, 53, 53, 57, 56, 66, 69, 65, 48, 48, 48, 48, 48, 49, 68, 70, 69, 49, 49, 67, 48, 48, 66, 56, 55, 56, 49, 67, 67, 65, 59, 32, 72, 109, 95, 108, 112, 118, 116, 95, 53, 49, 55, 48, 48, 98, 54, 99, 55, 50, 50, 102, 53, 98, 98, 52, 99, 102, 51, 57, 57, 48, 54, 97, 53, 57, 54, 101, 97, 52, 49, 102, 61, 49, 53, 50, 52, 51, 57, 51, 50, 53, 52, 59, 32, 104, 95, 117, 110, 116, 61, 49, 53, 50, 52, 51, 57, 51, 50, 56, 50, 92, 11, 18, 0, 159, 159, 207, 34, 0, 159, 159, 207, 54, 28, 231, 142, 139, 229, 173, 144, 231, 187, 174, 32, 232, 131, 189, 228, 184, 141, 232, 131, 189, 229, 144, 172, 231, 130, 185, 232, 175, 157, 76, 90, 0, 255, 16, 4, 44, 11, 106, 0, 255, 16, 4, 44, 48, 1, 76, 11, 121, 12, 130, pid[0],pid[1],pid[2],pid3, 11, 140, 152, 12, 168, 12, 44 };
            byte[] isenddddddddddddddddddddddbytes = { };
            if (Call.sendCon == "{3}")
            {
                string str = ((char)r.Next(48, 65 + 64)).ToString();
                int num = r.Next(3, 10);
                for (int i = 0; i < num; i++)
                    str += ((char)r.Next(48, 65 + 26)).ToString();
                isenddddddddddddddddddddddbytes = Encoding.UTF8.GetBytes(str);
            }
            else if (Call.sendCon == "{666}")
            {
                string str = ((new Random().Next(0, 1) == 0 ? (char)r.Next(65, 65 + 26) : (char)r.Next(97, 97 + 26))).ToString();
                int num = r.Next(3, 10);

                for (int i = 0; i < num; i++)
                    str += (r.Next(0, 2) == 0 ? (char)r.Next(65, 65 + 26) : (r.Next(0, 3) == 0 ? (char)r.Next(97, 97 + 26) : (char)r.Next('0', '9'))).ToString();
                isenddddddddddddddddddddddbytes = Encoding.UTF8.GetBytes(str);

            }
            //, 231, 142, 139, 229, 173, 144// { 231, 142, 139, 229, 173, 144, 231, 187, 174, 229, 164, 167, 229, 130, 187, 233, 128, 188,(byte)r.Next(65,65+26) };// Encoding.UTF8.GetBytes(sendsms);
            else
            {
                isenddddddddddddddddddddddbytes = Encoding.UTF8.GetBytes(Call.sendCon.Replace("{1}", Call.GenerateChineseWords(r.Next(3, 8))).Replace("{2}", Call.GenerateChineseWords(r.Next(3, 8))));
            }//   Encoding.UTF8.GetBytes("王子绮我儿子" + r.Next(000, 999));

            int alllen = isenddddddddddddddddddddddbytes.Length + 183 + 4 + strInfor.Length;//1=191 1700=192
            int conlen = isenddddddddddddddddddddddbytes.Length;// sendMsm.Length;
            byte[] myID = Call.getRES(uid);
            byte[] myChid = Call.getRES(id);
            byte[] myChsid = Call.getRES(sid);
            byte[] lenOf1 = Call.getRES((short)(alllen - 8));
            byte[] lenOf2 = Call.getRES((short)(alllen - 49));
            byte[] lenOf3 = Call.getRES((short)(alllen - 63));
            byte[] pid = Call.getRES(this.pid);
            byte[] lenOfcookies = Call.getRES((short)(strInfor.Length));
            byte[] sPk = { 0, 3, 29, 0, 1, lenOf1[0], lenOf1[1], 0, 0, lenOf1[0], lenOf1[1], 16, 3, 44, 60, 64, 255, 86, 6, 108, 105, 118, 101, 117, 105, 102, 11, 115, 101, 110, 100, 77, 101, 115, 115, 97, 103, 101, 125, 0, 1, lenOf2[0], lenOf2[1], 8, 0, 1, 6, 4, 116, 82, 101, 113, 29, 0, 1, lenOf3[0], lenOf3[1], 10, 10, 3, 0, 0, 0, 0, myID[0], myID[1], myID[2], myID[3], 22, 32, 48, 101, 55, 52, 97, 98, 98, 99, 100, 55, 51, 51, 99, 54, 53, 97, 54, 52, 51, 101, 54, 57, 54, 54, 54, 97, 54, 54, 102, 57, 100, 99, 38, 0, 54, 26, 119, 101, 98, 104, 53, 38, 49, 56, 48, 52, 49, 51, 49, 49, 52, 48, 38, 119, 101, 98, 115, 111, 99, 107, 101, 116, 71, 0, 0, lenOfcookies[0], lenOfcookies[1] };
            byte[] normalPk = Encoding.UTF8.GetBytes(strInfor);
            //92,11,18,0,159,159,207,34,0,159,159,207,54,18,231,142,139,229,173,144,231,187,174,229,164,167,229,130,187,233,128,188,76,90,0,255,16,4,44,11,106,0,255,16,4,44,48,1,76,11,121,12,130,3,211,45,47,11,140,152,12,168,12,44]
            byte[] ends = { 92, 11, 18, myChid[0], myChid[1], myChid[2], myChid[3], 35, 0, 0, 0, 0, myChsid[0], myChsid[1], myChsid[2], myChsid[3], 54, (byte)isenddddddddddddddddddddddbytes.Length };
            byte[] content = isenddddddddddddddddddddddbytes;// { (byte)r.Next(65, 65 + 26), (byte)r.Next(65, 65 + 26) , (byte)r.Next(65, 65 + 26) };//, 231, 142, 139, 229, 173, 144// { 231, 142, 139, 229, 173, 144, 231, 187, 174, 229, 164, 167, 229, 130, 187, 233, 128, 188,(byte)r.Next(65,65+26) };// Encoding.UTF8.GetBytes(sendsms);
            byte[] con2 = content;// sendMsm;
            byte[] adding = { 76, 90, 0, 255, 16, 4, 44, 11, 106, 0, 255, 16, 4, 44, 48, 1, 76, 11, 121, 12, 130, pid[0], pid[1], pid[2], pid[3], 11, 140, 152, 12, 168, 12, 44 };
            MemoryStream ms = new MemoryStream();
            ms.Write(sPk, 0, sPk.Length);
            ms.Write(normalPk, 0, normalPk.Length);
            ms.Write(ends, 0, ends.Length);
            //ms.Write(content, 0, content.Length);
            ms.Write(con2, 0, con2.Length);
            ms.Write(adding, 0, adding.Length);
            return ms.ToArray();
        }
        /* 
         * 
         * 
         * 
         * byte[] getGameIDPk()
          {
              byte[] myID = Call.getRES(uid);
              byte[] myChid = Call.getRES(id);
              byte[] myChsid = Call.getRES(sid);
              byte[] F = { 0, 3, 29, 0, 1, 9, 50, 0, 0, 9, 50, 16, 3, 44, 60, 64, 4, 86, 6, 103, 97, 109, 101, 117, 105, 102, 11, 103, 101, 116, 71, 97, 109, 101, 73, 110, 102, 111, 125, 0, 1, 9, 9, 8, 0, 1, 6, 4, 116, 82, 101, 113, 29, 0, 1, 8, 251, 10, 10, 3, 0, 0, 0, 0, 132, 146, 207, 43, 22, 32, 48, 101, 55, 52, 97, 98, 98, 57, 97, 50, 100, 100, 56, 55, 53, 97, 49, 52, 54, 99, 55, 54, 102, 57, 55, 55, 102, 57, 52, 49, 98, 53, 38, 0, 54, 26, 119, 101, 98, 104, 53, 38, version[0], version[1], version[2], version[3], version[4], version[5], version[6], version[7], version[8], version[9], 38, 119, 101, 98, 115, 111, 99, 107, 101, 116, 71, 0, 0, 8, 149, 83, 111, 117, 110, 100, 86, 97, 108, 117, 101, 61, 48, 46, 53, 48, 59, 32, 103, 117, 105, 100, 61, 48, 101, 55, 52, 97, 98, 98, 57, 97, 50, 100, 100, 56, 55, 53, 97, 49, 52, 54, 99, 55, 54, 102, 57, 55, 55, 102, 57, 52, 49, 98, 53, 59, 32, 95, 95, 121, 97, 109, 105, 100, 95, 116, 116, 49, 61, 48, 46, 54, 55, 49, 53, 53, 53, 57, 56, 56, 51, 49, 53, 54, 52, 49, 59, 32, 95, 95, 121, 97, 109, 105, 100, 95, 110, 101, 119, 61, 67, 55, 69, 48, 66, 54, 55, 55, 51, 68, 69, 48, 48, 48, 48, 49, 65, 49, 49, 49, 52, 67, 51, 48, 49, 69, 48, 48, 55, 66, 48, 48, 59, 32, 118, 105, 100, 101, 111, 76, 105, 110, 101, 61, 51, 59, 32, 85, 77, 95, 100, 105, 115, 116, 105, 110, 99, 116, 105, 100, 61, 49, 54, 49, 102, 98, 99, 55, 98, 53, 51, 99, 50, 101, 45, 48, 52, 51, 99, 101, 99, 101, 50, 56, 53, 99, 98, 50, 56, 45, 51, 98, 54, 48, 52, 57, 48, 100, 45, 49, 56, 101, 52, 49, 52, 45, 49, 54, 49, 102, 98, 99, 55, 98, 53, 51, 100, 55, 53, 97, 59, 32, 67, 78, 90, 90, 68, 65, 84, 65, 49, 50, 53, 54, 55, 57, 51, 51, 49, 57, 61, 49, 51, 51, 48, 55, 49, 49, 56, 56, 50, 45, 49, 53, 50, 48, 51, 52, 51, 48, 50, 51, 45, 37, 55, 67, 49, 53, 50, 48, 53, 54, 57, 56, 51, 56, 59, 32, 105, 115, 73, 110, 76, 105, 118, 101, 82, 111, 111, 109, 61, 116, 114, 117, 101, 59, 32, 95, 95, 121, 97, 115, 109, 105, 100, 61, 48, 46, 54, 55, 49, 53, 53, 53, 57, 56, 56, 51, 49, 53, 54, 52, 49, 59, 32, 72, 109, 95, 108, 118, 116, 95, 53, 49, 55, 48, 48, 98, 54, 99, 55, 50, 50, 102, 53, 98, 98, 52, 99, 102, 51, 57, 57, 48, 54, 97, 53, 57, 54, 101, 97, 52, 49, 102, 61, 49, 53, 50, 48, 51, 52, 55, 54, 50, 55, 44, 49, 53, 50, 48, 53, 55, 53, 48, 48, 51, 44, 49, 53, 50, 49, 51, 55, 55, 57, 49, 51, 44, 49, 53, 50, 49, 55, 55, 56, 56, 55, 57, 59, 32, 117, 100, 98, 95, 112, 97, 115, 115, 100, 97, 116, 97, 61, 49, 59, 32, 117, 100, 98, 111, 97, 117, 116, 104, 116, 109, 112, 116, 111, 107, 101, 110, 115, 101, 99, 61, 59, 32, 80, 72, 80, 83, 69, 83, 83, 73, 68, 61, 51, 116, 110, 105, 104, 50, 105, 107, 51, 118, 117, 110, 112, 54, 106, 108, 48, 56, 104, 114, 48, 105, 56, 105, 48, 55, 59, 32, 121, 97, 95, 101, 105, 100, 61, 110, 97, 118, 105, 47, 115, 105, 103, 110, 59, 32, 117, 100, 98, 111, 97, 117, 116, 104, 116, 109, 112, 116, 111, 107, 101, 110, 61, 100, 97, 102, 52, 98, 49, 57, 54, 97, 102, 97, 53, 55, 55, 50, 53, 57, 97, 98, 101, 102, 56, 53, 50, 48, 100, 102, 52, 49, 101, 57, 102, 55, 48, 51, 48, 53, 57, 101, 100, 50, 102, 49, 99, 102, 51, 100, 99, 57, 52, 52, 52, 102, 97, 97, 97, 102, 101, 50, 99, 98, 102, 53, 57, 101, 51, 49, 102, 98, 98, 56, 101, 56, 97, 57, 56, 99, 56, 52, 50, 54, 56, 49, 101, 55, 98, 97, 102, 57, 55, 97, 99, 55, 56, 101, 57, 59, 32, 104, 95, 112, 114, 61, 49, 59, 32, 121, 121, 117, 105, 100, 61, 50, 50, 50, 52, 50, 49, 51, 56, 48, 51, 59, 32, 117, 115, 101, 114, 110, 97, 109, 101, 61, 98, 98, 100, 108, 52, 49, 97, 122, 97, 104, 57, 50, 106, 117, 57, 117, 59, 32, 112, 97, 115, 115, 119, 111, 114, 100, 61, 69, 53, 51, 48, 65, 70, 56, 53, 50, 50, 69, 69, 51, 56, 69, 66, 49, 66, 49, 70, 57, 67, 56, 65, 51, 68, 57, 67, 55, 69, 69, 51, 70, 50, 68, 68, 66, 65, 67, 67, 59, 32, 111, 115, 105, 110, 102, 111, 61, 55, 48, 54, 50, 67, 70, 69, 68, 70, 54, 51, 52, 51, 56, 54, 57, 51, 49, 57, 56, 68, 49, 67, 55, 67, 55, 66, 48, 55, 49, 52, 69, 51, 51, 68, 65, 55, 54, 55, 52, 59, 32, 117, 100, 98, 95, 108, 61, 69, 65, 66, 105, 89, 109, 82, 115, 78, 68, 70, 104, 101, 109, 70, 111, 79, 84, 74, 113, 100, 84, 108, 49, 98, 111, 75, 48, 87, 103, 100, 52, 65, 76, 104, 90, 101, 89, 84, 103, 113, 105, 74, 74, 118, 95, 118, 82, 86, 105, 67, 86, 107, 122, 51, 51, 82, 53, 118, 72, 118, 116, 73, 87, 77, 109, 119, 71, 110, 101, 77, 68, 66, 52, 57, 68, 55, 103, 100, 49, 112, 100, 102, 45, 73, 114, 110, 114, 85, 65, 67, 57, 109, 78, 116, 100, 70, 85, 67, 52, 83, 66, 107, 106, 106, 102, 68, 48, 69, 56, 85, 52, 85, 81, 118, 72, 117, 68, 114, 116, 120, 71, 117, 86, 108, 121, 81, 72, 76, 74, 49, 48, 84, 101, 53, 120, 75, 102, 108, 56, 114, 66, 50, 83, 55, 53, 115, 107, 65, 68, 104, 104, 86, 78, 48, 97, 78, 88, 54, 102, 113, 110, 88, 80, 81, 89, 85, 71, 111, 68, 45, 101, 88, 67, 117, 71, 73, 102, 53, 107, 48, 82, 104, 114, 80, 89, 77, 110, 84, 95, 77, 70, 119, 103, 65, 65, 65, 65, 65, 68, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 119, 65, 77, 84, 81, 117, 77, 106, 85, 117, 77, 106, 81, 49, 76, 106, 73, 119, 66, 65, 65, 49, 77, 106, 69, 50, 59, 32, 117, 100, 98, 95, 110, 61, 53, 98, 53, 101, 56, 56, 54, 102, 98, 48, 55, 101, 99, 52, 54, 98, 52, 48, 54, 98, 98, 99, 100, 100, 100, 97, 57, 50, 101, 57, 56, 55, 49, 55, 56, 56, 52, 54, 97, 55, 51, 102, 55, 102, 101, 57, 51, 56, 48, 101, 100, 57, 54, 48, 101, 98, 57, 51, 49, 100, 97, 52, 99, 56, 99, 57, 97, 101, 53, 55, 55, 55, 51, 55, 57, 53, 52, 98, 52, 48, 50, 100, 101, 54, 54, 55, 56, 100, 49, 53, 50, 52, 52, 53, 51, 48, 59, 32, 117, 100, 98, 95, 99, 61, 65, 69, 67, 72, 74, 70, 66, 113, 65, 65, 74, 103, 65, 80, 121, 114, 48, 74, 114, 78, 56, 72, 67, 89, 108, 89, 90, 110, 50, 107, 81, 51, 77, 45, 45, 105, 97, 120, 109, 65, 114, 80, 121, 99, 65, 87, 103, 69, 83, 45, 45, 87, 101, 103, 54, 76, 95, 67, 112, 49, 121, 95, 69, 90, 116, 88, 81, 107, 45, 85, 53, 82, 72, 57, 119, 120, 116, 49, 88, 108, 120, 69, 81, 113, 82, 110, 90, 75, 99, 55, 76, 117, 108, 50, 69, 120, 57, 110, 113, 115, 81, 51, 114, 68, 112, 100, 110, 70, 79, 68, 110, 118, 84, 87, 80, 86, 56, 105, 102, 66, 77, 73, 111, 103, 102, 78, 115, 102, 122, 86, 69, 77, 89, 84, 71, 70, 105, 90, 104, 87, 49, 119, 61, 61, 59, 32, 117, 100, 98, 95, 111, 97, 114, 61, 50, 51, 70, 70, 70, 48, 54, 48, 66, 68, 69, 57, 65, 67, 50, 54, 54, 68, 70, 54, 53, 57, 53, 69, 66, 70, 67, 65, 56, 57, 48, 48, 65, 50, 67, 55, 52, 70, 54, 65, 49, 69, 56, 48, 68, 52, 57, 52, 50, 51, 57, 70, 52, 56, 53, 68, 66, 66, 51, 65, 55, 56, 50, 70, 49, 52, 66, 69, 54, 52, 70, 51, 68, 49, 53, 50, 65, 66, 66, 57, 56, 50, 57, 50, 48, 51, 50, 49, 53, 68, 70, 70, 54, 52, 49, 54, 65, 57, 70, 50, 70, 48, 65, 68, 55, 69, 57, 49, 56, 68, 57, 57, 56, 48, 52, 57, 66, 69, 53, 69, 48, 65, 57, 56, 53, 52, 53, 53, 56, 69, 54, 68, 50, 53, 49, 53, 67, 48, 66, 50, 68, 52, 67, 55, 55, 50, 53, 53, 53, 67, 54, 51, 48, 67, 50, 68, 66, 65, 48, 70, 69, 70, 70, 53, 51, 51, 65, 53, 50, 66, 57, 56, 68, 66, 66, 69, 49, 50, 54, 65, 52, 53, 52, 69, 49, 51, 67, 55, 65, 56, 67, 50, 51, 52, 54, 66, 57, 50, 65, 48, 68, 51, 56, 70, 70, 65, 55, 66, 51, 68, 55, 48, 68, 51, 67, 48, 66, 50, 54, 49, 52, 65, 66, 48, 55, 51, 51, 69, 53, 70, 56, 67, 69, 69, 66, 52, 67, 55, 68, 66, 67, 68, 51, 69, 49, 69, 66, 51, 54, 55, 66, 56, 50, 51, 52, 69, 50, 51, 51, 53, 48, 65, 48, 54, 48, 65, 70, 67, 68, 57, 69, 50, 53, 66, 56, 57, 65, 66, 56, 55, 67, 65, 69, 65, 48, 49, 66, 66, 51, 49, 66, 53, 52, 69, 50, 54, 48, 69, 54, 67, 65, 69, 51, 68, 68, 68, 66, 70, 56, 55, 53, 50, 68, 49, 65, 66, 68, 54, 50, 67, 52, 55, 56, 49, 70, 70, 56, 68, 66, 53, 65, 49, 65, 65, 50, 48, 68, 52, 52, 56, 48, 49, 52, 56, 66, 52, 53, 68, 48, 51, 65, 56, 68, 65, 65, 53, 70, 50, 51, 56, 68, 50, 51, 56, 48, 66, 51, 48, 67, 69, 53, 49, 66, 48, 53, 52, 69, 49, 51, 52, 52, 50, 57, 70, 66, 56, 66, 51, 65, 70, 66, 57, 53, 67, 52, 67, 57, 57, 49, 51, 66, 66, 48, 68, 66, 50, 66, 48, 55, 48, 55, 49, 51, 50, 51, 49, 57, 55, 48, 68, 50, 67, 48, 56, 68, 66, 66, 66, 57, 50, 67, 53, 54, 70, 50, 66, 68, 53, 55, 68, 53, 70, 53, 53, 50, 67, 52, 70, 51, 67, 53, 56, 55, 54, 52, 69, 67, 53, 49, 55, 55, 66, 49, 65, 55, 69, 65, 48, 55, 48, 52, 67, 65, 66, 56, 50, 69, 57, 56, 52, 70, 68, 48, 66, 51, 56, 57, 49, 48, 54, 56, 56, 50, 69, 55, 49, 55, 66, 69, 66, 69, 54, 48, 55, 52, 67, 69, 52, 68, 50, 70, 68, 48, 49, 67, 50, 67, 70, 66, 65, 49, 52, 65, 66, 48, 56, 50, 68, 51, 66, 51, 54, 51, 68, 54, 50, 65, 67, 49, 52, 56, 68, 50, 50, 65, 53, 70, 54, 49, 48, 55, 65, 54, 51, 68, 56, 48, 67, 57, 51, 57, 57, 68, 70, 70, 50, 48, 54, 52, 53, 52, 52, 52, 67, 53, 52, 54, 48, 67, 50, 48, 67, 65, 68, 55, 53, 50, 50, 55, 65, 48, 65, 68, 65, 57, 68, 49, 69, 52, 50, 67, 52, 53, 51, 67, 56, 66, 70, 66, 57, 51, 53, 70, 56, 67, 67, 66, 53, 56, 52, 68, 48, 66, 52, 57, 69, 67, 69, 55, 66, 51, 65, 57, 55, 49, 70, 68, 69, 54, 56, 57, 70, 51, 57, 67, 55, 54, 53, 48, 49, 52, 52, 52, 56, 49, 69, 49, 55, 55, 55, 69, 69, 67, 57, 57, 66, 51, 70, 57, 65, 52, 66, 57, 54, 57, 51, 51, 51, 67, 56, 69, 69, 53, 67, 57, 54, 68, 70, 50, 52, 52, 48, 69, 70, 65, 52, 67, 67, 50, 68, 57, 53, 53, 57, 49, 70, 50, 67, 49, 65, 68, 69, 69, 56, 68, 55, 52, 56, 50, 69, 68, 52, 50, 67, 67, 54, 49, 56, 54, 70, 68, 67, 69, 66, 54, 53, 65, 50, 54, 48, 57, 54, 52, 67, 48, 66, 52, 50, 50, 54, 57, 56, 66, 69, 67, 53, 67, 66, 66, 48, 70, 52, 48, 56, 52, 48, 68, 56, 59, 32, 95, 95, 121, 97, 111, 108, 100, 121, 121, 117, 105, 100, 61, 50, 50, 50, 52, 50, 49, 51, 56, 48, 51, 59, 32, 95, 121, 97, 115, 105, 100, 115, 61, 95, 95, 114, 111, 111, 116, 115, 105, 100, 37, 51, 68, 67, 55, 69, 66, 57, 67, 66, 50, 66, 67, 55, 48, 48, 48, 48, 49, 68, 57, 55, 49, 52, 51, 68, 48, 70, 54, 50, 48, 49, 70, 54, 51, 59, 32, 72, 109, 95, 108, 112, 118, 116, 95, 53, 49, 55, 48, 48, 98, 54, 99, 55, 50, 50, 102, 53, 98, 98, 52, 99, 102, 51, 57, 57, 48, 54, 97, 53, 57, 54, 101, 97, 52, 49, 102, 61, 49, 53, 50, 49, 55, 56, 48, 48, 50, 48, 59, 32, 104, 95, 117, 110, 116, 61, 49, 53, 50, 49, 55, 56, 48, 48, 50, 52, 92, 11, 18, myChid[0], myChid[1], myChid[2], myChid[3], 35, 0, 0, 0, 0, myChsid[0], myChsid[1], myChsid[2], myChsid[3], 50, 101, 58, 75, 173, 11, 140, 152, 12, 168, 12, 44 };
              return F;
          }
          byte[] NUMGET()
          {
              byte[] myID = Call.getRES(uid);
              byte[] fd = { 0, 3, 29, 0, 0, 91, 0, 0, 0, 91, 16, 3, 44, 60, 64, 18, 86, 6, 108, 105, 118, 101, 117, 105, 102, 16, 113, 117, 101, 114, 121, 67, 97, 114, 100, 80, 97, 99, 107, 97, 103, 101, 125, 0, 0, 46, 8, 0, 1, 6, 4, 116, 82, 101, 113, 29, 0, 0, 33, 10, 10, 12, 22, 0, 38, 0, 54, 0, 70, 0, 92, 11, 25, 0, 1, 3, 0, 0, 0, 0, myID[0], myID[1], myID[2], myID[3], 41, 12, 57, 12, 76, 92, 108, 11, 140, 152, 12, 168, 12, 44 };
              return fd;
          }
          byte[] Buybetpk(byte[] betnum, int num)
          {
              /*int alllen = 191 + strInfor.Length;//1=191 1700=192
              byte[] myID = Call.getRES(uid);
              byte[] myChid = Call.getRES(Call.id_);
              byte[] myChsid = Call.getRES(Call.sid_);
              // 8,206 (-8) 8,170 (-44) 8,156(-58)
              byte[] lenOf1 = Call.getRES((short)(alllen - 8));
              byte[] lenOf2 = Call.getRES((short)(alllen - 44));
              byte[] lenOf3 = Call.getRES((short)(alllen - 58));
              byte[] lenOfcookies = Call.getRES((short)(strInfor.Length));

              byte[] normalPacket = { 0, 3, 29, 0, 1, lenOf1[0], lenOf1[1], 0, 0, lenOf1[0], lenOf1[1], 16, 3, 44, 60, 64, 16, 86, 6, 103, 97, 109, 101, 117, 105, 102, 6, 98, 117, 121, 66, 101, 116, 125, 0, 1, lenOf2[0], lenOf2[1], 8, 0, 1, 6, 4, 116, 82, 101, 113, 29, 0, 1, lenOf3[0], lenOf3[1], 10, 10, 3, 0, 0, 0, 0, myID[0], myID[1], myID[2], myID[3], 22, 32, 48, 101, 55, 52, 97, 98, 98, 57, 97, 50, 100, 100, 56, 55, 53, 97, 49, 52, 54, 99, 55, 54, 102, 57, 55, 55, 102, 57, 52, 49, 98, 53, 38, 0, 54, 26, 119, 101, 98, 104, 53, 38, 49, 56, 48, 51, 50, 48, 49, 48, 53, 56, 38, 119, 101, 98, 115, 111, 99, 107, 101, 116, 71, 0, 0 };
              byte[] normal2 = lenOfcookies;
              byte[] normal3 = Encoding.UTF8.GetBytes(strInfor);
              byte[] normalEnding = { 92, 11, 18, myChid[0], myChid[1], myChid[2], myChid[3], 35, 0, 0, 0, 0, myChsid[0], myChsid[1], myChsid[2], myChsid[3] };

              byte[] normal6a = new byte[] { 50, 101, 58, 75, 173, 66, 7, 125, 240, 77, 80, 1, 102, 16, 98, 98, 100, 108, 52, 49, 97, 122, 97, 104, 57, 50, 106, 117, 57, 117, 112, 1, 134, 0, 11, 140, 152, 12, 168, 12, 44 };
              byte[] normal5A = new byte[] { 50, 101, 58, 75, 173, 66, gameid[0], gameid[1], gameid[2], gameid[3], 80, 1, 102, 17, 109, 56, 106, 53, 50, 49, 115, 101, 118, 102, 111, 54, 122, 110, 111, 100, 49, 113, betnum[0], betnum[1], 134, 0, 11, 140, 152, 12, 168, 12, 44 };
              // old id: byte[] normal5A = new byte[] { 50, 101, 58, 75, 173, 66, 7, 124, 90, 229, 80, 1, 102, 17, 109, 56, 106, 53, 50, 49, 115, 101, 118, 102, 111, 54, 122, 110, 111, 100, 49, 112, 1, 134, 0, 11, 140, 152, 12, 168, 12, 44};
              if (betnum.Length == 1)
              {
                  alllen--;
                  normal5A = new byte[] { 50, 101, 58, 75, 173, 66, gameid[0], gameid[1], gameid[2], gameid[3], 80, 1, 102, 17, 109, 56, 106, 53, 50, 49, 115, 101, 118, 102, 111, 54, 122, 110, 111, 100, 49, 112, betnum[0], 134, 0, 11, 140, 152, 12, 168, 12, 44 };

              }



              //種1的包




              //種1700的包

              //byte[] normal4B = new byte[]{50, 101, 58, 75, 173, 66, 7, 124, 70, 25, 80, 1, 102, 18, 116, 106, 103, 56, 104, 100, 107, 111, 109, 54, 111, 109, 121, 117, 104, 99, 49, 119, 113, 6, 164, 134, 0, 11, 140, 152, 12, 168, 12, 44};

              MemoryStream ms = new MemoryStream();
              ms.Write(normalPacket, 0, normalPacket.Length);
              ms.Write(normal2, 0, normal2.Length);
              ms.Write(normal3, 0, normal3.Length);
              ms.Write(normalEnding, 0, normalEnding.Length);
              ms.Write(normal5A, 0, normal5A.Length);
              byte[] demo = ms.ToArray();


              string v = Convert.ToBase64String(demo);
              return demo;

              return null;
          }

                 public void FillUserId(object obj)
        {
            /* try
             {
                 bool flag = obj != null;
                 if (flag)
                 {
                     Type type = obj.GetType();
                     PropertyInfo property = type.GetProperty("lUid");
                     bool flag2 = property != null;
                     if (flag2)
                     {
                         property.SetValue(obj, uid, null);
                     }
                     PropertyInfo property2 = type.GetProperty("sToken");
                     bool flag3 = property2 != null;
                     if (flag3)
                     {
                         string value = strInfor;// "boIBvDCCAbigAwIBBaEDAgEOogcDBQAAAAAAo4IBLWGCASkwggEloAMCAQWhERsPeXkuY29tAAAEAAEAqQ46ohEwD6ADAgEBoQgwBhsENTA2MKOB9zCB9KAEAgIBFaEDAgECooHmBIHjsAKA2bACgNlocUChaHFAoWaIjQRHPD9ewuYnJcuXCz6qlS03Obu/tHxhYJ1aysli0S4G+XkbE69AP/nC14joQQkMu434EPblmZ4ezPtxZKxEySvAykUx5J3PMtR4rpWoNQLpqys8gIQBKG5GPH90Ncj6ifD6y+BDAOGDLMBJ4DB7RHmm94UYj49lqxBhYxTE7Xk4hAjNQvNcu3F2krJdfkDk0Y9WC+BB6ep7x72LhsoG4/xoyu99oMIH2bDpkFAAYjLiSUW3puxfjw/M+3GK+BGfZsXHfSAAAAAAAAAAAAAAAACkcjBwoAMCARGiaQRn7hq7RU+1gC7YF90+2z86VnNQOYvlM2UHnz0qbca+1r23xBLRePiTja2ElS/ICnwRrzcnZww4ygjUqkc35n9Ts5gNJP6DiQKnARGzQSmtOah0gwTNgTdZgmHC4+6ep2jfuiwfk2bsbQ==";
                         property2.SetValue(obj, value, null);
                     }
                     PropertyInfo property3 = type.GetProperty("sHuYaUA");
                     bool flag4 = property3 != null;
                     if (flag4)
                     {
                         property3.SetValue(obj, "pc_exe&2.0&official", null);
                     }
                     PropertyInfo property4 = type.GetProperty("iTokenType");
                     bool flag5 = property4 != null;
                     if (flag5)
                     {
                         property4.SetValue(obj, 0, null);
                     }
                 }
             }
             catch (Exception)
             {
             }
    }







         */
    }
}