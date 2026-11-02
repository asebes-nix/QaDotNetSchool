using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class Country
{
    [JsonPropertyName("languages")]
    public Dictionary<string, string>? Languages { get; set; }

    [JsonPropertyName("population")]
    public long Population { get; set; }
}