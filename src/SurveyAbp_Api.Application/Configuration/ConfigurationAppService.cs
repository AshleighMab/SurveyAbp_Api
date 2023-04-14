using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SurveyAbp_Api.Configuration.Dto;

namespace SurveyAbp_Api.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SurveyAbp_ApiAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
