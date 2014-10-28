using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class RSXView
	{
		public static void Start()
		{
			Say.IRC("http://rly.sx/v/?" + Global.IRCMessage);
		}
	}
}
