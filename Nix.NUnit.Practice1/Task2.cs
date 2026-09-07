using RestSharp;
using System.Text.Json;

namespace Nix.NUnit.Practice1;

public static class Task2
{
    public static async Task<(Dictionary<string, string> form, Dictionary<string, string> headers)> SendPostRequest(
        Dictionary<string, string> body,
        Dictionary<string, string> headers)
    {
        var client = new RestClient("https://nghttp2.org/httpbin/");
        var request = new RestRequest("post", Method.Post);
        request.AddHeader("User-Agent", "Learning Automation");

        foreach (var kv in headers)
        {
            request.AddHeader(kv.Key, kv.Value);
        }

        if (body is not null)
        {
            foreach (var kv in body)
            {
                request.AddParameter(kv.Key, kv.Value ?? string.Empty);
            }
        }

        var response = await client.ExecuteAsync(request);

        var formDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var headerDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        using var doc = JsonDocument.Parse(response.Content);
        if (doc.RootElement.TryGetProperty("form", out var formElement) && formElement.ValueKind == JsonValueKind.Object)
        {
            foreach (var prop in formElement.EnumerateObject())
                formDict[prop.Name] = prop.Value.GetString() ?? string.Empty;
        }

        if (doc.RootElement.TryGetProperty("headers", out var headersElement))
        {
            foreach (var prop in headersElement.EnumerateObject())
                headerDict[prop.Name] = prop.Value.GetString() ?? string.Empty;
        }

        return (formDict, headerDict);
    }
}