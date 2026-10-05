using Nix.Selenium.Helpers;
using Nix.Selenium.Pages;
using OpenQA.Selenium;

namespace Nix.Selenium.Tests;

internal class Task2Tests
{
    private IWebDriver _driver;
    private InventoryPage _inventoryPage;

    [SetUp]
    public void SetUp()
    {
        _driver = DriverFactory.CreateChrome();
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        new LoginPage(_driver)
            .EnterUsername("standard_user")
            .EnterPassword("secret_sauce")
            .ClickLoginButton();

        _inventoryPage = new InventoryPage(_driver);
    }

    [Test]
    public void StandardUser_CanSortProductsByPriceLowToHigh()
    {
        Assert.That(_inventoryPage.IsInventoryContainerDisplayed(), Is.True, "Expected to land on the inventory page after login");

        _inventoryPage.SortByLowToHigh();

        var prices = _inventoryPage.GetDisplayedPrices();
        Assert.That(prices, Is.Ordered.Ascending, "Expected prices to be sorted from low to high");
    }

    [Test]
    public void AddingProductToCart_ShowsRemoveButtonAndUpdatesBadge()
    {
        const string product = "Sauce Labs Bolt T-Shirt";

        _inventoryPage.AddProductToCart(product);

        Assert.Multiple((Action)(() =>
        {
            Assert.That(_inventoryPage.IsProductInCart(product), Is.True, "Expected the button to switch to Remove");
            Assert.That(_inventoryPage.GetCartItemCount(), Is.EqualTo(1), "Expected the cart badge to show 1 item");
        }));
    }

    [Test]
    public void RemovingProductFromCart_HidesBadgeAndRestoresAddButton()
    {
        const string product = "Sauce Labs Bolt T-Shirt";

        _inventoryPage.AddProductToCart(product);
        _inventoryPage.RemoveProductFromCart(product);

        Assert.Multiple((Action)(() =>
        {
            Assert.That(_inventoryPage.IsProductInCart(product), Is.False, "Expected the button to switch back to Add to cart");
            Assert.That(_inventoryPage.GetCartItemCount(), Is.EqualTo(0), "Expected the cart badge to disappear");
        }));
    }

    [Test]
    public void CartPage_ShowsCorrectlyAddedProductData()
    {
        const string product = "Sauce Labs Backpack";
        decimal expectedPrice = _inventoryPage.GetProductPrice(product);

        var cartPage = _inventoryPage.AddProductToCart(product).GoToCart();

        Assert.Multiple((Action)(() =>
        {
            Assert.That(cartPage.IsProductListed(product), Is.True, "Expected the added product to appear in the cart");
            Assert.That(cartPage.GetProductPrice(product), Is.EqualTo(expectedPrice), "Expected the cart price to match the inventory price");
        }));
    }

    [Test]
    public void RemovingProductInCart_ClearsBadge_AndContinueShoppingAllowsAddingAnotherProduct()
    {
        const string firstProduct = "Sauce Labs Bolt T-Shirt";
        const string secondProduct = "Sauce Labs Backpack";

        var cartPage = _inventoryPage.AddProductToCart(firstProduct).GoToCart();
        cartPage.RemoveProduct(firstProduct);

        Assert.Multiple((Action)(() =>
        {
            Assert.That(cartPage.IsProductListed(firstProduct), Is.False, "Expected the removed product to disappear from the cart");
            Assert.That(cartPage.GetCartItemCount(), Is.EqualTo(0), "Expected the cart badge to disappear");
        }));

        var inventoryPage = cartPage.ClickContinueShopping();
        inventoryPage.AddProductToCart(secondProduct);

        Assert.That(inventoryPage.IsProductInCart(secondProduct), Is.True, "Expected the second product to be added after continuing shopping");
    }

    [Test]
    public void CompletingCheckout_ShowsCorrectItemTotalAndThankYouPage()
    {
        const string product = "Sauce Labs Backpack";
        decimal expectedPrice = _inventoryPage.GetProductPrice(product);

        var checkoutStepTwo = _inventoryPage
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
        _driver.Quit();
        _driver.Dispose();
    }
}