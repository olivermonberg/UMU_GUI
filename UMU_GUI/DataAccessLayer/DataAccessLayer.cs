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
    }
    public class DataAccessLayer : IDataAccessLayer
    {
        public bool Check_if_Email_and_Password_is_in_database(string Email, string Password)
        {
            return true;
        }
    }
}
