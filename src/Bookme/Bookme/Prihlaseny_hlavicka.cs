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
    public partial class Prihlaseny_hlavicka : UserControl
    {
        public Uzivatel uzivatel { get; private set; }
        private Bookme b;
        public Prihlaseny_hlavicka(Uzivatel u, Bookme b)
        {    
            InitializeComponent();
            this.uzivatel = u;
            this.b = b;
        }

        public void Load_data()
        {
            lbl_meno.Text = uzivatel.meno;
        }

        private void btnMojeRez_Click(object sender, EventArgs e)
        {
            MojeRezervacie mojeRezervacie = new MojeRezervacie(b, uzivatel);
            b.clearPanel(b.flpanel1);
            b.clearPanel(b.PagingPanel1);
            b.addflPanel(b.flpanel1, mojeRezervacie);
        }
    }
}
