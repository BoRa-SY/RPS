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
            this.buttonRock = new System.Windows.Forms.Button();
            this.buttonPaper = new System.Windows.Forms.Button();
            this.buttonScissors = new System.Windows.Forms.Button();
            this.labelOpponentsMove = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelOpponentPoints = new System.Windows.Forms.Label();
            this.labelplayerMove = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRock
            // 
            this.buttonRock.Location = new System.Drawing.Point(68, 204);
            this.buttonRock.Name = "buttonRock";
            this.buttonRock.Size = new System.Drawing.Size(150, 150);
            this.buttonRock.TabIndex = 0;
            this.buttonRock.Tag = "r";
            this.buttonRock.Text = "Rock";
            this.buttonRock.UseVisualStyleBackColor = true;
            this.buttonRock.Click += new System.EventHandler(this.moveSelected);
            // 
            // buttonPaper
            // 
            this.buttonPaper.Location = new System.Drawing.Point(224, 204);
            this.buttonPaper.Name = "buttonPaper";
            this.buttonPaper.Size = new System.Drawing.Size(150, 150);
            this.buttonPaper.TabIndex = 1;
            this.buttonPaper.Tag = "p";
            this.buttonPaper.Text = "Paper";
            this.buttonPaper.UseVisualStyleBackColor = true;
            this.buttonPaper.Click += new System.EventHandler(this.moveSelected);
            // 
            // buttonScissors
            // 
            this.buttonScissors.Location = new System.Drawing.Point(380, 204);
            this.buttonScissors.Name = "buttonScissors";
            this.buttonScissors.Size = new System.Drawing.Size(150, 150);
            this.buttonScissors.TabIndex = 2;
            this.buttonScissors.Tag = "s";
            this.buttonScissors.Text = "Scissors";
            this.buttonScissors.UseVisualStyleBackColor = true;
            this.buttonScissors.Click += new System.EventHandler(this.moveSelected);
            // 
            // labelOpponentsMove
            // 
            this.labelOpponentsMove.AutoSize = true;
            this.labelOpponentsMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelOpponentsMove.Location = new System.Drawing.Point(63, 95);
            this.labelOpponentsMove.Name = "labelOpponentsMove";
            this.labelOpponentsMove.Size = new System.Drawing.Size(222, 25);
            this.labelOpponentsMove.TabIndex = 4;
            this.labelOpponentsMove.Text = "Opponent\'s Move: ?";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPoints.Location = new System.Drawing.Point(64, 9);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(157, 24);
            this.labelPoints.TabIndex = 5;
            this.labelPoints.Text = "username (you)";
            // 
            // labelOpponentPoints
            // 
            this.labelOpponentPoints.AutoSize = true;
            this.labelOpponentPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelOpponentPoints.Location = new System.Drawing.Point(19, 33);
            this.labelOpponentPoints.Name = "labelOpponentPoints";
            this.labelOpponentPoints.Size = new System.Drawing.Size(202, 24);
            this.labelOpponentPoints.TabIndex = 6;
            this.labelOpponentPoints.Text = "Opponent username";
            // 
            // labelplayerMove
            // 
            this.labelplayerMove.AutoSize = true;
            this.labelplayerMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelplayerMove.Location = new System.Drawing.Point(63, 176);
            this.labelplayerMove.Name = "labelplayerMove";
            this.labelplayerMove.Size = new System.Drawing.Size(153, 25);
            this.labelplayerMove.TabIndex = 7;
            this.labelplayerMove.Text = "Your Move: ?";
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelplayerMove);
            this.Controls.Add(this.labelOpponentPoints);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.labelOpponentsMove);
            this.Controls.Add(this.buttonScissors);
            this.Controls.Add(this.buttonPaper);
            this.Controls.Add(this.buttonRock);
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRock;
        private System.Windows.Forms.Button buttonPaper;
        private System.Windows.Forms.Button buttonScissors;
        private System.Windows.Forms.Label labelOpponentsMove;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelOpponentPoints;
        private System.Windows.Forms.Label labelplayerMove;
    }
}