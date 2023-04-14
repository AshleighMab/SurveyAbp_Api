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

namespace SurveyAbp_Api.Services.Answers
{
    public class AnswerAppService : ApplicationService, IAnswerAppService
    {

        private readonly IRepository<Answer, Guid> _answerRepo;
  
        private readonly IRepository<Question, Guid>  _questionRepo;

        public AnswerAppService(IRepository<Answer, Guid> answerRepo, IRepository<Question, Guid> questionRepo)
        {
            _answerRepo = answerRepo;
            _questionRepo = questionRepo;   
            
        }
        [AbpAuthorize("Pages.Answer.Create")]
        public async Task<AnswerDto> CreateAsync(AnswerDto input)
        {
            //map course class to the input Dto to the class itself
            var answer = ObjectMapper.Map<Answer>(input);
            answer.Question = await _questionRepo.GetAsync((Guid)input.QuestionId);
            await _answerRepo.InsertAsync(answer);
            CurrentUnitOfWork.SaveChanges();

            //return the course
            return ObjectMapper.Map<AnswerDto>(answer);

        }

        [AbpAuthorize("Pages.Answer.Delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _answerRepo.DeleteAsync(id);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<AnswerDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _answerRepo.GetAllIncluding(m => m.Question);
                var result = new PagedResultDto<AnswerDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<AnswerDto>>(query);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResultDto<AnswerDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            try
            {
                var query = _answerRepo.GetAllIncluding(m => m.Question) ;
                var res = query.Where(x => x.Id == id);
                var result = new PagedResultDto<AnswerDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<AnswerDto>>(res);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [AbpAuthorize("Pages.Answer.Update")]
        public async Task<AnswerDto> UpdateAsync(AnswerDto input)
        {
            var course = await _answerRepo.GetAsync(input.Id);
            ObjectMapper.Map(input, course);
            course.Question = await _questionRepo.GetAsync((Guid)input.QuestionId);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<AnswerDto>(course);
        }
    }
}
