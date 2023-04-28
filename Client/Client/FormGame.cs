using Client.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
        }
        int currentplayer;
        private void FormGame_Load(object sender, EventArgs e)
        {
            this.Text = $"U: {Statics.username} / OU: {Statics.opponent_username}";
            updatePointLabels(0, 0);
            currentplayer = Statics.currentPlayer;
            if (currentplayer != 1 && currentplayer != 2) throw new Exception("Incorrect player num");

            PacketHandler.onEndTourNotifier = onEndTour;
        }

        private void moveSelected(object sender, EventArgs e)
        {
            string movestr = ((Button)sender).Tag.ToString();
            RPS move = RPS.Rock;
            switch(movestr)
            {
                case "r":
                    move = RPS.Rock;
                    break;
                case "p":
                    move = RPS.Paper;
                    break;
                case "s":
                    move = RPS.Scissors;
                    break;
            }

            MakeMoveResponse resp = PacketHandler.makeMove(move, Statics.Secret);
            if (!resp.success) throw new Exception("Error");
            labelplayerMove.Text = "Your Move: " + Enum.GetName(typeof(RPS), move);
            buttonRock.Enabled = false;
            buttonPaper.Enabled = false;
            buttonScissors.Enabled = false;
            
            if(resp.isEndTour)
            {
                EndTourNotif etn = new EndTourNotif()
                {
                    p1Points = resp.endTourinfo.p1Points,
                    p2Points = resp.endTourinfo.p2Points,
                    p1RPS = resp.endTourinfo.p1RPS,
                    p2RPS = resp.endTourinfo.p2RPS
                };
                onEndTour(etn);
            }
        }
        void updatePointLabels(int point, int opponentPoint)
        {
            labelPoints.Text = $"{Statics.username} (you): {point}";
            labelOpponentPoints.Text = $"{Statics.opponent_username}: {opponentPoint}";
        }

        void onEndTour(EndTourNotif p)
        {
            buttonRock.Enabled = false;
            buttonPaper.Enabled = false;
            buttonScissors.Enabled = false;
            if (currentplayer == 1)
            {
                updatePointLabels(p.p1Points, p.p2Points);
            }
            else if (currentplayer == 2)
            {
                updatePointLabels(p.p2Points, p.p1Points);
            }
            else throw new Exception("Incorrect Player Num");

            new Thread(new ThreadStart(() =>
            {
                if(currentplayer == 1)
                {
                    labelOpponentsMove.Text = "Opponent's move: " + Enum.GetName(typeof(RPS), p.p2RPS);
                    labelplayerMove.Text = "Your Move: " + Enum.GetName(typeof(RPS), p.p1RPS);
                }
                else 
                { 
                    labelOpponentsMove.Text = "Opponent's move: " + Enum.GetName(typeof(RPS), p.p1RPS);
                    labelplayerMove.Text = "Your Move: " + Enum.GetName(typeof(RPS), p.p2RPS);
                }
                Thread.Sleep(3000);
                labelOpponentsMove.Text = "Opponent's move: ?";
                labelplayerMove.Text = "Your Move: ?";

                buttonRock.Enabled = true;
                buttonPaper.Enabled = true;
                buttonScissors.Enabled = true;

            })).Start();
        }
    }
}
