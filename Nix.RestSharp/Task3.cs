using RestSharp;
using System.Text.Json;

namespace Nix.RestSharp;

public static class Task3
{
    private static async Task<JsonDocument> FetchCountries()
    {
        var client = new RestClient("https://restcountries.com/");
        var request = new RestRequest("v3.1/all");
        request.AddQueryParameter("fields", "languages,population");
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
                foreach (var lang in langs.EnumerateObject())
                {
                    if (!languages.Contains(lang.Name))
                        languages.Add(lang.Name);
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
            if (country.TryGetProperty("languages", out var langs) && country.TryGetProperty("population", out var population))
            {
                foreach (var lang in langs.EnumerateObject())
                {
                    if (!populationByLanguage.ContainsKey(lang.Name))
                        populationByLanguage[lang.Name] = 0;
                    populationByLanguage[lang.Name] += population.GetInt64();
                }
            }
        }
        return populationByLanguage;
    }
}