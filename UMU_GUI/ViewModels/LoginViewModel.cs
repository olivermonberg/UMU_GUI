using System.Windows.Input;
using MvvmFoundation.Wpf;
using UMU_GUI.ViewModels;

namespace UMU_GUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {

        }

        ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(Login));
            }
        }

        public void Login()
        {
            
        }

        //public bool CanLogin(string email, string password)
        //{
        //    
        //}
    }
}
