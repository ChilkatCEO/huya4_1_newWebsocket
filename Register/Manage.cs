using HUYA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace iHuya
{
    class Manage
    {

        public Form1 Window;
        int uindex = 0;
        public static object obj = new object();
        string myChannelFileAddr = "";

        public Manage(Form1 arg)
        {
            Window = arg;
            Window.bcb.Checked = Call.isUsingSocks5;
            Window.scb.Checked = Call.isUsingSocks5WithSvc;
            Window.vcb.Checked = Call.isUsingSocks5WithVideo;
        }

        delegate void AddItemDelegate(int row, int index, string msg);

        public void Msg(int row, int index, string msg)
        {
            try
            {
                // 如果需要跨线程刷新
                if (Window.dlv.InvokeRequired)
                {
                    AddItemDelegate del = Msg;
                    Window.dlv.Invoke(del, row, index, msg);
                }
                else  // 如果不需要跨线程刷新，直接对treeView1操作
                {
                    Window.dlv.Items[index].SubItems[row].Text = msg;
                }
            }
            catch
            {

            }
        }

        public void Addsingle(string usn, string pwd)
        {


            lock (osAdd)
            {
                User3 user = new User3(usn, pwd, uindex, "", 0, 0);
                ListViewItem item = new ListViewItem();
                item.Text = uindex.ToString();
                item.SubItems.Add(usn);
                item.SubItems.Add("0");
                item.SubItems.Add("");
                item.SubItems.Add("");
                Window.dlv.Items.Add(item);
                uindex++;
                Call.UserList.Add(user);

            }
            if (!Window.button_lgn.Enabled)
                Window.button_lgn.Enabled = true;
            return;
        }
        object osAdd = new object();
        public void AddSingleAccountToken(string token, long v, S5Struct s5x)
        {
            try
            {
                lock (osAdd)
                {
                    ListViewItem item = new ListViewItem();
                    User3 user = new User3("", "", uindex, token, v, 126);
                    item.Text = uindex.ToString();
                    item.SubItems.Add(v.ToString() + ":" + token);
                    item.SubItems.Add("HYToken");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    Call.map.Add(uindex, s5x);
                    Window.dlv.Items.Add(item);
                    uindex++;
                    Call.UserList.Add(user);
                }
                if (!Window.button_lgn.Enabled)
                    Window.button_lgn.Enabled = true;
            }
            catch { }
        }
        public void AddSingleAccount(string strRead, S5Struct s5s)
        {
            try
            {
                lock (osAdd)
                {
                    ListViewItem item = new ListViewItem();
                    User3 user = new User3(Call.StrcenterOf(strRead, "username=", ";"), "password", uindex, strRead, Convert.ToInt64(Call.StrcenterOf(strRead, "udb_uid=", ";")), 2);
                    item.Text = uindex.ToString();
                    item.SubItems.Add(Call.StrcenterOf(strRead, "username=", ";"));
                    item.SubItems.Add("YYClient");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    Call.map.Add(uindex, s5s);
                    Window.dlv.Items.Add(item);
                    uindex++;
                    Call.UserList.Add(user);
                }
                if (!Window.button_lgn.Enabled)
                    Window.button_lgn.Enabled = true;
            }
            catch { }


        }
        public void AddByFileAddr(string addr)
        {

            if (Call.isAddMAUAL==false)
            {
                if (addr.Length <= 0) return;
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(addr);//确保汉字能够正常显示//Encoding.GetEncoding("gb2312")              
                    string strRead;
                    User3 user = null;
                    bool isYY = false;
                    while (true)
                    {
                        strRead = sr.ReadLine();//读取一行
                        if (string.IsNullOrEmpty(strRead))//如果strRead读取为空
                            break;


                        ListViewItem item = new ListViewItem();
                        if (strRead.IndexOf("----") != -1)
                            isYY = true;
                        else isYY = false;
                        if (uindex <= 1)
                        {
                            if (isYY)
                            {
                                string[] arr = strRead.Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arr.Length >= 2)
                                {
                                    user = new User3(arr[0], arr[1], uindex, "", 0, 0);
                                    item.Text = uindex.ToString();
                                    item.SubItems.Add(arr[0]);
                                    item.SubItems.Add("ACCOUNT");
                                    item.SubItems.Add("");
                                    item.SubItems.Add("");
                                    item.SubItems.Add("");

                                }
                            }
                            else
                            {
                                if (strRead.IndexOf("udb_biztoken") != -1)
                                {
                                    user = new User3(Call.StrcenterOf(strRead, "username=", ";"), "password", uindex, strRead, Convert.ToInt64(Call.StrcenterOf(strRead, "udb_uid=", ";")), 1);
                                    item.Text = uindex.ToString();
                                    item.SubItems.Add(Call.StrcenterOf(strRead, "username=", ";"));
                                    item.SubItems.Add("NEW_HY");
                                    item.SubItems.Add("");
                                    item.SubItems.Add("");
                                    item.SubItems.Add("");
                                }
                                else
                                {
                                    user = new User3(Call.StrcenterOf(strRead, "username=", ";"), "password", uindex, strRead, Convert.ToInt64(Call.StrcenterOf(strRead, "udb_uid=", ";")), 2);
                                    item.Text = uindex.ToString();
                                    item.SubItems.Add(Call.StrcenterOf(strRead, "username=", ";"));
                                    item.SubItems.Add("OLD_YY");
                                    item.SubItems.Add("");
                                    item.SubItems.Add("");
                                    item.SubItems.Add("");
                                }
                            }
                            Window.dlv.Items.Add(item);
                            uindex++;
                            Call.UserList.Add(user);
                        }
                        else
                        {
               
                            Call.twiceLoginAccount.Add(strRead);
                        }
                    }
                    Window.button_lgn.Enabled = true;
                    // Window.btn_AddS5.Enabled = true;
                }
                catch
                {
                    //Call.MsgShow("无法导入此文件，请检查后再试。");
                    return;
                }
                finally
                {
                    sr.Close();
                }
                return;
            }
            else
            {
                try
                {

                    string strRead = "";
                    bool isYY = false;
                    int i = 0;
                    while (true)
                    {
                        i++;
                        if (i == 121)//121
                            break;


                        strRead = Call.outAUser();
                        //strRead = "942209687----x";
                        if (string.IsNullOrEmpty(strRead))//如果strRead读取为空
                            break;
                        ListViewItem item = new ListViewItem();
                        if (strRead.IndexOf("----") != -1)
                            isYY = true;
                        else isYY = false;
                        User3 user = null;
                        if (isYY)
                        {
                            string[] arr = strRead.Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
                            if (arr.Length >= 2)
                            {
                                user = new User3(arr[0], arr[1], uindex, "", 0, 0);
                                item.Text = uindex.ToString();
                                item.SubItems.Add(arr[0]);
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                try
                                {
                                    //File.Delete(Call.saverpath + arr[0] + ".txt");
                                }
                                catch
                                {

                                }
                            }
                        }
                        else
                        {
                            if (strRead.IndexOf("udb_biztoken") != -1)
                            {
                                user = new User3(Call.StrcenterOf(strRead, "username=", ";"), "password", uindex, strRead, Convert.ToInt64(Call.StrcenterOf(strRead, "udb_uid=", ";")), 1);
                                item.Text = uindex.ToString();
                                item.SubItems.Add(Call.StrcenterOf(strRead, "username=", ";"));
                                item.SubItems.Add("NEW_HY");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                            }
                            else
                            {
                                user = new User3(Call.StrcenterOf(strRead, "username=", ";"), "password", uindex, strRead, Convert.ToInt64(Call.StrcenterOf(strRead, "udb_uid=", ";")), 2);
                                item.Text = uindex.ToString();
                                item.SubItems.Add(Call.StrcenterOf(strRead, "username=", ";"));
                                item.SubItems.Add("OLD_YY");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                            }
                        }
                        Window.dlv.Items.Add(item);
                        uindex++;
                        Call.UserList.Add(user);
                    }
                    Window.button_lgn.Enabled = true;
                    // Window.btn_AddS5.Enabled = true;
                    //return true;
                }
                catch
                {

                }
                //return true;
            }

        }

        public bool Add()
        {
     
            if (Call.isAddMAUAL == true)
            {
                AddByFileAddr("");
                return true;
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "账号文件|*.txt";
                if (ofd.ShowDialog() != DialogResult.OK)
                    return false;
                StreamReader sr = null;
                User3 user = null;
                try
                {
                    sr = new StreamReader(ofd.FileName);//确保汉字能够正常显示//Encoding.GetEncoding("gb2312")              
                    string strRead;
                    bool isYY = false;
                    while (true)
                    {
                        strRead = sr.ReadLine();//读取一行
                        if (string.IsNullOrEmpty(strRead))//如果strRead读取为空
                            break;
                        ListViewItem item = new ListViewItem();


                        if (strRead.IndexOf("----") != -1)
                            isYY = true;
                        else isYY = false;

                        if (isYY)
                        {
                            string[] arr = strRead.Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
                            if (arr.Length >= 2)
                            {
                                user = new User3(arr[0], arr[1], uindex, "", 0, 0);
                                item.Text = uindex.ToString();
                                item.SubItems.Add(arr[0]);
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                try
                                {
                                    //File.Delete(Call.saverpath + arr[0] + ".txt");
                                }
                                catch
                                {

                                }
                            }
                        }
                        else
                        {
                            if (strRead.IndexOf("udb_biztoken") != -1)
                            {
                                user = new User3(Call.StrcenterOf(strRead, "username=", ";"), "password", uindex, strRead, Convert.ToInt64(Call.StrcenterOf(strRead, "udb_uid=", ";")), 1);
                                item.Text = uindex.ToString();
                                item.SubItems.Add(Call.StrcenterOf(strRead, "username=", ";"));
                                item.SubItems.Add("NEW_HY");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                            }
                            else
                            {
                                user = new User3(Call.StrcenterOf(strRead, "username=", ";"), "password", uindex, strRead, Convert.ToInt64(Call.StrcenterOf(strRead, "udb_uid=", ";")), 2);
                                item.Text = uindex.ToString();
                                item.SubItems.Add(Call.StrcenterOf(strRead, "username=", ";"));
                                item.SubItems.Add("OLD_YY");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                            }
                        }
                        Window.dlv.Items.Add(item);
                        uindex++;
                        Call.UserList.Add(user);
                    }

                    // Window.btn_AddS5.Enabled = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString() + "\n" + ex.StackTrace);
                    Window.button_lgn.Enabled = true;
                    //   Call.MsgShow("无法导入此文件，请检查后再试。");
                    return true;
                }
                Window.button_lgn.Enabled = true;
                return true;
            }

        }
        public void AddChannel()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "频道文件(hyRoomID)|*.txt";
            if (myChannelFileAddr == "")
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;
                myChannelFileAddr = ofd.FileName;
            }
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(myChannelFileAddr);//确保汉字能够正常显示//Encoding.GetEncoding("gb2312")              
                string strRead;
                Call.ChList.Clear();
                while (true)
                {
                    strRead = sr.ReadLine();//读取一行
                    if (string.IsNullOrEmpty(strRead))//如果strRead读取为空
                        break;

                    Call.ChList.Add(strRead);
                }
                // Window.btn_AddS5.Enabled = true;
                sr.Close();
                sr.Dispose();
                ofd.Dispose();
            }
            catch
            {
                // Call.MsgShow("无法导入此文件，请检查后再试。");
                return;
            }
            return;
        }

        public void AddS5NoDialog(string fn)
        {


            if (fn.Length <= 0) return;
            StreamReader sr = null;


            string strRead = "";
            try
            {
                //Chilkat.Http http = new Chilkat.Http();
                //http.UnlockComponent("SunStar");
                //Call.accountsrc = http.QuickGetStr(Call.accnetstream).Split(new string[] { "\r\n" }, StringSplitOptions.None);

                S5Struct s5s = new S5Struct();
                sr = new StreamReader(fn);//确保汉字能够正常显示//Encoding.GetEncoding("gb2312")              
                List<string> test = new List<string>();
                string[] ss = { "," };
                int i = 0;
                while (true)
                {
                    strRead = sr.ReadLine();//读取一行
                    if (string.IsNullOrEmpty(strRead))//如果strRead读取为空
                        break;

                    string[] arrValue = strRead.Split(ss, StringSplitOptions.RemoveEmptyEntries);
                    if (true)//!test.Contains(arrValue[0])
                    {
                        if (i >= Call.UserList.Count) break;
                        test.Add(arrValue[0]);
                        s5s.Socks5HostName = arrValue[0];

                        s5s.Socks5Port = int.Parse(arrValue[1]);
                        s5s.Socks5Usn = arrValue[2];
                        s5s.Socks5Pwd = arrValue[3];
                        s5s.state = 0;
                        Msg(3, i, "[" + arrValue[0] + "]");
                        Call.map.Add(i, s5s);
                        i++;
                    }
                }
            }
            catch
            {
                //  Call.MsgShow("无法导入此文件，请检查后再试。");
                return;
            }
            finally
            {

                sr.Close();
            }



            return;
        }
        public void AddS5()
        {
            Call.map.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Socks5批量代理文件|*.txt";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            StreamReader sr = null;
            string strRead = "";
            try
            {
                S5Struct s5s = new S5Struct();
                sr = new StreamReader(ofd.FileName);//确保汉字能够正常显示//Encoding.GetEncoding("gb2312")              
                List<string> test = new List<string>();
                string[] ss = { ":" };
                int i = 0;
                while (true)
                {
                    strRead = sr.ReadLine();//读取一行
                    if (string.IsNullOrEmpty(strRead))//如果strRead读取为空
                        break;

                    string[] arrValue = strRead.Split(ss, StringSplitOptions.RemoveEmptyEntries);
                    if (true)//!test.Contains(arrValue[0])
                    {
                        if (i >= Call.UserList.Count) break;
                        test.Add(arrValue[0]);
                        s5s.Socks5HostName = arrValue[0];

                        s5s.Socks5Port = int.Parse(arrValue[1]);
                        s5s.Socks5Usn = arrValue[2];
                        s5s.Socks5Pwd = arrValue[3];
                        s5s.state = 0;
                        Msg(3, i, "[" + arrValue[0] + "]");

                        Call.map.Add(i, s5s);
                        i++;
                    }
                }
            }
            catch
            {
                //Call.MsgShow("无法导入此文件，请检查后再试。");
                return;
            }
            return;
        }
        internal void AddVideoS5(string oip)
        {

            StreamReader sr = null;
            string strRead = "";
            try
            {
                S5Struct s5s = new S5Struct();
                sr = new StreamReader(oip);//确保汉字能够正常显示//Encoding.GetEncoding("gb2312")              
                List<string> test = new List<string>();
                Call.S5ARRAY = new S5Struct[Call.UserList.Count];
                string[] ss = { "," };
                int i = 0;
                while (true)
                {
                    strRead = sr.ReadLine();//读取一行
                    if (string.IsNullOrEmpty(strRead))//如果strRead读取为空
                        break;

                    string[] arrValue = strRead.Split(ss, StringSplitOptions.RemoveEmptyEntries);

                    if (i >= Call.UserList.Count) break;
                    test.Add(arrValue[0]);
                    s5s.Socks5HostName = arrValue[0];

                    s5s.Socks5Port = int.Parse(arrValue[1]);
                    s5s.Socks5Usn = arrValue[2];
                    s5s.Socks5Pwd = arrValue[3];
                    s5s.state = 0;
                    Call.S5ARRAY[i] = s5s;
                    //Msg(3, i, "[" + arrValue[0] + "]");
                    //Call.map.Add(i, s5s);
                    i++;

                }
                Call.isUsingSocks5WithVideo = true;
            }
            catch
            {
                //Call.MsgShow("无法导入此文件，请检查后再试。");
                return;
            }
            return;
        }
        internal void AddVideoS5()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "S5 File|*.txt";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            StreamReader sr = null;
            string strRead = "";
            try
            {
                S5Struct s5s = new S5Struct();
                sr = new StreamReader(ofd.FileName);//确保汉字能够正常显示//Encoding.GetEncoding("gb2312")              
                List<string> test = new List<string>();
                Call.S5ARRAY = new S5Struct[Call.UserList.Count];
                string[] ss = { ":" };
                int i = 0;
                while (true)
                {
                    strRead = sr.ReadLine();//读取一行
                    if (string.IsNullOrEmpty(strRead))//如果strRead读取为空
                        break;

                    string[] arrValue = strRead.Split(ss, StringSplitOptions.RemoveEmptyEntries);

                    if (i >= Call.UserList.Count) break;
                    test.Add(arrValue[0]);
                    s5s.Socks5HostName = arrValue[0];

                    s5s.Socks5Port = int.Parse(arrValue[1]);
                    s5s.Socks5Usn = arrValue[2];
                    s5s.Socks5Pwd = arrValue[3];
                    s5s.state = 0;
                    Call.S5ARRAY[i] = s5s;
                    //Msg(3, i, "[" + arrValue[0] + "]");
                    //Call.map.Add(i, s5s);
                    i++;

                }
                Call.isUsingSocks5WithVideo = true;
            }
            catch
            {
                //Call.MsgShow("无法导入此文件，请检查后再试。");
                return;
            }
            return;
        }


    }
}
