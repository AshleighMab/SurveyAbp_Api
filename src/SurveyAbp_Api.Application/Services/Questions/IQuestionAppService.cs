using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Questions
{
    public interface IQuestionAppService : IApplicationService
    {
        Task<QuestionDto> CreateAsync(QuestionDto input);
        Task<QuestionDto> UpdateAsync(QuestionDto input);
        Task<PagedResultDto<QuestionDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<QuestionDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);
    }
}
