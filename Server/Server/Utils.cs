using Server.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Utils
    {
        public static string createPlayerSecret()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'u', 'v', 'y', 'z', 'q', 'w', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'Y', 'Z', 'Q', 'W', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            int length = 50;

            string[] secrets1 = GameHandler.games.Select(x => x.player1 == null ? null : x.player1.Secret).ToArray();
            string[] secrets2 = GameHandler.games.Select(x => x.player2 == null ? null : x.player2.Secret).ToArray();

            string secret = "";
            do
            {
                secret = "";
                for (int i = 0; i < length; i++)
                {
                    secret += chars[Statics.rnd.Next(0, chars.Length)];
                }

            } while (secrets1.Contains(secret) || secrets2.Contains(secret));
            return secret;
        }

        public static string createJoinCode()
        {
            char[] chars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'Y', 'Z', 'Q', 'W', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            int length = 6;

            string[] joincodes = GameHandler.games.Select(x => x.joinCode).ToArray();

            string code = "";
            do
            {
                code = "";
                for (int i = 0; i < length; i++)
                {
                    code += chars[Statics.rnd.Next(0, chars.Length)];
                }

            } while (joincodes.Contains(code));
            return code;
        }

        public static int calculateWinner(RPSN p1, RPSN p2)
        {
            if (p1 == RPSN.Rock && p2 == RPSN.Scissors) return 1;
            else if (p1 == RPSN.Scissors && p2 == RPSN.Rock) return 2;

            else if (p1 == RPSN.Scissors && p2 == RPSN.Paper) return 1;
            else if (p1 == RPSN.Paper && p2 == RPSN.Scissors) return 2;

            else if (p1 == RPSN.Paper && p2 == RPSN.Rock) return 1;
            else if (p1 == RPSN.Rock && p2 == RPSN.Paper) return 2;

            else return 0;
        }
    }
}
