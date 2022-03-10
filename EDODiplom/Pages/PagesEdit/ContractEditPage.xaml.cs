using EDODiplom.Database;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics.Contracts;
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
using Contract = EDODiplom.Database.Contract;

namespace EDODiplom.Pages
{
    /// <summary>
    /// Interaction logic for ContractEditPage.xaml
    /// </summary>
    public partial class ContractEditPage : Page
    {
        Contract сontract;
        public ContractEditPage(Contract contract)
        {
            this.сontract = contract;
            InitializeComponent();
            CbSuppliers.ItemsSource = EfModel.Init().Suppliers.ToList();
            DataContext = сontract;
        }

        private void BtSaveContractClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (сontract.ID_Contract == 0)
                    EfModel.Init().Contracts.Add(сontract);
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
                сontract.DocumentScan = File.ReadAllBytes(openFile.FileName);
            }
        }
    }
}
    

