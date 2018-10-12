using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMU_GUI.ViewModels;

namespace UMU_GUI.Views
{
    public interface INavigationService
    {
        void ShowCreateAccountView();
        void ShowLoginView();
        void ShowMainMenuView();
    }
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {

        }
        public void ShowCreateAccountView()
        {
            App.Current.MainWindow.DataContext = new CreateAccountView();
        }

        public void ShowLoginView()
        {
            App.Current.MainWindow.DataContext = new LoginView();
        }

        public void ShowMainMenuView()
        {
            //This is yet to be implemented
        }
    }
}
