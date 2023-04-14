using SurveyAbp_Api.Debugging;

namespace SurveyAbp_Api
{
    public class SurveyAbp_ApiConsts
    {
        public const string LocalizationSourceName = "SurveyAbp_Api";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7940865c9a05492faa1df8326212b9d1";
    }
}
