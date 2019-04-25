using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp1
{
    public class ZostavaRezervacie
    {
        public int id { get; set; }
        public int pocet { get; private set; }
        public int id_rezervacia { get; private set; }
        public int id_ubytovanie { get; private set; }
        public int id_uzivatel { get; private set; }

        public ZostavaRezervacie(int pocet, int id_rezervacia, int id_ubytovanie, int id_uzivatel)
        {
            this.pocet = pocet;
            this.id_rezervacia = id_rezervacia;
            this.id_ubytovanie = id_ubytovanie;
            this.id_uzivatel = id_uzivatel;
        }

    }
}
