using System.ComponentModel.DataAnnotations;

namespace SurveyAbp_Api.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}