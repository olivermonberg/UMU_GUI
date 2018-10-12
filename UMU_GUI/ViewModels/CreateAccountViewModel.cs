using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MvvmFoundation.Wpf;
using UMU_GUI.Model;
using UMU_GUI.Models;
using UMU_GUI.Views;

namespace UMU_GUI.ViewModels
{
    public class CreateAccountViewModel : ViewModelBase
    {
        private UserAccount _currentUserAccount;
        private readonly ICreateAccountModel _createAccountModel;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;

        public CreateAccountViewModel()
        {
            _createAccountModel = new CreateAccountModel(new DataAccessLayer.DataAccessLayer());
            _currentUserAccount = new UserAccount();
            _navigationService = new NavigationService();
            _notificationService = new NotificationService();
        }
        public CreateAccountViewModel(ICreateAccountModel createAccountModel, INavigationService navigationService, 
            INotificationService notificationService, UserAccount userAccount)
        {
            _createAccountModel = createAccountModel;
            _currentUserAccount = userAccount;
            _navigationService = navigationService;
            _notificationService = notificationService;
        }

        ICommand _createAccountCommand;
        public ICommand CreateAccountCommand
        {
            get
            {
                return _createAccountCommand ?? (_createAccountCommand = new RelayCommand<object>(CreateAccount));
            }
        }

        public void CreateAccount(object parameter)
        {
            var values = (object[])parameter;

            string Username = values[0].ToString();
            string Email = values[1].ToString();
            string EmailConfirm = values[2].ToString();
            string Password = values[3].ToString();
            string PasswordRepeat = values[4].ToString();

            if (Check_If_Given_Emails_Differ_And_Format_Is_Valid(Email, EmailConfirm) &&
                Check_If_Given_Passwords_Differ_And_Format_Is_Valid(Password, PasswordRepeat))
            {
                if (_createAccountModel.Validate_Username(Username))
                {
                    _createAccountModel.Create_Account(Username, Email, Password);

                    _navigationService.ShowLoginView();

                    _notificationService.Show_Message_Account_Has_Been_Created();
                }
                else
                {
                    _notificationService.Show_Message_Username_Is_Already_Taken();
                }

            }
        }

        private bool CompareTwoStrings(string a, string b)
        {
            if (a == b)
                return true;

            return false;
        }

        private bool Check_If_Given_Emails_Differ_And_Format_Is_Valid(string Email, string EmailConfirm)
        {
            if (Email != EmailConfirm)
            {
                _notificationService.Show_Message_Emails_Does_Not_Match();
                
                return false;
            }
            if (!Email.Contains("@"))
            {
                _notificationService.Show_Message_Email_Format_Is_Not_Valid();
                return false;
            }

            return true;

        }

        private bool Check_If_Given_Passwords_Differ_And_Format_Is_Valid(string Password, string PasswordRepeat)
        {
            if (Password != PasswordRepeat)
            {
                _notificationService.Show_Message_Passwords_Does_Not_Match();
                return false;
            }
            if (Password.Length <= 8)
            {
                _notificationService.Show_Message_Password_Is_Too_Short();
                return false;
            }
            if (!Password.Any(char.IsUpper) || !Password.Any(char.IsDigit))
            {

                _notificationService.Show_Message_Password_Not_Containing_Uppercase_Or_Number();
                return false;
            }

            return true;
        }
    }
}
