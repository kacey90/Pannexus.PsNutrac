using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Pannexus.PsNutrac.Crops.Dto;
using Pannexus.PsNutrac.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Crops
{
    public class CropAppService : ICropAppService
    {
        private readonly IRepository<Crop, string> _cropRepo;

        public CropAppService(IRepository<Crop, string> cropRepo)
        {
            _cropRepo = cropRepo;
        }

        public async Task CreateAsync(CreateCropInput input)
        {
            var crop = new Crop
            {
                Id = ClassUtil.GenerateUniqueKey(),
                Code = input.Code,
                Name = input.Name,
                Description = input.Description
            };
            await _cropRepo.InsertAsync(crop);
        }

        public async Task DeleteAsync(EntityDto<string> input)
        {
            await _cropRepo.DeleteAsync(input.Id);
        }

        public PagedResultDto<CropDto> GetAllCropsPaged(CropListInput input)
        {
            var crops = _cropRepo.GetAll()
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), b => b.Name.Contains(input.Filter) || b.Code.Equals(input.Filter))
                .OrderBy(a => a.Id)
                .PageBy(input).ToList();

            return new PagedResultDto<CropDto>
            {
                TotalCount = crops.Count,
                Items = crops.MapTo<List<CropDto>>()
            };
        }

        public async Task<CropDto> GetAsync(EntityDto<string> input)
        {
            var crop = await _cropRepo.GetAsync(input.Id);

            return crop.MapTo<CropDto>();
        }

        public async Task UpdateAsync(UpdateCropInput input)
        {
            var crop = await _cropRepo.GetAsync(input.Id);
            if (crop != null)
            {
                input.MapTo<Crop>();
            }
        }
    }
}
