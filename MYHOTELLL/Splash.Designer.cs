namespace MYHOTELLL
{
    partial class Splash
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Hotel = new System.Windows.Forms.Label();
            this.MyProgress = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.MyProgress);
            this.panel1.Controls.Add(this.Hotel);
            this.panel1.Location = new System.Drawing.Point(7, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 359);
            this.panel1.TabIndex = 0;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // Hotel
            // 
            this.Hotel.AutoSize = true;
            this.Hotel.Font = new System.Drawing.Font("Maiandra GD", 20F);
            this.Hotel.Location = new System.Drawing.Point(142, 1);
            this.Hotel.Name = "Hotel";
            this.Hotel.Size = new System.Drawing.Size(330, 32);
            this.Hotel.TabIndex = 1;
            this.Hotel.Text = "Hotel Managament System";
            // 
            // MyProgress
            // 
            this.MyProgress.Animated = false;
            this.MyProgress.AnimationInterval = 1;
            this.MyProgress.AnimationSpeed = 1;
            this.MyProgress.BackColor = System.Drawing.Color.Transparent;
            this.MyProgress.CircleMargin = 10;
            this.MyProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.MyProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MyProgress.IsPercentage = false;
            this.MyProgress.LineProgressThickness = 10;
            this.MyProgress.LineThickness = 10;
            this.MyProgress.Location = new System.Drawing.Point(224, 98);
            this.MyProgress.Name = "MyProgress";
            this.MyProgress.ProgressAnimationSpeed = 200;
            this.MyProgress.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.MyProgress.ProgressColor = System.Drawing.Color.DodgerBlue;
            this.MyProgress.ProgressColor2 = System.Drawing.Color.DodgerBlue;
            this.MyProgress.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.MyProgress.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Solid;
            this.MyProgress.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.MyProgress.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.MyProgress.Size = new System.Drawing.Size(160, 160);
            this.MyProgress.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.MyProgress.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.MyProgress.SubScriptText = ".00";
            this.MyProgress.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.MyProgress.SuperScriptMargin = new System.Windows.Forms.Padding(5, 20, 0, 0);
            this.MyProgress.SuperScriptText = "°C";
            this.MyProgress.TabIndex = 16;
            this.MyProgress.Text = "30";
            this.MyProgress.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.MyProgress.Value = 30;
            this.MyProgress.ValueByTransition = 30;
            this.MyProgress.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 12F);
            this.label1.Location = new System.Drawing.Point(185, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Depelopped By YAHYA AYKAN";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 375);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label Hotel;
        private Bunifu.UI.WinForms.BunifuCircleProgress MyProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}