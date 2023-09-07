using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Dtos;
public class ResponseApi
{
    public List<Data> Data { get; set; }
    public string Message { get; set; }
    public int statusCode { get; set; } = 200;
}
public class Data
{
    public int CityId { get; set; }
    public string CityName { get; set; }
    public string WeatherMain { get; set; }
    public string WeatherDescription { get; set; }
    public string WeatherIcon { get; set; }
    public decimal MainTemp { get; set; }
    public decimal MainHumidity { get; set;}
}
