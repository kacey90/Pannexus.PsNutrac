using Abp.Domain.Entities.Auditing;
using Pannexus.PsNutrac.Payments;
using Pannexus.PsNutrac.Schemes;
using Pannexus.PsNutrac.Tenors;
using Pannexus.PsNutrac.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Investments
{
    public class Investment : FullAuditedEntity<string>
    {
        public Investment()
        {
            NoOfTotalPaymentMade = 0;
        }
        #region Properties
        public long UserId { get; set; }

        [MaxLength(20), Required]
        public string SchemeId { get; set; }

        [MaxLength(50), Required]
        public string SchemeName { get; set; }

        public int InvestmentUnit { get; set; }

        public decimal InvestmentAmount { get; set; } //InvestmentAmount = InvestmentUnit * Scheme.ValuePerUnit

        public DateTime InvestmentDate { get; set; }

        public DateTime InvestmentStartDate { get; set; }

        public DateTime InvestmentMaturityDate
        {
            get { return InvestmentStartDate.AddDays(TenorInDays); }
        }

        public float ReturnRate { get; set; } // From The Scheme.ReturnRate

        [MaxLength(20), Required]
        public string TenorID { get; set; }

        public int TenorInDays { get; set; }

        [MaxLength(20), Required]
        public string PaymentPeriodID { get; set; }

        public int PaymentPeriodInDays { get; set; }

        public decimal ExpectedTotalReturn  //InvestmentAmount * returnRate + InvestmentAmount
        {
            get { return InvestmentAmount + InvestmentAmount * decimal.Parse(ReturnRate.ToString()); }
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
        public virtual User User { get; set; }
        public virtual Scheme Scheme { get; set; }
        public virtual Tenor Tenor { get; set; }
        public virtual PaymentPeriod PaymentPeriod { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        #endregion
    }
}
