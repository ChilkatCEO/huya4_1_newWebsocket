extern alias huyawatchframe;
extern alias huyaproto;
extern alias huyanetsvc;
extern alias huyawatchframeinformationview;
extern alias huyawatchframetreasurebox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huyaproto::Wup;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using iHuya.ProtoTool;
using huyawatchframe::Huya.WatchFrame;
using System.Collections.ObjectModel;
using huyawatchframe::Huya.WatchFrame.VideoStream;
using System.Threading;

namespace iHuya
{
    class Guest
    {
        string sHuYaUA = Call.webUA;
        bool useProxy = false;
        S5Struct s5x;
        int eop = 1;
        long id = 0;
        long sid = 0;
        long uid = 0;
        long pid = 0;
        string sGuid = "0e74abbcc485d05b6e9f99099a09405a";
        Chilkat.Rest rest = null;
        Chilkat.WebSocket ws = null;
        Chilkat.Socket socket = null;
        huyawatchframe.HUYA.StreamInfo streamsinfo;
        string cookie = "";
        public Timer ReLoginTimer, HBevent;

        public Guest(S5Struct s5x, string cookie, long id, long sid, long pid)
        {
            if (s5x.Socks5HostName != null)
                useProxy = true;
            this.s5x = s5x;
            this.cookie = cookie;
            this.id = id;
            this.sid = sid;
            this.pid = pid;
            this.HBevent = new Timer(new TimerCallback(this.HB));
            ReLoginTimer = new Timer(new TimerCallback(this.ReLgn));
        }

