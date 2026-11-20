using Nix.NUnit.Practice1.Models;
using RestSharp;

namespace Nix.NUnit.Practice1;

public class Task3
{
    private readonly RestClient _client;

    public Task3()
    {
        _client = new RestClient("https://countries.dev/");
        _client.AddDefaultHeader("User-Agent", "Learning Automation");
    }

    public async Task<List<Country>> GetAllCountries()
    {
        var request = new RestRequest("countries");
        return await _client.GetAsync<List<Country>>(request) ?? [];
    }

    public async Task<Dictionary<string, long>> GetPopulationByLanguage()
    {
        var countries = await GetAllCountries();
        var result = new Dictionary<string, long>();

        foreach (var country in countries)
        {
            foreach (var lang in country.Languages ?? [])
            {
                var code = lang.Iso639_1;
                if (string.IsNullOrEmpty(code)) continue;

                if (!result.ContainsKey(code))
                    result[code] = 0;
                result[code] += country.Population;
            }
        }

        return result;
    }
}