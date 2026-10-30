using Nix.Reqnroll.DemoQa.Pages;
using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.StepDefinitions;

[Binding]
public class CommonSteps(IWebDriver driver)
{
    private readonly HomePage _homePage = new(driver);

    [Given("the user opens the {string} category")]
    public void GivenTheUserOpensTheCategory(string category)
    {
        _homePage.OpenCategory(category);
    }

    [Given("the user opens the {string} section")]
    public void GivenTheUserOpensTheSection(string section)
    {
        _homePage.OpenSection(section);
    }
}