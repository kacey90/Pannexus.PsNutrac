using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Crops.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Crops
{
    public interface ICropAppService : IApplicationService
    {
        Task CreateAsync(CreateCropInput input);

        Task UpdateAsync(UpdateCropInput input);

        Task DeleteAsync(EntityDto<string> input);

        Task<CropDto> GetAsync(EntityDto<string> input);

        PagedResultDto<CropDto> GetAllCropsPaged(CropListInput input);
    }
}
