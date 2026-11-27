using Nix.NUnit.Practice1.Models;
using RestSharp;

namespace Nix.NUnit.Practice1;

public class Task2
{
    public const string BaseUrl = "https://httpbin.org";

    private readonly RestClient _client;

    public Task2()
    {
        _client = new RestClient(BaseUrl);
        _client.AddDefaultHeader("User-Agent", "Learning Automation");
    }

    public async Task<(FormData? form, Dictionary<string, string> headers)> SendPostRequest(
        FormData body,
        Dictionary<string, string> requestHeaders)
    {
        var request = new RestRequest("post", Method.Post);
        request.AddHeaders(requestHeaders);
        request.AddParameter("custname", body.CustomerName);
        request.AddParameter("custtel", body.CustomerTel);
        request.AddParameter("custemail", body.CustomerEmail);
        request.AddParameter("size", body.Size);
        request.AddParameter("delivery", body.Delivery);
        request.AddParameter("comments", body.Comments);
        foreach (var topping in body.Toppings ?? [])
            request.AddParameter("topping", topping);

        var response = await _client.ExecutePostAsync<HttpBinPostResponse>(request);
        if (!response.IsSuccessful)
            throw new HttpRequestException($"POST /post failed with {response.StatusCode}", response.ErrorException);

        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var h in response.Headers ?? [])
            headers[h.Name] = h.Value?.ToString() ?? string.Empty;
        foreach (var h in response.ContentHeaders ?? [])
            headers[h.Name] = h.Value?.ToString() ?? string.Empty;

        return (response.Data?.Form, headers);
    }
}