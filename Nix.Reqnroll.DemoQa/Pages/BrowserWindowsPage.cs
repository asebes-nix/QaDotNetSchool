using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class BrowserWindowsPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By SampleHeading = By.Id("sampleHeading");

    private static By Button(string name) =>
        By.XPath($"//button[normalize-space()='{name}']");

    public BrowserWindowsPage OpenAndSwitchToNewWindow(string buttonName)
    {
        IReadOnlyCollection<string> existingWindows = Driver.WindowHandles;

        Click(Button(buttonName));

        new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
            .Until(webDriver => webDriver.WindowHandles.Count > existingWindows.Count);

        string newWindow = Driver.WindowHandles.Except(existingWindows).Single();
        Driver.SwitchTo().Window(newWindow);
        return this;
    }

    public string GetSampleHeading()
    {
        return WaitForElement(SampleHeading).Text;
    }
}