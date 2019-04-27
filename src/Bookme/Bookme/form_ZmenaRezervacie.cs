using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp1
{
    public partial class form_ZmenaRezervacie : Form
    {
        RezervaciaPolozka polozka;
        public form_ZmenaRezervacie(RezervaciaPolozka polozka)
        {
            this.polozka = polozka;
            InitializeComponent();
            lbl_cisloRezervacie.Text = polozka.CisloRezervacie.ToString();
            lbl_pocetIzieb.Text = polozka.PocetIzieb.ToString();
            lbl_od.Text = polozka.Od.Date.ToString();
            lbl_do.Text = polozka.Do.Date.ToString();
            lbl_nazovUbytovania.Text = polozka.NazovUbytovania;
            lbl_adresa.Text = polozka.Adresa;
            lbl_stav.Text = polozka.Stav;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
