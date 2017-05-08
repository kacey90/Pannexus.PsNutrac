using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Tenors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Tenors
{
    public interface ITenorAppService : IApplicationService
    {
        Task CreateAsync(CreateTenorInput input);

        Task UpdateAsync(UpdateTenorInput input);

        Task DeleteAsync(EntityDto<string> input);

        Task<TenorDto> GetAsync(EntityDto<string> input);

        Task<ListResultDto<TenorDto>> GetAllTenorsAsync();
    }
}
