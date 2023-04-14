using Abp.Application.Services.Dto;
using SurveyAbp_Api.Authorization.Users;
using SurveyAbp_Api.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Dto_s
{
    public class PersonDto : EntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }

        public virtual RefListGender Gender { get; set; }
        public virtual string Phone { get; set; }

        public virtual long UserId { get; set; }
    }
}
