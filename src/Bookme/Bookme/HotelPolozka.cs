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

namespace DesktopApp1
{
    public partial class HotelPolozka : UserControl
    {
        
        public HotelPolozka()
        {
            InitializeComponent();
        }

        #region Properties

        private string _hotelNazov;
        private string _hviezdicky;
        private float _hodnotenie;
        private float _cena; 
        private Image _img;


        [Category("Custom props")]
        public string HotelNazov
        {
            get { return _hotelNazov; }
            set { _hotelNazov = value; lblNazov.Text = value; }
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

        private void btnVybrat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Polozka" + this.HotelNazov);
        }
    }
}
