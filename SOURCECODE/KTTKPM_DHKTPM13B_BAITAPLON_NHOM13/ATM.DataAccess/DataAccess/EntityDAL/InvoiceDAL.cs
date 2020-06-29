using ApiModel;
using DataAccess.TransactionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityDAL
{
    public class InvoiceDAL:DataContextBLO
    {
        private readonly CheckBalanceTransactionDAL _checkBalance;
        private readonly TransferTransactionDAL _transfer;
        private readonly WithdrawlTransactionDAL _withdrawl;
        private readonly PaymentTransactionDAL _payment;
        public InvoiceDAL()
        {
            _checkBalance = new CheckBalanceTransactionDAL();
            _transfer = new TransferTransactionDAL();
            _withdrawl = new WithdrawlTransactionDAL();
            _payment = new PaymentTransactionDAL();
        }
        public ApiCheckBalanceTransactionModel InvoiceCheckBalanceTransaction(string acc)
        {
            return _checkBalance.ApiCheckBalanceTransaction(acc);
        }
        public ApiTransferTransactionModel InvoiceTransferTransaction(string acc, string beneficiary, double transMoney, int atmID)
        {
            return _transfer.TransferTransaction(acc, beneficiary, transMoney, atmID);
        }
        public ApiWithdrawlTransactionModel InvoiceWithdrawlTransaction(string acc, double transMoney, int atmID)
        {
            return _withdrawl.WithdrawlTransaction(acc, transMoney, atmID);
        }
        public ApiPaymentTransactionModel InvoicePaymentTransaction(string acc, double paymentMoney, int atmID)
        {
            return _payment.PaymentTransaction(acc, paymentMoney, atmID);
        }
    }
}
