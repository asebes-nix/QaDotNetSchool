using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class PathItem
{
    [JsonPropertyName("responses")]
    public Dictionary<string, ResponseInfo>? Responses { get; set; }
}