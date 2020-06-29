using ApiModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class WithdrawlTransactionDAL:DataContextBLO
    {
        public WithdrawlTransactionDAL()
        {
        }
        
        public ApiWithdrawlTransactionModel WithdrawlTransaction (string acc, double transMoney,  int atmID)
        {
            var person = new Person();
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault(x => x.AccountNumber.Equals(acc));
            if(userLogin != null)
            {
                AccountCard accountCard = _dbContext.AccountCards.FirstOrDefault(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                ATMInfo atmInfo = _dbContext.ATMInfos.FirstOrDefault(x => x.ATMID == atmID);
                BankInfo bankInfo = _dbContext.BankInfos.FirstOrDefault(x => x.BankID == atmInfo.BankID);

                if (accountCard != null)
                {
                    person = _personDAL.GetPerson(accountCard.PersonID);
                }
                var withdrawl = new ApiWithdrawlTransactionModel();
                if (accountCard.BankID == bankInfo.BankID)
                {
                    withdrawl.PersonName = person.PersonName;
                    withdrawl.TransactionMoney = transMoney;
                    withdrawl.WithdrawlFee = accountCard.InternalFee;
                }
                else if(accountCard.BankID != bankInfo.BankID)
                {
                    withdrawl.PersonName = person.PersonName;
                    withdrawl.TransactionMoney = transMoney;
                    withdrawl.WithdrawlFee = accountCard.ForeignFee;
                }
                try
                {
                    if(withdrawl != null)
                    {
                        if(_accountCardDAL.UpdateBalanceAccount(accountCard, transMoney + withdrawl.WithdrawlFee) == true)
                        {
                            _addHistoryDAL.AddATMHistory(atmID);
                            _addHistoryDAL.AddAccountHistory(accountCard.AccountNumber);
                            _atmInfoDAL.UpdateAvailableBalanceWithdrawlATM(atmID, transMoney);
                            _atmTransactionDAL.AddTransaction(accountCard.AccountNumber, transMoney, atmID);
                            withdrawl.AvailableBalance = accountCard.AvailableBalance;
                            return withdrawl;
                        }
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
