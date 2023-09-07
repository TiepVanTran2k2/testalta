using Domain.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services;
public class ApiClientService : IApiClientService
{
    private readonly IHttpClientFactory _iHttpClientFactory;
    public ApiClientService(IHttpClientFactory iHttpClientFactory)
    {
        _iHttpClientFactory = iHttpClientFactory;
    }
    public async Task<HttpResponseMessage> FetchAsync(string baseUrl, string operation, string payload, string method, string authorization = "")
    {
        HttpResponseMessage response = null;
        using (var client = _iHttpClientFactory.CreateClient("ApiClient"))
        using (var httpContent = new StringContent(payload, Encoding.UTF8, "application/json"))
        {
            if (!string.IsNullOrEmpty(authorization))
            {
                client.DefaultRequestHeaders.Add("Authorization", authorization);
            }
            client.BaseAddress = new Uri(baseUrl);
            switch (method.ToUpper())
            {
                case "GET":
                    response = await client.GetAsync(operation);
                    break;
                case "POST":
                    response = await client.PostAsync(operation, httpContent);
                    break;
                case "PUT":
                    response = await client.PutAsync(operation, httpContent);
                    break;
                default:
                    break;
            };
        }
        if (response is { IsSuccessStatusCode: true })
        {
            response.EnsureSuccessStatusCode();
            return response;
        }
        else
        {
            return response;
        }
    }
}
