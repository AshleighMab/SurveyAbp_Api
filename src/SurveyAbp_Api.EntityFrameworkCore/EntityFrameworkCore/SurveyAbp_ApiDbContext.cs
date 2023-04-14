using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SurveyAbp_Api.Authorization.Roles;
using SurveyAbp_Api.Authorization.Users;
using SurveyAbp_Api.MultiTenancy;
using SurveyAbp_Api.Domain;

namespace SurveyAbp_Api.EntityFrameworkCore
{
    public class SurveyAbp_ApiDbContext : AbpZeroDbContext<Tenant, Role, User, SurveyAbp_ApiDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Survey> Surveys { get; set; }

        public SurveyAbp_ApiDbContext(DbContextOptions<SurveyAbp_ApiDbContext> options)
            : base(options)
        {
        }
    }
}
