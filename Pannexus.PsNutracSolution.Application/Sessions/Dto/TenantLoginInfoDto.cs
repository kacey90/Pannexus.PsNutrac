using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pannexus.PsNutrac.MultiTenancy;

namespace Pannexus.PsNutrac.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}