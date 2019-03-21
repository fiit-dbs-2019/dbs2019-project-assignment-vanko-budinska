namespace DesktopApp1
{
    partial class HotelDetail
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
            this.lblHodn = new System.Windows.Forms.Label();
            this.lblNazov = new System.Windows.Forms.Label();
            this.lblHviezd = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCena = new System.Windows.Forms.Label();
            this.btnRezervuj = new System.Windows.Forms.Button();
            this.picBoxMainView = new System.Windows.Forms.PictureBox();
            this.rtbPopis = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPoloha = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMainView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHodn
            // 
            this.lblHodn.AutoSize = true;
            this.lblHodn.Location = new System.Drawing.Point(3, 19);
            this.lblHodn.Name = "lblHodn";
            this.lblHodn.Size = new System.Drawing.Size(81, 17);
            this.lblHodn.TabIndex = 0;
            this.lblHodn.Text = "Hodnotenie";
            // 
            // lblNazov
            // 
            this.lblNazov.AutoSize = true;
            this.lblNazov.Location = new System.Drawing.Point(88, 19);
            this.lblNazov.Name = "lblNazov";
            this.lblNazov.Size = new System.Drawing.Size(48, 17);
            this.lblNazov.TabIndex = 1;
            this.lblNazov.Text = "Nazov";
            // 
            // lblHviezd
            // 
            this.lblHviezd.AutoSize = true;
            this.lblHviezd.Location = new System.Drawing.Point(142, 19);
            this.lblHviezd.Name = "lblHviezd";
            this.lblHviezd.Size = new System.Drawing.Size(23, 17);
            this.lblHviezd.TabIndex = 2;
            this.lblHviezd.Text = "***";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPoloha);
            this.panel1.Controls.Add(this.lblHodn);
            this.panel1.Controls.Add(this.lblHviezd);
            this.panel1.Controls.Add(this.lblNazov);
            this.panel1.Location = new System.Drawing.Point(30, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 81);
            this.panel1.TabIndex = 3;
            // 
            // lblCena
            // 
            this.lblCena.AutoSize = true;
            this.lblCena.Location = new System.Drawing.Point(40, 31);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(41, 17);
            this.lblCena.TabIndex = 4;
            this.lblCena.Text = "Cena";
            // 
            // btnRezervuj
            // 
            this.btnRezervuj.Location = new System.Drawing.Point(104, 19);
            this.btnRezervuj.Name = "btnRezervuj";
            this.btnRezervuj.Size = new System.Drawing.Size(99, 41);
            this.btnRezervuj.TabIndex = 5;
            this.btnRezervuj.Text = "rezervovat";
            this.btnRezervuj.UseVisualStyleBackColor = true;
            this.btnRezervuj.Click += new System.EventHandler(this.btnRezervuj_Click);
            // 
            // picBoxMainView
            // 
            this.picBoxMainView.Location = new System.Drawing.Point(30, 109);
            this.picBoxMainView.Name = "picBoxMainView";
            this.picBoxMainView.Size = new System.Drawing.Size(298, 150);
            this.picBoxMainView.TabIndex = 7;
            this.picBoxMainView.TabStop = false;
            // 
            // rtbPopis
            // 
            this.rtbPopis.Location = new System.Drawing.Point(30, 284);
            this.rtbPopis.Name = "rtbPopis";
            this.rtbPopis.Size = new System.Drawing.Size(815, 185);
            this.rtbPopis.TabIndex = 8;
            this.rtbPopis.Text = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(346, 109);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(499, 150);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // lblPoloha
            // 
            this.lblPoloha.AutoSize = true;
            this.lblPoloha.Location = new System.Drawing.Point(3, 55);
            this.lblPoloha.Name = "lblPoloha";
            this.lblPoloha.Size = new System.Drawing.Size(52, 17);
            this.lblPoloha.TabIndex = 10;
            this.lblPoloha.Text = "Poloha";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRezervuj);
            this.panel2.Controls.Add(this.lblCena);
            this.panel2.Location = new System.Drawing.Point(639, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 81);
            this.panel2.TabIndex = 10;
            // 
            // HotelDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.rtbPopis);
            this.Controls.Add(this.picBoxMainView);
            this.Controls.Add(this.panel1);
            this.Name = "HotelDetail";
            this.Size = new System.Drawing.Size(880, 480);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMainView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHodn;
        private System.Windows.Forms.Label lblNazov;
        private System.Windows.Forms.Label lblHviezd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.Button btnRezervuj;
        private System.Windows.Forms.PictureBox picBoxMainView;
        private System.Windows.Forms.RichTextBox rtbPopis;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblPoloha;
        private System.Windows.Forms.Panel panel2;
    }
}
