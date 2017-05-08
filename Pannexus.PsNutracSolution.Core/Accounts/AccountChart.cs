using Abp.Domain.Entities.Auditing;
using Pannexus.PsNutrac.Banks;
using Pannexus.PsNutrac.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Accounts
{
    public class AccountChart : FullAuditedEntity<string>
    {
        #region Properties
        [MaxLength(20), Required]
        public String BankId { get; set; }

        [MaxLength(50), Required]
        public String BankName { get; set; }

        [MaxLength(20)]
        public String SortCode { get; set; }

        [MaxLength(20), Required]
        public String AccountNumber { get; set; }

        public bool IsActive { get; set; }

        public decimal TotalCreditAmount { get; set; }

        public decimal TotalDebitAmount { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Bank Bank { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        #endregion
    }
}
