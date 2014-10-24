using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace IRCBot
{
	class Sharpie
	{
		public static StreamWriter writer;

		static void Main(string[] args)
		{
			// Hardcoded Connection
			var HardCodedConnection = true;
			var server = "irc.subluminal.net";
			var port = 6667;
			var nick = "Sharpie|debug";
			var channel = "#test";
			var pass = "";

			Status.Welcome();
			Line.Single();
			if (HardCodedConnection == false)
			{
				Status.Input("Server:  ");
				server = Console.ReadLine();
				Status.Input("Port:    ");
				port = Convert.ToInt32(Console.ReadLine());
				Status.Input("Nick:    ");
				nick = Console.ReadLine();
				Status.Input("Channel: ");
				channel = Console.ReadLine();
				Status.Input("Pass:    ");
				pass = Console.ReadLine();
			}
			else
			{
				Status.OK("Using hardcoded connection settings");
			}
			Line.Double();

			Status.Do("Initializing");

			var SERVER = server;
			var PORT = port;
			var PORTToString = port.ToString();
			var USER = "USER Sharpie 0 * :Sharpie";
			var NICK = nick;
			var CHANNEL = channel;

			NetworkStream stream;
			TcpClient irc;
			string inputLine;
			StreamReader reader;

			try
			{
				Status.Do("Connecting to IRC: '" + SERVER + ":" + PORTToString + "'");
				irc = new TcpClient(SERVER, PORT);
				stream = irc.GetStream();
				reader = new StreamReader(stream);
				writer = new StreamWriter(stream);
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
								}
								catch
								{
									Global.IRCMessage = "";
								}

								switch (Global.IRCCommand)
								{
									case "#consay":
										Plugins.Consay.Start();
										writer.Flush();
										break;
									case "#debug":
										Plugins.Debug.Start();
										writer.Flush();
										break;
									case "#hello":
										Plugins.HelloWorld.Start();
										writer.Flush();
										break;
									case "#join":
										writer.WriteLine("JOIN " + msg);
										writer.Flush();
										break;
									case "#np":
										Plugins.LastFM.Start();
										writer.Flush();
										break;
									case "#version":
										Plugins.Version.Start();
										writer.Flush();
										break;
									case "#view":
										Plugins.RSXView.Start();
										writer.Flush();
										break;
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
					Status.OK("Close Stream Reader/Writer");
					irc.Close();
					Status.OK("Close IRC connection");
					Status.OK("Bye bye!");

				}
			}
			catch (Exception e)
			{
				// Show the exception, sleep for a while and try to establish a new connection to irc server
				Status.Error("Oh noez! Something went wrong...");
				Status.Error(e.ToString());
				Thread.Sleep(5000);
				string[] argv = { };
				Main(argv);
			}

		}

	}

}
