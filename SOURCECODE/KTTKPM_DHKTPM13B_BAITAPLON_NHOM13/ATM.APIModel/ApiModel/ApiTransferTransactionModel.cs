using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiTransferTransactionModel
    {
        public double TransactionMoney { get; set; }
        public string PersonName { get; set; }
        public string BeneficiaryCard { get; set; }
        public double TransferFee { get; set; }
    }
}
