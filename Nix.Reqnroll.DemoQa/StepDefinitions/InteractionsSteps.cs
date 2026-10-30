using Nix.Reqnroll.DemoQa.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.StepDefinitions;

[Binding]
public class InteractionsSteps(IWebDriver driver)
{
    private readonly SelectablePage _selectablePage = new(driver);

    [Given("the user switches to the {string} tab")]
    public void GivenTheUserSwitchesToTheTab(string tab)
    {
        _selectablePage.SwitchToTab(tab);
    }

    [When("the user selects the following grid squares")]
    public void WhenTheUserSelectsTheFollowingGridSquares(DataTable table)
    {
        foreach (DataTableRow row in table.Rows)
        {
            _selectablePage.SelectGridSquare(int.Parse(row["Square"]));
        }
    }

    [Then("the selected grid squares contain the following values")]
    public void ThenTheSelectedGridSquaresContainTheFollowingValues(DataTable table)
    {
        List<string> expected = [.. table.Rows.Select(row => row["Value"])];

        Assert.That(_selectablePage.GetSelectedGridValues(), Is.EqualTo(expected));
    }
}