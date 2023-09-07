using Application.Contracts.Dtos;
using Application.Contracts.Services;
using AutoMapper;
using Domain.Shared.Services;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Services;
public class WeatherService : IWeatherService
{
    private readonly IApiClientService _IApiClientService;
    private readonly IMapper _iMapper;
    public WeatherService(IApiClientService apiClientService,
                          IMapper mapper)
    {
        _IApiClientService = apiClientService;
        _iMapper = mapper;
    }
    public async Task<ResponseApi> GetInformationAsync()
    {
        try
        {
            var url = "http://api.openweathermap.org/data/2.5/group?id=1580578,1581129,1581297,1581188,1587923&units=metric&appid=91b7466cc755db1a94caf6d86a9c788a";
            var apiClient = await _IApiClientService.FetchAsync(url, string.Empty, string.Empty, "GET", string.Empty);
            if (apiClient.IsSuccessStatusCode)
            {
                var response = await apiClient.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherResponseDto>(response);
                if (result.List.Any())
                {
                    var data = _iMapper.Map<List<Data>>(result.List);
                    return new ResponseApi
                    {
                        Data = data,
                        Message = "Current weather information of cities",
                        statusCode = 200
                    };
                }
                return new ResponseApi();
            }
            throw new Exception("Can not fetch api");
        } 
        catch (Exception ex)
        {
            throw ex;

        }
    }
}
