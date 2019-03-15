using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PgSql;
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
        PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
        
        private void btn_filter_Click_1(object sender, EventArgs e)
        {
            /* Po kliknuti na tlacidlo je treba zistit zaznamy ktore vyhovuju vyhladavaniu
             * osetrit stavy ked nevyhovuje nic, ked je zadany zly format atd.
             * Nasledne zobrazit tolko zaznamov, kolko ich vyhovovalo vyhladaniu.
             * 
             * 
             * */
            naplPonuku(int.Parse(tbDestName.Text));
            List<string> result = db_conn.Query("SELECT * FROM public.izby");
            foreach (string res in result) {
                Debug.Write(res);
            }


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
