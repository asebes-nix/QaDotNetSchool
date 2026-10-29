using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class WebTablesPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By TableRows = By.CssSelector("table tbody tr");

    private static By ColumnHeader(string column) =>
        By.XPath($"//table/thead//th[normalize-space()='{column}']");

    private static By ColumnCells(string column) =>
        By.XPath($"//table/tbody/tr/td[count(//table/thead//th[normalize-space()='{column}']/preceding-sibling::th) + 1]");

    private static By DeleteButton(string firstName) =>
        By.XPath($"//table/tbody/tr[td[1][normalize-space()='{firstName}']]//span[@title='Delete']");

    public WebTablesPage ClickColumnHeader(string column)
    {
        Click(ColumnHeader(column));
        return this;
    }

    public WebTablesPage DeleteRow(string firstName)
    {
        Click(DeleteButton(firstName));
        return this;
    }

    public int GetRowCount()
    {
        return Driver.FindElements(TableRows).Count;
    }

    public List<string> GetColumnValues(string column)
    {
        WaitForElement(ColumnCells(column));
        return [.. Driver.FindElements(ColumnCells(column)).Select(cell => cell.Text)];
    }
}