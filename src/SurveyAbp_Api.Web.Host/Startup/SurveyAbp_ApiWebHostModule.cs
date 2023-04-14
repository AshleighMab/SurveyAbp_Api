using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SurveyAbp_Api.Configuration;

namespace SurveyAbp_Api.Web.Host.Startup
{
    [DependsOn(
       typeof(SurveyAbp_ApiWebCoreModule))]
    public class SurveyAbp_ApiWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SurveyAbp_ApiWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SurveyAbp_ApiWebHostModule).GetAssembly());
        }
    }
}
