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
    /// Interaction logic for ProdajaNamestajProzor.xaml
    /// </summary>
    public partial class ProdajaNamestajProzor : Window
    {


        private enum Operacija
        {
            IZMENA,
            DODAVANJE
        }

        Operacija operacija;
        ParProdaja parCopy;
        ParProdaja parReal;

        ProdajaNamestaja prodaja;

        public ProdajaNamestajProzor(ProdajaNamestaja prodaja)
        {
            InitializeComponent();
            parCopy = new ParProdaja();

            this.prodaja = prodaja;

            cbNamestaj.ItemsSource = Projekat.Instance.Namestaj;

            tbKolicina.DataContext = parCopy;

            cbNamestaj.DataContext = parCopy;

            operacija = Operacija.DODAVANJE;
            
        }


        public ProdajaNamestajProzor(ParProdaja par, ProdajaNamestaja prodaja)
        {
            InitializeComponent();

            this.prodaja = prodaja;

            parCopy = new ParProdaja();

            parCopy.Copy(par);

            parReal = par;

            cbNamestaj.ItemsSource = Projekat.Instance.Namestaj;

            tbKolicina.DataContext = parCopy;

            cbNamestaj.DataContext = parCopy;

            operacija = Operacija.IZMENA;

            
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (cbNamestaj.SelectedItem != null && int.TryParse(tbKolicina.Text, out var x) && x >0)
            {


                if (operacija == Operacija.DODAVANJE)
                {
                    prodaja.listaParova.Add(parCopy);
                }
                if (operacija == Operacija.IZMENA)
                {
                    parReal.Copy(parCopy);
                }
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
