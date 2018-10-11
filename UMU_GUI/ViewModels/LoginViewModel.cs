using System;
using System.Windows;
using System.Windows.Input;
using MvvmFoundation.Wpf;
using UMU_GUI.Model;
using UMU_GUI.ViewModels;

namespace UMU_GUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private UserAccount CurrentUserAccount;
        private LoginModel _loginModel;
        public LoginViewModel()
        {
            CurrentUserAccount = new UserAccount();
            _loginModel = new LoginModel();
        }

        ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand<object>(Login, CanLogin));
            }
        }

        public void Login(object parameter)
        {
            var values = (object[])parameter;
            string Email = values[0].ToString();
            string Password = values[1].ToString();
            //var param = (Tuple<object, object>)parameter;


            if (_loginModel.Check_if_Email_and_password_is_in_database(Email, Password))
            {
                App.Current.MainWindow.DataContext = new CreateAccountViewModel();
            }
            else
            {
                MessageBox.Show("Password eller email er forkert");
            }

            Console.WriteLine("Username : " + Email);
            Console.WriteLine("Password : " + Password);

        }

        private bool CanLogin(object parameter)
        {
            //var values = (object[])parameter;
            //string Email = values[0].ToString();
            //string Password = values[1].ToString();
            //if (_loginModel.Check_if_Email_and_password_is_in_database(Email, Password))
            //{
            //    //Skift skærm
            //    return true;
            //}

            return true;
        }
    }
}
