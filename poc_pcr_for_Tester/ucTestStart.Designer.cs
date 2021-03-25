namespace poc_pcr_for_Tester
{
    partial class ucTestStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTestStart));
            this.btnTestStart = new System.Windows.Forms.Button();
            this.btn_Check_Start = new System.Windows.Forms.Button();
            this.btn_Send_Protocol = new System.Windows.Forms.Button();
            this.picBox_Back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTestStart
            // 
            this.btnTestStart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTestStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestStart.Location = new System.Drawing.Point(340, 300);
            this.btnTestStart.Name = "btnTestStart";
            this.btnTestStart.Size = new System.Drawing.Size(400, 200);
            this.btnTestStart.TabIndex = 25;
            this.btnTestStart.Text = "Test Start";
            this.btnTestStart.UseVisualStyleBackColor = false;
            this.btnTestStart.Click += new System.EventHandler(this.btnTestStart_Click);
            // 
            // btn_Check_Start
            // 
            this.btn_Check_Start.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Check_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Check_Start.Location = new System.Drawing.Point(599, 561);
            this.btn_Check_Start.Name = "btn_Check_Start";
            this.btn_Check_Start.Size = new System.Drawing.Size(400, 200);
            this.btn_Check_Start.TabIndex = 26;
            this.btn_Check_Start.Text = "2. Check Data";
            this.btn_Check_Start.UseVisualStyleBackColor = false;
            this.btn_Check_Start.Visible = false;
            this.btn_Check_Start.Click += new System.EventHandler(this.btn_Check_Start_Click);
            // 
            // btn_Send_Protocol
            // 
            this.btn_Send_Protocol.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Send_Protocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Send_Protocol.Location = new System.Drawing.Point(3, 32);
            this.btn_Send_Protocol.Name = "btn_Send_Protocol";
            this.btn_Send_Protocol.Size = new System.Drawing.Size(400, 200);
            this.btn_Send_Protocol.TabIndex = 27;
            this.btn_Send_Protocol.Text = "1. Send Protocol Data";
            this.btn_Send_Protocol.UseVisualStyleBackColor = false;
            this.btn_Send_Protocol.Visible = false;
            this.btn_Send_Protocol.Click += new System.EventHandler(this.btn_Send_Protocol_Click);
            // 
            // picBox_Back
            // 
            this.picBox_Back.Image = ((System.Drawing.Image)(resources.GetObject("picBox_Back.Image")));
            this.picBox_Back.Location = new System.Drawing.Point(20, 720);
            this.picBox_Back.Name = "picBox_Back";
            this.picBox_Back.Size = new System.Drawing.Size(72, 70);
            this.picBox_Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Back.TabIndex = 35;
            this.picBox_Back.TabStop = false;
            // 
            // ucTestStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.picBox_Back);
            this.Controls.Add(this.btn_Send_Protocol);
            this.Controls.Add(this.btn_Check_Start);
            this.Controls.Add(this.btnTestStart);
            this.Name = "ucTestStart";
            this.Size = new System.Drawing.Size(1080, 800);
            this.Load += new System.EventHandler(this.ucTestStart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestStart;
        private System.Windows.Forms.Button btn_Check_Start;
        private System.Windows.Forms.Button btn_Send_Protocol;
        private System.Windows.Forms.PictureBox picBox_Back;
    }
}
