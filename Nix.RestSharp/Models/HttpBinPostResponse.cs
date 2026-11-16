using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class HttpBinPostResponse
{
    public FormData? Form { get; set; }
}

public class FormData
{
    [JsonPropertyName("custname")]
    public string? CustomerName { get; set; }

    [JsonPropertyName("custtel")]
    public string? CustomerTel { get; set; }

    [JsonPropertyName("custemail")]
    public string? CustomerEmail { get; set; }

    public string? Size { get; set; }

    [JsonPropertyName("topping")]
    public List<string>? Toppings { get; set; }

    public string? Delivery { get; set; }

    public string? Comments { get; set; }
}