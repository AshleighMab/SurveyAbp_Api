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

namespace SurveyAbp_Api.Services.Questions
{
    public class QuestionAppService : ApplicationService, IQuestionAppService
    {

        private readonly IRepository<Question, Guid> _questionrepository;
      

        public QuestionAppService(IRepository<Question, Guid> questionrepository)
        {
            _questionrepository = questionrepository;
       
            
        }
        [AbpAuthorize("Pages.Question.Create")]
        public async Task<QuestionDto> CreateAsync(QuestionDto input)
        {
            //map course class to the input Dto to the class itself
            var question = ObjectMapper.Map<Question>(input);
            await _questionrepository.InsertAsync(question);
            CurrentUnitOfWork.SaveChanges();

            //return the course
            return ObjectMapper.Map<QuestionDto>(question);
        }
        [AbpAuthorize("Pages.Question.Delete")]
        public async Task DeleteAsync(Guid id)
        {
          await _questionrepository.DeleteAsync(id);  
          await CurrentUnitOfWork.SaveChangesAsync(); 
          
        }

        public async Task<PagedResultDto<QuestionDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _questionrepository.GetAllIncluding();
                var result = new PagedResultDto<QuestionDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<QuestionDto>>(query);
                return await Task.FromResult(result);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResultDto<QuestionDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            try {
                var query = _questionrepository.GetAllIncluding();
                var res = query.Where(x => x.Id == id);
                var result = new PagedResultDto<QuestionDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<QuestionDto>>(res);

                return await Task.FromResult(result);    
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [AbpAuthorize("Pages.Question.Update")]
        public async Task<QuestionDto> UpdateAsync(QuestionDto input)
        {
            var question = await _questionrepository.GetAsync(input.Id);
            ObjectMapper.Map(input, question);
           
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<QuestionDto>(question);
        }
    }
}
