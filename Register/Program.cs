using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
namespace iHuya
{
    static class Program
    {
        static string argsv="";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            glExitApp = true;
            if (args!=null && args.Length > 0)
            {
                argsv = "";
                for (int i = 0; i < args.Length; i++)
                    argsv += args[i] + " ";
                Call.isUsingSocks5WithWS = true;
                Call.isUsingSocks5 = true;
                Application.Run(new Form1(args));
            }
            else
            {
                Application.Run(new Form1());
            }

        


        }
        /// <summary>
        /// 在命令行窗口中执行
        /// </summary>
        /// <param name="sExePath"></param>
        /// <param name="sArguments"></param>
        static void CmdStartCTIProc(string sExePath, string sArguments)
        {
            //Application.Restart();
            return;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            p.Start();
            p.StandardInput.WriteLine(sExePath + " " + sArguments);
            p.StandardInput.WriteLine("exit");
            p.Close();

            System.Threading.Thread.Sleep(6000);//必须等待，否则重启的程序还未启动完成；根据情况调整等待时间
        }
        /// <summary>
        /// 是否退出应用程序
        /// </summary>
        static bool glExitApp = false;

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            /*LogHelper.Save("CurrentDomain_UnhandledException", LogType.Error);
            LogHelper.Save("IsTerminating : " + e.IsTerminating.ToString(), LogType.Error);
            LogHelper.Save(e.ExceptionObject.ToString());*/
            //Application.Restart(); 
            //MessageBox.Show(e.ExceptionObject.ToString());
            if(e.IsTerminating)
            File.WriteAllText(DateTime.Now.ToString() + ".txt", "err(close):" + "CurrentDomain_UnhandledException" +
            "WillbeEnd " + (e.IsTerminating ? "1" : "0") + " \r\n" + e.ExceptionObject.ToString());
 
      
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //MessageBox.Show(e.Exception.Message);
            Directory.CreateDirectory("C:\\err");
            File.WriteAllText("C:\\" + "err\\x.txt", "err(close):" + "Application_ThreadException:" +
               e.Exception.StackTrace);

            //LogHelper.Save("Application_ThreadException:" +
            // e.Exception.Message, LogType.Error);
            // LogHelper.Save(e.Exception);
            //throw new NotImplementedException();
        }
    }
}
