using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Answers
{
    public interface IAnswerAppService : IApplicationService
    {
        Task<AnswerDto> CreateAsync(AnswerDto input);
        Task<AnswerDto> UpdateAsync(AnswerDto input);
        Task<PagedResultDto<AnswerDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<AnswerDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);
    }
}
