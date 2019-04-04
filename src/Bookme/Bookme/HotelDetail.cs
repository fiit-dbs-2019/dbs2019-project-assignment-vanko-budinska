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

namespace DesktopApp1
{
    public partial class HotelDetail : UserControl
    {
        HotelPolozka hotel;
        private PictureBox[] obrazky;

        public HotelDetail(HotelPolozka p)
        {
            InitializeComponent();
            hotel = p;
            NaplnPolozky(p.u);
        }
        
        private void NaplnPolozky(Ubytovanie u)
        {
            string hv = "";
            lblNazov.Text = u.nazov;
            for (int j = 0; j < u.pocet_hviezdiciek; j++)
                hv += "*";
            lblHviez.Text = hv;
            lblHodn.Text = u.hodnotenie.ToString();
            lblCena.Text = u.cena.ToString();
            lblDestinacia.Text = u.adresa;
            rtbPopis.Text = u.popis;
            vykresli_obr(u.obr_urls);
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
            
        }
    }


}
