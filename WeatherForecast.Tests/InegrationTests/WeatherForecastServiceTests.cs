using NUnit.Framework;
using WeatherForecast.Services;

namespace WeatherForecast.Tests.InegrationTests
{
    class WeatherForecastServiceTests
    {
        [Test]
        public void GetWeatherForecastJson_When_CityDoesntExist_Then_Return_Null()
        {
            //Arrange
            var service = new WeatherForecastProvider();
            //Act
            var result = service.GetWeatherForecastJson("", 7, "sssssssssssssss");
            //Assert
            Assert.That(result, Is.EqualTo(null));
        }
    }
}