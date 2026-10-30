using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class HomePage(IWebDriver driver) : BasePage(driver)
{
    private static By CategoryCard(string category) =>
        By.XPath($"//div[contains(@class, 'card')]//h5[text()='{category}']");

    private static By SectionMenuItem(string section) =>
        By.XPath($"//li[contains(@class, 'btn')]//span[@class='text' and text()='{section}']");

    public HomePage OpenCategory(string category)
    {
        Click(CategoryCard(category));
        return this;
    }

    public HomePage OpenSection(string section)
    {
        Click(SectionMenuItem(section)); 
        return this;
    }
}