using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Payments
{
    public class PaymentPeriod : FullAuditedEntity<string>
    {
        [MaxLength(20), Required]
        public String PeriodInDays { get; set; }
        public bool IsActive { get; set; }
    }
}
