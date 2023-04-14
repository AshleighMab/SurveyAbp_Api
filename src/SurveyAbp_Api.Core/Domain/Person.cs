using Abp.Domain.Entities.Auditing;
using SurveyAbp_Api.Authorization.Users;
using SurveyAbp_Api.Domain.Attributes;
using SurveyAbp_Api.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Domain
{
    [Entity(TypeShortAlias = "Surv.Person")]
    [Table("Surv_Persons")]
    [DiscriminatorValue("Surv.Person")]
    public class Person : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }

        public virtual RefListGender Gender {get; set;}
        public virtual string Phone { get; set; }

        public virtual User User { get; set; }
    }
}
