using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace IRCBot
{
	public class Perms
	{
		public static void RequireToRun(string user)
		{

		}
	}
	public class Say
	{
		public static void IRC(string text)
		{
			Sharpie.writer.WriteLine("PRIVMSG " + Global.IRCChannel + " :" + Global.Says + text);
		}
		public static void IRCMinor(string text)
		{
			Sharpie.writer.WriteLine("PRIVMSG " + Global.IRCChannel + " :" + Global.Says + "\u000314" + text);
		}
		public static void Cmd(string text)
		{
			Sharpie.writer.WriteLine(text);
		}
		public static void Console()
		{
			Status.Error(Global.IRCMessage);
		}
	}
	public class Status
	{
		public static void Welcome()
		{
			Global.Version = " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			Console.Title = "Sharpie";
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("  ____  _                      _      ");
			Console.WriteLine(" / ___|| |__   __ _ _ __ _ __ (_) ___ ");
			Console.WriteLine(" \\___ \\| '_ \\ / _` | '__| '_ \\| |/ _ \\");
			Console.WriteLine("  ___) | | | | (_| | |  | |_) | |  __/");
			Console.WriteLine(" |____/|_| |_|\\__,_|_|  | .__/|_|\\___|");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write(" ");
			Console.Write(Global.Version.PadLeft(23, '='));
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("|_|");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("===========");
			Console.ResetColor();
			Console.ResetColor();
			Line.Blank();
			Line.Blank();
		}
		public static void Input(string input)
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write("= ");
			Console.ResetColor();
			Console.Write(input);
		}
		public static void OK(string input)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("! ");
			Console.ResetColor();
			Console.Write(input + Environment.NewLine);
		}
		public static void Error(string input)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("! ");
			Console.ResetColor();
			Console.Write(input + Environment.NewLine);
		}
		public static void Warn(string input)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("! ");
			Console.ResetColor();
			Console.Write(input + Environment.NewLine);
		}
		public static void Do(string input)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("- ");
			Console.ResetColor();
			Console.Write(input + Environment.NewLine);
		}
		public static void SendIn(string input)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("<");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("-");
			Console.ResetColor();
			Console.Write(input + Environment.NewLine);
		}
		public static void SendOut(string input)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(">");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("-");
			Console.ResetColor();
			Console.Write(input + Environment.NewLine);
		}
		public static void NewLine(string input)
		{
			Console.Write("  ");
			Console.Write(input + Environment.NewLine);
		}
	}
	public class Line
	{
		public static void Single()
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("---");
			Console.ResetColor();
		}
		public static void Double()
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("===");
			Console.ResetColor();
		}
		public static void Blank()
		{
			Console.WriteLine(" ");
		}
	}
	public class Formatting
	{
		public static string Sep()
		{
			return " \u000314| \u000f";
		}
		public static string Icon(string icon)
		{
			return "\u0002\u000300" + icon + "\u000f";
		}
		public static string Minor()
		{
			return "\u000314";
		}
		public class IRC
		{
			public static string Space()
			{
				return " ";
			}
			public static string Reset()
			{
				return "\u000f";
			}
			public class Colors
			{
				public static string White()
				{
					return "\u000300";
				}
				public static string Black()
				{
					return "\u000301";
				}
				public static string Blue()
				{
					return "\u000302";
				}
				public static string Green()
				{
					return "\u000303";
				}
				public static string Red()
				{
					return "\u000304";
				}
				public static string Brown()
				{
					return "\u000305";
				}
				public static string Purple()
				{
					return "\u000306";
				}
				public static string Orange()
				{
					return "\u000307";
				}
				public static string Yellow()
				{
					return "\u000308";
				}
				public static string Lime()
				{
					return "\u000309";
				}
				public static string Teal()
				{
					return "\u000310";
				}
				public static string Aqua()
				{
					return "\u000311";
				}
				public static string Royal()
				{
					return "\u000312";
				}
				public static string Fuchsia()
				{
					return "\u000313";
				}
				public static string Grey()
				{
					return "\u000314";
				}
				public static string Silver()
				{
					return "\u000315";
				}
			}
			public class Style
			{
				public static string Bold()
				{
					return "\u0002";
				}
				public static string Italic()
				{
					return "\u001D";
				}
				public static string Underline()
				{
					return "\u001F";
				}
			}
			public static string Reverse()
			{
				return "\u0016";
			}
		}
	}
	public class PluginHelp
	{
		public static void Main(string name, string version, string desc)
		{
			if (String.IsNullOrEmpty(version) || String.IsNullOrWhiteSpace(version))
			{
				Sharpie.writer.WriteLine(name + " | " + desc);
			}
			else
			{
				Sharpie.writer.WriteLine(name + " (v" + version + ")" + " | " + desc);
			}
		}
	}
    public class Stop
    {
        public class Error {
            public static void Generic(int code)
                {
                    Console.ReadKey();
                    System.Environment.Exit(code);
                }
        }
        
    }
	public class MiscUtils
	{
		public static string GetRandomString()
		{
			string path = Path.GetRandomFileName();
			path = path.Replace(".", ""); // Remove period.
			return path;
		}
	}
}
