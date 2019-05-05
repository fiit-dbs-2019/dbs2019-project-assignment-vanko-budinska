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
using System.Threading;

namespace DesktopApp1
{
    public partial class RezervaciaPolozka : UserControl
    {
        private PostGreSQL db_conn = new PostGreSQL("127.0.0.1", "5432", "martin", "271996", "bookme", "public");
        public int CisloRezervacie { get; private set; }
        public int PocetIzieb;
        public DateTime Od;
        public DateTime Do;
        public string NazovUbytovania { get; private set; }
        public string Adresa { get; private set; }
        public string Stav;
        private Bookme b;
        private delegate void SafeCallDelegateZmenaIzieb(string pocet_izieb);
        private delegate void SafeCallDelegateZmenaStavu(string stav);
        private delegate void SafeCallDelegateZmenaDatOd(string dat_od);
        private delegate void SafeCallDelegateZmenaDatDo(string dat_do);


        public RezervaciaPolozka()
        {
            InitializeComponent();
        }

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
            Thread th_reg = new Thread(new ThreadStart(Start_ZmenaRezervacie));
            th_reg.Start();
            th_reg.Join();
        }

        private void Start_ZmenaRezervacie()
        {
            form_ZmenaRezervacie formZmena = new form_ZmenaRezervacie(this);
            Application.Run(formZmena);
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

        private void WriteZmenaStavu(string stav)
        {
            if (this.lbl_stav.InvokeRequired)
            {
                SafeCallDelegateZmenaStavu d = new SafeCallDelegateZmenaStavu(ZmenaStavuUloz);
                BeginInvoke(d, new object[] { stav });
            }
            else
            {
                lbl_stav.Text = stav;
            }
        }

        public void ZmenaStavuUloz(string stav)
        {
            WriteZmenaStavu(stav);
        }

        private void WriteZmenaIzieb(string pocetIzieb)
        {
            if (this.lbl_pocetIzieb.InvokeRequired)
            {
                SafeCallDelegateZmenaIzieb d = new SafeCallDelegateZmenaIzieb(WriteZmenaIzieb);
                BeginInvoke(d, new object[] { pocetIzieb });
            }
            else
            {
                lbl_pocetIzieb.Text = pocetIzieb;
            }
        }

        public void ZmenaIziebUloz(string pocetIzieb)
        {
            WriteZmenaIzieb(pocetIzieb);
        }

        private void WriteZmenaDatOd(string dat_od)
        {
            if (this.lbl_od.InvokeRequired)
            {
                SafeCallDelegateZmenaDatOd d = new SafeCallDelegateZmenaDatOd(WriteZmenaDatOd);
                BeginInvoke(d, new object[] { dat_od });
            }
            else
            {
                lbl_od.Text = dat_od;
            }
        }

        public void ZmenaDatOdUloz(string dat_od)
        {
            WriteZmenaDatOd(dat_od);
        }

        private void WriteZmenaDatDo(string dat_do)
        {
            if (this.lbl_do.InvokeRequired)
            {
                SafeCallDelegateZmenaDatDo d = new SafeCallDelegateZmenaDatDo(WriteZmenaDatDo);
                BeginInvoke(d, new object[] { dat_do });
            }
            else
            {
                lbl_do.Text = dat_do;
            }
        }

        public void ZmenaDatDoUloz(string dat_do)
        {
            WriteZmenaDatDo(dat_do);
        }
    }
}
