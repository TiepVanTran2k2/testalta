using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Contracts.Dtos;
public class WeatherResponseDto
{
    [JsonPropertyName("list")]
    public List<WeatherDetailResponseDto> List { get; set; }
}
public class WeatherDetailResponseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("main")]
    public MainDto Main { get; set; }
    [JsonPropertyName("weather")]
    public List<WeatherDto> Weather { get; set; }

}
public class MainDto
{
    [JsonPropertyName("temp")]
    public decimal Temp { get; set; }
    [JsonPropertyName("humidity")]
    public decimal Humidity { get; set; }
}
public class WeatherDto
{
    [JsonPropertyName("main")]
    public string Main { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("icon")]
    public string ICon { get; set; }
}
