using Nix.RestSharp.Models;

namespace Nix.RestSharp;

public static class Task1
{
    public static async Task<SpecResponse?> GetAllPaths(HttpBinApi api)
    {
        return await api.GetSpec();
    }

    public static Dictionary<string, string> CheckPaths(SpecResponse spec)
    {
        var results = new Dictionary<string, string>();
        foreach (var path in spec.Paths ?? [])
            foreach (var method in path.Value)
            {
                var codes = method.Value.Responses?.Keys.ToList() ?? [];
                if (!codes.Contains("200"))
                    results[$"{method.Key.ToUpper()} {path.Key}"] = string.Join(", ", codes);
            }
        return results;
    }
}