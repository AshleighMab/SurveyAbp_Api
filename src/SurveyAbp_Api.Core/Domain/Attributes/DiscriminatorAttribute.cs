using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Domain.Attributes
{
    public class DiscriminatorAttribute : Attribute
    {
        //discriminator column in the person table
        public string DiscriminatorColumn { get; set; }
        public bool UseDiscriminator { get; set; }
        public bool FilterUnknownDiscriminators { get; set; }
        public DiscriminatorAttribute()
        {
            DiscriminatorColumn = "Frwk_Discriminator";
            UseDiscriminator = true;
            FilterUnknownDiscriminators = false;
        }
    }
}