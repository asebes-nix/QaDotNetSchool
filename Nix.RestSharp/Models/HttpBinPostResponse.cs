using System.Text.Json.Serialization;

namespace Nix.RestSharp.Models;

public class HttpBinPostResponse
{
    [JsonPropertyName("form")]
    public FormData? Form { get; set; }
}

public class FormData
{
    [JsonPropertyName("customerName")]
    public string? CustomerName { get; set; }

    [JsonPropertyName("customerTel")]
    public string? CustomerTel { get; set; }

    [JsonPropertyName("customerEmail")]
    public string? CustomerEmail { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("toppings")]
    public string? Toppings { get; set; }

    [JsonPropertyName("delivery")]
    public string? Delivery { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }
}