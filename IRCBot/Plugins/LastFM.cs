using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lastfm.Services;

namespace IRCBot.Plugins
{
	class LastFM
	{
		public static void Start()
		{
			string APIKey = Config.LastFMKey;
			string APISecret = Config.LastFMSecret;
			Session session = new Session(APIKey, APISecret);

			var user = new User(Global.IRCMessage, session);

			string NP = "";

			try
			{
				NP = user.GetNowPlaying().ToString();
				Say.IRCMinor(Formatting.Icon("\u266B") + Formatting.SepMajor() + NP);
			}
			catch
			{
				Say.IRCMinor(Formatting.Icon("\u266B") + Formatting.SepMajor() + Formatting.Minor() + "Nothing is playing :(");
			}
		}
	}
}
