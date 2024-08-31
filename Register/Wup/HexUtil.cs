using System;

namespace Wup
{
	internal class HexUtil
	{
		private static char[] digits = new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F'
		};

		public static byte[] emptybytes = new byte[0];

		public static string byte2HexStr(byte b)
		{
			char[] expr_06 = new char[]
			{
				'\0',
				HexUtil.digits[(int)(b & 15)]
			};
			b = (byte)(b >> 4);
			expr_06[0] = HexUtil.digits[(int)(b & 15)];
			return new string(expr_06);
		}

		public static string bytes2HexStr(byte[] bytes)
		{
			if (bytes == null || bytes.Length == 0)
			{
				return null;
			}
			char[] array = new char[2 * bytes.Length];
			for (int i = 0; i < bytes.Length; i++)
			{
				byte b = bytes[i];
				array[2 * i + 1] = HexUtil.digits[(int)(b & 15)];
				b = (byte)(b >> 4);
				array[2 * i] = HexUtil.digits[(int)(b & 15)];
			}
			return new string(array);
		}

		public static byte hexStr2Byte(string str)
		{
			if (str != null && str.Length == 1)
			{
				return HexUtil.char2Byte(str[0]);
			}
			return 0;
		}

		public static byte char2Byte(char ch)
		{
			if (ch >= '0' && ch <= '9')
			{
				return (byte)(ch - '0');
			}
			if (ch >= 'a' && ch <= 'f')
			{
				return (byte)(ch - 'a' + '\n');
			}
			if (ch >= 'A' && ch <= 'F')
			{
				return (byte)(ch - 'A' + '\n');
			}
			return 0;
		}

		public static byte[] hexStr2Bytes(string str)
		{
			if (str == null || str.Equals(""))
			{
				return HexUtil.emptybytes;
			}
			byte[] array = new byte[str.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				char ch = str[i << 1];
				char ch2 = str[(i << 1) + 1];
				array[i] = (byte)(HexUtil.char2Byte(ch) * 16 + HexUtil.char2Byte(ch2));
			}
			return array;
		}

		public static byte[] ReverseBytes(byte[] inArray)
		{
			int num = inArray.Length - 1;
			for (int i = 0; i < inArray.Length / 2; i++)
			{
				byte b = inArray[i];
				inArray[i] = inArray[num];
				inArray[num] = b;
				num--;
			}
			return inArray;
		}
	}
}
