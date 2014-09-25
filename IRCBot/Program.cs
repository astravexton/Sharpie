using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

/* 
* This program establishes a connection to irc server and joins a channel. Thats it.
*
* Coded by Pasi Havia 17.11.2001 http://koti.mbnet.fi/~curupted
*
* Updated / fixed by Blake 09.10.2010
*/

class IrcBot
{
	// IRC server to connect 
	public static string SERVER = "irc.subluminal.net";

	// IRC server's port (6667 is default port)
	private static int PORT = 6667;

	// User information defined in RFC 2812 (Internet Relay Chat: Client Protocol) is sent to irc server
	private static string USER = "USER Sharpie 0 * :Sharpie";

	// Bot's nickname
	private static string NICK = "Sharpie";

	// Channel to join
	private static string CHANNEL = "#sharpie";

	// And here's where the magic happens...

	public static StreamWriter writer;
	static void Main(string[] args)
	{
		NetworkStream stream;
		TcpClient irc;
		string inputLine;
		StreamReader reader;

		try
		{
			irc = new TcpClient(SERVER, PORT);
			stream = irc.GetStream();
			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);
			writer.WriteLine("NICK " + NICK);
			writer.Flush();
			writer.WriteLine(USER);
			writer.Flush();

			Console.WriteLine("Sharpie (v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + ")");
			Console.WriteLine("---");

			while (true)
			{
				while ((inputLine = reader.ReadLine()) != null)
				{
					Console.WriteLine("<-" + inputLine);

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
							writer.WriteLine(JoinString);
							writer.Flush();
							break;
						case "PRIVMSG":
							var host = splitInput[0].Substring(1);
							var chan = splitInput[2];
							var msg = splitInput[3].Substring(1);

							switch (msg)
							{
								case "#hello":
									writer.WriteLine("PRIVMSG " + chan +  " :" + "Hello, world!");
									writer.Flush();
									break;
								case "#version":
									writer.WriteLine("PRIVMSG " + chan + " :" + "v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
									writer.Flush();
									break;
								case "#join":
									writer.WriteLine("JOIN " + msg);
									writer.Flush();
									break;
								default:
									break;
							}

							//Console.WriteLine("! Host:    " + splitInput[0]);
							//Console.WriteLine("! Channel: " + splitInput[2]);
							//Console.WriteLine("! Message: " + splitInput[3].Substring(1));
							writer.Flush();
							break;
						default:
							break;
					}

				}

				// Close all streams
				writer.Close();
				reader.Close();
				irc.Close();
			}
		}
		catch (Exception e)
		{
			// Show the exception, sleep for a while and try to establish a new connection to irc server
			Console.WriteLine(e.ToString());
			Thread.Sleep(5000);
			string[] argv = { };
			Main(argv);
		}

	}

}
