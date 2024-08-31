extern alias huyawatchframe;
extern alias huyaproto;
extern alias huyanetsvc;
extern alias huyawatchframeinformationview;
extern alias huyawatchframetreasurebox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using log4net;
using System.Threading;
using huyaproto::Wup;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;

namespace iHuya
{
    public partial class Form1 : Form
    {

        // static long timer = 0;
        Chilkat.Global gb;
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        static System.Threading.Timer timerA,timerB,timerC;


        bool unuse = true;
        public Form1()
        {

            InitializeComponent();
            getIMNetwork();
            /*if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Text += "(Set-1)";
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }*/
            Call.log.Debug("Application-init:Initialize");
            try
            {
                // Directory.CreateDirectory(Call.modeName);
            }
            catch
            {

                MessageBox.Show("创建文件目录失败。");
                return;
            }
            string rid = "", selected = "";
            try
            {
                rid = File.ReadAllText(Application.UserAppDataPath + "\\roomid.txt");
                selected = File.ReadAllText(Application.UserAppDataPath + "\\login.txt");
                tbstate.Text = Application.UserAppDataPath;
            }
            catch
            {

            }
            finally
            {
                if (rid != "")
                    tb_RoomID.Text = rid;
                if (selected != "")
                {
                    string[] sarr = selected.Split('|');
                    if (sarr.Length == 4)
                    {
                        if (sarr[0] == "1")
                            ckb_isdingyue.Checked = true;
                        if (sarr[1] == "1")
                            ckb_isguest.Checked = true;
                        if (sarr[2] == "1")
                            cb_opVideo.Checked = true;
                        if (sarr[3] == "1")
                            TimerReConn.Checked = true;
                    }
                }
            }

            Call.DanmuSender = false;
            Chilkat.Rest rest = new Chilkat.Rest();
            //Console.WriteLine(rest.Version);
            byte[] ret = i();
            Control.CheckForIllegalCrossThreadCalls = false;
            Call.manage = new Manage(this);
            Call.cInit();

            gb = new Chilkat.Global();
            gb.MaxThreads = 300;
            Call.Init(Application.StartupPath + "\\51ocr_yy_en.Templates");
            Call.saverpath = "C:\\userEvent\\biztoken\\";
            //Console.WriteLine("ocr's ans:" + 战火识别实现.imagetool.CreateInstance().hqCode(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAFAAAAAeCAIAAAA0IQ7mAAABxklEQVRYw+2YwbGEIAyG45tXi96WSizBC4V5sYStxKM24x5wIwYCAXFmdzUHRyP8EPkS0WpZFriS/V0q2jvgO+A74K+3f+5Gq3pz8hz1JQKeHwAA05AWbdP1eJ7aV6KMmjhQ6igV9x5uFADANMpmo7Zz0wU9QgVOELuT+WTrsytcg3mEouf3brzxP41rUrQqJylQECdA5uM2KIO0FDYf/3IF156jtrPDVcvLuDJIc3SVpdqezxHlBKS5us2N6lJHFLyXKE662/PJ5jkBaY7bKOdRLCWXqNZ0/TToI8kiQjoVIbdoe2+Zu41aj6S97SGC5yLdqr7e3PHltdu79dmicRWsoX8fd0PYnn0vfSLSNplCmE2QpsYaAgPcomcO8h+GvyTSxJIQilZvF1fSGNPK2yWv+EeRJhU1ASEOPKKMWxQ3BTCtGKR1yYDJm322iiRdSWZby4E3P+Ieb1pNg2663lv/iyHtAgbiDYbcL4QfgvW/FNLaHsALdhRd4jc6Nr2mZayka6+n3ArvP8cg9ulHtr5csyRzRzz++Vml/qYNvPQD9TYz4BOQrj78v3R4+10yhz/ECm45vmOFAx+Jvxlwcbv/S/+6vQBMbSdoPnZP+QAAAABJRU5ErkJggg==")));
            //Console.WriteLine("ocr's ans:"+Call.OcrImage(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAFAAAAAeCAIAAAA0IQ7mAAABxklEQVRYw+2YwbGEIAyG45tXi96WSizBC4V5sYStxKM24x5wIwYCAXFmdzUHRyP8EPkS0WpZFriS/V0q2jvgO+A74K+3f+5Gq3pz8hz1JQKeHwAA05AWbdP1eJ7aV6KMmjhQ6igV9x5uFADANMpmo7Zz0wU9QgVOELuT+WTrsytcg3mEouf3brzxP41rUrQqJylQECdA5uM2KIO0FDYf/3IF156jtrPDVcvLuDJIc3SVpdqezxHlBKS5us2N6lJHFLyXKE662/PJ5jkBaY7bKOdRLCWXqNZ0/TToI8kiQjoVIbdoe2+Zu41aj6S97SGC5yLdqr7e3PHltdu79dmicRWsoX8fd0PYnn0vfSLSNplCmE2QpsYaAgPcomcO8h+GvyTSxJIQilZvF1fSGNPK2yWv+EeRJhU1ASEOPKKMWxQ3BTCtGKR1yYDJm322iiRdSWZby4E3P+Ieb1pNg2663lv/iyHtAgbiDYbcL4QfgvW/FNLaHsALdhRd4jc6Nr2mZayka6+n3ArvP8cg9ulHtr5csyRzRzz++Vml/qYNvPQD9TYz4BOQrj78v3R4+10yhz/ECm45vmOFAx+Jvxlwcbv/S/+6vQBMbSdoPnZP+QAAAABJRU5ErkJggg==")));
            if (gb.UnlockBundle("SunStar"))
            {
                IntPtr sysMenuHandle = GetSystemMenu(this.Handle, false);
                AppendMenu(sysMenuHandle, MF_SEPARATOR, 0, string.Empty);//添加一个分隔线 
                AppendMenu(sysMenuHandle, MF_STRING, IDM_ABOUT, "关于(A)");
                unuse = false;
            }
            else
            {
                //string s=gb.LastErrorText;
                Call.log.Debug("Application-init:err,loadThirdPartyMoudleErr");
            }

            Console.WriteLine();
            //getbizToken("zz1904713623", "zyh5201314");
            // MessageBox.Show(gb.LastErrorText);
            /*  if (new Chilkat.Http().QuickGetStr("http://1e30y9.top:8081/isrun.txt") != "OKAY")
              {
                  Application.Exit();
                  this.Close();
                  Close();
              }
              else
              {*/

            //}
            readMsg();

        }
        void readMsg()
        {

            //Console.WriteLine("收到消息类型：" + webSocketCommand.iCmdType);
            //return webSocketCommand.vData.ToArray();
        }
        /// <summary> 
        /// 获取时间戳 10位
        /// </summary> 
        /// <returns></returns> 
        /// 
        public static long GetTimeStampTen()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public Form1(string[] args) : this()
        {
            try
            {

                if (!Directory.Exists("C:\\userEvent\\biztoken"))
                    Directory.CreateDirectory("C:\\userEvent\\biztoken");
                //string ret = Call.TestGet();
                string roomid = args[0];
                string thread = "50";// args[1];
                string fileofcookies = args[2];
                Call.manage.AddByFileAddr(fileofcookies);
                //Call.manage.AddVideoS5(fileofcookies);
                // Call.isUsingSocks5WithVideo = true;
                //timer = long.Parse(args[4]);
                Text = "[" + Call.versionflag + "]" + roomid + ":" + fileofcookies + ",Started:" + DateTime.Now.ToString();




                //string[] vars = File.ReadAllText(@"C:\UserBiz\OrderBackup\" + fileofcookies.Split('\\')[2] + ".txt").Split('|');

                //Call.accnetstream = vars[8];
                Call.manage.AddS5NoDialog(args[3]);
                string sarg = "";
                for (int a = 0; a < args.Length; a++)
                    sarg += args[a] + " , ";

                Call.log.Debug("Application-init:success[" + sarg + "]");
                try
                {
                    if (File.Exists("C:\\GUANBISHIPIN.TXT"))
                    {
                        Text += "(关闭视频)";
                        Call.isOpenVideo = false;
                    }
                    if (File.Exists("C:\\UNWATCHING.TXT"))
                    {
                        Text += "(不观看)";
                        Call.isWatch = false;
                    }
                }
                catch
                {

                }
                if (args.Length >= 5)
                {
                    //timer4.Enabled = true;
                    //File.WriteAllText("C:\\HuyaRenQiState\\" + args[4] + ".txt", Process.GetCurrentProcess().Id.ToString());
                }
                unuse = false;
                tb_thread.Text = thread;
                tb_RoomID.Text = roomid;
                if (args.Length > 0)
                    this.Hide();
                button1_Click_1(null, null);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool AppendMenu(IntPtr hMenu, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

        public const Int32 WM_SYSCOMMAND = 0x112;
        public const Int32 MF_SEPARATOR = 0x800;
        public const Int32 MF_STRING = 0x0;
        public const Int32 IDM_ABOUT = 10000;

        void getIMNetwork()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat = properties.GetIPv4GlobalStatistics();
            Console.WriteLine("  Inbound Packet Data:");
            Console.WriteLine("      Received ............................ : {0}",
            ipstat.ReceivedPackets);
            Console.WriteLine("      Forwarded ........................... : {0}",
            ipstat.ReceivedPacketsForwarded);
            Console.WriteLine("      Delivered ........................... : {0}",
            ipstat.ReceivedPacketsDelivered);
            Console.WriteLine("      Discarded ........................... : {0}",
            ipstat.ReceivedPacketsDiscarded);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
                switch (m.WParam.ToInt32())
                {
                    case IDM_ABOUT:
                        using (AboutBox dlg = new AboutBox())
                        {
                            dlg.ShowDialog();
                        }
                        return;
                    default:
                        break;
                }
            base.WndProc(ref m);
        }

        byte[] i()
        {
            byte[] f = BitConverter.GetBytes(11477271);
            Array.Reverse(f);
            return f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Call.manage.Add())
            {
                btn_AddS5.Enabled = true;
                AddS5V.Enabled = true;
            }

        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (AboutBox dlg = new AboutBox())
            {
                dlg.ShowDialog();
            }
        }

        private void msControl_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public static bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }
        void Testdecrypt()
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();

