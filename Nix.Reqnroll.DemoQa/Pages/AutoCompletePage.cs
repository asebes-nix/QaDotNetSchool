using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class AutoCompletePage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By MultipleInput = By.Id("autoCompleteMultipleInput");
    private static readonly By Suggestions = By.CssSelector(".auto-complete__menu .auto-complete__option");
    private static readonly By SelectedColors = By.CssSelector(".auto-complete__multi-value__label");

    private static By Suggestion(string color) =>
        By.XPath($"//div[contains(@class, 'auto-complete__option') and text()='{color}']");

    private static By RemoveButton(string color) =>
        By.CssSelector($"div[role='button'][aria-label='Remove {color}']");

    public AutoCompletePage TypeIntoMultipleField(string text)
    {
        ScrollTo(MultipleInput).SendKeys(text);
        return this;
    }

    public AutoCompletePage AddColor(string color)
    {
        TypeIntoMultipleField(color);
        Click(Suggestion(color));
        return this;
    }

    public AutoCompletePage RemoveColor(string color)
    {
        Click(RemoveButton(color));
        return this;
    }

    public List<string> GetSuggestions()
    {
        WaitForElement(Suggestions);
        return [.. Driver.FindElements(Suggestions).Select(option => option.Text)];
    }

    public List<string> GetSelectedColors()
    {
        return [.. Driver.FindElements(SelectedColors).Select(label => label.Text)];
    }
}