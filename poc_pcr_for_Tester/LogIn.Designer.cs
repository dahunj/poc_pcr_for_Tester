namespace poc_pcr_for_Tester
{
    partial class LogIn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.tb_LoginID = new System.Windows.Forms.TextBox();
            this.tb_LoginPW = new System.Windows.Forms.TextBox();
            this.cb_Port_Main = new System.Windows.Forms.ComboBox();
            this.btn_Connect_Main = new MetroFramework.Controls.MetroButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(340, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 2);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.label3.Location = new System.Drawing.Point(322, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 44);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Location = new System.Drawing.Point(340, 498);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 2);
            this.panel2.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnLogin.Location = new System.Drawing.Point(23, 567);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(300, 150);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Visible = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tb_LoginID
            // 
            this.tb_LoginID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_LoginID.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_LoginID.Location = new System.Drawing.Point(340, 336);
            this.tb_LoginID.Name = "tb_LoginID";
            this.tb_LoginID.Size = new System.Drawing.Size(400, 37);
            this.tb_LoginID.TabIndex = 8;
            this.tb_LoginID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_LoginID_KeyDown);
            // 
            // tb_LoginPW
            // 
            this.tb_LoginPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_LoginPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_LoginPW.Location = new System.Drawing.Point(340, 457);
            this.tb_LoginPW.Name = "tb_LoginPW";
            this.tb_LoginPW.Size = new System.Drawing.Size(400, 37);
            this.tb_LoginPW.TabIndex = 9;
            this.tb_LoginPW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogIn_KeyDown);
            // 
            // cb_Port_Main
            // 
            this.cb_Port_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cb_Port_Main.FormattingEnabled = true;
            this.cb_Port_Main.Location = new System.Drawing.Point(74, 468);
            this.cb_Port_Main.Name = "cb_Port_Main";
            this.cb_Port_Main.Size = new System.Drawing.Size(214, 33);
            this.cb_Port_Main.TabIndex = 10;
            this.cb_Port_Main.Visible = false;
            // 
            // btn_Connect_Main
            // 
            this.btn_Connect_Main.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_Connect_Main.Location = new System.Drawing.Point(56, 436);
            this.btn_Connect_Main.Name = "btn_Connect_Main";
            this.btn_Connect_Main.Size = new System.Drawing.Size(112, 48);
            this.btn_Connect_Main.TabIndex = 11;
            this.btn_Connect_Main.Text = "Connect";
            this.btn_Connect_Main.UseSelectable = true;
            this.btn_Connect_Main.Visible = false;
            this.btn_Connect_Main.Click += new System.EventHandler(this.btn_Connect_Main_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::poc_pcr_for_Tester.Properties.Resources.geneDtech_logo;
            this.pictureBox3.Location = new System.Drawing.Point(390, 120);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(300, 120);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::poc_pcr_for_Tester.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(900, 739);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(157, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.White;
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(377, 564);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(300, 150);
            this.btnSignIn.TabIndex = 13;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 800);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btn_Connect_Main);
            this.Controls.Add(this.cb_Port_Main);
            this.Controls.Add(this.tb_LoginPW);
            this.Controls.Add(this.tb_LoginID);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "LogIn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogIn_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroButton btnLogin;
        private System.Windows.Forms.TextBox tb_LoginID;
        private System.Windows.Forms.TextBox tb_LoginPW;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox cb_Port_Main;
        private MetroFramework.Controls.MetroButton btn_Connect_Main;
        private System.Windows.Forms.Button btnSignIn;
    }
}