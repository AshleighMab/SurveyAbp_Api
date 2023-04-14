using System.Threading.Tasks;
using Abp.Application.Services;
using SurveyAbp_Api.Authorization.Accounts.Dto;

namespace SurveyAbp_Api.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
