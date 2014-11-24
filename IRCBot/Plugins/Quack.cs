using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class Quack
	{
		public static void Start()
		{
			string WhatDoesDuckyDo == TrueOrFalse();
			if(WhatDoesDuckyDo == true) {
				// does
				var DuckyDoes = DuckyDoes(Global.IRCUser, Global.IRCChannel);
				Say.Raw("\u0001ACTION " + DuckyDoes + " \u0001");
				if (DuckyDoes == "segfaults\x07")
				{
					IRCBot.Sharpie.writer.WriteLine("PART " + Global.IRCChannel + " Something has gone horribly wrong here.");
					IRCBot.Sharpie.writer.WriteLine("JOIN " + Global.IRCChannel);
				}
			}
			else
			{
				// says
				var DuckySays = DuckySays(Global.IRCUser, Global.IRCChannel);
				Say.Raw(DuckySays);
			}
		}
		public static string DuckDoes(string user, string chan)
		{
			string[] sayings = {
				"bashes " + user + "'s f'ckin' 'ed in",
				"cuddlehumps " + user,
				"dances with " + user,
				"divebombs " + user,
				"faps",
				"flaps",
				"flaps his wings at " + user,
				"gropes " + user,
				"jumps on top of " + user,
				"kicks " + user + " in the nuts",
				"makes kinky gay love with " + user,
				"noms on bread",
				"om nom noms",
				"poops on " + user + "'s head",

				// ugly way of making sure this happens most of the time
				"quacks", "quacks", "quacks", "quacks", "quacks",

				"quacks at " + user,
				"ruffles his feathers",
				"segfaults \x07",
				"sets fire to " + chan,
				"shakes his booty",
				"sits on " + user + "'s lap",
				"slaps " + user + "'s face off",
				"snuggles " + user,
				"stares at " + user,
				"throws bread at " + user,
				"tickles " + user
			};
			return sayings[new Random().Next(0, sayings.Length)];
		}
		public static string DuckSays(string user, string chan)
		{
			string[] sayings = {
				"Hello, world!"
			};
			return sayings[new Random().Next(0, sayings.Length)];
		}
		public static bool TrueOrFalse(string user, string chan)
		{
			Random gen = new Random();
			int prob = gen.Next(100);
			if (prob < 50) {
			    return true;
			}
			else
			{
			    return false;
			}
		}
		
	}
}
