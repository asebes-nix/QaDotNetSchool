using Nix.Reqnroll.DemoQa.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Nix.Reqnroll.DemoQa.StepDefinitions;

[Binding]
public class ElementsSteps(IWebDriver driver)
{
    private readonly TextBoxPage _textBoxPage = new(driver);
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
}