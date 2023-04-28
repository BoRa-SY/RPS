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
    public partial class FormFirst : Form
    {
        public FormFirst()
        {
            InitializeComponent();
            PacketHandler.Init();
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            string code = textBoxJoinCode.Text;
            GameJoinResponse joininfo = PacketHandler.JoinGame(code,textBoxUsername.Text);
            if (!joininfo.isJoinCodeValid) { MessageBox.Show("Incorrect join code"); return; }
            if (joininfo.isRoomFull) { MessageBox.Show("Room is already full");return; }
            Statics.Secret = joininfo.p2secret;
            Statics.opponent_username = joininfo.p1username;
            Statics.username = textBoxUsername.Text;
            Statics.currentPlayer = 2;
            FormGame gameform = new FormGame();
            gameform.Show();
            this.Hide();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            FormCreate frm = new FormCreate();
            frm.Show();
            this.Hide();
        }
    }
}
