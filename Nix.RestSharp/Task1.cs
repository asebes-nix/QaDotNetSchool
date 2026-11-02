using Nix.RestSharp.Models;

namespace Nix.RestSharp;

public static class Task1
{
    public static async Task<SpecResponse?> GetAllPaths()
    {
        var api = new HttpBinApi();
        return await api.GetSpec();
    }

    public static List<string> CheckPaths(SpecResponse spec)
    {
        var results = new List<string>();
        foreach (var path in spec.Paths ?? [])
            foreach (var method in path.Value)
            {
                var responses = method.Value.Responses;
                if (responses is null || !responses.ContainsKey("200"))
                    results.Add($"{method.Key.ToUpper()} {path.Key}");
            }
        return results;
    }
}