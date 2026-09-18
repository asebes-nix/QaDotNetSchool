using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Nix.Selenium.Pages
{
    internal class InventoryPage(IWebDriver webDriver)
    {
        private IWebElement InventoryContainer => webDriver.FindElement(By.ClassName("inventory_container"));

        public bool IsInventoryContainerDisplayed()
        {
            return InventoryContainer.Displayed;
        }

        private IWebElement AddToCartButton(string productName)
        {
            string slug = productName.ToLower().Replace(" ", "-");
            return webDriver.FindElement(By.Id($"add-to-cart-{slug}"));
        }
        public InventoryPage AddProductToCart(string productName)
        {
            AddToCartButton(productName).Click();
            return this;
        }

        private IWebElement RemoveButton(string productName)
        {
            string slug = productName.ToLower().Replace(" ", "-");
            return webDriver.FindElement(By.Id($"remove-{slug}"));
        }
        public InventoryPage RemoveProductFromCart(string productName)
        {
            RemoveButton(productName).Click();
            return this;
        }

        public bool IsProductInCart(string productName)
        {
            string slug = productName.ToLower().Replace(" ", "-");
            return webDriver.FindElements(By.Id($"remove-{slug}")).Count > 0;
        }

        private SelectElement SortSelect => new(webDriver.FindElement(By.ClassName("product_sort_container")));

        public InventoryPage SortByLowToHigh()
        {
            SortSelect.SelectByValue("lohi");
            return this;
        }

        private IReadOnlyCollection<IWebElement> ProductPrices => webDriver.FindElements(By.CssSelector("[data-test='inventory-item-price']"));

        public List<decimal> GetDisplayedPrices()
        {
            return ProductPrices
                .Select(element => element.Text.Replace("$", ""))
                .Select(decimal.Parse)
                .ToList();
        }

        public int GetCartItemCount()
        {
            var badges = webDriver.FindElements(By.ClassName("shopping_cart_badge"));
            return badges.Count == 0 ? 0 : int.Parse(badges[0].Text);
        }
    }
}
