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

namespace POP31_MILOS_GUI.Prozori
{
    /// <summary>
    /// Interaction logic for GlavniProzor.xaml
    /// </summary>
    public partial class GlavniProzor : Window
    {
        public GlavniProzor()
        {
            InitializeComponent();
        }

        private void btnNamestaj_Click(object sender, RoutedEventArgs e) 
        {
            NamestajProzor prozor = new NamestajProzor();
            prozor.Show();
        }

        private void btnTipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            TipNamestajaProzor prozor = new TipNamestajaProzor();
            prozor.Show();
        }

        private void btnDodatnaUsluga_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUslugaProzor prozor = new DodatnaUslugaProzor();
            prozor.Show();
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            KorisnikProzor prozor = new KorisnikProzor();
            prozor.Show();
        }
    }
}
