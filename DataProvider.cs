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

        static public void DodajPosao(Posao posao)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.Posaos.Add(posao);
                cnt.SaveChanges();
            }
        }

        static public int IzbrisiPosao(Posao posao)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.Posaos.Remove(posao);
                return cnt.SaveChanges();
            }
        }
        
        static public int IzmeniPosao(Posao posao)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                Posao tmp = cnt.Posaos.Where(x => x.idPosla == posao.idPosla).FirstOrDefault();
                tmp.tip = posao.tip;
                tmp.vreme = posao.vreme;
                tmp.ulicaIme = posao.ulicaIme;
                tmp.datum = posao.datum;
                tmp.userRadnika = posao.userRadnika;
                return cnt.SaveChanges();
            }
        }

        static public void DodajUlicu(Ulica ulica)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.Ulicas.Add(ulica);
                cnt.SaveChanges();
            }
        }

        static public int IzbrisiUlicu(Ulica ulica)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.Ulicas.Remove(ulica);
                return cnt.SaveChanges();
            }
        }

        static public int IzmeniUlicu(Ulica ulica)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                Ulica tmp = cnt.Ulicas.Where(x => x.ulica1 == ulica.ulica1).FirstOrDefault();
                tmp.povrsina = ulica.povrsina;
                tmp.planPranja = ulica.planPranja;
                tmp.ulica1 = ulica.ulica1;
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
        static public Ulica GetUlica(string ulica)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.Ulicas.Where(x => x.ulica1 == ulica).FirstOrDefault();
            }
        }

        static public List<Ulica> GetUlice()
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.Ulicas.ToList();
            }
        }
        static public Posao GetPosao(int posao)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.Posaos.Where(x => x.idPosla == posao).FirstOrDefault();
            }
        }

        static public List<Posao> GetPoslove()
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.Posaos.ToList();
            }
        }
    }
}
