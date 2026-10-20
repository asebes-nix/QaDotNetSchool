using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class HttpBinPostResponse
{
    [JsonPropertyName("form")]
    public Dictionary<string, string>? Form { get; set; }
}