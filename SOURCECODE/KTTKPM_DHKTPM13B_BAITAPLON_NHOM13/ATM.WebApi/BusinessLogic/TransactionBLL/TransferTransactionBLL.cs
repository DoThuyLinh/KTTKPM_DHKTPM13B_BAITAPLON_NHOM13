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
    public class TransferTransactionBLL
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
        public TransferTransactionBLL()
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
        public ApiTransferTransactionModel TransferTransaction(string acc, string beneficiary, double transMoney, int atmID)
        {
            UserLogin userLogin = _userLogin.GetByCondition(x => x.AccountNumber.Equals(acc));
            AccountCard accountCard = _accountCard.GetByCondition(x => x.AccountNumber.Equals(userLogin.AccountNumber));
            ATMInfo atmInfo = _atmInfo.GetByCondition(x => x.ATMID == atmID);
            BankInfo bankInfo = _bankInfo.GetByCondition(x => x.BankID == accountCard.BankID);
            AccountCard benefic = _accountCard.GetByCondition(x => x.AccountNumber == beneficiary);

            var transfer = new ApiTransferTransactionModel();
            if (benefic != null)
            {
                transfer.ApiPersonModelTransfer = _personBLL.PersonInfo(accountCard);
                transfer.ApiPersonModelReceiver = _personBLL.PersonInfo(benefic);
                transfer.TransactionMoney = transMoney;
                if (benefic.BankID == bankInfo.BankID)
                {
                    transfer.TransferFee = accountCard.InternalFee;
                }
                else if (benefic.BankID != bankInfo.BankID)
                {
                    transfer.TransferFee = accountCard.ForeignFee;
                }

                try
                {
                    _accountCardBLL.UpdateBalanceAccount(accountCard, transMoney + transfer.TransferFee);
                    _accountCardBLL.UpdateBalanceAccountPayment(benefic, transMoney);

                    _addHistoryBLL.AddATMHistory(atmID);
                    _addHistoryBLL.AddAccountHistory(accountCard.AccountNumber);
                    _atmTransactionBLL.AddTransferTransaction(accountCard.AccountNumber, beneficiary, transMoney, atmID);

                    transfer.AvailableBalance = accountCard.AvailableBalance;
                    return transfer;
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
