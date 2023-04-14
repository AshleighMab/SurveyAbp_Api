using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SurveyAbp_Api.Configuration;
using SurveyAbp_Api.EntityFrameworkCore;
using SurveyAbp_Api.Migrator.DependencyInjection;

namespace SurveyAbp_Api.Migrator
{
    [DependsOn(typeof(SurveyAbp_ApiEntityFrameworkModule))]
    public class SurveyAbp_ApiMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SurveyAbp_ApiMigratorModule(SurveyAbp_ApiEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(SurveyAbp_ApiMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                SurveyAbp_ApiConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SurveyAbp_ApiMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
