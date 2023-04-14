using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> CreateAsync(ProductDto input);
        Task<ProductDto> UpdateAsync(ProductDto input);
        Task<PagedResultDto<ProductDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<ProductDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);
        Task<int> CountAsync();

    }
}
