using Microsoft.Extensions.Configuration;
using System;

namespace AlumnosService.API.Extensions
{
    public static class ApiExtensions
    {
        public static Uri ToServiceName(this string name)
        {
            return new Uri($"http://{name}");
        }

        public static Uri GetMicroserviceUrl(this IConfiguration Configuration, string ServiceName)
        {
            return Configuration[$"Microservices:{ServiceName}"].ToServiceName();
        }
    }
}
