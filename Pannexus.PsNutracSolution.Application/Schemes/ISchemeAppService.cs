using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Schemes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Schemes
{
    public interface ISchemeAppService : IApplicationService
    {
        Task CreateAsync(CreateSchemeInput input);

        Task UpdateAsync(UpdateSchemeInput input);

        Task DeleteAsync(EntityDto<string> input);

        Task<SchemeDto> GetAsync(EntityDto<string> input);

        PagedResultDto<SchemeDto> GetSchemesPagedList(SchemeListInput input);
    }
}
