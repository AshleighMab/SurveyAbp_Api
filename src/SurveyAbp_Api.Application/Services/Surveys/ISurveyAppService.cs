using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Surveys
{
    public interface ISurveyAppService : IApplicationService
    {
        Task<SurveyDto> CreateAsync(SurveyDto input);
        Task<SurveyDto> UpdateAsync(SurveyDto input);
        Task<PagedResultDto<SurveyDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<SurveyDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);

        Task<SurveyDto> GetHighestRatedProduct(Guid productId);

        Task<SurveyDto> GetLowestRatedProduct(Guid productId);

        Task<double> GetAverageRatingForProduct(Guid productId);
      
        Task<(Guid, double)> GetProductWithHighestAverageRating();



    }
}
