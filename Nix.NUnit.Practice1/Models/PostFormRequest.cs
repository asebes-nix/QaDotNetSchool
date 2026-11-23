using System.Text.Json.Serialization;

namespace Nix.NUnit.Practice1.Models;

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


    public override bool Equals(object? obj)
    {
        if (obj is not PostFormRequest other) return false;
        return CustomerName == other.CustomerName
            && CustomerTel == other.CustomerTel
            && CustomerEmail == other.CustomerEmail
            && Size == other.Size
            && Delivery == other.Delivery
            && Comments == other.Comments;
    }

    public override int GetHashCode() =>
        HashCode.Combine(CustomerName, CustomerTel, CustomerEmail, Size, Delivery, Comments);
}
