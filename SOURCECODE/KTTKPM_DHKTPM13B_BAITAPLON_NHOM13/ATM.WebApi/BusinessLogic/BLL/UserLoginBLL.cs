using ApiModel;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserLoginBLL 
    {
        private readonly UserLoginDAL _userLoginDAL = new UserLoginDAL();
        public ApiUserLoginModel Login(string account, string pass, int atmId)
        {
            var model = _userLoginDAL.UserLogin(account, pass, atmId);
            if (model != null)
            {
                var userLoginModel = new ApiUserLoginModel()
                {
                    AccountNumber = model.AccountNumber,
                    PersonName = model.PersonName,
                    Role = model.Role
                };
                return userLoginModel;
            }
            else return null;
        }
    }
}
