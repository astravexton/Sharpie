using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class Debug
	{
		public static void Start()
		{
			switch (Global.IRCMessage)
			{
				case "os ":
					OS();
					break;
				default:
					FullMonty();
					break;
			}
		}

		public static void FullMonty()
		{
			Plugins.Version.Start();
			Say.IRC("Host: " + Global.IRCHost + Formatting.Sep() + "User: " + Global.IRCUser + Formatting.Sep() + "Channel: " + Global.IRCChannel + Formatting.Sep() + "Says: " + Global.Says + Formatting.Sep() + "Cmd: " + Global.IRCCommand + Formatting.Sep() + "Type: " + Global.IRCStatus);
			Say.IRC("Msg: " + Global.IRCMessage);
		}
		public static void OS()
		{
			Say.IRC("OS: " + Environment.OSVersion + " @ " + Environment.MachineName);
		}
	}
}
