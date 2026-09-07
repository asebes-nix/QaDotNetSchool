using RestSharp;
using System;
using System.Text.Json;

namespace Nix.RestSharp;

public static class Task3
{
    private static async Task<JsonDocument> FetchCountries()
    {
        var client = new RestClient("https://countries.dev/");
        var request = new RestRequest("countries");
        request.AddHeader("User-Agent", "Learning Automation");
        var response = await client.ExecuteAsync(request);
        return JsonDocument.Parse(response.Content ?? "[]");
    }

    public static async Task<List<string>> GetAllLanguages()
    {
        using var json = await FetchCountries();
        var languages = new List<string>();
        foreach (var country in json.RootElement.EnumerateArray())
        {
            if (country.TryGetProperty("languages", out var langs))
            {
                foreach (var lang in langs.EnumerateArray())
                {
                    if (lang.TryGetProperty("iso639_1", out var code))
                    {
                        var langCode = code.GetString();
                        if (!string.IsNullOrEmpty(langCode) && !languages.Contains(langCode))
                            languages.Add(langCode);
                    }
                }
            }
        }
        return languages;
    }

    public static async Task<Dictionary<string, long>> GetPopulationByLanguage()
    {
        using var json = await FetchCountries();
        var populationByLanguage = new Dictionary<string, long>();
        foreach (var country in json.RootElement.EnumerateArray())
        {
            if (country.TryGetProperty("languages", out var langs)
                && country.TryGetProperty("population", out var population))
            {
                foreach (var lang in langs.EnumerateArray())
                {
                    if (lang.TryGetProperty("iso639_1", out var code))
                    {
                        var langCode = code.GetString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(langCode))
                        {
                            if (!populationByLanguage.ContainsKey(langCode))
                                populationByLanguage[langCode] = 0;
                            populationByLanguage[langCode] += population.GetInt64();
                        }
                    }
                }
            }
        }
        return populationByLanguage;
    }
}