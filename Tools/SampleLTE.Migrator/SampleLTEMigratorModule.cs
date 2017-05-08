using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Pannexus.PsNutrac.EntityFramework;

namespace Pannexus.PsNutrac.Migrator
{
    [DependsOn(typeof(SampleLTEDataModule))]
    public class SampleLTEMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<SampleLTEDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}