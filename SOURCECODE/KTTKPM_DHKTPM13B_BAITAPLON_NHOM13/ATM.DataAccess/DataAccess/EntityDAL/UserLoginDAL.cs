using ApiModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserLoginDAL : DataContextBLO
    {
        public UserLoginDAL()
        {
        }
        public ApiUserLoginModel UserLogin(string acc, string pass, int atmID)
        {
            var account = new AccountCard();
            var person = new Person();
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault(x => x.AccountNumber.Equals(acc));
            if (userLogin != null)
            {
                if (userLogin.CountPassword == 3)
                {
                    return null;
                }
                else if (userLogin.Password.Equals(pass))
                {
                    account = _dbContext.AccountCards.FirstOrDefault(x => x.AccountNumber == userLogin.AccountNumber);
                    if (account != null)
                    {
                        person = _personDAL.GetPerson(account.PersonID);
                    }
                }
                else
                {
                    userLogin.CountPassword += 1;
                }
            }
            var userloginmodel = new ApiUserLoginModel();
            if(person != null)
            {
                if (person is Staff)
                {
                    userloginmodel.AccountNumber = account.AccountNumber;
                    userloginmodel.PersonName = person.PersonName;
                    userloginmodel.Role = ApiUserLoginModel.AccountRole.Staff;
                }
                else if (person is Customer)
                {
                    userloginmodel.AccountNumber = account.AccountNumber;
                    userloginmodel.PersonName = person.PersonName;
                    userloginmodel.Role = ApiUserLoginModel.AccountRole.Customer;
                }

                try
                {
                    _addHistoryDAL.AddATMHistory(atmID);
                    _addHistoryDAL.AddAccountHistory(account.AccountNumber);
                    return userloginmodel;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
        public bool UpdateUserPassword(string acc,string newPass)
        {
            try
            {
                UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault(x=>x.AccountNumber.Equals(acc));
                userLogin.Password = newPass;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
