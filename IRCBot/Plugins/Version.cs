using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IRCBot.Plugins
{
	class Version
	{
		public static void Start()
		{
			Say.IRC(Formatting.Icon("Sharpie [tree/quack]") + Formatting.Sep() + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + Formatting.Sep() + Environment.OSVersion + " (" + Environment.MachineName + ")" + Formatting.Sep() + IsThisMono() + Debug());
		}
		public static string IsThisMono()
		{
			Type t = Type.GetType("Mono.Runtime");
			if (t != null)
				return "Mono";
			else
				return ".NET";
		}
		public static string Debug()
		{
			if (Debugger.IsAttached == true)
			{
				return " (Debugging)";
			}
			else
			{
				return "";
			}
		}
	}
}
