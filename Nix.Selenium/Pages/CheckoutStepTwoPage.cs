using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Nix.Selenium.Pages;

internal class CheckoutStepTwoPage(IWebDriver webDriver)
{
    private IWebElement ItemTotalLabel => webDriver.FindElement(By.ClassName("summary_subtotal_label"));

    public decimal GetItemTotal()
    {
        string text = ItemTotalLabel.Text;
        string numberPart = text.Replace("Item total: $", "");
        return decimal.Parse(numberPart);
    }

    private IWebElement FinishButton => webDriver.FindElement(By.Id("finish"));

    public CheckoutCompletePage ClickFinish()
    {
        FinishButton.Click();
        new WebDriverWait(webDriver, TimeSpan.FromSeconds(5))
            .Until(driver => driver.FindElement(By.CssSelector("img[alt='Pony Express']")).Displayed);
        return new CheckoutCompletePage(webDriver);
    }
}