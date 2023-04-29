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
        private static readonly string splitter = "[;]";
        private static readonly int timeout = 30000;
        public static void Init()
        {
            client = new SimpleTcpClient() { Delimiter = 0x0013, StringEncoder = Encoding.UTF8 };
            client.DelimiterDataReceived += Client_DelimiterDataReceived;
            client.Connect("188.132.198.137", 1286);
        }
        public delegate void OnStartGameNotifier(StartGameNotifier p);
        public delegate void OnEndTourNotifier(EndTourNotif p);
        public static OnStartGameNotifier onStartGameNotifier = null;
        public static OnEndTourNotifier onEndTourNotifier = null;



        private static void Client_DelimiterDataReceived(object sender, Message e)
        {
            string[] pairs = e.MessageString.Split(splitter);

            foreach(string jsonstr in pairs)
            {
                dynamic json = JObject.Parse(jsonstr);
                int packettype = json.packetType;
                switch (packettype)
                {
                    case 8:
                        if (onStartGameNotifier != null) onStartGameNotifier(JsonConvert.DeserializeObject<StartGameNotifier>(jsonstr));
                        break;
                    case 7:
                        if (onEndTourNotifier != null) onEndTourNotifier(JsonConvert.DeserializeObject<EndTourNotif>(jsonstr));
                        break;
                }
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
            Message msg = client.WriteLineAndGetReply(jsonstr, TimeSpan.FromSeconds(timeout));
            if (msg == null) { throw new Exception("Packet timed out"); }

            foreach(string responsestr in msg.MessageString.Split(splitter))
            {
                dynamic jsonResponse = JObject.Parse(responsestr);
                if ((int)jsonResponse.packetType != 2) continue;
                GameCreateResponse response = JsonConvert.DeserializeObject<GameCreateResponse>(responsestr);
                return response;
            }

            return null;
        }

        public static GameJoinResponse JoinGame(string joincode, string username)
        {
            GameJoin toSend = new GameJoin()
            {
                joinCode = joincode,
                username = username
            };
            string jsonstr = JsonConvert.SerializeObject(toSend);
            Message msg = client.WriteLineAndGetReply(jsonstr, TimeSpan.FromSeconds(timeout));
            if (msg == null) { throw new Exception("Packet timed out"); }

            foreach (string responsestr in msg.MessageString.Split(splitter))
            {
                dynamic jsonResponse = JObject.Parse(responsestr);
                if ((int)jsonResponse.packetType != 4) continue;
                GameJoinResponse response = JsonConvert.DeserializeObject<GameJoinResponse>(responsestr);
                return response;
            }

            return null;
        }

        public static MakeMoveResponse makeMove(RPS rps, string secret)
        {
            MakeMove toSend = new MakeMove()
            {
                rps = rps,
                secret = secret
            };

            string jsonstr = JsonConvert.SerializeObject(toSend);
            Message msg = client.WriteLineAndGetReply(jsonstr, TimeSpan.FromSeconds(timeout));
            if (msg == null) { throw new Exception("Packet timed out"); }

            foreach (string responsestr in msg.MessageString.Split(splitter))
            {
                dynamic jsonResponse = JObject.Parse(responsestr);
                if ((int)jsonResponse.packetType != 6) continue;
                MakeMoveResponse response = JsonConvert.DeserializeObject<MakeMoveResponse>(responsestr);
                return response;
            }

            return null;
        }
    }
}
