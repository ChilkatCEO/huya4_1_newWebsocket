using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using Wup.Jce;

namespace Wup
{
	public class WupHelper
	{
		public static bool ReadJceStruct(JceStruct obj, List<byte> data)
		{
			try
			{
				JceInputStream @is = new JceInputStream(data.ToArray());
				obj.ReadFrom(@is);
				return true;
			}
			catch
			{
			}
			return false;
		}

		public static Resp GetAsync<Req, Resp>(Req req, string function, string servant, bool bCdn = false)
		{
			Resp result = default(Resp);
			try
			{
				HttpWebRequest expr_21 = (HttpWebRequest)WebRequest.Create((!bCdn) ? "http://wup.huya.com" : "http://cdn.wup.huya.com");
				expr_21.Timeout = 6000;
				expr_21.Method = "POST";
				UniPacket expr_3C = new UniPacket();
				expr_3C.ServantName = servant;
				expr_3C.FuncName = function;
				expr_3C.Put<Req>("tReq", req);
				byte[] array = expr_3C.Encode();
				Stream expr_62 = expr_21.GetRequestStream();
				expr_62.Write(array, 0, array.Length);
				expr_62.Close();
				HttpWebResponse expr_7C = (HttpWebResponse)expr_21.GetResponse();
				Stream responseStream = expr_7C.GetResponseStream();
				long contentLength = expr_7C.ContentLength;
				byte[] buffer = new byte[contentLength];
				int num = 0;
				int num2;
				do
				{
					num2 = responseStream.Read(buffer, num, (int)contentLength - num);
					num += num2;
				}
				while ((long)num != contentLength && num2 != 0);
				UniPacket uniPacket = new UniPacket();
				uniPacket.Decode(buffer, 0);
				if (uniPacket.Get<int>("", -1) >= 0)
				{
					result = uniPacket.Get<Resp>("tRsp");
				}
				return result;
			}
			catch (Exception)
			{
			}
			return result;
		}

		public static UniPacket MakeupPacket<Req>(Req req, string servantName, string funcName)
		{
			try
			{
				UniPacket expr_05 = new UniPacket();
				expr_05.ServantName = servantName;
				expr_05.FuncName = funcName;
				expr_05.Put<Req>("tReq", req);
				return expr_05;
			}
			catch (Exception)
			{
			}
			return null;
		}

		public static UniPacket MakeupPacket(byte[] bytes)
		{
			try
			{
				UniPacket expr_05 = new UniPacket();
				expr_05.Decode(bytes, 0);
				return expr_05;
			}
			catch (Exception)
			{
			}
			return null;
		}

		public static Resp PacketToResp<Resp>(UniPacket packet)
		{
			Resp result = default(Resp);
			try
			{
				if (packet != null)
				{
					result = packet.Get<Resp>("tRsp");
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		public static int PacketToResp<Resp>(UniPacket packet, ref Resp rsp)
		{
			int num = -1;
			try
			{
				num = packet.Get<int>("");
				if (num > -1)
				{
					rsp = packet.Get<Resp>("tRsp");
				}
			}
			catch (Exception)
			{
			}
			return num;
		}

		public static byte[] RespToBytes<T>(T t)
		{
			try
			{
				MethodInfo arg_1A_0 = typeof(T).GetMethod("WriteTo");
				JceOutputStream jceOutputStream = new JceOutputStream();
				if (arg_1A_0 != null)
				{
					arg_1A_0.Invoke(t, new object[]
					{
						jceOutputStream
					});
				}
				return jceOutputStream.toByteArray();
			}
			catch (Exception)
			{
			}
			return null;
		}

		public static T ByteToResp<T>(byte[] bytes)
		{
			try
			{
				if (bytes == null && bytes.Length < 2)
				{
					T t = default(T);
					t = t;
					return t;
				}
				Type arg_26_0 = typeof(T);
				JceInputStream jceInputStream = new JceInputStream(bytes);
				T t2 = (T)((object)Activator.CreateInstance(arg_26_0, null));
				MethodInfo method = arg_26_0.GetMethod("ReadFrom");
				if (method != null)
				{
					method.Invoke(t2, new object[]
					{
						jceInputStream
					});
					T t = t2;
					return t;
				}
			}
			catch (Exception)
			{
			}
			return default(T);
		}
	}
}
