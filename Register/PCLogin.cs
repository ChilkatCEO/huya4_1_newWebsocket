using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdbLogin;
namespace HUYA
{
    class PCLogin
    {
        string usr = "";
        string pwd = "";
        public string uid="", id="", token="";

        public int tokenType = 0;

        public string state = "";
        public string imgbase = "";
        public string errmsg = "";
        public bool ticketget = false;
        public delegate void lgn();
        lgn rem;
        UdbLogin.LoginWrapper loginWrapper = new UdbLogin.LoginWrapper();
        public PCLogin(string usr,string pwd)
        {
            this.usr = usr;
            this.pwd = pwd;
        }
        public void TicketLogin(lgn ok,ulong uid_,string token_)
        {

            rem = ok;
            bool ret = loginWrapper.InitWrapper("1.0", "5007", "19f45e7c5145e3b034347c0a0c75a4f0");//109cf9fcbfbb017559dab7c6a7adcc12c64d63fd7d
            //loginWrapper.InitWrapp("2.2", "5006", "cf9b5344fc1b463493841814ed219ed1");"5007", "19f45e7c5145e3b034347c0a0c75a4f0"
            string retdvc = loginWrapper.GetDeviceData();

            this.loginWrapper.OnEventLoginInited += new EventLoginInited(this.Login_OnEventLoginInited);
            this.loginWrapper.OnLoginSuccess += new EventLoginSuccess(this.OnLoginSuccess);
            this.loginWrapper.OnLoginFailed += new EventLoginFailed(this.OnLoginFailed);
            this.loginWrapper.OnSendToServer += new EventLoginSendToServer(this.LoginWrapper_OnSendToServer);
            this.loginWrapper.OnPicVerify += new EventPicVerify(this.LoginWrap_PicVerify);
            this.loginWrapper.OnKickOff += new EventKickOff(this.OnKickOff);
            loginWrapper.SetCurrentNetStatus(true, 1, "udblgn.huya.com", true);
            loginWrapper.SendYYTicketLoginRequest(uid_, token_);
        }
        public void login(lgn ok)
        {

            rem = ok;
            bool ret = loginWrapper.InitWrapper("1.0", "5006", "cf9b5344fc1b463493841814ed219ed1");
            //loginWrapper.InitWrapp("2.2", "5006", "cf9b5344fc1b463493841814ed219ed1");"5007", "19f45e7c5145e3b034347c0a0c75a4f0"
            string retdvc =loginWrapper.GetDeviceData();
      
            this.loginWrapper.OnEventLoginInited += new EventLoginInited(this.Login_OnEventLoginInited);
            this.loginWrapper.OnLoginSuccess += new EventLoginSuccess(this.OnLoginSuccess);
            this.loginWrapper.OnLoginFailed += new EventLoginFailed(this.OnLoginFailed);
            this.loginWrapper.OnSendToServer += new EventLoginSendToServer(this.LoginWrapper_OnSendToServer);
            this.loginWrapper.OnPicVerify += new EventPicVerify(this.LoginWrap_PicVerify);
            this.loginWrapper.OnKickOff += new EventKickOff(this.OnKickOff);

  
            loginWrapper.SetCurrentNetStatus(true, 0, "www.baidu.com", true);
            loginWrapper.SendLoginRequest(this.usr, this.pwd);
        }
        public void ticketlogin(ulong u,string tk)
        {
            ticketget = true;
            loginWrapper.SendYYTicketLoginRequest(u, tk);
           
        }
        private void OnKickOff(string uid, int type, string tipText)
        {

            Console.WriteLine("LoginWrap_OnKickOff  "+tipText+"  "+uid);
            return;
        }

        private void Login_OnEventLoginInited()
        {
            try
            {
         
                Console.WriteLine("LoginInitOKAY");
            }
            catch (Exception exception1)
            {

            }
        }





        private void LoginWrapper_OnSendToServer(ulong ReqId, string Data)
        {
            try
            {
 
                Console.WriteLine("LoginWrap_OnSendToSvr\n\n"+Data);
                return;
            }
            catch (Exception)
            {
            }
        }

        private void LoginWrap_PicVerify(int action, int strategy, string uid, string sVerify, string sDescription, string sImageData)
        {
            state = sDescription;
            imgbase = sImageData;
            rem();
            return;
        }
        private void OnLoginSuccess(string loginType, int action, string yyid, string passport, string uid, int tokenType, string token, string thirdNickName, string thirdGender, string thirdLogoUrl, string des)
        {
            this.uid = uid;
            this.token = token;
            this.id = yyid;
            this.tokenType = tokenType;
            TokenPair tkp = loginWrapper.GetOTP();

            Console.WriteLine(passport+" "+"token " + tkp.sToken);
            rem();

        }
        private void OnLoginFailed(string loginType, string description)
        {
            errmsg = description+"."+loginType;
            rem();
            return;
        }
    }
}
