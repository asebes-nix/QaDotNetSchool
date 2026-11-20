using RestSharp;

namespace Nix.NUnit.MathApi;

public class MathApiService
{
    public const string BaseUrl = "https://api.mathjs.org/v4/";

    private readonly RestClient _client;

    public MathApiService()
    {
        _client = new RestClient(BaseUrl);
        _client.AddDefaultHeader("User-Agent", "Learning Automation");
    }

    public async Task<string> PostExpressionAsync(string expr)
    {
        var request = new RestRequest();
        request.AddJsonBody(new { expr });

        var response = await _client.ExecutePostAsync<MathApiResponse>(request);

        Assert.That(response.IsSuccessful, Is.True, $"POST failed: {response.StatusCode}");
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data!.Result, Is.Not.Null);

        return response.Data!.Result!;
    }

    public async Task<string> GetExpressionAsync(string expr)
    {
        var request = new RestRequest();
        request.AddQueryParameter("expr", expr);

        var response = await _client.ExecuteAsync(request);

        Assert.That(response.IsSuccessful, Is.True, $"GET failed: {response.StatusCode}");
        Assert.That(response.Content, Is.Not.Null);

        return response.Content!.Trim();
    }
}