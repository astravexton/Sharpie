using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
	class HelloWorld
	{
		public static void Start()
		{
			Say.IRC("Hello, world!");
		}
	}
}
