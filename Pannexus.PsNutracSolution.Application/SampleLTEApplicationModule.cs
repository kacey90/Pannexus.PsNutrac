using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Pannexus.PsNutrac
{
    [DependsOn(typeof(SampleLTECoreModule), typeof(AbpAutoMapperModule))]
    public class SampleLTEApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
