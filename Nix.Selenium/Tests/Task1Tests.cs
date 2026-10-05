using Nix.Selenium.Helpers;
using Nix.Selenium.Pages;
using OpenQA.Selenium;

namespace Nix.Selenium.Tests;

internal class Task1Tests
{
    private IWebDriver _driver;

    [SetUp]
    public void SetUp()
    {
        _driver = DriverFactory.CreateChrome();
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [Test]
    public void LockedOutUser_ShowsWarningAndStaysOnLoginPage()
    {
        var loginPage = new LoginPage(_driver)
            .EnterUsername("locked_out_user")
            .EnterPassword("secret_sauce")
            .ClickLoginButton();

        Assert.Multiple((Action)(() =>
        {
            Assert.That(loginPage.IsLoginLogoDisplayed(), Is.True, "Expected to stay on the login page");
            Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
        }));
        loginPage.CloseErrorMessage();
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
