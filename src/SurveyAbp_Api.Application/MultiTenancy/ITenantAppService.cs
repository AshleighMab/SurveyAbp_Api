using Abp.Application.Services;
using SurveyAbp_Api.MultiTenancy.Dto;

namespace SurveyAbp_Api.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

