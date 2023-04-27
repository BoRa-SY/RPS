using Server.Classes;
using Server.Packets;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public static class GameHandler
    {
        public static List<SS_Game> games;
        static PacketHandler packetHandler;
        public static void Init()
        {
            games = new List<SS_Game>();
            packetHandler = new PacketHandler(onGameCreate, onGameJoin, onMakeMove,onEndGame);
        }

        public static void onGameCreate(Server.Packets.GameCreate p, Message e)
        {
            SS_Game game = new SS_Game()
            {
                player1 = new Player()
                {
                    Secret = Utils.createPlayerSecret(),
                    TCPMessage = e,
                    username = p.username,
                    wins = 0
                },
                maxWin = p.maxWin,
                joinCode = Utils.createJoinCode()
            };
            GameCreateResponse response = new GameCreateResponse()
            {
                joinCode = game.joinCode,
                p1secret = game.player1.Secret
            };
            games.Add(game);
            packetHandler.SendPacket(response, response.p1secret);
        }
        public static void onGameJoin(Server.Packets.GameJoin p, Message e)
        {
            string joincode = p.joinCode;
            if(!games.Exists(x => x.joinCode == joincode))
            {
                GameJoinResponse invalidJCRESP = new GameJoinResponse()
                {
                    isJoinCodeValid = false
                };
                packetHandler.SendPacket(invalidJCRESP, e);
            }
            else
            {
                if(games.Find(x => x.joinCode == joincode).player2 != null)
                {
                    GameJoinResponse roomFullResp = new GameJoinResponse()
                    {
                        isJoinCodeValid = true,
                        isRoomFull = true
                    };
                    packetHandler.SendPacket(roomFullResp, e);
                }
                else
                {
                    games.Where(x => x.joinCode == joincode).FirstOrDefault().player2 = new Player()
                    {
                        Secret = Utils.createPlayerSecret(),
                        TCPMessage = e,
                        username = p.username,
                        wins = 0
                    };

                    SS_Game game = games.Where(x => x.joinCode == joincode).FirstOrDefault();
                    GameJoinResponse response = new GameJoinResponse()
                    {
                        isJoinCodeValid = true,
                        isRoomFull = false,
                        p1username = game.player1.username,
                        p2secret = game.player2.Secret
                    };

                    StartGameNotifier notifier = new StartGameNotifier()
                    {
                        p1username = game.player1.username,
                        p2username = game.player2.username
                    };
                    packetHandler.SendPacket(notifier, game);
                    packetHandler.SendPacket(response, response.p2secret);
                }
            }
        }
        public static void onMakeMove(Server.Packets.MakeMove p)
        {
            if (!games.Exists(x => x.player1.Secret == p.secret || x.player2.Secret == p.secret)) return;
            SS_Game game = games.Where(x => x.player1.Secret == p.secret || x.player2.Secret == p.secret).FirstOrDefault();
            if (p.secret == game.player1.Secret) game.currentTour.p1_RPS = (RPSN)(int)p.rps;
                                            else game.currentTour.p2_RPS = (RPSN)(int)p.rps;

            if(game.currentTour.p2_RPS != RPSN.None && game.currentTour.p1_RPS != RPSN.None)
            {
                int tourwinner = Utils.calculateWinner(game.currentTour.p1_RPS, game.currentTour.p2_RPS);

                if (tourwinner == 1) game.player1.wins++;
                else if (tourwinner == 2) game.player2.wins++;
                else if (tourwinner != 0) throw new Exception("Unknown tour winner");
            }
            EndTourNotifier notifier = new EndTourNotifier()
            {
                p1RPS = (RPS)(int)game.currentTour.p1_RPS,
                p2RPS = (RPS)(int)game.currentTour.p2_RPS,
                p1Points = game.player1.wins,
                p2Points = game.player2.wins
            };
            packetHandler.SendPacket(notifier, game);

        }
        public static void onEndGame(Server.Packets.EndGame p)
        {

        }
    }
}
