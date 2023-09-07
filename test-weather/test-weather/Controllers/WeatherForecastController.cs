using Application.Contracts.Dtos;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace test_weather.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _iWeatherService;
    public WeatherForecastController(IWeatherService weatherService)
    {
        _iWeatherService = weatherService;
    }
    [HttpGet]
    public async Task<ResponseApi> GetWeatherAsync()
    {
        return await _iWeatherService.GetInformationAsync();
    }
}
