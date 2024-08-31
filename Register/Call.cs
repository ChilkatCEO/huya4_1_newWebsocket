using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
///using Noesis.Javascript;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml;
using Amib.Threading;

using System.Web;
namespace iHuya
{
    internal class Call
    {
        public static List<string> ChList = new List<string>();
        public static List<User3> UserList = new List<User3>();
        public static Manage manage;
        public static object obj = new object(), objLocktheroomid = new object();
        public static bool isGuest = true;
        public static string modeName = Guid.NewGuid().ToString().Replace("-", "");
        public static object os5 = new object();
        public static object oread = new object();
        public static string sendCon = "";
        public static bool isShutdown = false;
        public static bool isTask = false;
        public static object indexObj = new object();
        public static Dictionary<int, S5Struct> map = new Dictionary<int, S5Struct>();
        public static S5Struct[] S5ARRAY = null;
        public static Queue<HStruct> HTTPlist = new Queue<HStruct>();
        public static bool isCanLogin = true;
        public static int LoginIndex = 0;
        public static bool UseHTTP = false;
        public static string ProxyHTTP = string.Empty;
        public static int sleepChange = 1000;
        public static bool DanmuSender = false;
        public static bool isOpenLog = false;
        
        public static int sleepOfReRead = 0;
        static object testo = new object();
        public static string accnetstream = "";
        public static string versionflag = "FOXI_PLAYER";
        public static string sessionvid= Guid.NewGuid().ToString().Replace("-","").ToLower() + DateTime.Now.Ticks.ToString();
        public static Dictionary<string, string> runRoomID = new Dictionary<string, string>();
        [DllImport("kernel32.dll",
            CallingConvention = CallingConvention.Winapi)]
        public extern static int GetTickCount();
        public static log4net.ILog log = log4net.LogManager.GetLogger("KApp.Logging");

        public static bool isSet = false;
        public static SmartThreadPool stp, buhaotp;

        public static List<IWorkItemResult> t_lResultItem = new List<IWorkItemResult>();//不对IWorkItemResult定义其类型，其结果需要自己做类型转换
        public static string sDesc = "";
        public static string gType = "";
        public static long iPeoplex = 0;
        public static string gVersion = "4.0";
        public static bool isUsingSocks5 = false;
        public static bool isUsingSocks5WithWS = false;
        public static bool isUsingSocks5WithSvc = false;
        public static bool isReqSubscribe = false;
        public static string apiHuya = "";
        public static bool isUsingSocks5WithVideo = false;
        public static bool isAutoLocaltion = false;
        public static bool isOpenVideo = true;
        public static bool isWatch = true;
        public static bool isAwardBox= false;
        public static bool isRegisterBarrage =true;
        public static string[] useragent = Properties.Resources.webUserAgent.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        public static string saverpath = "";
        public static string pcAgent = "VLC/2.2.4 LibVLC/2.2.4";
        public static string imHost = "localhost";
        public static List<string> twiceLoginAccount = new List<string>();
        public static Queue<string> nonameaccount = new Queue<string>();
        public static string ExplorerAgent = "";
        public static string dmUser = "s657040137";
        public static string dmPass = "zq123456..";
        public static string dmType = "3000";
        public static string dmid = "117412";
        public static string dmkey = "218af9e46ad04497b3b0c395a4923a0e";
        public static string h5PlayerSdkVer = "Home";
        public static string OldYYUA = "pc_exe_template&4050300&official";
        public static string versions = "webh5&" + h5PlayerSdkVer;
        public static string pcUA = "pc_exe&3.5.4.0&official";//NEW
        public static string wxappUA = "wxapp&2.8.7&huya";
        public static string svFlag = "1901151749";//"1812271139";
        public static string svFlagPC = "20000308";
        public static string iphoneUA = "ios&6.9.1&store&12.1";
        public static string webUA = versions + "&websocket";//"pc_exe&3.0.0.0&official";
        public static string daochu = "";
        public static bool isTrySpoken = false;
        public static bool isAddMAUAL = false;
        public static string room_ID = "";
        static object jj = new object();
        static object jjf = new object();
        static object outOBJ = new object();
        //private static JavascriptContext ctx = new JavascriptContext();
        //protected static V8ScriptEngine engine = new V8ScriptEngine();
        internal static Chilkat.Http http = new Chilkat.Http();
        internal static int usePort;

