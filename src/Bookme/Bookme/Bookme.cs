using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            List<string> result = db_conn.Query("SELECT * FROM public.izby");
            naplPonuku(result);
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
            
            //List<string> result = db_conn.Query("SELECT * FROM public.izby");
            //naplPonuku(result);

        }

        public void clearPanel()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        public void addControl(Control item)
        {
            flowLayoutPanel1.Controls.Add(item);
        }

        public void naplPonuku(List<string> data)
        {
            /*
             * Spravit vseobecne nejak na zaklade nazvu stlpca tahanie dat
             * 
             */
            clearPanel();
            HotelPolozka[] polozky = new HotelPolozka[data.Count];
            string[] r_data;
            WebRequest request;
            WebResponse response;
            Stream str;
            Debug.Write(data.Count);
            for (int i = 0; i < data.Count; i++)
            {
                polozky[i] = new HotelPolozka(this);
                r_data = data[i].Split(',');
                request = WebRequest.Create(r_data[10]);
                response = request.GetResponse();
                str = response.GetResponseStream();
                polozky[i].Img = Bitmap.FromStream(str);
                
                polozky[i].HotelNazov = r_data[9];
                for (int j = 0; j < Int32.Parse(r_data[8]); j++)
                    polozky[i].Hviezdicky += "*";
                addControl(polozky[i]);
                
            }
        }
    }
}
