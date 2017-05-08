using System.Threading.Tasks;
using Abp.Application.Services;
using Pannexus.PsNutrac.Roles.Dto;

namespace Pannexus.PsNutrac.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
