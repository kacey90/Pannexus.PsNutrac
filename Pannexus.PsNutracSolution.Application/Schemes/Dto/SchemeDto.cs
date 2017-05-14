using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Timing;
using Pannexus.PsNutrac.Crops.Dto;
using Pannexus.PsNutrac.Payments.PaymentPeriods.Dto;
using Pannexus.PsNutrac.Tenors.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Schemes.Dto
{
    [AutoMapFrom(typeof(Scheme))]
    public class SchemeDto : FullAuditedEntityDto<string>
    {
        #region Properties

        
        public String SchemeCode { get; set; }

        
        public String SchemeName { get; set; }

        
        public string CropId { get; set; }

        
        public String CropName { get; set; }

        public int TotalSchemeUnits { get; set; }

        public decimal ValuePerUnit { get; set; }

        public int FloorInvestUnit { get; set; }

        public int CeilingInvestUnit { get; set; }

        //public decimal SubscriptionCeiling
        //{
        //    get { return TotalSchemeUnits * ValuePerUnit; }
        //}

        public decimal SubscriptionCeiling { get; set; }

        public float ReturnRate { get; set; }

        
        public string TenorId { get; set; }

        public int TenorInDays { get; set; }

        public DateTime BidOpenDate { get; set; }

        public DateTime BidCloseDate { get; set; }

        public DateTime SchemeStartDate { get; set; }

        public DateTime SchemeMaturityDate { get; set; }

        //public DateTime SchemeMaturityDate
        //{
        //    get { return SchemeStartDate.AddDays(TenorInDays); }
        //}

        public string SchemeMaturityStatus
        {
            get
            {
                var res = string.Empty;
                if (SchemeMaturityDate < Clock.Now)
                    res = "Concluded!";
                //else
                //    res = "Scheme is Running!";

                return res;
            }
        }

        public string BiddingStatus
        {
            get
            {
                var res = string.Empty;
                if (Clock.Now < BidOpenDate)
                    res = "New";
                else if (Clock.Now >= BidOpenDate && Clock.Now <= BidCloseDate)
                    res = "Bidding: Opened";
                else
                    res = "Bidding: Closed";

                return res;
            }
        }

        public DateTime DateCreated { get; set; }

        public int SubscribedUnits { get; set; }

        public int UnsubscribedUnits { get; set; }

        //public decimal ActualSubscription
        //{
        //    get { return SubscribedUnits * ValuePerUnit; }
        //}

        public decimal ActualSubscription { get; set; }

        public string PaymentPeriodId { get; set; }

        public int PaymentPeriodInDays { get; set; }

        public int NoOfUniqueInvestments { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Navigation Properties

        public virtual CropDto Crop { get; set; }
        public virtual PaymentPeriodDto PaymentPeriod { get; set; }
        public virtual TenorDto Tenor { get; set; }

        //public virtual ICollection<Investment> Investments { get; set; }
        //public virtual ICollection<SchemePaymentDate> SchemePaymentDays { get; set; }
        //public virtual ICollection<Payment> Payments { get; set; }

        #endregion
    }
}
