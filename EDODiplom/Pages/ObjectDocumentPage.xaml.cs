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

namespace EDODiplom.Pages
{
    /// <summary>
    /// Interaction logic for ObjectDocumentPage.xaml
    /// </summary>
    public partial class ObjectDocumentPage : Page
    {
        public ObjectDocumentPage()
        {
            InitializeComponent();
            UpdateData();
        }

        private void UpdateData()
        {
            IEnumerable<ObjectDocument> objectDocuments = EfModel.Init().ObjectDocuments.
                Where(o => o.ObjectName.Contains(TbSearch.Text));
            LvObjectDocument.ItemsSource = objectDocuments.ToList();
        }

        private void TbSearchChange(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtObjectDocumentAddCLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ObjectDocumentEditPage(new ObjectDocument()));
        }

        private void BtObjectDocumentEditClick(object sender, RoutedEventArgs e)
        {
            if (LvObjectDocument.SelectedItems.Count > 0)
            {
                ObjectDocument objectDocument = LvObjectDocument.SelectedItem as ObjectDocument;
                NavigationService.Navigate(new ObjectDocumentEditPage(objectDocument));
            }
        }

        private void BtObjectDocumentDelClick(object sender, RoutedEventArgs e)
        {
            if (LvObjectDocument.SelectedItems.Count > 0)
            {
                ObjectDocument objectDocument = LvObjectDocument.SelectedItem as ObjectDocument;
                if (MessageBox.Show("Вы точно хотите удалить документ " + objectDocument.ObjectName + "?", "Удалить документ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    EfModel.Init().ObjectDocuments.Remove(objectDocument);
                    EfModel.Init().SaveChanges();
                    UpdateData();
                }
            }
        }
    }
}
