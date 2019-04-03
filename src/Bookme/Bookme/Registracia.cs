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
    public partial class Registracia : UserControl
    {
        Form _owner;

        public Registracia()
        {
            InitializeComponent();
        }

        private void btn_registracia_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
        
}
