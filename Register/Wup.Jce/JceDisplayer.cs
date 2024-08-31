using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Wup.Jce
{
	public class JceDisplayer
	{
		private StringBuilder sb;

		private int _level;

		private void ps(string fieldName)
		{
			for (int i = 0; i < this._level; i++)
			{
				this.sb.Append('\t');
			}
			if (fieldName != null)
			{
				this.sb.Append(fieldName).Append(": ");
			}
		}

		public JceDisplayer(StringBuilder sb, int level)
		{
			this.sb = sb;
			this._level = level;
		}

		public JceDisplayer(StringBuilder sb)
		{
			this.sb = sb;
		}

		public JceDisplayer Display(bool b, string fieldName)
		{
			this.ps(fieldName);
			this.sb.Append(b ? 'T' : 'F').Append('\n');
			return this;
		}

		public JceDisplayer Display(byte n, string fieldName)
		{
			this.ps(fieldName);
			this.sb.Append(n).Append('\n');
			return this;
		}

		public JceDisplayer Display(char n, string fieldName)
		{
			this.ps(fieldName);
			this.sb.Append(n).Append('\n');
			return this;
		}

		public JceDisplayer Display(short n, string fieldName)
		{
			this.ps(fieldName);
			this.sb.Append(n).Append('\n');
			return this;
		}

		public JceDisplayer Display(int n, string fieldName)
		{
			this.ps(fieldName);
			this.sb.Append(n).Append('\n');
			return this;
		}

		public JceDisplayer Display(long n, string fieldName)
		{
			this.ps(fieldName);
			this.sb.Append(n).Append('\n');
			return this;
		}

		public JceDisplayer Display(float n, string fieldName)
		{
			this.ps(fieldName);
			this.sb.Append(n).Append('\n');
			return this;
		}

		public JceDisplayer Display(double n, string fieldName)
		{
			this.ps(fieldName);
			this.sb.Append(n).Append('\n');
			return this;
		}

		public JceDisplayer Display(string s, string fieldName)
		{
			this.ps(fieldName);
			if (s == null)
			{
				this.sb.Append("null").Append('\n');
			}
			else
			{
				this.sb.Append(s).Append('\n');
			}
			return this;
		}

		public JceDisplayer Display(byte[] v, string fieldName)
		{
			this.ps(fieldName);
			if (v == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (v.Length == 0)
			{
				this.sb.Append(v.Length).Append(", []").Append('\n');
				return this;
			}
			this.sb.Append(v.Length).Append(", [").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			for (int i = 0; i < v.Length; i++)
			{
				byte n = v[i];
				jceDisplayer.Display(n, null);
			}
			this.Display(']', null);
			return this;
		}

		public JceDisplayer Display(char[] v, string fieldName)
		{
			this.ps(fieldName);
			if (v == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (v.Length == 0)
			{
				this.sb.Append(v.Length).Append(", []").Append('\n');
				return this;
			}
			this.sb.Append(v.Length).Append(", [").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			for (int i = 0; i < v.Length; i++)
			{
				char n = v[i];
				jceDisplayer.Display(n, null);
			}
			this.Display(']', null);
			return this;
		}

		public JceDisplayer Display(short[] v, string fieldName)
		{
			this.ps(fieldName);
			if (v == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (v.Length == 0)
			{
				this.sb.Append(v.Length).Append(", []").Append('\n');
				return this;
			}
			this.sb.Append(v.Length).Append(", [").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			for (int i = 0; i < v.Length; i++)
			{
				short n = v[i];
				jceDisplayer.Display(n, null);
			}
			this.Display(']', null);
			return this;
		}

		public JceDisplayer Display(int[] v, string fieldName)
		{
			this.ps(fieldName);
			if (v == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (v.Length == 0)
			{
				this.sb.Append(v.Length).Append(", []").Append('\n');
				return this;
			}
			this.sb.Append(v.Length).Append(", [").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			for (int i = 0; i < v.Length; i++)
			{
				int n = v[i];
				jceDisplayer.Display(n, null);
			}
			this.Display(']', null);
			return this;
		}

		public JceDisplayer Display(long[] v, string fieldName)
		{
			this.ps(fieldName);
			if (v == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (v.Length == 0)
			{
				this.sb.Append(v.Length).Append(", []").Append('\n');
				return this;
			}
			this.sb.Append(v.Length).Append(", [").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			for (int i = 0; i < v.Length; i++)
			{
				long n = v[i];
				jceDisplayer.Display(n, null);
			}
			this.Display(']', null);
			return this;
		}

		public JceDisplayer Display(float[] v, string fieldName)
		{
			this.ps(fieldName);
			if (v == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (v.Length == 0)
			{
				this.sb.Append(v.Length).Append(", []").Append('\n');
				return this;
			}
			this.sb.Append(v.Length).Append(", [").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			for (int i = 0; i < v.Length; i++)
			{
				float n = v[i];
				jceDisplayer.Display(n, null);
			}
			this.Display(']', null);
			return this;
		}

		public JceDisplayer Display(double[] v, string fieldName)
		{
			this.ps(fieldName);
			if (v == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (v.Length == 0)
			{
				this.sb.Append(v.Length).Append(", []").Append('\n');
				return this;
			}
			this.sb.Append(v.Length).Append(", [").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			for (int i = 0; i < v.Length; i++)
			{
				double n = v[i];
				jceDisplayer.Display(n, null);
			}
			this.Display(']', null);
			return this;
		}

		public JceDisplayer Display<K, V>(Dictionary<K, V> m, string fieldName)
		{
			this.ps(fieldName);
			if (m == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (m.Count == 0)
			{
				this.sb.Append(m.Count).Append(", {}").Append('\n');
				return this;
			}
			this.sb.Append(m.Count).Append(", {").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			JceDisplayer jceDisplayer2 = new JceDisplayer(this.sb, this._level + 2);
			foreach (KeyValuePair<K, V> current in m)
			{
				jceDisplayer.Display('(', null);
				jceDisplayer2.Display<K>(current.Key, null);
				jceDisplayer2.Display<V>(current.Value, null);
				jceDisplayer.Display(')', null);
			}
			this.Display('}', null);
			return this;
		}

		public JceDisplayer Display<T>(T[] v, string fieldName)
		{
			this.ps(fieldName);
			if (v == null)
			{
				this.sb.Append("null").Append('\n');
				return this;
			}
			if (v.Length == 0)
			{
				this.sb.Append(v.Length).Append(", []").Append('\n');
				return this;
			}
			this.sb.Append(v.Length).Append(", [").Append('\n');
			JceDisplayer jceDisplayer = new JceDisplayer(this.sb, this._level + 1);
			for (int i = 0; i < v.Length; i++)
			{
				T o = v[i];
				jceDisplayer.Display<T>(o, null);
			}
			this.Display(']', null);
			return this;
		}

		public JceDisplayer Display<T>(List<T> v, string fieldName)
		{
			if (v == null)
			{
				this.ps(fieldName);
				this.sb.Append("null").Append('\n');
				return this;
			}
			for (int i = 0; i < v.Count; i++)
			{
				this.Display<T>(v[i], fieldName);
			}
			return this;
		}

		public JceDisplayer Display<T>(T o, string fieldName)
		{
			object obj = o;
			if (o == null)
			{
				this.sb.Append("null").Append('\n');
			}
			else if (o is byte)
			{
				this.Display((byte)obj, fieldName);
			}
			else if (o is bool)
			{
				this.Display((bool)obj, fieldName);
			}
			else if (o is short)
			{
				this.Display((short)obj, fieldName);
			}
			else if (o is int)
			{
				this.Display((int)obj, fieldName);
			}
			else if (o is long)
			{
				this.Display((long)obj, fieldName);
			}
			else if (o is float)
			{
				this.Display((float)obj, fieldName);
			}
			else if (o is double)
			{
				this.Display((double)obj, fieldName);
			}
			else if (o is string)
			{
				this.Display((string)obj, fieldName);
			}
			else if (o is JceStruct)
			{
				this.Display((JceStruct)obj, fieldName);
			}
			else if (o is byte[])
			{
				this.Display((byte[])obj, fieldName);
			}
			else if (o is bool[])
			{
				this.Display<bool>((bool[])obj, fieldName);
			}
			else if (o is short[])
			{
				this.Display((short[])obj, fieldName);
			}
			else if (o is int[])
			{
				this.Display((int[])obj, fieldName);
			}
			else if (o is long[])
			{
				this.Display((long[])obj, fieldName);
			}
			else if (o is float[])
			{
				this.Display((float[])obj, fieldName);
			}
			else if (o is double[])
			{
				this.Display((double[])obj, fieldName);
			}
			else if (o.GetType().IsArray)
			{
				this.Display<object>((object[])obj, fieldName);
			}
			else
			{
				if (!(o is IList))
				{
					throw new JceEncodeException("write object error: unsupport type.");
				}
				IEnumerable arg_269_0 = (IList)obj;
				List<object> list = new List<object>();
				foreach (object current in arg_269_0)
				{
					list.Add(current);
				}
				this.Display<object>(list, fieldName);
			}
			return this;
		}

		public JceDisplayer Display(JceStruct v, string fieldName)
		{
			this.Display('{', fieldName);
			if (v == null)
			{
				this.sb.Append('\t').Append("null");
			}
			else
			{
				v.Display(this.sb, this._level + 1);
			}
			this.Display('}', null);
			return this;
		}
	}
}
