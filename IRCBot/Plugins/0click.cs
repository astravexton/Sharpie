using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// https://github.com/timkly/DuckDuckGo.Net
using DuckDuckGo.Net;

namespace IRCBot.Plugins
{
	class ZeroClick
	{
		public static void Start()
		{
			var search = new Search
			{
				NoHtml = true,
				NoRedirects = true,
				IsSecure = true,
				SkipDisambiguation = true,
				ApiClient = new HttpWebApi()
			};
			var searchResult = search.Query(Global.IRCMessage, "Sharpie");

			if (Global.IRCMessage.StartsWith("!"))
			{

				if (Global.IRCMessage.StartsWith("!porn"))
				{
					if (Global.IRCMessage.StartsWith("!porn.gay"))
					{
						var query = Global.IRCMessage.Substring(10, Global.IRCMessage.Length - 10);
						query = query.Replace(" ", "+");
						query = "http://www.pornmd.com/gay/" + query + "?";
						Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + query);
					}
					else if (Global.IRCMessage.StartsWith("!porn.str8"))
					{
						var query = Global.IRCMessage.Substring(11, Global.IRCMessage.Length - 11);
						query = query.Replace(" ", "+");
						query = "http://www.pornmd.com/straight/" + query + "?";
						Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + query);
					}
				}
				else
				{
					Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + searchResult.Redirect.ToString());
				}
			}
			else if (string.IsNullOrWhiteSpace(searchResult.Heading.ToString()) == false)
			{
				Say.IRC(Formatting.Icon("!") + Formatting.Sep() + searchResult.Heading.ToString());
				Say.IRC(Formatting.Icon("?") + Formatting.Sep() + searchResult.Abstract.ToString());
				Say.IRC(Formatting.Minor() + Formatting.Icon("\u2197") + Formatting.Sep() + searchResult.AbstractSource.ToString() + ": " + searchResult.AbstractUrl.ToString());
			}
			else
			{
				Say.IRC(Formatting.Minor() + "No results found :(");
			}
		}

		public static void Ducky(bool showLink)
		{
			var search = new Search
			{
				NoHtml = true,
				NoRedirects = true,
				IsSecure = true,
				SkipDisambiguation = true,
				ApiClient = new HttpWebApi()
			};
			var searchResult = search.Query("!ducky " + Global.IRCMessage, "Sharpie");
			Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + searchResult.Redirect.ToString());
		}
	}
}
