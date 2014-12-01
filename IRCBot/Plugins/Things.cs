using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCBot.Plugins
{
    class Things
    {
        public static void Start()
        {
            switch (Global.IRCMessage)
            {
                case "lod":
                    Say.IRC("\u0CA0_\u0CA0");
                    break;
            }
        }
    }
}
