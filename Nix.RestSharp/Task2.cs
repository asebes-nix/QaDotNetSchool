using Nix.RestSharp.Models;

namespace Nix.RestSharp;

public static class Task2
{
    public static async Task<(FormData? form, Dictionary<string, string> headers)> SendPostRequest(
        PostFormRequest body,
        Dictionary<string, string> requestHeaders)
    {
        var api = new HttpBinApi();
        var (parsed, response) = await api.PostForm(body, requestHeaders);

        var headerDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var h in response.ContentHeaders ?? [])
            headerDict[h.Name] = h.Value?.ToString() ?? string.Empty;
        return (parsed?.Form, headerDict);
    }
}