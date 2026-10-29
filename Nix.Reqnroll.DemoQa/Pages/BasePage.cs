using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Nix.Reqnroll.DemoQa.Pages;

internal abstract class BasePage(IWebDriver driver)
{
    protected IWebDriver Driver => driver;

    protected IWebElement WaitForElement(By locator)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(webDriver => webDriver.FindElement(locator));
    }

    protected void Click(By locator)
    {
        IWebElement element = WaitForElement(locator);
        var js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);

        try
        {
            element.Click();
        }
        catch (ElementClickInterceptedException)
        {
            js.ExecuteScript("arguments[0].click();", element);
        }
    }
}