using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PgSql;

namespace Json_into_sqltable
{
    class Program
    {
        static void Main(string[] args)
        {
            int argv = args.Length;

            //-d destinacie, -s staty, -i izby, 
            if (argv == 1 && args[0] == "-h")
            {
                Console.WriteLine("Usage: prog_name [-d destinations] [-s states] [-u urls] [-r rooms]\r\n[-a accomodations] filename1 filename2 [-h help] [-n number of rooms, accomodations]");
                Console.WriteLine("1. staty, 2. destinacie, 3. URLKY sa tahaju do suboru, 4. ubytovania, 5. izby.");
                Console.WriteLine("filename1 - input file, for accomodations - JSON with addresses");
                Console.WriteLine("filename2 - text file in format: server_address port_num username password db_name schema");
            }
            else if (argv == 2)
            {
                Console.WriteLine("Processing files");
                insert_data(args[0], "", args[1], "");
            }
            else if (argv == 3)
            {
                Console.WriteLine("Processing files");
                insert_data(args[0], args[1], args[2], "");
            }
            else if (argv == 4)
            {
                Console.WriteLine("Processing files");
                insert_data(args[0], args[1], args[2], args[3]);
            }
            else
                Console.WriteLine("Bad args. Use -h for help");
            Console.WriteLine("Press key to exit...");
            Console.ReadKey(); 
        }

        public static void insert_data(string c, String filename_json, String filename2, string number)
        {
            System.IO.StreamReader file2 = new System.IO.StreamReader(filename2);
            string line;
            int n;
       
            
            if ((line = file2.ReadLine()) != null)
            {
                file2.Close();
            }
            else
            {
                Console.WriteLine("Error reading file2");
                System.Environment.Exit(1);
            }
            string[] words = line.Split(' ');
            if (words.Length != 6)
            {
                Console.WriteLine("Error in file2 format.");
                System.Environment.Exit(1);
            }

            if(c.Equals("-d"))
            {
                Destinacia dest = new Destinacia();
                dest.wr_to_db(filename_json, words);
            }
            else if (c.Equals("-u"))
            {
                obr_urls urls = new obr_urls();
                urls.get_urls();
            }
            else if (c.Equals("-r"))
            {
                Izba iz = new Izba();
                iz.wr_to_db(words);
            }
            else if (c.Equals("-s"))
            {
                Staty s = new Staty();
                s.wr_to_db(filename_json, words);
            }
            else if (c.Equals("-a"))
            {
                try
                {
                    n = Int32.Parse(number);
                }
                catch
                {
                    Console.WriteLine("Invalid number");
                    return;
                }
                Ubytovanie u = new Ubytovanie();
                u.wr_to_db(filename_json, words, n);
            }
        }

    }
}
