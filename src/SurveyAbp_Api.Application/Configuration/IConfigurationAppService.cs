using System.Threading.Tasks;
using SurveyAbp_Api.Configuration.Dto;

namespace SurveyAbp_Api.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
