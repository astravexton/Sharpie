using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot
{
	public class Utilities
	{

	}
	public class Status
	{
		public static void Welcome()
		{
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.Yellow;
			Console.Write("Sharpie");
			Console.BackgroundColor = ConsoleColor.DarkGray;
			Console.Write ("|");
			Console.BackgroundColor = ConsoleColor.DarkYellow;
			Console.Write(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
			Console.ResetColor();
			Console.Write(Environment.NewLine);
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
}
