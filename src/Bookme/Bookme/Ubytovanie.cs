using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopApp1
{
    public class Ubytovanie
    {
        public int id { get; private set; }
        public string nazov { get; private set; }
        public int pocet_hviezdiciek { get; private set; }
        public float hodnotenie { get; private set; }
        public string adresa { get; set; }
        public string popis { get; private set; }
        public string[] obr_urls { get; private set; }
        public string main_url { get; set; }
        public int id_destinacia { get; private set; }
        public int id_typ_ubytovania { get; private set; }
        public float cena { get; private set; }
        private List<Izba> polozky_izieb;
               
        public Ubytovanie(int id, string nazov, int pocet_hviezdiciek, float hodnotenie, string adresa, string popis, string[] obr_urls, int id_destinacia, int id_typ_ubytovania)
        {
            this.id = id;
            this.nazov = nazov;
            this.pocet_hviezdiciek = pocet_hviezdiciek;
            this.hodnotenie = hodnotenie;
            this.adresa = adresa;
            this.popis = popis;
            this.obr_urls = obr_urls;
            this.main_url = obr_urls[0];
            this.id_destinacia = id_destinacia;
            this.id_typ_ubytovania = id_typ_ubytovania;
        }

       /* private List<Izba> NaplnIzby()
        {


        }*/

        public void vypis_urls()
        {
            //MessageBox.Show("Pocet url:" + obr_urls.Length.ToString());
            foreach (string str in this.obr_urls)
                MessageBox.Show(str);
        }
    }
}
