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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfParametri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrikaziKategorije()
        {
            ComboBox1.Items.Clear();            

            if (KategorijaDal.VratiKategorije() != null)
            {
                foreach (Kategorija k in KategorijaDal.VratiKategorije())
                {
                    ComboBox1.Items.Add(k);
                }
            }
        }

        private Kategorija NadjiKategoriju(int id)
        {
            foreach (Kategorija k in ComboBox1.Items)
            {
                if (k.KategorijaId == id)
                {
                    return k;
                }
            }
            return null;
        }

        private void Resetuj()
        {
            TextBoxId.Clear();
            TextBoxNaziv.Clear();
            TextBoxOpis.Clear();
            ComboBox1.SelectedIndex = -1;
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxNaziv.Text))
            {
                MessageBox.Show("Unesite Naziv");
                TextBoxNaziv.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextBoxOpis.Text))
            {
                MessageBox.Show("Unesite Opis");
                TextBoxOpis.Focus();
                return false;
            }

            return true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKategorije();
            
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedIndex > -1)
            {
                Kategorija k = ComboBox1.SelectedItem as Kategorija;
                TextBoxId.Text = k.KategorijaId.ToString();
                TextBoxNaziv.Text = k.NazivKategorije;
                TextBoxOpis.Text = k.OpisKategorije;
            }
        }

        private void ButtonResetuj_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
        }

        //INSERT
        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                Kategorija k = new Kategorija {
                    NazivKategorije = TextBoxNaziv.Text,
                    OpisKategorije = TextBoxOpis.Text
                };
                
                int Id = KategorijaDal.UbaciKategoriju(k);

                if (Id > 0)
                {
                    PrikaziKategorije();
                    //ComboBox1.SelectedIndex = k.KategorijaId;
                    ComboBox1.SelectedItem = NadjiKategoriju(Id);
                    MessageBox.Show("Kategorija ubacena");
                }
                else
                {
                    MessageBox.Show("Greska pri ubacivanju podataka.");
                }
            }
        }

        //UPDATE
        private void ButtonPromeni_Click(object sender, RoutedEventArgs e)
        {
            int indeks = ComboBox1.SelectedIndex;
            if (indeks> -1)
            {
                Kategorija selK = ComboBox1.SelectedItem as Kategorija;
                if (Validacija())
                {
                    selK.NazivKategorije = TextBoxNaziv.Text;
                    selK.OpisKategorije = TextBoxOpis.Text;
                    int rez = KategorijaDal.PromeniKategoriju(selK);

                    if (rez == 0)
                    {
                        PrikaziKategorije();
                        ComboBox1.SelectedItem = NadjiKategoriju(selK.KategorijaId);
                        MessageBox.Show("Podaci promenjeni");
                    }
                    else
                    {
                        MessageBox.Show("Greska pri promeni podataka.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberite kategoriju");
            }
            
        }

        //DELETE
        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex > -1)
            {
                var rez = MessageBox.Show("Da li se sigurni", "?", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (rez == MessageBoxResult.OK)
                {
                    Kategorija selK = ComboBox1.SelectedItem as Kategorija;

                    if (KategorijaDal.ObrisiKategoriju(selK.KategorijaId) == 0)
                    {
                        PrikaziKategorije();
                        Resetuj();
                        MessageBox.Show("Kategorija obrisana");
                    }
                    else
                    {
                        MessageBox.Show("Greska pri brisanju podataka");
                    }
                }                
            }
            else
            {
                MessageBox.Show("Odaberite kategoriju");
            }
        }
    }
}
