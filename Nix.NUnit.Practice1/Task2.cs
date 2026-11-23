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

    public async Task<(PostFormRequest? form, Dictionary<string, string> headers)> SendPostRequest(
    PostFormRequest body,
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

        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var h in response.Headers ?? [])
            headers[h.Name] = h.Value?.ToString() ?? string.Empty;

        // httpbin echoes request headers in JSON body under "headers" key
        if (response.Data?.Headers is not null)
            foreach (var h in response.Data.Headers)
                headers[h.Key] = h.Value;

        return (response.Data?.Form, headers);
    }
}