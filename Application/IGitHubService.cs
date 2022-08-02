namespace HttpClientFactoryApi.Application;

public interface IGitHubService
{
    Task<IEnumerable<Root>> GetGitHubAsync();
}
