using System;
using System.Collections.Generic;
using Wup.Jce;

namespace Wup
{
	public class RequestPacket : JceStruct
	{
		public short iVersion;

		public byte cPacketType;

		public int iMessageType;

		public int iRequestId;

		public string sServantName;

		public string sFuncName;

		public byte[] sBuffer;

		public int iTimeout;

		public Dictionary<string, string> context;

		public Dictionary<string, string> status;

		private static byte[] cache_sBuffer;

		public RequestPacket()
		{
		}

		public RequestPacket(short iVersion, byte cPacketType, int iMessageType, int iRequestId, string sServantName, string sFuncName, byte[] sBuffer, int iTimeout, Dictionary<string, string> context, Dictionary<string, string> status)
		{
			this.iVersion = iVersion;
			this.cPacketType = cPacketType;
			this.iMessageType = iMessageType;
			this.iRequestId = iRequestId;
			this.sServantName = sServantName;
			this.sFuncName = sFuncName;
			this.sBuffer = sBuffer;
			this.iTimeout = iTimeout;
			this.context = context;
			this.status = status;
		}

		public override void WriteTo(JceOutputStream _os)
		{
			_os.Write(this.iVersion, 1);
			_os.Write(this.cPacketType, 2);
			_os.Write(this.iMessageType, 3);
			_os.Write(this.iRequestId, 4);
			_os.Write(this.sServantName, 5, false);
			_os.Write(this.sFuncName, 6, false);
			_os.Write(this.sBuffer, 7);
			_os.Write(this.iTimeout, 8);
			_os.Write(this.context, 9);
			_os.Write(this.status, 10);
		}

		public override void ReadFrom(JceInputStream _is)
		{
			try
			{
				this.iVersion = _is.Read(this.iVersion, 1, true);
				this.cPacketType = _is.Read(this.cPacketType, 2, true);
				this.iMessageType = _is.Read(this.iMessageType, 3, true);
				this.iRequestId = _is.Read(this.iRequestId, 4, true);
				this.sServantName = _is.readString(5, true);
				this.sFuncName = _is.readString(6, true);
				if (RequestPacket.cache_sBuffer == null)
				{
					RequestPacket.cache_sBuffer = new byte[1];
				}
				this.sBuffer = (byte[])_is.Read<byte[]>(RequestPacket.cache_sBuffer, 7, true);
				this.iTimeout = _is.Read(this.iTimeout, 8, true);
				Dictionary<string, string> o = null;
				this.context = (Dictionary<string, string>)_is.Read<Dictionary<string, string>>(o, 9, true);
				this.status = (Dictionary<string, string>)_is.Read<Dictionary<string, string>>(o, 10, true);
			}
			catch (Exception ex)
			{
				QTrace.Trace(this + " ReadFrom Exception: " + ex.Message);
				throw ex;
			}
		}
	}
}
