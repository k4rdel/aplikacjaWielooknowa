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

namespace aplikacjaWielooknowa
{
    /// <summary>
    /// Logika interakcji dla klasy LeturyWindow.xaml
    /// </summary>
    public partial class LeturyWindow : Window
    {
        public Lektura lektura;
        public LeturyWindow()
        {
            InitializeComponent();
            klasa.ItemsSource = Enum.GetValues(typeof(KtoraKlasa)).Cast<KtoraKlasa>();
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
