using Nix.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Nix.Selenium.Pages;

internal class CartPage(IWebDriver webDriver)
{
    private IReadOnlyCollection<IWebElement> ProductNames => webDriver.FindElements(By.CssSelector("[data-test='inventory-item-name']"));

    public bool IsProductListed(string productName)
    {
        return ProductNames.Any(element => element.Text == productName);
    }

    public decimal GetProductPrice(string productName)
    {
        var names = ProductNames.Select(element => element.Text).ToList();
        var prices = webDriver.FindElements(By.CssSelector("[data-test='inventory-item-price']"))
            .Select(element => decimal.Parse(element.Text.Replace("$", "")))
            .ToList();
        int index = names.IndexOf(productName);
        return prices[index];
    }

    private IWebElement CheckoutButton => webDriver.FindElement(By.Id("checkout"));

    public CheckoutStepOnePage ClickCheckout()
    {
        CheckoutButton.Click();
        return new CheckoutStepOnePage(webDriver);
    }

    private IWebElement RemoveButton(string productName)
    {
        return webDriver.FindElement(By.Id($"remove-{ProductSlug.From(productName)}"));
    }

    public CartPage RemoveProduct(string productName)
    {
        RemoveButton(productName).Click();
        return this;
    }

    public int GetCartItemCount()
    {
        var badges = webDriver.FindElements(By.ClassName("shopping_cart_badge"));
        return badges.Count == 0 ? 0 : int.Parse(badges[0].Text);
    }

    private IWebElement ContinueShoppingButton => webDriver.FindElement(By.Id("continue-shopping"));

    public InventoryPage ClickContinueShopping()
    {
        ContinueShoppingButton.Click();
        new WebDriverWait(webDriver, TimeSpan.FromSeconds(5))
            .Until(driver => driver.FindElement(By.ClassName("inventory_container")).Displayed);
        return new InventoryPage(webDriver);
    }
}