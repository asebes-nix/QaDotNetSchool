using Nix.Selenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Nix.Selenium.Tests
{
    internal class Task1Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Starting WebDriver...");
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        [Test]
        public void LockedOutUser_ShowsWarningAndStaysOnLoginPage()
        {
            var loginPage = new LoginPage(driver)
                .EnterUsername("locked_out_user")
                .EnterPassword("secret_sauce")
                .ClickLoginButton();

            Assert.Multiple((Action)(() =>
            {
                Assert.That(loginPage.IsLoginLogoDisplayed(), Is.True, "Expected to stay on the login page");
                Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
            }));
            loginPage.CloseErrorMessage();
            //Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
