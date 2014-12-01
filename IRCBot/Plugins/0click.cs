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
            string query;
            if (String.IsNullOrEmpty(Global.IRCMessage))
            {
                query = "i forgot to type anything in here so tickle me";
            }
            else
            {
                query = Global.IRCMessage;
            }
			var search = new Search
			{
				NoHtml = true,
				NoRedirects = true,
				IsSecure = true,
                SkipDisambiguation = true,
				ApiClient = new HttpWebApi()
			};
			var searchResult = search.Query(query, "Sharpie");
			if (Global.IRCMessage.StartsWith("!"))
			{
				Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + searchResult.Redirect.ToString());
			}
			else if (searchResult.AnswerType == "info")
			{
				Say.IRC(Formatting.Icon("?") + Formatting.Sep() + searchResult.Answer.ToString());
			}
            else if (searchResult.AnswerType == "conversions")
            {
                Say.IRC(Formatting.Icon("?") + Formatting.Sep() + searchResult.Answer.ToString());
            }
            else if (string.IsNullOrWhiteSpace(searchResult.Answer.ToString()) == false) 
            {
                Say.IRC(Formatting.Icon("?") + Formatting.Sep() + searchResult.Answer.ToString());
            }
			else if (string.IsNullOrWhiteSpace(searchResult.Heading.ToString()) == false)
			{
				Say.IRC(Formatting.Icon("!") + Formatting.Sep() + searchResult.Heading.ToString());
				if (string.IsNullOrWhiteSpace(searchResult.Abstract.ToString()) == false)
				{
					Say.IRC(Formatting.Icon("?") + Formatting.Sep() + searchResult.Abstract.ToString());
				}
				if (string.IsNullOrWhiteSpace(searchResult.AbstractSource.ToString()) == false)
				{
                    Say.IRC(Formatting.Minor() + Formatting.Icon("\u2197") + Formatting.Sep() + searchResult.AbstractSource.ToString() + ": " + searchResult.AbstractUrl.ToString());
				}
				else
				{
					Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + searchResult.AbstractUrl.ToString());
				}
			}
			else
			{
				Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + "https://duckduckgo.com/?q=" + Global.IRCMessage.Replace(" ", "%20"));
				//Say.IRCMinor(Formatting.Icon("\u266B") + Formatting.Sep() + Formatting.Minor() + "Nothing found");
			}

		}
	}
}
