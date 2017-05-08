using Abp.Domain.Entities.Auditing;
using Pannexus.PsNutrac.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Accounts
{
    public class Wallet : FullAuditedEntity<string>
    {
        #region Properties
        public long UserID { get; set; }

        public decimal CurrentBalance { get; set; }

        public int TotalTransactions { get; set; }

        public int NoOfCreditTransactions { get; set; }

        public int NoOfDebitTransactions { get; set; }

        public DateTime DateOfLastTransaction { get; set; }

        public bool IsActive { get; set; }
        #endregion

        #region Navigation Properties
        public virtual User User { get; set; }
        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }
        #endregion
    }
}
