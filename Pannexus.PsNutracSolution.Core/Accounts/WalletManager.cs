using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Accounts
{
    public class WalletManager : IWalletManager
    {
        private readonly IRepository<Wallet, string> _walletRepository;

        public WalletManager(IRepository<Wallet, string> walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task CreateAsync(Wallet wallet)
        {
            await _walletRepository.InsertAsync(wallet);
        }
    }
}
