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
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {

            if (Provera_Polja())
            {
                MessageBox.Show("Jedno ili vise pola je prazno! Unesite sva polja da bi napravili nalog.");
            }
            else
            {
                if (txttip.Text == "Sef" || txttip.Text == "Radnik")
                {
                    if (DataContext is ObservableCollection<Nalog> Osobeplus)
                    {
                        bool provera = false;
                        foreach(var osoba in Osobeplus)
                        {
                            if(osoba.username == txtusername.Text)
                            {
                                provera = true;
                            }
                        }
                        if (!provera)
                        {
                            Nalog novaosoba = new Nalog();
                            novaosoba.username = txtusername.Text;
                            novaosoba.password = txtsifra.Text;
                            novaosoba.prava = txttip.Text;
                            novaosoba.imePrezime = txtimeprezime.Text;

                            Osobeplus.Add(novaosoba);
                            DataProvider.DodajNalog(novaosoba);
                            this.Close();
                        }
                        else
                            MessageBox.Show("Korisničko ime je zauzeto!");
                    }
                }
                else
                    MessageBox.Show("Unesite ispravan tip.");

            }
        }
        private bool Provera_Polja()
        {
            return string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtsifra.Text) || string.IsNullOrEmpty(txtimeprezime.Text) ||
                string.IsNullOrEmpty(txttip.Text);
        }
        /*private bool Proveri()
        {
            bool potvrda = true;
            if (DataContext is ObservableCollection<Nalog> Osobeplus)
            {
                foreach(var osoba in Osobeplus)
                {
                    if (osoba.username == txtusername.Text)
                        return potvrda;
                    else
                    {
                        potvrda = false;
                        return potvrda;
                    }
                }
            }
        }*/
    }
}
