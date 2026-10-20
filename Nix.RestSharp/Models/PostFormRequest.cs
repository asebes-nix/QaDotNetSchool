using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class PostFormRequest
{
    [JsonPropertyName("custname")]
    public string? CustomerName { get; set; }

    [JsonPropertyName("custtel")]
    public string? CustomerTel { get; set; }

    [JsonPropertyName("custemail")]
    public string? CustomerEmail { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("topping")]
    public List<string>? Toppings { get; set; }

    [JsonPropertyName("delivery")]
    public string? Delivery { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }
}
    