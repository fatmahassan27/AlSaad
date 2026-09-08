using AlSaad.Application.Common.Configuration;
using Microsoft.Extensions.Options;

namespace AlSaad.API.Extentions
{
    public static class DaftraServiceCollectionExtensions
    {
        public static IServiceCollection AddDaftraHttpClient<TInterface, TImplementation>(this IServiceCollection services)
           where TInterface : class
           where TImplementation : class, TInterface
        {
            services.AddHttpClient<TInterface, TImplementation>((sp, client) =>
            {
                var settings = sp.GetRequiredService<IOptions<DaftraSettings>>().Value;
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("apikey", settings.ApiKey);
            });

            return services;
        }
    }
}
