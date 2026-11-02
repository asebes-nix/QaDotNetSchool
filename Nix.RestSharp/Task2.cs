using RestSharp;
using Nix.RestSharp.Models;

namespace Nix.RestSharp;

public static class Task2
{
    public static async Task<(FormData? form, Dictionary<string, string> headers)> SendPostRequest(
        PostFormRequest body,
        Dictionary<string, string> requestHeaders)
    {
        var client = new RestClient("https://nghttp2.org/httpbin/");
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

        var response = await client.ExecuteAsync(request);
        var parsed = client.Deserialize<HttpBinPostResponse>(response);

        var headerDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var h in response.ContentHeaders ?? [])
            headerDict[h.Name ?? string.Empty] = h.Value?.ToString() ?? string.Empty;

        return (parsed?.Data?.Form, headerDict);
    }
}