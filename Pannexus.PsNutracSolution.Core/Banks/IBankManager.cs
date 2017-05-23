using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Banks
{
    public interface IBankManager : IDomainService
    {
        IEnumerable<Bank> GetBanksList();
    }
}
