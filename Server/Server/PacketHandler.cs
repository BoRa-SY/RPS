using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server.Classes;
using Server.Packets;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Server
{
    public class PacketHandler
    {
        SimpleTcpServer server;



        public PacketHandler(OnGameCreate ogc, OnGameJoin ogj, OnMakeMove omm, OnEndGame oeg)
        {
            onGameCreate = ogc;
            onGameJoin = ogj;
            onMakeMove = omm;
            onEndGame = oeg;

            server = new SimpleTcpServer() { Delimiter = 0x0013, StringEncoder = Encoding.UTF8};
            server.DelimiterDataReceived += Server_DelimiterDataReceived;
            server.Start(IPAddress.Parse("127.0.0.1"), 1286);
            Console.WriteLine("SV Started");
        }
        public delegate void OnGameCreate(Server.Packets.GameCreate p, Message m);
        public delegate void OnGameJoin(Server.Packets.GameJoin p, Message m);
        public delegate void OnMakeMove(Server.Packets.MakeMove p);
        public delegate void OnEndGame(Server.Packets.EndGame p);
        OnGameCreate onGameCreate;
        OnGameJoin onGameJoin;
        OnMakeMove onMakeMove;
        OnEndGame onEndGame;




        private void Server_DelimiterDataReceived(object sender, Message e)
        {
            try
            {
                string jsonstr = e.MessageString;
                dynamic json = JObject.Parse(jsonstr);
                int packettype = json.packetType;

                switch(packettype)
                {
                    case 1: onGameCreate(JsonConvert.DeserializeObject<GameCreate>(jsonstr), e); break;
                    case 3: onGameJoin(JsonConvert.DeserializeObject<GameJoin>(jsonstr), e); break;
                    case 5: onMakeMove(JsonConvert.DeserializeObject<MakeMove>(jsonstr)); break;
                    case 9: onEndGame(JsonConvert.DeserializeObject<EndGame>(jsonstr)); break;
                    default: throw new Exception("Incorrect packet type");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: Couldn't parse packet\nPacket: {e.MessageString}\nEx: {ex.Message}");
            }
        }

        public void SendPacket(GameCreateResponse p, string secret)
        {
            SS_Game game = GameHandler.games.Where(x => x.player1.Secret == secret || x.player2.Secret == secret).FirstOrDefault();
            
            Message tcpmsg = game.player1.Secret == secret ? game.player1.TCPMessage : game.player2.TCPMessage;

            string jsonstr = JsonConvert.SerializeObject(p);

            tcpmsg.Reply(jsonstr);
        }
        public void SendPacket(GameJoinResponse p, string secret)
        {
            SS_Game game = GameHandler.games.Where(x => x.player1.Secret == secret || x.player2.Secret == secret).FirstOrDefault();

            Message tcpmsg = game.player1.Secret == secret ? game.player1.TCPMessage : game.player2.TCPMessage;

            string jsonstr = JsonConvert.SerializeObject(p);

            tcpmsg.Reply(jsonstr);
        }
        public void SendPacket(GameJoinResponse p, Message m)
        {
            string jsonstr = JsonConvert.SerializeObject(p);

            m.Reply(jsonstr);
        }
        public void SendPacket(MakeMoveResponse p, string secret)
        {
            SS_Game game = GameHandler.games.Where(x => x.player1.Secret == secret || x.player2.Secret == secret).FirstOrDefault();

            Message tcpmsg = game.player1.Secret == secret ? game.player1.TCPMessage : game.player2.TCPMessage;

            string jsonstr = JsonConvert.SerializeObject(p);

            tcpmsg.Reply(jsonstr);
        }
        public void SendPacket(EndGameNotifier p, SS_Game game)
        {
            string jsonstr = JsonConvert.SerializeObject(p);
            game.player1.TCPMessage.ReplyLine(jsonstr);
            game.player2.TCPMessage.ReplyLine(jsonstr);
        }

        public void SendPacket(StartGameNotifier p, SS_Game game)
        {
            string jsonstr = JsonConvert.SerializeObject(p);
            game.player1.TCPMessage.ReplyLine(jsonstr);
        }
        public void SendPacket(EndTourNotifier p, SS_Game game)
        {
            string jsonstr = JsonConvert.SerializeObject(p);
            game.player1.TCPMessage.ReplyLine(jsonstr);
            game.player2.TCPMessage.ReplyLine(jsonstr);
        }
    }
}
