using Nix.RestSharp.Models;
using RestSharp;
using System.Text.Json;

namespace Nix.RestSharp;

public class HttpBinApi
{
    private readonly RestClient _client;

    public HttpBinApi()
    {
        _client = new RestClient("https://nghttp2.org/httpbin/");
        _client.AddDefaultHeader("User-Agent", "Learning Automation");
    }

    public async Task<SpecResponse?> GetSpec()
    {
        var request = new RestRequest("spec.json");
        var response = await _client.ExecuteAsync(request);
        return response.Content != null
            ? JsonSerializer.Deserialize<SpecResponse>(response.Content)
            : null;
    }

    public async Task<(HttpBinPostResponse? data, RestResponse response)> PostForm(
    PostFormRequest body,
    Dictionary<string, string> headers)
    {
        var request = new RestRequest("post", Method.Post);
        request.AddHeaders(headers);
        request.AddParameter("custname", body.CustomerName);
        request.AddParameter("custtel", body.CustomerTel);
        request.AddParameter("custemail", body.CustomerEmail);
        request.AddParameter("size", body.Size);
        request.AddParameter("delivery", body.Delivery);
        request.AddParameter("comments", body.Comments);
        foreach (var topping in body.Toppings ?? [])
            request.AddParameter("topping", topping);

        var response = await _client.ExecuteAsync(request);
        var parsed = response.Content != null
            ? JsonSerializer.Deserialize<HttpBinPostResponse>(response.Content)
            : null;
        return (parsed, response);
    }
}