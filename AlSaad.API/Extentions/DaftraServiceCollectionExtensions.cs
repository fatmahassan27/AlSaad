using AlSaad.Application.Common.Configuration;
using Microsoft.Extensions.Options;

namespace AlSaad.API.Extentions
{
    public static class DaftraServiceCollectionExtensions
    {
        public static IServiceCollection AddDaftraHttpClient<TInterface, TImplementation>(
            this IServiceCollection services,
            Func<DaftraSettings, string>? baseUrlSelector = null)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            baseUrlSelector ??= settings => settings.BaseUrl;
            services.AddHttpClient<TInterface, TImplementation>((sp, client) =>
            {
                var settings = sp.GetRequiredService<IOptions<DaftraSettings>>().Value;
                client.BaseAddress = new Uri(baseUrlSelector(settings));
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("apikey", settings.ApiKey);
            });

            return services;
        }
    }
}
