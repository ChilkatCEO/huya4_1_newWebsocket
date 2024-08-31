using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Chilkat;
using iHuya.ProtoTool;
namespace iHuya
{


    class channel
    {

        Chilkat.Socket socket = new Chilkat.Socket();
        bool ssl = false;
        int maxWaitMillisec = 20000;
        bool success = false;
        public bool islogin { get; set; }
        ARC4 sr, rr;
        int pindex = 0;
        string vstream; long uid; long mainid;
        S5Struct s5x;

        public channel(string vstream, long uid, long mainid, S5Struct s5x, int pindex)
        {
            islogin = false;
            this.vstream = vstream;
            this.uid = uid;
            this.mainid = mainid;
            this.s5x = s5x;
            this.pindex = pindex;
            if (Call.isUsingSocks5WithSvc)
            {

                if (s5x.Socks5HostName != null && s5x.Socks5HostName.Length > 0)
                {
                    socket.SocksHostname = s5x.Socks5HostName;
                    socket.SocksPort = s5x.Socks5Port;
                    socket.SocksUsername = s5x.Socks5Usn;
                    socket.SocksPassword = s5x.Socks5Pwd;
                    //  Set the SOCKS version to 4 or 5 based on the version
                    //  of the SOCKS proxy server:
                    socket.SocksVersion = 5;
                }

            }
        }


        public bool login()
        {
            try
            {
                string[] svrlist = new string[]
                {
                    "119.97.171.25:483",
                    "202.102.11.26:453"
                };
                Random rnd = new Random();
                svrlist = svrlist[rnd.Next(0, svrlist.Length - 1)].Split(':');
                string serverip = svrlist[0];
                int port = int.Parse(svrlist[1]);
                //Connection
                Call.manage.Msg(4, pindex, "正在连接房间服务器..");
                success = socket.Connect(serverip, port, ssl, maxWaitMillisec);
                if (success != true)
                {
                    //Console.WriteLine(socket.LastErrorText);
                    return false;
                }

                //  Set maximum timeouts for reading an writing (in millisec)
                socket.MaxReadIdleMs = 10000;
                socket.MaxSendIdleMs = 10000;
                Call.manage.Msg(4, pindex, "发送1..");
                //RSA Request
                byte[] sendbuff = { 79, 0, 0, 0, 4, 17, 0, 0, 200, 0, 64, 0, 235, 132, 56, 39, 154, 191, 217, 252, 234, 200, 37, 220, 154, 151, 69, 231, 99, 219, 89, 20, 58, 138, 249, 43, 100, 172, 134, 88, 106, 250, 112, 223, 61, 179, 2, 236, 168, 146, 8, 21, 245, 186, 159, 248, 153, 157, 41, 27, 77, 143, 43, 9, 226, 57, 56, 135, 159, 167, 217, 168, 117, 63, 251, 185, 1, 0, 3 };
                socket.SendBytes(sendbuff);
                /*
                < RSAKeyValue >< Modulus > 64Q4J5q / 2fzqyCXcmpdF52PbWRQ6ivkrZKyGWGr6cN89swLsqJIIFfW6n / iZnSkbTY8rCeI5OIefp9modT / 7uQ ==</ Modulus >< Exponent > Aw ==</ Exponent >< P > +vmHOaTRLsyyXT8vzNp6OlXBo058mQyr / M4Bhm0CObE =</ P >< Q > 8Dt0JxkncXIzpRHaBe9r70ngLezua4P + FN6 + g0Dr3Ik =</ Q >< DP > p1EE0RiLdIh26NTKiJGm0Y6BF4moZghyqIlWWZ4Be8s =</ DP >< DQ > oCeixLtvoPbNGLaRWUpH9NvqyUie8lf + uJR / AitH6Fs =</ DQ >< InverseQ > pPQleRIolSUART + P999w1hfqcxbbicx1AxDSmVr9ipE =</ InverseQ >< D > nQLQGmcqkVNHMBk9vGTZRO085g18XKYc7chZkEdRoJOMVAUH8buaj1 / QNJ8vN4H2c / ORNE94b + kJUhEUhOFDqw ==</ D ></ RSAKeyValue >
                */
                Chilkat.BinData recver = new BinData();
                Call.manage.Msg(4, pindex, "接收1..");
                success = socket.ReceiveBd(recver);
                if (success != true)
                {
                    //Console.WriteLine(socket.LastErrorText);
                    return false;
                }
                string arr = Convert.ToBase64String(recver.GetBinary());
                Console.WriteLine(arr);
                byte[] decrypted = recver.GetBinaryChunk(12, 64);
                genrsa rsa = genrsa.getInstance();
                byte[] decryptData = null;
                try
                {
                    decryptData = rsa.decrypt(decrypted);
                }
                catch
                {
                    throw new Exception("decrypt err");
                }
                sr = new ARC4(decryptData, false);
                rr = new ARC4(decryptData, true);

                Call.manage.Msg(4, pindex, "登陆房间中..");
                success = LoginChannel();
                if (success != true)
                    return false;

                recver.Clear();
                Call.manage.Msg(4, pindex, "接收房间..");
                success = socket.ReceiveBd(recver);
                if (success != true || recver.NumBytes == 0)
                {
                    //Console.WriteLine(socket.LastErrorText);
                    return false;
                }

                decryptData = recver.GetBinary();
                rr.decrypt(decryptData);
                Console.WriteLine("pkt:login-resp:\n" + bytetool.fromArray(decryptData, false));
            }
            catch (Exception ex)
            {
                Call.log.Debug("ConnectSvcError:" + ex.ToString());
                return false;
            }
            return SendKeeper();
        }

