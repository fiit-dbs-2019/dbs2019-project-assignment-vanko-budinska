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
using Npgsql;

namespace DesktopApp1
{
    public partial class RezervaciaPolozka : UserControl
    {
        private PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
        public int CisloRezervacie { get; private set; }
        public int PocetIzieb { get; private set; }
        public DateTime Od { get; private set; }
        public DateTime Do { get; private set; }
        public string NazovUbytovania { get; private set; }
        public string Adresa { get; private set; }
        public string Stav { get; private set; }
        private Bookme b;

        public RezervaciaPolozka(Bookme b, int CisloRezervacie, int PocetIzieb, DateTime Od, DateTime Do, string NazovUbytovania, string Adresa, string Stav)
        {

            InitializeComponent();
            this.b = b;
            this.CisloRezervacie = CisloRezervacie;
            this.PocetIzieb = PocetIzieb;
            this.Od = Od;
            this.Do = Do;
            this.NazovUbytovania = NazovUbytovania;
            this.Adresa = Adresa;
            this.Stav = Stav;
            lbl_cisloRezervacie.Text = this.CisloRezervacie.ToString();
            lbl_pocetIzieb.Text = this.PocetIzieb.ToString();
            lbl_od.Text = this.Od.Date.ToString();
            lbl_do.Text = this.Do.Date.ToString();
            lbl_nazovUbytovania.Text = this.NazovUbytovania;
            lbl_adresa.Text = this.Adresa;
            lbl_stav.Text = this.Stav;

        }

        private void btn_Upravit_Click(object sender, EventArgs e)
        {

        }

        private void btn_zrusit_Click(object sender, EventArgs e)
        {
            string q = "DELETE FROM public.zostava_rezervacie z " +
                        "WHERE z.id_rezervacia = :id_rez;";

            NpgsqlConnection connection = db_conn.conn;
            NpgsqlCommand cmd = new NpgsqlCommand(q, connection);
            cmd.Parameters.AddWithValue("id_rez", NpgsqlTypes.NpgsqlDbType.Integer).Value = CisloRezervacie;
            db_conn.command = cmd;
            db_conn.Query();

            q = "DELETE FROM public.rezervacia r " +
                        "WHERE r.id = :id_rez;";
            connection = db_conn.conn;
            cmd = new NpgsqlCommand(q, connection);
            cmd.Parameters.AddWithValue("id_rez", NpgsqlTypes.NpgsqlDbType.Integer).Value = CisloRezervacie;
            db_conn.command = cmd;
            db_conn.Query();
            this.Dispose();
            
        }
    }
}
