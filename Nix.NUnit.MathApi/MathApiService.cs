using Nix.NUnit.MathApi.Models;
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

    public async Task<RestResponse<MathApiResponse>> PostExpressionAsync(string expr)
    {
        var request = new RestRequest();
        request.AddJsonBody(new { expr });
        return await _client.ExecutePostAsync<MathApiResponse>(request);
    }

    public async Task<RestResponse> GetExpressionAsync(string expr)
    {
        var request = new RestRequest();
        request.AddQueryParameter("expr", expr);
        return await _client.ExecuteAsync(request);
    }
}