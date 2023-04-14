using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SurveyAbp_Api.Configuration;
using SurveyAbp_Api.Web;

namespace SurveyAbp_Api.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SurveyAbp_ApiDbContextFactory : IDesignTimeDbContextFactory<SurveyAbp_ApiDbContext>
    {
        public SurveyAbp_ApiDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SurveyAbp_ApiDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SurveyAbp_ApiDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SurveyAbp_ApiConsts.ConnectionStringName));

            return new SurveyAbp_ApiDbContext(builder.Options);
        }
    }
}
