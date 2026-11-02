using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class ResponseInfo
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}