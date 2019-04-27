using Npgsql;
using PgSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp1
{
    public partial class form_ZmenaRezervacie : Form
    {
        RezervaciaPolozka polozka;
        PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");

        public form_ZmenaRezervacie(RezervaciaPolozka polozka)
        {
            this.polozka = polozka;
            InitializeComponent();
            lbl_cisloRezervacie.Text = polozka.CisloRezervacie.ToString();
            lbl_pocetIzieb.Text = polozka.PocetIzieb.ToString();
            lbl_od.Text = polozka.Od.Date.ToString();
            lbl_do.Text = polozka.Do.Date.ToString();
            lbl_nazovUbytovania.Text = polozka.NazovUbytovania;
            lbl_adresa.Text = polozka.Adresa;
            lbl_stav.Text = polozka.Stav;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Spat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Platba_Click(object sender, EventArgs e)
        {
            string q = "BEGIN;" + 
                        "UPDATE public.rezervacia " + 
                        "SET id_stav = sq.id " +
                        "FROM(SELECT s.id " +
                              "FROM public.stav_rezervacie s " +
                              "WHERE s.stav = 'zaplatena') " +
                        "AS sq " +
                            "WHERE public.rezervacia.id = :r_id; " +
                        "END TRANSACTION;";

            NpgsqlConnection connection = db_conn.conn;
            NpgsqlCommand cmd = new NpgsqlCommand(q, connection);
            cmd.Parameters.AddWithValue("r_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = polozka.CisloRezervacie;
            db_conn.command = cmd;
            db_conn.Query();
            polozka.Stav = "zaplatena";
            lbl_stav.Text = polozka.Stav;
            polozka.Aktualizuj(polozka.Stav);
        }
    }
}
