using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using SurveyAbp_Api.EntityFrameworkCore.Seed;

namespace SurveyAbp_Api.EntityFrameworkCore
{
    [DependsOn(
        typeof(SurveyAbp_ApiCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class SurveyAbp_ApiEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<SurveyAbp_ApiDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        SurveyAbp_ApiDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        SurveyAbp_ApiDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SurveyAbp_ApiEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
