using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Accounts.Wallets.Dto
{
    public class WalletDto : FullAuditedEntityDto<string>
    {
        public long UserID { get; set; }

        public decimal CurrentBalance { get; set; }

        public int TotalTransactions { get; set; }

        public int NoOfCreditTransactions { get; set; }

        public int NoOfDebitTransactions { get; set; }

        public DateTime DateOfLastTransaction { get; set; }

        public bool IsActive { get; set; }

        public virtual UserListDto User { get; set; }
        //public virtual ICollection<WalletTransactionDto> WalletTransactions { get; set; }
    }
}
