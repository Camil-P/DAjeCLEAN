using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCLEAN
{
    class EFDataProvider
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
                tmp.username = nalog.username;

                return cnt.SaveChanges();
            }
        }
        static public void DodajPoruku(Poruka poruka)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.Porukas.Add(poruka);
                cnt.SaveChanges();
            }
        }

        static public int IzbrisiPoruku(Poruka poruka)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.Porukas.Remove(poruka);
                return cnt.SaveChanges();
            }
        }

        static public int IzmeniPoruku(Poruka poruka)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                Poruka tmp = cnt.Porukas.Where(x => x.idPoruke == poruka.idPoruke).FirstOrDefault();
                tmp.userKorisnika = poruka.userKorisnika;
                tmp.poruka1 = poruka.poruka1;
                tmp.datumObjave = poruka.datumObjave;

                return cnt.SaveChanges();
            }
        }

        static public void DodajArhiviraniPosao(ArhiviraniPosao posao)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.ArhiviraniPosaos.Add(posao);
                cnt.SaveChanges();
            }
        }

        static public int IzbrisiArhiviraniPosao(ArhiviraniPosao posao)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.ArhiviraniPosaos.Remove(posao);
                return cnt.SaveChanges();
            }
        }

        static public int IzmeniArhiviraniPosao(ArhiviraniPosao posao)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                ArhiviraniPosao tmp = cnt.ArhiviraniPosaos.Where(x => x.idPosla == posao.idPosla).FirstOrDefault();
                tmp.tip = posao.tip;
                tmp.vreme = posao.vreme;
                tmp.ulicaIme = posao.ulicaIme;
                tmp.datum = posao.datum;

                return cnt.SaveChanges();
            }
        }

        static public void DodajMoguciPosao(MoguciPosao ulica)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.MoguciPosaos.Add(ulica);
                cnt.SaveChanges();
            }
        }

        static public int IzbrisiMoguciPosao(MoguciPosao ulica)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                cnt.MoguciPosaos.Remove(ulica);
                return cnt.SaveChanges();
            }
        }

        static public int IzmeniMoguciPosao(MoguciPosao ulica)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                MoguciPosao tmp = cnt.MoguciPosaos.Where(x => x.ulica == ulica.ulica).FirstOrDefault();
                tmp.povrsina = ulica.povrsina;
                tmp.planp = ulica.planp;
                tmp.ulica = ulica.ulica;
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
        static public ArhiviraniPosao GetArhiviraniPosao(int id)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.ArhiviraniPosaos.Where(x => x.idPosla == id).FirstOrDefault();
            }
        }

        static public List<ArhiviraniPosao> GetArhiviraniPoslovi()
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.ArhiviraniPosaos.ToList();
            }
        }

        static public MoguciPosao GetMoguciPosao(string ulica)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.MoguciPosaos.Where(x => x.ulica == ulica).FirstOrDefault();
            }
        }

        static public List<MoguciPosao> GetMoguciPoslovi()
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.MoguciPosaos.ToList();
            }
        }
        static public Poruka GetPoruka(int idpor)
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.Porukas.Where(x => x.idPoruke == idpor).FirstOrDefault();
            }
        }

        static public List<Poruka> GetPoruke()
        {
            using (DataBaseEntities cnt = new DataBaseEntities())
            {
                return cnt.Porukas.ToList();
            }
        }

    }
}
