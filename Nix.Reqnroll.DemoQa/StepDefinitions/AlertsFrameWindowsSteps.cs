using Nix.Reqnroll.DemoQa.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.StepDefinitions;

[Binding]
public class AlertsFrameWindowsSteps(IWebDriver driver)
{
    private readonly BrowserWindowsPage _browserWindowsPage = new(driver);

    [When("the user opens a new window with the {string} button")]
    public void WhenTheUserOpensANewWindowWithTheButton(string button)
    {
        _browserWindowsPage.OpenAndSwitchToNewWindow(button);
    }

    [Then("the new window shows the heading {string}")]
    public void ThenTheNewWindowShowsTheHeading(string heading)
    {
        Assert.That(_browserWindowsPage.GetSampleHeading(), Is.EqualTo(heading));
    }
}