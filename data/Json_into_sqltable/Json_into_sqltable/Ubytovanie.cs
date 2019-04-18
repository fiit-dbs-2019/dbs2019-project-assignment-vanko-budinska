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
    
    class Ubytovanie
    {
        private string obr_urls;
        private string meno_ubytovania;
        private int pocet_hviezdiciek;
        private string hodnotenie;
        private string adresa;
        private string popis;
        private int id_typ_ubytovania;
        private int id_destinacia;
        private int min_pocet_destinacii;
        private int max_pocet_destinacii;
        private bool wifi;
        private bool tv;
        private bool parkovisko;
        private bool klimatizacia;
        private bool ranajky;
        private bool bazen;
        static Random random = new Random();
        public void wr_to_db(string JsonFile, string[] words, int pocet)
        {
            popis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque scelerisque enim at dui facilisis tincidunt. Vestibulum ut justo ornare, ultrices est ac, lobortis odio. Maecenas leo mi, fermentum a ipsum eget, pretium ornare neque. Nam in urna a orci finibus porta sed vehicula diam. Cras varius lorem sit amet magna cursus, sed pretium nulla aliquam. Curabitur sed tincidunt dui, porta varius magna. Mauris blandit, dolor sed viverra vestibulum, lectus nibh luctus mauris, ut dictum purus tortor id purus. Nunc tincidunt mi ullamcorper, auctor felis at, tincidunt leo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.";
            PostGreSQL db_conn;
            Random rand = new Random();
            int j, skip = 1;
            int i_of_file_urls = 0;

            db_conn = new PostGreSQL(words[0], words[1], words[2], words[3], words[4], words[5]);
            List<string> reply = new List<string>();
            string q;
            //pocet riadkov destinacie -> id_destinacie
            q = "SELECT id FROM public.destinacia ORDER BY id ASC LIMIT 1;";
            reply = db_conn.Query(q);
            min_pocet_destinacii = Int32.Parse(reply[0]);
            q = "SELECT id FROM public.destinacia ORDER BY id ASC LIMIT 1;";
            reply = db_conn.Query(q);
            max_pocet_destinacii = Int32.Parse(reply[0]);
            StreamReader r = new StreamReader(JsonFile);            
            string jsonString = r.ReadToEnd();
            JArray a = JArray.Parse(jsonString);

            foreach (JObject o in a.Children<JObject>())
            {
                db_conn = new PostGreSQL(words[0], words[1], words[2], words[3], words[4], words[5]);
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = (string)p.Value;

                    //pre kazdu adresu vytvorim jedno ubytovanie
                    if (name == "address")
                    {
                        pocet_hviezdiciek = rand.Next(1, 6);
                        double h = GetRandomNumber(1, 10);
                        decimal h2 = Convert.ToDecimal(h);
                        h2 = Math.Round(h2, 2);
                        hodnotenie = h2.ToString();
                        hodnotenie = hodnotenie.Replace(',', '.');
                        adresa = value;
                        id_typ_ubytovania = rand.Next(1, 11);

                        //nacitanie a ulozenie urliek ako stringov
                        //nacitava sa po 8 URL
                        obr_urls = "";
                        meno_ubytovania = "";

                        var lines_urls = File.ReadLines("urls.txt").Skip(i_of_file_urls).Take(8);                        
                        i_of_file_urls += 8;

                        //nacitanie mien a vyskladanie mena ubytovania
                        var lines_names = File.ReadLines("names.csv").Skip(skip).Take(1);
                        foreach(var line in lines_names)
                        {
                            string[] n = line.Split(',');
                            q = String.Format("SELECT nazov FROM public.typ_ubytovania WHERE id = '{0}';", id_typ_ubytovania);
                            reply = db_conn.Query(q);
                            reply[0] = reply[0].Remove(reply[0].Length - 2);
                            meno_ubytovania = reply[0] + " " + n[0];
                            Console.WriteLine(meno_ubytovania);
                        }
                        skip++;

                        //ulozenie urls ako pola pre psql
                        foreach (var line in lines_urls)
                        {
                            obr_urls += "'" + line + "',";
                        }
                        obr_urls = obr_urls.Remove(obr_urls.Length - 1);
                        id_destinacia = rand.Next(min_pocet_destinacii, max_pocet_destinacii);
                        tv = random_bool2();
                        wifi = random_bool1();
                        parkovisko = random_bool1();
                        ranajky = random_bool1();
                        klimatizacia = random_bool1();
                        bazen = random_bool2();
                        q = String.Format("INSERT INTO public.ubytovanie(nazov, pocet_hviezdiciek, hodnotenie, adresa, popis, obr_urls, id_destinacia, id_typ_ubytovania, tv, wifi, parkovisko, ranajky, klimatizacia, bazen) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', ARRAY [ {5} ], '{6}', '{7}', '{8}','{9}','{10}','{11}','{12}','{13}');", meno_ubytovania, pocet_hviezdiciek, hodnotenie, adresa, popis, obr_urls, id_destinacia, id_typ_ubytovania, tv, wifi, parkovisko, ranajky, klimatizacia, bazen);

                        //q = String.Format("INSERT INTO public.ubytovanie(nazov, pocet_hviezdiciek, hodnotenie, adresa, popis) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", meno_ubytovania, pocet_hviezdiciek, "2.25" , adresa, popis);
                        db_conn.Query(q);
                    }
                }
            }
           /* for (int i = 0; i < pocet; i++)
            {
                pocet_hviezdiciek = rand.Next(1, 6);
                double h = GetRandomNumber(1, 10);
                hodnotenie = Convert.ToDecimal(h);
                hodnotenie = Math.Round(hodnotenie, 2);
                adresa = 

                //nacitanie a ulozenie urliek ako stringov
                //nacitava sa po 8 URL
                obr_urls = "";
                var lines = File.ReadLines("urls.txt").Skip(i_of_file_urls).Take(8);
                i_of_file_urls += 8;

                //ulozenie ako pola pre psql
                foreach (var line in lines)
                {
                    obr_urls += "'" + line + "',";
                }
                obr_urls = obr_urls.Remove(obr_urls.Length - 1);

                //Console.WriteLine(iz.typ_lozka + ", kapacita: " + iz.kapacita + ", rozloha: " + iz.rozloha + ", tv: " + iz.tv + ", wifi: " + iz.wifi + ", park.: " + iz.parkovisko);
                string q = String.Format("INSERT INTO public.ubytovanie(obr_urls) VALUES (ARRAY [ {} ]);", obr_urls);
                Console.WriteLine(q);
                db_conn.Query(q);

            }
            /*foreach (var s in str)
            {
                string q = String.Format("INSERT INTO public.stat(nazov, code) VALUES ('{0}', '{1}');", s[0], s[1]);
                db_conn.Query(q);
            }*/
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private bool random_bool1()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob <= 60;
        }
        private bool random_bool2()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob <= 20;
        }

        //copied from:http://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers/1064907#1064907
    }
}
