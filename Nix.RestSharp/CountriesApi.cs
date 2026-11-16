using Nix.RestSharp.Models;
using RestSharp;

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
        return await _client.GetAsync<List<Country>>(request) ?? [];
    }

    public async Task<List<Country>> GetCountriesByLanguage(string lang)
    {
        var request = new RestRequest($"lang/{lang}");
        return await _client.GetAsync<List<Country>>(request) ?? [];
    }
}