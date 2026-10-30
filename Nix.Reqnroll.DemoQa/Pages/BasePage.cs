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

    protected IWebElement ScrollTo(By locator)
    {
        RemoveAds();
        IWebElement element = WaitForElement(locator);
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'instant'});", element);
        return element;
    }

    protected void EnsureNotCovered(IWebElement element)
    {
        var covering = (string?)((IJavaScriptExecutor)driver).ExecuteScript(
            """
        const rect = arguments[0].getBoundingClientRect();
        const top = document.elementFromPoint(rect.left + rect.width / 2, rect.top + rect.height / 2);
        return arguments[0].contains(top) ? null : top?.outerHTML.slice(0, 200);
        """, element);

        if (covering is not null)
        {
            throw new InvalidOperationException($"Element is covered by: {covering}");
        }
    }

    private void RemoveAds()
    {
        ((IJavaScriptExecutor)driver).ExecuteScript(
            """
        document.querySelectorAll(
            "ins.adsbygoogle, [id^='google_ads'], iframe[src*='doubleclick'], iframe[src*='googlesyndication'], #fixedban"
        ).forEach(ad => ad.remove());
        """);
    }

    protected void Click(By locator)
    {
        IWebElement element = ScrollTo(locator);

        try
        {
            element.Click();
        }
        catch (ElementClickInterceptedException)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}