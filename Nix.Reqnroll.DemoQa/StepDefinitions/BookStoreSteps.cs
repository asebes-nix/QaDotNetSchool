using Nix.Reqnroll.DemoQa.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Nix.Reqnroll.DemoQa.StepDefinitions;

[Binding]
public class BookStoreSteps(IWebDriver driver)
{
    private readonly BookStorePage _bookStorePage = new(driver);

    [When("the user sorts the book list by {string} in {word} order")]
    public void WhenTheUserSortsTheBookListBy(string column, string direction)
    {
        _bookStorePage.SortBy(column, direction);
    }

    [Then("the book list is sorted by {string} in {word} order")]
    public void ThenTheBookListIsSortedBy(string column, string direction)
    {
        List<string> values = _bookStorePage.GetColumnValues(column);
        var comparer = (IComparer<string>)StringComparer.OrdinalIgnoreCase;

        var order = direction == "ascending"
            ? Is.Ordered.Ascending.Using(comparer)
            : Is.Ordered.Descending.Using(comparer);

        Assert.Multiple(() =>
        {
            Assert.That(values, order, $"Expected '{column}' values in {direction} order");
            Assert.That(_bookStorePage.GetSortState(column),
                Is.EqualTo(direction == "ascending" ? "sorted-asc" : "sorted-desc"),
                "Expected the header to show the matching sort indicator");
        });
    }
}