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
    /// Interaction logic for KorisnikEditProzor.xaml
    /// </summary>
    public partial class KorisnikEditProzor : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }

        Operacija operacija;
        Korisnik korisnikCopy;
        Korisnik korisnikReal;
        
        public KorisnikEditProzor()
        {
            InitializeComponent();
            korisnikCopy = new Korisnik("", "", "", "",0);

            tbIme.DataContext = korisnikCopy;
            tbKorisnickoIme.DataContext = korisnikCopy;
            tbLozinka.DataContext = korisnikCopy;
            tbPrezime.DataContext = korisnikCopy;
            cbTipKorisnika.DataContext = korisnikCopy;

            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika));

            operacija = Operacija.DODAVANJE;
        }

        public KorisnikEditProzor(Korisnik korisnik)
        {
            InitializeComponent();

            korisnikCopy = new Korisnik();
            korisnikCopy.Copy(korisnik);
            korisnikReal = korisnik;
            tbIme.DataContext = korisnikCopy;
            tbKorisnickoIme.DataContext = korisnikCopy;
            tbLozinka.DataContext = korisnikCopy;
            tbPrezime.DataContext = korisnikCopy;
            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika));
            cbTipKorisnika.DataContext = korisnikCopy;
            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbIme.Text !="" && tbPrezime.Text !="" && tbKorisnickoIme.Text !="" && tbLozinka.Text !="" && cbTipKorisnika.SelectedItem !=null)
            {


                if (operacija == Operacija.DODAVANJE)
                {
                    Projekat.Instance.Korisnici.Add(korisnikCopy);
                }
                else if (operacija == Operacija.IZMENA)
                {
                    korisnikReal.Copy(korisnikCopy);
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
