using System.Threading.Tasks;
using SurveyAbp_Api.Models.TokenAuth;
using SurveyAbp_Api.Web.Controllers;
using Shouldly;
using Xunit;

namespace SurveyAbp_Api.Web.Tests.Controllers
{
    public class HomeController_Tests: SurveyAbp_ApiWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}