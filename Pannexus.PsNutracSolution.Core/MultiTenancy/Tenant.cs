using Abp.MultiTenancy;
using Pannexus.PsNutrac.Users;

namespace Pannexus.PsNutrac.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}