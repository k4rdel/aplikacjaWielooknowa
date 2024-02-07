using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplikacjaWielooknowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListaLektur pList = new ListaLektur();
        public MainWindow()
        {
            InitializeComponent();
            pListBox.ItemsSource = pList.lektury;
        }

        private void DodajLekture_Click(object sender, RoutedEventArgs e)
        {
            LeturyWindow lekturywindow = new LeturyWindow();
            lekturywindow.lektura = new Lektura();
            lekturywindow.DataContext = lekturywindow.lektura;
            var result = lekturywindow.ShowDialog();
            if(result == true)
            {
                pList.DodajLekture(lekturywindow.lektura);
            }
        }
        private void EdytujLekture_Click(object sender, RoutedEventArgs e)
        {
            LeturyWindow lekturywindow = new LeturyWindow();
            Lektura lek = pList.lektury[pListBox.SelectedIndex];
            lekturywindow.lektura = new Lektura(lek.Tytul , lek.Autor, lek.Klasa);
            lekturywindow.DataContext = lekturywindow.lektura;
            var result = lekturywindow.ShowDialog();
            if (result == true)
            {
                pList.EdytujLekture(pListBox.SelectedIndex, lekturywindow.lektura);
            }
        }
        private void UsunLekture_Click(object sender, RoutedEventArgs e)
        {
            pList.UsunLektureNa(pListBox.SelectedIndex);
        }
        private void ZapiszLekture_Click(object sender, RoutedEventArgs e)
        {
            pList.ZapiszLektury();
        }
        private void ZaladujLektury_Click(object sender, RoutedEventArgs e)
        {
            pList.ZaladujLektury();
        }
        private void Zamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}