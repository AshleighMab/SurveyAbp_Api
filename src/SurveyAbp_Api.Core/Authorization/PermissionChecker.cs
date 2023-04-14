using Abp.Authorization;
using SurveyAbp_Api.Authorization.Roles;
using SurveyAbp_Api.Authorization.Users;

namespace SurveyAbp_Api.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
