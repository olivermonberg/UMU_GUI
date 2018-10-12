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
        public UserAccount _currentUserAccount;
        private readonly ILoginModel _loginModel;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;

        public LoginViewModel()
        {
            _loginModel = new LoginModel(new DataAccessLayer.DataAccessLayer());
            _currentUserAccount = new UserAccount();
            _navigationService = new NavigationService();
            _notificationService = new NotificationService();
        }
        public LoginViewModel(ILoginModel loginModel, INavigationService navigationService, 
            INotificationService notificationService, UserAccount userAccount)
        {
            _loginModel = loginModel;
            _currentUserAccount = userAccount;
            _navigationService = navigationService;
            _notificationService = notificationService;
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
                _navigationService.ShowMainWindowView(); //This is yet to be implemented
            }
            else
            {
                _notificationService.Show_Message_Email_Or_Password_Is_Incorrect();
            }
        }

        ICommand _createAccountBtnCommand;
        public ICommand CreateAccountBtnCommand
        {
            get
            {
                return _createAccountBtnCommand ?? (_createAccountBtnCommand = new RelayCommand(_navigationService.ShowCreateAccountView));
            }
        }

        ICommand _goToLoginScreenCommand;
        public ICommand GoToLoginScreenCommand
        {
            get
            {
                return _goToLoginScreenCommand ?? (_goToLoginScreenCommand = new RelayCommand(_navigationService.ShowLoginView));
            }
        }
    }
}
