using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace DesktopApp1
{
    public partial class HotelPolozka : UserControl
    {
        public Bookme b { get; private set; }
        public Ubytovanie ubytovanie { get; private set; }
        public HotelPolozka(Bookme b, Ubytovanie ubytovanie)
        {
            InitializeComponent();
            this.b = b;
            this.ubytovanie = ubytovanie;
            NaplnPolozky(ubytovanie);
        }

        private void NaplnPolozky(Ubytovanie ubytovanie)
        {
            string hv = "";
            lblNazov.Text = ubytovanie.nazov;
            for (int j = 0; j < ubytovanie.pocet_hviezdiciek; j++)
                hv += "*";
            lblHviez.Text = hv;
            lblHodn.Text = ubytovanie.hodnotenie.ToString();
            //lblCena.Text = ubytovanie.cena.ToString();
            lblDestinacia.Text = ubytovanie.adresa;
            lbl_PocetRezervacii.Text = ubytovanie.pocetRezervacii.ToString();
            rtbPopis.Text = ubytovanie.popis;

            //pictureBox set img
            WebRequest request;
            WebResponse response;
            Stream str;
            request = WebRequest.Create(ubytovanie.main_url);
            response = request.GetResponse();
            str = response.GetResponseStream();
            picBox.Image = Bitmap.FromStream(str);

        }

        public HotelPolozka()
        {

        }
        /*
        #region Properties

        private string _hotelNazov;
        private string _popis;
        private string _hviezdicky;
        private float _hodnotenie;
        private string _destinacia;
        private float _cena;
        private Image _img;
        public string[] ObrUrls { get; set; }
        public int Id { get; set; }

        

        [Category("Custom props")]
        public string HotelNazov
        {
            get { return _hotelNazov; }
            set { _hotelNazov = value; lblNazov.Text = value; }
        }

        [Category("Custom props")]
        public string Destinacia
        {
            get { return _destinacia; }
            set { _destinacia = value; lbl_destinacia.Text = value; }
        }

        [Category("Custom props")]
        public string Popis
        {
            get { return _popis; }
            set { _popis = value; rtbPopis.Text = value.ToString(); }
        }

        [Category("Custom props")]
        public string Hviezdicky
        {
            get { return _hviezdicky; }
            set { _hviezdicky = value; lblHviez.Text = value; }
        }

        [Category("Custom props")]
        public float Hodnotenie
        {
            get { return _hodnotenie; }
            set { _hodnotenie = value; lblHodn.Text = value.ToString(); }
        }

        [Category("Custom props")]
        public float Cena
        {
            get { return _cena; }
            set { _cena = value; lblCena.Text = value.ToString(); }
        }

        [Category("Custom props")]
        public Image Img
        {
            get { return _img; }
            set { _img = value; picBox.Image = value; }
        }
        #endregion
        */
        private void btnVybrat_Click(object sender, EventArgs e)
        {
            b.clearPanel(b.flpanel1);
            b.PagingPanel1.Hide();
            b.addPanel(b.flpanel1, new HotelDetail(this));
        }
    }
}
