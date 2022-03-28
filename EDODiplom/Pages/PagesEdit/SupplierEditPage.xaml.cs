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

namespace EDODiplom.Pages.PagesEdit
{
    /// <summary>
    /// Interaction logic for SupplierEditPage.xaml
    /// </summary>
    public partial class SupplierEditPage : Page
    {
        Supplier supplier;
        public SupplierEditPage(Supplier supplier)
        {
            this.supplier = supplier;
            InitializeComponent();
            DataContext = supplier;
        }

        private void BtSaveSupplierClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (supplier.ID_Supplier == 0)
                    EfModel.Init().Suppliers.Add(supplier);
                EfModel.Init().SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(String.Join(", ", ex.EntityValidationErrors.Last().ValidationErrors.Select(ve => ve.ErrorMessage)));
            }
        }

        private void BtCancelSupplierClick(object sender, RoutedEventArgs e)
        {
            if(supplier.ID_Supplier != 0)
            EfModel.Init().Entry(supplier).Reload();
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void ImageChangeClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                supplier.Photo = File.ReadAllBytes(openFile.FileName);
            }
        }
    }
}
