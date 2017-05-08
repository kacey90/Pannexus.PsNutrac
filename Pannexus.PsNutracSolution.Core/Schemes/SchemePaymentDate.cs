using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Schemes
{
    public class SchemePaymentDate : FullAuditedEntity<string>
    {
        #region Properties

        [MaxLength(20), Required]
        public string SchemeId { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsPast
        {
            get { return PaymentDate < Clock.Now; }
        }

        public decimal ExpectedTotalPayment { get; set; }

        public decimal ActualTotalPayment { get; set; }

        #endregion

        #region Navigation Properties
        public virtual Scheme Scheme { get; set; }
        #endregion
    }
}
