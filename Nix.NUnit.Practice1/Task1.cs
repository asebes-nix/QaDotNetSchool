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

    public async Task<Dictionary<string, int[]>> CheckPaths(SpecResponse spec)
    {
        var results = new Dictionary<string, int[]>();

        foreach (var path in spec.Paths ?? [])
        {
            if (path.Key.Contains('{'))
                continue;

            var methodResults = new List<int>();
            foreach (var method in path.Value)
            {
                var request = new RestRequest(path.Key, Enum.Parse<Method>(method.Key, true));
                var response = await _client.ExecuteAsync(request);
                var statusCode = (int)response.StatusCode;
                if (statusCode != 200)
                    methodResults.Add(statusCode);
            }

            if (methodResults.Count > 0)
                results[path.Key] = [.. methodResults];
        }

        return results;
    }
}