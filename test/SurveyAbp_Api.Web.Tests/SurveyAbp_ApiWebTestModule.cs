using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SurveyAbp_Api.EntityFrameworkCore;
using SurveyAbp_Api.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SurveyAbp_Api.Web.Tests
{
    [DependsOn(
        typeof(SurveyAbp_ApiWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SurveyAbp_ApiWebTestModule : AbpModule
    {
        public SurveyAbp_ApiWebTestModule(SurveyAbp_ApiEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SurveyAbp_ApiWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SurveyAbp_ApiWebMvcModule).Assembly);
        }
    }
}