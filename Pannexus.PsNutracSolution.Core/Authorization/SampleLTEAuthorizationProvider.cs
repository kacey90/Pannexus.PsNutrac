using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Pannexus.PsNutrac.Authorization
{
    public class SampleLTEAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));

            var admins = pages.CreateChildPermission(PermissionNames.Pages_Admin, L("Adminstrators"),
               multiTenancySides: MultiTenancySides.Tenant);

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SampleLTEConsts.LocalizationSourceName);
        }
    }
}
