using Abp.Application.Services.Dto;
using SurveyAbp_Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Dto_s
{
    public class SurveyDto : EntityDto<Guid>
    {
        public virtual Guid? PersonId { get; set; }
        public virtual Guid? ProductId { get; set; }
        public virtual int Rating { get; set; }
        public virtual IList<Question> Questions { get; set; }
        public virtual IList<Answer> Answers { get; set; }
    }
}
