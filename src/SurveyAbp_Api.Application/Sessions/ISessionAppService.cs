using System.Threading.Tasks;
using Abp.Application.Services;
using SurveyAbp_Api.Sessions.Dto;

namespace SurveyAbp_Api.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
