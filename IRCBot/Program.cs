// why the fuck am I making an IRC bot in C#

using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using SharpConfig;
using System.Threading.Tasks;

namespace IRCBot
{
	class Sharpie
	{
		public static StreamWriter writer;

		static void Main(string[] args)
		{
			Status.Welcome();

			Status.OK("Quack quack motherfuckers");
			Line.Blank();

			if (Debugger.IsAttached == true)
			{
				Status.Error("Debugging");
				Line.Blank();
			}

			Status.Input("Config: ");
			var cfgPath = Console.ReadLine();

			// TODO: Swap these for global variables
			var server = "";
			int port = 0;
			var nick = "";
			var channel = "";
			var pass = "";
			Global.Master = "";

			if (string.IsNullOrEmpty(cfgPath))
			{
				Line.Blank();
				Status.OK("Not using configuration file for config (boo!)");
				Status.NewLine("Please enter config manually");
				Status.NewLine("This is a pretty bad idea and something will break");
				Line.Blank();
				Status.NewLine("Connection");
				Status.Input("Server:   ");
				server = Console.ReadLine();
				Status.Input("Port:     ");
				port = Convert.ToInt32(Console.ReadLine());
				Status.Input("Nick:     ");
				nick = Console.ReadLine();
				Status.Input("Channel:  ");
				channel = Console.ReadLine();
				Status.Input("Pass:     ");
				pass = Console.ReadLine();
				Status.NewLine("Admin");
				Status.Input("Admin:    ");
				Global.Master = Console.ReadLine();
			}
			else
			{
				Configuration config = Configuration.LoadFromFile(@cfgPath);

				Section cfgConnection = config["Connection"];
				Section cfgAdmin = config["Admin"];
				Section cfgSSHLocal = config["SSHLocal"];
				Section cfgLastFM = config["LastFM"];

				server = cfgConnection["Server"].Value;
				port = cfgConnection["Port"].GetValue<int>();
				nick = cfgConnection["Nick"].Value;
				channel = cfgConnection["Channel"].Value;
				pass = cfgConnection["Password"].Value;
				Global.Master = cfgAdmin["AdminUser"].Value;

				//Config.SSHLocalPort = cfgSSHLocal["Port"].GetValue<int>();
				//Config.SSHLocalUser = cfgSSHLocal["User"].Value;
				//Config.SSHLocalPass = cfgSSHLocal["Pass"].Value;

				//Config.LastFMKey = cfgLastFM["Key"].Value;
				//Config.LastFMSecret = cfgLastFM["Secret"].Value;

				Status.OK("Using '" + cfgPath + "' for settings");
			}
			Line.Blank();
			Line.Double();
			Line.Blank();

			Status.Do("Initializing");

			Global.QuitKey = MiscUtils.GetRandomString();
			Status.Error("To quit Sharpie from IRC...");
			Status.NewLine(" - Do '#stop " + Global.QuitKey + "'");
			//Status.NewLine(" - Exit as '" + Global.Master + "'");

			var SERVER = server;
			var PORT = port;
			var PORTToString = port.ToString();
			var USER = "USER Sharpie 0 * :Sharpie";
			var NICK = nick;
			var CHANNEL = "";
			if (!string.IsNullOrEmpty(channel))
			{
				CHANNEL = "#" + channel;
			}

			NetworkStream stream;
			TcpClient irc;
			string inputLine;
			StreamReader reader;

			Console.Title = server + " | Sharpie";

			try
			{
				Status.Do("Connecting to IRC: '" + SERVER + ":" + PORTToString + "'");
				irc = new TcpClient(SERVER, PORT);
				stream = irc.GetStream();
				reader = new StreamReader(stream);
				writer = new StreamWriter(stream);
				Stream.IRC.Writer = writer;
				Stream.IRC.Reader = reader;
				Status.Do("Setting Nick: '" + NICK + "'");
				writer.WriteLine("NICK " + NICK);
				writer.Flush();
				if (pass != "")
				{
					writer.WriteLine("PASS " + pass);
					writer.Flush();
				}
				writer.WriteLine(USER);
				writer.Flush();

				while (true)
				{
					while ((inputLine = reader.ReadLine()) != null)
					{
						Status.SendIn(inputLine);

						// Split the lines sent from the server by spaces. This seems the easiest way to parse them.
						string[] splitInput = inputLine.Split(new Char[] { ' ' });

						if (splitInput[0] == "PING")
						{
							string PongReply = splitInput[1];
							//Console.WriteLine("->PONG " + PongReply);
							writer.WriteLine("PONG " + PongReply);
							writer.Flush();
							continue;
						}

						switch (splitInput[1])
						{
							// This is the 'raw' number, put out by the server. Its the first one
							// so I figured it'd be the best time to send the join command.
							// I don't know if this is standard practice or not.
							case "001":
								string JoinString = "JOIN " + CHANNEL;
								Status.Do("Joining Channel: '" + CHANNEL + "'");
								writer.WriteLine(JoinString);
								writer.Flush();
								writer.WriteLine("AWAY");
								writer.Flush();
								break;
							case "PRIVMSG":
								Global.IRCStatus = splitInput[1];
								Global.IRCHost = splitInput[0].Substring(1);
								Global.IRCUser = Global.IRCHost.Substring(0, Global.IRCHost.LastIndexOf("!") + 1);
								Global.IRCUser = Global.IRCUser.Remove(Global.IRCUser.Length - 1);
								Global.IRCChannel = splitInput[2];
								Global.IRCCommand = splitInput[3].Substring(1);
								Global.IRCMessage = "";
								Global.Says = "\u000308\u2502\u000315 ";

								var status = splitInput[1];
								var host = splitInput[0].Substring(1);
								var user = host.Substring(0, host.LastIndexOf("!") + 1);
								user = user.Remove(user.Length - 1);
								var chan = splitInput[2];
								var cmd = splitInput[3].Substring(1);
								var says = "\u000308\u2502\u000315 ";
								var msg = "";
								try
								{
									for (var i = 4; i < splitInput.Length; i++)
									{
										Global.IRCMessage += splitInput[i] + " ";
									}
									Global.IRCMessage = Global.IRCMessage.Remove(Global.IRCMessage.Length - 1);
								}
								catch
								{
									Global.IRCMessage = "";
								}

								switch (Global.IRCCommand)
								{
									// self-contained
									case "!quack.debug":
									case "#quack.debug":
										Plugins.Debug.Start();
										writer.Flush();
										break;
									case "#quack":
									case "!quack":
										Plugins.Quack.Start();
										writer.Flush();
										break;

									// Keep on truckin'
									default:
										break;
								}
								writer.Flush();
								break;
							default:
								break;
						}

					}

					// Close all streams
					Status.Error("Shutdown");
					writer.Close();
					reader.Close();
					irc.Close();
				}
			}
			catch (Exception e)
			{
				Status.Error("CRASH D:");
				Status.Error(e.ToString());
				Thread.Sleep(50000);
				string[] argv = { };
				//Main(argv);
			}

		}

	}

}
