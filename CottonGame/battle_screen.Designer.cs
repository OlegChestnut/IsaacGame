namespace CottonGame
{
    partial class battle_screen
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer_generator = new System.Windows.Forms.Timer(this.components);
            this.timer_bullet = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer_generator
            // 
            this.timer_generator.Enabled = true;
            this.timer_generator.Interval = 5000;
            this.timer_generator.Tick += new System.EventHandler(this.timer_generator_Tick);
            // 
            // timer_bullet
            // 
            this.timer_bullet.Interval = 500;
            this.timer_bullet.Tick += new System.EventHandler(this.timer_bullet_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CottonGame.Properties.Resources.sp_green_background;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 640);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(468, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "SCORE: 0";
            // 
            // battle_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.BackgroundImage = global::CottonGame.Properties.Resources.sp_green_background;
            this.ClientSize = new System.Drawing.Size(663, 664);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "battle_screen";
            this.Text = "battle_screen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.battle_screen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.battle_screen_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer_generator;
        private System.Windows.Forms.Timer timer_bullet;
        private System.Windows.Forms.Label label1;
    }
}