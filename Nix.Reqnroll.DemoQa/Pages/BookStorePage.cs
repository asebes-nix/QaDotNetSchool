using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class BookStorePage(IWebDriver driver) : BasePage(driver)
{
    private static string ColumnHeaderXPath(string column) =>
        $"//table/thead//th[span[text()[normalize-space()='{column}']]]";

    private static By ColumnHeader(string column) =>
        By.XPath(ColumnHeaderXPath(column));

    private static By SortIndicator(string column) =>
        By.XPath($"{ColumnHeaderXPath(column)}//span[@aria-label]");

    private static By ColumnCells(string column) =>
        By.XPath($"//table/tbody/tr/td[count({ColumnHeaderXPath(column)}/preceding-sibling::th) + 1]");

    private static string SortStateFor(string direction) => direction switch
    {
        "ascending" => "sorted-asc",
        "descending" => "sorted-desc",
        _ => throw new ArgumentException($"Unknown sort direction: '{direction}'", nameof(direction))
    };

    public BookStorePage SortBy(string column, string direction)
    {
        string expectedState = SortStateFor(direction);

        for (int click = 0; click < 3 && GetSortState(column) != expectedState; click++)
        {
            Click(ColumnHeader(column));
        }

        return this;
    }

    public string? GetSortState(string column)
    {
        WaitForElement(ColumnHeader(column));
        var indicators = Driver.FindElements(SortIndicator(column));
        return indicators.Count == 0 ? null : indicators[0].GetDomAttribute("aria-label");
    }

    public List<string> GetColumnValues(string column)
    {
        WaitForElement(ColumnCells(column));
        return [.. Driver.FindElements(ColumnCells(column)).Select(cell => cell.Text)];
    }
}