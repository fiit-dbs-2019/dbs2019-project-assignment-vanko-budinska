using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using PgSql;
// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Bookme : Form
    {
        private PostGreSQL db_conn;
        public Bookme()
        {
            InitializeComponent();
            db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
            //List<string> result = db_conn.Query("SELECT * FROM public.izby");
            //naplPonuku(result);
        }

        HotelDetail hdet = new HotelDetail();
        
        private void btn_filter_Click_1(object sender, EventArgs e)
        {
            /* Po kliknuti na tlacidlo je treba zistit zaznamy ktore vyhovuju vyhladavaniu
             * osetrit stavy ked nevyhovuje nic, ked je zadany zly format atd.
             * Nasledne zobrazit tolko zaznamov, kolko ich vyhovovalo vyhladaniu.
             * 
             * 
             * */

            //List<string> result = db_conn.Query("SELECT * FROM public.izby");
            //naplPonuku(result);
            /*
             * select column_name,data_type 
                from information_schema.columns 
                where table_name = 'table_name';
            */

        }

        public void clearPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
        }

        public void addControl(FlowLayoutPanel panel, Control item)
        {
            panel.Controls.Add(item);
        }

        public void naplPonuku(List<string> data)
        {
            /*
             * Spravit vseobecne nejak na zaklade nazvu stlpca tahanie dat
             * 
             */
            clearPanel(flowLayoutPanel1);
            HotelPolozka[] polozky = new HotelPolozka[data.Count];
            string[] r_data;
            WebRequest request;
            WebResponse response;
            Stream str;
            Debug.Write(data.Count);
            for (int i = 0; i < data.Count; i++)
            {
                polozky[i] = new HotelPolozka(this);
                r_data = data[i].Split(',');
                request = WebRequest.Create(r_data[9]);
                response = request.GetResponse();
                str = response.GetResponseStream();
                polozky[i].Img = Bitmap.FromStream(str);
                
                polozky[i].HotelNazov = r_data[8];
                for (int j = 0; j < Int32.Parse(r_data[7]); j++)
                    polozky[i].Hviezdicky += "*";
                addControl(flowLayoutPanel1, polozky[i]);
                
            }
        }
        
        private void btn_filter_Click(object sender, EventArgs e)
        {

        }

        private void reg_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btn_registracia_Click_1(object sender, EventArgs e)
        {
            Thread th_reg = new Thread(new ThreadStart(Start_Reg));
            th_reg.Start();
            th_reg.Join();
            //this.Hide();
        }

        private void Start_Reg()
        {
            Registracia reg_Control = new Registracia();
            Reg_Form reg_form = new Reg_Form(reg_Control);
            reg_form.ShowDialog();
        }

        private void btn_prihlas_Click(object sender, EventArgs e)
        {
            string q = String.Format("SELECT meno, priezvisko, email, passwd FROM public.pouzivatel WHERE email = '{0}'", tb_email.Text);
            string passwd = tb_heslo.Text + "\r\n";
            
            List<string> response = db_conn.Query(q);
            /*
             * pred parse list[0]: meno,priezvisko,email,passwd
             * po parse:
             * response list[0] : meno
             *          list[1] : priezvisko
             *          list[2] : email
             *          list[3] : passwd
             */

            //osetrenie prihlasovania
            if (response.Count == 0)
            {
                print_message("Nespravny e-mail!");
                return;
            }
            response = parse_response(response[0]);
            if (!response[3].Equals(passwd))
            {
                print_message("Zle zadane heslo!" + response[3]);
                return;
            }

            Uzivatel uzivatel = new Uzivatel(response[0], response[1], response[2]);
            //najst v DB, porovnat heslo, ak sedi tak zmenit hlavicku a ulozit udaje
            Prihlaseny_hlavicka phlav_Control = new Prihlaseny_hlavicka();
            groupBox3.Hide();
            phlav_Control.Load_data(uzivatel);
            clearPanel(flp_prihlaseny);
            addControl(flp_prihlaseny, phlav_Control);
        }

        private void print_message(string message)
        {
            string caption = "Chyba prihlasenia";
            MessageBoxButtons button = MessageBoxButtons.OK;
            DialogResult result;
            result = System.Windows.Forms.MessageBox.Show(message, caption, button);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private List<string> parse_response(string response)
        {
            List<string> str = new List<string>();
            string[] parsed = response.Split(',');
            foreach (var s in parsed)
                str.Add(s);
            return str;
        }
    }
}
