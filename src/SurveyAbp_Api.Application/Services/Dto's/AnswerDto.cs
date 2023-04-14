using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using SurveyAbp_Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Dto_s
{
    public class AnswerDto: EntityDto<Guid>
    {
        public virtual string AnswerText { get; set; }

        public virtual Guid? QuestionId { get; set; }
    }
}
