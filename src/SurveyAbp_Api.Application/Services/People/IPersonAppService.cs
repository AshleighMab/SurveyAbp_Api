using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.People
{
    public interface IPersonAppService: IApplicationService
    {
        Task<PersonDto> CreateAsync(PersonDto input);
        Task<PersonDto> UpdateAsync(PersonDto input);
        Task<PagedResultDto<PersonDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<PersonDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);

    }
}
