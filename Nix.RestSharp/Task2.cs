using Nix.RestSharp.Models;

namespace Nix.RestSharp;

public static class Task2
{
    public static async Task<(FormData? form, Dictionary<string, string> headers)> SendPostRequest(
        FormData body,
        Dictionary<string, string> requestHeaders)
    {
        var api = new HttpBinApi();
        return await api.PostForm(body, requestHeaders);
    }
}