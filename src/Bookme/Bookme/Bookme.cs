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
using System.Windows.Forms;
using PgSql;
// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Bookme : Form
    {
        private PostGreSQL db_conn;

        private List<string> data;      //List s odpovedou z DB pre naplnenie ponuky SELECT * FROM public.ubytovanie 
        private List<string[]> data_arr; //List s odpovedou z DB pre url SELECT obr_urls FROM public.ubytovanie
        private string hladat_Querry = "";
        private string hladat_Querry_urls = "";

        private int offset;
        private int limit;

        public HotelPolozka[] polozky_control { get; private set; }
        Uzivatel uzivatel;

        public Bookme()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap("..\\..\\img\\logo-bookme.png");
            db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
            limit = 10;
            offset = 0;
            data = db_conn.Query(String.Format("SELECT * FROM public.ubytovanie LIMIT {0} OFFSET {1};", limit, offset));
            data_arr = db_conn.Query_Array(String.Format("SELECT obr_urls FROM public.ubytovanie LIMIT {0} OFFSET {1};", limit, offset));
            naplPonuku();
            //List<string> result = db_conn.Query("SELECT * FROM public.izby");
            //naplPonuku(result);
        }

        public FlowLayoutPanel flpanel1
        {
            get { return flowLayoutPanel1; }
        }

        public Panel PagingPanel1
        {
            get { return panelPaging; }
        }
                
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

        public void clearflPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
        }

        public void clearPanel(Panel panel)
        {
            panel.Controls.Clear();
        }

        public void addflPanel(FlowLayoutPanel flpanel, Control item)
        {
            flpanel.Controls.Add(item);
        }

        public void addPanel(Panel panel, Control item)
        {
            panel.Controls.Add(item);
        }

        public void naplPonuku()
        {
            List<string> riadok;
            List<string> dst;
            clearflPanel(flowLayoutPanel1);
            polozky_control = new HotelPolozka[data.Count];
            Ubytovanie[] polozky_ubytovania = new Ubytovanie[data.Count];
            Debug.Write(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                /* 
                 * 
                 * Riadok:  [0] - id
                 *          [1] - nazov
                 *          [2] - pocet_hviezdiciek
                 *          [3] - hodnorenie
                 *          [4] - adresa
                 *          [5] - popis
                 *          [6] - obr_urls[]
                 *          [7] - wifi
                 *          [8] - tv
                 *          [9] - parkovisko
                 *          [10] - ranajky
                 *          [11] - bazen
                 *          [12] - id_destinacia
                 *          [13] - id_typ_ubytovania
                 *          [14] - klimatizacia
                 */
                riadok = parse_response(data[i]);
                dst = db_conn.Query(String.Format("SELECT * FROM public.destinacia d INNER JOIN public.stat s ON d.id_stat = s.id WHERE d.id = '{0}';", Int32.Parse(riadok[12])));
                dst = parse_response(dst[0]);

                polozky_ubytovania[i] = new Ubytovanie(Int32.Parse(riadok[0]), riadok[1], Int32.Parse(riadok[2]), float.Parse(riadok[3]), riadok[4], riadok[5], data_arr[i], Boolean.Parse(riadok[7]), Boolean.Parse(riadok[8]), Boolean.Parse(riadok[9]), Boolean.Parse(riadok[10]), Boolean.Parse(riadok[11]), Int32.Parse(riadok[12]), Int32.Parse(riadok[13]), Boolean.Parse(riadok[14]));
                polozky_ubytovania[i].adresa = dst[0] + " " + dst[1] + " " + dst[2] + ", " + dst[4];
                                
                polozky_control[i] = new HotelPolozka(this, polozky_ubytovania[i]);
                
                addflPanel(flowLayoutPanel1, polozky_control[i]);
                
            }
        }
        
        private void btn_filter_Click(object sender, EventArgs e)
        {

        }

        private void reg_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnRegistracia_Click(object sender, EventArgs e)
        {
            Thread th_reg = new Thread(new ThreadStart(Start_Reg));
            th_reg.Start();
            th_reg.Join();
            //this.Hide();
        }

        private void Start_Reg()
        {
            Registracia reg_Control = new Registracia(this);
            Reg_Form reg_form = new Reg_Form(reg_Control);
            reg_form.ShowDialog();
        }

        private void btnPrihlas_Click(object sender, EventArgs e)
        {
            string q = String.Format("SELECT meno, priezvisko, email, heslo FROM public.pouzivatel WHERE email = '{0}'", tb_email.Text);
            string heslo = tb_heslo.Text + "\r\n";
            
            List<string> response = db_conn.Query(q);
            /*
             * pred parse list[0]: meno,priezvisko,email,heslo
             * po parse:
             * response list[0] : meno
             *          list[1] : priezvisko
             *          list[2] : email
             *          list[3] : heslo
             */

            //osetrenie prihlasovania
            if (response.Count == 0)
            {
                print_message("Nespravny e-mail!");
                return;
            }
            response = parse_response(response[0]);
            if (!response[3].Equals(heslo))
            {
                print_message("Zle zadane heslo!" + response[3]);
                return;
            }

            prihlasenie(response[0], response[1], response[2]);
            
        }

        public void prihlasenie(string meno, string priezvisko, string email)
        {
            this.uzivatel = new Uzivatel(meno, priezvisko, email);
            //najst v DB, porovnat heslo, ak sedi tak zmenit hlavicku a ulozit udaje
            Prihlaseny_hlavicka phlav_Control = new Prihlaseny_hlavicka();
            phlav_Control.Load_data(uzivatel);
            clearPanel(flp_prihlaseny);
            addPanel(flp_prihlaseny, phlav_Control);
        }

        private void print_message(string message)
        {
            string caption = "Chyba prihlasenia";
            MessageBoxButtons button = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, button);
        }

        private List<string> parse_response(string response)
        {
            List<string> str = new List<string>();
            string[] parsed = response.Split(';');
            foreach (string s in parsed)
            {
                str.Add(s);
            }
            return str;
        }
        private void btnFiltruj_Click(object sender, EventArgs e)
        {
            string q = "";
            if(chbWifi.Checked)
            {
                if(q.Length == 0 && hladat_Querry.Length == 0)
                    q += " WHERE wifi = 'true' ";
                else
                    q += " AND wifi = 'true' ";
            }
            if (chbTv.Checked)
            {
                if (q.Length == 0 && hladat_Querry.Length == 0)
                    q += " WHERE tv = 'true' ";
                else
                    q += " AND tv = 'true' ";
            }
            if (chbParkovanie.Checked && hladat_Querry.Length == 0)
            {
                if (q.Length == 0)
                    q += " WHERE parkovisko = 'true' ";
                else
                    q += " AND parkovisko = 'true' ";
            }
            if (chbRanajky.Checked && hladat_Querry.Length == 0)
            {
                if (q.Length == 0)
                    q += " WHERE ranajky = 'true' ";
                else
                    q += " AND ranajky = 'true' ";
            }
            if (chbBazen.Checked && hladat_Querry.Length == 0)
            {
                if (q.Length == 0)
                    q += " WHERE bazen = 'true' ";
                else
                    q += " AND bazen = 'true' ";
            }
            if (chbKlimatizacia.Checked && hladat_Querry.Length == 0)
            {
                if (q.Length == 0)
                    q += " WHERE klimatizacia = 'true' ";
                else
                    q += " AND klimatizacia = 'true' ";
            }
            if (hladat_Querry.Length == 0)
            {
                data = db_conn.Query(String.Format("SELECT * FROM public.ubytovanie " + q + " LIMIT {0} OFFSET {1};", limit, offset));
                data_arr = db_conn.Query_Array(String.Format("SELECT obr_urls FROM public.ubytovanie " + q + "LIMIT {0} OFFSET {1};", limit, offset));
            }
            else
            {
                data = db_conn.Query(String.Format(hladat_Querry + q + " LIMIT {0} OFFSET {1};", limit, offset));
                data_arr = db_conn.Query_Array(String.Format(hladat_Querry_urls + q + "LIMIT {0} OFFSET {1};", limit, offset));
            }
            naplPonuku();
        }

        private void btnHladat_Click(object sender, EventArgs e)
        {
            hladat_Querry = "SELECT u.* FROM public.ubytovanie u " +
                        "INNER JOIN public.destinacia d ON u.id_destinacia = d.id " +
                        "INNER JOIN public.stat s ON d.id_stat = s.id ";
            hladat_Querry += "WHERE (s.nazov LIKE '%" + tbDestinacia.Text + "%' OR d.nazov LIKE '%" + tbDestinacia.Text + "%' OR u.adresa LIKE '%" + tbDestinacia.Text + "%' )";
            //hladat_Querry += String.Format("LIMIT {0} OFFSET {1};", limit, offset);
            db_conn.Query(String.Format(hladat_Querry + "LIMIT {0} OFFSET {1};", limit, offset));

            data = db_conn.Query(String.Format(hladat_Querry + "LIMIT {0} OFFSET {1};", limit, offset));
            hladat_Querry_urls = "SELECT u.obr_urls FROM public.ubytovanie u " +
                        "INNER JOIN public.destinacia d ON u.id_destinacia = d.id " +
                        "INNER JOIN public.stat s ON d.id_stat = s.id ";
            hladat_Querry_urls += "WHERE (s.nazov LIKE '%" + tbDestinacia.Text + "%' OR d.nazov LIKE '%" + tbDestinacia.Text + "%' OR u.adresa LIKE '%" + tbDestinacia.Text + "%' )";
            //hladat_Querry_urls += String.Format("LIMIT {0} OFFSET {1};", limit, offset);
            data_arr = db_conn.Query_Array(String.Format(hladat_Querry_urls + "LIMIT {0} OFFSET {1};", limit, offset));
            naplPonuku();
        }
    }
}