            // AES is also known as Rijndael.		
            crypt.CryptAlgorithm = "rc4";

            // CipherMode may be "ecb", "cbc", "ofb", "cfb", "gcm", etc.
            // Note: Check the online reference documentation to see the Chilkat versions
            // when certain cipher modes were introduced.
            // crypt.CipherMode = "ecb";

            // KeyLength may be 128, 192, 256
            crypt.KeyLength = 128;

            // The padding scheme determines the contents of the bytes
            // that are added to pad the result to a multiple of the
            // encryption algorithm's block size.  AES has a block
            // size of 16 bytes, so encrypted output is always
            // a multiple of 16.


            // EncodingMode specifies the encoding of the output for
            // encryption, and the input for decryption.
            // It may be "hex", "url", "base64", or "quoted-printable".
            crypt.EncodingMode = "base64";

            // An initialization vector is required if using CBC mode.
            // ECB mode does not use an IV.
            // The length of the IV is equal to the algorithm's block size.
            // It is NOT equal to the length of the key.
            string ivHex = "000102030405060708090A0B0C0D0E0F";
            crypt.SetEncodedIV(ivHex, "hex");

            // The secret key must equal the size of the key.  For
            // 256-bit encryption, the binary secret key is 32 bytes.
            // For 128-bit encryption, the binary secret key is 16 bytes.
            string keyHex = "3437336338373938333735333431643838343938303431353464313831616363";// "3836356134393234613430383937616331666366653662346332636262303435";
            crypt.SetEncodedKey(keyHex, "hex");
            string cc = "nsV97w9Sv/bWPbmOqBLrokNcYxVLUVIr9NQI4Z3kb7hPONuPUWGw7sTrIRsiogi+3/oYySIn6GDyh5S9jLbWupT4aawKoOCqYcOUVybnh5xhGUhUaBZgSjOn3/DoQicjrIacgrooXY3fIOvceeLxpb2/4QJjHhzUOh0zRYyZw6W99BtwSMk51jvITx49Cl0qQ6VA5fRFpxUVUQL7bPaOgqDJa+kQkmS5J5T0j5fz/yHYi3vq9ToJOoWU1olkhVwS5HfXONuI798gKvNUxarD6QsKbFNlHov1WjAfijbyWV0AhZGGwnNwUAA2swKJzBvVV5vmpkTAaj839iAiRFnMXaQUuSc0Kpj5iO439zLVwAyJA42884tGLdJrt8bySXDx3blKtV+ogUiJ70SSTepOQw6kN91xuC4bmbjGv/xMV8+zVf525FBUB29gugTsUyGAAVotyxAm5cfuOi6zIZhqC7rz39G9dkMgaWeiZnrTjDVAJ8/GDdxFrvx8uTnT/c/aAHj1jI6AhClQWHUvmx1PsKykmL9CsR1BOnOTnQYCWBg4Ip1WsnQ2y4t7FLyBS0gXTFpH3qibcd5tV/OCD3yuJCzQj6R4HGLepQmdz6YXtX2nvs3KKbYPyeev/nPHMswZrrFqaEO/zPAXDO+ka4zzlU1JvhejInvqmTVtB9/Rphd054ID+VIaVre6Ll3R6jbo51XkfuzJP3DkMNGOv2iGVXW2Zx9x8WcSHscg9GJ83APbdfxQ6OpAWiGjN2GksICNIQYRr/6";
            byte[] aa = crypt.DecryptBytesENC(cc);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(aa));
        }
        DateTime datetime = DateTime.Now;
        private void Form1_Load(object sender, EventArgs e)
        {
            timerA = new System.Threading.Timer(Timer8_Tick, null, 10000, 30000);
            timerB = new System.Threading.Timer(Timer9_Tick, null, 10000, 30000);

            //cb_opVideo.Checked = Call.isOpenVideo;
            LATEST.Text = "Old:" + Call.gVersion;
            Directory.CreateDirectory("C:\\DataCache");
            ReTry:

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


            string keyHex = Convert.ToBase64String(new byte[] { 2, 1, 9, 0, 4, 7, 1, 3, 6, 2, 3, 2, 0, 0, 2, 0, 1, 1, 9, 1, 1, 1, 0, 0, 0, 66, 99, 88 });
            crypt.SetEncodedKey(keyHex, "base64");
            string key = Guid.NewGuid().ToString();
            string sendKey = crypt.EncryptStringENC(key);
            Call.http.SetRequestHeader("Connection", "Keep-Alive");
            Call.http.SetRequestHeader("Connection", "Keep-Alive");
            Call.http.MaxConnections = 65535;
            Call.http.ConnectTimeout = 3;
            Call.http.ReadTimeout = 5;//wsapi-huya.yst.aisee.tv
            string api = "https://chilkat-1305478598.cos.ap-guangzhou.myqcloud.com/fingerprintcheck.txt";
            Call.apiHuya = Call.http.QuickGetStr(api);//// "cdnws.api.huya.com";

            
   

            //Console.WriteLine("ss:"+Call.getConvertUid(997815777, 1199512040120).ToString()); 
            Random rnd = new Random();
            int prt = rnd.Next(10000, 20000);
            while (true)
            {
                if (PortInUse(prt))
                {
                    prt = rnd.Next(10000, 50000);
                }
                else
                {
                    break;
                }
            }
            //Call.usePort = prt;//
            Call.usePort = prt;
            try
            {
                if (Call.usePort == 15260)
                {
                    Call.imHost = "127.0.0.1";// "111.231.19.42";
                }
                else
                {
                    Call.imHost = "127.0.0.1";
                    if (Call.isOpenVideo)
                        Process.Start("x\\videomanager.exe", prt.ToString() + " 0001");
                }

            }
            catch
            {

            }
      

            //new Test();
            //Console.WriteLine(requestPacket.context["1"]);
            // channel test = new channel("78941969-2699318348-11593484026152747008-958609000-10057-A-0-1", 11079226, 78941969);
            //test.login();

            /*
            ProtoBase pb=new ProtoBase();
            pb.unmarshall(new ByteArray(new byte[]{ 79, 0, 0, 0, 4, 17, 0, 0, 200, 0, 64, 0, 127, 237, 16, 173, 44, 234, 253, 131, 240, 109, 219, 236, 95, 173, 123, 44, 76, 150, 5, 76, 6, 173, 106, 169, 214, 242, 137, 210, 237, 102, 28, 120, 235, 241, 217, 123, 152, 166, 68, 238, 113, 248, 117, 54, 66, 131, 61, 125, 151, 204, 55, 219, 108, 156, 52, 65, 105, 207, 210, 118, 133, 238, 122, 1, 1, 0, 3 }));
            uint ss = pb.popInt();
            uint pp = pb.popInt();
            uint ps = pb.popShort();
            genrsa rsa = genrsa.getInstance();
            byte[] modules = rsa.getModules();
            byte[] n = rsa.getPublicKey();
            byte[] decryptData = rsa.decrypt(new byte[] { 218, 169, 120, 75, 50, 84, 178, 205, 220, 143, 111, 54, 26, 51, 136, 213, 184, 195, 105, 191, 7, 162, 60, 209, 6, 112, 81, 33, 88, 120, 179, 253, 168, 244, 165, 71, 254, 58, 221, 144, 173, 83, 32, 164, 136, 15, 67, 32, 84, 175, 53, 6, 139, 191, 31, 83, 107, 167, 205, 230, 239, 156, 70, 39 });
            byte[] enc = rsa.encrypt(new byte[] { 1, 2 });
            byte[] dec = rsa.decrypt(enc);
            //Console.WriteLine(0);
            // Call.A_Init("b250ba50dee29641a351178d6e0e24bd56fa9f95");
            */

        }

        private void listUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public static byte[] Bitmap2Byte(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
                return data;
            }
        }
        Thread thr = null;
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                timer8.Enabled = true;
                timer10.Enabled = true;
                timer7.Enabled = TimerReConn.Checked;
                Call.isOpenVideo = checkBox2.Checked;
                System.Threading.ThreadPool.SetMaxThreads(800, 800);
                System.Threading.ThreadPool.SetMinThreads(0, 0);
                Call.isGuest = ckb_isguest.Checked;
                Call.isReqSubscribe = ckb_isdingyue.Checked;
                unuse = false;
                if (!unuse)
                {
                    try
                    {
                        File.WriteAllText(Application.UserAppDataPath + "\\roomid.txt", tb_RoomID.Text);
                        File.WriteAllText(Application.UserAppDataPath + "\\login.txt", (ckb_isdingyue.Checked ? "1" : "0") + "|" + (ckb_isguest.Checked ? "1" : "0")
                            + "|" + (cb_opVideo.Checked ? "1" : "0") + "|" + (TimerReConn.Checked ? "1" : "0"));

                    }
                    catch
                    {

                    }

                    if (Call.ChList.Count < 1)
                    {
                        long pid = 0, ch = 0, sid = 0;
                        Call.getChannelArgs(tb_RoomID.Text, ref pid, ref ch, ref sid);
                        tb_Pid.Text = pid.ToString();
                        tb_channel.Text = ch.ToString();
                        tb_schannel.Text = sid.ToString();
                        Call.ChList.Add(tb_RoomID.Text);
                        //Call.runRoomID[tb_RoomID.Text] = "";
                        groupBox1.Text = "SETTINGS(" + Call.h5PlayerSdkVer + ")";
                    }
                    Call.sendCon = null;// tb_hh.Text;
                    int thnum = int.Parse(tb_thread.Text);
                    Call.UseHTTP = false;// cb_UseHttp.Checked;
                    /* if (!Call.UseHTTP)
                     {
                         if (thnum > Call.s5list.Count) Call.MsgShow("线程数不推荐大于SOCKS5数量");
                     }
                     else Call.ProxyHTTP = tb_http.Text;*/
                    Call.sleepOfReRead = 10000;
                    Call.sleepChange = 60000;
                    Call.Login(thnum);

                }
                Call.http.QuickGetStr("http://" + "localhost" + ":" + Call.usePort + "/?HeartBeat|" + Process.GetCurrentProcess().Id);
                //timerC = new System.Threading.Timer(Timer11_Tick, null, 0, 30000);

                    Thread thr = new Thread(new ThreadStart(delegate
                    {

                        while (true)
                        {
                            for (int i = 0; i < Call.UserList.Count; i++)
                            {
                                Call.UserList[i].reConnectVideo();
                                Thread.Sleep(10);
                            }
                            Thread.Sleep(2000);
                        }
                    }
                    ));
                    thr.IsBackground = true;
                    thr.Start();
        
            }
            catch (Exception ex)
            {
                Call.log.Debug(ex.ToString());
                // Call.MsgShow("登录异常\n\n" + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Call.isUsingSocks5 = true;
            Call.isUsingSocks5WithWS = true;
            Call.manage.AddS5();
            lb_s5num.Text = "PROXY " + Call.map.Count.ToString();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            Call.manage.AddChannel();
            if (Call.ChList.Count >= 1)
            {
                tb_RoomID.Enabled = false;
                Call.isTask = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //GC.Collect();
            //GC.WaitForPendingFinalizers();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            getIMNetwork();
            groupBox1.Visible = !groupBox1.Visible;

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void cb_loginres(string tk)
        {
            tbstate.Text = tk;
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            Call.ChList = new List<String>();
            Call.ChList.Add(tb_RoomID.Text);
            //tbstate.Text = "登录中。。";
            Call.manage.Addsingle(tb_username.Text, tb_passworrd.Text);
            //Call.UserList[0].cbres = cb_loginres;

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (GameType.Text != Call.gType)
                GameType.Text = Call.gType;
            if (sDesc.Text != Call.sDesc)
                sDesc.Text = Call.sDesc;
            if (iPeople.Text != Call.iPeoplex.ToString())
                iPeople.Text = Call.iPeoplex.ToString();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Call.isReqSubscribe = ckb_isdingyue.Checked;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(delegate (object o) { Call.UserList[int.Parse(lgnid.Text)].LoginHy(); }));
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void ckb_isguest_CheckedChanged(object sender, EventArgs e)
        {
            Call.isGuest = ckb_isguest.Checked;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Call.ReConnectVideo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("当导入代理测试视频时，连接成功后，将会在30秒后重新登录。");
            Call.manage.AddVideoS5();
            Call.isUsingSocks5WithVideo = true;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            UniPacket ssd = null;
            try
            {
                byte[] pack = File.ReadAllBytes("c:\\yytoken\\" + tb_fileaddr.Text + ".txt");
                //huyaproto::Wup.Jce.JceInputStream
                huyaproto::Wup.Jce.JceInputStream ss = new huyaproto::Wup.Jce.JceInputStream(pack);
                ssd = WupHelper.MakeupPacket(pack);

                ssd.Decode(pack);
                long ss3 = 0;
            }
            catch
            {
                MessageBox.Show("读文件错误。");
            }
            //ssd.Get("")
            // ss.
            //ss.Read(ss3, 3, false);
            //ss.wrap(pack,0);
            huyanetsvc::HUYA.UserEventReq UserEventReq = new huyanetsvc::HUYA.UserEventReq();
            //userHeartBeatReq.ReadFrom(ssd.("tReq"));
            UserEventReq = ssd.Get<huyanetsvc::HUYA.UserEventReq>("tReq");


        }


        public List<string> FindFile(string sSourcePath)
        {
            List<String> list = new List<string>();

            //在指定目录及子目录下查找文件,在list中列出子目录及文件

            DirectoryInfo Dir = new DirectoryInfo(sSourcePath);


            // DirectoryInfo[] DirSub = Dir.GetDirectories();

            //if (DirSub.Length <= 0)

            //{

            foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件

            {

                //listBox1.Items.Add(Dir+f.ToString()); //listBox1中填加文件名

                list.Add(f.Name);

            }

            // }


            /* int t = 1;

             foreach (DirectoryInfo d in DirSub)//查找子目录 

             {

                 FindFile(Dir + @"\" + d.ToString());

                 list.Add(Dir + @"\" + d.ToString());

                 if (t == 1)

                 {

                     foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件

                     {

                         list.Add(Dir + @"\" + f.ToString());

                     }

                     t = t + 1;

                 }

             }
             */
            return list;


        }
        private void button8_Click(object sender, EventArgs e)
        {

            UniPacket ssd = null;
            string pip = "";
            int pp = 0;
            try
            {
                byte[] pack = File.ReadAllBytes("c:\\yytoken\\" + tb_fileaddr.Text + ".txt");
                //huyaproto::Wup.Jce.JceInputStream
                huyaproto::Wup.Jce.JceInputStream ss = new huyaproto::Wup.Jce.JceInputStream(pack);
                ssd = WupHelper.MakeupPacket(pack);

                ssd.Decode(pack);
                string[] arr = File.ReadAllText("c:\\logininfo\\" + tb_fileaddr.Text + ".txt").Split(':');
                pip = arr[0];
                pp = Convert.ToInt32(arr[1]);
            }
            catch
            {
                MessageBox.Show("读文件错误。");
            }
            //ssd.Get("")
            // ss.
            //ss.Read(ss3, 3, false);
            //ss.wrap(pack,0);
            huyanetsvc::HUYA.UserEventReq UserEventReq = new huyanetsvc::HUYA.UserEventReq();
            //userHeartBeatReq.ReadFrom(ssd.("tReq"));
            UserEventReq = ssd.Get<huyanetsvc::HUYA.UserEventReq>("tReq");
            string url = "http://lgn.duowan.com/lgn/jump/authentication.do?appid=5060&busiId=5871&action=authenticate&ticket=" + UserEventReq.tId.sToken + "&busiUrl=http%3A%2F%2Fsz.duowan.com%2Fsuccess%2FgameLobby.html&direct=1";
            Chilkat.Http http = new Chilkat.Http();
            S5Struct s5x = new S5Struct();
            s5x.Socks5HostName = pip;
            s5x.Socks5Port = pp;
            s5x.Socks5Usn = tb_s5usn.Text;
            s5x.Socks5Pwd = tb_s5pwd.Text;
            http.SocksVersion = 5;
            http.SocksHostname = s5x.Socks5HostName;
            http.SocksPort = s5x.Socks5Port;
            http.SocksUsername = s5x.Socks5Usn;
            http.SocksPassword = s5x.Socks5Pwd;
            Chilkat.HttpResponse rsp = http.QuickGetObj(url);
            string cookie = "新Cookie:\r\n";
            if (rsp.NumCookies > 0)
            {

                for (int i = 0; i < rsp.NumCookies; i++)
                {
                    cookie += rsp.GetCookieName(i) + "=" + rsp.GetCookieValue(i) + "; ";
                }
            }
            tbstate.Text = cookie;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Threading.Thread TH = new System.Threading.Thread(new System.Threading.ThreadStart(thrun));
            TH.IsBackground = true;
            TH.Start();
        }
        void runs(object o)
        {
            string fn = (string)o;
            UniPacket ssd = null;
            string pip = "";
            int pp = 0;
            try
            {
                byte[] pack = File.ReadAllBytes("c:\\yytoken\\" + fn);
                //huyaproto::Wup.Jce.JceInputStream
                huyaproto::Wup.Jce.JceInputStream ss = new huyaproto::Wup.Jce.JceInputStream(pack);
                ssd = WupHelper.MakeupPacket(pack);

                ssd.Decode(pack);
                string[] arr = File.ReadAllText("c:\\logininfo\\" + fn).Split(':');
                pip = arr[0];
                pp = Convert.ToInt32(arr[1]);
            }
            catch
            {
                MessageBox.Show("读文件错误。");
            }
            //ssd.Get("")
            // ss.
            //ss.Read(ss3, 3, false);
            //ss.wrap(pack,0);
            huyanetsvc::HUYA.UserEventReq UserEventReq = new huyanetsvc::HUYA.UserEventReq();
            //userHeartBeatReq.ReadFrom(ssd.("tReq"));
            UserEventReq = ssd.Get<huyanetsvc::HUYA.UserEventReq>("tReq");
            string url = "http://lgn.duowan.com/lgn/jump/authentication.do?appid=5060&busiId=5871&action=authenticate&ticket=" + UserEventReq.tId.sToken + "&busiUrl=http%3A%2F%2Fsz.duowan.com%2Fsuccess%2FgameLobby.html&direct=1";
            Chilkat.Http http = new Chilkat.Http();
            S5Struct s5x = new S5Struct();
            s5x.Socks5HostName = pip;
            s5x.Socks5Port = pp;
            s5x.Socks5Usn = tb_s5usn.Text;
            s5x.Socks5Pwd = tb_s5pwd.Text;
            http.SocksVersion = 5;
            http.SocksHostname = s5x.Socks5HostName;
            http.SocksPort = s5x.Socks5Port;
            http.SocksUsername = s5x.Socks5Usn;
            http.SocksPassword = s5x.Socks5Pwd;
            Chilkat.HttpResponse rsp = http.QuickGetObj(url);

            string cookie = "";
            if (rsp != null && rsp.NumCookies > 0)
            {

                for (int j = 0; j < rsp.NumCookies; j++)
                {
                    cookie += rsp.GetCookieName(j) + "=" + rsp.GetCookieValue(j) + "; ";
                }
                Call.manage.AddSingleAccount(cookie, s5x);
            }

        }
        void thrun()
        {
            List<string> listusr = FindFile(@"C:\yytoken");
            for (int i = 0; i < listusr.Count; i++)
            {

                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(runs), listusr[i]);
                System.Threading.Thread.Sleep(100);

            }
        }
        void runs2(object o)
        {
            string fn = (string)o;
            UniPacket ssd = null;
            string pip = "";
            int pp = 0;
            try
            {
                byte[] pack = File.ReadAllBytes("c:\\yytoken\\" + fn);
                //huyaproto::Wup.Jce.JceInputStream
                huyaproto::Wup.Jce.JceInputStream ss = new huyaproto::Wup.Jce.JceInputStream(pack);
                ssd = WupHelper.MakeupPacket(pack);

                ssd.Decode(pack);
                string[] arr = File.ReadAllText("c:\\logininfo\\" + fn).Split(':');
                pip = arr[0];
                pp = Convert.ToInt32(arr[1]);
            }
            catch
            {
                MessageBox.Show("读文件错误。");
            }
            //ssd.Get("")
            // ss.
            //ss.Read(ss3, 3, false);
            //ss.wrap(pack,0);
            huyanetsvc::HUYA.UserEventReq UserEventReq = new huyanetsvc::HUYA.UserEventReq();
            //userHeartBeatReq.ReadFrom(ssd.("tReq"));
            UserEventReq = ssd.Get<huyanetsvc::HUYA.UserEventReq>("tReq");

            S5Struct s5x = new S5Struct();
            s5x.Socks5HostName = pip;
            s5x.Socks5Port = pp;
            s5x.Socks5Usn = tb_s5usn.Text;
            s5x.Socks5Pwd = tb_s5pwd.Text;





        }
        private void button10_Click(object sender, EventArgs e)
        {
            System.Threading.Thread TH = new System.Threading.Thread(new System.Threading.ThreadStart(thrun2));
            TH.IsBackground = true;
            TH.Start();
        }
        void thrun2()
        {
            List<string> listusr = FindFile(@"C:\yytoken");
            for (int i = 0; i < listusr.Count; i++)
            {

                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(runs2), listusr[i]);
                System.Threading.Thread.Sleep(200);

            }
        }
        void thrun3()
        {
            List<string> listusr = FindFile(@"C:\yytoken");
            for (int i = 0; i < listusr.Count; i++)
            {

                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(runs3), listusr[i]);
                System.Threading.Thread.Sleep(1);

            }
        }
        private void button6_Click_2(object sender, EventArgs e)
        {
            btn_AddS5.Enabled = true;
            System.Threading.Thread TH = new System.Threading.Thread(new System.Threading.ThreadStart(thrun3));
            TH.IsBackground = true;
            TH.Start();
        }
        void runs3(object o)
        {
            string fn = (string)o;
            UniPacket ssd = null;
            string pip = "";
            int pp = 0;
            try
            {
                byte[] pack = File.ReadAllBytes("c:\\yytoken\\" + fn);
                //huyaproto::Wup.Jce.JceInputStream
                huyaproto::Wup.Jce.JceInputStream ss = new huyaproto::Wup.Jce.JceInputStream(pack);
                ssd = WupHelper.MakeupPacket(pack);

                ssd.Decode(pack);
                string[] arr = File.ReadAllText("c:\\logininfo\\" + fn).Split(':');
                pip = arr[0];
                pp = Convert.ToInt32(arr[1]);
            }
            catch
            {
                MessageBox.Show("读文件错误。");
            }
            //ssd.Get("")
            // ss.
            //ss.Read(ss3, 3, false);
            //ss.wrap(pack,0);
            huyanetsvc::HUYA.UserEventReq UserEventReq = new huyanetsvc::HUYA.UserEventReq();
            //userHeartBeatReq.ReadFrom(ssd.("tReq"));
            UserEventReq = ssd.Get<huyanetsvc::HUYA.UserEventReq>("tReq");

            S5Struct s5x = new S5Struct();
            s5x.Socks5HostName = pip;
            s5x.Socks5Port = pp;
            s5x.Socks5Usn = tb_s5usn.Text;
            s5x.Socks5Pwd = tb_s5pwd.Text;


            Call.manage.AddSingleAccountToken(UserEventReq.tId.sToken, Convert.ToInt64(UserEventReq.tId.lUid), s5x);



        }

        private void timer6_Tickxx(object sender, EventArgs e)
        {


        }

        private void thrun_reLogin()
        {
            try
            {
                //timer7.Interval = 100000;
                if (Call.LoginIndex >= Call.UserList.Count - 1)
                {

                    for (int i = 0; i < Call.UserList.Count; i++)
                    {

                        Call.UserList[i].Shutdown();


                        Thread.Sleep(1);
                    }

                    Thread.Sleep(3000);
                    int thnum = int.Parse(tb_thread.Text);

                    Call.Login(thnum);
                }

            }
            catch
            {

            }

            //timer7.Enabled = true;

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("reLogin__Timer");
            Thread TH = new Thread(new ThreadStart(thrun_reLogin));
            TH.IsBackground = true;
            TH.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            huyaproto::Wup.RequestPacket requestPacket = new RequestPacket();

            requestPacket.ReadFrom(new huyaproto::Wup.Jce.JceInputStream(bytetool.strToToHexByte("0000021610022C3C4C56066D657472696366067265706F72747D000101F3080001060474526571180001060E485559412E4D65747269635365741D000101D20A0A023B7975E11620306134343164363433353530656135623532393966353863663638633731616127000001047751432F4141454441414141345856354F774141414141414141414141414141414151414E5441774E6851414E7A42684E444134596A677A4F445A6B4E6A45334E7A4D344D325945414455774D446143414149596A367262794459484B6A436D57393437364F45702F5964306F6E51683133556168737A64617A2F4E746C6C32436F6B366E4E48452F6234474962616D736D424C614D5875385257776F5151787750446654366D426852773463444D76455030347731485231704B364171392F74674648396C4E746C6C535134664B516A38356F7641642B2B47706D45626673426A67573947315650415863754C463239346E3674322B4679672B715077514141414141361770635F65786526332E322E302E30266F6666696369616C460050020B1900010A0612706C617965722E7032702E64657461696C731900040A0609616E63686F72756964160A313339343537353533340B0A0608636F6465726174651601300B0A06046C696E651601330B0A060A706C6179657274797065160A64787661706C617965720B2308D67F9CC7A36AE83C4C550000000000000000600F86000B0B8C980CA80C")));
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("c:\\1\\test1.txt", Call.daochu);
            }
            catch
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                Call.http.QuickGetStr("https://" + "localhost" + ":" + Call.usePort + "/?Closen");
            }
            catch
            {

            }

        }
        int jici = 0;
        private void Timer8_Tick(object sender)
        {

            try
            {

               
            }
            catch
            {

            }

        }

        string hasDownload = "";
        private void Timer9_Tick(object sender)
        {

            try
            {

                LATEST.Text = "Old:" + Call.gVersion;

                ReTry:

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
                string keyHex = Convert.ToBase64String(new byte[] { 2, 1, 9, 0, 4, 7, 1, 3, 6, 2, 3, 2, 0, 0, 2, 0, 1, 1, 9, 1, 1, 1, 0, 0, 0, 66, 99, 88 });
                crypt.SetEncodedKey(keyHex, "base64");
                string key = Guid.NewGuid().ToString();
                string sendKey = crypt.EncryptStringENC(key);

                string results = Call.http.QuickGetStr("https://111.231.19.42:8083/?getVersionx|" + sendKey);
                keyHex = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(key + "0010101120020119HAOGENB666"));

                crypt.SetEncodedKey(keyHex, "base64");

                results = crypt.DecryptStringENC(results);

                if (results == "banUser")
                {
                    Text = "Baned User"; Console.WriteLine("Baned Exit");
                    Environment.Exit(0);


                }
                if (results == null || results == "")
                {
                    Thread.Sleep(5000);
                    goto ReTry;
                }

                string newVer = Call.StrcenterOf(results, "TheLatest=", "&");
                Call.apiHuya = Call.StrcenterOf(results, "API_HUYA=", "&");//"cdnws.api.huya.com"
                NewVERSION.Text = "New:" + newVer;


            }
            catch
            {

            }
        }

        private void Timer10_Tick(object sender, EventArgs e)
        {
            if (lbMsg.Items.Count > 100)
                lbMsg.Items.Clear();
            this.lbMsg.Items.Add(DateTime.Now.ToString() + " [ " + iPeople.Text + " ]");
            this.lbMsg.TopIndex = this.lbMsg.Items.Count - (int)(this.lbMsg.Height / this.lbMsg.ItemHeight);
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            Call.isTrySpoken = checkBox1.Checked;
        }
        void getOL()
        {
            try
            {

                try
                {
                    Chilkat.Http h = new Chilkat.Http();
                    string args = h.QuickGetStr("https://www.huya.com/" + Call.room_ID + "?tempid=" + new Random().Next(0, 999));
                    string ol = Call.StrcenterOf(args, "\"totalCount\":", ",");
                    Call.AddPeople(long.Parse(ol));
                }
                catch
                {

                }


            }
            catch
            {

            }

        }
        private void Timer11_Tick(object sender)
        {
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Call.isOpenVideo = checkBox2.Checked;
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            thr = new Thread(new ThreadStart(delegate
            {

                getOL();
            }
                   ));
            thr.IsBackground = true;
            thr.Start(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Call.UserList[int.Parse(tb_RoomID.Text)].GetLivingInfo();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Call.UserList[int.Parse(tb_RoomID.Text)].setSocketTimer();
        }
    }
}
