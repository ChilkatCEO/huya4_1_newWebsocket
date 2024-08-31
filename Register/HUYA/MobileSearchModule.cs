using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wup.Jce;
namespace HUYA
{
    class MobileSearchModule : JceStruct
    {
        public int showNum, icontenttype;
        public string sKeyWord, sk2;

        List<SSNormalUserInfo> sSNormalUserInfoList { get; set; }
        List<SSPresenterInfo> sSPresenterInfoList { get; set; }


        public override void ReadFrom(JceInputStream _is)
        {
            if (sSNormalUserInfoList == null)
            {
                this.sSNormalUserInfoList = new List<SSNormalUserInfo>();
                sSNormalUserInfoList.Add(new SSNormalUserInfo());
            }
            if (sSPresenterInfoList == null)
            {
                this.sSPresenterInfoList = new List<SSPresenterInfo>();
                sSPresenterInfoList.Add(new SSPresenterInfo());
            }

            icontenttype = _is.Read(this.icontenttype, 0, false);
            sKeyWord = _is.Read(this.sKeyWord, 1, false);
            sk2 = _is.Read(this.sKeyWord, 2, false);
            showNum = _is.Read(this.showNum, 3, false);

            /*this.sSPresenterInfoList = (List<SSPresenterInfo>)_is.Read<List<SSPresenterInfo>>(this.sSPresenterInfoList, 4, false);
            Console.WriteLine("111");
            this.sSPresenterInfoList = (List<SSPresenterInfo>)_is.Read<List<SSPresenterInfo>>(this.sSPresenterInfoList, 5, false);
            Console.WriteLine("222");*/

            this.sSNormalUserInfoList = (List<SSNormalUserInfo>)_is.Read<List<SSNormalUserInfo>>(this.sSNormalUserInfoList, 8, false);
            Console.WriteLine("個數:"+sSNormalUserInfoList.Count);
        }

        public override void WriteTo(JceOutputStream _os)
        {
            throw new NotImplementedException();
        }
    }
}
