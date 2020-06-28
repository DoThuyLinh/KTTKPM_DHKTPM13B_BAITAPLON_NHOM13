using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ATMTransaction
    {
        public enum TransactionTypes
        {
            Withdrawl, Transfer, Payment, CheckBalance, ChangePin
        }
        [Key]
        public int TransactionID { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Property: Code Error: The TransactionMoney field is required.")]
        public double TransactionMoney { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The TransactionTime field is required.")]
        public DateTime TransactionTime { get; set; }

        [Required(ErrorMessage = "Property: Code Error: The TransactionType field is required.")]
        public TransactionTypes? TransactionType { get; set; }

        [RegularExpression("^\\d{13}$", ErrorMessage = "Property: Code Error: The BeneficiaryCard field is required.")]
        public string BeneficiaryCard { get; set; }

        [Required]
        public string AccountNumber { get; set; }
        public UserLogin UserLogin { get; set; }

        [Required]
        public int ATMID { get; set; }
        public ATMInfo ATMInfo { get; set; }

        public ATMTransaction(double transactionMoney, DateTime transactionTime, TransactionTypes? transactionType, string beneficiaryCard, string accountNumber, int atmId)
        {
            this.TransactionMoney = transactionMoney;
            this.TransactionTime = transactionTime;
            this.TransactionType = transactionType;
            this.BeneficiaryCard = beneficiaryCard;
            this.AccountNumber = accountNumber;
            this.ATMID = atmId;
        }
    }
}
