using OpenQA.Selenium;

namespace Nix.Selenium.Pages;

internal class CheckoutCompletePage(IWebDriver webDriver)
{
    private IWebElement PonyExpressImage => webDriver.FindElement(By.CssSelector("img[alt='Pony Express']"));

    public bool IsPonyExpressImageDisplayed()
    {
        return PonyExpressImage.Displayed;
    }
}