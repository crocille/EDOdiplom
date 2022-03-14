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
using EDODiplom.Pages.PagesEdit;

namespace EDODiplom.Pages
{
    /// <summary>
    /// Interaction logic for MaterialListPage.xaml
    /// </summary>
    public partial class MaterialListPage : Page
    {
        public MaterialListPage()
        {
            InitializeComponent();
            UpdateData();
            List<MaterialType> materialTypes = EfModel.Init().MaterialTypes.ToList();
            materialTypes.Insert(0, new MaterialType { MaterialTypeName = "Все типы" });
            CbFilter.ItemsSource = materialTypes;
            CbFilter.SelectedIndex = 0;

            CbSort.Items.Add("Наименование");
            CbSort.Items.Add("▲ Цена");
            CbSort.Items.Add("▼ Цена");
            CbSort.Items.Add("▲ Количество");
            CbSort.Items.Add("▼ Количество");

            CbSort.SelectedIndex = 0;
        }
        //Метод обновления данных
        private void UpdateData()
        {
            IEnumerable<Material> materials = EfModel.Init().Materials
                .Include(m => m.MaterialTypes).Include(m => m.Materials_has_Suppliers)
                .Where(m => m.Name.Contains(TbSearch.Text));

            if (CbFilter.SelectedIndex > 0)
                materials = materials.Where(m => m.MaterialTypes.Select(mt=>mt.ID_MaterialType).Contains(
                 (CbFilter.SelectedItem as MaterialType).ID_MaterialType));

            switch (CbSort.SelectedIndex)
            {
                case 0:
                    materials = materials.OrderBy(m => m.Name);
                    break;
                case 1:
                    materials = materials.OrderByDescending(m => m.Materials_has_Suppliers.Min(ms=>ms.Material_Price));
                    break;
                case 2:
                    materials = materials.OrderBy(m => m.Materials_has_Suppliers.Max(ms => ms.Material_Price));
                    break;
                case 3:
                    materials = materials.OrderByDescending(m => m.Materials_has_Supply.Min(ms=>ms.Material_Count));
                    break;
                case 4:
                    materials = materials.OrderBy(m => m.Materials_has_Supply.Max(ms => ms.Material_Count));
                    break;
            }

            LvMaterials.ItemsSource = materials.ToList();
        }

        private void TbSearchChange(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void SortChange(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FilterChange(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtMaterialAddCLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaterialEditPage());
        }

        private void BtMaterialDelClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtMaterialEditClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
