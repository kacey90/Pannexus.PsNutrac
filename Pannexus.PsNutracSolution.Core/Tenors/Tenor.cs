using Abp.Domain.Entities.Auditing;
using Pannexus.PsNutrac.Investments;
using Pannexus.PsNutrac.Schemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Tenors
{
    public class Tenor : FullAuditedEntity<string>
    {
        public Tenor()
        {
            Schemes = new HashSet<Scheme>();
        }
        public String TenorInDays { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Scheme> Schemes { get; set; }
        public ICollection<Investment> Investments { get; set; }
    }
}
