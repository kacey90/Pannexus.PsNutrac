using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pannexus.PsNutrac.Accounts
{
    public class WalletTransaction : FullAuditedEntity<string>
    {
        public WalletTransaction()
        {
            TransactionDate = Clock.Now;
        }
        #region Properties

        [MaxLength(20), Required]
        public string WalletID { get; set; }

        public DateTime TransactionDate { get; set; }

        [MaxLength(50)]
        public string BankTransactionReference { get; set; }

        [MaxLength(20)]
        public string SourceBankSortCode { get; set; }

        public decimal Amount { get; set; }

        [MaxLength(20), Required]
        public string AccountChartId { get; set; }

        [MaxLength(20), Required]
        public string BankCode { get; set; }

        [MaxLength(50), Required]
        public string BankName { get; set; }

        [MaxLength(20), Required]
        public string CreditAccountNumber { get; set; }

        public bool IsCreditDebit { get; set; }

        public bool IsExternalGenerated { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Wallet Wallet { get; set; }
        public virtual AccountChart AccountChart { get; set; }

        #endregion
    }
}