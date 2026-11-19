using Nix.RestSharp.Models;
using RestSharp;

namespace Nix.RestSharp;

public class HttpBinApi
{
    public const string BaseUrl = "https://httpbin.org";

    private readonly RestClient _client;

    public HttpBinApi()
    {
        _client = new RestClient(BaseUrl);
        _client.AddDefaultHeader("User-Agent", "Learning Automation");
    }

    public async Task<SpecResponse?> GetSpec()
    {
        var request = new RestRequest("spec.json");
        return await _client.GetAsync<SpecResponse>(request);
    }

    public async Task<(FormData? form, Dictionary<string, string> headers)> PostForm(
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
            headers[h.Name] = h.Value;
        foreach (var h in response.ContentHeaders ?? [])
            headers[h.Name] = h.Value;

        return (response.Data?.Form, headers);
    }
}