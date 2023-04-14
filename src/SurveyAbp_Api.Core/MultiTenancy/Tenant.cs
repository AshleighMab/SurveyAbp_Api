using Abp.MultiTenancy;
using SurveyAbp_Api.Authorization.Users;

namespace SurveyAbp_Api.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
