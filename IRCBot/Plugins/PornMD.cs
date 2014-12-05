using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace IRCBot.Plugins
{
    class PornMD
    {
        public static void Start()
        {
            string query = Global.IRCMessage.Replace("--straight", "")
                .Replace("--gay", "")
                .Replace("--shemale", "")
                .Replace("--random", "")
                .Replace("--top", "")
                .Replace("--recent", "")
                .Replace("--relevant", "")
                .Replace("--best", "")
                .Replace("--more", "");
            string orientation = Config.PornMDOrientation;
            bool random = false;
            string recent = "";
            int resultNumber = 0;
            string source = "";

            if (Global.IRCMessage.Contains("--straight"))
            {
                orientation = "straight";
            }
            else if (Global.IRCMessage.Contains("--gay"))
            {
                orientation = "gay";
            }
            else if (Global.IRCMessage.Contains("--shemale"))
            {
                orientation = "tranny";
            }

            if (Global.IRCMessage.Contains("--random"))
            {
                Random rnd = new Random();
                random = true;
                resultNumber = rnd.Next(1, 25);
            }
            else if (Global.IRCMessage.Contains("--top"))
            {
                random = false;
            }

            if (Global.IRCMessage.Contains("--recent"))
            {
                recent = "&o=mr";
            }
            else if (Global.IRCMessage.Contains("--relevant") || Global.IRCMessage.Contains("--best"))
            {
                recent = "";
            }

            //var client = new WebClient();
            //client.Headers.Add("User-Agent", Global.UAS); //my endpoint needs this...
            try
            {
                //var response = client.DownloadString(new Uri("http://www.pornmd.com/" + orientation + "/" + query + "?start=50&ajax=true&limit=50&format=json" + recent));
				var response = GetFile("http://www.pornmd.com/" + orientation + "/" + query + "?start=50&ajax=true&limit=50&format=json" + recent);
                var o = JsonConvert.DeserializeObject<JSON.Root>(response);

                switch (o.videos[0].source.ToLower())
                {
                    case "pornhub":
                        source = "PornHub";
                        break;
                    case "redtube":
                        source = "RedTube";
                        break;
                    case "youporn":
                        source = "YouPorn";
                        break;
                    case "spankwire":
                        source = "SpankWire";
                        break;
                    case "xtube":
                        source = "XTube";
                        break;
                    case "tube8":
                        source = "Tube8";
                        break;
                    case "keezmovies":
                        source = "KeezMovies";
                        break;
                    case "extremetube":
                        source = "ExtremeTube";
                        break;
                    case "mofosex":
                        source = "MofoSex";
                        break;
                    case "gaytube":
                        source = "GayTube";
                        break;
                }

                if (Global.IRCMessage.Contains("--more"))
                {
                    Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + "http://www.porn.md/" + orientation + "/" + query.Replace(" ", "+"));
                }
                else
                {
                    var videoURL = MiscUtils.GetRedir("http://www.pornmd.com" + o.videos[resultNumber].link);
                    //var videoURL = "http://www.pornmd.com" + o.videos[resultNumber].link;

                    Say.IRC(Formatting.Icon("!") + Formatting.Sep() + o.videos[resultNumber].title);
                    Say.IRC(Formatting.Icon("?") + Formatting.Sep()
                        + source + Formatting.SepMinor()
                        + o.videos[resultNumber].rating.ToString() + "%" + Formatting.SepMinor()
                        + o.videos[resultNumber].duration.Substring(1) + Formatting.SepMinor()
                        + o.videos[resultNumber].pub_date);
                    Say.IRC(Formatting.Icon("\u2197") + Formatting.Sep() + videoURL + Formatting.IRC.Style.Bold() + Formatting.IRC.Colors.Red() + " [nsfw]");
                }
            }
            catch
            {
            }
        }

		static string GetFile(string strURL)
		{
			string strResult;
			strResult = " ";
			try
			{
				WebResponse objResponse;
				WebRequest objRequest = HttpWebRequest.Create(strURL);
				objResponse = objRequest.GetResponse();
				using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
				{
					strResult = sr.ReadToEnd();
					sr.Close();
				}
				strResult.Replace("\n", Environment.NewLine);
			}
			catch (Exception e)
			{
				strResult = e.ToString();
			}
			return strResult;
		}

        public class JSON
        {
            public class Root
            {
                public List<Videos> videos { get; set; }
            }
            public class Videos
            {
                public string title { get; set; }
                public string thumb { get; set; }
                public string link { get; set; }
                public string source { get; set; }
                public decimal rating { get; set; }
                public string duration { get; set; }
                public string pub_date { get; set; }
            }
        }
    }
}
