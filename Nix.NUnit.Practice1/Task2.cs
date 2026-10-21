using Nix.NUnit.Practice1.Models;
using RestSharp;
using System.Text.Json;

namespace Nix.NUnit.Practice1;

public static class Task2
{
    public static async Task<(Dictionary<string, string> form, Dictionary<string, string> headers)> SendPostRequest(
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
        var formDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var headerDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        var parsed = client.Deserialize<HttpBinPostResponse>(response);
        if (parsed?.Data?.Form is not null)
            formDict = parsed.Data.Form;

        var parsedForHeaders = JsonSerializer.Deserialize<JsonElement>(response.Content ?? "{}");
        if (parsedForHeaders.TryGetProperty("headers", out var headersElement))
        {
            foreach (var h in headersElement.EnumerateObject())
                headerDict[h.Name] = h.Value.GetString() ?? string.Empty;
        }

        return (formDict, headerDict);
    }
}