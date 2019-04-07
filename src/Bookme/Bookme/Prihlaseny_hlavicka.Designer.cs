namespace DesktopApp1
{
    partial class Prihlaseny_hlavicka
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_meno = new System.Windows.Forms.Label();
            this.btnMojeRez = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vitaj";
            // 
            // lbl_meno
            // 
            this.lbl_meno.AutoSize = true;
            this.lbl_meno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_meno.Location = new System.Drawing.Point(48, 41);
            this.lbl_meno.Name = "lbl_meno";
            this.lbl_meno.Size = new System.Drawing.Size(0, 24);
            this.lbl_meno.TabIndex = 1;
            // 
            // btnMojeRez
            // 
            this.btnMojeRez.Location = new System.Drawing.Point(414, 33);
            this.btnMojeRez.Name = "btnMojeRez";
            this.btnMojeRez.Size = new System.Drawing.Size(109, 42);
            this.btnMojeRez.TabIndex = 2;
            this.btnMojeRez.Text = "Moje Rezervacie";
            this.btnMojeRez.UseVisualStyleBackColor = true;
            this.btnMojeRez.Click += new System.EventHandler(this.btnMojeRez_Click);
            // 
            // Prihlaseny_hlavicka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMojeRez);
            this.Controls.Add(this.lbl_meno);
            this.Controls.Add(this.label1);
            this.Name = "Prihlaseny_hlavicka";
            this.Size = new System.Drawing.Size(535, 111);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_meno;
        private System.Windows.Forms.Button btnMojeRez;
    }
}
