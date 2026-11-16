namespace Nix.RestSharp.Models;

public class Country
{
    public List<Language>? Languages { get; set; }

    public long Population { get; set; }
}