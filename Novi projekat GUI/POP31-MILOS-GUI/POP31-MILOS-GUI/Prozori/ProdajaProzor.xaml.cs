using POP_31.Model;
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
    /// Interaction logic for ProdajaProzor.xaml
    /// </summary>
    public partial class ProdajaProzor : Window
    {
        public ProdajaProzor()
        {
            InitializeComponent();

            dgProdaja.ItemsSource = Projekat.Instance.Prodaja;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            NovaProdajaProzor prozor = new NovaProdajaProzor();
            prozor.Show();
        }

        private void btnPrikazi_Click(object sender, RoutedEventArgs e)
        {
            
            
           if(dgProdaja.SelectedItem != null)
            {
                NovaProdajaProzor prozor = new NovaProdajaProzor((ProdajaNamestaja)dgProdaja.SelectedItem);
                prozor.Show();
            }
        }
    }
}
