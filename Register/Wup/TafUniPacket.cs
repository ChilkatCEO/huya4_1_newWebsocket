using System;
using System.Collections.Generic;

namespace Wup
{
	internal class TafUniPacket : UniPacket
	{
		public TafUniPacket()
		{
			this._package.iVersion = 2;
			this._package.cPacketType = Const.PACKET_TYPE_WUP;
			this._package.iMessageType = 0;
			this._package.iTimeout = 0;
			this._package.sBuffer = new byte[0];
			this._package.context = new Dictionary<string, string>();
			this._package.status = new Dictionary<string, string>();
		}

		public void setTafVersion(short version)
		{
			base.setVersion(version);
		}

		public void setTafPacketType(byte packetType)
		{
			this._package.cPacketType = packetType;
		}

		public void setTafMessageType(int messageType)
		{
			this._package.iMessageType = messageType;
		}

		public void setTafTimeout(int timeout)
		{
			this._package.iTimeout = timeout;
		}

		public void setTafBuffer(byte[] buffer)
		{
			this._package.sBuffer = buffer;
		}

		public void setTafContext(Dictionary<string, string> context)
		{
			this._package.context = context;
		}

		public void setTafStatus(Dictionary<string, string> status)
		{
			this._package.status = status;
		}

		public short getTafVersion()
		{
			return this._package.iVersion;
		}

		public byte getTafPacketType()
		{
			return this._package.cPacketType;
		}

		public int getTafMessageType()
		{
			return this._package.iMessageType;
		}

		public int getTafTimeout()
		{
			return this._package.iTimeout;
		}

		public byte[] getTafBuffer()
		{
			return this._package.sBuffer;
		}

		public Dictionary<string, string> getTafContext()
		{
			return this._package.context;
		}

		public Dictionary<string, string> getTafStatus()
		{
			return this._package.status;
		}

		public int getTafResultCode()
		{
			int result = 0;
			try
			{
				string text = this._package.status[Const.STATUS_RESULT_CODE];
				result = ((text != null) ? int.Parse(text) : 0);
			}
			catch (Exception arg_27_0)
			{
				QTrace.Trace(arg_27_0.Message);
				return 0;
			}
			return result;
		}

		public string getTafResultDesc()
		{
			string text = this._package.status[Const.STATUS_RESULT_DESC];
			if (text == null)
			{
				return "";
			}
			return text;
		}
	}
}
