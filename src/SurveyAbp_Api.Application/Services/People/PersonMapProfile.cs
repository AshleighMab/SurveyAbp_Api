using AutoMapper;
using SurveyAbp_Api.Domain;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.People
{
    public class PersonMapProfile : Profile
    {
        public PersonMapProfile()
        {
            CreateMap<Person, PersonDto>()
             .ForMember(e => e.UserId, m => m.MapFrom(e => e.User != null && e.User != null ? e.User.Id : (long?)null));

            CreateMap<PersonDto, Person>()
             .ForMember(e => e.Id, d => d.Ignore());


        }
    }
}
