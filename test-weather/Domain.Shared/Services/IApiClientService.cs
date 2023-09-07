using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Services;
public interface IApiClientService
{
    Task<HttpResponseMessage> FetchAsync(string baseUrl, string operation, string payload, string method, string authorization = "");
}
