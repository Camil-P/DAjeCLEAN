using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ObservableCollection<Nalog> osobe = new ObservableCollection<Nalog>();
        public Login()
        {
            InitializeComponent();

            Napuni();

            cb.ItemsSource = osobe;
            cb.DisplayMemberPath = "username";
        }

        private bool PraznoPolje()
        {
            return string.IsNullOrEmpty(txtSifra.Text);
        }

        private void OcistiLoz()
        {
            txtSifra.Text = string.Empty;
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataContext = cb.SelectedItem;
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (PraznoPolje())
            {
                MessageBox.Show("Niste popunili sva polja");
            }
            else
            {
                foreach (var korisnik in osobe)
                {
                    if (korisnik.username == cb.Text)
                    {
                        if (korisnik.password == txtSifra.Text)
                        {
                            MainWindow Glavniprozor = new MainWindow();
                            Glavniprozor.DataContext = korisnik;
                            Glavniprozor.Visibility = Visibility.Visible;

                            this.Close();
                        }
                        else
                        {
                            OcistiLoz();
                            MessageBox.Show("Uneli ste pogresni sifru, molim vas pokusajte ponovo.");
                        }
                    }
                }
            }
        }

        private void Napuni()
        {
            var trosobe = DataProvider.GetNalozi();
            foreach (Nalog trosoba in trosobe)
                osobe.Add(trosoba);
        }

        private void btKreiraj_Click(object sender, RoutedEventArgs e)
        {
            Registracija prozorregistracije = new Registracija();
            prozorregistracije.DataContext = osobe;
            prozorregistracije.Visibility = Visibility.Visible;
        }
    }
}
