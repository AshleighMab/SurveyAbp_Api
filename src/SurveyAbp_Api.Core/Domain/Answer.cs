using Abp.Domain.Entities.Auditing;
using SurveyAbp_Api.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Domain
{
    [Entity(TypeShortAlias = "Surv.Answer")]
    public class Answer : FullAuditedEntity<Guid>
    {
        public virtual string AnswerText { get; set; }
        
        public virtual Question Question { get; set; }
    }
}
