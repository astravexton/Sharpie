using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class LastFM
	{
		public static void Start()
		{
			Say.IRC(Formatting.Icon("\u266B") + Formatting.Sep() + "Artist - Title");
		}
	}
}
