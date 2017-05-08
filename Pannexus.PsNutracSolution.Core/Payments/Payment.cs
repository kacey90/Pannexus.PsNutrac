using Abp.Domain.Entities.Auditing;
using Pannexus.PsNutrac.Accounts;
using Pannexus.PsNutrac.Banks;
using Pannexus.PsNutrac.Investments;
using Pannexus.PsNutrac.Schemes;
using Pannexus.PsNutrac.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Payments
{
    public class Payment : FullAuditedEntity<string>
    {
        #region Properties
        [MaxLength(20), Required]
        public string InvestmentID { get; set; }

        [MaxLength(20), Required]
        public string SchemeId { get; set; }

        public long UserId { get; set; }

        [MaxLength(20), Required]
        public string BankId { get; set; }

        [MaxLength(20), Required]
        public string CreditBank { get; set; }

        [MaxLength(20)]
        public string SortCode { get; set; }

        [MaxLength(20), Required]
        public string CreditAccount { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool Status { get; set; }

        [MaxLength(50), Required]
        public string Message { get; set; }

        [MaxLength(20), Required]
        public string AccountChartId { get; set; }

        [MaxLength(50), Required]
        public string DebitBankName { get; set; }

        [MaxLength(20), Required]
        public string DebitBankAccountNumber { get; set; }
        #endregion

        #region Navigation Properties

        public virtual Investment Investment { get; set; }
        public virtual Scheme Scheme { get; set; }
        public virtual User User { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual AccountChart AccountChart { get; set; }

        #endregion
    }
}
