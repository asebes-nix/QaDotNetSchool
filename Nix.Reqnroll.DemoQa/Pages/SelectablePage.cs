using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class SelectablePage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By SelectedGridSquares = By.CssSelector("#gridContainer li.active");

    private static By Tab(string name) =>
        By.XPath($"//button[@role='tab' and normalize-space()='{name}']");

    private static By GridSquare(int position) =>
        By.XPath($"(//div[@id='gridContainer']//li)[{position}]");

    public SelectablePage SwitchToTab(string name)
    {
        Click(Tab(name));
        return this;
    }

    public SelectablePage SelectGridSquare(int position)
    {
        Click(GridSquare(position));
        return this;
    }

    public List<string> GetSelectedGridValues()
    {
        return [.. Driver.FindElements(SelectedGridSquares).Select(square => square.Text)];
    }
}