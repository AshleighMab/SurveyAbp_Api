using AutoMapper;
using SurveyAbp_Api.Domain;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Answers
{
    public class AnswerMapProfile : Profile
    {
        public AnswerMapProfile()
        {
            CreateMap<Answer, AnswerDto>()
                .ForMember(e => e.QuestionId, m => m.MapFrom(e => e.Question != null && e.Question != null ? e.Question.Id : (Guid?)null));

            CreateMap<AnswerDto, Answer>()
                 .ForMember(e => e.Id, d => d.Ignore());


        }
    }
}
