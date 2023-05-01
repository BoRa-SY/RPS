namespace Client
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.labelOpponentsMove = new System.Windows.Forms.Label();
            this.labelplayerMove = new System.Windows.Forms.Label();
            this.panelDrag = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelOpPoints = new System.Windows.Forms.Label();
            this.rpsButtonOpponent = new Client.RPSButton();
            this.rpsButton3 = new Client.RPSButton();
            this.rpsButton2 = new Client.RPSButton();
            this.rpsButton1 = new Client.RPSButton();
            this.labelWFO = new System.Windows.Forms.Label();
            this.panelDrag.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOpponentsMove
            // 
            this.labelOpponentsMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelOpponentsMove.ForeColor = System.Drawing.Color.White;
            this.labelOpponentsMove.Location = new System.Drawing.Point(33, 358);
            this.labelOpponentsMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOpponentsMove.Name = "labelOpponentsMove";
            this.labelOpponentsMove.Size = new System.Drawing.Size(462, 31);
            this.labelOpponentsMove.TabIndex = 4;
            this.labelOpponentsMove.Text = "Opponent\'s Move:";
            this.labelOpponentsMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelplayerMove
            // 
            this.labelplayerMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelplayerMove.ForeColor = System.Drawing.Color.White;
            this.labelplayerMove.Location = new System.Drawing.Point(33, 68);
            this.labelplayerMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelplayerMove.Name = "labelplayerMove";
            this.labelplayerMove.Size = new System.Drawing.Size(462, 31);
            this.labelplayerMove.TabIndex = 7;
            this.labelplayerMove.Text = "Your Move:";
            this.labelplayerMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDrag
            // 
            this.panelDrag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(81)))), ((int)(((byte)(136)))));
            this.panelDrag.Controls.Add(this.buttonClose);
            this.panelDrag.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDrag.Location = new System.Drawing.Point(0, 0);
            this.panelDrag.Margin = new System.Windows.Forms.Padding(4);
            this.panelDrag.Name = "panelDrag";
            this.panelDrag.Size = new System.Drawing.Size(529, 43);
            this.panelDrag.TabIndex = 8;
            this.panelDrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDrag_MouseDown);
            this.panelDrag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDrag_MouseMove);
            this.panelDrag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelDrag_MouseUp);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(81)))), ((int)(((byte)(136)))));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(472, 2);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(40, 37);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelPoints
            // 
            this.labelPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPoints.ForeColor = System.Drawing.Color.White;
            this.labelPoints.Location = new System.Drawing.Point(139, 259);
            this.labelPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(251, 31);
            this.labelPoints.TabIndex = 13;
            this.labelPoints.Text = "Points: 0";
            this.labelPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOpPoints
            // 
            this.labelOpPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelOpPoints.ForeColor = System.Drawing.Color.White;
            this.labelOpPoints.Location = new System.Drawing.Point(139, 545);
            this.labelOpPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOpPoints.Name = "labelOpPoints";
            this.labelOpPoints.Size = new System.Drawing.Size(251, 31);
            this.labelOpPoints.TabIndex = 14;
            this.labelOpPoints.Text = "Points: 0";
            this.labelOpPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rpsButtonOpponent
            // 
            this.rpsButtonOpponent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(85)))), ((int)(((byte)(142)))));
            this.rpsButtonOpponent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rpsButtonOpponent.BackgroundImage")));
            this.rpsButtonOpponent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rpsButtonOpponent.defaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(85)))), ((int)(((byte)(142)))));
            this.rpsButtonOpponent.Enabled = false;
            this.rpsButtonOpponent.hoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(157)))), ((int)(((byte)(198)))));
            this.rpsButtonOpponent.Location = new System.Drawing.Point(189, 392);
            this.rpsButtonOpponent.Name = "rpsButtonOpponent";
            this.rpsButtonOpponent.rps = Client.RPSButton.RPSU.Unknown;
            this.rpsButtonOpponent.Size = new System.Drawing.Size(150, 150);
            this.rpsButtonOpponent.TabIndex = 12;
            // 
            // rpsButton3
            // 
            this.rpsButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(128)))), ((int)(((byte)(181)))));
            this.rpsButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rpsButton3.BackgroundImage")));
            this.rpsButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rpsButton3.defaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(128)))), ((int)(((byte)(181)))));
            this.rpsButton3.hoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(157)))), ((int)(((byte)(198)))));
            this.rpsButton3.Location = new System.Drawing.Point(345, 106);
            this.rpsButton3.Name = "rpsButton3";
            this.rpsButton3.rps = Client.RPSButton.RPSU.Scissors;
            this.rpsButton3.Size = new System.Drawing.Size(150, 150);
            this.rpsButton3.TabIndex = 12;
            this.rpsButton3.Select += new System.EventHandler<Client.RPSButton.RPSU>(this.moveSelected);
            // 
            // rpsButton2
            // 
            this.rpsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(128)))), ((int)(((byte)(181)))));
            this.rpsButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rpsButton2.BackgroundImage")));
            this.rpsButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rpsButton2.defaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(128)))), ((int)(((byte)(181)))));
            this.rpsButton2.hoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(157)))), ((int)(((byte)(198)))));
            this.rpsButton2.Location = new System.Drawing.Point(189, 106);
            this.rpsButton2.Name = "rpsButton2";
            this.rpsButton2.rps = Client.RPSButton.RPSU.Paper;
            this.rpsButton2.Size = new System.Drawing.Size(150, 150);
            this.rpsButton2.TabIndex = 12;
            this.rpsButton2.Select += new System.EventHandler<Client.RPSButton.RPSU>(this.moveSelected);
            // 
            // rpsButton1
            // 
            this.rpsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(128)))), ((int)(((byte)(181)))));
            this.rpsButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rpsButton1.BackgroundImage")));
            this.rpsButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rpsButton1.defaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(128)))), ((int)(((byte)(181)))));
            this.rpsButton1.hoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(157)))), ((int)(((byte)(198)))));
            this.rpsButton1.Location = new System.Drawing.Point(33, 106);
            this.rpsButton1.Name = "rpsButton1";
            this.rpsButton1.rps = Client.RPSButton.RPSU.Rock;
            this.rpsButton1.Size = new System.Drawing.Size(150, 150);
            this.rpsButton1.TabIndex = 11;
            this.rpsButton1.Select += new System.EventHandler<Client.RPSButton.RPSU>(this.moveSelected);
            // 
            // labelWFO
            // 
            this.labelWFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelWFO.ForeColor = System.Drawing.Color.White;
            this.labelWFO.Location = new System.Drawing.Point(33, 603);
            this.labelWFO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWFO.Name = "labelWFO";
            this.labelWFO.Size = new System.Drawing.Size(462, 31);
            this.labelWFO.TabIndex = 15;
            this.labelWFO.Text = "Waiting For Opponent..";
            this.labelWFO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWFO.Visible = false;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(104)))), ((int)(((byte)(164)))));
            this.ClientSize = new System.Drawing.Size(529, 643);
            this.Controls.Add(this.labelWFO);
            this.Controls.Add(this.labelOpPoints);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.rpsButtonOpponent);
            this.Controls.Add(this.rpsButton3);
            this.Controls.Add(this.rpsButton2);
            this.Controls.Add(this.rpsButton1);
            this.Controls.Add(this.panelDrag);
            this.Controls.Add(this.labelplayerMove);
            this.Controls.Add(this.labelOpponentsMove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGame";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.panelDrag.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelOpponentsMove;
        private System.Windows.Forms.Label labelplayerMove;
        private System.Windows.Forms.Panel panelDrag;
        private System.Windows.Forms.Button buttonClose;
        private RPSButton rpsButton1;
        private RPSButton rpsButton2;
        private RPSButton rpsButton3;
        private RPSButton rpsButtonOpponent;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelOpPoints;
        private System.Windows.Forms.Label labelWFO;
    }
}