using AutoMapper;
using SurveyAbp_Api.Domain;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Surveys
{
    public class SurveyMapProfile : Profile
    {

        public SurveyMapProfile()
        {

            CreateMap<Survey, SurveyDto>()
               .ForMember(e => e.PersonId, m => m.MapFrom(e => e.Person != null && e.Person != null ? e.Person.Id : (Guid?)null))
             .ForMember(e => e.ProductId, m => m.MapFrom(e => e.Product != null && e.Product != null ? e.Product.Id : (Guid?)null));

            CreateMap<SurveyDto, Survey>()
                 .ForMember(e => e.Id, d => d.Ignore());  

        }

    }
}
