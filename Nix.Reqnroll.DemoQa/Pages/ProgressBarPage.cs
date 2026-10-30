using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class ProgressBarPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly TimeSpan ProgressTimeout = TimeSpan.FromSeconds(30);

    private static readonly By StartStopButton = By.Id("startStopButton");
    private static readonly By ResetButton = By.Id("resetButton");
    private static readonly By ControlButton = By.XPath("//button[@id='startStopButton' or @id='resetButton']");
    private static readonly By ProgressBar = By.CssSelector("#progressBar [role='progressbar']");

    public ProgressBarPage StartAndWaitUntilComplete()
    {
        Click(StartStopButton);

        new WebDriverWait(Driver, ProgressTimeout)
            .Until(webDriver => webDriver.FindElement(ProgressBar).GetDomAttribute("aria-valuenow") == "100");

        return this;
    }

    public ProgressBarPage Reset()
    {
        Click(ResetButton);
        return this;
    }

    public string GetButtonText()
    {
        return WaitForElement(ControlButton).Text;
    }

    public string GetProgressText()
    {
        return WaitForElement(ProgressBar).Text;
    }
}