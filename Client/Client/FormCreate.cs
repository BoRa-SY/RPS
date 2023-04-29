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
    public partial class FormCreate : Form
    {
        public FormCreate()
        {
            InitializeComponent();
            Statics.formcreate = this;
        }

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
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            GameCreateResponse info = PacketHandler.CreateGame(textBoxUsername.Text, 0);
            buttonCreate.Enabled = false;
            Statics.Secret = info.p1secret;
            textBoxJoinCode.Text = info.joinCode;
            textBoxUsername.ReadOnly = true;
            PacketHandler.onStartGameNotifier = onStartGameNotifier; 
        }

        void onStartGameNotifier(StartGameNotifier p)
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                PacketHandler.onStartGameNotifier = null;
                Statics.username = p.p1username;
                Statics.opponent_username = p.p2username;
                Statics.currentPlayer = 1;
                FormGame gameform = new FormGame();
                Statics.formcreate.Hide();
                gameform.ShowDialog();
            }));
            thr.Start();

        }

    }
}
