using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Accounts
{
    public interface IWalletManager : IDomainService
    {
        Task CreateAsync(Wallet wallet);
    }
}
