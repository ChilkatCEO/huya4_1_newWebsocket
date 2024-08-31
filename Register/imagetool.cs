using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.Remoting.Channels.Tcp;

namespace 战火识别实现
{
    public class Get51Code : MarshalByRefObject
    {
        public Get51Code()
        {

        }

        public string HQCode(byte[] bytes, int imagetype)
        {
            try
            {
                return "";
            }
            catch
            {
                return "";
            }
        }
    }
    public class imagetool
    {
        private static imagetool imagetool_0;

        private Get51Code UjYdAtsjXq;

        private imagetool()
        {
            ChannelServices.RegisterChannel(new TcpClientChannel("shibie", new BinaryClientFormatterSinkProvider()), false);
            UjYdAtsjXq = (Get51Code)Activator.GetObject(typeof(Get51Code), "tcp://localhost:80/Get51Code");
        }

        public static imagetool CreateInstance()
        {
            if (imagetool_0 == null)
            {
                imagetool_0 = new imagetool();
            }
            return imagetool_0;
        }

        public string hqCode(byte[] bytes, int imageType = 4)
        {
            try
            {
                return UjYdAtsjXq.HQCode(bytes, imageType);
            }
            catch (Exception ex)
            {

                return "jgdq";
            }
        }

        public byte[] method_0(Bitmap bitmap)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, ImageFormat.Bmp);
                    byte[] array = new byte[memoryStream.Length];
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    memoryStream.Read(array, 0, Convert.ToInt32(memoryStream.Length));
                    bitmap.Dispose();
                    memoryStream.Close();
                    memoryStream.Dispose();
                    return array;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}