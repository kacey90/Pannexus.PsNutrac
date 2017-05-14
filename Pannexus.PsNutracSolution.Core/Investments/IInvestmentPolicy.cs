using Abp.Domain.Services;
using Pannexus.PsNutrac.Schemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Investments
{
    public interface IInvestmentPolicy : IDomainService
    {
        void CheckBiddingAttemptPolicy(Scheme scheme);
    }
}
