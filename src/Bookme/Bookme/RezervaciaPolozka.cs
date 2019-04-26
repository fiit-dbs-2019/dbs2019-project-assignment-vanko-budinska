using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp1
{
    public partial class RezervaciaPolozka : UserControl
    {
        public int CisloRezervacie { get; private set; }
        public int PocetIzieb { get; private set; }
        public DateTime Od { get; private set; }
        public DateTime Do { get; private set; }
        public string NazovUbytovania { get; private set; }
        public string Adresa { get; private set; }
        public string Stav { get; private set; }

        public RezervaciaPolozka(int CisloRezervacie, int PocetIzieb, DateTime Od, DateTime Do, string NazovUbytovania, string Adresa, string Stav)
        {

            InitializeComponent();
            this.CisloRezervacie = CisloRezervacie;
            this.PocetIzieb = PocetIzieb;
            this.Od = Od;
            this.Do = Do;
            this.NazovUbytovania = NazovUbytovania;
            this.Adresa = Adresa;
            this.Stav = Stav;
            lbl_cisloRezervacie.Text = this.CisloRezervacie.ToString();
            lbl_pocetIzieb.Text = this.PocetIzieb.ToString();
            lbl_od.Text = this.Od.Date.ToString();
            lbl_do.Text = this.Do.Date.ToString();
            lbl_nazovUbytovania.Text = this.NazovUbytovania;
            lbl_adresa.Text = this.Adresa;
            lbl_stav.Text = this.Stav;

        }
    }
}
