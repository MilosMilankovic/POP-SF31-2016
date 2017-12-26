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
        //private static Namestaj nam;
        //public AddWindow()
        //{
        //    InitializeComponent();
        //    this.DataContext = this;
        //    //Combobx.ItemsSource = MainWindow.tipNamLista;
        //   // Combobx.SelectedItem = MainWindow.tipNamLista[0];
            
        //}


        //public AddWindow(Namestaj n)
        //{
        //    InitializeComponent();
        //    nam = n;
        //    this.DataContext = n;
        //    //Combobx.ItemsSource = MainWindow.tipNamLista;
        //   // foreach(TipNamestaja tip in MainWindow.tipNamLista)
        //    {
        //     //   if(tip.Id==nam.TipNamestaja.Id)
        //        {
        //            Combobx.SelectedItem = tip;
        //        //    break;
        //        }
        //    }
            
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.labelaIzmena.Content.ToString()=="Dodavanje")
        //    {
        //        Namestaj n = new Namestaj();
        //    //    n.Id = MainWindow.lista.Count+1;
        //        n.Naziv = TBNaziv.Text;
        //        n.Sifra = TBSifra.Text;
        //        n.Obrisan = false;
        //        n.TipNamestaja = Combobx.SelectedItem as TipNamestaja;
        //        n.JedinicnaCena = Convert.ToInt32(TBjedCena.Text);
        //        n.KolicinaUMagacinu = Convert.ToInt32(TBkolicinaUmag.Text);
                
                
        //      //      MainWindow.lista.Add(n);
        //      //      GenericSerializer.Serialize<Namestaj>("Namestaj.xml", MainWindow.lista);
        //            this.Close();
        //    }
        //    else
        //    {
        //        nam.Naziv = TBNaziv.Text;
        //        nam.Sifra = TBSifra.Text;
        //        nam.Obrisan = false;
        //        nam.TipNamestaja = Combobx.SelectedItem as TipNamestaja;
        //        nam.JedinicnaCena = Convert.ToInt32(TBjedCena.Text);
        //        nam.KolicinaUMagacinu = Convert.ToInt32(TBkolicinaUmag.Text);
        //       // foreach(Namestaj k in MainWindow.lista)
        //        {
        //            if(k.Id==nam.Id)
        //            {
        //                k.JedinicnaCena = nam.JedinicnaCena;
        //                k.KolicinaUMagacinu = nam.KolicinaUMagacinu;
        //                k.Naziv = nam.Naziv;
        //                k.Sifra = nam.Sifra;
        //                k.TipNamestaja = nam.TipNamestaja;
        //                k.Obrisan = nam.Obrisan;
        //            }
        //        }
        //     //   GenericSerializer.Serialize<Namestaj>("Namestaj.xml", MainWindow.lista);
        //        this.Close();
        //    }
        //}
    }
}
