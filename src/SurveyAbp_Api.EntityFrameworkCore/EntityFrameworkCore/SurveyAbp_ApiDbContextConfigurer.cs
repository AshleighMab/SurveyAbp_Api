using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SurveyAbp_Api.EntityFrameworkCore
{
    public static class SurveyAbp_ApiDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SurveyAbp_ApiDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SurveyAbp_ApiDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
