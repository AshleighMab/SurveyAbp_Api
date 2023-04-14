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
    public class QuestionDto : EntityDto<Guid>
    {
        public virtual string QuestionText { get; set; }
        
    }
}
