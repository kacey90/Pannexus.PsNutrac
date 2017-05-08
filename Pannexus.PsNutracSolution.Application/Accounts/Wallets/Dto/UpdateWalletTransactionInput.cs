using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Accounts.Wallets.Dto
{
    [AutoMapTo(typeof(WalletTransaction))]
    public class UpdateWalletTransactionInput : EntityDto<string>
    {
        [MaxLength(20), Required]
        public string WalletID { get; set; }

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
    }
}
