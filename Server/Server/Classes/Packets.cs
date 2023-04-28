using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Packets
{

    #region cli -> sv -> cli
    public class GameCreate
    {
        public readonly int packetType = 1;
        public string username;
        public int maxWin;
    }
    public class GameCreateResponse
    {
        public readonly int packetType = 2;
        public string joinCode;
        public string p1secret;
    }


    public class GameJoin
    {
        public readonly int packetType = 3;
        public string joinCode;
        public string username;
    }
    public class GameJoinResponse
    {
        public readonly int packetType = 4;
        public bool isJoinCodeValid;
        public bool isRoomFull;
        public string p2secret;
        public string p1username;
    }

    public class MakeMove
    {
        public readonly int packetType = 5;
        public RPS rps;
        public string secret;
    }
    public class MakeMoveResponse
    {
        public readonly int packetType = 6;
        public bool success;
        public bool isEndTour;
        public TourInfo endTourinfo;
        public class TourInfo
        {
            public RPS p1RPS;
            public RPS p2RPS;

            public int p1Points;
            public int p2Points;
        }
    }

    #endregion

    #region sv -> cli_x & cli_y

    public class EndTourNotif
    {
        public readonly int packetType = 7;
        public RPS p1RPS;
        public RPS p2RPS;

        public int p1Points;
        public int p2Points;
    }

    #endregion

    #region sv -> cli_x
    public class StartGameNotifier
    {
        public readonly int packetType = 8;
        public string p1username;
        public string p2username;
    }
    #endregion
    #region cli_x || cli_y -> sv -> cli_y & cli_x
    public class EndGame
    {
        public readonly int packetType = 9;
        public string secret;
    }
    public class EndGameNotifier
    {
        public readonly int packetType = 10;
    }
    #endregion
    public enum RPS
    {
        Rock,
        Paper,
        Scissors
    }
}
