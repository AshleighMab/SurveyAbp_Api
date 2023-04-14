using Abp.AutoMapper;
using SurveyAbp_Api.Authentication.External;

namespace SurveyAbp_Api.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
