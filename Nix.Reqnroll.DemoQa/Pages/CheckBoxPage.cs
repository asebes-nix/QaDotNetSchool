using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class CheckBoxPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By ResultItems = By.CssSelector("#result .text-success");

    private static string TreeNodeXPath(string title) =>
        $"//div[@role='treeitem'][.//span[@class='rc-tree-title' and text()='{title}']]";

    private static By TreeNode(string title) =>
        By.XPath(TreeNodeXPath(title));

    private static By ExpandToggle(string title) =>
        By.XPath($"{TreeNodeXPath(title)}//span[contains(@class, 'rc-tree-switcher')]");

    private static By Checkbox(string title) =>
        By.CssSelector($"span.rc-tree-checkbox[aria-label='Select {title}']");

    public CheckBoxPage ExpandFolder(string folder)
    {
        string? expanded = WaitForElement(TreeNode(folder)).GetDomAttribute("aria-expanded");

        if (expanded != "true")
        {
            Click(ExpandToggle(folder));
        }

        return this;
    }

    public CheckBoxPage CheckItem(string item)
    {
        Click(Checkbox(item));
        return this;
    }

    public List<string> GetSelectedItems()
    {
        WaitForElement(ResultItems);
        return [.. Driver.FindElements(ResultItems).Select(element => element.Text)];
    }
}