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
            CbSort.Items.Add("Цена");
            CbSort.Items.Add("Количество");

            CbSort.SelectedIndex = 0;
        }
        //Метод обновления данных
        private void UpdateData()
        {
          IEnumerable<Material> materials = EfModel.Init().Materials
                .Where(m => m.Name.Contains(TbSearch.Text));
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

        }

        private void BtMaterialDelClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtMaterialEditClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
