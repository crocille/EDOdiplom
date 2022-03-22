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
    /// Interaction logic for MaterialEditPage.xaml
    /// </summary>
    public partial class MaterialEditPage : Page
    {
        Material material;
        Materials_has_Suppliers materials_Has_Suppliers = new Materials_has_Suppliers();
        public MaterialEditPage(Material material)
        {
            this.material = material;
            InitializeComponent();

            CbName.ItemsSource = EfModel.Init().Suppliers.ToList();
            DataContext = material;
            SupplySelect.DataContext = materials_Has_Suppliers;

        }
        private void UpdateData()
        {
            IEnumerable<Material> materials = EfModel.Init().Materials;
            LvMaterialAdd.ItemsSource = materials.ToList();
        }
        private void ImageChangeClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                material.ImageMaterial = File.ReadAllBytes(openFile.FileName);
            }
        }

        private void BtSaveMaterialClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (material.ID_Material == 0)
                    EfModel.Init().Materials.Add(material);
                EfModel.Init().SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(String.Join(", ", ex.EntityValidationErrors.Last().ValidationErrors.Select(ve => ve.ErrorMessage)));
            }
        }

        private void NameChange(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtAddClick(object sender, RoutedEventArgs e)
        {
            material.Materials_has_Suppliers.Add(
                new Materials_has_Suppliers { 
                    Supplier = materials_Has_Suppliers.Supplier,
                    Material_Price = materials_Has_Suppliers.Material_Price 
                }
            );
            LvMaterialAdd.Items.Refresh();
        }

        private void BtRemClick(object sender, RoutedEventArgs e)
        {
            if (LvMaterialAdd.Items.Count > 0)
            {
                material.Materials_has_Suppliers.Remove(LvMaterialAdd.SelectedItem as Materials_has_Suppliers);
            }
            LvMaterialAdd.Items.Refresh();

        }
    }
}
