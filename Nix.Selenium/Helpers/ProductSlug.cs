namespace Nix.Selenium.Helpers;

internal static class ProductSlug
{
    public static string From(string productName)
    {
        return productName.ToLower().Replace(" ", "-");
    }
}