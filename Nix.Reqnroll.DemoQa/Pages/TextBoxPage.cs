using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class TextBoxPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By SubmitButton = By.Id("submit");

    private static By InputFor(string field) => field switch
    {
        "Full Name" => By.Id("userName"),
        "Email" => By.Id("userEmail"),
        "Current Address" => By.CssSelector("textarea#currentAddress"),
        "Permanent Address" => By.CssSelector("textarea#permanentAddress"),
        _ => throw new ArgumentException($"Unknown Text Box field: '{field}'", nameof(field))
    };

    private static By OutputFor(string field) => field switch
    {
        "Full Name" => By.CssSelector("#output #name"),
        "Email" => By.CssSelector("#output #email"),
        "Current Address" => By.CssSelector("#output #currentAddress"),
        "Permanent Address" => By.CssSelector("#output #permanentAddress"),
        _ => throw new ArgumentException($"Unknown Text Box output field: '{field}'", nameof(field))
    };

    public TextBoxPage FillField(string field, string value)
    {
        IWebElement input = WaitForElement(InputFor(field));
        input.Clear();
        input.SendKeys(value);
        return this;
    }

    public TextBoxPage Submit()
    {
        Click(SubmitButton);
        return this;
    }

    public string GetOutputValue(string field)
    {
        string text = WaitForElement(OutputFor(field)).Text;
        return text[(text.IndexOf(':') + 1)..].Trim();
    }
}