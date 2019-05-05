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
using Npgsql;
using PgSql;
// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{

    public partial class Bookme : Form
    {
        private PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");

        private List<string> data;      //List s odpovedou z DB pre naplnenie ponuky SELECT * FROM public.ubytovanie 
        private List<string[]> data_arr; //List s odpovedou z DB pre url SELECT obr_urls FROM public.ubytovanie
        private int offset;
        private int limit;
        private string filter;

        public HotelPolozka[] polozky_control { get; private set; }
        public Uzivatel uzivatel { get; private set; }

        public Bookme()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap("..\\..\\img\\logo-bookme.png");
            limit = 0;
            offset = 10;
            string q = String.Format("SELECT * FROM public.ubytovanie " +
                                      "WHERE id > {0} " +
                                      "ORDER BY id ASC " +
                                      "LIMIT {1};", limit, offset);
            data = db_conn.Query(q);
            q = String.Format("SELECT obr_urls FROM public.ubytovanie " +
                                      "WHERE id > {0} " +
                                      "ORDER BY id ASC " +
                                      "LIMIT {1};", limit, offset);
            data_arr = db_conn.Query_Array(q);
            naplPonuku();
        }

        public FlowLayoutPanel flpanel1
        {
            get { return flpPanel1; }
        }

        public Panel PagingPanel1
        {
            get { return panelPaging; }
        }

        public DateTime DatumOd
        {
            get { return dtpicOd.Value.Date; }
        }

        public DateTime DatumDo
        {
            get { return dtpicDo.Value.Date; }
        }

        private void btn_filter_Click_1(object sender, EventArgs e)
        {
        }

        public void clearPanel(Panel panel)
        {            
            panel.Controls.Clear();
        }

        public void disposePanelItems(Panel panel)
        {
            while (panel.Controls.Count > 0) panel.Controls[0].Dispose();
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
            disposePanelItems(flpPanel1);
            clearPanel(flpPanel1);
            polozky_control = new HotelPolozka[data.Count];
            Ubytovanie[] polozky_ubytovania = new Ubytovanie[data.Count];
            int pocet_rezervacii;
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

                string q = "SELECT id_ubytovanie, COUNT(*) FROM public.zostava_rezervacie " +
                            "GROUP BY id_ubytovanie " +
                            "HAVING id_ubytovanie = :id; ";

                NpgsqlConnection connection = db_conn.conn;
                NpgsqlCommand cmd = new NpgsqlCommand(q, connection);
                cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = polozky_ubytovania[i].id;
                db_conn.command = cmd;
                dst = db_conn.Query();
                if(dst.Count == 0)
                {
                    polozky_ubytovania[i].pocetRezervacii = 0;
                }
                else
                {

                    dst = parse_response(dst[0]);
                    polozky_ubytovania[i].pocetRezervacii = Int32.Parse(dst[1]);
                }
                polozky_control[i] = new HotelPolozka(this, polozky_ubytovania[i]);

                addflPanel(flpPanel1, polozky_control[i]);

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
            Registracia reg_Control = new Registracia();
            Reg_Form reg_form = new Reg_Form(reg_Control);
            //reg_form.ShowDialog();
            Application.Run(reg_form);
        }

        private void btnPrihlas_Click(object sender, EventArgs e)
        {
            string q = String.Format("SELECT meno, priezvisko, email, heslo, id FROM public.pouzivatel WHERE email = '{0}'", tb_email.Text);
            string heslo = tb_heslo.Text;

            List<string> response = db_conn.Query(q);
            /*
             * pred parse list[0]: meno,priezvisko,email,heslo
             * po parse:
             * response list[0] : meno
             *          list[1] : priezvisko
             *          list[2] : email
             *          list[3] : heslo
             *          list[4] : id
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

            prihlasenie(response[0], response[1], response[2], Int32.Parse(response[4]));

        }

        public void prihlasenie(string meno, string priezvisko, string email, int id)
        {
            this.uzivatel = new Uzivatel(meno, priezvisko, email, id);
            //najst v DB, porovnat heslo, ak sedi tak zmenit hlavicku a ulozit udaje
            Prihlaseny_hlavicka phlav_Control = new Prihlaseny_hlavicka(uzivatel, this);
            phlav_Control.Load_data();
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
            limit = 0;
            hladat();
            naplPonuku();
        }

        public void hladat()
        {
            filter = "";
            if (chbWifi.Checked)
                filter += " AND wifi = 'true' ";
            if (chbTv.Checked)
                filter += " AND tv = 'true' ";
            if (chbParkovanie.Checked)
                filter += " AND parkovisko = 'true' ";
            if (chbRanajky.Checked)
                filter += " AND ranajky = 'true' ";
            if (chbBazen.Checked)
                filter += " AND bazen = 'true' ";
            if (chbKlimatizacia.Checked)
                filter += " AND klimatizacia = 'true' ";
            string q = "WITH tb AS ( " +
                        "SELECT u.*, ROW_NUMBER() OVER(ORDER BY u.id ASC) as n " +
                        "FROM public.ubytovanie AS u " +
                        "INNER JOIN public.destinacia d ON u.id_destinacia = d.id " +
                        "INNER JOIN public.stat s ON d.id_stat = s.id " +
                        "WHERE ((s.nazov LIKE '%' || :dst || '%' OR d.nazov LIKE '%' || :dst || '%' OR u.adresa LIKE '%' || :dst || '%') " +
                        filter + ")" +
                        ") SELECT * FROM tb WHERE n > :limit " +
                        "LIMIT :offset;";

            NpgsqlConnection connection = db_conn.conn;
            NpgsqlCommand cmd = new NpgsqlCommand(q, connection);
            cmd.Parameters.AddWithValue("dst", NpgsqlTypes.NpgsqlDbType.Text).Value = tbDestinacia.Text;
            cmd.Parameters.AddWithValue("limit", NpgsqlTypes.NpgsqlDbType.Integer).Value = limit;
            cmd.Parameters.AddWithValue("offset", NpgsqlTypes.NpgsqlDbType.Integer).Value = offset;
            db_conn.command = cmd;
            data = db_conn.Query();
            q =         "WITH tb AS ( " +
                         "SELECT u.id, u.obr_urls, u.wifi, u.ranajky, u.parkovisko, u.bazen, u.klimatizacia, u.tv, ROW_NUMBER() OVER(ORDER BY u.id ASC) as n " +
                         "FROM public.ubytovanie AS u " +
                         "INNER JOIN public.destinacia d ON u.id_destinacia = d.id " +
                         "INNER JOIN public.stat s ON d.id_stat = s.id " +
                         "WHERE ((s.nazov LIKE '%' || :dst || '%' OR d.nazov LIKE '%' || :dst || '%' OR u.adresa LIKE '%' || :dst || '%')" +
                         filter + ")" +
                         ") SELECT * FROM tb WHERE n > :limit " +
                         "LIMIT :offset;";
             cmd = new NpgsqlCommand(q, connection);
             cmd.Parameters.AddWithValue("dst", NpgsqlTypes.NpgsqlDbType.Text).Value = tbDestinacia.Text;
             cmd.Parameters.AddWithValue("limit", NpgsqlTypes.NpgsqlDbType.Integer).Value = limit;
             cmd.Parameters.AddWithValue("offset", NpgsqlTypes.NpgsqlDbType.Integer).Value = offset;
             db_conn.command = cmd;
             data_arr = db_conn.Query_Array();
        }

        private void btnHladat_Click(object sender, EventArgs e)
        {
            limit = 0;
            hladat();
            naplPonuku();
        }

        private void dalej_Click(object sender, EventArgs e)
        {
            limit += 10;
            hladat();
            naplPonuku();
        }

        private void spat_Click(object sender, EventArgs e)
        {
            if (limit >= 10)
            {
                limit -= 10;
            }
            hladat();

            naplPonuku();
        }
    }
}
