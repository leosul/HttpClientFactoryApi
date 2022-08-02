using HttpClientFactoryApi.Application;

namespace HttpClientFactoryApi.Configuration;

public static class HttpClientFactoryConfig
{
    public static IServiceCollection AddHttpConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IGitHubService, GitHubService>("GitHub", client =>
        {
            client.BaseAddress = new Uri(configuration["GitHubUrl"]);
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
        });

        return services;
    }
}
