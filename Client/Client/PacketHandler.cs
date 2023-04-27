using Client.Packets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class PacketHandler
    {
        static SimpleTcpClient client;

        public static void Init()
        {
            client = new SimpleTcpClient() { Delimiter = 0x0013, StringEncoder = Encoding.UTF8 };
            client.DelimiterDataReceived += Client_DelimiterDataReceived;
            client.Connect("127.0.0.1", 1286);
        }
        public delegate void OnStartGameNotifier(StartGameNotifier p);
        public static OnStartGameNotifier onStartGameNotifier = null;
        private static void Client_DelimiterDataReceived(object sender, Message e)
        {
            dynamic json = JObject.Parse(e.MessageString);
            int packettype = json.packetType;
            switch(packettype)
            {
                case 8:
                    if (onStartGameNotifier != null) onStartGameNotifier(JsonConvert.DeserializeObject<StartGameNotifier>(e.MessageString));
                    break;
            }
        }

        public static GameCreateResponse CreateGame(string username, int maxWin)
        {
            GameCreate toSend = new GameCreate()
            {
                maxWin = maxWin,
                username = username
            };
            string jsonstr = JsonConvert.SerializeObject(toSend);
            Message msg = client.WriteLineAndGetReply(jsonstr, TimeSpan.FromSeconds(1000));
            if (msg == null) { throw new Exception("Packet timed out"); }
            string responsestr = msg.MessageString;
            GameCreateResponse response = JsonConvert.DeserializeObject<GameCreateResponse>(responsestr);
            return response;
        }

        public static GameJoinResponse JoinGame(string joincode, string username)
        {
            GameJoin toSend = new GameJoin()
            {
                joinCode = joincode,
                username = username
            };
            string jsonstr = JsonConvert.SerializeObject(toSend);
            Message msg = client.WriteLineAndGetReply(jsonstr, TimeSpan.FromSeconds(1000));
            if (msg == null) { throw new Exception("Packet timed out"); }
            string responsestr = msg.MessageString;
            GameJoinResponse response = JsonConvert.DeserializeObject<GameJoinResponse>(responsestr);
            return response;
        }


    }
}
