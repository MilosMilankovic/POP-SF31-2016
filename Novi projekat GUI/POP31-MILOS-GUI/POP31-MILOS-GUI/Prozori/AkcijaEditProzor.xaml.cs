using POP_31.Model;
using System;
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

namespace POP31_MILOS_GUI.Prozori
{
    /// <summary>
    /// Interaction logic for AkcijaEditProzor.xaml
    /// </summary>
    public partial class AkcijaEditProzor : Window
    {

        private enum Operacija
        {
            IZMENA,
            DODAVANJE
        }

        Operacija operacija;
        Akcija akcijaCopy;

        public AkcijaEditProzor()
        {
            InitializeComponent();
            akcijaCopy = new Akcija();
            tbNaziv.DataContext = akcijaCopy;
            dpPocetak.DataContext = akcijaCopy;
            dpKraj.DataContext = akcijaCopy;
            dgPar.ItemsSource = akcijaCopy.ListaParova;

            operacija = Operacija.DODAVANJE;
        }

        public AkcijaEditProzor(Akcija akcija)
        {
            InitializeComponent();
            akcijaCopy = new Akcija();
            akcijaCopy.Copy(akcija);

            tbNaziv.DataContext = akcijaCopy;
            dpPocetak.DataContext = akcijaCopy;
            dpKraj.DataContext = akcijaCopy;
            dgPar.ItemsSource = akcijaCopy.ListaParova;
            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (akcijaCopy.ListaParova.Count > 0 && tbNaziv.Text != "")
            {

                if (operacija == Operacija.DODAVANJE)
                {
                    Akcija.Create(akcijaCopy);
                }
                if (operacija == Operacija.IZMENA)
                {
                    Akcija.Update(akcijaCopy);
                }
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {

            if (dgPar.SelectedItem != null)
            {
                AkcijaEditPar prozor = new AkcijaEditPar((Par)dgPar.SelectedItem, akcijaCopy);
                prozor.Show();
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            AkcijaEditPar prozor = new AkcijaEditPar(akcijaCopy);
            prozor.Show();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgPar.SelectedItem != null)
            {
                akcijaCopy.ListaParova.Remove((Par)dgPar.SelectedItem);

            }
        }
    }
}