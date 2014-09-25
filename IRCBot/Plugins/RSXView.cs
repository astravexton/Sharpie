using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class RSXView
	{
		public static void Main(string host, string chan, string says, string cmd, string msg)
		{
			Say.IRC(chan, says + "http://rly.sx/v/?" + msg);
		}
	}
}
