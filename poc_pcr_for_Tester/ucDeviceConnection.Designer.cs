namespace poc_pcr_for_Tester
{
    partial class ucDeviceConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDeviceConnection));
            this.label11 = new System.Windows.Forms.Label();
            this.cb_Port_Main = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Connect_Main = new System.Windows.Forms.Button();
            this.btn_GetPorts = new System.Windows.Forms.Button();
            this.picBox_deviceConnectionNext = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBox_NextInfoBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_deviceConnectionNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_NextInfoBack)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(140, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(824, 37);
            this.label11.TabIndex = 30;
            this.label11.Text = "1. Please, Check connection between PC and the device.";
            // 
            // cb_Port_Main
            // 
            this.cb_Port_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Port_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Port_Main.FormattingEnabled = true;
            this.cb_Port_Main.Location = new System.Drawing.Point(254, 594);
            this.cb_Port_Main.Name = "cb_Port_Main";
            this.cb_Port_Main.Size = new System.Drawing.Size(214, 45);
            this.cb_Port_Main.TabIndex = 35;
            this.cb_Port_Main.SelectedIndexChanged += new System.EventHandler(this.cb_Port_Main_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(697, 37);
            this.label1.TabIndex = 36;
            this.label1.Text = "2. Select COM PORT and Click Connect button.";
            // 
            // btn_Connect_Main
            // 
            this.btn_Connect_Main.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Connect_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.btn_Connect_Main.Location = new System.Drawing.Point(531, 591);
            this.btn_Connect_Main.Name = "btn_Connect_Main";
            this.btn_Connect_Main.Size = new System.Drawing.Size(300, 150);
            this.btn_Connect_Main.TabIndex = 37;
            this.btn_Connect_Main.Text = "Connect";
            this.btn_Connect_Main.UseVisualStyleBackColor = false;
            this.btn_Connect_Main.Click += new System.EventHandler(this.btn_Connect_Main_Click);
            // 
            // btn_GetPorts
            // 
            this.btn_GetPorts.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_GetPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GetPorts.Location = new System.Drawing.Point(254, 645);
            this.btn_GetPorts.Name = "btn_GetPorts";
            this.btn_GetPorts.Size = new System.Drawing.Size(214, 96);
            this.btn_GetPorts.TabIndex = 38;
            this.btn_GetPorts.Text = "Get Ports";
            this.btn_GetPorts.UseVisualStyleBackColor = false;
            this.btn_GetPorts.Click += new System.EventHandler(this.btn_GetPorts_Click);
            // 
            // picBox_deviceConnectionNext
            // 
            this.picBox_deviceConnectionNext.Image = ((System.Drawing.Image)(resources.GetObject("picBox_deviceConnectionNext.Image")));
            this.picBox_deviceConnectionNext.Location = new System.Drawing.Point(990, 720);
            this.picBox_deviceConnectionNext.Name = "picBox_deviceConnectionNext";
            this.picBox_deviceConnectionNext.Size = new System.Drawing.Size(72, 70);
            this.picBox_deviceConnectionNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_deviceConnectionNext.TabIndex = 39;
            this.picBox_deviceConnectionNext.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(356, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 340);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // picBox_NextInfoBack
            // 
            this.picBox_NextInfoBack.Image = ((System.Drawing.Image)(resources.GetObject("picBox_NextInfoBack.Image")));
            this.picBox_NextInfoBack.Location = new System.Drawing.Point(20, 720);
            this.picBox_NextInfoBack.Name = "picBox_NextInfoBack";
            this.picBox_NextInfoBack.Size = new System.Drawing.Size(72, 70);
            this.picBox_NextInfoBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_NextInfoBack.TabIndex = 40;
            this.picBox_NextInfoBack.TabStop = false;
            // 
            // ucDeviceConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.picBox_NextInfoBack);
            this.Controls.Add(this.picBox_deviceConnectionNext);
            this.Controls.Add(this.btn_GetPorts);
            this.Controls.Add(this.btn_Connect_Main);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Port_Main);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label11);
            this.Name = "ucDeviceConnection";
            this.Size = new System.Drawing.Size(1080, 800);
            this.Load += new System.EventHandler(this.ucDeviceConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_deviceConnectionNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_NextInfoBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cb_Port_Main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Connect_Main;
        private System.Windows.Forms.Button btn_GetPorts;
        private System.Windows.Forms.PictureBox picBox_deviceConnectionNext;
        private System.Windows.Forms.PictureBox picBox_NextInfoBack;
    }
}
