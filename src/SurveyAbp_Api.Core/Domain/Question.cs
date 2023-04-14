using Abp.Domain.Entities.Auditing;
using SurveyAbp_Api.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Domain
{

    [Entity(TypeShortAlias = "Surv.Question")]
    public class Question : FullAuditedEntity<Guid>
    {
        public virtual string QuestionText { get;set; }
    
}
}
