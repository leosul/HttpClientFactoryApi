using System.Text.Json;

namespace HttpClientFactoryApi.Application;

public class GitHubService : IGitHubService
{
    //PROPRIEDADE PRIVADA PARA SER USADA NA INJEÇÃO DE DEPENDÊNCIA
    private readonly IHttpClientFactory _httpClientFactory;

    //INJEÇÃO DE DEPENDÊNCIA DA INTERFACE
    public GitHubService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Root>> GetGitHubAsync()
    {
        //CRIAÇÃO DO CLIENT PASSANDO O NOME COFIGURADO EM 'HttpClientFactoryConfig' E COMPLEMENTANDO
        //COM A REQUEST URI
        var response = await _httpClientFactory.CreateClient("GitHub").GetAsync("users/leosul/repos");

        //DESERIALIZANDO O OBJETO DE RESPOSTA DO GITHUB
        return await DeserializarObjetoResponse<IEnumerable<Root>>(response);
    }

    //MÉTODO AUXILIAR CRIADO PARA A DESERIALIZAÇÃO
    protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsByteArrayAsync(), options);
    }
}
