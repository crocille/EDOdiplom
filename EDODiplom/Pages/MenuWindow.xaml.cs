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

namespace EDODiplom.Pages
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }


        private void ItemMaterials(object sender, RoutedEventArgs e)
        {
            FRnav.Navigate(new MaterialListPage());
        }

        private void ItemContracts(object sender, RoutedEventArgs e)
        {
            FRnav.Navigate(new ContractListPage());
        }

        private void ItemSuppliers(object sender, RoutedEventArgs e)
        {
            FRnav.Navigate(new SupplierListPage());
        }

        private void ItemBuildObject(object sender, RoutedEventArgs e)
        {

        }

        private void ItemDocumentObject(object sender, RoutedEventArgs e)
        {
            FRnav.Navigate(new ObjectDocumentPage());
        }

        private void BtExit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutorizationPage());
        }
    }
}
