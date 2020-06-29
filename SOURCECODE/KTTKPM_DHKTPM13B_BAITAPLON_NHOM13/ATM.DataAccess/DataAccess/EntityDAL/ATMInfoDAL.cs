using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityDAL
{
    public class ATMInfoDAL:DataContextBLO
    {
        public bool UpdateAvailableBalanceWithdrawlATM(int atmID,double transactionMoney)
        {
            ATMInfo info = _dbContext.ATMInfos.FirstOrDefault(x => x.ATMID == atmID);
            try
            {
                if (info != null)
                {
                    double balance = info.ATMBalance - transactionMoney;
                    info.ATMBalance = balance;
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool UpdateAvailableBalancePaymentATM(int atmID, double transactionMoney)
        {
            ATMInfo info = _dbContext.ATMInfos.FirstOrDefault(x => x.ATMID == atmID);
            try
            {
                if (info != null)
                {
                    double balance = info.ATMBalance + transactionMoney;
                    info.ATMBalance = balance;
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
