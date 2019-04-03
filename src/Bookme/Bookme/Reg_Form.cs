using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp1
{
    public partial class Reg_Form : Form
    {
        public Reg_Form(Registracia control)
        {
            this.Controls.Add(control);            
        }
    }
}
