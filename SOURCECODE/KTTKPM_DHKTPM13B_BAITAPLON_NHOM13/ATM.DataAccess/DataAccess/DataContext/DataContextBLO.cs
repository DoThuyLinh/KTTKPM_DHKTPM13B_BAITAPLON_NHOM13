using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContextBLO 
    {
        protected AtmDataContext _dbContext;
        protected AddHistoryDAL _addHistoryDAL;
        protected PersonDAL _personDAL;
        protected AccountCardDAL _accountCardDAL;
        protected AtmTransactionDAL _atmTransactionDAL;
        protected UserLoginDAL _userLoginDAL;
        protected ATMInfoDAL _atmInfoDAL;
        public DataContextBLO()
        {
            _dbContext = new AtmDataContext();
            _addHistoryDAL = new AddHistoryDAL();
            _personDAL = new PersonDAL();
            _accountCardDAL = new AccountCardDAL();
            _atmTransactionDAL = new AtmTransactionDAL();
            _userLoginDAL = new UserLoginDAL();
            _atmInfoDAL = new ATMInfoDAL();
        }
    }
}
