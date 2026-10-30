using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class ButtonsPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By Messages = By.CssSelector("p[id$='ClickMessage']");

    private static By Button(string name) =>
        By.XPath($"//button[normalize-space()='{name}']");

    public ButtonsPage ClickButton(string name)
    {

        IWebElement button = ScrollTo(Button(name));
        EnsureNotCovered(button);
        var actions = new Actions(Driver);

        switch (name)
        {
            case "Double Click Me":
                actions.DoubleClick(button).Perform();
                break;
            case "Right Click Me":
                actions.ContextClick(button).Perform();
                break;
            case "Click Me":
                actions.Click(button).Perform();
                break;
            default:
                throw new ArgumentException($"Unknown button: '{name}'", nameof(name));
        }

        return this;
    }

    public List<string> GetMessages()
    {
        WaitForElement(Messages);
        return [.. Driver.FindElements(Messages).Select(message => message.Text)];
    }
}