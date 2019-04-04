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
        public Prihlaseny_hlavicka()
        {
            InitializeComponent();
        }

        public void Load_data(Uzivatel u)
        {
            lbl_meno.Text = u.meno;
        }
    }
}
