using System;
using System.Windows;
using System.Windows.Input;
using MvvmFoundation.Wpf;
using UMU_GUI.Model;
using UMU_GUI.ViewModels;
using UMU_GUI.DataAccessLayer;
using UMU_GUI.Views;

namespace UMU_GUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private UserAccount _currentUserAccount;
        private readonly ILoginModel _loginModel;

        public LoginViewModel()
        {
            _loginModel = new LoginModel(new DataAccessLayer.DataAccessLayer());
            _currentUserAccount = new UserAccount();
        }
        public LoginViewModel(ILoginModel loginModel, UserAccount userAccount)
        {
            _loginModel = loginModel;
            _currentUserAccount = userAccount;
        }

        ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand<object>(Login));
            }
        }

        public void Login(object parameter)
        {
            var values = (object[])parameter;

            _currentUserAccount.Email = values[0].ToString();
            _currentUserAccount.Password = values[1].ToString();

            if (_loginModel.Validate_Email_and_Password(_currentUserAccount.Email, _currentUserAccount.Password))
            {
                App.Current.MainWindow.DataContext = new CreateAccountView();
            }
            else
            {
                MessageBox.Show("The e-mail or password you entered is incorrect.\nPlease try again.");
            }

            //Console.WriteLine("Username : " + Email);
            //Console.WriteLine("Password : " + Password);

        }

        ICommand _createAccountBtnCommand;
        public ICommand CreateAccountBtnCommand
        {
            get
            {
                return _createAccountBtnCommand ?? (_createAccountBtnCommand = new RelayCommand(CreateAccountBtn));
            }
        }

        public void CreateAccountBtn()
        {
            App.Current.MainWindow.DataContext = new CreateAccountView();
        }

        ICommand _goToLoginScreenCommand;
        public ICommand GoToLoginScreenCommand
        {
            get
            {
                return _goToLoginScreenCommand ?? (_goToLoginScreenCommand = new RelayCommand(GoToLoginScreen));
            }
        }

        public void GoToLoginScreen()
        {
            App.Current.MainWindow.DataContext = new LoginView();
        }
    }
}
