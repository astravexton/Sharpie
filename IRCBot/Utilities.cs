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
