using AutoMapper;
using SurveyAbp_Api.Domain;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Questions
{
    public class QuestionMapProfile : Profile
    {
        public QuestionMapProfile()
        {
            CreateMap<Question, QuestionDto>();
               

            CreateMap<QuestionDto, Question>()
                  .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
