using RestSharp;
using Nix.RestSharp.Models;
using System.Text.Json;

namespace Nix.RestSharp;

public static class Task1
{
    public static async Task<SpecResponse?> GetAllPaths()
    {
        var client = new RestClient("https://nghttp2.org/httpbin/");
        var request = new RestRequest("spec.json");
        var response = await client.ExecuteAsync(request);
        return JsonSerializer.Deserialize<SpecResponse>(response.Content ?? "{}");
    }

    public static async Task<Dictionary<string, int>> CheckPaths(SpecResponse spec)
    {
        var client = new RestClient("https://nghttp2.org/httpbin/");
        client.AddDefaultHeader("User-Agent", "Learning Automation");
        var results = new Dictionary<string, int>();

        foreach (var path in spec.Paths!)
        {
            foreach (var method in path.Value.EnumerateObject())
            {
                var httpMethod = method.Name.ToLower() switch
                {
                    "get" => Method.Get,
                    "post" => Method.Post,
                    "put" => Method.Put,
                    "delete" => Method.Delete,
                    "patch" => Method.Patch,
                    _ => Method.Get
                };

                var request = new RestRequest(path.Key, httpMethod);
                var response = await client.ExecuteAsync(request);
                var statusCode = (int)response.StatusCode;
                if (statusCode != 200)
                {
                    results[$"{method.Name.ToUpper()} {path.Key}"] = statusCode;
                }
            }
        }
        return results;
    }
}