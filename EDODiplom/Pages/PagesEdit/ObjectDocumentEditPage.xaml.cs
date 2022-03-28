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

namespace EDODiplom.Pages.PagesEdit
{
    /// <summary>
    /// Interaction logic for ObjectDocumentEditPage.xaml
    /// </summary>
    public partial class ObjectDocumentEditPage : Page
    {
        ObjectDocument objectDocument;
        public ObjectDocumentEditPage(ObjectDocument objectDocument)
        {
            this.objectDocument = objectDocument;
            InitializeComponent();
            DataContext = objectDocument;
        }
    }
}
