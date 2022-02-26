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

namespace EDODiplom.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BtContractClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ContractListPage());
        }

        private void BtMaterialCLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaterialListPage());
        }

        private void BtSupplierClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtSupplyClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtBuldObjectClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtObjectDocument(object sender, RoutedEventArgs e)
        {

        }
    }
}
