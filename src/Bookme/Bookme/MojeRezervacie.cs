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
    public partial class MojeRezervacie : UserControl
    {
        private Uzivatel uzivatel;
        private PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
        public MojeRezervacie(Uzivatel uzivatel)
        {
            this.uzivatel = uzivatel;
            InitializeComponent();
        }

        public void fill_dataGrid()
        {
            string q = "SELECT z.id, z.pocet, r.od_dat, r.do_dat, u.nazov, u.adresa, d.nazov, s.nazov FROM public.zostava_rezervacie z "
                + " INNER JOIN public.rezervacia r ON z.id_rezervacia = r.id "
                + " INNER JOIN public.ubytovanie u ON z.id_ubytovanie = u.id "
                + " INNER JOIN public.destinacia d ON u.id_destinacia = d.id "
                + " INNER JOIN public.stat s ON d.id_stat = s.id "
                + " WHERE z.id_pouzivatel = :id_pouz;";
            NpgsqlConnection connection = db_conn.conn;
            NpgsqlCommand cmd = new NpgsqlCommand(q, connection);
            cmd.Parameters.AddWithValue("id_pouz", NpgsqlTypes.NpgsqlDbType.Integer).Value = uzivatel.id;
            db_conn.command = cmd;
            List<string> rep = db_conn.Query();
            dataGridRezervacie.ColumnCount = 8;
            dataGridRezervacie.Columns[0].Name = "Cislo r.";
            dataGridRezervacie.Columns[1].Name = "Pocet iz.";
            dataGridRezervacie.Columns[2].Name = "Od";
            dataGridRezervacie.Columns[3].Name = "Do";
            dataGridRezervacie.Columns[4].Name = "Nazov";
            dataGridRezervacie.Columns[5].Name = "Adresa";
            dataGridRezervacie.Columns[6].Name = "Destinacia";
            dataGridRezervacie.Columns[7].Name = "Stat";

            foreach (var line in rep)
            {
                dataGridRezervacie.Rows.Add(line.Split(';'));
            }
        }
    }
}
