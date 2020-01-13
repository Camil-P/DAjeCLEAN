﻿using System;
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
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        ObservableCollection<Nalog> listaNaloga = new ObservableCollection<Nalog>();
        public Account()
        {
            InitializeComponent();
            NapuniNaloge();
            dgAcc.ItemsSource = listaNaloga;
        }
        private void NapuniNaloge()
        {
            var trosobe = EFDataProvider.GetNalozi();
            foreach (Nalog trosoba in trosobe)
                listaNaloga.Add(trosoba);
        }

        private void dodajacc_Click(object sender, RoutedEventArgs e)
        {
            Registracija prozorRegistracije = new Registracija();
            prozorRegistracije.DataContext = listaNaloga;
            prozorRegistracije.Visibility = Visibility.Visible;
        }

        private void izmeniacc_Click(object sender, RoutedEventArgs e)
        {
            if (dgAcc.SelectedItem != null)
            {
                Registracija prozorRegistracije = new Registracija();
                prozorRegistracije.DataContext = dgAcc.SelectedItem;
                prozorRegistracije.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Morate selektovati nalog.");
        }

        private void izbrisiacc_Click(object sender, RoutedEventArgs e)
        {
            if (dgAcc.SelectedItem != null)
            {
                EFDataProvider.IzbrisiNalog(listaNaloga[dgAcc.SelectedIndex]);
                listaNaloga.RemoveAt(dgAcc.SelectedIndex);
            }
            else
                MessageBox.Show("Morate selektovati nalog.");
        }

        private void dgAcc_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                Registracija prozorRegistracije = new Registracija();
                prozorRegistracije.DataContext = dgAcc.SelectedItem;
                prozorRegistracije.Visibility = Visibility.Visible;
            }
        }
    }
}
