using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class ZNC
	{
        // For all features to work...
        //  - *controlpanel need to be enabled
        //  - Sharpie needs to be admin

		public static void AddUser()
		{
            string username = MiscUtils.GetFirstWord(Global.IRCMessage);
            string password = MiscUtils.GetRandomString();
            if (username == null)
            {
                Say.IRCError("Username is missing", false);
            }
            else
            {
                Say.Raw("PRIVMSG *controlpanel :AddUser " + username + " " + password);
                Say.Raw("NOTICE " + Global.IRCUser + " :znc.rly.sx -- " + username + " / " + password);
            }
		}
	}
}
