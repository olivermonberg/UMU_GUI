using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMU_GUI.Model;

namespace UMU_GUI.DataAccessLayer
{
    public interface IDataAccessLayer
    {
        bool Check_if_Email_and_Password_is_in_database(string Email, string Password);
        bool Check_In_Database_If_Username_And_Email_Is_Already_In_Use(string Username,string email);
        void Create_Account_In_Database(string Username, string Email, string Password);
        bool Check_In_Database_If_Username_Is_Already_In_Use(string username);
    }
    public class DataAccessLayer : IDataAccessLayer
    {
        public bool Check_if_Email_and_Password_is_in_database(string Email, string Password)
        {
            //Do something
            return true;
        }

        public bool Check_In_Database_If_Username_And_Email_Is_Already_In_Use(string Username, string email)
        {
            //Do something
            return false;
        }

        public void Create_Account_In_Database(string Username, string Email, string Password)
        {
            //Do something
        }

        public bool Check_In_Database_If_Username_Is_Already_In_Use(string username)
        {
            //Do something
            return false;
        }
    }
}
