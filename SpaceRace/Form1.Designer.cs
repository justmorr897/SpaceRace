namespace SpaceRace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.player1scoreLabel = new System.Windows.Forms.Label();
            this.player2scoreLabel = new System.Windows.Forms.Label();
            this.player2Bar = new System.Windows.Forms.ProgressBar();
            this.player1Bar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 15;
            this.gameTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titleLabel.Location = new System.Drawing.Point(82, 115);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(776, 55);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "titleLabel";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.subtitleLabel.Location = new System.Drawing.Point(76, 228);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(782, 37);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "subtitleLabel";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player1scoreLabel
            // 
            this.player1scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.player1scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1scoreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.player1scoreLabel.Location = new System.Drawing.Point(69, 451);
            this.player1scoreLabel.Name = "player1scoreLabel";
            this.player1scoreLabel.Size = new System.Drawing.Size(100, 85);
            this.player1scoreLabel.TabIndex = 2;
            this.player1scoreLabel.Text = "0";
            // 
            // player2scoreLabel
            // 
            this.player2scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.player2scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2scoreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.player2scoreLabel.Location = new System.Drawing.Point(786, 451);
            this.player2scoreLabel.Name = "player2scoreLabel";
            this.player2scoreLabel.Size = new System.Drawing.Size(100, 85);
            this.player2scoreLabel.TabIndex = 3;
            this.player2scoreLabel.Text = "0";
            // 
            // player2Bar
            // 
            this.player2Bar.Location = new System.Drawing.Point(596, 545);
            this.player2Bar.Name = "player2Bar";
            this.player2Bar.Size = new System.Drawing.Size(300, 23);
            this.player2Bar.TabIndex = 8;
            this.player2Bar.Value = 100;
            // 
            // player1Bar
            // 
            this.player1Bar.Location = new System.Drawing.Point(52, 545);
            this.player1Bar.Name = "player1Bar";
            this.player1Bar.Size = new System.Drawing.Size(300, 23);
            this.player1Bar.TabIndex = 7;
            this.player1Bar.Value = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(978, 569);
            this.Controls.Add(this.player2Bar);
            this.Controls.Add(this.player1Bar);
            this.Controls.Add(this.player2scoreLabel);
            this.Controls.Add(this.player1scoreLabel);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Space Race";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label player1scoreLabel;
        private System.Windows.Forms.Label player2scoreLabel;
        private System.Windows.Forms.ProgressBar player2Bar;
        private System.Windows.Forms.ProgressBar player1Bar;
    }
}

