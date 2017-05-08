using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Tenors.Dto;
using Abp.Domain.Repositories;
using Pannexus.PsNutrac.Helper;
using Abp.AutoMapper;

namespace Pannexus.PsNutrac.Tenors
{
    public class TenorAppService : ITenorAppService
    {
        private readonly IRepository<Tenor, string> _tenorRepo;

        public TenorAppService(IRepository<Tenor, string> tenorRepo)
        {
            _tenorRepo = tenorRepo;
        }

        public async Task CreateAsync(CreateTenorInput input)
        {
            var tenor = new Tenor
            {
                Id = ClassUtil.GenerateUniqueKey(),
                TenorInDays = input.TenorInDays,
                IsActive = input.IsActive
            };

            await _tenorRepo.InsertAsync(tenor);
        }

        public async Task DeleteAsync(EntityDto<string> input)
        {
            await _tenorRepo.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<TenorDto>> GetAllTenorsAsync()
        {
            var tenors = await _tenorRepo.GetAllListAsync();

            return new ListResultDto<TenorDto>(
                tenors.MapTo<List<TenorDto>>()
                );
        }

        public async Task<TenorDto> GetAsync(EntityDto<string> input)
        {
            var tenor = await _tenorRepo.GetAsync(input.Id);

            return tenor.MapTo<TenorDto>();
        }

        public async Task UpdateAsync(UpdateTenorInput input)
        {
            var tenor = await _tenorRepo.GetAsync(input.Id);
            if (tenor != null)
            {
                tenor.TenorInDays = input.TenorInDays;
                tenor.IsActive = input.IsActive;

                await _tenorRepo.UpdateAsync(tenor);
            }
        }
    }
}
