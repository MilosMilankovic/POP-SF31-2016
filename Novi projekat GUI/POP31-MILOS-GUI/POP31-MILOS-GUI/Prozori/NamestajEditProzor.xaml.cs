﻿using POP_31.Model;
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
        Namestaj namestajReal;
        public NamestajEditProzor()
        {
            InitializeComponent();

            namestajCopy = new Namestaj("","",0,0,0);
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
            namestajReal = namestaj;
            tbNaziv.DataContext = namestajCopy;
            tbCena.DataContext = namestajCopy;
            tbKolicina.DataContext = namestajCopy;
            tbSifra.DataContext = namestajCopy;
            cbTip.ItemsSource = Projekat.Instance.TipNamestaja;
            cbTip.SelectedItem = namestajCopy.TipNamestaja; //trazimo objekat,ispise koji je tip namestaj
            cbTip.DataContext = namestajCopy;

            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            
            if (operacija == Operacija.DODAVANJE)
            {
                Projekat.Instance.Namestaj.Add(namestajCopy);
            }
            if (operacija == Operacija.IZMENA)
            {
                namestajReal.Copy(namestajCopy);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}