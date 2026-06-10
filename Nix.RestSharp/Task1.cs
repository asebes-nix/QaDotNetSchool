using RestSharp;
using System.Text.Json;

namespace Nix.RestSharp;

public static class Task1
{
    public static async Task<List<string>> GetAllPaths()
    {
        var client = new RestClient("https://nghttp2.org/httpbin/");
        var request = new RestRequest("spec.json");
        var response = await client.ExecuteAsync(request);

        var paths = new List<string>();
        var json = JsonDocument.Parse(response.Content);
        var pathsElement = json.RootElement.GetProperty("paths");

        foreach (var path in pathsElement.EnumerateObject())
        {
            if (!path.Name.Contains("{"))
                paths.Add(path.Name);
        }

        return paths;
    }

    public static async Task<Dictionary<string, int>> CheckPaths(List<string> paths)
    {
        var client = new RestClient("https://nghttp2.org/httpbin/");
        var results = new Dictionary<string, int>();

        foreach (var path in paths)
        {
            var request = new RestRequest(path, Method.Get);
            request.AddHeader("User-Agent", "Learning Automation");
            var response = await client.ExecuteAsync(request);

            if (response == null)
            {
                results[path] = -1;
                continue;
            }

            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                results[path] = statusCode;
            }
        }
        return results;
    }
}