using Microsoft.Extensions.Logging.Abstractions;
using WebAPI.Template.API.Controllers;
using WebAPI.Template.Models;

namespace WebAPI.Template.API.Tests
{
    public class WeatherForecastControllerTests
    {
        private WeatherForecastController CreateController()
        {
            return new WeatherForecastController(NullLogger<WeatherForecastController>.Instance);
        }

        [Fact]
        public void Get_returns_a_Collection_of_WeatherForecasts()
        {
            //Arrange
            var controller = CreateController();

            //Act
            var result = controller.Get();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
        }

        [Fact]
        public void Get_returns_all_summary_in_expected_range()
        {
            //Arrange
            var controller = CreateController();

            //Act
            var result = controller.Get();

            //Assert
            foreach(var forecast in result)
            {
                Assert.NotNull(forecast.Summary);
                Assert.Contains(forecast.Summary, WeatherForecastController.Summaries);
            }
        }

        [Fact]
        public void Get_returns_between_one_and_five_forecasts()
        {
            //Arrange
            var controller = CreateController();

            //Act
            var result = controller.Get();

            //Assert
            Assert.InRange(result.Count(), 1, 5);
        }

    }
}