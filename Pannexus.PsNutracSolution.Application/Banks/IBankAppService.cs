using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Banks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Banks
{
    public interface IBankAppService : IApplicationService
    {
        Task CreateAsync(CreateBankInput input);

        Task UpdateAsync(UpdateBankInput input);

        Task DeleteAsync(EntityDto<string> input);

        Task<BankDto> GetAsync(EntityDto<string> input);

        PagedResultDto<BankDto> GetAllBanksPaged(BankListInput input);
    }
}
