namespace DesktopApp1
{
    partial class HotelPolozka
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
            this.lblNazov = new System.Windows.Forms.Label();
            this.btnVybrat = new System.Windows.Forms.Button();
            this.lblHviez = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblHodn = new System.Windows.Forms.Label();
            this.lblCena = new System.Windows.Forms.Label();
            this.rtbPopis = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNazov
            // 
            this.lblNazov.AutoSize = true;
            this.lblNazov.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNazov.Location = new System.Drawing.Point(3, 0);
            this.lblNazov.Name = "lblNazov";
            this.lblNazov.Size = new System.Drawing.Size(72, 29);
            this.lblNazov.TabIndex = 1;
            this.lblNazov.Text = "Hotel";
            // 
            // btnVybrat
            // 
            this.btnVybrat.Location = new System.Drawing.Point(713, 152);
            this.btnVybrat.Name = "btnVybrat";
            this.btnVybrat.Size = new System.Drawing.Size(75, 23);
            this.btnVybrat.TabIndex = 2;
            this.btnVybrat.Text = "Vybrat";
            this.btnVybrat.UseVisualStyleBackColor = true;
            this.btnVybrat.Click += new System.EventHandler(this.btnVybrat_Click);
            // 
            // lblHviez
            // 
            this.lblHviez.AutoSize = true;
            this.lblHviez.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHviez.Location = new System.Drawing.Point(81, 0);
            this.lblHviez.Name = "lblHviez";
            this.lblHviez.Size = new System.Drawing.Size(71, 18);
            this.lblHviez.TabIndex = 3;
            this.lblHviez.Text = "Hviezdiky";
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(25, 25);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(150, 150);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 4;
            this.picBox.TabStop = false;
            // 
            // lblHodn
            // 
            this.lblHodn.AutoSize = true;
            this.lblHodn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHodn.Location = new System.Drawing.Point(713, 63);
            this.lblHodn.Name = "lblHodn";
            this.lblHodn.Size = new System.Drawing.Size(94, 20);
            this.lblHodn.TabIndex = 6;
            this.lblHodn.Text = "Hodnotenie";
            this.lblHodn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCena
            // 
            this.lblCena.AutoSize = true;
            this.lblCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCena.Location = new System.Drawing.Point(713, 108);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(48, 20);
            this.lblCena.TabIndex = 7;
            this.lblCena.Text = "Cena";
            this.lblCena.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbPopis
            // 
            this.rtbPopis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbPopis.Location = new System.Drawing.Point(215, 63);
            this.rtbPopis.Name = "rtbPopis";
            this.rtbPopis.ReadOnly = true;
            this.rtbPopis.Size = new System.Drawing.Size(423, 112);
            this.rtbPopis.TabIndex = 5;
            this.rtbPopis.Text = "Popis";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 192);
            this.panel1.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblNazov);
            this.flowLayoutPanel1.Controls.Add(this.lblHviez);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(215, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(423, 53);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // HotelPolozka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblCena);
            this.Controls.Add(this.lblHodn);
            this.Controls.Add(this.rtbPopis);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnVybrat);
            this.Controls.Add(this.panel1);
            this.Name = "HotelPolozka";
            this.Size = new System.Drawing.Size(840, 200);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNazov;
        private System.Windows.Forms.Button btnVybrat;
        private System.Windows.Forms.Label lblHviez;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblHodn;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.RichTextBox rtbPopis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
