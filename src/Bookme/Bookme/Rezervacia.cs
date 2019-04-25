using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp1
{
    public class Rezervacia
    {
        public DateTime od_dat { get; private set; }
        public DateTime do_dat { get; private set; }
        public int id { get; private set; }

        public Rezervacia(DateTime od_dat, DateTime do_dat, int id)
        {
            this.od_dat = od_dat;
            this.do_dat = do_dat;
            this.id = id;
        }
    }
}
