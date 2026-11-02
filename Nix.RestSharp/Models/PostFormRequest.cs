namespace Nix.RestSharp.Models;

public class PostFormRequest
{
    public string? CustomerName { get; set; }
    public string? CustomerTel { get; set; }
    public string? CustomerEmail { get; set; }
    public string? Size { get; set; }
    public List<string>? Toppings { get; set; }
    public string? Delivery { get; set; }
    public string? Comments { get; set; }
}