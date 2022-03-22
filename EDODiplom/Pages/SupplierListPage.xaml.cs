using EDODiplom.Database;
using EDODiplom.Pages.PagesEdit;
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
using System.Data.Entity;

namespace EDODiplom.Pages
{
    /// <summary>
    /// Interaction logic for SupplierListPage.xaml
    /// </summary>
    public partial class SupplierListPage : Page
    {
        public SupplierListPage()
        {
            InitializeComponent();
        }

        private void TbSearchSupplierChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtSupplierAddCLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplierEditPage());
        }

        private void BtSupplierEditClick(object sender, RoutedEventArgs e)
        {
            /*if (LvSuppliers.SelectedItems.Count > 0)
            {
                Supplier supplier = LvSuppliers.SelectedItem as Supplier;
                NavigationService.Navigate(new SupplierEditPage(supplier));
            }*/
        }

        private void BtSupplierDelClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
