using System.Text.Json.Serialization;

namespace Nix.NUnit.Practice1.Models;

public class HttpBinPostResponse
{
    [JsonPropertyName("form")]
    public Dictionary<string, string>? Form { get; set; }
}