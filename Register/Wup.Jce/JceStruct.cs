extern alias huyaproto;
using System;

using System.Text;

namespace Wup.Jce
{
	public abstract class JceStruct
	{
		public static int JCE_MAX_STRING_LENGTH = 104857600;

		public abstract void WriteTo(JceOutputStream _os);
        public abstract void ReadFrom(JceInputStream _is);

		public virtual void Display(StringBuilder sb, int level)
		{
		}
	}
}
