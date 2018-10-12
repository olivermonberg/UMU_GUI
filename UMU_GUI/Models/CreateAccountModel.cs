using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMU_GUI.DataAccessLayer;

namespace UMU_GUI.Models
{
    public interface ICreateAccountModel
    {
        bool Validate_Username(string username);
        void Create_Account(string Username, string Email, string Password);
    }
    public class CreateAccountModel : ICreateAccountModel
    {
        private IDataAccessLayer _dataAccessLayer;
        public CreateAccountModel(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public bool Validate_Username(string username)
        {
            if(!_dataAccessLayer.Check_In_Database_If_Username_Is_Already_In_Use(username))
                return true;

            return false;
        }

        public void Create_Account(string Username, string Email, string Password)
        {
            _dataAccessLayer.Create_Account_In_Database(Username, Email, Password);
        }
    }
}
