using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp1
{
    class Uzivatel
    {
        private string meno;
        private string priezvisko;
        private string mail;

        Uzivatel(string meno, string priezvisko, string mail)
        {
            this.meno = meno;
            this.priezvisko = priezvisko;
            this.mail = mail;
        }
    }
}
