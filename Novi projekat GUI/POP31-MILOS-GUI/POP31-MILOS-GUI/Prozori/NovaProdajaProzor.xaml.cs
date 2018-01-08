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
    /// Interaction logic for NovaProdajaProzor.xaml
    /// </summary>
    public partial class NovaProdajaProzor : Window
    {
        ProdajaNamestaja prodaja;
        public NovaProdajaProzor()
        {
            InitializeComponent();

            prodaja = new ProdajaNamestaja()
            {
                listaDodatnihUslugaID = new ObservableCollection<int>(),
                listaParova = new ObservableCollection<ParProdaja>(),
                listaDodatnihUsluga = new ObservableCollection<DodatnaUsluga>()
            };

            dgPar.ItemsSource = prodaja.listaParova;
            dgUsluga.ItemsSource = prodaja.listaDodatnihUsluga;

            tbKupac.DataContext = prodaja;
            tbBrojRacuna.DataContext = prodaja;
            
        }


        public NovaProdajaProzor(ProdajaNamestaja prodajaCopy)
        {
            InitializeComponent();
            
            dgPar.ItemsSource = prodajaCopy.listaParova;
            dgUsluga.ItemsSource = prodajaCopy.ListaDodatnihUsluga;

            tbKupac.DataContext = prodajaCopy;
            tbBrojRacuna.DataContext = prodajaCopy;

            btnDodaj.IsEnabled = false;
            btnIzmeni.IsEnabled = false;
            btnObrisi.IsEnabled = false;

            btnUslugaDodaj.IsEnabled = false;
            btnUslugaObrisi.IsEnabled = false;

            tbKupac.IsReadOnly = true;
            tbBrojRacuna.IsReadOnly = true;

            btnKupi.IsEnabled = false;
        }


        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            ProdajaNamestajProzor prozor = new ProdajaNamestajProzor(prodaja);
            prozor.Show();

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            

            if(dgPar.SelectedItem != null)
            {
                ProdajaNamestajProzor prozor = new ProdajaNamestajProzor(((ParProdaja)dgPar.SelectedItem), prodaja);
                prozor.Show();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if(dgPar.SelectedItem != null)
            {
                prodaja.listaParova.Remove((ParProdaja)dgPar.SelectedItem);
            }
        }

        private void btnUslugaDodaj_Click(object sender, RoutedEventArgs e)
        {
            ProdajaUslugaProzor prozor = new ProdajaUslugaProzor(prodaja);
            prozor.Show();
        }

        private void btnUslugaObrisi_Click(object sender, RoutedEventArgs e)
        {
            if(dgUsluga.SelectedItem != null)
            {
                prodaja.listaDodatnihUsluga.Remove((DodatnaUsluga)dgUsluga.SelectedItem);
            }
        }

        private void btnKupi_Click(object sender, RoutedEventArgs e)
        {

            if (tbKupac.Text !="" && tbBrojRacuna.Text !="" && (prodaja.listaParova.Count > 0 || prodaja.listaDodatnihUsluga.Count > 0))
            {
                foreach (ParProdaja par in prodaja.listaParova)
                {
                    if (par.Kolicina > Namestaj.GetById(par.NamestajId).KolicinaUMagacinu) 
                    {
                        MessageBox.Show("Nema dovoljno namestaja na stanju.", "Greska");
                        return;
                    }
                }

                foreach (DodatnaUsluga usluga in prodaja.listaDodatnihUsluga)
                {
                    prodaja.listaDodatnihUslugaID.Add(usluga.Id);
                }

                foreach (ParProdaja par in prodaja.listaParova)
                {
                    Namestaj.GetById(par.NamestajId).KolicinaUMagacinu -= par.Kolicina; 
                    Namestaj.Update(par.Namestaj); 
                }

                Projekat.Instance.Prodaja.Add(prodaja);

                Close();
            }
        }
    }
}
