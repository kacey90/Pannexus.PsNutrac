using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Payments.PaymentPeriods.Dto
{
    public class UpdatePaymentPeriodInput : EntityDto<string>
    {
        public String PeriodInDays { get; set; }
    }
}
