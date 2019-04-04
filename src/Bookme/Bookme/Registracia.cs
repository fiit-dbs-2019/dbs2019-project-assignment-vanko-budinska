using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PgSql;


namespace DesktopApp1
{
    public partial class Registracia : UserControl
    {
        

        public Registracia()
        {
            InitializeComponent();
        }

        private void btn_registracia_Click(object sender, EventArgs e)
        {
            PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
            List<string> s = db_conn.Query(String.Format("INSERT INTO public.pouzivatel(meno, priezvisko, email, passwd) VALUES('{0}', '{1}', '{2}', '{3}')", tb_meno.Text, tb_priezvisko.Text, tb_email.Text, tb_heslo.Text));
            this.ParentForm.Close();
        }
    }
        
}
