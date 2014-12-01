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
            if (Config.MainAppName == "Sharpie" || String.IsNullOrEmpty(Config.MainAppName))
            {
                Say.IRC(Formatting.Icon("Sharpie") + Formatting.SepMinor() + "http://sharpie.rocks/");
            }
            else
            {
                Say.IRC(Formatting.Icon(Config.MainAppName) + Formatting.Sep() + "powered by" + Formatting.IRC.Style.Bold() + " Sharpie" + Formatting.IRC.Reset() + Formatting.SepMinor() + "http://sharpie.rocks/");
            } 
		}
	}
}
