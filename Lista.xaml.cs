using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFCLEAN
{
    /// <summary>
    /// Interaction logic for Lista.xaml
    /// </summary>
    public partial class Lista : Window
    {
        List<MoguciPosao> dnevniposlovi = new List<MoguciPosao>();
        private bool _stiklirano;
        public bool stiklirano
        {
            get => _stiklirano;
            set
            {

            }
        }
        public Lista()
        {
            InitializeComponent();

            NapuniDnevno();

            dgDP.ItemsSource = dnevniposlovi;
        }
        private void NapuniDnevno()
        {
            var trposlovi = EFDataProvider.GetMoguciPoslovi();
            string danas = DateTime.Now.DayOfWeek.ToString();
            switch (danas)
            {
                case "Monday":
                    dnevniposlovi.AddRange(trposlovi.Where(x => x.planp == "A" || x.planp == "E"));
                    break;
                case "Tuesday":
                    dnevniposlovi.AddRange(trposlovi.Where(x => x.planp == "B"));
                    break;
                case "Wednesday":
                    string strdatum = DateTime.Now.ToString();
                    int datum = int.Parse(strdatum.ElementAt(3).ToString()) * 10 + int.Parse(strdatum.ElementAt(4).ToString());
                    if (datum >= 23)
                    {
                        dnevniposlovi.AddRange(trposlovi.Where(x => x.planp == "F"));
                        break;
                    }
                    else
                    {
                        dnevniposlovi.AddRange(trposlovi.Where(x => x.planp == "A"));
                        break;
                    }

                case "Thursday":
                    dnevniposlovi.AddRange(trposlovi.Where(x => x.planp == "C"));
                    break;
                case "Friday":
                    dnevniposlovi.AddRange(trposlovi.Where(x => x.planp == "D"));
                    break;

            }
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            dnevniposlovi.Add(new MoguciPosao());
            dgDP.ItemsSource = null;
            dgDP.ItemsSource = dnevniposlovi;
        }
        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach(MoguciPosao p in dgDP.ItemsSource)
                p.Stiklirano = true;
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (MoguciPosao p in dgDP.ItemsSource)
                p.Stiklirano = false;
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            foreach(MoguciPosao p in dgDP.ItemsSource)
            {
                if (p.Stiklirano == true)
                { 

                }
            }
        }
    }
}
