using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountCardDAL : DataContextBLO
    {
        public bool UpdateBalanceAccount(AccountCard account, double transMoney)
        {
            try
            {
                var accountcard = _dbContext.AccountCards.FirstOrDefault(x => x.AccountNumber.Equals(account.AccountNumber));
                if (accountcard != null)
                {
                    double balance = accountcard.AvailableBalance - transMoney;
                    if ((accountcard.AvailableBalance - transMoney) >= 100000)
                    {
                        accountcard.AvailableBalance = balance;
                        _dbContext.SaveChanges();
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

        public bool UpdateBalanceAccountPayment(AccountCard account, double transMoney)
        {
            try
            {
                var accountcard = _dbContext.AccountCards.FirstOrDefault(x => x.AccountNumber.Equals(account.AccountNumber));
                if (accountcard != null)
                {
                    double balance = accountcard.AvailableBalance + transMoney;
                    accountcard.AvailableBalance = balance;
                    _dbContext.SaveChanges();
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
