using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Schemes
{
    public interface ISchemeCreationPolicy : IDomainService
    {
        void CheckSchemeCreationAttemptPolicy(Scheme scheme);
    }
}
