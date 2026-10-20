using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class SpecResponse
{
    [JsonPropertyName("paths")]
    public Dictionary<string, JsonElement>? Paths { get; set; }
}