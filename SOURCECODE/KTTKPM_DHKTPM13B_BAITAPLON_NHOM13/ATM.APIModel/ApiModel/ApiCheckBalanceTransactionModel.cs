using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiCheckBalanceTransactionModel
    {
        public string AccountNumber { get; set; }
        public string PersonName { get; set; }
        public double AvailableBalance { get; set; }
    }
}
