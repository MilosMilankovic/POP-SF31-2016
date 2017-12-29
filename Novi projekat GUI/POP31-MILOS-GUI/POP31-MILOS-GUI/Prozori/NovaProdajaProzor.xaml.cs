﻿using POP_31.Model;
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
                listaParova = new ObservableCollection<ParProdaja>()
            };

            dgPar.ItemsSource = prodaja.listaParova;
            dgUsluga.ItemsSource = prodaja.ListaDodatnihUsluga;

            tbKupac.DataContext = prodaja;
            tbBrojRacuna.DataContext = prodaja;
            
        }


        public NovaProdajaProzor(ProdajaNamestaja prodajaCopy)
        {
            InitializeComponent();
            
            dgPar.ItemsSource = prodajaCopy.listaParova;
            dgUsluga.ItemsSource = prodajaCopy.ListaDodatnihUsluga;

            tbKupac.DataContext = prodaja;
            tbBrojRacuna.DataContext = prodaja;

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
            
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

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
                prodaja.ListaDodatnihUsluga.Remove((DodatnaUsluga)dgUsluga.SelectedItem);
            }
        }

        private void btnKupi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
