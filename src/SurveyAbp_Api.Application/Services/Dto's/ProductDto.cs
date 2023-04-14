using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Dto_s
{
    public class ProductDto: EntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
