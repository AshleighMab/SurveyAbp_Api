using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace SurveyAbp_Api.Authorization
{
    public class SurveyAbp_ApiAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
   
            context.CreatePermission(PermissionNames.Pages_Product_Create, L("Pages.Product.Create"));
            context.CreatePermission(PermissionNames.Pages_Product_Update, L("Pages.Product.Update"));
            context.CreatePermission(PermissionNames.Pages_Product_Delete, L("Pages.Product.Delete"));

            context.CreatePermission(PermissionNames.Pages_Survey_Create, L("Pages.Survey.Create"));
            context.CreatePermission(PermissionNames.Pages_Survey_Update, L("Pages.Survey.Update"));
            context.CreatePermission(PermissionNames.Pages_Survey_Delete, L("Pages.Survey.Delete"));

            context.CreatePermission(PermissionNames.Pages_Question_Create, L("Pages.Question.Create"));
            context.CreatePermission(PermissionNames.Pages_Question_Update, L("Pages.Question.Update"));
            context.CreatePermission(PermissionNames.Pages_Question_Delete, L("Pages.Question.Delete"));

            context.CreatePermission(PermissionNames.Pages_Answer_Create, L("Pages.Answer.Create"));
            context.CreatePermission(PermissionNames.Pages_Answer_Update, L("Pages.Answer.Update"));
            context.CreatePermission(PermissionNames.Pages_Answer_Delete, L("Pages.Answer.Delete"));

            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SurveyAbp_ApiConsts.LocalizationSourceName);
        }
    }
}
