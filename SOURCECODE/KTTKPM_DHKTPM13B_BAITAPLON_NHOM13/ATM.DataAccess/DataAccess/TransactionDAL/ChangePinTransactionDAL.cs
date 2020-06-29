using ApiModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.TransactionDAL
{
    public class ChangePinTransactionDAL : DataContextBLO
    {
        public ApiChangePinTransactionModel ChangePinTransaction(string acc, string oldPass, string newPass)
        {
            var person = new Person();
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault(x => x.AccountNumber.Equals(acc));
            if (userLogin != null)
            {
                if (_dbContext.UserLogins.FirstOrDefault(x => x.Password.Equals(oldPass)) != null)
                {
                    var changePin = new ApiChangePinTransactionModel();
                    bool checkUpdateUserPassword = _userLoginDAL.UpdateUserPassword(userLogin.AccountNumber, newPass);
                    if (checkUpdateUserPassword == true)
                    {
                        _addHistoryDAL.AddAccountHistory(acc);
                        changePin.Message = "Thay đổi mật khẩu thành công";
                        return changePin;
                    }
                }
            }
            return null;
        }
    }
}
