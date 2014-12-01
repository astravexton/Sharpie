using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot
{

	public static class Global
	{
		public static String Version = "";
		public static String IRCStatus = "";
		public static String IRCHost = "";
		public static String IRCUser = "";
		public static String IRCChannel = "";
		public static String IRCCommand = "";
		public static String IRCMessage = "";
		public static String Says = "";
		public static String QuitKey = "";
		public static String Master = "";
        public static String OSOverride = "";
	}

	public static class Stream
	{
		public static class IRC
		{
			public static System.IO.StreamWriter Writer;
			public static System.IO.StreamReader Reader;
		}
	}

	public static class Config
	{
		public static String MainAppName = "";
        public static String MainAdminUser = "";
        public static String MainOSName = "";

		public static String ConnectionServer = "";
		public static Int32 ConnectionPort = 0;
		public static String ConnectionNick = "";
		public static String ConnectionChannel = "";
		public static String Password = "";

		public static String LastFMKey = "";
		public static String LastFMSecret = "";

        public static String PornMDOrientation = "";

        public static Int32 SSHLocalPort = 0;
        public static String SSHLocalUser = "";
        public static String SSHLocalPass = "";
	}
}
