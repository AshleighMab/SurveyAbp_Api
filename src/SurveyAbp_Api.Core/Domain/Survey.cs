using Abp.Domain.Entities.Auditing;
using SurveyAbp_Api.Domain.Attributes;
using SurveyAbp_Api.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Domain
{
    [Entity(TypeShortAlias = "Surv.Survey")]
    public class Survey : FullAuditedEntity<Guid>
    {
        public virtual Person Person { get; set; }
        public virtual  Product Product { get; set; }
        public virtual int Rating { get; set; }
        public virtual IList<Question>? Questions { get; set; }  
        public virtual IList<Answer>? Answers { get; set; }  

    }
}
