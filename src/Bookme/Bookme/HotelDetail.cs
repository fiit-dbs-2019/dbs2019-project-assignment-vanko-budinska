using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using PgSql;
using Npgsql;

namespace DesktopApp1
{
    public partial class HotelDetail : UserControl
    {
        private HotelPolozka hotelPolozka;
        private Bookme b;
        private Uzivatel uzivatel;
        private Ubytovanie ubytovanie;
        private PictureBox[] obrazky;
        private PostGreSQL db_conn;

        public HotelDetail(HotelPolozka hotelPolozka)
        {
            InitializeComponent();
            this.hotelPolozka = hotelPolozka;
            this.b = hotelPolozka.b;
            this.ubytovanie = hotelPolozka.ubytovanie;
            NaplnPolozky();
        }
        
        private void NaplnPolozky()
        {
            string hv = "";
            lblNazov.Text = ubytovanie.nazov;
            for (int j = 0; j < ubytovanie.pocet_hviezdiciek; j++)
                hv += "*";
            lblHviez.Text = hv;
            lblHodn.Text = ubytovanie.hodnotenie.ToString();
            //lblCena.Text = ubytovanie.cena.ToString();
            lblDestinacia.Text = ubytovanie.adresa;
            rtbPopis.Text = ubytovanie.popis;
            if (ubytovanie.parkovanie)
                lblPark.Show();
            if (ubytovanie.ranajky)
                lblRanajky.Show();       
            if (ubytovanie.bazen)
                lblBazen.Show();
            if (ubytovanie.wifi)
                lblWifi.Show();
            if (ubytovanie.tv)
                lblTv.Show();
            vykresli_obr(ubytovanie.obr_urls);
        }

        private void vykresli_obr(string[] obr_urls)
        {
            int x = 20, y = 20;
            obrazky = new PictureBox[obr_urls.Length];
            WebRequest request;
            WebResponse response;
            Stream str;
            for (int i = 0; i < obr_urls.Length; i++)
            {
                obrazky[i] = new PictureBox();
                request = WebRequest.Create(obr_urls[i]);
                response = request.GetResponse();
                str = response.GetResponseStream();
                obrazky[i].Image = Bitmap.FromStream(str);
                obrazky[i].Location = new Point(x, y);
                obrazky[i].SizeMode = PictureBoxSizeMode.StretchImage;
                x += obrazky[i].Width + 10;
                obrazky[i].Click += new EventHandler(obrazky_Click);
                flowLayoutPanel1.Controls.Add(obrazky[i]);
            }
            picBoxMainView.Image = obrazky[0].Image;
            picBoxMainView.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        private void obrazky_Click(object sender, EventArgs e)
        {
            picBoxMainView.Image = ((PictureBox)sender).Image;
            picBoxMainView.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnRezervuj_Click(object sender, EventArgs e)
        {
            this.uzivatel = b.uzivatel;
            db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
            string q = "INSERT INTO public.rezervacia (od_dat, do_dat) VALUES (:datum_od, :datum_do) RETURNING id;";

            NpgsqlConnection connection = db_conn.conn;
            NpgsqlCommand cmd = new NpgsqlCommand(q, connection);
            cmd.Parameters.AddWithValue("datum_od", NpgsqlTypes.NpgsqlDbType.Date).Value = b.DatumOd;
            cmd.Parameters.AddWithValue("datum_do", NpgsqlTypes.NpgsqlDbType.Date).Value = b.DatumDo;
            db_conn.command = cmd;

            List<string> rep = db_conn.Query();
            Rezervacia r = new Rezervacia(b.DatumOd, b.DatumDo, Int32.Parse(rep[0]));
            //!!!! zmenit pocet, pridat moznost zadania poctu
            if (uzivatel == null)
            {
                string caption = "Chyba rezervacie";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show("Pre vytvorenie rezervacie je potreba sa prihlasit", caption, button);
                return;
            }
            ZostavaRezervacie z = new ZostavaRezervacie(1, r.id, ubytovanie.id, uzivatel.id);

            q = "INSERT INTO public.zostava_rezervacie (pocet, id_rezervacia, id_ubytovanie, id_pouzivatel) VALUES (:pocet, :id_rez, :id_ubyt, :id_pouz) RETURNING id;";
            cmd = new NpgsqlCommand(q, connection);
            cmd.Parameters.AddWithValue("pocet", NpgsqlTypes.NpgsqlDbType.Integer).Value = z.pocet;
            cmd.Parameters.AddWithValue("id_rez", NpgsqlTypes.NpgsqlDbType.Integer).Value = z.id_rezervacia;
            cmd.Parameters.AddWithValue("id_ubyt", NpgsqlTypes.NpgsqlDbType.Integer).Value = z.id_ubytovanie;
            cmd.Parameters.AddWithValue("id_pouz", NpgsqlTypes.NpgsqlDbType.Integer).Value = z.id_uzivatel;
            db_conn.command = cmd;
            rep = db_conn.Query();

            MessageBox.Show("Rezervacia od: " + b.DatumOd.ToString() + " do: " + b.DatumOd.ToString() + " bola vytvorena");
        }

        private void btnSpatHotelDetail_Click(object sender, EventArgs e)
        {
            b.clearPanel(b.flpanel1);
            foreach(var polozka in b.polozky_control)
                b.addflPanel(b.flpanel1, polozka);
        }
    }


}
