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
    /// Interaction logic for AkcijaEditPar.xaml
    /// </summary>
    public partial class AkcijaEditPar : Window
    {

        private enum Operacija
        {
            IZMENA,
            DODAVANJE
        }

        Operacija operacija;
        Par parCopy;
        Par parReal;
        Akcija akcija;

        public AkcijaEditPar(Akcija akcija)
        {
            InitializeComponent();

            this.akcija = akcija;
            parCopy = new Par(new Namestaj(), 0);
            
            
            cbNamestaj.ItemsSource = Projekat.Instance.Namestaj;
            tbPopust.DataContext = parCopy;
            cbNamestaj.DataContext = parCopy;

            operacija = Operacija.DODAVANJE;
        }

        public AkcijaEditPar(Par par, Akcija akcija)
        {
            InitializeComponent();

            this.akcija = akcija;

            parCopy = new Par();
            parCopy.Copy(par);
            parReal = par;

            cbNamestaj.ItemsSource = Projekat.Instance.Namestaj;
            tbPopust.DataContext = parCopy;
            cbNamestaj.DataContext = parCopy;

            operacija = Operacija.IZMENA;
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (cbNamestaj.SelectedItem !=null && double.TryParse(tbPopust.Text, out var x) && x >0 )
            {



                if (operacija == Operacija.DODAVANJE)
                {
                    akcija.ListaParova.Add(parCopy);
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
