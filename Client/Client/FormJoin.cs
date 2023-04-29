using Client.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormJoin : Form
    {
        public FormJoin()
        {
            InitializeComponent();
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


        private void textBoxJoinCode_TextChanged(object sender, EventArgs e)
        {
            textBoxJoinCode.Text = string.IsNullOrEmpty(textBoxJoinCode.Text) ? "" : textBoxJoinCode.Text.ToUpper();
            textBoxJoinCode.SelectionStart = textBoxJoinCode.TextLength;
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            string code = textBoxJoinCode.Text;
            GameJoinResponse joininfo = PacketHandler.JoinGame(code, textBoxUsername.Text);
            if (!joininfo.isJoinCodeValid) { MessageBox.Show("Incorrect join code"); return; }
            if (joininfo.isRoomFull) { MessageBox.Show("Room is already full"); return; }
            Statics.Secret = joininfo.p2secret;
            Statics.opponent_username = joininfo.p1username;
            Statics.username = textBoxUsername.Text;
            Statics.currentPlayer = 2;
            FormGame gameform = new FormGame();
            gameform.Show();
            this.Hide();
        }


    }
}
