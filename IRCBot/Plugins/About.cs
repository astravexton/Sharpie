using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IRCBot.Plugins
{
	class About
	{
		public static void Start()
		{
            Say.IRC(Formatting.Icon("Sharpie") + Formatting.Sep() + "http://sharpie.rocks/");
		}
	}
}
