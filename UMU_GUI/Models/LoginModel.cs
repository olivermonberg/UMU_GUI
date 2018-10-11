using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UMU_GUI.Model
{
    public interface ILoginModel
    {
        bool Check_if_Email_and_password_is_in_database(string Email, string Password);
    }


    public class LoginModel : ILoginModel
    {
        private string email = "Androgles1994@gmail.com";
        private string password= "password";

        public bool Check_if_Email_and_password_is_in_database(string Email, string Password)
        {
            if (Email == email && password == Password)
            {
                return true;
            }
            else return false;
        }
    }
}