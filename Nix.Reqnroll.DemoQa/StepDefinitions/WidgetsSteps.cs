using Nix.Reqnroll.DemoQa.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.StepDefinitions;

[Binding]
public class WidgetsSteps(IWebDriver driver)
{
    private readonly AutoCompletePage _autoCompletePage = new(driver);
    private readonly ProgressBarPage _progressBarPage = new(driver);

    [When("the user types {string} into the multiple color names field")]
    public void WhenTheUserTypesIntoTheMultipleColorNamesField(string text)
    {
        _autoCompletePage.TypeIntoMultipleField(text);
    }

    [When("the user adds the following colors")]
    public void WhenTheUserAddsTheFollowingColors(DataTable table)
    {
        foreach (DataTableRow row in table.Rows)
        {
            _autoCompletePage.AddColor(row["Color"]);
        }
    }

    [When("the user removes the following colors")]
    public void WhenTheUserRemovesTheFollowingColors(DataTable table)
    {
        foreach (DataTableRow row in table.Rows)
        {
            _autoCompletePage.RemoveColor(row["Color"]);
        }
    }

    [When("the user starts the progress bar and waits until it reaches 100%")]
    public void WhenTheUserStartsTheProgressBarAndWaitsUntilItReaches100()
    {
        _progressBarPage.StartAndWaitUntilComplete();
    }

    [When("the user resets the progress bar")]
    public void WhenTheUserResetsTheProgressBar()
    {
        _progressBarPage.Reset();
    }

    [Then("{int} color suggestions are offered")]
    public void ThenColorSuggestionsAreOffered(int expectedCount)
    {
        Assert.That(_autoCompletePage.GetSuggestions(), Has.Count.EqualTo(expectedCount));
    }

    [Then("every color suggestion contains {string}")]
    public void ThenEveryColorSuggestionContains(string text)
    {
        List<string> suggestions = _autoCompletePage.GetSuggestions();

        Assert.Multiple(() =>
        {
            foreach (string suggestion in suggestions)
            {
                Assert.That(suggestion, Does.Contain(text).IgnoreCase, $"Suggestion '{suggestion}' does not contain '{text}'");
            }
        });
    }

    [Then("the multiple color names field contains exactly")]
    public void ThenTheMultipleColorNamesFieldContainsExactly(DataTable table)
    {
        List<string> expected = [.. table.Rows.Select(row => row["Color"])];

        Assert.That(_autoCompletePage.GetSelectedColors(), Is.EqualTo(expected));
    }

    [Then("the progress bar button shows {string}")]
    public void ThenTheProgressBarButtonShows(string text)
    {
        Assert.That(_progressBarPage.GetButtonText(), Is.EqualTo(text));
    }

    [Then("the progress bar shows {string}")]
    public void ThenTheProgressBarShows(string value)
    {
        Assert.That(_progressBarPage.GetProgressText(), Is.EqualTo(value));
    }
}