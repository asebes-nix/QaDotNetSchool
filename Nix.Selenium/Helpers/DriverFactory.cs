using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Nix.Selenium.Helpers;

internal static class DriverFactory
{
    public static IWebDriver CreateChrome()
    {
        var options = new ChromeOptions();
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        return new ChromeDriver(options);
    }
}