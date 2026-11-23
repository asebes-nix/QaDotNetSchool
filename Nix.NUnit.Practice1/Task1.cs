using Nix.NUnit.Practice1.Models;
using RestSharp;

namespace Nix.NUnit.Practice1;

public class Task1
{
    public const string BaseUrl = "https://httpbin.org";

    private readonly RestClient _client;

    public Task1()
    {
        _client = new RestClient(BaseUrl);
        _client.AddDefaultHeader("User-Agent", "Learning Automation");
    }

    public async Task<SpecResponse?> GetAllPaths()
    {
        var request = new RestRequest("spec.json");
        return await _client.GetAsync<SpecResponse>(request);
    }

    public static Dictionary<string, string> CheckPaths(SpecResponse spec)
    {
        var results = new Dictionary<string, string>();
        foreach (var path in spec.Paths ?? [])
            foreach (var method in path.Value)
            {
                var codes = method.Value.Responses?.Keys.ToList() ?? [];
                if (!codes.Contains("200"))
                    results[$"{method.Key.ToUpper()} \"{BaseUrl}{path.Key}\""] = string.Join(", ", codes);
            }
        return results;
    }
}