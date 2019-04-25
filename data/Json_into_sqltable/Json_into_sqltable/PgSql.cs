using System;
using Npgsql;
using System.Collections.Generic;
using System.Diagnostics;

namespace PgSql
{
    public class PostGreSQL
    {
        
        

        private string _server;
        private string _port;
        private string _user_id;
        private string _password;
        private string _db_name;
        private string _schema_name;
        /*
        #region Properties
        public string Server{
            get { return _server; }
            set { _server = value; }
        }

        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public string User_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Db_name
        {
            get { return _db_name; }
            set { _db_name = value; }
        }

        public string Schema_name
        {
            get { return _schema_name; }
            set { _schema_name = value; }
        }

        #endregion Properties
        */
        public PostGreSQL(string server, string port, string user_id, string passwd, string db_name, string sch_name)
        {
            _server = server;
            _port = port;
            _user_id = user_id;
            _password = passwd;
            _db_name = db_name;
            _schema_name = sch_name;
        }


        
        
        public List<string> Query(string q_command)
        {
            List<string> dataItems = new List<string>();
            try
            {
                string connstring = "Server=" + _server + "; Port=" + _port + "; User Id=" + _user_id + "; Password=" + _password + "; Database=" + _db_name + ";";
                //string connstring = "Server=127.0.0.1; Port=5432; User Id=martin; Password=271996; Database=test;";
          
                Console.WriteLine(connstring);
                Console.WriteLine("Connected\n");
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(q_command, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                Debug.Write("Reader: ");
                
                for (int i = 0; dataReader.Read(); i++)
                {
                    string itm = "";
                    for (int j = 0; j < dataReader.FieldCount; j++)
                    {
                        string sub = dataReader[j].ToString();
                        if (sub == "")
                            itm += "NULL";
                        else
                            itm += dataReader[j].ToString();
                        if(j < dataReader.FieldCount - 1)
                            itm += ",";
                    }
                        
                    dataItems.Add(itm + "\r\n");
                    Debug.Write(dataItems[i]);
                }
                connection.Close();
                return dataItems;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                
                throw;
            }
        }

        /*public List<string> PostgreSQLtest2()
        {
            try
            {
                string connstring = "Server=127.0.0.1; Port=5432; User Id=martin; Password=271996; Database=test;";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.test_table WHERE pocet_lozok > 1", connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    dataItems.Add(dataReader[0].ToString() + "," + dataReader[1].ToString() + "\r\n");
                }
                connection.Close();
                return dataItems;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
         }*/

    }
}
