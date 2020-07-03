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
            var person = new Person();
            var accountCard = new AccountCard();
            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));

            if (userLogin.CountPassword > 3)
            {
                UpdateAccountByCountPass(accountCard);
                return null;
            }
            else if (userLogin.Password.Equals(pass))
            {
                accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                person = _person.GetByCondition(x => x.PersonID == accountCard.PersonID);
            }
            else
            {
                userLogin.CountPassword += 1;
            }

            ApiUserLoginModel userloginmodel = new ApiUserLoginModel();

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
                return null;
            }
        }

        public bool UpdateAccountByCountPass(AccountCard account)
        {
            account.Status = AccountCard.AccountStatus.Pause;
            _accountCard.Update(account);
            return true;
        }
    }
}
