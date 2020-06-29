using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiWithdrawlTransactionModel : ApiJsonResult
    {
        public double TransactionMoney { get; set; }
        public string PersonName { get; set; }
        public double WithdrawlFee { get; set; }
    }
}
