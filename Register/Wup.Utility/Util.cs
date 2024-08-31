using System;
using System.Collections.Generic;
using System.Text;

namespace HUYA
{
	internal class Util
	{
		private static Random rand = new Random();

		public static int Random()
		{
			return Util.rand.Next();
		}

		public static byte[] CharArray2Bytes(char[] chars)
		{
			byte[] array = new byte[chars.Length];
			for (int i = 0; i < chars.Length; i++)
			{
				char c = chars[i];
				array[i] = (byte)c;
				c >>= 8;
				if (c > '\0')
				{
					i++;
					array[i] = (byte)c;
				}
			}
			return array;
		}

		public static string Bytes2String(byte[] bytes)
		{
			string text = "";
			List<int> list = new List<int>();
			for (int i = 0; i < bytes.Length - 1; i++)
			{
				if ((bytes[i] & 128) != 0 && (bytes[i + 1] & 128) != 0)
				{
					list.Add(i);
				}
			}
			if (list.Count > 0)
			{
				if (list[0] > 0)
				{
					text += Encoding.UTF8.GetString(bytes, 0, list[0]);
				}
				text += ((char)list[0]).ToString();
			}
			for (int j = 1; j < list.Count; j++)
			{
				int num = list[j] - list[j - 1] - 1;
				if (num > 0)
				{
					text += Encoding.UTF8.GetString(bytes, list[j - 1] + 1, num);
				}
				text += ((char)list[j]).ToString();
			}
			int num2 = 0;
			if (list.Count > 0)
			{
				num2 = list[list.Count - 1] + 1;
			}
			if (num2 < bytes.Length)
			{
				text += Encoding.UTF8.GetString(bytes, num2, bytes.Length - num2);
			}
			return text;
		}

		public static string Hex2String(byte[] buffer)
		{
			string text = "";
			if (buffer != null)
			{
				for (int i = 0; i < buffer.Length; i++)
				{
					byte b = buffer[i];
					text += b.ToString("x2");
				}
			}
			return text;
		}
	}
}
