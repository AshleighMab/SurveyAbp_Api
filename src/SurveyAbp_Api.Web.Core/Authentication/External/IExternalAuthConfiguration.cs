using System.Collections.Generic;

namespace SurveyAbp_Api.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