        [DllImport("ocr.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern int www_51ocr_com_InitOCR(string templatefile);

        [DllImport("ocr.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern int www_51ocr_com_RECOG_1(string imagefile, StringBuilder text);

        [DllImport("ocr.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern int www_51ocr_com_RECOG_2(byte[] imagebuf, int size, int type, StringBuilder text);
        public static string outAUser()
        {
            string outs = "";
            try
            {

                lock (outOBJ)
                {
                    if (nonameaccount.Count <= 0)
                    {

                        string res = "";
                        while (true)
                        {
                            try
                            {
                                res = Call.http.QuickGetStr("https://111.231.19.42:8083/?getUserAccount|" + Call.sessionvid);
                            }
                            catch
                            {

                            }
                            if (res.Length > 100)
                                break;
                            if (res == "no_source")
                            {
                                Thread.Sleep(10000);
                            }
                        }
                        Chilkat.Crypt2 crypt = new Chilkat.Crypt2();

                        crypt.CryptAlgorithm = "arc4";

                        crypt.KeyLength = 128;


                        crypt.EncodingMode = "base64";

                        string keyHex = "3836356134393234613430383937616331666366653662346332636262303435";
                        crypt.SetEncodedKey(keyHex, "hex");
                        res = crypt.DecryptStringENC(res);
                        string[] arrv = res.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        Call.nonameaccount = new Queue<string>(arrv);


                    }
                    outs = nonameaccount.Dequeue();

                }

            }
            catch
            {

            }
            return outs;
        }
        public static void AddPeople(long peole)
        {
            lock (jj)
            {
                if (!(peole + 5 >= iPeoplex && peole - 5 <= iPeoplex))
                {
                    if (iPeoplex != peole || peole == 0)
                        iPeoplex = peole;
                }
            }
        }
        public static void AddDaochu(string a)
        {
            /*lock (jjf)
            {
                daochu += a + "\r\n";
            }*/
        }

        public static string URLEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        public static string URLDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }
        public static void ReConnectVideo()

        {
            new Thread(new ThreadStart(delegate ()
            {
                for (int i = 0; i < UserList.Count; i++)
                {
                    User3 a = UserList[i];
                    a.tryAntiCdn();
                    a.CloseVideo();
                }
            }))
            {
                IsBackground = true
            }.Start();


        }
        public static string convertUid(long t, long i)
        {
            long a = rotl64(t ^ i, 8) + i % 256;
            return a.ToString();
        }
        public static long rotl64(long t, long i)
        {

            var s = Call.turnStr(t, 2, 64);

            var a = s.Substring((int)i, 64 - (int)i) + s.Substring(0, (int)i);
            a = a.TrimStart('0');
            return Convert.ToInt64(a.ToString(), 2);
        }
        public static string turnStr(long e, int t, int i)
        {
            int a = 0;
            string s = System.Convert.ToString(e, t);//10进制
            a = s.Length;
            for (; a < i; a++)
                s = "0" + s;
            return s;
        }
        public static byte[] getProtoBuff(byte[] pbuff)
        {
            try
            {
                //IArrayBuffer i = (IArrayBuffer)(engine.Script.getWebSocketBuff(pbuff));
                return new byte[] { };//i.GetBytes()
            }
            catch
            {

            }
            return new byte[] { };

        }
        public static string Native2Ascii(string nativecode)
        {
            try
            {
                //var e = engine.Script.native2ascii(nativecode);
                return "null";
            }
            catch
            {

            }

            return "";
        }
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp(System.DateTime time)
        {
            long ts = ConvertDateTimeToInt(time);
            return ts.ToString();
        }
        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }

        public static string ruokuai(byte[] bytes, ref string topicid)
        {
            string res = "ojbkf2";
            try
            {
                byte[] data = bytes;
                var param = new Dictionary<object, object>
                        {
                            {"username",Call.dmUser},
                            {"password",Call.dmPass},
                            {"typeid",Call.dmType},
                            {"timeout","90"},
                            {"softid",Call.dmid},
                            {"softkey",Call.dmkey}
                        };
                string httpResult = RuoKuaiHttp.Post("http://api.ruokuai.com/create.xml", param, data);
                XmlDocument xmlDoc = new XmlDocument();
                string result = "";
                string topidid = "";
                try
                {
                    xmlDoc.LoadXml(httpResult);
                    XmlNode idNode = xmlDoc.SelectSingleNode("Root/Id");
                    XmlNode resultNode = xmlDoc.SelectSingleNode("Root/Result");
                    XmlNode errorNode = xmlDoc.SelectSingleNode("Root/Error");

                    if (resultNode != null && idNode != null)
                    {
                        topidid = idNode.InnerText;
                        result = resultNode.InnerText;
                        topicid = topidid;
                        res = result;

                    }
                    else if (errorNode != null)
                    {
                        Console.WriteLine("识别错误：" + errorNode.InnerText);

                    }
                    else
                    {
                        Console.WriteLine("识别错误unknown");
                    }
                }
                catch
                {
                    if (topidid != "")
                        reportError(topidid);
                    //report err
                }
            }
            catch
            {

                //report err
            }
            return res;
        }
        public static void reportError(string gtopic)
        {
            try
            {
                var param = new Dictionary<object, object>
                    {
                        {"username",Call.dmUser },
                        {"password",Call.dmPass},
                        {"id",gtopic}
                    };



                //提交服务器
                RuoKuaiHttp.Post("http://api.ruokuai.com/reporterror.xml", param);
            }
            catch
            {

            }

        }
        public static string OcrImage(byte[] bytes, int imageType = 4)
        {
            try
            {
                return 战火识别实现.imagetool.CreateInstance().hqCode(bytes, imageType);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static long GetTimeStampTen()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public static void Init(string path)
        {
            /* try
             {
                 www_51ocr_com_InitOCR(path);

             }
             catch
             {

             }*/

            // engine.Execute(Properties.Resources.core);
            //engine.AddHostType("Console", typeof(Console));






        }

        public static long getConvertUid(long uid, long pid)
        {

            return 0;
        }

        public static string EncryptToSHA1(string str)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] str1 = Encoding.UTF8.GetBytes(str);
            byte[] str2 = sha1.ComputeHash(str1);
            sha1.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < str2.Length; i++)
            {
                stringBuilder.Append(str2[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        /// <summary>  
               /// 连接代理服务器  
               /// </summary>  
               /// <param name="strRemoteHost"></param>  
               /// <param name="iRemotePort"></param>  
               /// <param name="sProxyServer"></param>  
               /// <returns></returns>  


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClientA"></param>
        /// <param name="LhS5Ip">LH代理服务器程序下开通的用户账号的IP地址</param>
        /// <param name="LhS5Port">LH代理服务器程序下开通的用户账号的端口</param>
        /// <param name="LhS5UserName">LH代理服务器程序下开通的用户账号的账号</param>
        /// <param name="LhS5UserPassword">LH代理服务器程序下开通的用户账号的密码</param>
        /// <param name="ConnType_">设置要代理的访问的目标类型 1=IP4  2=域名  此访问类型是告诉lh服务器要代理连接到的目标地址</param>
        /// <param name="TragetAddress">根据上方输入内容  IP4地址 或  域名</param>
        /// <param name="TragetProt">上方配套的连接地址对应的端口</param>
        /// <returns></returns>
        public static int SetConnection(ref System.Net.Sockets.Socket ClientA, string LhS5UserName, string LhS5UserPassword, int ConnType_, string TragetAddress, ushort TragetProt)
        {



            int Vindex = 0;
            int Size = 6 + System.Text.Encoding.ASCII.GetBytes(LhS5UserName + LhS5UserPassword).Count();
            if (ConnType_ == 2)
            {
                Size += 1 + Encoding.ASCII.GetBytes(TragetAddress).Count();
            }
            else
            {
                Size += 4;
            }

            byte[] Vbyte = new byte[Size];
            Vbyte[0] = 85;
            Vbyte[1] = (byte)System.Text.Encoding.ASCII.GetBytes(LhS5UserName).Count();
            Vindex = 2;
            foreach (byte i in System.Text.Encoding.ASCII.GetBytes(LhS5UserName))
            {
                Vbyte[Vindex] = i;
                Vindex += 1;
            };

            Vbyte[Vindex] = (byte)System.Text.Encoding.ASCII.GetBytes(LhS5UserPassword).Count();
            Vindex += 1;
            foreach (byte i in System.Text.Encoding.ASCII.GetBytes(LhS5UserPassword))
            {
                Vbyte[Vindex] = i;
                Vindex += 1;
            }

            switch (ConnType_)
            {
                case 1:
                    Vbyte[Vindex] = 1;
                    Vindex += 1;
                    foreach (byte i in System.Net.IPAddress.Parse(TragetAddress).GetAddressBytes())
                    {
                        Vbyte[Vindex] = i;
                        Vindex += 1;
                    }

                    break;
                case 2:
                    Vbyte[Vindex] = 2;
                    Vindex += 1;
                    Vbyte[Vindex] = (byte)System.Text.Encoding.ASCII.GetBytes(TragetAddress).Count();
                    Vindex += 1;
                    foreach (byte i in System.Text.Encoding.ASCII.GetBytes(TragetAddress))
                    {
                        Vbyte[Vindex] = i;
                        Vindex += 1;
                    }

                    break;
            }




            foreach (byte i in BitConverter.GetBytes(BitConverter.ToUInt16(BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(TragetProt)), 2)))
            {
                Vbyte[Vindex] = i;
                Vindex += 1;
            }
            ClientA.Send(Vbyte);

            Vbyte = new byte[2];
            Vindex = ClientA.Receive(Vbyte);
            if (Vindex < 2)
            {
                Console.WriteLine("获取服务器返回数据失败");
                ClientA.Close();
                return -1;
            }
            else
            {
                return Vbyte[1];
            }

        }

        public static string TestGet()
        {
            string reader = "";

            return reader;
        }
        public static string GetMD5String(string text)
        {
            try
            {
                byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                    stringBuilder.Append(array[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("encryption(md5)err:" + ex.ToString());
            }
            return "";
        }
        public static void AddLoginTaskT(int i)
        {
            stp.QueueWorkItem(
                        new WorkItemCallback(UserList[i].LoginHuya));
        }
        public static string bytesToHexString(byte[] bArr)
        {
            var encode = Encoding.UTF8;
            var bytes = bArr;
            var hex = BitConverter.ToString(bytes, 0).Replace("-", string.Empty).ToUpper();
            return hex;
        }

        public static string toXCodeArray(string str)
        {
            var x = new List<char>();
            for (var i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c < 128)
                {
                    x.Add(c);
                }
                else
                {
                    if (c < 2048)
                    {
                        x.Add((char)(192 | (c >> 6)));
                        x.Add((char)(128 | (c & 63)));
                    }
                    else
                    {
                        if (c < 55296 || c >= 57344)
                        {
                            x.Add((char)(224 | (c >> 12)));
                            x.Add((char)(128 | ((c >> 6) & 63)));
                            x.Add((char)(128 | (c & 63)));

                        }
                        else
                        {
                            i++;
                            c = (char)(65536 + (((c & 1023) << 10) | ((int)str[i] & 1023)));
                            x.Add((char)(240 | (c >> 18)));
                            x.Add((char)(128 | ((c >> 12) & 63)));
                            x.Add((char)(128 | ((c >> 6) & 63)));
                            x.Add((char)(128 | (c & 63)));

                        }
                    }
                }
            }
            return new string(x.ToArray());
}
        public static void AddLoginTask(int thr)
        {
            try
            {
                try
                {
                    if (stp != null)
                    {
                        stp.Shutdown();
                        buhaotp.Shutdown();
                        stp.Dispose();
                        buhaotp.Dispose();

                    }

                }
                catch
                {

                }
                STPStartInfo sTPStartInfo = new STPStartInfo();
                sTPStartInfo.IdleTimeout = -1;
                sTPStartInfo.MaxQueueLength = 3000;
                sTPStartInfo.MaxStackSize = 1024 * 1024;
                sTPStartInfo.MinWorkerThreads = 0;
                sTPStartInfo.MaxWorkerThreads = thr;
                stp = new SmartThreadPool(sTPStartInfo);

                buhaotp = new SmartThreadPool(-1, thr + 200, 1);

                for (int i = 0; i < UserList.Count; i++)
                {
                    UserList[i].isShutdown = Call.isShutdown;
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(delegate  { UserList[i].LoginHy(); }));
                    //Thread.Sleep(100);
                    stp.QueueWorkItem(
                        new WorkItemCallback(UserList[i].LoginHuya));
                }
                stp.Start();
            }
            catch
            {

            }

        }

        public static void getChannelArgs(string roomid, ref long pid, ref long mainid, ref long sid)
        {



            if (!runRoomID.ContainsKey(roomid))
            {
                lock (objLocktheroomid)
                {
                    string args = Call.http.QuickGetStr("https://www.huya.com/" + roomid + "?tempid=" + new Random().Next(0, 999));
                    if (args.Length <= 0) { pid = 0; mainid = 0; sid = 0; return; }
                    room_ID = roomid;
                    if (Call.StrcenterOf(args, "\"lp\":", ",").Contains("\"")){
                        runRoomID.Add(roomid, Call.StrcenterOf(args, "\"lp\":\"", "\"") + "-" + Call.StrcenterOf(args, "\"id\":\"", "\"") + "-" + Call.StrcenterOf(args, "\"sid\":\"", "\""));

                    }else
                    {
                        runRoomID.Add(roomid, Call.StrcenterOf(args, "\"lp\":", ",") + "-" + Call.StrcenterOf(args, "\"lp\":", ",") + "-" + Call.StrcenterOf(args, "\"lp\":", ","));

                    }

                    string huyaUA = Call.StrcenterOf(args, "\"h5PlayerIncludeSDK\":\"", "\"");
                    if (huyaUA != "")
                    {
                        h5PlayerSdkVer = huyaUA;
                        versions = "webh5&" + h5PlayerSdkVer;
                        webUA = versions + "&websocket";
                        //engine.Script.setUA(webUA);

                    }
                }
            }

            string getData = runRoomID[roomid];
            string[] idc = getData.Split('-');
            try
            {
                pid = long.Parse(idc[0]);
                mainid = long.Parse(idc[1]);
                sid = long.Parse(idc[2]);
            }
            catch
            {

            }


        }
        public static byte[] getRES(int var)
        {
            byte[] ret = BitConverter.GetBytes(var);
            Array.Reverse(ret);
            return ret;
        }
        public static byte[] getRES(long var)
        {
            byte[] ret = BitConverter.GetBytes(var);
            Array.Reverse(ret);
            return ret;
        }
        /// <summary>
        /// 随机产生常用汉字
        /// </summary>
        /// <param name="count">要产生汉字的个数</param>
        /// <returns>常用汉字</returns>
        public static string GenerateChineseWords(int count)
        {
            List<string> chineseWords = new List<string>();
            Random rm = new Random();
            Encoding gb = Encoding.GetEncoding("gb2312");
            string ret = "";
            for (int i = 0; i < count; i++)
            {
                // 获取区码(常用汉字的区码范围为16-55)
                int regionCode = rm.Next(16, 56);
                // 获取位码(位码范围为1-94 由于55区的90,91,92,93,94为空,故将其排除)
                int positionCode;
                if (regionCode == 55)
                {
                    // 55区排除90,91,92,93,94
                    positionCode = rm.Next(1, 90);
                }
                else
                {
                    positionCode = rm.Next(1, 95);
                }

                // 转换区位码为机内码
                int regionCode_Machine = regionCode + 160;// 160即为十六进制的20H+80H=A0H
                int positionCode_Machine = positionCode + 160;// 160即为十六进制的20H+80H=A0H

                // 转换为汉字
                byte[] bytes = new byte[] { (byte)regionCode_Machine, (byte)positionCode_Machine };
                ret += gb.GetString(bytes);
            }

            return ret;
        }
        public static byte[] getRES(uint var)
        {
            byte[] ret = BitConverter.GetBytes(var);
            Array.Reverse(ret);
            return ret;
        }
        public static byte[] getRES(short var)
        {
            byte[] ret = BitConverter.GetBytes(var);
            Array.Reverse(ret);
            return ret;
        }
        public static string StrcenterOf(string str, string leftstr, string rightstr)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return "";
                int i = str.IndexOf(leftstr) + leftstr.Length;
                int d = str.IndexOf(rightstr, i) - i;
                string temp = str.Substring(i, d);
                return temp;

            }
            catch
            {

            }
            return "";
        }
        public static void cInit()
        {
            try
            {
                //  ctx.Run(Properties.Resources.JS);
            }
            catch (Exception ex)
            {
                // MsgShow("启动时异常:" + ex.Message);
            }
        }
        public static void callbackS5(S5Struct s5d, int stated)
        {
            try
            {
                s5d.state = stated;
                // s5list.Enqueue(s5d);
            }
            catch (Exception ex)
            {
                //MsgShow("Socks5模块异常，请报告该问题 POS:2");
                throw ex;
            }
        }
        public static S5Struct readAS5(int index)
        {
            try
            {
                S5Struct s5d;
                lock (os5)
                {
                    if (index < map.Count)
                    { s5d = map[index]; }
                    else
                    {
                        Random rnd = new Random();
                        int rand = rnd.Next(0, map.Count - 1);
                        s5d = map[rand];
                    }
                }
                s5d.state = 1;
                return s5d;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static HStruct readAHP()
        {
            try
            {
                HStruct hp;
                lock (os5)
                {
                    while (true)
                    {
                        if (HTTPlist.Count > 0)
                        {
                            if (HTTPlist.Count <= 100)
                            {
                                lock (oread)
                                {
                                    getHTTPex(null);
                                }
                            }
                            hp = HTTPlist.Dequeue();
                            if (hp.HostName != string.Empty) break;
                        }
                        else
                        {
                            lock (oread)
                            {
                                getHTTPex(null);
                            }
                        }
                    }
                }
                return hp;
            }
            catch (Exception ex)
            {
                //MsgShow("HTTP代理模块异常，请报告该问题 POS:1");
                throw ex;
            }

        }
        public static byte[] getcenterofbytes(byte[] src, byte[] leftsrc, byte[] rightsrc)
        {
            int f = IndexOf(src, leftsrc);
            int f2 = IndexOf(src, rightsrc, f);
            if (f2 - f <= 0) return null;
            byte[] ret = new byte[f2 - leftsrc.Length - f];
            Array.Copy(src, f + leftsrc.Length, ret, 0, ret.Length);
            return ret;
        }
        public static int IndexOf(byte[] srcBytes, byte[] searchBytes, int beginIndex = 0)
        {
            if (srcBytes == null) { return -1; }
            if (searchBytes == null) { return -1; }
            if (srcBytes.Length == 0) { return -1; }
            if (searchBytes.Length == 0) { return -1; }
            if (srcBytes.Length < searchBytes.Length) { return -1; }
            for (int i = beginIndex; i < srcBytes.Length - searchBytes.Length; i++)
            {
                if (srcBytes[i] == searchBytes[0])
                {
                    if (searchBytes.Length == 1) { return i; }
                    bool flag = true;
                    for (int j = 1; j < searchBytes.Length; j++)
                    {
                        if (srcBytes[i + j] != searchBytes[j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) { return i; }
                }
            }
            return -1;
        }
        public static void doThreadTask(int index)
        {
            //Thread.Sleep(3000);
            Thread ths = new Thread(new ThreadStart(delegate () { UserList[index].LoginHy(); }));
            ths.IsBackground = true;
            ths.Start();

            //buhaotp.QueueWorkItem(new WorkItemCallback(UserList[index].LoginHuya));
        }

        public static void Login(int Thread)
        {
            LoginIndex = 0;

            new Thread(new ThreadStart(delegate () { AddLoginTask(Thread); }))
            {
                IsBackground = true
            }.Start();


            if (UseHTTP)
            {
                getHTTPex(null);
            }


        }

        public static int getIndex()
        {
            int ret = 0;
            lock (indexObj)
            {
                if (LoginIndex >= UserList.Count) return -1;
                ret = LoginIndex;
                LoginIndex++;
            }
            return ret;
        }
        public static void ThreadLogin(object o)
        {
            int my = (int)o;
            try
            {
                int index = my;
                while (true)
                {
                    index = getIndex();
                    if (index == -1) break;
                    UserList[index].isShutdown = false;
                    UserList[index].LoginHy();
                }


            }
            catch (Exception)
            {
                Call.manage.Msg(3, my, "[线程登录命令异常] 第" + my.ToString() + "个线程中");
            }

        }

        public static string GetPass(string pwd)
        {
            string ret = "";
            lock (obj)
            {
                //  ret = ctx.Run(";getPass(\"" + Call.Daoxu(pwd) + "\")").ToString();
            }
            return ret;
        }
        public static string Daoxu(string a)
        {
            char[] charArray = a.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static void Login(object o)
        {

            int os = (int)o;
            if (os >= UserList.Count) return;
            /*if (UseHTTP)
            {
                UserList[os].LoginH();
            }*/
            else UserList[os].LoginHy();
            // CreateLogin();
        }


        public static byte[] byteOfindex(byte[] need_search, byte[] Allofbyte)
        {
            int need_num = need_search.Length;
            byte[] searching = { };
            for (int i = 0; i < Allofbyte.Length; i++)
            {
                // Array.Copy()
            }
            return null;
        }

        public static void getHTTPex(object ob)
        {
            try
            {
                string ret = getHTTP();
                HStruct hs = new HStruct();
                if (ret != string.Empty)
                {
                    string[] arr = ret.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length != 0)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            string[] iparr = arr[i].Split(':');
                            if (iparr.Length == 2)
                            {
                                hs.HostName = iparr[0];
                                hs.Port = int.Parse(iparr[1]);
                            }
                            HTTPlist.Enqueue(hs);
                        }
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }
        public static string getHTTP()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Call.ProxyHTTP);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:5.0.1) Gecko/20100101 Firefox/5.0.1";
                request.AllowAutoRedirect = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response = (HttpWebResponse)request.GetResponse();
                string text = string.Empty;
                using (Stream responseStm = response.GetResponseStream())
                {
                    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                    text = redStm.ReadToEnd();
                }

                return text;

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
