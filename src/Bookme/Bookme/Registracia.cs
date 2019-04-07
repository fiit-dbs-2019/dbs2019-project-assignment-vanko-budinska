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
        Bookme b;

        public Registracia(Bookme b)
        {
            InitializeComponent();
            this.b = b;
        }

        private void btnRegistracia_Click(object sender, EventArgs e)
        {
            PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
            if (tb_email.TextLength == 0 || tb_heslo.TextLength == 0 || tb_meno.TextLength == 0 || tb_priezvisko.TextLength == 0) 
            {
                print_message("Nespravne udaje");
            }
            else
            {
                List<string> s = db_conn.Query(String.Format("INSERT INTO public.pouzivatel(meno, priezvisko, email, heslo) VALUES('{0}', '{1}', '{2}', '{3}')", tb_meno.Text, tb_priezvisko.Text, tb_email.Text, tb_heslo.Text));
                b.prihlasenie(tb_meno.Text, tb_priezvisko.Text, tb_email.Text);
                this.ParentForm.Close();
            }
        }

        private void print_message(string message)
        {
            string caption = "Chyba prihlasenia";
            MessageBoxButtons button = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, button);
        }
    }
        
}
