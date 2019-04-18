using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PgSql;

namespace Json_into_sqltable
{
    
    class Staty
    {
        /* metoda na zapis do db
         * table: public.stat
         * columns: id, nazov, code
         * json s udajmi o statoch :
         * 
         [
            {
                "name": "Afghanistan",
                "code": "AF"
            },
            .
            .
            .
            {
                "name": "Zimbabwe",
                "code": "ZW"
            }
         ]
         */
        public void wr_to_db(string JsonFile, string[] words)
        {
            List<string[]> str = new List<string[]>();
            StreamReader r = new StreamReader(JsonFile);
            PostGreSQL db_conn;
            string jsonString = r.ReadToEnd();
            JArray a = JArray.Parse(jsonString);
            foreach (JObject o in a.Children<JObject>())
            {

                string[] s1 = new string[2];
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = (string)p.Value;
                    
                    if (name == "name")
                    {
                        s1[0] = value;
                    }
                    if(name == "code")
                    {
                        s1[1] = value;
                        str.Add(s1);
                    }
                }
            }
            db_conn = new PostGreSQL(words[0], words[1], words[2], words[3], words[4], words[5]); 
            List<string> col_names = db_conn.Query("SELECT column_name FROM information_schema.columns WHERE table_name = 'stat'");
            foreach (var s in str)
            {
                string q = String.Format("INSERT INTO public.stat(nazov, code) VALUES ('{0}', '{1}');", s[0], s[1]);
                db_conn.Query(q);
            }
        }
        
    }

    
    

}
