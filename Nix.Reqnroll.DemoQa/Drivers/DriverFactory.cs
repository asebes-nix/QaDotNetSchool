using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Nix.Reqnroll.DemoQa.Drivers;

internal static class DriverFactory
{
    public static IWebDriver Create(string browser)
    {
        IWebDriver driver = browser.ToLowerInvariant() switch
        {
            "chrome" => CreateChrome(),
            "firefox" => new FirefoxDriver(),
            "edge" => new EdgeDriver(),
            _ => throw new ArgumentException($"Unsupported browser: '{browser}'. Use chrome, firefox or edge.", nameof(browser))
        };

        driver.Manage().Window.Maximize();
        return driver;
    }

    private static ChromeDriver CreateChrome()
    {
        var options = new ChromeOptions();
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        return new ChromeDriver(options);
    }
}