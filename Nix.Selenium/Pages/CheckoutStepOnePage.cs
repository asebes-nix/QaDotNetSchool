using OpenQA.Selenium;

namespace Nix.Selenium.Pages;

internal class CheckoutStepOnePage(IWebDriver webDriver)
{
    private IWebElement FirstNameInput => webDriver.FindElement(By.Id("first-name"));

    public CheckoutStepOnePage EnterFirstName(string firstName)
    {
        FirstNameInput.SendKeys(firstName);
        return this;
    }

    private IWebElement LastNameInput => webDriver.FindElement(By.Id("last-name"));

    public CheckoutStepOnePage EnterLastName(string lastName)
    {
        LastNameInput.SendKeys(lastName);
        return this;
    }

    private IWebElement PostalCodeInput => webDriver.FindElement(By.Id("postal-code"));

    public CheckoutStepOnePage EnterPostalCode(string postalCode)
    {
        PostalCodeInput.SendKeys(postalCode);
        return this;
    }

    private IWebElement ContinueButton => webDriver.FindElement(By.Id("continue"));

    public CheckoutStepTwoPage ClickContinue()
    {
        ContinueButton.Click();
        return new CheckoutStepTwoPage(webDriver);
    }
}