        private void ReLgn(object state)
        {
            try
            {
                if (HBevent != null)
                    HBevent.Change(-1, -1);
                ReLoginTimer.Change(-1, -1);
                if (Call.isGuest)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object o)
                    {
                        while (true)
                        {

                            if (this.Login())
                                break;
                            Thread.Sleep(8000);
                        }
                    }));
                }

            }
            catch (Exception)
            {

            }
        }

        private void HB(object state)
        {
            try
            {

                SendUe();
                SendWSHeart();
            }
            catch
            {

                ReLoginTimer.Change(15000, 15000);
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
        private bool ConnectTo()
        {

            //Console.WriteLine(UserName + "-------------\n" + retofchecked + "\n-------------\n");
            rest = new Chilkat.Rest();
            if (socket != null)
                socket.Dispose();

            socket = new Chilkat.Socket();

            ///登录方式：50%的新版(pc)，50%老版(web)
            if (useProxy)
            {



                socket.SocksHostname = s5x.Socks5HostName;
                socket.SocksPort = s5x.Socks5Port;
                socket.SocksVersion = 5;

                //  Provide authentication to the SOCKS proxy, if needed.
                socket.SocksUsername = s5x.Socks5Usn;
                socket.SocksPassword = s5x.Socks5Pwd;

                socket.MaxReadIdleMs = 20000;
                socket.MaxSendIdleMs = 10000;



            }


            int maxWaitMs = 15000;
            string connIP = "ws.api.huya.com";// "cdnws.api.huya.com";
            int port = 80;
            // if (!isTest)
            //{ connIP = "ws.api.huya.com"; port = 80; }//7d58990d-ws.va.huya.com
            bool success = socket.Connect(connIP, port, false, maxWaitMs);
            //bool success = socket.Connect("ws.api.huya.com", port, bTls, maxWaitMs);
            if (success != true)
                throw new Exception("连接远程失败");

            //  Tell the Rest object to use the connected socket.
            success = rest.UseConnection(socket, true);
            if (success != true)
                throw new Exception("连接远程失败");

            ws = new Chilkat.WebSocket();

            //  Tell the WebSocket to use this connection.
            success = ws.UseConnection(rest);

            if (success != true)
                throw new Exception("对接会话失败");

            ws.AddClientHeaders();
            rest.AddHeader("Origin", "http://www.huya.com");

            rest.AddHeader("Cookie", cookie);

            rest.FullRequestNoBody("GET", "/");

            success = ws.ValidateServerHandshake();
            if (success != true)
                throw new Exception("会话认证时被拒绝");


            return success;
        }
        public bool Login()
        {
            try
            {

                if (!ConnectTo()) return false;
                RegisterChan();
                wsuserinfo();
                huyawatchframe::HUYA.GetLivingInfoReq getLivingInfoReq = new huyawatchframe::HUYA.GetLivingInfoReq();


                getLivingInfoReq.tId = new huyawatchframe::HUYA.UserId();
                getLivingInfoReq.tId.lUid = this.uid;

                getLivingInfoReq.tId.sCookie = this.cookie;
                getLivingInfoReq.tId.sHuYaUA = sHuYaUA;
                getLivingInfoReq.tId.sGuid = sGuid;
                getLivingInfoReq.lTopSid = id;
                getLivingInfoReq.lSubSid = sid;
                getLivingInfoReq.lPresenterUid = pid;
                getLivingInfoReq.tId.iTokenType = 0;


                UniPacket packue = WupHelper.MakeupPacket<huyawatchframe::HUYA.GetLivingInfoReq>(getLivingInfoReq, "liveui", "getLivingInfo");


                Send(GetWebPacket(packue.Encode()));
                byte[] ret = DecodeWebPack(Recv());// PostData(packue.Encode());


                huyawatchframe::HUYA.GetLivingInfoRsp getLivingInfoRsp = WupHelper.PacketToResp<huyawatchframe::HUYA.GetLivingInfoRsp>(WupHelper.MakeupPacket(ret));

                if (getLivingInfoRsp == null)
                {
                    throw new Exception("获取直播信息错误");
                }
                int isLiving = getLivingInfoRsp.bIsLiving;
                this.pid = getLivingInfoRsp.tNotice.lPresenterUid;
                this.id = getLivingInfoRsp.tNotice.lChannelId;
                this.sid = getLivingInfoRsp.tNotice.lSubChannelId;

                huyawatchframe::HUYA.StreamInfo streamInfoOfP2p = null, streamInfoOfFlv = null;
                huyawatchframe::Huya.WatchFrame.VideoStream.StreamItem playingOut = new StreamItem();
                if (isLiving != 0 && getLivingInfoRsp.tNotice.vStreamInfo.Count > 0)
                {
                    int _iDefaultBitRateFromServer = getLivingInfoRsp.tNotice.iPCDefaultBitRate;//码率


                    ObservableCollection<LineItem> vlines = new ObservableCollection<LineItem>();
                    bool isHevc = false;

                    StreamLineHandle(getLivingInfoRsp.tNotice, ref playingOut, ref vlines, getLivingInfoRsp.tStreamSettingNotice.iBitRate, isHevc);

                    streamInfoOfFlv = playingOut.StreamInfo;
                    streamInfoOfP2p = playingOut.StreamInfo;
                }
                //Call.AddPeople(getLivingInfoRsp.tNotice.lAttendeeCount);
                streamsinfo = playingOut.StreamInfo;
                UserChannelReq ucr = new UserChannelReq(cookie, uid, id, sid);
                Send(GetWebPacket(ucr.marshall()));

                OnReady onready = new OnReady(cookie, uid, id, sid);
                Send(GetWebPacket(onready.marshall()));
                SendUe();
                SendWSHeart();
                HBevent.Change(15000, 15000);
            }
            catch
            {
                return false;
            }
            return true;
        }
        bool SendUe()
        {
            huyawatchframe::HUYA.UserEventReq userEventReq = new huyawatchframe::HUYA.UserEventReq();

            userEventReq.tId = new huyawatchframe::HUYA.UserId();
            userEventReq.tId.lUid = this.uid;

            userEventReq.tId.sCookie = this.cookie;
            userEventReq.tId.sHuYaUA = sHuYaUA;
            userEventReq.tId.sGuid = sGuid;

            //this.loginProxy.FillUserId(userEventReq.tId);
            userEventReq.lTid = id;
            userEventReq.lSid = sid;
            userEventReq.lPid = pid;//presenter
            userEventReq.eOp = eop;// (tafRegister.bRegister ? 1 : 2);
            huyaproto::Wup.UniPacket packue = WupHelper.MakeupPacket<huyawatchframe::HUYA.UserEventReq>(userEventReq, "onlineui", "OnUserEvent");

            byte[] sss = GetWebPacket(packue.Encode());


            Send(sss);

            byte[] rets = Recv();
            if (rets.Length <= 0)
            {
                throw new Exception();
            }


            //huyawatchframe::HUYA.UserEventRsp userEventRsp = WupHelper.PacketToResp<huyawatchframe::HUYA.UserEventRsp>(WupHelper.MakeupPacket(rets));

            return true;
        }
        int SendWSHeart(bool bWatchVideo = true, bool post = false)
        {
            huyanetsvc::HUYA.UserHeartBeatReq userHeartBeatReq = new huyanetsvc::HUYA.UserHeartBeatReq();
            userHeartBeatReq.tId = new huyanetsvc::HUYA.UserId();
            userHeartBeatReq.tId.lUid = this.uid;
            userHeartBeatReq.tId.sCookie = this.cookie;
            userHeartBeatReq.tId.sHuYaUA = sHuYaUA;
            userHeartBeatReq.tId.sGuid = sGuid;
            userHeartBeatReq.bWatchVideo = bWatchVideo;

            userHeartBeatReq.lTid = id;
            userHeartBeatReq.lSid = sid;
            userHeartBeatReq.lShortTid = 0;
            userHeartBeatReq.lPid = pid;

            UniPacket pack = WupHelper.MakeupPacket<huyanetsvc::HUYA.UserHeartBeatReq>(userHeartBeatReq, "onlineui", "OnUserHeartBeat");

            Send(GetWebPacket(pack.Encode()));
            this.Recv();
            return 0;

        }
        void RegisterChan()
        {
            WSVerify wsVerify = new WSVerify(cookie, uid, sGuid);
            this.Send(wsVerify.marshall());

            byte[] test = this.Recv();
            wsVerify.unmarshall(test);



            if (wsVerify.iValidate == 0)
            {

                eop = 1;
            }
            else
            {


                eop = 2;
            }


        }
        void Send(byte[] buff)
        {
            Chilkat.BinData bd = new Chilkat.BinData();
            bd.AppendBinary(buff);//getRegisterPk
            if (!ws.SendFrameBd(bd, true))
                throw new Exception(ws.LastErrorText);

        }
        byte[] Recv()
        {


            byte[] recvBuff = null;
            Chilkat.BinData recvBd = new Chilkat.BinData();
            bool receivedFinalFrame = false, success = false;
            while (receivedFinalFrame == false)
            {


                success = ws.ReadFrame();
                if (success != true)
                    throw new Exception(ws.LastErrorText);
                receivedFinalFrame = ws.FinalFrame;
            }

            if (!ws.GetFrameDataBd(recvBd))
            {
                throw new Exception("Buffer is null");
            }

            recvBuff = recvBd.GetBinary();
            return recvBuff;
        }

        void verifyHuyaToken()
        {
            huyanetsvc::HUYA.WSVerifyHuyaTokenReq wsverifyHuyaTokenReq = new huyanetsvc::HUYA.WSVerifyHuyaTokenReq();
            wsverifyHuyaTokenReq.tId = new huyanetsvc::HUYA.UserId();
            wsverifyHuyaTokenReq.tId.lUid = uid;
            wsverifyHuyaTokenReq.tId.iTokenType = 0;
            wsverifyHuyaTokenReq.tId.sToken = "";
            wsverifyHuyaTokenReq.bAutoRegisterUid = 1;
            huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
            webSocketCommand.iCmdType = 12;
            huyaproto::Wup.Jce.JceOutputStream jceOutputStream = new huyaproto::Wup.Jce.JceOutputStream();
            wsverifyHuyaTokenReq.WriteTo(jceOutputStream);
            webSocketCommand.vData = new List<byte>(jceOutputStream.toByteArray());
            huyaproto::Wup.Jce.JceOutputStream jceOutputStream2 = new huyaproto::Wup.Jce.JceOutputStream();
            webSocketCommand.WriteTo(jceOutputStream2);
            Send(jceOutputStream2.toByteArray());
            byte[] test = this.Recv();
            WSVerify wsVerify = new WSVerify("", 0, "");
            wsVerify.unmarshall(test);



            if (wsVerify.iValidate == 0)
            {
                eop = 1;

            }
            else
            {

                eop = 2;
            }

        }
        byte[] DecodeWebPack(byte[] pack)
        {
            huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
            webSocketCommand.ReadFrom(new huyaproto::Wup.Jce.JceInputStream(pack));
            Console.WriteLine("收到消息类型：" + webSocketCommand.iCmdType);
            return webSocketCommand.vData.ToArray();
        }
        byte[] GetWebPacket(byte[] pack)
        {
            huyanetsvc::HUYA.WebSocketCommand webSocketCommand = new huyanetsvc::HUYA.WebSocketCommand();
            webSocketCommand.iCmdType = 3;
            webSocketCommand.vData = new List<byte>(pack);

            huyaproto::Wup.Jce.JceOutputStream jceOutputStream = new huyaproto::Wup.Jce.JceOutputStream();
            webSocketCommand.WriteTo(jceOutputStream);
            byte[] array = jceOutputStream.toByteArray();
            return array;
        }
        void GetCdnMsg(huyawatchframe::HUYA.StreamInfo streamInfo)
        {
            huyawatchframe::HUYA.GetCdnTokenReq getCdnTokenReq = new huyawatchframe::HUYA.GetCdnTokenReq();

            getCdnTokenReq.stream_name = streamInfo.sStreamName;
            getCdnTokenReq.cdn_type = streamInfo.sCdnType;



            UniPacket packue = WupHelper.MakeupPacket<huyawatchframe::HUYA.GetCdnTokenReq>(getCdnTokenReq, "liveui", "getCdnTokenInfo");

            Send(GetWebPacket(packue.Encode()));

            byte[] ret = Recv();


        }

        private string OnCdnTokenAction(huyawatchframe::HUYA.GetCdnTokenRsp pack, object obj)
        {
            try
            {
                huyawatchframe::HUYA.GetCdnTokenRsp getCdnTokenRsp = pack;
                StreamItem streamItem = obj as StreamItem;
                string text = "";
                if (getCdnTokenRsp != null)
                {
                    int rate = 2000;
                    bool flag = false;
                    bool flag2 = false;


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
                            text = string.Format("{0}/{1}.flv?{2}&codec=264", streamItem.StreamInfo.sFlvUrl, streamItem.StreamInfo.sStreamName, getCdnTokenRsp.flv_anti_code);
                        }
                        else
                        {
                            rate = 2000;// streamItem.MultiStreamInfo.iBitRate;
                            text = string.Format("{0}/{1}.flv?{2}&ratio={3}&codec=264", new object[]
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
                        text = string.Format("{0}/{1}.flv?{2}&codec=264", streamItem.StreamInfo.sFlvUrl, streamItem.StreamInfo.sStreamName, getCdnTokenRsp.flv_anti_code);
                    }
                    else
                    {
                        rate = 2000;// streamItem.MultiStreamInfo.iBitRate;
                        text = string.Format("{0}/{1}.flv?{2}&ratio={3}&codec=264", new object[]
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

                    Console.WriteLine(obj2);
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
                        Console.WriteLine(log);

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
                                Console.WriteLine(log2);
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
                                Console.WriteLine(log3);
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
                    Random rrnd = new Random();
                    playingStreamOut = lineItem.vStreamItems[rrnd.Next(0, lineItem.vStreamItems.Count)];
                }
            }
            catch (Exception ex2)
            {

            }
        }
        private static int GetRecommendRateIndex(ObservableCollection<StreamItem> items, int defaultRate)
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
            wsuserInfo.lTid = id;
            wsuserInfo.lSid = sid;
            wsuserInfo.lUid = uid;
            wsuserInfo.lGroupId = 0L;
            wsuserInfo.lGroupType = 0L;
            wsuserInfo.bAnonymous = true;
            wsuserInfo.sToken = "";
            wsuserInfo.sGuid = sGuid;


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
            data = Recv();

            huyanetsvc::HUYA.WebSocketCommand WC = new huyanetsvc::HUYA.WebSocketCommand();
            WC.ReadFrom(new huyaproto::Wup.Jce.JceInputStream(data));

            huyaproto::Wup.Jce.JceInputStream is4 = new huyaproto::Wup.Jce.JceInputStream(WC.vData.ToArray());
            huyanetsvc::HUYA.WSRegisterRsp wrr = new huyanetsvc::HUYA.WSRegisterRsp();
            wrr.ReadFrom(is4);


            return;


        }
    }
}
