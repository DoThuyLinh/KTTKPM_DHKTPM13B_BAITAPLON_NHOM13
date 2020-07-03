using DataAccess.EntityDAL;
using DataAccess.Migrations;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class AddHistoryBLL
    {
        private DataAccess<ATMHistory> _atmHistory;
        private DataAccess<AccountHistory> _accountHistory;
        public AddHistoryBLL()
        {
            _atmHistory = new DataAccess<ATMHistory>();
            _accountHistory = new DataAccess<AccountHistory>();
        }
        public bool AddATMHistory(int atmID)
        {
            ATMHistory history = new ATMHistory(DateTime.Now, atmID);
            try
            {
                _atmHistory.Add(history);
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
                _accountHistory.Add(history);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
