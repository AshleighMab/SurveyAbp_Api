using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SurveyAbp_Api.Controllers
{
    public abstract class SurveyAbp_ApiControllerBase: AbpController
    {
        protected SurveyAbp_ApiControllerBase()
        {
            LocalizationSourceName = SurveyAbp_ApiConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
