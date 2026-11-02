using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class Language
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("iso639_2")]
    public string? Iso639_2 { get; set; }
}