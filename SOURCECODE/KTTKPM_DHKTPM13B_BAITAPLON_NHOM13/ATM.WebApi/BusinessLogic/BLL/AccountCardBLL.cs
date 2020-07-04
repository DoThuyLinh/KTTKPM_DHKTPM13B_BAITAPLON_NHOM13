using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class AccountCardBLL
    {
        private readonly DataAccess<AccountCard> _accountCard;
        public AccountCardBLL()
        {
            _accountCard = new DataAccess<AccountCard>();
        }
        public bool UpdateBalanceAccount(AccountCard account, double transMoney)
        {
            try
            {
                var accountcard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(account.AccountNumber));
                if (accountcard.AvailableBalance > transMoney+100000)
                {
                    double balance = accountcard.AvailableBalance - transMoney;
                    if ((accountcard.AvailableBalance - transMoney) >= 100000)
                    {
                        accountcard.AvailableBalance = balance;
                        _accountCard.Update(accountcard);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool UpdateBalanceAccountPayment(AccountCard account, double paymentMoney)
        {
            try
            {
                var accountcard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(account.AccountNumber));
                if (accountcard != null)
                {
                    double balance = accountcard.AvailableBalance + paymentMoney;
                    accountcard.AvailableBalance = balance;
                    _accountCard.Update(accountcard);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
