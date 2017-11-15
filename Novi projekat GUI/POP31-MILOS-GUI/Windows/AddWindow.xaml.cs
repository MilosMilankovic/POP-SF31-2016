using POP_31.Model;
using POP_31.Util;
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


namespace POP31_MILOS_GUI.Windows
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            Combobx.ItemsSource = MainWindow.listString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.TBId.IsEnabled==true)
            {
                Namestaj n = new Namestaj();
                n.Id = Convert.ToInt32(TBId.Text);
                n.Naziv = TBNaziv.Text;
                n.Sifra = TBSifra.Text;
                n.Obrisan = false;
                //n.TipNamestaja = Convert.ToInt32(TBTipNamestaja.Text);
                n.JedinicnaCena = Convert.ToInt32(TBjedCena.Text);
                n.KolicinaUmagacinu = Convert.ToInt32(TBkolicinaUmag.Text);
                bool nadjen = false;
                foreach(Namestaj a in MainWindow.lista)
                {
                    if(a.Id==n.Id)
                    {
                        nadjen = true;
                        break;
                    }
                }
                if (nadjen==false)
                {
                    MainWindow.lista.Add(n);
                    GenericSerializer.Serialize<Namestaj>("file.xml", MainWindow.lista);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Id vec postoji!");
                }
                
            }
            else
            {
                foreach (Namestaj nam in MainWindow.lista)
                {
                    Namestaj n = new Namestaj();
                    n.Id = Convert.ToInt32(TBId.Text);
                    if (nam.Id == n.Id)
                    {
                        nam.Naziv = TBNaziv.Text;
                        nam.Sifra = TBSifra.Text;
                        nam.Obrisan = false;
                        //nam.TipNamestaja = Convert.ToInt32(TBTipNamestaja.Text);
                        nam.JedinicnaCena = Convert.ToInt32(TBjedCena.Text);
                        nam.KolicinaUmagacinu = Convert.ToInt32(TBkolicinaUmag.Text);
                        break;
                    }
                }
                this.Close();
            }
        }
    }
}
