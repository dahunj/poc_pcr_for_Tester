namespace poc_pcr_for_Tester
{
    partial class ucRunning
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRunning));
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.picBox_running_NextPage = new System.Windows.Forms.PictureBox();
            this.picBox_Btn_Back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_running_NextPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Btn_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(374, 291);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.Gray;
            this.circularProgressBar1.OuterMargin = -80;
            this.circularProgressBar1.OuterWidth = 80;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.Lime;
            this.circularProgressBar1.ProgressWidth = 80;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.Size = new System.Drawing.Size(320, 340);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 0;
            this.circularProgressBar1.Text = "25%";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 25;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Status.Location = new System.Drawing.Point(457, 150);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(164, 55);
            this.lbl_Status.TabIndex = 1;
            this.lbl_Status.Text = "Ready";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 671);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picBox_running_NextPage
            // 
            this.picBox_running_NextPage.Image = ((System.Drawing.Image)(resources.GetObject("picBox_running_NextPage.Image")));
            this.picBox_running_NextPage.Location = new System.Drawing.Point(990, 720);
            this.picBox_running_NextPage.Name = "picBox_running_NextPage";
            this.picBox_running_NextPage.Size = new System.Drawing.Size(72, 70);
            this.picBox_running_NextPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_running_NextPage.TabIndex = 38;
            this.picBox_running_NextPage.TabStop = false;
            this.picBox_running_NextPage.Click += new System.EventHandler(this.picBox_running_NextPage_Click);
            // 
            // picBox_Btn_Back
            // 
            this.picBox_Btn_Back.Image = ((System.Drawing.Image)(resources.GetObject("picBox_Btn_Back.Image")));
            this.picBox_Btn_Back.Location = new System.Drawing.Point(20, 720);
            this.picBox_Btn_Back.Name = "picBox_Btn_Back";
            this.picBox_Btn_Back.Size = new System.Drawing.Size(72, 70);
            this.picBox_Btn_Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Btn_Back.TabIndex = 39;
            this.picBox_Btn_Back.TabStop = false;
            // 
            // ucRunning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.picBox_Btn_Back);
            this.Controls.Add(this.picBox_running_NextPage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.circularProgressBar1);
            this.Name = "ucRunning";
            this.Size = new System.Drawing.Size(1080, 800);
            this.Load += new System.EventHandler(this.ucRunning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_running_NextPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Btn_Back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picBox_running_NextPage;
        private System.Windows.Forms.PictureBox picBox_Btn_Back;
    }
}
