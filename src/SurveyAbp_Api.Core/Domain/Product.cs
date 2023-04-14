using Abp.Domain.Entities.Auditing;
using SurveyAbp_Api.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Domain
{

    [Entity(TypeShortAlias = "Surv.Product")]
    public class Product : FullAuditedEntity<Guid>
    {
        public virtual string Name {get; set;}
        public virtual string Description {get; set;}

    }
}
