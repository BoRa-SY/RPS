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

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            GameCreateResponse info = PacketHandler.CreateGame(textBoxUsername.Text, (int)numericUpDownTargetWin.Value);
            buttonCreate.Enabled = false;
            Statics.Secret = info.p1secret;
            labelJoinCode.Text = info.joinCode;
            PacketHandler.onStartGameNotifier = onStartGameNotifier; 
        }

        void onStartGameNotifier(StartGameNotifier p)
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                Statics.username = p.p1username;
                Statics.opponent_username = p.p2username;
                FormGame gameform = new FormGame();
                Statics.formcreate.Hide();
                gameform.ShowDialog();
            }));
            thr.Start();

        }
    }
}
