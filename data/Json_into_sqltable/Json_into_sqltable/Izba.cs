using Newtonsoft.Json.Linq;
using PgSql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_into_sqltable
{
    class Izba
    {
        private int rozloha;
        private string typ_lozka;
        private int kapacita;
        
        private int typ_index; //<<FK>> typ izby
        private int id_ubytovanie; //<<FK>> id_ubytovania

        public void wr_to_db(string[] words)
        {
            PostGreSQL db_conn;
            string[] typy_lozka = { "Velka manzelska postel", "Manzelska postel", "Poschodova postel", "Rozkladacia pohovka", "Jednolozkova postel", "Pristelka", "Pohovka" };
            db_conn = new PostGreSQL(words[0], words[1], words[2], words[3], words[4], words[5]);
            Random rand = new Random();
            Izba iz = new Izba();
            int index;
            int limit, limit2;
            //pre prvu polozku id_ubytovania
            string q = "SELECT id FROM public.ubytovanie ORDER BY id ASC LIMIT 1;";
            Console.WriteLine(q);
            List<string> reply = db_conn.Query(q);
            //prve id_ubytovanie
            id_ubytovanie = Int32.Parse(reply[0]);
            Console.WriteLine(String.Format("Prve id: {0}", id_ubytovanie));
            //posledne id_ubytovanie
            q = "SELECT id FROM public.ubytovanie ORDER BY id DESC LIMIT 1;";
            reply = db_conn.Query(q);
            limit = Int32.Parse(reply[0]);
            Console.WriteLine(String.Format("Posledne id: {0}", limit));

            //vytvorenie pre kazde ubytovanie aspon jednu izbu
            string nazov_typu_ubyt = "";
            string[] r;
            for (int i = id_ubytovanie; i < limit; i++)
            {
                //pre nahodne mnozstvo ubytovanie vytvorenie dalsich nahodnych izieb
                q = String.Format("SELECT id_typ_ubytovania FROM public.ubytovanie WHERE id = '{0}';", i);
                r = db_conn.Query(q).ToArray();
                q = String.Format("SELECT nazov FROM public.typ_ubytovania WHERE id = '{0}';", Int32.Parse(r[0]));
                r = db_conn.Query(q).ToArray();
                nazov_typu_ubyt = r[0];
                if (nazov_typu_ubyt.Equals("Izba\r\n"))
                {
                    limit2 = 1;
                }
                else if (nazov_typu_ubyt.Equals("Apartman\r\n"))
                {
                    limit2 = rand.Next(2, 5);
                }
                else if (nazov_typu_ubyt.Equals("Botel\r\n"))
                {
                    limit2 = rand.Next(3, 15);
                }
                else if (nazov_typu_ubyt.Equals("Vila\r\n"))
                {
                    limit2 = rand.Next(3, 7);
                }
                else if (nazov_typu_ubyt.Equals("Dovolenkovy dom\r\n"))
                {
                    limit2 = rand.Next(3, 7);
                }
                else if (nazov_typu_ubyt.Equals("Privat\r\n"))
                {
                    limit2 = rand.Next(1, 4);
                }
                else
                {
                    limit2 = rand.Next(10, 100);
                }
                
                for (int k = 0; k < limit2; k++)
                {
                    index = rand.Next(typy_lozka.Length);
                    iz.typ_lozka = typy_lozka[index];
                    if (index < 4)
                    {
                        iz.kapacita = 2;
                        iz.rozloha = rand.Next(60);
                        iz.rozloha += 10; //minimalna rozloha
                    }
                    else
                    {
                        iz.kapacita = 1;
                        iz.rozloha = rand.Next(15);
                        iz.rozloha += 10; //minimalna rozloha
                    }
                    iz.typ_index = rand.Next(1, 5);

                    q = String.Format("INSERT INTO public.izba(rozloha, typ_lozka, kapacita, id_ubytovanie, id_typ_izby) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", iz.rozloha, iz.typ_lozka, iz.kapacita, i, iz.typ_index);
                    Console.WriteLine(q);
                    db_conn.Query(q);
                }

            }
            /*foreach (var s in str)
            {
                string q = String.Format("INSERT INTO public.stat(nazov, code) VALUES ('{0}', '{1}');", s[0], s[1]);
                db_conn.Query(q);
            }*/
        }

        
    }
}
