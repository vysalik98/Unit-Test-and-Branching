using CalculatorAPIs.Controllers;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace CalculatorAPIs
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void WeatherForecastController_Get_Success()
        {
            var logger = A.Fake<ILogger<WeatherForecastController>>();

            var controller = new WeatherForecastController(logger);

            var response = controller.Get();

            var content = response.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeOfType<WeatherForecast[]>().Subject;
            content.Should().HaveCount(5);
        }

    }
}