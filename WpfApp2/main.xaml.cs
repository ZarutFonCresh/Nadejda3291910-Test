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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
        }

        private void ResidentialComplex_Click(object sender, RoutedEventArgs e)
        {
            Maneger.MainFrame.Navigate(new residentialComplex());
        }

        private void House_Click(object sender, RoutedEventArgs e)
        {
            Maneger.MainFrame.Navigate(new houses());
        }

        private void Apartments_Click(object sender, RoutedEventArgs e)
        {
            Maneger.MainFrame.Navigate(new apartment());
        }
    }
}
