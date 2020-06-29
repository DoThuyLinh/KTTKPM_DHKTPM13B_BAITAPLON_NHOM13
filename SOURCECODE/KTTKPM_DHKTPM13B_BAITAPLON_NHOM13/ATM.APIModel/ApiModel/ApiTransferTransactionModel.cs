using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiTransferTransactionModel
    {
        public string PersonNameTransfer { get; set; }
        public string PersonNameReceiver { get; set; }
        public double TransactionMoney { get; set; }
        public double AvailableBalance { get; set; }
        public string BeneficiaryCard { get; set; }
        public double TransferFee { get; set; }
    }
}
