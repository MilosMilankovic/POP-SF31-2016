using POP_31.Model;
using POP_31.Util;
using POP31_MILOS_GUI.Prozori;
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

namespace POP31_MILOS_GUI.Windows
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public static bool isAdmin = false;
        public LogInWindow()
        {
            InitializeComponent();
            userTB.Text = "Milos123";
            passTB.Text = "milos";

        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string user = userTB.Text;
            string pass = passTB.Text;
            bool nadjen = false;
            foreach(Korisnik k in Projekat.Instance.Korisnici)
            {
                if(k.KorisnickoIme==user && k.Lozinka==pass)
                {
                    nadjen = true;
                    if(k.TipKorisnika==TipKorisnika.Administrator)
                    {
                        isAdmin = true;
                    }
                    else
                    {
                        isAdmin = false;
                    }
                    break;
                }
            }

            if(nadjen==true)
            {
                
                GlavniProzor win = new GlavniProzor();
                this.Close();
                win.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Dati korisnik ne postoji u bazi podataka!");
            }

        }

        
    }
}
