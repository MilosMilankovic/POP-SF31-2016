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
    /// Interaction logic for NamestajEditProzor.xaml
    /// </summary>
    public partial class NamestajEditProzor : Window
    {
        private enum Operacija
        {
            IZMENA,
            DODAVANJE
        }

        Operacija operacija;
        Namestaj namestajCopy;

        public NamestajEditProzor()
        {
            InitializeComponent();

            namestajCopy = new Namestaj();
            tbNaziv.DataContext = namestajCopy; 
            tbCena.DataContext = namestajCopy;
            tbKolicina.DataContext = namestajCopy;
            tbSifra.DataContext = namestajCopy;
            cbTip.ItemsSource = Projekat.Instance.TipNamestaja;  

            cbTip.DataContext = namestajCopy;

            operacija = Operacija.DODAVANJE;
        }

        public NamestajEditProzor(Namestaj namestaj)
        {
            InitializeComponent();
            namestajCopy = new Namestaj();
            namestajCopy.Copy(namestaj);

            tbNaziv.DataContext = namestajCopy;
            tbCena.DataContext = namestajCopy;
            tbKolicina.DataContext = namestajCopy;
            tbSifra.DataContext = namestajCopy;
            cbTip.ItemsSource = Projekat.Instance.TipNamestaja;
            cbTip.SelectedItem = namestajCopy.TipNamestaja; 
            cbTip.DataContext = namestajCopy;

            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            if (tbNaziv.Text !="" && double.TryParse(tbCena.Text, out var x) && x > 0 && int.TryParse(tbKolicina.Text, out var y) && y > 0 && tbSifra.Text !="" && cbTip.SelectedItem !=null)
            {



                if (operacija == Operacija.DODAVANJE)
                {
                    Namestaj.Create(namestajCopy);
                }
                if (operacija == Operacija.IZMENA)
                {
                    Namestaj.Update(namestajCopy);
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
