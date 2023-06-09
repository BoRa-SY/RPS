﻿using Client.Packets;
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




        private void buttonJoin_Click(object sender, EventArgs e)
        {
            FormJoin frm = new FormJoin();
            frm.Show();
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
