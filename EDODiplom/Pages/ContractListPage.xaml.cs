using EDODiplom.Database;
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
    /// Interaction logic for ContractListPage.xaml
    /// </summary>
    public partial class ContractListPage : Page
    {
        public ContractListPage()
        {
            InitializeComponent();
            UpdateData();
        }
        private void UpdateData()
        {
            IEnumerable<Contract> contracts = EfModel.Init().Contracts
                .Include(c => c.Supplier).Where(c => c.Name.Contains(TbSearch.Text));
            LvContracts.ItemsSource = contracts.ToList();
        }

        private void TbSearchChange(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtContractAddCLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ContractEditPage(new Contract()));
        }

        private void BtContractEditClick(object sender, RoutedEventArgs e)
        {
            if (LvContracts.SelectedItems.Count > 0)
            {
                Contract contract = LvContracts.SelectedItem as Contract;
                NavigationService.Navigate(new ContractEditPage(contract));
            }

        }

        private void BtContractDelClick(object sender, RoutedEventArgs e)
        {
            
            if (LvContracts.SelectedItems.Count > 0)
            {
                Contract contract = LvContracts.SelectedItem as Contract;
                if(MessageBox.Show("Вы точно хотите удалить договор " + contract.Name + "?", "Удалить договор", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    EfModel.Init().Contracts.Remove(contract);
                    EfModel.Init().SaveChanges(); 
                    UpdateData();
                }
            }  
        }

        private void PageVisChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateData();
        }
    }
}

