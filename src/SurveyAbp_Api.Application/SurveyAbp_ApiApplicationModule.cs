using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SurveyAbp_Api.Authorization;

namespace SurveyAbp_Api
{
    [DependsOn(
        typeof(SurveyAbp_ApiCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SurveyAbp_ApiApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SurveyAbp_ApiAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SurveyAbp_ApiApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
