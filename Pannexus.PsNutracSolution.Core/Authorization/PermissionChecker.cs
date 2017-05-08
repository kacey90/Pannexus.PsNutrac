using Abp.Authorization;
using Pannexus.PsNutrac.Authorization.Roles;
using Pannexus.PsNutrac.MultiTenancy;
using Pannexus.PsNutrac.Users;

namespace Pannexus.PsNutrac.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
