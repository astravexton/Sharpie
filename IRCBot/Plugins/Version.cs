using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class Version
	{
		public static void Main(string host, string chan, string says, string cmd, string msg)
		{
			Sharpie.writer.WriteLine("PRIVMSG " + chan + " :" + says + "Sharpie" + " | " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + " | " + Environment.OSVersion + " | " + IsThisMono());
		}
		public static string IsThisMono() {
			Type t = Type.GetType ("Mono.Runtime");
			if (t != null)
				return "Mono";
			else
				return ".NET";
		}
	}
}
