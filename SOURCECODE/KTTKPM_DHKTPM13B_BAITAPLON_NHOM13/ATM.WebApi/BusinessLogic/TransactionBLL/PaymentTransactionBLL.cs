using ApiModel;
using BusinessLogic.BLL;
using DataAccess.EntityDAL;
using DataAccess.Migrations;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.TransactionBLL
{
    public class PaymentTransactionBLL
    {
        private DataAccess<UserLogin> _userLogin;
        private DataAccess<AccountCard> _accountCard;
        private DataAccess<ATMInfo> _atmInfo;
        private DataAccess<BankInfo> _bankInfo;

        private PersonBLL _personBLL;
        private AccountCardBLL _accountCardBLL;
        private AddHistoryBLL _addHistoryBLL;
        private AtmTransactionBLL _atmTransactionBLL;
        private ATMInfoBLL _atmInfoBLL;
        public PaymentTransactionBLL()
        {
            _userLogin = new DataAccess<UserLogin>();
            _accountCard = new DataAccess<AccountCard>();
            _atmInfo = new DataAccess<ATMInfo>();
            _bankInfo = new DataAccess<BankInfo>();
            _personBLL = new PersonBLL();
            _accountCardBLL = new AccountCardBLL();
            _addHistoryBLL = new AddHistoryBLL();
            _atmTransactionBLL = new AtmTransactionBLL();
            _atmInfoBLL = new ATMInfoBLL();
        }

        public ApiPaymentTransactionModel PaymentTransaction(string acc, double paymentMoney, int atmID)
        {
            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            if (userLogin != null)
            {
                AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
                ATMInfo atmInfo = _atmInfo.GetByCondition(x => x.ATMID == atmID);
                BankInfo bankInfo = _bankInfo.GetByCondition(x => x.BankID == accountCard.BankID);

                ApiPaymentTransactionModel payment = new ApiPaymentTransactionModel();
                payment.ApiPersonModel = _personBLL.PersonInfo(accountCard);
                payment.TransactionMoney = paymentMoney;
                if (atmInfo.BankID == bankInfo.BankID)
                {
                    payment.PaymentFee = accountCard.InternalFee;
                }
                else if (atmInfo.BankID != bankInfo.BankID)
                {
                    payment.PaymentFee = accountCard.ForeignFee;
                }
                try
                {
                    _accountCardBLL.UpdateBalanceAccountPayment(accountCard, paymentMoney - payment.PaymentFee);

                    _addHistoryBLL.AddATMHistory(atmID);
                    _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber);
                    _atmTransactionBLL.AddTransaction(accountCard.AccountNumber, paymentMoney, atmID);

                    _atmInfoBLL.UpdateAvailableBalancePaymentATM(atmID, paymentMoney);
                    payment.AvailableBalance = accountCard.AvailableBalance;
                    return payment;
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