        public bool SendKeeper()
        {
            try
            {
                BinData recver = new BinData();


                byte[] decryptData = null;

                //heartTest
                for (int i = 0; i < 2; i++)
                {
                    success = SendHeart();
                }

                if (success != true)
                    return false;

                recver.Clear();

                success = socket.ReceiveBd(recver);
                if (success != true || recver == null || recver.NumBytes == 0)
                {
                    //Console.WriteLine(socket.LastErrorText);
                    return false;
                }

                decryptData = recver.GetBinary();
                rr.decrypt(decryptData);
                Console.WriteLine("pkt:heart-resp:\n" + bytetool.fromArray(decryptData, false));




                recver.Clear();

                success = socket.ReceiveBd(recver);
                if (success != true || recver == null || recver.NumBytes == 0)
                {
                    //Console.WriteLine(socket.LastErrorText);
                    return false;
                }

                decryptData = recver.GetBinary();
                rr.decrypt(decryptData);
                if (decryptData == null)
                    return false;


                Console.WriteLine("pkt:heart002:\n" + bytetool.fromArray(decryptData, false));


                success = SessionKeeper();
                if (success != true)
                    return false;


                recver.Clear();

                success = socket.ReceiveBd(recver);
                if (success != true || recver == null || recver.NumBytes == 0)
                {
                    //Console.WriteLine(socket.LastErrorText);
                    return false;
                }

                decryptData = recver.GetBinary();
                rr.decrypt(decryptData);
                if (decryptData == null)
                    return false;


                Console.WriteLine("pkt:session:\n" + bytetool.fromArray(decryptData, false));

                islogin = true;
            }
            catch
            {
                return false;
            }
            return true;

        }

        bool SendHeart()
        {

            LOGINSEQ2 LS2 = new LOGINSEQ2(uid, mainid);
            LS2.marshall();
            Console.WriteLine(Convert.ToBase64String(LS2.getBuffer()));
            //{46,0,0,0,35,102,0,0,200,0,66,0,0,0,158,156,133,134,0,0,0,0,17,143,180,4,0,0,0,0,232,141,96,41,0,0,0,0,1,0,0,0,0,0,0,5}

            byte[] sented = LS2.getBuffer();//{ 46, 0, 0, 0, 35, 102, 0, 0, 200, 0, 66, 0, 0, 0, 58, 14, 169, 0, 0, 0, 0, 0, 17, 143, 180, 4, 0, 0, 0, 0, 181, 12, 155, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };// 


            sr.encrypt(sented);

            return socket.SendBytes(sented);
        }

        bool LoginChannel()
        {
            //vstream=Encoding.UTF8.GetString(new byte[]{ 57, 53, 52, 51, 49, 56, 54, 57, 45, 50, 50, 55, 56, 49, 53, 52, 55, 54, 48, 45, 57, 55, 56, 52, 54, 48, 48, 49, 56, 57, 52, 50, 54, 55, 50, 56, 57, 54, 48, 45, 50, 48, 49, 56, 55, 56, 57, 53, 52, 56, 45, 49, 48, 48, 53, 55, 45, 65, 45, 48, 45, 49});
            //vstream = "78941969-2559461593-10992803837303062528-2693342886-10057-A-0-1";
            // uid = 11079226;
            //mainid = 78941969;

            LOGINSEQ1 LS1 = new LOGINSEQ1(vstream, uid);
            LS1.marshall();
            byte[] sented = LS1.getBuffer();
            //{ 120, 0, 0, 0, 35, 206, 0, 0, 200, 0, 63, 0, 55, 56, 57, 52, 49, 57, 54, 57, 45, 50, 53, 53, 57, 52, 54, 49, 53, 57, 51, 45, 49, 48, 57, 57, 50, 56, 48, 51, 56, 51, 55, 51, 48, 51, 48, 54, 50, 53, 50, 56, 45, 50, 54, 57, 51, 51, 52, 50, 56, 56, 54, 45, 49, 48, 48, 53, 55, 45, 65, 45, 48, 45, 49, 3, 2, 0, 0, 58, 14, 169, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 192, 168, 2, 229, 179, 123, 0, 0, 0, 0, 0, 0, 8, 0, 50, 48, 48, 48, 48, 51, 48, 54, 0, 8 };// 
            //LS1.getBuffer(); 

            //

            //byte[] sendted2 = LS1.getBuffer();
            Console.WriteLine(Convert.ToBase64String(LS1.getBuffer()));
            sr.encrypt(sented);
            //socket.SendBytes(sendted2);
            return socket.SendBytes(sented);
        }

        bool SessionKeeper()
        {
            LOGINSEQ3 LS1 = new LOGINSEQ3(uid, vstream);
            LS1.marshall();
            Console.WriteLine(Convert.ToBase64String(LS1.getBuffer()));
            byte[] sented = LS1.getBuffer(); //{ 86, 0, 0, 0, 35, 200, 0, 0, 200, 0, 58, 14, 169, 0, 0, 0, 0, 0, 62, 0, 57, 53, 52, 51, 49, 56, 54, 57, 45, 50, 50, 55, 56, 49, 53, 52, 55, 54, 48, 45, 57, 55, 56, 52, 54, 48, 48, 49, 56, 57, 52, 50, 54, 55, 50, 56, 57, 54, 48, 45, 50, 48, 49, 56, 55, 56, 57, 53, 52, 56, 45, 49, 48, 48, 53, 55, 45, 65, 45, 48, 45, 49, 184, 1, 0, 0 };
            sr.encrypt(sented);

            return socket.SendBytes(sented);
        }
    }
}
