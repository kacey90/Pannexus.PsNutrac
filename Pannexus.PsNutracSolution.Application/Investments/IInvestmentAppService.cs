using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Investments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Investments
{
    public interface IInvestmentAppService : IApplicationService
    {
        Task CreateAsync(CreateInvestmentInput input);

        Task InstantPayCreateAsync(CreateInvestmentInput input);

        Task UpdateAsync(UpdateInvestmentInput input);

        Task DeleteAsync(EntityDto<string> input);

        Task<InvestmentDto> GetAsync(EntityDto<string> input);

        PagedResultDto<InvestmentDto> GetAllInvestmentsPaged(InvestmentListInput input);
    }
}
