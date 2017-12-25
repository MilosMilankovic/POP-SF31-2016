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
            //otvara prozor namestaj
        }

        private void btnTipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            TipNamestajaProzor prozor = new TipNamestajaProzor();
            prozor.Show();
        }
    }
}
