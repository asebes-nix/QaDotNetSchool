using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Nix.Selenium.Pages;

internal class SideMenu(IWebDriver webDriver)
{
    private IWebElement MenuButton => webDriver.FindElement(By.Id("react-burger-menu-btn"));
    private IWebElement ResetAppStateLink => webDriver.FindElement(By.Id("reset_sidebar_link"));

    public SideMenu ResetAppState()
    {
        MenuButton.Click();
        new WebDriverWait(webDriver, TimeSpan.FromSeconds(5))
            .Until(driver => driver.FindElement(By.Id("reset_sidebar_link")).Displayed);
        ResetAppStateLink.Click();
        return this;
    }
}