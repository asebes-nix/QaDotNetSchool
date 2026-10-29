using Nix.Reqnroll.DemoQa.Drivers;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Nix.Reqnroll.DemoQa.Support;

[Binding]
public class Hooks(IObjectContainer container)
{
    private const string BaseUrl = "https://demoqa.com/";

    [BeforeScenario]
    public void StartBrowser()
    {
        string browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome";

        IWebDriver driver = DriverFactory.Create(browser);
        driver.Navigate().GoToUrl(BaseUrl);

        container.RegisterInstanceAs(driver);
    }

    [AfterScenario]
    public void CloseBrowser()
    {
        container.Resolve<IWebDriver>().Quit();
    }
}