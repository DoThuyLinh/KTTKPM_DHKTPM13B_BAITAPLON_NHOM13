using ApiModel;
using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class UserLoginBLL
    {
        private DataAccess<UserLogin> _userLogin;
        private DataAccess<AccountCard> _accountCard;
        private DataAccess<Person> _person;
        private PersonBLL _personBLL;
        private AddHistoryBLL _addHistoryBLL;
        public UserLoginBLL()
        {
            _userLogin = new DataAccess<UserLogin>();
            _accountCard = new DataAccess<AccountCard>();
            _person = new DataAccess<Person>();
            _personBLL = new PersonBLL();
            _addHistoryBLL = new AddHistoryBLL();
        }
        public ApiUserLoginModel UserLogin(string acc, string pass, int atmID)
        {
            ApiUserLoginModel userloginmodel = new ApiUserLoginModel();
            userloginmodel.ApiPersonModel = new ApiPersonModel(null, null);
            

            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
            if (userLogin.CountPassword > 3)
            {
                UpdateAccountByCountPass(accountCard);
                userloginmodel.ErrorMessages = new List<string> (){ "false","tai khoan da khoa"};
                return userloginmodel;
            }
            else if (userLogin.Password.Equals(pass))
            {
                var person = _person.GetByCondition(x => x.PersonID == accountCard.PersonID);
                userloginmodel.ApiPersonModel = _personBLL.PersonInfo(accountCard);
                if (person is Staff)
                {
                    userloginmodel.Role = ApiUserLoginModel.AccountRole.Staff;
                }
                else if (person is Customer)
                {
                    userloginmodel.Role = ApiUserLoginModel.AccountRole.Customer;
                    userloginmodel.ApiPersonModel = new ApiPersonModel(acc, person.PersonName);
                }
                try
                {
                    _addHistoryBLL.AddATMHistory(atmID);
                    _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber);
                    return userloginmodel;
                }
                catch (Exception)
                {
                    return userloginmodel;
                }
            }
            else
            {
                UpdateAccountStatusByCountPass(userLogin);
            }
            return userloginmodel;
            
        }
        public bool UpdateAccountStatusByCountPass(UserLogin userLogin)
        {
            userLogin.CountPassword += 1;
            _userLogin.Update(userLogin);
            return true;
        }
        public bool UpdateAccountByCountPass(AccountCard account)
        {
            account.Status = AccountCard.AccountStatus.Pause;
            _accountCard.Update(account);
            return true;
        }
    }
}
