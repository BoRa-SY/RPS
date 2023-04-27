using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Classes
{
    public class SS_Game
    {
        public string joinCode;
        public int maxWin;
        public Player player1;
        public Player player2;

        public CurrentTour currentTour = new CurrentTour();
    }
    public class Player
    {
        public string Secret;
        public string username;
        public int wins = 0;
        public Message TCPMessage;
    }
    public class CurrentTour
    {
        public RPSN p1_RPS = RPSN.None;
        public RPSN p2_RPS = RPSN.None;
    }


    public enum RPSN
    {
        Rock,
        Paper,
        Scissors,
        None
    }
}
