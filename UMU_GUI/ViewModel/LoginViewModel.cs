using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmFoundation.Wpf;

namespace UMU_GUI.ViewModel
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
                return _loginCommand ?? (_loginCommand = new RelayCommand(Login, CanLogin()));
            }
        }

        public void Login()
        {

        }

        public bool CanLogin(string email, string password)
        {
            
        }
    }
}
