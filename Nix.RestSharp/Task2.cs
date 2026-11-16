using Nix.RestSharp.Models;

namespace Nix.RestSharp;

public static class Task2
{
    public static async Task<(FormData? form, Dictionary<string, string> headers)> SendPostRequest(
    HttpBinApi api,
    FormData body,
    Dictionary<string, string> requestHeaders)
    {
        return await api.PostForm(body, requestHeaders);
    }  
}