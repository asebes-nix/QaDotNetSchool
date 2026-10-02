using Nix.Selenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Nix.Selenium.Tests
{
    internal class Task2Tests
    {
        private IWebDriver driver;
        private InventoryPage inventoryPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            new LoginPage(driver)
                .EnterUsername("standard_user")
                .EnterPassword("secret_sauce")
                .ClickLoginButton();

            inventoryPage = new InventoryPage(driver);
        }

        [Test]
        public void StandardUser_CanSortProductsByPriceLowToHigh()
        {
            Assert.That(inventoryPage.IsInventoryContainerDisplayed(), Is.True, "Expected to land on the inventory page after login");

            inventoryPage.SortByLowToHigh();

            var prices = inventoryPage.GetDisplayedPrices();
            Assert.That(prices, Is.Ordered.Ascending, "Expected prices to be sorted from low to high");
        }

        [Test]
        public void AddingProductToCart_ShowsRemoveButtonAndUpdatesBadge()
        {
            const string product = "Sauce Labs Bolt T-Shirt";

            inventoryPage.AddProductToCart(product);

            Assert.Multiple((Action)(() =>
            {
                Assert.That(inventoryPage.IsProductInCart(product), Is.True, "Expected the button to switch to Remove");
                Assert.That(inventoryPage.GetCartItemCount(), Is.EqualTo(1), "Expected the cart badge to show 1 item");
            }));
        }

        [Test]
        public void RemovingProductFromCart_HidesBadgeAndRestoresAddButton()
        {
            const string product = "Sauce Labs Bolt T-Shirt";

            inventoryPage.AddProductToCart(product);
            inventoryPage.RemoveProductFromCart(product);

            Assert.Multiple((Action)(() =>
            {
                Assert.That(inventoryPage.IsProductInCart(product), Is.False, "Expected the button to switch back to Add to cart");
                Assert.That(inventoryPage.GetCartItemCount(), Is.EqualTo(0), "Expected the cart badge to disappear");
            }));
        }

        [Test]
        public void CartPage_ShowsCorrectlyAddedProductData()
        {
            const string product = "Sauce Labs Backpack";
            decimal expectedPrice = inventoryPage.GetProductPrice(product);

            var cartPage = inventoryPage.AddProductToCart(product).GoToCart();

            Assert.Multiple((Action)(() =>
            {
                Assert.That(cartPage.IsProductListed(product), Is.True, "Expected the added product to appear in the cart");
                Assert.That(cartPage.GetProductPrice(product), Is.EqualTo(expectedPrice), "Expected the cart price to match the inventory price");
            }));
        }

        [Test]
        public void CompletingCheckout_ShowsCorrectItemTotalAndThankYouPage()
        {
            const string product = "Sauce Labs Backpack";
            decimal expectedPrice = inventoryPage.GetProductPrice(product);

            var checkoutStepTwo = inventoryPage
                .AddProductToCart(product)
                .GoToCart()
                .ClickCheckout()
                .EnterFirstName("Andras")
                .EnterLastName("Sebes")
                .EnterPostalCode("1111")
                .ClickContinue();

            Assert.That(checkoutStepTwo.GetItemTotal(), Is.EqualTo(expectedPrice), "Expected the item total to match the product price");

            var completePage = checkoutStepTwo.ClickFinish();

            Assert.That(completePage.IsPonyExpressImageDisplayed(), Is.True, "Expected the Thank You page to show the Pony Express image");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}