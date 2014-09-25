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
			Sharpie.writer.WriteLine("PRIVMSG " + chan + " :" + says + "Sharpie, v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + "[http://github.com/electricduck/sharpie]");
		}
	}
}
