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
            this.btnSpatMojeRezervacie = new System.Windows.Forms.Button();
            this.flp_Rezeravacie = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnSpatMojeRezervacie
            // 
            this.btnSpatMojeRezervacie.Location = new System.Drawing.Point(780, 721);
            this.btnSpatMojeRezervacie.Name = "btnSpatMojeRezervacie";
            this.btnSpatMojeRezervacie.Size = new System.Drawing.Size(75, 23);
            this.btnSpatMojeRezervacie.TabIndex = 1;
            this.btnSpatMojeRezervacie.Text = "Spat";
            this.btnSpatMojeRezervacie.UseVisualStyleBackColor = true;
            this.btnSpatMojeRezervacie.Click += new System.EventHandler(this.btnSpat_Click);
            // 
            // flp_Rezeravacie
            // 
            this.flp_Rezeravacie.Location = new System.Drawing.Point(3, 3);
            this.flp_Rezeravacie.Name = "flp_Rezeravacie";
            this.flp_Rezeravacie.Size = new System.Drawing.Size(852, 712);
            this.flp_Rezeravacie.TabIndex = 2;
            // 
            // MojeRezervacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.flp_Rezeravacie);
            this.Controls.Add(this.btnSpatMojeRezervacie);
            this.Name = "MojeRezervacie";
            this.Size = new System.Drawing.Size(900, 760);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSpatMojeRezervacie;
        private System.Windows.Forms.FlowLayoutPanel flp_Rezeravacie;
    }
}
