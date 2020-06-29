using ApiModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.TransactionDAL
{
    public class CheckBalanceTransactionDAL:DataContextBLO
    {
        public ApiCheckBalanceTransactionModel ApiCheckBalanceTransaction(string acc)
        {
            var person = new Person();
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault(x => x.AccountNumber.Equals(acc));
            if (userLogin != null)
            {
                AccountCard accountCard = _dbContext.AccountCards.FirstOrDefault(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                if (accountCard != null)
                {
                    person = _personDAL.GetPerson(accountCard.PersonID);
                }
                var checkBalance = new ApiCheckBalanceTransactionModel();
                if(person != null)
                {
                    checkBalance.AccountNumber = accountCard.AccountNumber;
                    checkBalance.PersonName = person.PersonName;
                    checkBalance.AvailableBalance = accountCard.AvailableBalance;
                }
                try
                {
                    if (checkBalance != null)
                    {
                        return checkBalance;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
    }
}
