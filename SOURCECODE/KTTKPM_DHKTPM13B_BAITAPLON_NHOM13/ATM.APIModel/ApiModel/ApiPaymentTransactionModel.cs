using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiPaymentTransactionModel: ApiJsonResult
    {
        public double TransactionMoney { get; set; }
        public string PersonName { get; set; }
        public double PaymentFee { get; set; }
    }
}
