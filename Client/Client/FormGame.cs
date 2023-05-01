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
        bool debug;
        public FormGame(bool debug = false)
        {
            this.debug = debug;
            InitializeComponent();

        }
        int currentplayer;

        #region dragbar
        Point offset;
        bool down = false;
        private void panelDrag_MouseDown(object sender, MouseEventArgs e)
        {
            offset = e.Location;
            down = true;
        }

        private void panelDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panelDrag_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }
        #endregion
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        private void FormGame_Load(object sender, EventArgs e)
        {
            if (debug) return;
            labelplayerMove.Text = $"{Statics.username} (you)";
            labelOpponentsMove.Text = $"{Statics.opponent_username}";
            updatePointLabels(0, 0);
            currentplayer = Statics.currentPlayer;
            if (currentplayer != 1 && currentplayer != 2) throw new Exception("Incorrect player num");

            PacketHandler.onEndTourNotifier = onEndTour;
        }


        Color selectedColor = Color.FromArgb(88,85,142);
        private void moveSelected(object sender, RPSButton.RPSU rpsu)
        {
            RPS move = (RPS)(int)rpsu;

            MakeMoveResponse resp = PacketHandler.makeMove(move, Statics.Secret);
            if (!resp.success) throw new Exception("Error");
          //  labelplayerMove.Text = "Your Move: " + Enum.GetName(typeof(RPS), move);


            var btn = (RPSButton)sender;
            btn.BackColor = selectedColor;
            
            ToggleRPSButtonsEnabled(false);
            labelWFO.Visible = true;

            if (resp.isEndTour)
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
            labelPoints.Text = $"Points: {point}";
            labelOpPoints.Text = $"Points: {opponentPoint}";
        }

        void onEndTour(EndTourNotif p)
        {
            ToggleRPSButtonsEnabled(false);
            labelWFO.Visible = false;
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
                    rpsButtonOpponent.rps = (RPSButton.RPSU)(int)p.p2RPS;
                   // labelOpponentsMove.Text = "Opponent's move: " + Enum.GetName(typeof(RPS), p.p2RPS);
                   // labelplayerMove.Text = "Your Move: " + Enum.GetName(typeof(RPS), p.p1RPS);
                }
                else 
                {

                    rpsButtonOpponent.rps = (RPSButton.RPSU)(int)p.p1RPS;
                  //  labelOpponentsMove.Text = "Opponent's move: " + Enum.GetName(typeof(RPS), p.p1RPS);
                  //  labelplayerMove.Text = "Your Move: " + Enum.GetName(typeof(RPS), p.p2RPS);
                }
                Thread.Sleep(3000);
              //  labelOpponentsMove.Text = "Opponent's move: ?";
             //   labelplayerMove.Text = "Your Move: ?";


                ToggleRPSButtonsEnabled(true);
                ToggleRPSButtonsColor(rpsButton1.defaultColor);

                rpsButtonOpponent.rps = RPSButton.RPSU.Unknown;
            })).Start();
        }

        void ToggleRPSButtonsEnabled(bool b)
        {
            rpsButton1.Enabled = b;
            rpsButton2.Enabled = b;
            rpsButton3.Enabled = b;
        }

        void ToggleRPSButtonsColor(Color c)
        {
            rpsButton1.BackColor = c;
            rpsButton2.BackColor = c;
            rpsButton3.BackColor = c;
        }
    }
}
