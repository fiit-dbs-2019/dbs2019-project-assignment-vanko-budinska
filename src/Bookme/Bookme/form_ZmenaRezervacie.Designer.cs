﻿namespace DesktopApp1
{
    partial class form_ZmenaRezervacie
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_cisloRezervacie = new System.Windows.Forms.Label();
            this.lbl_od = new System.Windows.Forms.Label();
            this.lbl_do = new System.Windows.Forms.Label();
            this.lbl_nazovUbytovania = new System.Windows.Forms.Label();
            this.lbl_adresa = new System.Windows.Forms.Label();
            this.lbl_stav = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Platba = new System.Windows.Forms.Button();
            this.btn_Ulozit = new System.Windows.Forms.Button();
            this.dtPick_od = new System.Windows.Forms.DateTimePicker();
            this.dtPick_do = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Spat = new System.Windows.Forms.Button();
            this.nUpDown_PocetIzieb = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_PocetIzieb = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown_PocetIzieb)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label13);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(139, 113);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cislo rezervacie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pocet izieb";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Od";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Do";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nazov ubytovania";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Adresa";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lbl_cisloRezervacie);
            this.flowLayoutPanel2.Controls.Add(this.lbl_od);
            this.flowLayoutPanel2.Controls.Add(this.lbl_do);
            this.flowLayoutPanel2.Controls.Add(this.lbl_nazovUbytovania);
            this.flowLayoutPanel2.Controls.Add(this.lbl_adresa);
            this.flowLayoutPanel2.Controls.Add(this.lbl_PocetIzieb);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(173, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(516, 113);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // lbl_cisloRezervacie
            // 
            this.lbl_cisloRezervacie.AutoSize = true;
            this.lbl_cisloRezervacie.Location = new System.Drawing.Point(3, 0);
            this.lbl_cisloRezervacie.Name = "lbl_cisloRezervacie";
            this.lbl_cisloRezervacie.Size = new System.Drawing.Size(45, 17);
            this.lbl_cisloRezervacie.TabIndex = 0;
            this.lbl_cisloRezervacie.Text = "C. rez";
            // 
            // lbl_od
            // 
            this.lbl_od.AutoSize = true;
            this.lbl_od.Location = new System.Drawing.Point(3, 17);
            this.lbl_od.Name = "lbl_od";
            this.lbl_od.Size = new System.Drawing.Size(27, 17);
            this.lbl_od.TabIndex = 2;
            this.lbl_od.Text = "Od";
            // 
            // lbl_do
            // 
            this.lbl_do.AutoSize = true;
            this.lbl_do.Location = new System.Drawing.Point(3, 34);
            this.lbl_do.Name = "lbl_do";
            this.lbl_do.Size = new System.Drawing.Size(26, 17);
            this.lbl_do.TabIndex = 3;
            this.lbl_do.Text = "Do";
            // 
            // lbl_nazovUbytovania
            // 
            this.lbl_nazovUbytovania.AutoSize = true;
            this.lbl_nazovUbytovania.Location = new System.Drawing.Point(3, 51);
            this.lbl_nazovUbytovania.Name = "lbl_nazovUbytovania";
            this.lbl_nazovUbytovania.Size = new System.Drawing.Size(74, 17);
            this.lbl_nazovUbytovania.TabIndex = 4;
            this.lbl_nazovUbytovania.Text = "Naz. Ubyt.";
            // 
            // lbl_adresa
            // 
            this.lbl_adresa.AutoSize = true;
            this.lbl_adresa.Location = new System.Drawing.Point(3, 68);
            this.lbl_adresa.Name = "lbl_adresa";
            this.lbl_adresa.Size = new System.Drawing.Size(33, 17);
            this.lbl_adresa.TabIndex = 5;
            this.lbl_adresa.Text = "Add";
            // 
            // lbl_stav
            // 
            this.lbl_stav.AutoSize = true;
            this.lbl_stav.Location = new System.Drawing.Point(15, 145);
            this.lbl_stav.Name = "lbl_stav";
            this.lbl_stav.Size = new System.Drawing.Size(36, 17);
            this.lbl_stav.TabIndex = 9;
            this.lbl_stav.Text = "Stav";
            this.lbl_stav.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Stav";
            // 
            // btn_Platba
            // 
            this.btn_Platba.Location = new System.Drawing.Point(6, 143);
            this.btn_Platba.Name = "btn_Platba";
            this.btn_Platba.Size = new System.Drawing.Size(75, 23);
            this.btn_Platba.TabIndex = 10;
            this.btn_Platba.Text = "Zaplatit";
            this.btn_Platba.UseVisualStyleBackColor = true;
            this.btn_Platba.Click += new System.EventHandler(this.btn_Platba_Click);
            // 
            // btn_Ulozit
            // 
            this.btn_Ulozit.Location = new System.Drawing.Point(173, 59);
            this.btn_Ulozit.Name = "btn_Ulozit";
            this.btn_Ulozit.Size = new System.Drawing.Size(108, 23);
            this.btn_Ulozit.TabIndex = 11;
            this.btn_Ulozit.Text = "Ulozit";
            this.btn_Ulozit.UseVisualStyleBackColor = true;
            this.btn_Ulozit.Click += new System.EventHandler(this.btn_Ulozit_Click);
            // 
            // dtPick_od
            // 
            this.dtPick_od.Location = new System.Drawing.Point(35, 3);
            this.dtPick_od.Name = "dtPick_od";
            this.dtPick_od.Size = new System.Drawing.Size(176, 22);
            this.dtPick_od.TabIndex = 12;
            // 
            // dtPick_do
            // 
            this.dtPick_do.Location = new System.Drawing.Point(35, 31);
            this.dtPick_do.Name = "dtPick_do";
            this.dtPick_do.Size = new System.Drawing.Size(176, 22);
            this.dtPick_do.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 22);
            this.textBox1.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cislo karty";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 22);
            this.textBox2.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Platnost";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "CVV";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 116);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(95, 22);
            this.textBox3.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btn_Platba);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(694, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 169);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nUpDown_PocetIzieb);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_Ulozit);
            this.panel2.Controls.Add(this.dtPick_do);
            this.panel2.Controls.Add(this.dtPick_od);
            this.panel2.Location = new System.Drawing.Point(173, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 87);
            this.panel2.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 17);
            this.label12.TabIndex = 15;
            this.label12.Text = "Do";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "Od";
            // 
            // btn_Spat
            // 
            this.btn_Spat.Location = new System.Drawing.Point(819, 192);
            this.btn_Spat.Name = "btn_Spat";
            this.btn_Spat.Size = new System.Drawing.Size(75, 23);
            this.btn_Spat.TabIndex = 22;
            this.btn_Spat.Text = "Spat";
            this.btn_Spat.UseVisualStyleBackColor = true;
            this.btn_Spat.Click += new System.EventHandler(this.btn_Spat_Click);
            // 
            // nUpDown_PocetIzieb
            // 
            this.nUpDown_PocetIzieb.Location = new System.Drawing.Point(220, 23);
            this.nUpDown_PocetIzieb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUpDown_PocetIzieb.Name = "nUpDown_PocetIzieb";
            this.nUpDown_PocetIzieb.Size = new System.Drawing.Size(120, 22);
            this.nUpDown_PocetIzieb.TabIndex = 23;
            this.nUpDown_PocetIzieb.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "Pocet izieb";
            // 
            // lbl_PocetIzieb
            // 
            this.lbl_PocetIzieb.AutoSize = true;
            this.lbl_PocetIzieb.Location = new System.Drawing.Point(3, 85);
            this.lbl_PocetIzieb.Name = "lbl_PocetIzieb";
            this.lbl_PocetIzieb.Size = new System.Drawing.Size(42, 17);
            this.lbl_PocetIzieb.TabIndex = 6;
            this.lbl_PocetIzieb.Text = "PocIz";
            // 
            // form_ZmenaRezervacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 225);
            this.Controls.Add(this.btn_Spat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_stav);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "form_ZmenaRezervacie";
            this.Text = "Zmena rezervacie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown_PocetIzieb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lbl_cisloRezervacie;
        private System.Windows.Forms.Label lbl_od;
        private System.Windows.Forms.Label lbl_do;
        private System.Windows.Forms.Label lbl_nazovUbytovania;
        private System.Windows.Forms.Label lbl_adresa;
        private System.Windows.Forms.Label lbl_stav;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Platba;
        private System.Windows.Forms.Button btn_Ulozit;
        private System.Windows.Forms.DateTimePicker dtPick_od;
        private System.Windows.Forms.DateTimePicker dtPick_do;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Spat;
        private System.Windows.Forms.NumericUpDown nUpDown_PocetIzieb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_PocetIzieb;
    }
}