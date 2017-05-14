using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Pannexus.PsNutrac.Crops;
using Pannexus.PsNutrac.Investments;
using Pannexus.PsNutrac.Payments;
using Pannexus.PsNutrac.Tenors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Schemes
{
    public class Scheme : FullAuditedEntity<string>
    {
        public Scheme()
        {
            SubscribedUnits = 0;
            NoOfUniqueInvestments = 0;

            Investments = new HashSet<Investment>();
            SchemePaymentDays = new List<SchemePaymentDate>();
            Payments = new HashSet<Payment>();
        }

        #region Properties

        [MaxLength(3), Required]
        public String SchemeCode { get; set; }

        [MaxLength(50), Required]
        public String SchemeName { get; set; }

        [MaxLength(20), Required]
        public string CropId { get; set; }

        [MaxLength(50), Required]
        public String CropName { get; set; }

        public int TotalSchemeUnits { get; set; }

        public decimal ValuePerUnit { get; set; }

        public int FloorInvestUnit { get; set; }

        public int CeilingInvestUnit { get; set; }

        public decimal SubscriptionCeiling
        {
            get { return TotalSchemeUnits * ValuePerUnit; }
        }

        public float ReturnRate { get; set; }

        [MaxLength(20), Required]
        public string TenorId { get; set; }

        public int TenorInDays { get; set; }

        public DateTime BidOpenDate { get; set; }

        public DateTime BidCloseDate { get; set; }

        public DateTime SchemeStartDate { get; set; }

        public DateTime SchemeMaturityDate
        {
            get { return SchemeStartDate.AddDays(TenorInDays); }
        }

        public int SubscribedUnits { get; set; }

        public int UnsubscribedUnits
        {
            get { return TotalSchemeUnits - SubscribedUnits; }
        }

        public decimal ActualSubscription
        {
            get { return SubscribedUnits * ValuePerUnit; }
        }

        [MaxLength(20), Required]
        public string PaymentPeriodId { get; set; }

        public int PaymentPeriodInDays { get; set; }

        public int NoOfUniqueInvestments { get; set; } //what is this?

        public bool IsActive { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Crop Crop { get; set; }
        public virtual PaymentPeriod PaymentPeriod { get; set; }
        public virtual Tenor Tenor { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
        public virtual ICollection<SchemePaymentDate> SchemePaymentDays { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        #endregion

        #region Utility Methods

        public bool IsSchemeConcluded()
        {
            return SchemeMaturityDate < Clock.Now;
        }

        public bool IsBiddingAllowed()
        {
            return Clock.Now >= BidOpenDate && Clock.Now <= BidCloseDate;
        }

        #endregion
    }
}
