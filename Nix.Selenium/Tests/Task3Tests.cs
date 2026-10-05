using Nix.Selenium.Helpers;
using Nix.Selenium.Pages;
using OpenQA.Selenium;

namespace Nix.Selenium.Tests;

internal class Task3Tests
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

    [TestCase("Test.allTheThings() T-Shirt (Red)")]
    [TestCase("Sauce Labs Fleece Jacket")]
    [TestCase("Sauce Labs Bike Light")]
    public void ProductPriceInCart_MatchesInventoryPrice(string productName)
    {
        decimal expectedPrice = _inventoryPage.GetProductPrice(productName);

        var cartPage = _inventoryPage
            .AddProductToCart(productName)
            .GoToCart();

        Assert.That(cartPage.GetProductPrice(productName), Is.EqualTo(expectedPrice), "Expected the cart price to match the inventory price");
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            new SideMenu(_driver).ResetAppState();
        }
        finally
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}