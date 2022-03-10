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
    /// Interaction logic for AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public string password = "";
        public AutorizationPage()
        {
            InitializeComponent();
            TbLogin.DataContext = this;
            TbPass.DataContext = this;
        }

        private void BtEntryClick(object sender, RoutedEventArgs e)
        {
            User user = EfModel.Init().Users.FirstOrDefault(u => u.Login == TbLogin.Text && u.Password == PbPass.Password);
            if (user != null)
            {
                if (user.Role == 2)
                {
                    NavigationService.Navigate(new MenuPage());
                }
                else
                {

                }
            }
            else
                MessageBox.Show("Неверный логин или пароль!");
        }

        private void CBPassCheck(object sender, RoutedEventArgs e)
        {
            TbPass.Text = PbPass.Password;
        }

        private void CBPassUncheck(object sender, RoutedEventArgs e)
        {
            PbPass.Password = TbPass.Text;
        }
    }
}
