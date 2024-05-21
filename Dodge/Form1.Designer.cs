namespace Dodge
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player1ScoreOutput = new System.Windows.Forms.Label();
            this.player2ScoreOutput = new System.Windows.Forms.Label();
            this.timerOutput = new System.Windows.Forms.Label();
            this.winnerOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player1ScoreOutput
            // 
            this.player1ScoreOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1ScoreOutput.Location = new System.Drawing.Point(187, 226);
            this.player1ScoreOutput.Name = "player1ScoreOutput";
            this.player1ScoreOutput.Size = new System.Drawing.Size(100, 23);
            this.player1ScoreOutput.TabIndex = 4;
            this.player1ScoreOutput.Text = "label1";
            this.player1ScoreOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2ScoreOutput
            // 
            this.player2ScoreOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2ScoreOutput.Location = new System.Drawing.Point(399, 226);
            this.player2ScoreOutput.Name = "player2ScoreOutput";
            this.player2ScoreOutput.Size = new System.Drawing.Size(100, 23);
            this.player2ScoreOutput.TabIndex = 5;
            this.player2ScoreOutput.Text = "label2";
            this.player2ScoreOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerOutput
            // 
            this.timerOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerOutput.Location = new System.Drawing.Point(279, 9);
            this.timerOutput.Name = "timerOutput";
            this.timerOutput.Size = new System.Drawing.Size(128, 23);
            this.timerOutput.TabIndex = 6;
            this.timerOutput.Text = "label3";
            this.timerOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winnerOutput
            // 
            this.winnerOutput.BackColor = System.Drawing.Color.Transparent;
            this.winnerOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerOutput.Location = new System.Drawing.Point(278, 115);
            this.winnerOutput.Name = "winnerOutput";
            this.winnerOutput.Size = new System.Drawing.Size(128, 23);
            this.winnerOutput.TabIndex = 7;
            this.winnerOutput.Text = "winnerOutput";
            this.winnerOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.winnerOutput.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.winnerOutput);
            this.Controls.Add(this.timerOutput);
            this.Controls.Add(this.player2ScoreOutput);
            this.Controls.Add(this.player1ScoreOutput);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label player1ScoreOutput;
        private System.Windows.Forms.Label player2ScoreOutput;
        private System.Windows.Forms.Label timerOutput;
        private System.Windows.Forms.Label winnerOutput;
    }
}

