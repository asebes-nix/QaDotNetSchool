using Nix.RestSharp.Models;
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

    public async Task<List<Country>> GetCountries()
    {
        var request = new RestRequest("countries");
        var response = await _client.ExecuteAsync(request);
        return response.Content != null
            ? JsonSerializer.Deserialize<List<Country>>(response.Content) ?? []
            : [];
    }

    public async Task<List<Country>> GetCountriesByLanguage(string lang)
    {
        var request = new RestRequest($"lang/{lang}");
        var response = await _client.ExecuteAsync(request);
        return response.Content != null
            ? JsonSerializer.Deserialize<List<Country>>(response.Content) ?? []
            : [];
    }
}