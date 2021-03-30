namespace poc_pcr_for_Tester
{
    partial class ucSelectTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSelectTest));
            this.label1 = new System.Windows.Forms.Label();
            this.cbBox_SelectTest = new System.Windows.Forms.ComboBox();
            this.picBox_SelectTestNext = new System.Windows.Forms.PictureBox();
            this.picBox_btn_back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_SelectTestNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_btn_back)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 55);
            this.label1.TabIndex = 29;
            this.label1.Text = "Select Test";
            // 
            // cbBox_SelectTest
            // 
            this.cbBox_SelectTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.cbBox_SelectTest.FormattingEnabled = true;
            this.cbBox_SelectTest.Items.AddRange(new object[] {
            "TB",
            "COVID"});
            this.cbBox_SelectTest.Location = new System.Drawing.Point(343, 342);
            this.cbBox_SelectTest.Name = "cbBox_SelectTest";
            this.cbBox_SelectTest.Size = new System.Drawing.Size(380, 50);
            this.cbBox_SelectTest.TabIndex = 36;
            this.cbBox_SelectTest.SelectedIndexChanged += new System.EventHandler(this.cbBox_SelectTest_SelectedIndexChanged);
            // 
            // picBox_SelectTestNext
            // 
            this.picBox_SelectTestNext.Image = ((System.Drawing.Image)(resources.GetObject("picBox_SelectTestNext.Image")));
            this.picBox_SelectTestNext.Location = new System.Drawing.Point(990, 720);
            this.picBox_SelectTestNext.Name = "picBox_SelectTestNext";
            this.picBox_SelectTestNext.Size = new System.Drawing.Size(72, 70);
            this.picBox_SelectTestNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_SelectTestNext.TabIndex = 37;
            this.picBox_SelectTestNext.TabStop = false;
            // 
            // picBox_btn_back
            // 
            this.picBox_btn_back.Image = ((System.Drawing.Image)(resources.GetObject("picBox_btn_back.Image")));
            this.picBox_btn_back.Location = new System.Drawing.Point(20, 720);
            this.picBox_btn_back.Name = "picBox_btn_back";
            this.picBox_btn_back.Size = new System.Drawing.Size(72, 70);
            this.picBox_btn_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_btn_back.TabIndex = 38;
            this.picBox_btn_back.TabStop = false;
            // 
            // ucSelectTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.picBox_btn_back);
            this.Controls.Add(this.picBox_SelectTestNext);
            this.Controls.Add(this.cbBox_SelectTest);
            this.Controls.Add(this.label1);
            this.Name = "ucSelectTest";
            this.Size = new System.Drawing.Size(1080, 800);
            this.Load += new System.EventHandler(this.ucSelectTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_SelectTestNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_btn_back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBox_SelectTest;
        private System.Windows.Forms.PictureBox picBox_SelectTestNext;
        private System.Windows.Forms.PictureBox picBox_btn_back;
    }
}
