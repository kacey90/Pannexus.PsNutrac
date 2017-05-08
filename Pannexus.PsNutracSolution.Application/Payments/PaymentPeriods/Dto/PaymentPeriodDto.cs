using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Payments.PaymentPeriods.Dto
{
    [AutoMapFrom(typeof(PaymentPeriod))]
    public class PaymentPeriodDto : FullAuditedEntityDto<string>
    {
        public String PeriodInDays { get; set; }
        public bool IsActive { get; set; }
    }
}
