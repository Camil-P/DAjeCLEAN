using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCLEAN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string privremeni;
        public MainWindow()
        {
            InitializeComponent();
            if (!Login.sef)
                tablaBtn.Visibility = Visibility.Hidden;

            EFDataProvider.RefreshujPoslove();
        }

        #region Logout
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Visibility = Visibility.Visible;
            this.Close();
        }
        #endregion
        private void listaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Login.sef)
            {
                OdlukaAPiTS ProzorOdluke = new OdlukaAPiTS();
                ProzorOdluke.Visibility = Visibility.Visible;
            }
            else
            {
                Lista prozorLista = new Lista();
                prozorLista.Visibility = Visibility.Visible;
            }
        }

        #region Pojedinacni_Pregled
        private void PranjeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.privremeni = "Pranje";
            Lista ProzorListe = new Lista();
            ProzorListe.Visibility = Visibility.Visible;
        }

        private void ciscenjeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.privremeni = "Ciscenje";
            Lista ProzorListe = new Lista();
            ProzorListe.Visibility = Visibility.Visible;
           
        }

        private void KontejneriBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.privremeni = "Kontejneri";
            Lista ProzorListe = new Lista();
            ProzorListe.Visibility = Visibility.Visible;
            
        }
        #endregion
        private void tablaBtn_Click(object sender, RoutedEventArgs e)
        {
            Account prozorAcc = new Account();
            prozorAcc.Visibility = Visibility.Visible;
        }
    }
}
