using ApiModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TransferTransactionDAL:DataContextBLO
    {
        
        public ApiTransferTransactionModel TransferTransaction(string acc, string beneficiary, double transMoney, int atmID)
        {
            var person = new Person();
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault(x => x.AccountNumber.Equals(acc));
            if (userLogin != null)
            {
                AccountCard accountCard = _dbContext.AccountCards.FirstOrDefault(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                ATMInfo atmInfo = _dbContext.ATMInfos.FirstOrDefault(x => x.ATMID == atmID);
                BankInfo bankInfo = _dbContext.BankInfos.FirstOrDefault(x => x.BankID == atmInfo.BankID);
                AccountCard benefic = _dbContext.AccountCards.FirstOrDefault(x => x.AccountNumber == beneficiary);
                if (accountCard != null)
                {
                    person = _personDAL.GetPerson(accountCard.PersonID);
                }
                var transfer = new ApiTransferTransactionModel();
                if (accountCard.BankID == bankInfo.BankID)
                {
                    transfer.PersonName = person.PersonName;
                    transfer.TransactionMoney = transMoney;
                    transfer.BeneficiaryCard = beneficiary;
                    transfer.TransferFee = accountCard.InternalFee;
                }
                else if (accountCard.BankID != bankInfo.BankID)
                {
                    transfer.PersonName = person.PersonName;
                    transfer.TransactionMoney = transMoney;
                    transfer.BeneficiaryCard = beneficiary;
                    transfer.TransferFee = accountCard.ForeignFee;
                }
                try
                {
                    if(benefic != null)
                    {
                        _addHistoryDAL.AddATMHistory(atmID);
                        _addHistoryDAL.AddAccountHistory(accountCard.AccountNumber);
                        _accountCardDAL.UpdateBalanceAccount(accountCard, transMoney + transfer.TransferFee);
                        _atmTransactionDAL.AddTransferTransaction(accountCard.AccountNumber, beneficiary, transMoney, atmID);
                        return transfer;
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
