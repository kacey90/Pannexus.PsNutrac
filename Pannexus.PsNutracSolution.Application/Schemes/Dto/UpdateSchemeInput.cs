using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Schemes.Dto
{
    [AutoMapTo(typeof(Scheme))]
    public class UpdateSchemeInput : EntityDto<string>
    {
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

        public float ReturnRate { get; set; }

        [MaxLength(20), Required]
        public string TenorId { get; set; }

        public int TenorInDays { get; set; }

        public DateTime BidOpenDate { get; set; }

        public DateTime BidCloseDate { get; set; }

        public DateTime SchemeStartDate { get; set; }

        public int SubscribedUnits { get; set; }

        public int UnsubscribedUnits { get; set; }

        [MaxLength(20), Required]
        public string PaymentPeriodId { get; set; }

        public int PaymentPeriodInDays { get; set; }

        public int NoOfUniqueInvestments { get; set; }

        public bool IsActive { get; set; }
    }
}
