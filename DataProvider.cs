using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCLEAN
{
    class DataProvider
    {
        static public void DodajNalog(Nalog nalog)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.Nalogs.Add(nalog);
                cnt.SaveChanges();
            }
        }

        static public int IzbrisiNalog(Nalog nalog)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.Nalogs.Remove(nalog);
                return cnt.SaveChanges();
            }
        }

        static public int IzmeniNalog(Nalog nalog)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                Nalog tmp = cnt.Nalogs.Where(x => x.username == nalog.username).FirstOrDefault();
                tmp.password = nalog.password;
                tmp.imePrezime = nalog.imePrezime;
                tmp.prava = nalog.prava;
                tmp.username = nalog.username;

                return cnt.SaveChanges();
            }
        }

        static public Nalog GetNalog(string nalog)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.Nalogs.Where(x => x.username == nalog).FirstOrDefault();
            }
        }
        static public List<Nalog> GetNalozi()
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.Nalogs.ToList();
            }
        }
    }
}
