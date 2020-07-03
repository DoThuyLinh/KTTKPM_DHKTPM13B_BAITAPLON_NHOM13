using ApiModel;
using BusinessLogic.BLL;
using DataAccess.EntityDAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.TransactionBLL
{
    public class WithdrawlTransactionBLL
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
        public WithdrawlTransactionBLL()
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
        public ApiWithdrawlTransactionModel WithdrawlTransaction(string acc, double transMoney, int atmID)
        {
            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
            ATMInfo atmInfo = _atmInfo.GetByCondition(x => x.ATMID == atmID);
            BankInfo bankInfo = _bankInfo.GetByCondition(x => x.BankID == accountCard.BankID);

            var withdrawl = new ApiWithdrawlTransactionModel();
            withdrawl.ApiPersonModel = _personBLL.PersonInfo(accountCard);
            withdrawl.TransactionMoney = transMoney;

            if (atmInfo.BankID == bankInfo.BankID)
            {
                withdrawl.WithdrawlFee = accountCard.InternalFee;
            }
            else if (atmInfo.BankID != bankInfo.BankID)
            {
                withdrawl.WithdrawlFee = accountCard.ForeignFee;
            }
            try
            {
                _accountCardBLL.UpdateBalanceAccount(accountCard, transMoney + withdrawl.WithdrawlFee);
                _atmInfoBLL.UpdateAvailableBalanceWithdrawlATM(atmID, transMoney);

                _addHistoryBLL.AddATMHistory(atmID);
                _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber);
                _atmTransactionBLL.AddTransaction(accountCard.AccountNumber, transMoney, atmID);

                withdrawl.AvailableBalance = accountCard.AvailableBalance;
                return withdrawl;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
