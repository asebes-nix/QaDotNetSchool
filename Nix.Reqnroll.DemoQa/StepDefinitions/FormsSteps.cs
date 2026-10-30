using Nix.Reqnroll.DemoQa.Pages;
using Nix.Reqnroll.DemoQa.Support;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.StepDefinitions;

[Binding]
public class FormsSteps(IWebDriver driver)
{
    private readonly PracticeFormPage _practiceFormPage = new(driver);
    private readonly Dictionary<string, string> _expectedTextValues = [];

    [When("the user fills in all text fields with random data")]
    public void WhenTheUserFillsInAllTextFieldsWithRandomData()
    {
        string firstName = RandomData.FirstName();
        string lastName = RandomData.LastName();
        string email = RandomData.Email(firstName, lastName);
        string mobile = RandomData.Mobile();
        string address = RandomData.Address();

        _practiceFormPage
            .EnterFirstName(firstName)
            .EnterLastName(lastName)
            .EnterEmail(email)
            .EnterMobile(mobile)
            .EnterCurrentAddress(address);

        _expectedTextValues["Student Name"] = $"{firstName} {lastName}";
        _expectedTextValues["Student Email"] = email;
        _expectedTextValues["Mobile"] = mobile;
        _expectedTextValues["Address"] = address;

        Console.WriteLine($"Generated test data: {string.Join(", ", _expectedTextValues.Select(pair => $"{pair.Key}={pair.Value}"))}");
    }

    [When("the user selects the {string} gender")]
    public void WhenTheUserSelectsTheGender(string gender)
    {
        _practiceFormPage.SelectGender(gender);
    }

    [When("the user enters {string} as date of birth")]
    public void WhenTheUserEntersAsDateOfBirth(string date)
    {
        _practiceFormPage.EnterDateOfBirth(date);
    }

    [When("the user adds the following subjects")]
    public void WhenTheUserAddsTheFollowingSubjects(DataTable table)
    {
        foreach (DataTableRow row in table.Rows)
        {
            _practiceFormPage.AddSubject(row["Subject"]);
        }
    }

    [When("the user selects the following hobbies")]
    public void WhenTheUserSelectsTheFollowingHobbies(DataTable table)
    {
        foreach (DataTableRow row in table.Rows)
        {
            _practiceFormPage.SelectHobby(row["Hobby"]);
        }
    }

    [When("the user selects the {string} state")]
    public void WhenTheUserSelectsTheState(string state)
    {
        _practiceFormPage.SelectState(state);
    }

    [When("the user types {string} into the city field and presses Enter")]
    public void WhenTheUserTypesIntoTheCityFieldAndPressesEnter(string city)
    {
        _practiceFormPage.TypeCityAndPressEnter(city);
    }

    [When("the user submits the Practice Form")]
    public void WhenTheUserSubmitsThePracticeForm()
    {
        _practiceFormPage.Submit();
    }

    [Then("the confirmation modal shows the entered text field data")]
    public void ThenTheConfirmationModalShowsTheEnteredTextFieldData()
    {
        AssertModalValues(_expectedTextValues);
    }

    [Then("the confirmation modal shows the following values")]
    public void ThenTheConfirmationModalShowsTheFollowingValues(DataTable table)
    {
        AssertModalValues(table.Rows.ToDictionary(row => row["Label"], row => row["Value"]));
    }

    private void AssertModalValues(Dictionary<string, string> expectedValues)
    {
        Assert.Multiple(() =>
        {
            foreach (var (label, expected) in expectedValues)
            {
                Assert.That(_practiceFormPage.GetModalValue(label), Is.EqualTo(expected), $"Modal mismatch for '{label}'");
            }
        });
    }
}