using System.Windows;
using System.Windows.Controls;
using UMU_GUI.ViewModels;

namespace UMU_GUI.Views
{
    /// <summary>
    /// Interaction logic for LoginViewModel.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
           
            App.Current.MainWindow.DataContext = new CreateAccountView();
        }

        private void Password_btnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
