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
            return true;
        }
    }
}
