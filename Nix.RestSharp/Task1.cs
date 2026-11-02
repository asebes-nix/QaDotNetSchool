using RestSharp;
using Nix.RestSharp.Models;

namespace Nix.RestSharp;

public static class Task1
{
    public static async Task<SpecResponse?> GetAllPaths()
    {
        var client = new RestClient("https://nghttp2.org/httpbin/");
        var request = new RestRequest("spec.json");
        var response = await client.ExecuteAsync(request);
        return client.Deserialize<SpecResponse>(response)?.Data;
    }

    public static List<string> CheckPaths(SpecResponse spec)
    {
        var results = new List<string>();

        foreach (var path in spec.Paths ?? [])
        {
            foreach (var method in path.Value)
            {
                var responses = method.Value.Responses;
                if (responses is null || !responses.ContainsKey("200"))
                    results.Add($"{method.Key.ToUpper()} {path.Key}");
            }
        }

        return results;
    }
}