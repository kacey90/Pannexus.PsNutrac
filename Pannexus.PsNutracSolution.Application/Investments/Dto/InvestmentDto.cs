using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pannexus.PsNutrac.Payments.PaymentPeriods.Dto;
using Pannexus.PsNutrac.Schemes.Dto;
using Pannexus.PsNutrac.Tenors.Dto;
using Pannexus.PsNutrac.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Investments.Dto
{
    [AutoMapFrom(typeof(Investment))]
    public class InvestmentDto : FullAuditedEntityDto
    {
        #region Properties
        public long UserId { get; set; }

        [MaxLength(20), Required]
        public String SchemeId { get; set; }

        [MaxLength(50), Required]
        public String SchemeName { get; set; }

        public int InvestmentUnit { get; set; }

        public decimal InvestmentAmount { get; set; } //InvestmentAmount = InvestmentUnit * Scheme.ValuePerUnit

        public DateTime InvestmentDate { get; set; }

        public DateTime InvestmentStartDate { get; set; }

        public DateTime InvestmentMaturityDate
        {
            get { return InvestmentStartDate.AddDays(TenorInDays); }
        }

        public decimal ReturnRate { get; set; } // From The Scheme.ReturnRate

        [MaxLength(20), Required]
        public String TenorID { get; set; }

        public int TenorInDays { get; set; }

        [MaxLength(20), Required]
        public String PaymentPeriodID { get; set; }

        public int PaymentPeriodInDays { get; set; }

        public decimal ExpectedTotalReturn  //InvestmentAmount * returnRate + InvestmentAmount
        {
            get { return InvestmentAmount + InvestmentAmount * ReturnRate; }
        }

        public double NoOfTotalPayments { get; set; } // how is this deduced

        public decimal ExpectedAmountPerPayment
        {
            get { return ExpectedTotalReturn / PaymentPeriodInDays; }
        }

        public int NoOfTotalPaymentMade { get; set; }

        public bool IsActive { get; set; }
        #endregion

        #region Navigation Properties
        public virtual UserListDto User { get; set; }
        public virtual SchemeDto Scheme { get; set; }
        public virtual TenorDto Tenor { get; set; }
        public virtual PaymentPeriodDto PaymentPeriod { get; set; }

        //public virtual ICollection<PaymentDto> Payments { get; set; }
        #endregion
    }
}
