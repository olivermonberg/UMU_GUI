using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UMU_GUI.Views
{
    public interface INotificationService
    {
        void Show_Message_Email_Or_Password_Is_Incorrect();
        void Show_Message_Username_Is_Already_Taken();
        void Show_Message_Emails_Does_Not_Match();
        void Show_Message_Email_Format_Is_Not_Valid();
        void Show_Message_Passwords_Does_Not_Match();
        void Show_Message_Password_Is_Too_Short();
        void Show_Message_Password_Not_Containing_Uppercase_Or_Number();
        void Show_Message_Account_Has_Been_Created();
    }
    public class NotificationService : INotificationService
    {
        public NotificationService()
        {
        }

        public void Show_Message_Email_Or_Password_Is_Incorrect()
        {
            MessageBox.Show("The e-mail or password you entered is incorrect.\nPlease try again.");
        }

        public void Show_Message_Username_Is_Already_Taken()
        {
            MessageBox.Show("Username is already taken, please try again.");
        }

        public void Show_Message_Emails_Does_Not_Match()
        {
            MessageBox.Show("E-mails does not match.");
        }

        public void Show_Message_Email_Format_Is_Not_Valid()
        {
            MessageBox.Show("E-mail format is invalid.");
        }

        public void Show_Message_Passwords_Does_Not_Match()
        {
            MessageBox.Show("Passwords does not match.");
        }

        public void Show_Message_Password_Is_Too_Short()
        {
            MessageBox.Show("Password is too short, must be at least 8 characters.");
        }

        public void Show_Message_Password_Not_Containing_Uppercase_Or_Number()
        {
            MessageBox.Show("Password must contain at least one uppercase letter and one number.");
        }
        

        public void Show_Message_Account_Has_Been_Created()
        {
            MessageBox.Show("Your account has been successfully created, please log in.");
        }
    }
}
