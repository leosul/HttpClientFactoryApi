using HttpClientFactoryApi.Application;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactoryApi.Controllers;

[ApiController]
[Route("api/repositories")]
public class GitHubController : Controller
{
    private readonly IGitHubService _gitHubService;

    public GitHubController(IGitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    [HttpGet]
    public async Task<IActionResult> GetrepositoriesAsync()
    {
        return Ok(await _gitHubService.GetGitHubAsync());
    }
}
