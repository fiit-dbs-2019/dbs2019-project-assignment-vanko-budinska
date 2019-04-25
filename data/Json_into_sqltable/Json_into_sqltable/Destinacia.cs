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
    class Destinacia
    {

        public void wr_to_db(string JsonFile, string[] words)
        {
            string str_name;
            string str_country;
            StreamReader r = new StreamReader(JsonFile);
            PostGreSQL db_conn;
            List<string> reply = new List<string>();
            string jsonString = r.ReadToEnd();
            JArray a = JArray.Parse(jsonString);
            foreach (JObject o in a.Children<JObject>())
            {
                db_conn = new PostGreSQL(words[0], words[1], words[2], words[3], words[4], words[5]);
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = (string)p.Value;

                    if (name == "country")
                    {
                        string q = String.Format("SELECT id FROM public.stat WHERE code = '{0}';", value);
                        //Console.Write(q);
                        reply = db_conn.Query(q);
                        
                    }

                    if (name == "name")
                    {                        
                        str_name = value;
                        if (reply.Any())
                        {
                            string q = String.Format("INSERT INTO public.destinacia(nazov, id_stat) VALUES ('{0}', '{1}');", str_name, reply[0]);
                            db_conn.Query(q);
                            Console.WriteLine(q);
                        }
                        //List<string> col_names = db_conn.Query("SELECT column_name FROM information_schema.columns WHERE table_name = 'stat'");
                        
                        //
                    }
                }
            }
           
        }
    }
}
