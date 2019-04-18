namespace DesktopApp1
{
    partial class MojeRezervacie
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
            this.dataGridRezervacie = new System.Windows.Forms.DataGridView();
            this.btnSpatMojeRezervacie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRezervacie)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRezervacie
            // 
            this.dataGridRezervacie.AllowUserToAddRows = false;
            this.dataGridRezervacie.AllowUserToDeleteRows = false;
            this.dataGridRezervacie.AllowUserToOrderColumns = true;
            this.dataGridRezervacie.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridRezervacie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRezervacie.Location = new System.Drawing.Point(15, 3);
            this.dataGridRezervacie.Name = "dataGridRezervacie";
            this.dataGridRezervacie.ReadOnly = true;
            this.dataGridRezervacie.RowTemplate.Height = 24;
            this.dataGridRezervacie.Size = new System.Drawing.Size(859, 712);
            this.dataGridRezervacie.TabIndex = 0;
            // 
            // btnSpatMojeRezervacie
            // 
            this.btnSpatMojeRezervacie.Location = new System.Drawing.Point(799, 721);
            this.btnSpatMojeRezervacie.Name = "btnSpatMojeRezervacie";
            this.btnSpatMojeRezervacie.Size = new System.Drawing.Size(75, 23);
            this.btnSpatMojeRezervacie.TabIndex = 1;
            this.btnSpatMojeRezervacie.Text = "Spat";
            this.btnSpatMojeRezervacie.UseVisualStyleBackColor = true;
            this.btnSpatMojeRezervacie.Click += new System.EventHandler(this.btnSpat_Click);
            // 
            // MojeRezervacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnSpatMojeRezervacie);
            this.Controls.Add(this.dataGridRezervacie);
            this.Name = "MojeRezervacie";
            this.Size = new System.Drawing.Size(900, 760);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRezervacie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridRezervacie;
        private System.Windows.Forms.Button btnSpatMojeRezervacie;
    }
}
