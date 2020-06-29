using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AtmTransactionDAL:DataContextBLO
    {
        public bool AddTransaction(string acc, double transMoney, int atmID)
        {
            ATMTransaction transaction = new ATMTransaction(transMoney, DateTime.Now, ATMTransaction.TransactionTypes.Withdrawl, acc, acc, atmID);
            try
            {
                _dbContext.ATMTransactions.Add(transaction);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddTransferTransaction(string acc, string beneficiary, double transMoney, int atmID)
        {
            ATMTransaction transaction = new ATMTransaction(transMoney, DateTime.Now, ATMTransaction.TransactionTypes.Transfer, beneficiary, acc, atmID);
            try
            {
                _dbContext.ATMTransactions.Add(transaction);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
