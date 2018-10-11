using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UMU_GUI.DataAccessLayer;

namespace UMU_GUI.Model
{
    public interface ILoginModel
    {
        bool Validate_Email_and_Password(string Email, string Password);
    }


    public class LoginModel : ILoginModel
    {
        private IDataAccessLayer _dataAccessLayer;
        public LoginModel(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public bool Validate_Email_and_Password(string Email, string Password)
        {
            if (_dataAccessLayer.Check_if_Email_and_Password_is_in_database(Email, Password))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}