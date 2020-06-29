using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AddHistoryDAL:DataContextBLO
    {
        public AddHistoryDAL()
        {
        }
        public bool AddATMHistory(int atmID)
        {
            ATMHistory history = new ATMHistory(DateTime.Now, atmID);
            try
            {
                _dbContext.ATMHistories.Add(history);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddAccountHistory(string acc)
        {
            AccountHistory history = new AccountHistory(DateTime.Now, acc);
            try
            {
                _dbContext.AccountHistories.Add(history);
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
