using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using SurveyAbp_Api.Authorization.Users;
using SurveyAbp_Api.Domain;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.People
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {

        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<User, long> _userRepository;

        public PersonAppService(IRepository<Person, Guid> personRepository, IRepository<User, long> userRepository)
        {
            _personRepository = personRepository;
            _userRepository = userRepository;
        }

        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            var person = ObjectMapper.Map<Person>(input);
            person.User = await _userRepository.GetAsync((long)input.UserId);
            await _personRepository.InsertAsync(person);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<PersonDto>(person);
        }

        public async Task DeleteAsync(Guid id)
        {
           await _personRepository.DeleteAsync(id);
           await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<PersonDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _personRepository.GetAllIncluding(m=> m.User);
                var result = new PagedResultDto<PersonDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<PersonDto>>(query);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResultDto<PersonDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            try
            {
                var query = _personRepository.GetAllIncluding(m => m.User);
                var res = query.Where(x => x.Id == id);
                var result = new PagedResultDto<PersonDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<PersonDto>>(res);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PersonDto> UpdateAsync(PersonDto input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, person);
            person.User = await _userRepository.GetAsync((long)input.UserId);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<PersonDto>(person);
        }
    }
}
