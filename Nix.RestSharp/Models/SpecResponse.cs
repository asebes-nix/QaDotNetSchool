using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class SpecResponse
{
    [JsonPropertyName("paths")]
    public Dictionary<string, Dictionary<string, PathItem>>? Paths { get; set; }
}