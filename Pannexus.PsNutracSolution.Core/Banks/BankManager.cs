using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Banks
{
    public class BankManager : IBankManager
    {
        private readonly IRepository<Bank, string> _bankRepository;
        
        public BankManager(IRepository<Bank, string> bankRepository)
        {
            _bankRepository = bankRepository;
        }

        
        public IEnumerable<Bank> GetBanksList()
        {
            return _bankRepository.GetAll();
        }
    }
}
