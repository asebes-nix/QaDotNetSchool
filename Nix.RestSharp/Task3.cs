using RestSharp;
using System.Text.Json;

namespace Nix.RestSharp;

public static class Task3
{
    //Task 3.1
    public static async Task<List<string>> GetAllLanguages()
    {
        var client = new RestClient("https://restcountries.com/v3/");
        var request = new RestRequest("all");
        request.AddQueryParameter("fields", "languages,population");
        var response = await client.ExecuteAsync(request);
        var languages = new List<string>();
        var json = JsonDocument.Parse(response.Content);
        var countries = json.RootElement.EnumerateArray();
        foreach (var country in countries)
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

    //Task 3.2
    public static async Task<Dictionary<string, long>> GetPopulationByLanguage(List<string> languageCodes)
    {
        var client = new RestClient("https://restcountries.com/v3/");
        var request = new RestRequest("all");
        request.AddQueryParameter("fields", "languages,population");
        var response = await client.ExecuteAsync(request);
        var populationByLanguage = new Dictionary<string, long>();
        var json = JsonDocument.Parse(response.Content);
        var countries = json.RootElement.EnumerateArray();
        foreach (var country in countries)
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