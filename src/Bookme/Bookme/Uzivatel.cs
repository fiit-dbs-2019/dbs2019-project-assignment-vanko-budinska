using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp1
{
    public class Uzivatel
    {
        public string meno { get; private set; }
        public string priezvisko { get; private set; }
        public string mail { get; private set; }

       

        public Uzivatel(string meno, string priezvisko, string mail)
        {
            this.meno = meno;
            this.priezvisko = priezvisko;
            this.mail = mail;
        }


    }
}
