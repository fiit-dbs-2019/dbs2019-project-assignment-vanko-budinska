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
            lblHodn.Text = p.Hodnotenie.ToString();
            lblHviez.Text = p.Hviezdicky;
            lblCena.Text = p.Cena.ToString();
            lblNazov.Text = p.HotelNazov;
            lbl_destinacia.Text = p.Destinacia;
            rtbPopis.Text = p.Popis;
            vykresli_obr(p.ObrUrls);
            //ProcessDirectory("..\\..\\img");
        }
        
        //https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=netframework-4.7.2

        public void vykresli_obr(string[] obr_urls)
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
        

        /*public void ProcessDirectory(string targetDirectory)
        {
            string[] subory = Directory.GetFiles(targetDirectory);
            int x = 20, y = 20;
            obrazky = new PictureBox[subory.Length];
            for (int i = 0; i < subory.Length; i++)
            {
                string nazov = subory[i];
                Debug.WriteLine("Processed file '{0}'.", nazov);
                obrazky[i] = new PictureBox();
                obrazky[i].Image = Image.FromFile(nazov);
                obrazky[i].Location = new Point(x, y);
                obrazky[i].SizeMode = PictureBoxSizeMode.StretchImage;
                x += obrazky[i].Width + 10;
                obrazky[i].Click += new EventHandler(obrazky_Click);
                flowLayoutPanel1.Controls.Add(obrazky[i]);
            }
        }*/

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
