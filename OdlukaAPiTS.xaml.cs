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
using System.Windows.Shapes;

namespace WPFCLEAN
{
    /// <summary>
    /// Interaction logic for OdlukaAPiTS.xaml
    /// </summary>
    public partial class OdlukaAPiTS : Window
    {
        public OdlukaAPiTS()
        {
            InitializeComponent();
        }

        private void pts_Click(object sender, RoutedEventArgs e)
        {
            Lista ProzorListe = new Lista();
            ProzorListe.Visibility = Visibility.Visible;
            this.Close();
        }

        private void pap_Click(object sender, RoutedEventArgs e)
        {
            string danas = DateTime.Now.DayOfWeek.ToString();
            MessageBox.Show(danas);
        }
    }
}
