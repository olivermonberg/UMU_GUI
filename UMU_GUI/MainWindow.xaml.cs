using System.Windows;
using UMU_GUI.Model;
using UMU_GUI.ViewModels;

namespace UMU_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new LoginViewModel();
            InitializeComponent();
            
        }


    }
}
