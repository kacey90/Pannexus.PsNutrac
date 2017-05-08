using System.Linq;
using Pannexus.PsNutrac.EntityFramework;
using Pannexus.PsNutrac.MultiTenancy;

namespace Pannexus.PsNutrac.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly SampleLTEDbContext _context;

        public DefaultTenantCreator(SampleLTEDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
