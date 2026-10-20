using RestSharp;
using System.Text.Json;

namespace Nix.RestSharp;

public class CountriesApi
{
    private readonly RestClient _client;

    public CountriesApi()
    {
        _client = new RestClient("https://countries.dev/");
        _client.AddDefaultHeader("User-Agent", "Learning Automation");
    }

    private async Task<JsonDocument> FetchCountries()
    {
        var request = new RestRequest("countries");
        var response = await _client.ExecuteAsync(request);
        return JsonDocument.Parse(response.Content ?? "[]");
    }

    public async Task<List<string>> GetAllLanguages()
    {
        using var json = await FetchCountries();
        var languages = new List<string>();
        foreach (var country in json.RootElement.EnumerateArray())
        {
            if (country.TryGetProperty("languages", out var langs))
                foreach (var lang in langs.EnumerateArray())
                    if (lang.TryGetProperty("iso639_1", out var code))
                    {
                        var langCode = code.GetString();
                        if (!string.IsNullOrEmpty(langCode) && !languages.Contains(langCode))
                            languages.Add(langCode);
                    }
        }
        return languages;
    }

    public async Task<Dictionary<string, long>> GetPopulationByLanguage()
    {
        using var json = await FetchCountries();
        var result = new Dictionary<string, long>();
        foreach (var country in json.RootElement.EnumerateArray())
        {
            if (country.TryGetProperty("languages", out var langs)
                && country.TryGetProperty("population", out var population))
            {
                foreach (var lang in langs.EnumerateArray())
                    if (lang.TryGetProperty("iso639_1", out var code))
                    {
                        var langCode = code.GetString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(langCode))
                        {
                            if (!result.ContainsKey(langCode))
                                result[langCode] = 0;
                            result[langCode] += population.GetInt64();
                        }
                    }
            }
        }
        return result;
    }
}