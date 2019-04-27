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
        private Bookme b;
        private PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");

        public MojeRezervacie(Bookme b, Uzivatel uzivatel)
        {
            this.uzivatel = uzivatel;
            this.b = b;
            InitializeComponent();
            Napln_MojeRezervacie();
        }

        public void DisposePanelItems(Panel panel)
        {
            while (panel.Controls.Count > 0) panel.Controls[0].Dispose();
        }

        public void ClearPanel(Panel panel)
        {
            panel.Controls.Clear();
        }

        public void AddPanel(Panel panel, Control item)
        {
            panel.Controls.Add(item);
        }

        private void Napln_MojeRezervacie()
        {
            DisposePanelItems(flp_Rezeravacie);
            ClearPanel(flp_Rezeravacie);

            string q = "SELECT z.id, z.pocet, r.od_dat, r.do_dat, u.nazov, u.adresa, d.nazov, s.nazov, st.stav FROM public.zostava_rezervacie z "
                + " INNER JOIN public.rezervacia r ON z.id_rezervacia = r.id "
                + " INNER JOIN public.ubytovanie u ON z.id_ubytovanie = u.id "
                + " INNER JOIN public.destinacia d ON u.id_destinacia = d.id "
                + " INNER JOIN public.stat s ON d.id_stat = s.id "
                +  "INNER JOIN public.stav_rezervacie st ON r.id_stav = st.id "
                + " WHERE z.id_pouzivatel = :id_pouz;";
            NpgsqlConnection connection = db_conn.conn;
            NpgsqlCommand cmd = new NpgsqlCommand(q, connection);
            cmd.Parameters.AddWithValue("id_pouz", NpgsqlTypes.NpgsqlDbType.Integer).Value = uzivatel.id;
            db_conn.command = cmd;
            List<string> rep = db_conn.Query();
            RezervaciaPolozka[] moje_rezervacie = new RezervaciaPolozka[rep.Count];
            int cisloRez;
            int pocetIz;
            DateTime Od;
            DateTime Do;
            string nazov;
            string adresa;
            string stav;
            for(int i = 0; i < rep.Count; i++)
            {
                var line = rep[i].Split(';');
                cisloRez = Int32.Parse(line[0]);
                pocetIz = Int32.Parse(line[1]);
                Od = DateTime.Parse(line[2]);
                Do = DateTime.Parse(line[3]);
                nazov = line[4];
                adresa = line[5] + " " + line[6] + " " + line[7];
                stav = line[8];
                moje_rezervacie[i] = new RezervaciaPolozka(b, cisloRez, pocetIz, Od, Do, nazov, adresa, stav);
                AddPanel(flp_Rezeravacie, moje_rezervacie[i]);
            }
        
        }


        private void btnSpat_Click(object sender, EventArgs e)
        {
            b.clearPanel(b.flpanel1);
            foreach (var polozka in b.polozky_control)
                b.addflPanel(b.flpanel1, polozka);
        }
    }
}
