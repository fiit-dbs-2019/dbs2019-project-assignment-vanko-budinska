using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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

        HotelDetail hdet = new HotelDetail();

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
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

        public void clearPanel()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        public void addControl(Control item)
        {
            flowLayoutPanel1.Controls.Add(item);
        }

        public void naplPonuku(int pocet)
        {
            clearPanel();
            HotelPolozka[] polozky = new HotelPolozka[pocet];
            for (int i = 0; i < polozky.Length; i++)
            {
                polozky[i] = new HotelPolozka(this);
                polozky[i].HotelNazov = "Nazov" + i;
                addControl(polozky[i]);
            }
        }
    }
}
