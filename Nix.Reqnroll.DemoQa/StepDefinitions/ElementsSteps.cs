using Nix.Reqnroll.DemoQa.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.StepDefinitions;

[Binding]
public class ElementsSteps(IWebDriver driver)
{
    private readonly TextBoxPage _textBoxPage = new(driver);
    private readonly CheckBoxPage _checkBoxPage = new(driver);
    private readonly WebTablesPage _webTablesPage = new(driver);
    private readonly ButtonsPage _buttonsPage = new(driver);
    private readonly Dictionary<string, string> _submittedData = [];


    [When("the user submits the Text Box form with the following data")]
    public void WhenTheUserSubmitsTheTextBoxFormWithTheFollowingData(DataTable table)
    {
        foreach (DataTableRow row in table.Rows)
        {
            _textBoxPage.FillField(row["Field"], row["Value"]);
            _submittedData[row["Field"]] = row["Value"];
        }

        _textBoxPage.Submit();
    }

    [Then("the output shows the submitted data")]
    public void ThenTheOutputShowsTheSubmittedData()
    {
        Assert.Multiple(() =>
        {
            foreach (var (field, expected) in _submittedData)
            {
                Assert.That(_textBoxPage.GetOutputValue(field), Is.EqualTo(expected), $"Output mismatch for '{field}'");
            }
        });
    }

    [When("the user expands the {string} folder")]
    public void WhenTheUserExpandsTheFolder(string folder)
    {
        _checkBoxPage.ExpandFolder(folder);
    }

    [When("the user checks the {string} item")]
    public void WhenTheUserChecksTheItem(string item)
    {
        _checkBoxPage.CheckItem(item);
    }

    [When("the user checks the following items")]
    public void WhenTheUserChecksTheFollowingItems(DataTable table)
    {
        foreach (DataTableRow row in table.Rows)
        {
            _checkBoxPage.CheckItem(row["Item"]);
        }
    }

    [Then("the Check Box result shows {string}")]
    public void ThenTheCheckBoxResultShows(string expected)
    {
        string[] expectedItems = expected
            .Replace("You have selected :", "")
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Assert.That(_checkBoxPage.GetSelectedItems(), Is.EquivalentTo(expectedItems),
            "Expected exactly the listed items to be selected");
    }

    [When("the user clicks the {string} column header")]
    public void WhenTheUserClicksTheColumnHeader(string column)
    {
        _webTablesPage.ClickColumnHeader(column);
    }

    [When("the user deletes the row of {string}")]
    public void WhenTheUserDeletesTheRowOf(string firstName)
    {
        _webTablesPage.DeleteRow(firstName);
    }

    [Then("the values in the {string} column are in ascending order")]
    public void ThenTheValuesInTheColumnAreInAscendingOrder(string column)
    {
        List<decimal> values = [.. _webTablesPage.GetColumnValues(column).Select(decimal.Parse)];

        Assert.That(values, Is.Ordered.Ascending, $"Expected '{column}' values to be in ascending order");
    }

    [Then("the table has {int} rows")]
    public void ThenTheTableHasRows(int expectedCount)
    {
        Assert.That(_webTablesPage.GetRowCount(), Is.EqualTo(expectedCount));
    }

    [Then("the {string} column does not contain {string}")]
    public void ThenTheColumnDoesNotContain(string column, string value)
    {
        Assert.That(_webTablesPage.GetColumnValues(column), Does.Not.Contain(value));
    }

    [When("the user clicks the {string} button")]
    public void WhenTheUserClicksTheButton(string button)
    {
        _buttonsPage.ClickButton(button);
    }

    [Then("only the message {string} is displayed")]
    public void ThenOnlyTheMessageIsDisplayed(string message)
    {
        Assert.That(_buttonsPage.GetMessages(), Is.EqualTo([message]),
            "Expected exactly one confirmation message");
    }
}