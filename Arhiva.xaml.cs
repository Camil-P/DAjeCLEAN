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
    /// Interaction logic for Arhiva.xaml
    /// </summary>
    public partial class Arhiva : Window
    {
        ObservableCollection<ArhiviraniPosao> trlista = new ObservableCollection<ArhiviraniPosao>();
        ObservableCollection<ArhiviraniPosao> ListaArhiviranih = new ObservableCollection<ArhiviraniPosao>();
        List<string> tipovi = new List<string>();
        
        public Arhiva()
        {
            InitializeComponent();
            NapuniArhivirane();
            napuniTipove();
            comboTip.ItemsSource = tipovi;
            dgArhiva.ItemsSource = ListaArhiviranih;
        }
        private void NapuniArhivirane()
        {
            var trArhiva = EFDataProvider.GetArhiviraniPoslovi();
            foreach(var tr in trArhiva)
            {
                ListaArhiviranih.Add(tr);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PocetnoVreme.SelectedDate < KrajnjeVreme.SelectedDate)
            {
                trlista.Clear();
                foreach (var ar in ListaArhiviranih)
                {
                    if (ar.vreme >= PocetnoVreme.SelectedDate && ar.vreme <= KrajnjeVreme.SelectedDate) 
                        trlista.Add(ar);
                }
                dgArhiva.ItemsSource = trlista;
            }
            else
                MessageBox.Show("Uneli ste nepostojeci Datum!");
            
        }
        private void napuniTipove()
        {
            tipovi.Add("Sve");
            tipovi.Add("Pranje");
            tipovi.Add("Ciscenje");
            tipovi.Add("Kontejneri");
            
        }

        private void tip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            trlista.Clear();
            foreach(ArhiviraniPosao a in ListaArhiviranih)
            {
                trlista.Add(a);
            }

            if (PocetnoVreme.SelectedDate < KrajnjeVreme.SelectedDate)
            {
                trlista.Clear();
                foreach (var ar in ListaArhiviranih)
                {
                    if (ar.vreme >= PocetnoVreme.SelectedDate && ar.vreme <= KrajnjeVreme.SelectedDate)
                        trlista.Add(ar);
                }
                dgArhiva.ItemsSource = trlista;
            }


            if (comboTip.SelectedValue.ToString() == "Pranje")
            {
                for (int i = 0; i < trlista.Count; i++)
                {
                    if (trlista[i].tip != "Pranje")
                    {
                        trlista.RemoveAt(i);
                        i -= 1;
                    }
                }
                
            }
            else if (comboTip.SelectedValue.ToString()  == "Ciscenje" )
            {
                for (int i = 0; i < trlista.Count; i++)
                {
                    if (trlista[i].tip != "Ciscenje")
                    {
                        trlista.RemoveAt(i);
                        i -= 1;
                    }
                }

            }
            else if (comboTip.SelectedValue.ToString() == "Kontejneri")
            {
                for (int i = 0; i < trlista.Count; i++)
                {
                    if (trlista[i].tip != "Kontejneri")
                    {
                        trlista.RemoveAt(i);
                        i -= 1;
                    }
                }
            }
            else
                dgArhiva.ItemsSource = trlista;
            dgArhiva.ItemsSource = trlista;


           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            trlista.Clear();
            foreach (ArhiviraniPosao a in ListaArhiviranih)
            {
                trlista.Add(a);
            }
            PocetnoVreme.DisplayDateStart.GetValueOrDefault(ListaArhiviranih[0].vreme);
            KrajnjeVreme.DisplayDateStart.GetValueOrDefault(ListaArhiviranih[ListaArhiviranih.Count-1].vreme);
            dgArhiva.ItemsSource = trlista;
        }
    }
}
