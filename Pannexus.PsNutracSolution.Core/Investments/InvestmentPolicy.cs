using Abp.Domain.Repositories;
using Abp.UI;
using Pannexus.PsNutrac.Schemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Investments
{
    public class InvestmentPolicy : IInvestmentPolicy
    {
        private readonly IRepository<Investment, string> _investmentRepo;

        public InvestmentPolicy(IRepository<Investment, string> investmentRepo)
        {
            _investmentRepo = investmentRepo;
        }

        public void CheckBiddingAttemptPolicy(Scheme scheme)
        {
            if (scheme == null)
                throw new ArgumentNullException("scheme");

            CheckSchemeStatus(scheme);
            CheckBidPeriod(scheme);
            CheckAvailabileUnits(scheme);
        }

        private void CheckAvailabileUnits(Scheme scheme)
        {
            if (scheme.UnsubscribedUnits <= scheme.FloorInvestUnit)
                throw new UserFriendlyException("We're very sorry!", "No available units for sale anymore. You may try again sometime.");
        }

        private void CheckSchemeStatus(Scheme scheme)
        {
            if (scheme.IsSchemeConcluded())
                throw new UserFriendlyException("Oops!", "The Scheme is expired!");
        }

        private static void CheckBidPeriod(Scheme scheme)
        {
            if (!scheme.IsBiddingAllowed())
                throw new UserFriendlyException("We're Sorry!", "You can't bid outside the Bid Period. Please try again later.");
        }
    }
}
