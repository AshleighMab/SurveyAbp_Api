
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SurveyAbp_Api.Domain;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Surveys
{
    public class SurveyAppService : ApplicationService, ISurveyAppService
    {

        private readonly IRepository<Survey, Guid> _surveyRepo;

        private readonly IRepository<Person, Guid> _personRepo;

        private readonly IRepository<Product, Guid> _productRepo;
        private readonly IRepository<Question, Guid> _questionRepo;
        private readonly IRepository<Answer, Guid> _answerRepo;

        public SurveyAppService(IRepository<Survey, Guid> surveyRepo, IRepository<Person, Guid> personRepo, IRepository<Product, Guid> productRepo, IRepository<Question, Guid> questionRepo, IRepository<Answer, Guid> answerRepo)
        {
            _surveyRepo  = surveyRepo;  
            _personRepo = personRepo;   
            _productRepo = productRepo;
            _questionRepo = questionRepo;
            _answerRepo = answerRepo;   
            
        }

        public async Task<SurveyDto> CreateAsync(SurveyDto input)
        {
            //map course class to the input Dto to the class itself
            var survey = ObjectMapper.Map<Survey>(input);
            survey.Product = await _productRepo.GetAsync((Guid)input.ProductId);
            survey.Person = await _personRepo.GetAsync((Guid)input.PersonId);
            await _surveyRepo.InsertAsync(survey);
            CurrentUnitOfWork.SaveChanges();

            //return the course
            return ObjectMapper.Map<SurveyDto>(survey);
        }

        [AbpAuthorize("Pages.Survey.Delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _surveyRepo.DeleteAsync(id);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<SurveyDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _surveyRepo.GetAllIncluding(m => m.Product).Include(p => p.Person).Include(p => p.Answers).Include(p => p.Questions);
                var result = new PagedResultDto<SurveyDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<SurveyDto>>(query);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResultDto<SurveyDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            try
            {
                var query = _surveyRepo.GetAllIncluding(m => m.Product);
                var res = query.Where(x => x.Id == id);
                var result = new PagedResultDto<SurveyDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<SurveyDto>>(res);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [AbpAuthorize("Pages.Survey.Update")]
        public async Task<SurveyDto> UpdateAsync(SurveyDto input)
        {
            var survey = await _surveyRepo.GetAsync(input.Id);
            ObjectMapper.Map(input, survey);
            survey.Product = await _productRepo.GetAsync((Guid)input.ProductId);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<SurveyDto>(survey);
        }

        public async Task<SurveyDto> GetHighestRatedProduct(Guid productId)
        {
            try
            {
                var query = _surveyRepo.GetAllIncluding(m => m.Product);
                var res = query.Where(x => x.Product.Id == productId);
                var maxRating = res.Max(x => x.Rating);
                var survey = res.FirstOrDefault(x => x.Rating == maxRating);
                return ObjectMapper.Map<SurveyDto>(survey);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<SurveyDto> GetLowestRatedProduct(Guid productId)
        {
            try
            {
                var query = _surveyRepo.GetAllIncluding(m => m.Product);
                var res = query.Where(x => x.Product.Id == productId);
                var minRating = res.Min(x => x.Rating);
                var survey = res.FirstOrDefault(x => x.Rating == minRating);
                return ObjectMapper.Map<SurveyDto>(survey);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<double> GetAverageRatingForProduct(Guid productId)
        {
            try
            {
                var query = _surveyRepo.GetAllIncluding(m => m.Product);
                var res = query.Where(x => x.Product.Id == productId);
                var avgRating = res.Average(x => x.Rating);
                return avgRating;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<(Guid, double)> GetProductWithHighestAverageRating()
        {
            try
            {
                var query = _surveyRepo.GetAllIncluding(m => m.Product);
                var groupByProduct = query.GroupBy(x => x.Product.Id);
                var averageRatings = groupByProduct.Select(x => new { ProductId = x.Key, AverageRating = x.Average(y => y.Rating) });
                var maxAverageRating = averageRatings.Max(x => x.AverageRating);
                var highestRatedProduct = averageRatings.FirstOrDefault(x => x.AverageRating == maxAverageRating);

                return (highestRatedProduct.ProductId, highestRatedProduct.AverageRating);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}

