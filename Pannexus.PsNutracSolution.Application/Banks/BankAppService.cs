using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Pannexus.PsNutrac.Banks.Dto;
using Pannexus.PsNutrac.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Banks
{
    public class BankAppService : IBankAppService
    {
        private readonly IRepository<Bank, string> _bankRepo;

        public BankAppService(IRepository<Bank, string> bankRepo)
        {
            _bankRepo = bankRepo;
        }

        public async Task CreateAsync(CreateBankInput input)
        {
            var bank = new Bank
            {
                Id = ClassUtil.GenerateUniqueKey(),
                BankCode = input.BankCode,
                BankName = input.BankName
            };
            await _bankRepo.InsertAsync(bank);
        }

        public async Task DeleteAsync(EntityDto<string> input)
        {
            await _bankRepo.DeleteAsync(input.Id);
        }

        public PagedResultDto<BankDto> GetAllBanksPaged(BankListInput input)
        {
            var banks = _bankRepo.GetAll()
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), b => b.BankName.Contains(input.Filter) || b.BankCode.Equals(input.Filter))
                .OrderBy(a => a.Id)
                .PageBy(input).ToList();

            return new PagedResultDto<BankDto>
            {
                TotalCount = banks.Count,
                Items = banks.MapTo<List<BankDto>>()
            };
        }

        public async Task<BankDto> GetAsync(EntityDto<string> input)
        {
            var bank = await _bankRepo.GetAsync(input.Id);

            return bank.MapTo<BankDto>();
        }

        public async Task UpdateAsync(UpdateBankInput input)
        {
            var bank = await _bankRepo.GetAsync(input.Id);
            if (bank != null)
            {
                input.MapTo<Bank>();
            }
        }
    }
}
