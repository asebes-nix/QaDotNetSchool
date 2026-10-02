using OpenQA.Selenium;

namespace Nix.Selenium.Pages
{
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
    }
}
