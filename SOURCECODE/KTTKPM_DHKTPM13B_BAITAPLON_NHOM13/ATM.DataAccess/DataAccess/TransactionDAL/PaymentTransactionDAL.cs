using ApiModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PaymentTransactionDAL:DataContextBLO
    {
        public ApiPaymentTransactionModel PaymentTransaction(string acc, double paymentMoney, int atmID)
        {
            var person = new Person();
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault(x => x.AccountNumber.Equals(acc));
            if (userLogin != null)
            {
                AccountCard accountCard = _dbContext.AccountCards.FirstOrDefault(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                ATMInfo atmInfo = _dbContext.ATMInfos.FirstOrDefault(x => x.ATMID == atmID);
                BankInfo bankInfo = _dbContext.BankInfos.FirstOrDefault(x => x.BankID == atmInfo.BankID);

                if (accountCard != null)
                {
                    person = _personDAL.GetPerson(accountCard.PersonID);
                }
                var payment = new ApiPaymentTransactionModel();
                if (accountCard.BankID == bankInfo.BankID)
                {
                    payment.PersonName = person.PersonName;
                    payment.TransactionMoney = paymentMoney;
                    payment.PaymentFee = accountCard.InternalFee;
                }
                else if (accountCard.BankID != bankInfo.BankID)
                {
                    payment.PersonName = person.PersonName;
                    payment.TransactionMoney = paymentMoney;
                    payment.PaymentFee = accountCard.ForeignFee;
                }
                try
                {
                    if (payment != null)
                    {
                        if(_accountCardDAL.UpdateBalanceAccountPayment(accountCard, paymentMoney - payment.PaymentFee) == true)
                        {
                            _addHistoryDAL.AddATMHistory(atmID);
                            _addHistoryDAL.AddAccountHistory(accountCard.AccountNumber);
                            _atmInfoDAL.UpdateAvailableBalancePaymentATM(atmID, paymentMoney);
                            payment.AvailableBalance = accountCard.AvailableBalance;
                            _atmTransactionDAL.AddTransaction(accountCard.AccountNumber, paymentMoney, atmID);
                        }
                        return payment;
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
