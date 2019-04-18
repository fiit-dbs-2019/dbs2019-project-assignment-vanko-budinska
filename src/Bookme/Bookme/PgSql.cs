using System;
using System.Windows.Forms;
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
        public NpgsqlConnection conn { get; private set; }
        public NpgsqlCommand command { get; set; }
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
        public PostGreSQL(string server, string port, string user_id, string heslo, string db_name, string sch_name)
        {
            _server = server;
            _port = port;
            _user_id = user_id;
            _password = heslo;
            _db_name = db_name;
            _schema_name = sch_name;
            conn = new NpgsqlConnection("Server=" + _server + "; Port=" + _port + "; User Id=" + _user_id + "; Password=" + _password + "; Database=" + _db_name + ";");
        }

        public List<string> Query()
        {
            List<string> dataItems = new List<string>();
            try
            {
                conn.Open();
                NpgsqlDataReader dataReader = command.ExecuteReader();

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
                        if (j < dataReader.FieldCount - 1)
                            itm += ";";
                    }

                    dataItems.Add(itm + "\r\n");
                }
                conn.Close();
                return dataItems;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        public List<string> Query(string q_command)
        {
            List<string> dataItems = new List<string>();
            try
            {
                string connstring = "Server=" + _server + "; Port=" + _port + "; User Id=" + _user_id + "; Password=" + _password + "; Database=" + _db_name + ";";
                //string connstring = "Server=127.0.0.1; Port=5432; User Id=martin; Password=271996; Database=test;";
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                command = new NpgsqlCommand(q_command, conn);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                
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
                            itm += ";";
                    }
                        
                    dataItems.Add(itm + "\r\n");
                }
                conn.Close();
                return dataItems;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                MessageBox.Show(q_command);
                throw;
            }
        }

        public List<string[]> Query_Array(string q_command)
        {
            List<string[]> dataItems = new List<string[]>();
            try
            {
                string connstring = "Server=" + _server + "; Port=" + _port + "; User Id=" + _user_id + "; Password=" + _password + "; Database=" + _db_name + ";";
                //string connstring = "Server=127.0.0.1; Port=5432; User Id=martin; Password=271996; Database=test;";
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                command = new NpgsqlCommand(q_command, conn);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                for (int i = 0; dataReader.Read(); i++)
                {
                    string[] itm = (string[])dataReader.GetValue(0);
                    dataItems.Add(itm);
                }
                conn.Close();
                return dataItems;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                MessageBox.Show(q_command);
                throw;
            }
        }
    }
}

    
