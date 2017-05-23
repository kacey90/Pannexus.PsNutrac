using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Schemes
{
    public class SchemeCreationPolicy : ISchemeCreationPolicy
    {
        private readonly IRepository<Scheme, string> _schemeRepo;

        public SchemeCreationPolicy(IRepository<Scheme, string> schemeRepo)
        {
            _schemeRepo  = schemeRepo;
        }

        public void CheckSchemeCreationAttemptPolicy(Scheme scheme)
        {
            if (scheme == null)
                throw new ArgumentNullException("scheme");

            CheckOpenAndCloseBidPeriod(scheme);
            VerifySchemeStartDate(scheme);
        }

        private static void VerifySchemeStartDate(Scheme scheme)
        {
            if (Clock.Now > scheme.SchemeStartDate)
                throw new UserFriendlyException("Invalid Operation!", "The Scheme's Start Date cannot be set in the past. Try a future date.");

            if (scheme.SchemeStartDate >= scheme.BidOpenDate && scheme.SchemeStartDate <= scheme.BidCloseDate)
                throw new UserFriendlyException("Invalid Operation!", "The Scheme's Start Date shouldn't be set within the bidding period.");
        }

        private static void CheckOpenAndCloseBidPeriod(Scheme scheme)
        {
            if (Clock.Now > scheme.BidOpenDate)
                throw new UserFriendlyException("Invalid Operation!", "The Bid open Date cannot be set in the past. Try a future date.");

            if (scheme.BidOpenDate > scheme.BidCloseDate)
                throw new UserFriendlyException("Oh Snap!", "The bid open date must be less than the bid close date");
            if (scheme.BidOpenDate == scheme.BidCloseDate)
                throw new UserFriendlyException("Bidding Same Day Error!", "The bid open and bid close day cannot be the same.");
        }
    }
}
