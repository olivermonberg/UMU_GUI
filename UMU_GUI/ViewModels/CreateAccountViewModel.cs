using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MvvmFoundation.Wpf;
using UMU_GUI.Views;

namespace UMU_GUI.ViewModels
{
    public class CreateAccountViewModel : ViewModelBase
    {
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
                //To be continued Androgles
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
                MessageBox.Show("E-mail differs.");
                return false;
            }
            if (!Email.Contains("@"))
            {
                MessageBox.Show("E-mail format is invalid.");
                return false;
            }

            return true;

        }

        private bool Check_If_Given_Passwords_Differ_And_Format_Is_Valid(string Password, string PasswordRepeat)
        {
            if (Password != PasswordRepeat)
            {
                MessageBox.Show("Passwords differs.");
                return false;
            }
            if (Password.Length <= 8)
            {
                MessageBox.Show("Password is too short, must be at least 8 characters.");
                return false;
            }
            if (!Password.Any(char.IsUpper) || !Password.Any(char.IsDigit))
            {
                MessageBox.Show("Password must contain at least one uppercase letter and one number.");
                return false;
            }

            return true;
        }
    }
}
