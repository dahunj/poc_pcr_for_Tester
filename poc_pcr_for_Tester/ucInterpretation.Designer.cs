namespace poc_pcr_for_Tester
{
    partial class ucInterpretation
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
            this.dgv_interpretation_howTo = new System.Windows.Forms.DataGridView();
            this.btn_save_interpretation = new System.Windows.Forms.Button();
            this.btn_load_interpretation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_interpretation_howTo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_interpretation_howTo
            // 
            this.dgv_interpretation_howTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_interpretation_howTo.Location = new System.Drawing.Point(65, 86);
            this.dgv_interpretation_howTo.Name = "dgv_interpretation_howTo";
            this.dgv_interpretation_howTo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_interpretation_howTo.Size = new System.Drawing.Size(952, 491);
            this.dgv_interpretation_howTo.TabIndex = 0;
            // 
            // btn_save_interpretation
            // 
            this.btn_save_interpretation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_interpretation.Location = new System.Drawing.Point(65, 603);
            this.btn_save_interpretation.Name = "btn_save_interpretation";
            this.btn_save_interpretation.Size = new System.Drawing.Size(209, 57);
            this.btn_save_interpretation.TabIndex = 1;
            this.btn_save_interpretation.Text = "Save Interpretation";
            this.btn_save_interpretation.UseVisualStyleBackColor = true;
            this.btn_save_interpretation.Click += new System.EventHandler(this.btn_save_interpretation_Click);
            // 
            // btn_load_interpretation
            // 
            this.btn_load_interpretation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load_interpretation.Location = new System.Drawing.Point(296, 603);
            this.btn_load_interpretation.Name = "btn_load_interpretation";
            this.btn_load_interpretation.Size = new System.Drawing.Size(209, 57);
            this.btn_load_interpretation.TabIndex = 2;
            this.btn_load_interpretation.Text = "Load Interpretation";
            this.btn_load_interpretation.UseVisualStyleBackColor = true;
            this.btn_load_interpretation.Click += new System.EventHandler(this.btn_load_interpretation_Click);
            // 
            // ucInterpretation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_load_interpretation);
            this.Controls.Add(this.btn_save_interpretation);
            this.Controls.Add(this.dgv_interpretation_howTo);
            this.Name = "ucInterpretation";
            this.Size = new System.Drawing.Size(1080, 800);
            this.Load += new System.EventHandler(this.ucInterpretation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_interpretation_howTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_interpretation_howTo;
        private System.Windows.Forms.Button btn_save_interpretation;
        private System.Windows.Forms.Button btn_load_interpretation;
    }
}
