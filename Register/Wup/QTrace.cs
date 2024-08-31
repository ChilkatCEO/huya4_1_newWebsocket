using System;
using System.Collections;
using System.Diagnostics;

namespace Wup
{
	public class QTrace
	{
		public static void Trace(string value)
		{
			Debug.WriteLine(string.Concat(new string[]
			{
				DateTime.Now.Hour.ToString("D2"),
				":",
				DateTime.Now.Minute.ToString("D2"),
				":",
				DateTime.Now.Second.ToString("D2"),
				":",
				DateTime.Now.Millisecond.ToString("D3")
			}) + "\t" + value);
		}

		public static void Trace(string value, object arg)
		{
			string.Format("{0}{1}", value, arg);
			Debug.WriteLine(value);
		}

		public static string Trace(byte[] value)
		{
			string text = "\r\n";
			int num = 0;
			for (int i = 0; i < value.Length; i++)
			{
				byte b = value[i];
				text += string.Format(" {0,02:x}", b);
				num++;
				if (num % 16 == 0)
				{
					text += "\n";
				}
			}
			QTrace.Trace(text);
			return text;
		}

		public static void Trace(IDictionary dict)
		{
			if (dict == null)
			{
				return;
			}
			string text = " Dictionary: ";
			foreach (object current in dict.Keys)
			{
				text += current.ToString();
				text += "\t\t";
				text += dict[current].ToString();
				text += "\r\n";
			}
			QTrace.Trace(text);
		}

		public static void Trace(IList list)
		{
			if (list == null)
			{
				return;
			}
			string text = " List: ";
			foreach (object current in list)
			{
				text += current.ToString();
				text += "\r\n";
			}
			QTrace.Trace(text);
		}

		public static void Assert(bool condition)
		{
			Debug.Assert(condition);
		}

		public static string Output(byte[] value)
		{
			string text = "";
			int num = 0;
			for (int i = 0; i < value.Length; i++)
			{
				byte b = value[i];
				text += string.Format("0x{0:x},", b);
				num++;
				if (num % 16 == 0)
				{
					text += "\n";
				}
			}
			return text;
		}
	}
}
