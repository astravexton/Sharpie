using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using System.IO;

namespace IRCBot.Plugins
{
    class SSH
    {
        public static void Start()
        {
        }
        public static void Local()
        {
            // Setup Credentials and Server Information
            ConnectionInfo ConnNfo = new ConnectionInfo("localhost", Config.SSHLocalPort, Config.SSHLocalUser,
                new AuthenticationMethod[]{
 
                // Pasword based Authentication
                new PasswordAuthenticationMethod(Config.SSHLocalUser,Config.SSHLocalPass)
            }
            );

            using (var sshclient = new SshClient(ConnNfo))
            {
                try
                {
                    sshclient.Connect();
                    var output = sshclient.CreateCommand(Global.IRCMessage).Execute().ToString();
                    //Say.IRC(output);
                    //Status.Warn(output);
                    using (StringReader reader = new StringReader(output))
                    {
                        while (true)
                        {
                            string line = reader.ReadLine();
                            if (line == null)
                            {
                                break;
                            }
                            Say.IRC(line); // Use line.
                        }
                    }
                    sshclient.Disconnect();
                }
                catch
                {
                    Say.IRCError("Could not connect to '" + "localhost" + "' via SSH");
                }
            }
        }
        public static void Remote()
        {
            Status.Error("Not implemented");
        }
    }
}
