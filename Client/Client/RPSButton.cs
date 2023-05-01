using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Packets;

namespace Client
{
    public class RPSButton : Panel
    {

        public RPSButton()
        {
            this.BackgroundImageLayout = ImageLayout.Center;
            this.rps = RPSU.Unknown;
        }


        private RPSU rps_;
        private Color defaultColor_;
        private Color hoverColor_;

        [Category("RPS")]
        public RPSU rps
        {
            get
            {
                return rps_;
            }
            set
            {
                rps_ = value;
                switch(value)
                {
                    case RPSU.Rock:
                        this.BackgroundImage = Properties.Resources.rock;
                        break;
                    case RPSU.Paper:
                        this.BackgroundImage = Properties.Resources.paper;
                        break;
                    case RPSU.Scissors:
                        this.BackgroundImage = Properties.Resources.scissors;
                        break;
                    case RPSU.Unknown:
                        this.BackgroundImage = Properties.Resources.qmark;
                        break;
                }
            }
        }

        [Category("RPS")]
        public Color defaultColor
        {
            get
            {
                return defaultColor_;
            }
            set
            {
                defaultColor_ = value;
                this.BackColor = value;
            }
        }

        [Category("RPS")]
        public Color hoverColor
        {
            get
            {
                return hoverColor_;
            }
            set
            {
                hoverColor_ = value;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (!this.Enabled) { base.OnMouseEnter(e); return; }
            this.BackColor = hoverColor_;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!this.Enabled) { base.OnMouseLeave(e); return; }
            this.BackColor = defaultColor_;
            base.OnMouseLeave(e);
        }

        public event EventHandler<RPSU> Select;

        protected override void OnClick(EventArgs e)
        {
            if(Select != null)
            Select(this, rps_);
            base.OnClick(e);
        }

        public enum RPSU
        {
            Rock,
            Paper,
            Scissors,
            Unknown
        }


    }

}
