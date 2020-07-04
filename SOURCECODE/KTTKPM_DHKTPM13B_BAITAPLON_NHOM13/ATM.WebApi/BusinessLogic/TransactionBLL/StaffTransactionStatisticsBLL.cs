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
    public class StaffTransactionStatisticsBLL
    {
        private readonly DataAccess<ATMHistory> _atmHistory;
        private readonly DataAccess<ATMTransaction> _atmTransaction;

        //private readonly DataAccess<UserLogin> _userLogin;
        //private readonly DataAccess<AccountCard> _accountCard;
        //private readonly DataAccess<ATMInfo> _atmInfo;
        //private readonly DataAccess<BankInfo> _bankInfo;

        //private readonly PersonBLL _personBLL;
        //private readonly AccountCardBLL _accountCardBLL;
        //private readonly AddHistoryBLL _addHistoryBLL;
        //private readonly AtmTransactionBLL _atmTransactionBLL;
        public StaffTransactionStatisticsBLL()
        {
            _atmHistory = new DataAccess<ATMHistory>();
            _atmTransaction = new DataAccess<ATMTransaction>();

            //_userLogin = new DataAccess<UserLogin>();
            //_accountCard = new DataAccess<AccountCard>();
            //_atmInfo = new DataAccess<ATMInfo>();
            //_bankInfo = new DataAccess<BankInfo>();
            //_personBLL = new PersonBLL();
            //_accountCardBLL = new AccountCardBLL();
            //_addHistoryBLL = new AddHistoryBLL();
            //_atmTransactionBLL = new AtmTransactionBLL();
        }

        public List<ApiStaffTransactionStatisticsModel> StaffTransactionStatistics(int atmID)
        {
            List<ApiStaffTransactionStatisticsModel> listStatistics = new List<ApiStaffTransactionStatisticsModel>();
            List<ATMHistory> atmHistories = _atmHistory.GetByWhere(x => x.ATMID == atmID).ToList();
            List<ATMTransaction> atmTransactions = _atmTransaction.GetByWhere(x => x.ATMID == atmID).ToList();
            List<DateTime> histories = new List<DateTime>();
            List<double> transactions = new List<double>();
            foreach (var item in atmHistories)
            {
                histories.Add(item.ATMHistoryTime);
            }
            foreach (var statistics in atmTransactions)
            {
                transactions.Add(statistics.TransactionMoney);
                
            }
            return listStatistics;
        }
    }
}
