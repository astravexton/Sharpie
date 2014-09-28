using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class Debug
	{
		public static void Main(string status, string host, string user, string chan, string says, string cmd, string msg)
		{
			Plugins.Version.Main (host, chan, says, cmd, msg);
			Say.IRC(chan, says + "Host: " + host + Formatting.Sep() + "User: " + user + Formatting.Sep() + "Channel: " + chan + Formatting.Sep() + "Says: " + says + Formatting.Sep() + "Cmd: " + cmd + Formatting.Sep() + "Type: " + status);
			Say.IRC(chan, says + "Msg: " + msg);
		}
	}
}
