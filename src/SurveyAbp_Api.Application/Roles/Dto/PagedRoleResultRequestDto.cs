using Abp.Application.Services.Dto;

namespace SurveyAbp_Api.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

