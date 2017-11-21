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
            if (this.labelaDodavanje.IsEnabled==true && this.labelaIzmena.IsEnabled==false)
            {
                Namestaj n = new Namestaj();
                n.Id = MainWindow.lista.Count+1;//ako ih ima vec 5 u listi, dodaje sestog sa id-em 6!
                n.Naziv = TBNaziv.Text;
                n.Sifra = TBSifra.Text;
                n.Obrisan = false;
                string selectedItem = Combobx.SelectedItem.ToString();
                foreach(var item in MainWindow.tipNamLista)
                {
                    if(selectedItem==item.Naziv)
                    {
                        n.TipNamestaja = item;
                    }
                }
                n.JedinicnaCena = Convert.ToInt32(TBjedCena.Text);
                n.KolicinaUmagacinu = Convert.ToInt32(TBkolicinaUmag.Text);
                
                
                    MainWindow.lista.Add(n);
                    GenericSerializer.Serialize<Namestaj>("Namestaj.xml", MainWindow.lista);
                    this.Close();

                
            }
            else
            {
                foreach (Namestaj nam in MainWindow.lista)
                {
                    
                    
                    if (nam.Id == Convert.ToInt32(this.labelaId.Content))
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
                GenericSerializer.Serialize<Namestaj>("Namestaj.xml", MainWindow.lista);
                this.Close();
            }
        }
    }
}
