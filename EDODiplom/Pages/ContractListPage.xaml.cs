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
                .Where(c => c.Name.Contains(TbSearch.Text));
            LvContracts.ItemsSource = contracts.ToList();
        }

        private void TbSearchChange(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
