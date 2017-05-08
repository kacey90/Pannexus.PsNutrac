using Abp.Domain.Entities.Auditing;
using Pannexus.PsNutrac.Schemes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Crops
{
    public class Crop : FullAuditedEntity<string>
    {
        public Crop()
        {
            IsActive = true;
        }

        #region Properties

        [MaxLength(3), Required]
        public String Code { get; set; }

        [MaxLength(20), Required]
        public String Name { get; set; }

        [MaxLength(150)]
        public String Description { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<Scheme> Schemes { get; set; }

        #endregion
    }
}
