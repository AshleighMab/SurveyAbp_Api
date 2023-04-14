using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using SurveyAbp_Api.Domain;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Products
{

    
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductAppService(IRepository<Product, Guid> productRepository) 
        {
            _productRepository  = productRepository;
        }

        [AbpAuthorize("Pages.Product.Create")]
        public async Task<ProductDto> CreateAsync(ProductDto input)
        {
           var product = ObjectMapper.Map<Product>(input);
           await _productRepository.InsertAsync(product);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<ProductDto>(product);
        }

        [AbpAuthorize("Pages.Product.Delete")]
        public async Task DeleteAsync(Guid id)
        {
            await  _productRepository.DeleteAsync(id);
         
        }

        public async Task<PagedResultDto<ProductDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {

            try
            {
                var query = _productRepository.GetAllIncluding();
                var result = new PagedResultDto<ProductDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<ProductDto>>(query);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResultDto<ProductDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            try
            {
                         
                var query = _productRepository.GetAllList();
                var res = query.Where(x => x.Id == id);
                var result = new PagedResultDto<ProductDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<ProductDto>>(res);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           
        }
        [AbpAuthorize("Pages.Product.Update")]
        public async Task<ProductDto> UpdateAsync(ProductDto input)
        {
            var product = await _productRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, product);
            await _productRepository.UpdateAsync(product);
            return ObjectMapper.Map<ProductDto>(product);
        }

        public async Task<int> CountAsync()
        {
            return await _productRepository.CountAsync();
        }
    }
}
