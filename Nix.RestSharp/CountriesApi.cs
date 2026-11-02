using RestSharp;
using Nix.RestSharp.Models;

namespace Nix.RestSharp;

public class CountriesApi
{
    private readonly RestClient _client;

    public CountriesApi()
    {
        _client = new RestClient("https://countries.dev/");
        _client.AddDefaultHeader("User-Agent", "Learning Automation");
    }

    public async Task<List<Country>> GetCountries()
    {
        var request = new RestRequest("countries");
        var response = await _client.ExecuteAsync(request);
        return _client.Deserialize<List<Country>>(response)?.Data ?? [];
    }

    public async Task<List<string>> GetAllLanguages()
    {
        var countries = await GetCountries();
        return countries
            .Where(c => c.Languages != null)
            .SelectMany(c => c.Languages!.Keys)
            .Distinct()
            .ToList();
    }

    public async Task<Dictionary<string, long>> GetPopulationByLanguage()
    {
        var languages = await GetAllLanguages();
        var result = new Dictionary<string, long>();

        foreach (var lang in languages)
        {
            var request = new RestRequest($"lang/{lang}");
            var response = await _client.ExecuteAsync(request);
            var countries = _client.Deserialize<List<Country>>(response)?.Data ?? [];
            result[lang] = countries.Sum(c => c.Population);
        }

        return result;
    }
}