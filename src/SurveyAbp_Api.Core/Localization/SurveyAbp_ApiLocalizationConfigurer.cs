using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SurveyAbp_Api.Localization
{
    public static class SurveyAbp_ApiLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SurveyAbp_ApiConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SurveyAbp_ApiLocalizationConfigurer).GetAssembly(),
                        "SurveyAbp_Api.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
