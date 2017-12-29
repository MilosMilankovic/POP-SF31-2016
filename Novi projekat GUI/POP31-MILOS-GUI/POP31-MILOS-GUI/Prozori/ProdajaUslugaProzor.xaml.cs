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
    /// Interaction logic for ProdajaUslugaProzor.xaml
    /// </summary>
    public partial class ProdajaUslugaProzor : Window
    {
        ProdajaNamestaja prodaja;
        public ProdajaUslugaProzor(ProdajaNamestaja prodaja)
        {
            InitializeComponent();

            cbUsluga.ItemsSource = Projekat.Instance.DodatneUsluge;
            this.prodaja = prodaja;

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(cbUsluga.SelectedItem != null)
            {
                prodaja.listaDodatnihUslugaID.Add(((DodatnaUsluga)cbUsluga.SelectedItem).Id);
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
