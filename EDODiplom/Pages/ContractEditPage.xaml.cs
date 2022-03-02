using EDODiplom.Database;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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
    /// Interaction logic for ContractEditPage.xaml
    /// </summary>
    public partial class ContractEditPage : Page
    {
        Contract Contract;
        public ContractEditPage(Contract contract)
        {
            this.Contract = contract;
            Contract = new Contract { Date = DateTime.Now };
            InitializeComponent();
            DataContext = Contract;
        }

        private void BtSaveContractClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Contract.ID_Contract == 0)
                    EfModel.Init().Contracts.Add(Contract);
                EfModel.Init().SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(String.Join(", ", ex.EntityValidationErrors.Last().ValidationErrors.Select(ve => ve.ErrorMessage)));
            }
        }

        private void ImageChangeClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                Contract.DocumentScan = File.ReadAllBytes(openFile.FileName);
            }
        }
    }
}
    

