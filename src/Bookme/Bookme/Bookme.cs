using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Bookme : Form
    {
        public Bookme()
        {
            InitializeComponent();
            naplPonuku(10);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void but_filter_Click(object sender, EventArgs e)
        {
            
        }


        private void btn_filter_Click_1(object sender, EventArgs e)
        {
            /* Po kliknuti na tlacidlo je treba zistit zaznamy ktore vyhovuju vyhladavaniu
             * osetrit stavy ked nevyhovuje nic, ked je zadany zly format atd.
             * Nasledne zobrazit tolko zaznamov, kolko ich vyhovovalo vyhladaniu.
             * 
             * 
             * */
            naplPonuku(int.Parse(tbDestName.Text));
            
        }

        public void naplPonuku(int pocet)
        {
            flowLayoutPanel1.Controls.Clear();
            HotelPolozka[] polozky = new HotelPolozka[pocet];
            for (int i = 0; i < polozky.Length; i++)
            {
                polozky[i] = new HotelPolozka();
                polozky[i].HotelNazov = "Nazov" + i;
                flowLayoutPanel1.Controls.Add(polozky[i]);
            }
        }
    }
}
