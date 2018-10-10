using System.Windows;
using System.Windows.Controls;

namespace UMU_GUI.Views
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccountView : UserControl
    {
        public CreateAccountView()
        {
            InitializeComponent();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.DataContext = new LoginView();
        }
    }
}
